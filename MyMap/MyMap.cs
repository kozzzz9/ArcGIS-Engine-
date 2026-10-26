using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Output;
using ESRI.ArcGIS.SystemUI;
using Path = System.IO.Path;
using ArcPoint = ESRI.ArcGIS.Geometry.Point;

namespace MyMap
{
    /// <summary>
    /// 主窗体：基于 ArcGIS Engine 的地图浏览与应用程序。
    /// 功能包括图层加载、地图渲染、属性查看、地图浏览与测量、
    /// 图层管理、地图文档与图片导出、属性与点选查询、书签与制版打印等。
    /// </summary>
    public partial class MyMap : Form
    {
        #region 私有字段

        /// <summary>图层树右键菜单。</summary>
        private ContextMenuStrip _tocContextMenu;

        /// <summary>右键菜单当前操作的图层。</summary>
        private ILayer _contextMenuLayer;

        /// <summary>已添加的书签数量，用于书签自动命名。</summary>
        private int _bookmarkCount;

        /// <summary>鹰眼图控件（运行时创建到“鹰眼”页签的面板中）。</summary>
        private AxMapControl _overviewMapControl;

        /// <summary>Mxd 地图文档操作类实例（实习十二：自定义类封装文档操作）。</summary>
        private readonly MyMxdDocClass _mxdDoc = new MyMxdDocClass();

        /// <summary>当前地图交互动作模式。</summary>
        private MapAction _pendingAction = MapAction.None;

        /// <summary>是否正在橡皮带交互中（防止 TrackNew 期间事件重入）。</summary>
        private bool _actionRunning;

        /// <summary>当前测量结果图形（结果对话框关闭后自动移除）。</summary>
        private IElement _measureElement;

        /// <summary>地图交互动作模式。</summary>
        private enum MapAction
        {
            None,
            MeasureDistance,
            MeasureArea,
            RectangleSelect,
            PolygonSelect
        }

        #endregion

        #region 构造函数与窗体加载

        /// <summary>
        /// 创建主窗体并初始化地图控件与菜单。
        /// </summary>
        public MyMap()
        {
            ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.EngineOrDesktop);
            InitializeComponent();
        }

        private void MyMap_Load(object sender, EventArgs e)
        {
            // 将工具栏与图层树控件绑定到地图控件，否则两者不显示任何内容
            axToolbarControl1.SetBuddyControl(axMapControl1);
            axTOCControl1.SetBuddyControl(axMapControl1);

            // 图层树右键菜单
            BuildTocContextMenu();

            // 鹰眼图
            InitializeOverview();
            tabControl1.SelectedIndexChanged += new EventHandler(tabControl1_SelectedIndexChanged);

            // 工具栏补充常用地图浏览工具；失败时保留菜单操作入口
            try
            {
                axToolbarControl1.AddItem(new ControlsMapZoomInTool());
                axToolbarControl1.AddItem(new ControlsMapZoomOutTool());
                axToolbarControl1.AddItem(new ControlsMapPanTool());
                axToolbarControl1.AddItem(new ControlsMapFullExtentCommand());
            }
            catch
            {
                // 工具栏添加按钮失败不影响主功能，菜单中仍有对应入口
            }

            UpdateStatusBar();
        }

        private void axToolbarControl1_OnMouseDown(object sender, ESRI.ArcGIS.Controls.IToolbarControlEvents_OnMouseDownEvent e)
        {

        }

        #endregion

        #region 现有功能：添加图层

