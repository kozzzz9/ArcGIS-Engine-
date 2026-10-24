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

            using (FeatureAttributeTable form = new FeatureAttributeTable(featureLayer))
            {
                form.ShowDialog(this);
            }
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
            IActiveView activeView = (IActiveView)axMapControl1.ActiveView;
            IRubberBand rubberBand = new RubberLine();
            IGeometry geometry = rubberBand.TrackNew(activeView.ScreenDisplay, null);
            if (geometry == null)
            {
                return;
            }

            ICurve curve = (ICurve)geometry;
            MessageBox.Show(
                string.Format("测量的线段长度：{0:F2} {1}", curve.Length, GetMapUnitName()),
                "测距",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        /// <summary>
        /// 测面积菜单：在地图上跟踪一个多边形并显示其面积。
        /// </summary>
        private void measureAreaMenuItem_Click(object sender, EventArgs e)
        {
            IActiveView activeView = (IActiveView)axMapControl1.ActiveView;
            IRubberBand rubberBand = new RubberPolygon();
            IGeometry geometry = rubberBand.TrackNew(activeView.ScreenDisplay, null);
            if (geometry == null)
            {
                return;
            }

            IArea area = (IArea)geometry;
            MessageBox.Show(
                string.Format("测量的多边形面积：{0:F2} 平方{1}", area.Area, GetMapUnitName()),
                "测面积",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
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
        /// 打开地图文档（.mxd 等）并加载到地图控件。
        /// </summary>
        private void openMapDocumentMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "打开地图文档";
                dialog.Filter = "地图文档(*.mxd;*.mxt;*.pmf)|*.mxd;*.mxt;*.pmf";
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    axMapControl1.LoadMxFile(dialog.FileName, null, null);
                    axMapControl1.ActiveView.Refresh();
                    UpdateStatusBar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("打开地图文档失败：" + ex.Message);
                }
            }
        }

        /// <summary>
        /// 将当前地图另存为地图文档（.mxd）。
        /// </summary>
        private void saveMapDocumentMenuItem_Click(object sender, EventArgs e)
        {
            if (axMapControl1.Map.LayerCount == 0)
            {
                MessageBox.Show("当前地图没有可保存的图层！");
                return;
            }

            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Title = "另存地图文档";
                dialog.Filter = "地图文档(*.mxd)|*.mxd";
                dialog.OverwritePrompt = true;
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                IMapDocument mapDocument = new MapDocument();
                try
                {
                    mapDocument.New(dialog.FileName);
                    mapDocument.ReplaceContents(axMapControl1.Map as IMxdContents);
                    mapDocument.Save(true, false);
                    mapDocument.Close();
                    MessageBox.Show("地图文档保存成功！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存地图文档失败：" + ex.Message);
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
                dialog.Filter = "PNG 图片(*.png)|*.png|JPEG 图片(*.jpg)|*.jpg";
                dialog.OverwritePrompt = true;
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                ExportActiveView(dialog.FileName);
            }
        }

        /// <summary>
        /// 按文件扩展名将当前地图视图导出为 PNG 或 JPG 图片。
        /// </summary>
        /// <param name="fileName">目标图片文件路径。</param>
        private void ExportActiveView(string fileName)
        {
            string extension = Path.GetExtension(fileName).ToLower();
            IExport export;
            if (extension == ".jpg" || extension == ".jpeg")
            {
                export = (IExport)new ExportJPEG();
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
        }

        #endregion

        #region 扩展功能：图层树右键菜单

        /// <summary>
        /// 构建图层树右键菜单：缩放至图层、打开属性表、移除图层。
        /// </summary>
        private void BuildTocContextMenu()
        {
            _tocContextMenu = new ContextMenuStrip();

            ToolStripMenuItem zoomToLayerItem = new ToolStripMenuItem("缩放至图层");
            zoomToLayerItem.Click += new EventHandler(tocZoomToLayerMenuItem_Click);
            ToolStripMenuItem viewAttributeItem = new ToolStripMenuItem("打开属性表");
            viewAttributeItem.Click += new EventHandler(tocViewAttributeMenuItem_Click);
            ToolStripMenuItem removeLayerItem = new ToolStripMenuItem("移除图层");
            removeLayerItem.Click += new EventHandler(tocRemoveLayerMenuItem_Click);

            _tocContextMenu.Items.Add(zoomToLayerItem);
            _tocContextMenu.Items.Add(viewAttributeItem);
            _tocContextMenu.Items.Add(removeLayerItem);
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

            using (FeatureAttributeTable form = new FeatureAttributeTable(featureLayer))
            {
                form.ShowDialog(this);
            }
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