        /// <summary>
        /// 添加矢量图层（shapefile）到地图控件。
        /// </summary>
        private void addVectorLayerMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "shapefile文件（*.shp）|*.shp";

            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult != DialogResult.OK)
            {
                return;
            }

            string path = openFileDialog.FileName;
            string folder = Path.GetDirectoryName(path);
            string fileName = Path.GetFileName(path);

            IWorkspaceFactory workspaceFactory = new ShapefileWorkspaceFactory();
            IWorkspace workspace = workspaceFactory.OpenFromFile(folder, 0);
            if (workspace == null)
            {
                MessageBox.Show("无法打开该工作空间！");
                return;
            }
            IFeatureWorkspace featureWorkspace = workspace as IFeatureWorkspace;
            IFeatureClass featureClass = featureWorkspace.OpenFeatureClass(fileName);
            if (featureClass == null)
            {
                MessageBox.Show("无法打开该矢量数据集！");
                return;
            }
            IFeatureLayer featureLayer = new FeatureLayer();
            featureLayer.FeatureClass = featureClass;
            featureLayer.Name = featureClass.AliasName;
            ILayer layer = featureLayer as ILayer;
            axMapControl1.Map.AddLayer(layer);
            axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
            UpdateStatusBar();
            SyncOverview();
        }

        /// <summary>
        /// 添加栅格图层到地图控件。
        /// </summary>
        private void addRasterLayerMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "栅格影像(*.tif;*.tiff;*.img;*.jpg;*.png)|*.tif;*.tiff;*.img;*.jpg;*.png";
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult != DialogResult.OK)
            {
                return;
            }
            string path = openFileDialog.FileName;
            string folder = Path.GetDirectoryName(path);
            string fileName = Path.GetFileName(path);

            IRasterLayer rasterLayer = new RasterLayer();
            IWorkspaceFactory workspaceFactory = new RasterWorkspaceFactory();
            IWorkspace workspace = workspaceFactory.OpenFromFile(folder, 0);
            IRasterWorkspace rasterWorkspace = workspace as IRasterWorkspace;
            IRasterDataset rasterDataset = null;

            bool loadSuccess = false;
            if (rasterWorkspace != null)
            {
                rasterDataset = rasterWorkspace.OpenRasterDataset(fileName);
                if (rasterDataset != null)
                {
                    rasterLayer.CreateFromDataset(rasterDataset);
                    loadSuccess = true;
                }
            }

            if (!loadSuccess)
            {
                try
                {
                    rasterLayer.CreateFromFilePath(path);
                    loadSuccess = true;
                }
                catch
                {
                    MessageBox.Show("栅格文件打开失败！");
                    return;
                }
            }

            rasterLayer.Name = fileName;
            ILayer layer = rasterLayer as ILayer;
            if (layer == null)
            {
                MessageBox.Show("栅格图层转换失败！");
                return;
            }
            axMapControl1.Map.AddLayer(layer);
            axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewAll, null, null);
            UpdateStatusBar();
            SyncOverview();
        }

        #endregion

        #region 现有功能：地图渲染

        /// <summary>
        /// 对指定的矢量图层使用给定的符号进行简单渲染（单一符号）。
        /// </summary>
        /// <param name="featureLayer">待渲染的矢量图层。</param>
        /// <param name="symbol">用于渲染的符号，可为点、线、面符号。</param>
        private void DefineSimpleRender(IFeatureLayer featureLayer, ISymbol symbol)
        {
            if (featureLayer == null)
            {
                MessageBox.Show("未选择图层，或者图层非矢量图层！");
                return;
            }

            if (symbol == null)
            {
                MessageBox.Show("未获取到渲染符号！");
                return;
            }

            // 设置简单渲染的相关属性
            ISimpleRenderer simpleRenderer = new SimpleRenderer();
            simpleRenderer.Symbol = symbol;

            // 接口转换，对渲染方式进行设置
            IGeoFeatureLayer geoFeatureLayer = featureLayer as IGeoFeatureLayer;
            if (geoFeatureLayer == null)
            {
                MessageBox.Show("该图层不支持渲染！");
                return;
            }
            geoFeatureLayer.Renderer = simpleRenderer as IFeatureRenderer;

            // 地图刷新
            axMapControl1.Refresh();
        }

        /// <summary>
        /// 创建默认的红色面符号（保留原示例中的默认值）。
        /// </summary>
        private static ISymbol CreateDefaultFillSymbol()
        {
            IRgbColor color = new RgbColor();
            color.Red = 255;
            color.Blue = 0;
            color.Green = 0;

            // 设置用于渲染的符号的基本属性
            ISimpleFillSymbol simpleFeatureSymbol = new SimpleFillSymbol();
            simpleFeatureSymbol.Style = esriSimpleFillStyle.esriSFSSolid;
            simpleFeatureSymbol.Outline.Width = 0.4;
            simpleFeatureSymbol.Color = color as IColor;

            return simpleFeatureSymbol as ISymbol;
        }

        /// <summary>
        /// 简单渲染菜单：弹出渲染设置对话框并对选中图层应用单一符号渲染。
        /// </summary>
        private void simpleRenderMenuItem_Click(object sender, EventArgs e)
        {
            IFeatureLayer featureLayer = GetSelectedFeatureLayer();
            if (featureLayer == null)
            {
                return;
            }

            // 获取图层几何类型（点、线、面），用于决定对话框显示哪些参数
            esriGeometryType geometryType = GetLayerGeometryType(featureLayer);

            // 取图层当前的符号，用于初始化对话框的默认值
            ISymbol currentSymbol = GetCurrentSymbol(featureLayer);

            // 弹出渲染设置对话框，由用户调整点大小/颜色、线粗细/颜色、面填充色/边线等
            using (SimpleRenderDialog dialog = new SimpleRenderDialog(geometryType, currentSymbol))
            {
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                ISymbol symbol = dialog.ResultSymbol;
                if (symbol == null)
                {
                    return;
                }

                // 对图层进行渲染处理
                DefineSimpleRender(featureLayer, symbol);
            }
        }

        /// <summary>
        /// 获取矢量图层的几何类型（点、线、面）。
        /// </summary>
        private static esriGeometryType GetLayerGeometryType(IFeatureLayer featureLayer)
        {
            IFeatureClass featureClass = featureLayer.FeatureClass;
            if (featureClass == null)
            {
                return esriGeometryType.esriGeometryAny;
            }
            return featureClass.ShapeType;
        }

        /// <summary>
        /// 获取图层当前使用的渲染符号。
        /// </summary>
        private static ISymbol GetCurrentSymbol(IFeatureLayer featureLayer)
        {
            IGeoFeatureLayer geoFeatureLayer = featureLayer as IGeoFeatureLayer;
            if (geoFeatureLayer == null)
            {
                return null;
            }

            IFeatureRenderer renderer = geoFeatureLayer.Renderer;
            if (renderer == null)
            {
                return null;
            }

            // 单一符号渲染器
            ISimpleRenderer simpleRenderer = renderer as ISimpleRenderer;
            if (simpleRenderer != null)
            {
                return simpleRenderer.Symbol;
            }

            // 唯一值渲染器：取第一个值对应的符号
            IUniqueValueRenderer uniqueValueRenderer = renderer as IUniqueValueRenderer;
            if (uniqueValueRenderer != null && uniqueValueRenderer.ValueCount > 0)
            {
                return uniqueValueRenderer.get_Symbol(uniqueValueRenderer.get_Value(0));
            }

            return null;
        }

        /// <summary>
        /// 唯一值渲染菜单：为选中的矢量图层按唯一值字段生成不同符号。
        /// </summary>
        private void uniqueValueRenderMenuItem_Click(object sender, EventArgs e)
        {
            IFeatureLayer featureLayer = GetSelectedFeatureLayer();
            if (featureLayer == null)
            {
                return;
            }

            IFeatureClass featureClass = featureLayer.FeatureClass;
            if (featureClass == null)
            {
                MessageBox.Show("该图层没有对应的要素类！");
                return;
            }

            // 获取图层几何类型（点、线、面），用于生成默认符号
            esriGeometryType geometryType = GetLayerGeometryType(featureLayer);

            // 取图层当前的符号，作为符号模板
            ISymbol currentSymbol = GetCurrentSymbol(featureLayer);

            using (UniqueValueRenderDialog dialog =
                new UniqueValueRenderDialog(featureClass, geometryType, currentSymbol))
            {
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                // 由对话框结果生成唯一值渲染器
                IUniqueValueRenderer renderer = UniqueValueRenderHelper.CreateRenderer(
                    dialog.SelectedField,
                    dialog.SelectedFieldIsString,
                    dialog.ValueSymbols,
                    dialog.DefaultSymbol,
                    dialog.UseDefaultSymbol);

                if (renderer == null)
                {
                    MessageBox.Show("生成唯一值渲染器失败！");
                    return;
                }

                // 渲染到图层
                DefineUniqueValueRender(featureLayer, renderer);
            }
        }

        /// <summary>
        /// 将唯一值渲染器应用到指定图层并刷新地图。
        /// </summary>
        /// <param name="featureLayer">待渲染的矢量图层。</param>
        /// <param name="renderer">唯一值渲染器。</param>
        private void DefineUniqueValueRender(IFeatureLayer featureLayer, IUniqueValueRenderer renderer)
        {
            IGeoFeatureLayer geoFeatureLayer = featureLayer as IGeoFeatureLayer;
            if (geoFeatureLayer == null)
            {
                MessageBox.Show("该图层不支持渲染！");
                return;
            }

            IFeatureRenderer featureRenderer = renderer as IFeatureRenderer;
            if (featureRenderer == null)
            {
                MessageBox.Show("唯一值渲染器无法转换为要素渲染器！");
                return;
            }

            geoFeatureLayer.Renderer = featureRenderer;

            // 地图刷新
            axMapControl1.Refresh();
        }

        #endregion

        #region 现有功能：查看属性

        /// <summary>
        /// 查看属性菜单：以表格形式展示选中矢量图层的属性。
        /// </summary>
        private void viewAttributeMenuItem_Click(object sender, EventArgs e)
        {
            IFeatureLayer featureLayer = GetSelectedFeatureLayer();
            if (featureLayer == null)
            {
                return;
            }

            ShowAttributeTable(featureLayer);
        }

        /// <summary>
        /// 打开属性表窗体，并订阅要素变化事件以刷新地图。
        /// </summary>
        /// <param name="featureLayer">待展示属性的矢量图层。</param>
        private void ShowAttributeTable(IFeatureLayer featureLayer)
        {
            using (FeatureAttributeTable form = new FeatureAttributeTable(featureLayer, axMapControl1.ActiveView))
            {
                form.FeaturesChanged += attributeTable_FeaturesChanged;
                form.ShowDialog(this);
            }
        }

        /// <summary>
        /// 属性表中要素被修改或删除后刷新地图显示。
        /// </summary>
        private void attributeTable_FeaturesChanged(object sender, EventArgs e)
        {
            axMapControl1.Refresh();
            UpdateStatusBar();
        }

        #endregion

        #region 扩展功能：地图浏览

        /// <summary>
        /// 全图：缩放到地图完整范围。
        /// </summary>
        private void fullExtentMenuItem_Click(object sender, EventArgs e)
        {
            axMapControl1.Extent = axMapControl1.FullExtent;
            axMapControl1.ActiveView.Refresh();
        }

        /// <summary>
        /// 放大：激活地图放大工具。
        /// </summary>
        private void zoomInMenuItem_Click(object sender, EventArgs e)
        {
            SetCurrentTool(new ControlsMapZoomInTool());
        }

        /// <summary>
        /// 缩小：激活地图缩小工具。
        /// </summary>
        private void zoomOutMenuItem_Click(object sender, EventArgs e)
        {
            SetCurrentTool(new ControlsMapZoomOutTool());
        }

        /// <summary>
        /// 漫游：激活地图漫游工具。
        /// </summary>
        private void panMenuItem_Click(object sender, EventArgs e)
        {
            SetCurrentTool(new ControlsMapPanTool());
        }

        /// <summary>
        /// 上一视图：返回到上一个地图范围。
        /// </summary>
        private void zoomToLastExtentBackMenuItem_Click(object sender, EventArgs e)
        {
            ExecuteCommand(new ControlsMapZoomToLastExtentBackCommand());
        }

        /// <summary>
        /// 下一视图：前进到下一个地图范围。
        /// </summary>
        private void zoomToLastExtentForwardMenuItem_Click(object sender, EventArgs e)
        {
            ExecuteCommand(new ControlsMapZoomToLastExtentForwardCommand());
        }

        /// <summary>
        /// 将地图命令设置为地图控件的当前工具。
        /// </summary>
        /// <param name="command">ArcGIS Engine 内置工具命令。</param>
        private void SetCurrentTool(ICommand command)
        {
            if (command == null)
            {
                return;
            }

            command.OnCreate(axMapControl1.Object);
            ITool tool = command as ITool;
            if (tool != null)
            {
                axMapControl1.CurrentTool = tool;
            }
        }

        /// <summary>
        /// 创建并执行一次地图命令（立即生效，不作为当前工具）。
        /// </summary>
        /// <param name="command">ArcGIS Engine 内置命令。</param>
        private void ExecuteCommand(ICommand command)
        {
            if (command == null)
            {
                return;
            }

            command.OnCreate(axMapControl1.Object);
            command.OnClick();
        }

        #endregion

        #region 扩展功能：测量

        /// <summary>
        /// 测距菜单：在地图上跟踪一条线并显示其长度。
        /// </summary>
        private void measureDistanceMenuItem_Click(object sender, EventArgs e)
        {
            // 只设定动作模式，起点由用户在地图上第一次单击确定
            SetMapAction(MapAction.MeasureDistance, (ToolStripMenuItem)sender,
                "测距：在地图上按下左键并拖动画线，松开后显示距离");
        }

        /// <summary>
        /// 测面积菜单：在地图上跟踪一个多边形并显示其面积。
        /// </summary>
        private void measureAreaMenuItem_Click(object sender, EventArgs e)
        {
            SetMapAction(MapAction.MeasureArea, (ToolStripMenuItem)sender,
                "测面积：在地图上依次单击各顶点，双击结束");
        }

        /// <summary>
        /// 创建测距与框选拖动时显示的红色实线符号。
        /// </summary>
        private static ISymbol CreateMeasureLineSymbol()
        {
            ISimpleLineSymbol lineSymbol = new SimpleLineSymbol();
            lineSymbol.Style = esriSimpleLineStyle.esriSLSSolid;
            lineSymbol.Width = 2;
            IRgbColor red = new RgbColor();
            red.Red = 255;
            lineSymbol.Color = red;
            return (ISymbol)lineSymbol;
        }

        /// <summary>
        /// 创建测面积与圈选拖动时显示的红色空心面符号（只显示轮廓）。
        /// </summary>
        private static ISymbol CreateMeasureFillSymbol()
        {
            ISimpleLineSymbol outline = new SimpleLineSymbol();
            outline.Style = esriSimpleLineStyle.esriSLSSolid;
            outline.Width = 2;
            IRgbColor red = new RgbColor();
            red.Red = 255;
            outline.Color = red;

            ISimpleFillSymbol fillSymbol = new SimpleFillSymbol();
            fillSymbol.Style = esriSimpleFillStyle.esriSFSHollow;
            fillSymbol.Outline = outline;
            return (ISymbol)fillSymbol;
        }

        /// <summary>
        /// 把测量结果以图形元素绘制到地图上（可用“清除分析结果”清除）。
        /// </summary>
        /// <param name="geometry">测量得到的线或面几何。</param>
        /// <param name="symbol">显示符号。</param>
        private void DrawMeasureGeometry(IGeometry geometry, ISymbol symbol)
        {
            IGraphicsContainer container = (IGraphicsContainer)axMapControl1.Map;

            IElement element = null;

            if (geometry is IPolyline)
            {
                ILineElement lineElement = (ILineElement)new LineElement();
                ((ILineElement)lineElement).Symbol = (ILineSymbol)symbol;
                element = (IElement)lineElement;
            }
            else if (geometry is IPolygon)
            {
                element = (IElement)new PolygonElement();
                ((IFillShapeElement)element).Symbol = (IFillSymbol)symbol;
            }

            if (element == null)
            {
                return;
            }

            element.Geometry = geometry;

            // 同一时间只保留最新一条测量图形
            RemoveMeasureGraphic();
            container.AddElement(element, 0);
            _measureElement = element;
            axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        /// <summary>
        /// 移除当前测量结果图形（测量结果对话框关闭后自动调用）。
        /// </summary>
        private void RemoveMeasureGraphic()
        {
            if (_measureElement == null)
            {
                return;
            }

            IGraphicsContainer container = (IGraphicsContainer)axMapControl1.Map;
            container.DeleteElement(_measureElement);
            _measureElement = null;
            axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        /// <summary>
        /// 获取当前地图单位的中文名称。
        /// </summary>
        private string GetMapUnitName()
        {
            switch (axMapControl1.Map.MapUnits)
            {
                case esriUnits.esriMeters: return "米";
                case esriUnits.esriKilometers: return "千米";
                case esriUnits.esriFeet: return "英尺";
                case esriUnits.esriMiles: return "英里";
                case esriUnits.esriDecimalDegrees: return "度";
                default: return "地图单位";
            }
        }

        #endregion

        #region 扩展功能：书签管理

        /// <summary>
        /// 添加书签菜单：把当前地图范围保存为书签。
        /// </summary>
        private void addBookmarkMenuItem_Click(object sender, EventArgs e)
        {
            IMapBookmarks mapBookmarks = (IMapBookmarks)axMapControl1.Map;
            IAOIBookmark bookmark = new AOIBookmark();
            bookmark.Name = string.Format("书签{0}", ++_bookmarkCount);
            bookmark.Location = axMapControl1.ActiveView.Extent;
            mapBookmarks.AddBookmark(bookmark);
            statusStripInfoLabel.Text = "已添加书签：" + bookmark.Name;
        }

        /// <summary>
        /// 管理书签菜单：在对话框中查看、转到或删除书签。
        /// </summary>
        private void manageBookmarksMenuItem_Click(object sender, EventArgs e)
        {
            IMapBookmarks mapBookmarks = (IMapBookmarks)axMapControl1.Map;
            using (BookmarkDialog dialog = new BookmarkDialog(mapBookmarks))
            {
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                ISpatialBookmark bookmark = dialog.SelectedBookmark;
                if (bookmark == null)
                {
                    return;
                }

                bookmark.ZoomTo(axMapControl1.Map);
                axMapControl1.ActiveView.Refresh();
            }
        }

        #endregion

        #region 扩展功能：图层管理

        /// <summary>
        /// 移除 TOC 中当前选中的图层。
        /// </summary>
        private void removeLayerMenuItem_Click(object sender, EventArgs e)
        {
            ILayer selectedLayer = GetSelectedLayer();
            if (selectedLayer == null)
            {
                MessageBox.Show("请先在图层列表中选择一个图层！");
                return;
            }

            DialogResult dialogResult = MessageBox.Show(
                string.Format("确定要移除图层“{0}”吗？", selectedLayer.Name),
                "确认移除",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dialogResult != DialogResult.Yes)
            {
                return;
            }

            axMapControl1.Map.DeleteLayer(selectedLayer);
            axMapControl1.ActiveView.Refresh();
            UpdateStatusBar();
            SyncOverview();
        }

        /// <summary>
        /// 清空地图中的全部图层。
        /// </summary>
        private void clearLayersMenuItem_Click(object sender, EventArgs e)
        {
            if (axMapControl1.Map.LayerCount == 0)
            {
                MessageBox.Show("当前地图没有图层！");
                return;
            }

            DialogResult dialogResult = MessageBox.Show(
                "确定要清空地图中的全部图层吗？",
                "确认清空",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dialogResult != DialogResult.Yes)
            {
                return;
            }

            axMapControl1.Map.ClearLayers();
            axMapControl1.ActiveView.Refresh();
            UpdateStatusBar();
            SyncOverview();
        }

        /// <summary>
        /// 刷新地图显示。
        /// </summary>
        private void refreshMapMenuItem_Click(object sender, EventArgs e)
        {
            axMapControl1.Refresh();
        }

        #endregion

        #region 扩展功能：地图文档与导出

        /// <summary>
        /// 新建Mxd文档菜单：调用地图文档操作类新建空白文档并加载。
        /// </summary>
        private void newMxdDocMenuItem_Click(object sender, EventArgs e)
        {
            _mxdDoc.newMapDoc(axMapControl1);
            UpdateStatusBar();
            SyncOverview();
        }

        /// <summary>
        /// 打开Mxd文档菜单：调用地图文档操作类打开文档并加载到地图控件。
        /// </summary>
        private void openMxdDocMenuItem_Click(object sender, EventArgs e)
        {
            _mxdDoc.openMapDoc(axMapControl1);
            UpdateStatusBar();
            SyncOverview();
        }

        /// <summary>
        /// 保存Mxd文档菜单：调用地图文档操作类保存当前文档。
        /// </summary>
        private void saveMxdDocMenuItem_Click(object sender, EventArgs e)
        {
            _mxdDoc.saveMapDoc(axMapControl1);
        }

        /// <summary>
        /// 另存Mxd文档菜单：调用地图文档操作类把当前地图另存为新文档。
        /// </summary>
        private void saveAsMxdDocMenuItem_Click(object sender, EventArgs e)
        {
            _mxdDoc.SaveAsMapDoc(axMapControl1);
        }

        /// <summary>
        /// 添加图层文件（.lyr）到地图控件。
        /// </summary>
        private void addLayerFileMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "添加图层文件";
                dialog.Filter = "图层文件(*.lyr)|*.lyr";
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    axMapControl1.AddLayerFromFile(dialog.FileName, 0);
                    axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewAll, null, null);
                    UpdateStatusBar();
                    SyncOverview();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("添加图层文件失败：" + ex.Message);
                }
            }
        }

        /// <summary>
        /// 将当前地图视图导出为图片（PNG/JPG）。
        /// </summary>
        private void exportMapImageMenuItem_Click(object sender, EventArgs e)
        {
            if (axMapControl1.Map.LayerCount == 0)
            {
                MessageBox.Show("当前地图没有可导出的图层！");
                return;
            }

            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Title = "导出地图为图片";
                dialog.Filter = "PNG 图片(*.png)|*.png|JPEG 图片(*.jpg)|*.jpg|PDF 文档(*.pdf)|*.pdf";
                dialog.OverwritePrompt = true;
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                ExportActiveView(dialog.FileName);
            }
        }

        /// <summary>
        /// 按文件扩展名将当前地图视图导出为 PNG、JPG 或 PDF。
        /// </summary>
        /// <param name="fileName">目标文件路径。</param>
        private void ExportActiveView(string fileName)
        {
            string extension = Path.GetExtension(fileName).ToLower();
            IExport export;
            if (extension == ".jpg" || extension == ".jpeg")
            {
                export = (IExport)new ExportJPEG();
            }
            else if (extension == ".pdf")
            {
                export = (IExport)new ExportPDF();
            }
            else
            {
                export = (IExport)new ExportPNG();
            }

            try
            {
                export.ExportFileName = fileName;
                export.Resolution = 96;

                // 像素范围取当前地图视图的导出框
                IActiveView activeView = (IActiveView)axMapControl1.ActiveView;
                tagRECT exportFrame = activeView.ExportFrame;
                IEnvelope pixelBounds = (IEnvelope)new Envelope();
                pixelBounds.PutCoords(exportFrame.left, exportFrame.top, exportFrame.right, exportFrame.bottom);
                export.PixelBounds = pixelBounds;

                // 通过 IActiveView.Output 将地图绘制到导出设备上下文
                ITrackCancel trackCancel = (ITrackCancel)new CancelTracker();
                int hDC = export.StartExporting();
                activeView.Output(hDC, (int)export.Resolution, ref exportFrame, null, trackCancel);
                export.FinishExporting();
                export.Cleanup();
                MessageBox.Show("地图导出成功：" + fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("地图导出失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 导出选中要素菜单：把选中图层的选中要素导出为新的 Shapefile。
        /// </summary>
        private void exportSelectedFeaturesMenuItem_Click(object sender, EventArgs e)
        {
            IFeatureLayer sourceLayer = GetSelectedFeatureLayer();
            if (sourceLayer == null)
            {
                return;
            }

            IFeatureSelection featureSelection = sourceLayer as IFeatureSelection;
            if (featureSelection == null || featureSelection.SelectionSet == null ||
                featureSelection.SelectionSet.Count == 0)
            {
                MessageBox.Show("请先选择该图层中的要素（属性查询、点选查询或框选查询）！");
                return;
            }

            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Title = "导出选中要素为 Shapefile";
                dialog.Filter = "shapefile文件（*.shp）|*.shp";
                dialog.OverwritePrompt = true;
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                string folder = Path.GetDirectoryName(dialog.FileName);
                string fileName = Path.GetFileNameWithoutExtension(dialog.FileName);

                try
                {
                    int count = ExportFeaturesToShapefile(sourceLayer, folder, fileName);
                    MessageBox.Show(string.Format("成功导出 {0} 个要素到：{1}", count, dialog.FileName));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("导出选中要素失败：" + ex.Message);
                }
            }
        }

        /// <summary>
        /// 把图层中的选中要素导出为新的 Shapefile。
        /// </summary>
        /// <param name="sourceLayer">源矢量图层。</param>
        /// <param name="folder">目标文件夹。</param>
        /// <param name="fileName">目标 Shapefile 名（不含扩展名）。</param>
        /// <returns>导出的要素数量。</returns>
        private int ExportFeaturesToShapefile(IFeatureLayer sourceLayer, string folder, string fileName)
        {
            IFeatureClass sourceClass = sourceLayer.FeatureClass;

            // 1. 把目标文件夹作为 shapefile 工作空间
            IWorkspaceFactory workspaceFactory = new ShapefileWorkspaceFactory();
            IFeatureWorkspace targetWorkspace =
                (IFeatureWorkspace)workspaceFactory.OpenFromFile(folder, 0);

            // 2. 用字段检查器转换源字段（字段名合法性、重名处理）
            IFieldChecker fieldChecker = new FieldChecker();
            fieldChecker.ValidateWorkspace = (IWorkspace)targetWorkspace;
            IEnumFieldError enumFieldError;
            IFields validatedFields;
            fieldChecker.Validate(sourceClass.Fields, out enumFieldError, out validatedFields);

            // 3. 重新设置几何字段的 GeometryDef（shapefile 需要明确的几何类型）
            for (int i = 0; i < validatedFields.FieldCount; i++)
            {
                IField field = validatedFields.get_Field(i);
                if (field.Type != esriFieldType.esriFieldTypeGeometry)
                {
                    continue;
                }

                IGeometryDef geometryDef = new GeometryDef();
                IGeometryDefEdit geometryDefEdit = (IGeometryDefEdit)geometryDef;
                geometryDefEdit.GeometryType_2 = sourceClass.ShapeType;
                geometryDefEdit.GridCount_2 = 1;
                geometryDefEdit.set_GridSize(0, 0);
                IFieldEdit fieldEdit = (IFieldEdit)validatedFields.get_Field(i);
                fieldEdit.GeometryDef_2 = geometryDef;
            }

            // 4. 创建目标要素类
            IFeatureClass targetClass = targetWorkspace.CreateFeatureClass(
                fileName + ".shp",
                validatedFields,
                null,
                null,
                esriFeatureType.esriFTSimple,
                sourceClass.ShapeFieldName,
                "");

            // 5. 逐条复制选中要素（几何复制 + 同名字段值复制）
            IFeatureSelection featureSelection = sourceLayer as IFeatureSelection;
            ICursor selectedCursor;
            featureSelection.SelectionSet.Search(null, true, out selectedCursor);
            IFeatureCursor sourceCursor = (IFeatureCursor)selectedCursor;

            IFeatureBuffer featureBuffer = targetClass.CreateFeatureBuffer();
            IFeatureCursor insertCursor = targetClass.Insert(true);
            int count = 0;

            try
            {
                IFeature sourceFeature = sourceCursor.NextFeature();
                while (sourceFeature != null)
                {
                    // ShapeCopy 返回几何的副本
                    featureBuffer.Shape = sourceFeature.ShapeCopy;

                    for (int i = 0; i < validatedFields.FieldCount; i++)
                    {
                        IField targetField = validatedFields.get_Field(i);
                        if (targetField.Type == esriFieldType.esriFieldTypeGeometry ||
                            targetField.Type == esriFieldType.esriFieldTypeOID)
                        {
                            continue;
                        }

                        int sourceIndex = sourceClass.Fields.FindField(targetField.Name);
                        if (sourceIndex >= 0)
                        {
                            featureBuffer.set_Value(i, sourceFeature.get_Value(sourceIndex));
                        }
                    }

                    insertCursor.InsertFeature(featureBuffer);
                    count++;
                    sourceFeature = sourceCursor.NextFeature();
                }
                insertCursor.Flush();
            }
            finally
            {
                UniqueValueRenderHelper.ReleaseComObject(insertCursor);
                UniqueValueRenderHelper.ReleaseComObject(sourceCursor);
                UniqueValueRenderHelper.ReleaseComObject(featureBuffer);
            }

            return count;
        }

        #endregion

        #region 扩展功能：查询分析

        /// <summary>
        /// 属性查询菜单：按 SQL 条件选择要素。
        /// </summary>
        private void attributeQueryMenuItem_Click(object sender, EventArgs e)
        {
            List<IFeatureLayer> featureLayers = GetFeatureLayers();
            if (featureLayers.Count == 0)
            {
                MessageBox.Show("请先添加矢量图层！");
                return;
            }

            using (AttributeQueryDialog dialog = new AttributeQueryDialog(featureLayers))
            {
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    int count = SelectFeaturesByWhere(dialog.SelectedLayer, dialog.WhereClause);
                    MessageBox.Show(string.Format("属性查询完成，共选中 {0} 个要素。", count));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("属性查询失败，请检查查询条件是否正确：" + ex.Message);
                }
                UpdateStatusBar();
            }
        }

        /// <summary>
        /// 点选查询开关：开启后在地图上单击即可选择要素。
        /// </summary>
        private void pointSelectMenuItem_Click(object sender, EventArgs e)
        {
            statusStripInfoLabel.Text = 点选查询ToolStripMenuItem.Checked
                ? "点选查询已开启：在地图上单击选择要素"
                : "点选查询已关闭";
        }

        /// <summary>
        /// 清除地图中的全部选中要素。
        /// </summary>
        private void clearSelectionMenuItem_Click(object sender, EventArgs e)
        {
            axMapControl1.Map.ClearSelection();
            axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            UpdateStatusBar();
        }

        /// <summary>
        /// 缩放到全部选中要素的范围。
        /// </summary>
        private void zoomToSelectedMenuItem_Click(object sender, EventArgs e)
        {
            if (axMapControl1.Map.SelectionCount == 0)
            {
                MessageBox.Show("当前没有选中任何要素！");
                return;
            }

            IEnumFeature enumFeature = axMapControl1.Map.FeatureSelection as IEnumFeature;
            if (enumFeature == null)
            {
                return;
            }

            IEnvelope extent = (IEnvelope)new Envelope();
            enumFeature.Reset();
            IFeature feature = enumFeature.Next();
            while (feature != null)
            {
                IGeometry geometry = feature.Shape;
                if (geometry != null && !geometry.IsEmpty)
                {
                    extent.Union(geometry.Envelope);
                }
                feature = enumFeature.Next();
            }

            if (extent.IsEmpty)
            {
                MessageBox.Show("选中要素的范围为空！");
                return;
            }

            // 适当外扩范围，避免选中要素紧贴窗口边缘
            extent.Expand(1.2, 1.2, true);
            axMapControl1.ActiveView.Extent = extent;
            axMapControl1.ActiveView.Refresh();
        }

        /// <summary>
        /// 坐标定位菜单：输入坐标后把地图居中到该位置并打十字标记。
        /// </summary>
        private void coordinateLocationMenuItem_Click(object sender, EventArgs e)
        {
            using (CoordinateLocationDialog dialog = new CoordinateLocationDialog())
            {
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                IPoint point = new ArcPoint();
                point.PutCoords(dialog.LocationX, dialog.LocationY);

                // 在该位置添加一个十字标记
                IMarkerElement markerElement = (IMarkerElement)new MarkerElement();
                IElement element = (IElement)markerElement;
                element.Geometry = point;

                ISimpleMarkerSymbol markerSymbol = new SimpleMarkerSymbol();
                markerSymbol.Style = esriSimpleMarkerStyle.esriSMSCross;
                markerSymbol.Size = 16;
                IRgbColor red = new RgbColor();
                red.Red = 255;
                markerSymbol.Color = red;
                markerElement.Symbol = (IMarkerSymbol)markerSymbol;

                IGraphicsContainer container = (IGraphicsContainer)axMapControl1.Map;
                container.AddElement(element, 0);

                // 把该点作为视图中心
                IEnvelope extent = axMapControl1.ActiveView.Extent;
                extent.CenterAt(point);
                axMapControl1.ActiveView.Extent = extent;
                axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);

                statusStripInfoLabel.Text = string.Format(
                    "已定位到坐标：X = {0:F2}，Y = {1:F2}", dialog.LocationX, dialog.LocationY);
            }
        }

        /// <summary>
        /// 获取地图中全部矢量图层。
        /// </summary>
        private List<IFeatureLayer> GetFeatureLayers()
        {
            List<IFeatureLayer> featureLayers = new List<IFeatureLayer>();
            for (int i = 0; i < axMapControl1.Map.LayerCount; i++)
            {
                IFeatureLayer featureLayer = axMapControl1.Map.get_Layer(i) as IFeatureLayer;
                if (featureLayer != null)
                {
                    featureLayers.Add(featureLayer);
                }
            }
            return featureLayers;
        }

        /// <summary>
        /// 按属性条件选择指定图层中的要素。
        /// </summary>
        /// <param name="featureLayer">待查询的矢量图层。</param>
        /// <param name="whereClause">SQL 查询条件。</param>
        /// <returns>选中要素的数量。</returns>
        private int SelectFeaturesByWhere(IFeatureLayer featureLayer, string whereClause)
        {
            IQueryFilter queryFilter = new QueryFilter();
            queryFilter.WhereClause = whereClause;

            IFeatureSelection featureSelection = featureLayer as IFeatureSelection;
            if (featureSelection == null)
            {
                return 0;
            }

            featureSelection.SelectFeatures(queryFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
            axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            return axMapControl1.Map.SelectionCount;
        }

        #endregion

        #region 扩展功能：制版同步与打印

        /// <summary>
        /// 制版页签激活时把当前地图同步到制版控件。
        /// </summary>
        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl2.SelectedTab == Layout)
            {
                SyncPageLayout();
            }
        }

        /// <summary>
        /// 同步制版视图菜单：手动把当前地图同步到制版控件。
        /// </summary>
        private void syncPageLayoutMenuItem_Click(object sender, EventArgs e)
        {
            SyncPageLayout();
            MessageBox.Show("地图已同步到制版视图。");
        }

        /// <summary>
        /// 打印地图菜单：同步制版视图后按当前打印机设置打印。
        /// </summary>
        private void printMapMenuItem_Click(object sender, EventArgs e)
        {
            if (axMapControl1.Map.LayerCount == 0)
            {
                MessageBox.Show("当前地图没有可打印的图层！");
                return;
            }

            try
            {
                SyncPageLayout();
                axPageLayoutControl1.PrintPageLayout();
                statusStripInfoLabel.Text = "打印任务已发送：" + DateTime.Now.ToString("HH:mm:ss");
            }
            catch (Exception ex)
            {
                MessageBox.Show("打印失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 使用对象复制将地图控件中的地图同步到制版控件。
        /// </summary>
        private void SyncPageLayout()
        {
            if (axMapControl1.Map.LayerCount == 0)
            {
                return;
            }

            IObjectCopy objectCopy = (IObjectCopy)new ObjectCopy();
            object sourceMap = axMapControl1.Map;
            object targetMap = axPageLayoutControl1.ActiveView.FocusMap;
            objectCopy.Overwrite(sourceMap, ref targetMap);
            axPageLayoutControl1.ActiveView.Refresh();
            axPageLayoutControl1.ActiveView.ScreenDisplay.UpdateWindow();
        }

        #endregion

        #region 扩展功能：图层树右键菜单

        /// <summary>
        /// 构建图层树右键菜单：图层属性、缩放至图层、打开属性表、移除图层。
        /// </summary>
        private void BuildTocContextMenu()
        {
            _tocContextMenu = new ContextMenuStrip();

            ToolStripMenuItem layerPropertyItem = new ToolStripMenuItem("图层属性");
            layerPropertyItem.Click += new EventHandler(tocLayerPropertyMenuItem_Click);
            ToolStripMenuItem zoomToLayerItem = new ToolStripMenuItem("缩放至图层");
            zoomToLayerItem.Click += new EventHandler(tocZoomToLayerMenuItem_Click);
            ToolStripMenuItem viewAttributeItem = new ToolStripMenuItem("打开属性表");
            viewAttributeItem.Click += new EventHandler(tocViewAttributeMenuItem_Click);
            ToolStripMenuItem removeLayerItem = new ToolStripMenuItem("移除图层");
            removeLayerItem.Click += new EventHandler(tocRemoveLayerMenuItem_Click);

            _tocContextMenu.Items.Add(layerPropertyItem);
            _tocContextMenu.Items.Add(zoomToLayerItem);
            _tocContextMenu.Items.Add(viewAttributeItem);
            _tocContextMenu.Items.Add(removeLayerItem);
        }

        /// <summary>
        /// 右键菜单：把图层属性同步到属性面板并切换到属性页。
        /// </summary>
        private void tocLayerPropertyMenuItem_Click(object sender, EventArgs e)
        {
            if (_contextMenuLayer == null)
            {
                return;
            }

            propertyGrid1.SelectedObject = _contextMenuLayer;
            tabControl1.SelectedTab = Property;
        }

        /// <summary>
        /// 图层树鼠标按下：右键点击图层时弹出右键菜单。
        /// </summary>
        private void axTOCControl1_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            if (e.button != 2 || _tocContextMenu == null)
            {
                return;
            }

            // 命中测试，获取鼠标位置对应的图层
            esriTOCControlItem itemType = esriTOCControlItem.esriTOCControlItemNone;
            IBasicMap basicMap = null;
            ILayer layer = null;
            object other = null;
            object index = null;
            axTOCControl1.HitTest(e.x, e.y, ref itemType, ref basicMap, ref layer, ref other, ref index);
            if (layer == null)
            {
                return;
            }

            _contextMenuLayer = layer;
            _tocContextMenu.Show(axTOCControl1, new System.Drawing.Point(e.x, e.y));
        }

        /// <summary>
        /// 右键菜单：缩放到当前图层的范围。
        /// </summary>
        private void tocZoomToLayerMenuItem_Click(object sender, EventArgs e)
        {
            if (_contextMenuLayer == null)
            {
                return;
            }

            IEnvelope extent = _contextMenuLayer.AreaOfInterest;
            if (extent == null || extent.IsEmpty)
            {
                axMapControl1.Extent = axMapControl1.FullExtent;
            }
            else
            {
                axMapControl1.ActiveView.Extent = extent;
            }
            axMapControl1.ActiveView.Refresh();
        }

        /// <summary>
        /// 右键菜单：打开当前图层的属性表。
        /// </summary>
        private void tocViewAttributeMenuItem_Click(object sender, EventArgs e)
        {
            IFeatureLayer featureLayer = _contextMenuLayer as IFeatureLayer;
            if (featureLayer == null)
            {
                MessageBox.Show("该图层不是矢量图层，无法查看属性！");
                return;
            }

            ShowAttributeTable(featureLayer);
        }

        /// <summary>
        /// 右键菜单：移除当前图层。
        /// </summary>
        private void tocRemoveLayerMenuItem_Click(object sender, EventArgs e)
        {
            if (_contextMenuLayer == null)
            {
                return;
            }

            DialogResult dialogResult = MessageBox.Show(
                string.Format("确定要移除图层“{0}”吗？", _contextMenuLayer.Name),
                "确认移除",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dialogResult != DialogResult.Yes)
            {
                return;
            }

            axMapControl1.Map.DeleteLayer(_contextMenuLayer);
            axMapControl1.ActiveView.Refresh();
            UpdateStatusBar();
            SyncOverview();
        }

        #endregion

        #region 扩展功能：地图交互模式（测距/测面积/框选/圈选）

        /// <summary>
        /// 设定地图动作模式并互斥勾选菜单项；再次点击同一菜单项可取消。
        /// </summary>
        /// <param name="action">要设定的动作模式。</param>
        /// <param name="menuItem">触发本次设定的菜单项。</param>
        /// <param name="hint">操作提示文本。</param>
        private void SetMapAction(MapAction action, ToolStripMenuItem menuItem, string hint)
        {
            // CheckOnClick 已先行翻转勾选状态：勾上表示开启模式，勾掉表示取消
            bool turningOn = menuItem.Checked;
            ResetMapAction();

            if (!turningOn)
            {
                // 再次点击已勾选的菜单项表示取消模式
                UpdateStatusBar();
                return;
            }

            menuItem.Checked = true;
            _pendingAction = action;
            statusStripInfoLabel.Text = hint;
        }

        /// <summary>
        /// 取消当前动作模式。
        /// </summary>
        private void ResetMapAction()
        {
            _pendingAction = MapAction.None;
            _actionRunning = false;

            测距ToolStripMenuItem.Checked = false;
            测面积ToolStripMenuItem.Checked = false;
            框选查询ToolStripMenuItem.Checked = false;
            圈选查询ToolStripMenuItem.Checked = false;
        }

        /// <summary>
        /// 动作模式下在地图上按下左键：用橡皮带完成测量或选择。
        /// 起点就是用户按下鼠标的位置，拖动过程中橡皮带实时显示，
        /// TrackNew 自行处理绘制与擦除，松开（或双击）后返回几何。
        /// </summary>
        private void RunMapAction()
        {
            IActiveView activeView = (IActiveView)axMapControl1.ActiveView;
            IRubberBand rubberBand;
            IGeometry geometry = null;

            switch (_pendingAction)
            {
                case MapAction.RectangleSelect:
                    rubberBand = new RubberEnvelope();
                    geometry = rubberBand.TrackNew(activeView.ScreenDisplay, CreateMeasureLineSymbol());
                    break;
                case MapAction.PolygonSelect:
                    rubberBand = new RubberPolygon();
                    geometry = rubberBand.TrackNew(activeView.ScreenDisplay, CreateMeasureFillSymbol());
                    break;
                case MapAction.MeasureArea:
                    rubberBand = new RubberPolygon();
                    geometry = rubberBand.TrackNew(activeView.ScreenDisplay, CreateMeasureFillSymbol());
                    break;
                case MapAction.MeasureDistance:
                    rubberBand = new RubberLine();
                    geometry = rubberBand.TrackNew(activeView.ScreenDisplay, CreateMeasureLineSymbol());
                    break;
                default:
                    return;
            }

            if (geometry == null || geometry.IsEmpty)
            {
                return;
            }

            switch (_pendingAction)
            {
                case MapAction.RectangleSelect:
                    {
                        int count = SelectFeaturesByGeometry(geometry);
                        UpdateStatusBar();
                        statusStripInfoLabel.Text = string.Format("框选查询完成，选中 {0} 个要素。", count);
                    }
                    break;
                case MapAction.PolygonSelect:
                    {
                        int count = SelectFeaturesByGeometry(geometry);
                        UpdateStatusBar();
                        statusStripInfoLabel.Text = string.Format("圈选查询完成，选中 {0} 个要素。", count);
                    }
                    break;
                case MapAction.MeasureArea:
                    {
                        IArea area = (IArea)geometry;

                        // 结果对话框期间显示测量图形，点确定后自动清除
                        DrawMeasureGeometry(geometry, CreateMeasureFillSymbol());
                        MessageBox.Show(
                            string.Format("测量的多边形面积：{0:F2} 平方{1}", area.Area, GetMapUnitName()),
                            "测面积",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        RemoveMeasureGraphic();
                    }
                    break;
                case MapAction.MeasureDistance:
                    {
                        ICurve curve = (ICurve)geometry;

                        // 结果对话框期间显示测量图形，点确定后自动清除
                        DrawMeasureGeometry(geometry, CreateMeasureLineSymbol());
                        MessageBox.Show(
                            string.Format("测量的线段长度：{0:F2} {1}", curve.Length, GetMapUnitName()),
                            "测距",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        RemoveMeasureGraphic();
                    }
                    break;
            }
        }

        #endregion

        #region 扩展功能：地图事件与状态栏刷新

        /// <summary>
        /// 地图鼠标移动：更新状态栏中的坐标与比例尺。
        /// </summary>
        private void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            statusStripCoordLabel.Text = string.Format("当前坐标：X = {0:F2}，Y = {1:F2}", e.mapX, e.mapY);
            statusStripScaleLabel.Text = string.Format("比例尺 1:{0:F0}", axMapControl1.MapScale);
        }

        /// <summary>
        /// 地图鼠标按下：点选查询开启时，选择点击位置附近的要素。
        /// </summary>
        private void axMapControl1_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            // 动作模式下：在地图上按下左键开始橡皮带交互，起点即按下位置
            if (_pendingAction != MapAction.None && !_actionRunning && e.button == 1)
            {
                _actionRunning = true;
                try
                {
                    RunMapAction();
                }
                finally
                {
                    _actionRunning = false;
                }
                return;
            }

            if (!点选查询ToolStripMenuItem.Checked)
            {
                return;
            }

            if (axMapControl1.Map.LayerCount == 0)
            {
                return;
            }

            // 以点击位置为中心构造一个与地图范围相关的缓冲区作为查询范围
            IPoint point = new ArcPoint();
            point.PutCoords(e.mapX, e.mapY);
            ITopologicalOperator topoOperator = point as ITopologicalOperator;
            if (topoOperator == null)
            {
                return;
            }

            double tolerance = axMapControl1.ActiveView.Extent.Width / 50.0;
            if (tolerance <= 0)
            {
                tolerance = 1.0;
            }
            IGeometry searchGeometry = topoOperator.Buffer(tolerance);

            SelectFeaturesByGeometry(searchGeometry);
            UpdateStatusBar();
        }

        /// <summary>
        /// 刷新状态栏中的图层与选中要素信息。
        /// </summary>
        private void UpdateStatusBar()
        {
            statusStripInfoLabel.Text = string.Format(
                "图层数：{0}    选中要素：{1}",
                axMapControl1.Map.LayerCount,
                axMapControl1.Map.SelectionCount);
        }

        #endregion

        #region 扩展功能：空间选择

        /// <summary>
        /// 框选查询菜单：在地图上拖出一个矩形，选择范围内的要素。
        /// </summary>
        private void rectangleSelectMenuItem_Click(object sender, EventArgs e)
        {
            SetMapAction(MapAction.RectangleSelect, (ToolStripMenuItem)sender,
                "框选查询：在地图上按下左键拖出矩形，松开完成选择");
        }

        /// <summary>
        /// 圈选查询菜单：在地图上绘制一个多边形，选择范围内的要素。
        /// </summary>
        private void polygonSelectMenuItem_Click(object sender, EventArgs e)
        {
            SetMapAction(MapAction.PolygonSelect, (ToolStripMenuItem)sender,
                "圈选查询：在地图上依次单击各顶点，双击结束");
        }

        /// <summary>
        /// 按给定的几何范围选择全部可见矢量图层中的要素。
        /// </summary>
        /// <param name="searchGeometry">空间查询范围几何。</param>
        /// <returns>选中要素的数量。</returns>
        private int SelectFeaturesByGeometry(IGeometry searchGeometry)
        {
            ISpatialFilter spatialFilter = new SpatialFilter();
            spatialFilter.Geometry = searchGeometry;
            spatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;

            bool firstLayer = true;
            for (int i = 0; i < axMapControl1.Map.LayerCount; i++)
            {
                IFeatureLayer featureLayer = axMapControl1.Map.get_Layer(i) as IFeatureLayer;
                if (featureLayer == null || !featureLayer.Visible)
                {
                    continue;
                }

                IFeatureSelection featureSelection = featureLayer as IFeatureSelection;
                if (featureSelection == null)
                {
                    continue;
                }

                esriSelectionResultEnum resultType = firstLayer
                    ? esriSelectionResultEnum.esriSelectionResultNew
                    : esriSelectionResultEnum.esriSelectionResultAdd;
                featureSelection.SelectFeatures(spatialFilter, resultType, false);
                firstLayer = false;
            }

            axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            return axMapControl1.Map.SelectionCount;
        }

        #endregion

        #region 扩展功能：高级分析

        /// <summary>
        /// 分级渲染菜单：按数值字段分级设色（等间距/自然间断点/分位数）。
        /// </summary>
        private void classBreakRenderMenuItem_Click(object sender, EventArgs e)
        {
            IFeatureLayer featureLayer = GetSelectedFeatureLayer();
            if (featureLayer == null)
            {
                return;
            }

            IFeatureClass featureClass = featureLayer.FeatureClass;
            if (featureClass == null)
            {
                MessageBox.Show("该图层没有对应的要素类！");
                return;
            }

            using (ClassBreakRenderDialog dialog = new ClassBreakRenderDialog(featureClass))
            {
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    IClassBreaksRenderer renderer = BuildClassBreakRenderer(
                        featureLayer,
                        dialog.SelectedField,
                        dialog.MethodIndex,
                        dialog.ClassCount,
                        dialog.RampIndex,
                        dialog.ExcludeZero);
                    if (renderer == null)
                    {
                        return;
                    }

                    IGeoFeatureLayer geoFeatureLayer = featureLayer as IGeoFeatureLayer;
                    if (geoFeatureLayer == null)
                    {
                        MessageBox.Show("该图层不支持渲染！");
                        return;
                    }
                    geoFeatureLayer.Renderer = (IFeatureRenderer)renderer;
                    axMapControl1.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("分级渲染失败：" + ex.Message);
                }
            }
        }

        /// <summary>
        /// 读取字段数值并按指定方法生成分级渲染器。
        /// </summary>
        /// <param name="featureLayer">待渲染的矢量图层。</param>
        /// <param name="fieldName">分级字段名。</param>
        /// <param name="methodIndex">分级方法索引：0 等间距、1 自然间断点、2 分位数。</param>
        /// <param name="classCount">分级数量。</param>
        /// <param name="rampIndex">色带类型索引。</param>
        /// <param name="excludeZero">是否排除空值与 0 值。</param>
        /// <returns>分级渲染器；失败时返回 null。</returns>
        private IClassBreaksRenderer BuildClassBreakRenderer(
            IFeatureLayer featureLayer,
            string fieldName,
            int methodIndex,
            int classCount,
            int rampIndex,
            bool excludeZero)
        {
            IFeatureClass featureClass = featureLayer.FeatureClass;
            int fieldIndex = featureClass.Fields.FindField(fieldName);
            if (fieldIndex < 0)
            {
                MessageBox.Show("未找到字段：" + fieldName);
                return null;
            }

            // 读取字段全部数值并升序排序
            List<double> values = new List<double>();
            IQueryFilter queryFilter = new QueryFilter();
            queryFilter.SubFields = fieldName;
            IFeatureCursor cursor = featureClass.Search(queryFilter, false);
            try
            {
                IFeature feature = cursor.NextFeature();
                while (feature != null)
                {
                    object value = feature.get_Value(fieldIndex);
                    if (value != null && value != DBNull.Value)
                    {
                        double number;
                        if (double.TryParse(UniqueValueRenderHelper.FormatValue(value), out number))
                        {
                            if (!excludeZero || Math.Abs(number) > 0.0000001)
                            {
                                values.Add(number);
                            }
                        }
                    }
                    feature = cursor.NextFeature();
                }
            }
            finally
            {
                UniqueValueRenderHelper.ReleaseComObject(cursor);
            }

            if (values.Count == 0)
            {
                MessageBox.Show("该字段没有可用的数值！");
                return null;
            }
            if (values.Count < classCount)
            {
                classCount = values.Count;
            }
            values.Sort();

            // 按分级方法计算分级断点
            IClassifyGEN classify;
            if (methodIndex == 1)
            {
                classify = new NaturalBreaks();
            }
            else if (methodIndex == 2)
            {
                classify = new Quantile();
            }
            else
            {
                classify = new EqualInterval();
            }
            classify.Classify(values.ToArray(), null, ref classCount);
            double[] breaks = (double[])classify.ClassBreaks;
            if (breaks == null || breaks.Length < 2)
            {
                MessageBox.Show("分级计算失败！");
                return null;
            }
            int realCount = breaks.Length - 1;

            // 用当前符号作为模板，按色带逐级生成符号
            ISymbol template = GetCurrentSymbol(featureLayer)
                ?? UniqueValueRenderHelper.CreateDefaultTemplate(GetLayerGeometryType(featureLayer));
            List<IColor> colors = UniqueValueRenderHelper.CreateColors(rampIndex, realCount);
            esriGeometryType geometryType = GetLayerGeometryType(featureLayer);

            IClassBreaksRenderer renderer = new ClassBreaksRenderer();
            renderer.Field = fieldName;
            renderer.BreakCount = realCount;
            renderer.SortClassesAscending = true;
            for (int i = 0; i < realCount; i++)
            {
                renderer.set_Break(i, breaks[i + 1]);
                renderer.set_Label(i, string.Format("{0:F2} - {1:F2}", breaks[i], breaks[i + 1]));
                renderer.set_Symbol(i, UniqueValueRenderHelper.CreateSymbol(
                    template, geometryType, colors[i % colors.Count]));
            }
            return renderer;
        }

        /// <summary>
        /// 缓冲区分析菜单：对当前选中的要素生成缓冲区并以图形显示。
        /// </summary>
        private void bufferAnalysisMenuItem_Click(object sender, EventArgs e)
        {
            if (axMapControl1.Map.LayerCount == 0)
            {
                MessageBox.Show("请先添加矢量图层！");
                return;
            }

            if (axMapControl1.Map.SelectionCount == 0)
            {
                MessageBox.Show("请先通过属性查询、点选查询或框选查询选择要素！");
                return;
            }

            using (BufferAnalysisDialog dialog = new BufferAnalysisDialog())
            {
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                double distance = dialog.BufferDistance;
                IEnumFeature enumFeature = (IEnumFeature)axMapControl1.Map.FeatureSelection;
                IGraphicsContainer container = (IGraphicsContainer)axMapControl1.Map;
                int count = 0;

                enumFeature.Reset();
                IFeature feature = enumFeature.Next();
                while (feature != null)
                {
                    IGeometry geometry = feature.Shape;
                    if (geometry != null && !geometry.IsEmpty)
                    {
                        ITopologicalOperator topoOperator = (ITopologicalOperator)geometry;
                        IGeometry bufferGeometry = topoOperator.Buffer(distance);

                        IElement element = (IElement)new PolygonElement();
                        element.Geometry = bufferGeometry;
                        ((IFillShapeElement)element).Symbol = (IFillSymbol)CreateBufferSymbol();
                        ((IElementProperties)element).Name = "缓冲区";
                        container.AddElement(element, 0);
                        count++;
                    }
                    feature = enumFeature.Next();
                }

                axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
                statusStripInfoLabel.Text = string.Format("缓冲区分析完成，共生成 {0} 个缓冲区。", count);
            }
        }

        /// <summary>
        /// 创建缓冲区显示符号：半透明红色填充加深红边线。
        /// </summary>
        private static ISymbol CreateBufferSymbol()
        {
            IRgbColor fillColor = new RgbColor();
            fillColor.Red = 255;
            fillColor.Transparency = 40;

            ISimpleLineSymbol outline = new SimpleLineSymbol();
            outline.Style = esriSimpleLineStyle.esriSLSSolid;
            outline.Width = 1.5;
            IRgbColor outlineColor = new RgbColor();
            outlineColor.Red = 180;
            outline.Color = outlineColor;

            ISimpleFillSymbol fillSymbol = new SimpleFillSymbol();
            fillSymbol.Style = esriSimpleFillStyle.esriSFSSolid;
            fillSymbol.Color = fillColor;
            fillSymbol.Outline = outline;

            return (ISymbol)fillSymbol;
        }

        /// <summary>
        /// 字段统计菜单：统计数值字段的和、均值、最值与标准差。
        /// </summary>
        private void fieldStatisticsMenuItem_Click(object sender, EventArgs e)
        {
            List<IFeatureLayer> featureLayers = GetFeatureLayers();
            if (featureLayers.Count == 0)
            {
                MessageBox.Show("请先添加矢量图层！");
                return;
            }

            using (FieldStatisticsDialog dialog = new FieldStatisticsDialog(featureLayers))
            {
                dialog.ShowDialog(this);
            }
        }

        /// <summary>
        /// 清除分析结果菜单：删除地图中缓冲区等全部图形元素。
        /// </summary>
        private void clearAnalysisMenuItem_Click(object sender, EventArgs e)
        {
            IGraphicsContainer container = (IGraphicsContainer)axMapControl1.Map;
            container.DeleteAllElements();
            _measureElement = null;
            axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
            statusStripInfoLabel.Text = "已清除分析结果。";
        }

        #endregion

        #region 扩展功能：制图整饰

        /// <summary>
        /// 添加图例菜单：在制版视图右侧添加图例。
        /// </summary>
        private void addLegendMenuItem_Click(object sender, EventArgs e)
        {
            if (!EnsurePageLayoutSynced())
            {
                return;
            }
            AddMapSurround("esriCarto.Legend", 0.76, 0.28, 0.97, 0.85);
        }

        /// <summary>
        /// 添加指北针菜单：在制版视图右上角添加指北针。
        /// </summary>
        private void addNorthArrowMenuItem_Click(object sender, EventArgs e)
        {
            if (!EnsurePageLayoutSynced())
            {
                return;
            }
            AddMapSurround("esriCarto.MarkerNorthArrow", 0.85, 0.86, 0.97, 0.98);
        }

        /// <summary>
        /// 添加比例尺菜单：在制版视图底部添加比例尺。
        /// </summary>
        private void addScaleBarMenuItem_Click(object sender, EventArgs e)
        {
            if (!EnsurePageLayoutSynced())
            {
                return;
            }
            AddMapSurround("esriCarto.AlternatingScaleBar", 0.30, 0.02, 0.70, 0.10);
        }

        /// <summary>
        /// 添加标题菜单：在制版视图顶部添加地图标题。
        /// </summary>
        private void addMapTitleMenuItem_Click(object sender, EventArgs e)
        {
            if (!EnsurePageLayoutSynced())
            {
                return;
            }
            AddMapSurround("esriCarto.MapTitle", 0.25, 0.90, 0.75, 0.97);
        }

        /// <summary>
        /// 确认制版视图可用：有图层时先同步当前地图。
        /// </summary>
        /// <returns>制版视图是否可用。</returns>
        private bool EnsurePageLayoutSynced()
        {
            if (axMapControl1.Map.LayerCount == 0)
            {
                MessageBox.Show("请先添加图层！");
                return false;
            }

            SyncPageLayout();
            return true;
        }

        /// <summary>
        /// 按页面比例位置在制版视图中添加地图整饰元素（图例、指北针等）。
        /// </summary>
        /// <param name="surroundProgId">整饰元素的 ProgID。</param>
        /// <param name="x1">相对页面左下角 X 最小比例。</param>
        /// <param name="y1">相对页面左下角 Y 最小比例。</param>
        /// <param name="x2">相对页面左下角 X 最大比例。</param>
        /// <param name="y2">相对页面左下角 Y 最大比例。</param>
        private void AddMapSurround(string surroundProgId, double x1, double y1, double x2, double y2)
        {
            IGraphicsContainer container = axPageLayoutControl1.GraphicsContainer;
            IMapFrame mapFrame = container.FindFrame(axPageLayoutControl1.ActiveView.FocusMap) as IMapFrame;
            if (mapFrame == null)
            {
                MessageBox.Show("未找到制版视图的地图框！");
                return;
            }

            UID uid = new UID();
            uid.Value = surroundProgId;
            IMapSurroundFrame surroundFrame = mapFrame.CreateSurroundFrame(uid, null);

            // 按页面范围的比例计算元素位置
            IActiveView activeView = (IActiveView)axPageLayoutControl1.ActiveView;
            IEnvelope pageExtent = activeView.Extent;
            double width = pageExtent.Width;
            double height = pageExtent.Height;
            IEnvelope envelope = (IEnvelope)new Envelope();
            envelope.PutCoords(
                pageExtent.XMin + width * x1,
                pageExtent.YMin + height * y1,
                pageExtent.XMin + width * x2,
                pageExtent.YMin + height * y2);

            IElement element = (IElement)surroundFrame;
            element.Geometry = envelope;
            container.AddElement(element, 0);
            axPageLayoutControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        #endregion

        #region 扩展功能：鹰眼图

        /// <summary>
        /// 获取鹰眼图是否已就绪（控件已创建且句柄已激活）。
        /// 鹰眼控件位于非激活页签时句柄不会创建，此时访问 ActiveX 属性会抛出
        /// AxHost.InvalidActiveXStateException，因此访问前必须判断就绪状态。
        /// </summary>
        private bool IsOverviewReady
        {
            get { return _overviewMapControl != null && _overviewMapControl.IsHandleCreated && !_overviewMapControl.IsDisposed; }
        }

        /// <summary>
        /// 初始化鹰眼图：在“鹰眼”页签中创建地图控件（句柄由页签首次显示时创建）。
        /// </summary>
        private void InitializeOverview()
        {
            if (_overviewMapControl != null)
            {
                return;
            }

            _overviewMapControl = new AxMapControl();
            _overviewMapControl.Dock = DockStyle.Fill;
            pnlOverview.Controls.Add(_overviewMapControl);
            _overviewMapControl.OnMouseDown += new IMapControlEvents2_Ax_OnMouseDownEventHandler(overviewMapControl_OnMouseDown);
            _overviewMapControl.HandleCreated += new EventHandler(overviewMapControl_HandleCreated);
        }

        /// <summary>
        /// “鹰眼”页签显示：控件句柄创建完成后同步一次主地图。
        /// </summary>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == Overview)
            {
                InitializeOverview();
                // 延迟到页签布局完成、控件句柄创建之后再同步
                BeginInvoke(new MethodInvoker(SyncOverview));
            }
        }

        /// <summary>
        /// 鹰眼图控件句柄创建完成（页签首次显示）。
        /// 用 BeginInvoke 把同步推迟到控件激活完成之后执行。
        /// </summary>
        private void overviewMapControl_HandleCreated(object sender, EventArgs e)
        {
            BeginInvoke(new MethodInvoker(SyncOverview));
        }

        /// <summary>
        /// 鹰眼图鼠标按下：主地图以点击位置为中心。
        /// </summary>
        private void overviewMapControl_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            IPoint point = new ArcPoint();
            point.PutCoords(e.mapX, e.mapY);
            axMapControl1.CenterAt(point);
            axMapControl1.ActiveView.Refresh();
        }

        /// <summary>
        /// 把主地图的图层同步到鹰眼图，并把视图缩放到全图。
        /// </summary>
        private void SyncOverview()
        {
            if (!IsOverviewReady)
            {
                return;
            }

            IObjectCopy objectCopy = (IObjectCopy)new ObjectCopy();
            object copiedMap = objectCopy.Copy(axMapControl1.Map);
            object targetMap = _overviewMapControl.Map;
            objectCopy.Overwrite(copiedMap, ref targetMap);

            _overviewMapControl.ActiveView.Extent = _overviewMapControl.FullExtent;
            _overviewMapControl.ActiveView.Refresh();
            DrawOverviewExtent();
        }

        /// <summary>
        /// 在鹰眼图上绘制表示主地图当前范围的红色矩形。
        /// </summary>
        private void DrawOverviewExtent()
        {
            if (!IsOverviewReady || axMapControl1.Map.LayerCount == 0)
            {
                return;
            }

            IGraphicsContainer container = (IGraphicsContainer)_overviewMapControl.Map;
            container.DeleteAllElements();

            IElement element = (IElement)new RectangleElement();
            element.Geometry = axMapControl1.ActiveView.Extent;

            ISimpleLineSymbol outline = new SimpleLineSymbol();
            outline.Style = esriSimpleLineStyle.esriSLSSolid;
            outline.Width = 2;
            IRgbColor red = new RgbColor();
            red.Red = 255;
            outline.Color = red;

            ISimpleFillSymbol fillSymbol = new SimpleFillSymbol();
            fillSymbol.Style = esriSimpleFillStyle.esriSFSNull;
            fillSymbol.Outline = outline;
            ((IFillShapeElement)element).Symbol = (IFillSymbol)fillSymbol;

            container.AddElement(element, 0);
            _overviewMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        /// <summary>
        /// 主地图范围变化时更新鹰眼图上的范围矩形。
        /// </summary>
        private void axMapControl1_OnExtentUpdated(object sender, IMapControlEvents2_OnExtentUpdatedEvent e)
        {
            DrawOverviewExtent();
        }

        #endregion

        #region 公共辅助方法

        /// <summary>
        /// 获取 TOC 控件中当前选中的图层；未选中时返回 null。
        /// </summary>
        private ILayer GetSelectedLayer()
        {
            esriTOCControlItem tocChoosedItem = esriTOCControlItem.esriTOCControlItemLayer;
            IBasicMap basicMap = null;
            ILayer tocChoosedLayer = null;
            object other = new object();
            object index = new object();
            axTOCControl1.GetSelectedItem(
                ref tocChoosedItem,
                ref basicMap,
                ref tocChoosedLayer,
                ref other,
                ref index
            );

            return tocChoosedLayer;
        }

        /// <summary>
        /// 获取 TOC 控件中当前选中的矢量图层；未选择或非矢量图层时提示并返回 null。
        /// </summary>
        private IFeatureLayer GetSelectedFeatureLayer()
        {
            ILayer tocChoosedLayer = GetSelectedLayer();
            if (!(tocChoosedLayer is IFeatureLayer))
            {
                MessageBox.Show("未选择图层，或者图层非矢量图层！");
                return null;
            }

            return tocChoosedLayer as IFeatureLayer;
        }

        #endregion

    }

}
