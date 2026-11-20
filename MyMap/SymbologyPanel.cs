using System;
using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;

namespace MyMap
{
    /// <summary>
    /// 符号系统停靠面板（ArcGIS Pro 的 Symbology 视图）：
    /// 选中图层后按几何类型自动加载 ESRI.ServerStyle 符号库，
    /// 双击符号直接以单一符号方式渲染图层，也可打开高级参数对话框精调。
    /// </summary>
    public partial class SymbologyPanel : DockContent
    {
        /// <summary>目标地图控件，由主窗体在创建面板时注入。</summary>
        public AxMapControl MainMap { get; set; }

        /// <summary>当前设定的目标图层。</summary>
        private IFeatureLayer _targetLayer;

        /// <summary>符号库中当前选中的样式项。</summary>
        private IStyleGalleryItem _selectedItem;

        /// <summary>符号库文件是否已加载。</summary>
        private bool _styleLoaded;

        /// <summary>
        /// 创建符号系统面板。
        /// </summary>
        public SymbologyPanel()
        {
            InitializeComponent();
        }

        #region 图层绑定与符号库加载

        /// <summary>
        /// 设定目标图层：按几何类型切换符号库类别，供后续渲染使用。
        /// </summary>
        /// <param name="featureLayer">目标矢量图层；null 表示清除目标。</param>
        public void SetLayer(IFeatureLayer featureLayer)
        {
            _targetLayer = featureLayer;

            if (featureLayer == null)
            {
                lblSymbologyLayer.Text = "图层：（未选择）";
                return;
            }

            lblSymbologyLayer.Text = "图层：" + featureLayer.Name;
            EnsureStyleLoaded();

            switch (featureLayer.FeatureClass.ShapeType)
            {
                case esriGeometryType.esriGeometryPoint:
                case esriGeometryType.esriGeometryMultipoint:
                    axSymbologyPanelControl.StyleClass = esriSymbologyStyleClass.esriStyleClassMarkerSymbols;
                    break;
                case esriGeometryType.esriGeometryPolyline:
                    axSymbologyPanelControl.StyleClass = esriSymbologyStyleClass.esriStyleClassLineSymbols;
                    break;
                case esriGeometryType.esriGeometryPolygon:
                case esriGeometryType.esriGeometryMultiPatch:
                    axSymbologyPanelControl.StyleClass = esriSymbologyStyleClass.esriStyleClassFillSymbols;
                    break;
                default:
                    lblSymbologyLayer.Text = "图层：" + featureLayer.Name + "（不支持的几何类型）";
                    break;
            }
        }

        /// <summary>
        /// 首次使用时载入 ESRI.ServerStyle 符号库。
        /// </summary>
        private void EnsureStyleLoaded()
        {
            if (_styleLoaded)
            {
                return;
            }

            try
            {
                string installPath = ESRI.ArcGIS.RuntimeManager.ActiveRuntime.Path;
                axSymbologyPanelControl.LoadStyleFile(
                    System.IO.Path.Combine(installPath, "Styles", "ESRI.ServerStyle"));
                _styleLoaded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("载入符号库失败：" + ex.Message);
            }
        }

        #endregion

        #region 符号选择与应用

        /// <summary>
        /// 获取当前选中的符号；未选中时返回 null。
        /// </summary>
        private ISymbol GetSelectedSymbol()
        {
            if (_selectedItem == null)
            {
                return null;
            }

            ISymbol symbol = _selectedItem.Item as ISymbol;
            IClone clone = symbol as IClone;
            return clone != null ? (ISymbol)clone.Clone() : symbol;
        }

        /// <summary>
        /// 应用当前符号到目标图层（单一符号渲染）。
        /// </summary>
        private void ApplySelectedSymbol()
        {
            ISymbol symbol = GetSelectedSymbol();
            if (symbol == null)
            {
                MessageBox.Show("请先在下方符号库中选择一个符号！");
                return;
            }

            if (_targetLayer == null)
            {
                MessageBox.Show("请先在图层树中选中一个矢量图层！");
                return;
            }

            IGeoFeatureLayer geoFeatureLayer = _targetLayer as IGeoFeatureLayer;
            if (geoFeatureLayer == null)
            {
                MessageBox.Show("该图层不是矢量图层，无法设置符号！");
                return;
            }

            ISimpleRenderer renderer = new SimpleRenderer();
            renderer.Symbol = symbol;
            geoFeatureLayer.Renderer = (IFeatureRenderer)renderer;
            MainMap.ActiveView.Refresh();
        }

        /// <summary>
        /// 把当前选中符号渲染到预览框。
        /// </summary>
        private void PreviewSelectedSymbol()
        {
            if (_selectedItem == null)
            {
                return;
            }

            try
            {
                dynamic picture = axSymbologyPanelControl.GetStyleClass(axSymbologyPanelControl.StyleClass)
                    .PreviewItem(_selectedItem, pictureBoxSymbolPreview.Width, pictureBoxSymbolPreview.Height);
                Image image = Image.FromHbitmap(new IntPtr(picture.Handle));

                Image oldImage = pictureBoxSymbolPreview.Image;
                pictureBoxSymbolPreview.Image = image;
                if (oldImage != null)
                {
                    oldImage.Dispose();
                }
            }
            catch
            {
                // 预览失败不影响选择
            }
        }

        #endregion

        #region 事件处理

        /// <summary>
        /// 符号库选中项变化：刷新预览。
        /// </summary>
        private void axSymbologyPanelControl_OnItemSelected(object sender, ISymbologyControlEvents_OnItemSelectedEvent e)
        {
            _selectedItem = e.styleGalleryItem as IStyleGalleryItem;
            PreviewSelectedSymbol();
        }

        /// <summary>
        /// 双击符号：直接应用到目标图层。
        /// </summary>
        private void axSymbologyPanelControl_OnDoubleClick(object sender, ISymbologyControlEvents_OnDoubleClickEvent e)
        {
            ApplySelectedSymbol();
        }

        /// <summary>
        /// 应用按钮：把当前符号以单一符号方式渲染目标图层。
        /// </summary>
        private void btnApplySymbol_Click(object sender, EventArgs e)
        {
            ApplySelectedSymbol();
        }

        /// <summary>
        /// 高级参数按钮：打开符号选择器对话框精调颜色/大小等参数。
        /// </summary>
        private void btnAdvancedSymbol_Click(object sender, EventArgs e)
        {
            if (_targetLayer == null)
            {
                MessageBox.Show("请先在图层树中选中一个矢量图层！");
                return;
            }

            ISymbol currentSymbol = GetSelectedSymbol();
            if (currentSymbol == null && _targetLayer is IGeoFeatureLayer)
            {
                IFeatureRenderer renderer = ((IGeoFeatureLayer)_targetLayer).Renderer;
                ISimpleRenderer simpleRenderer = renderer as ISimpleRenderer;
                if (simpleRenderer != null)
                {
                    currentSymbol = simpleRenderer.Symbol;
                }
            }

            using (SymbolSelectDialog dialog = new SymbolSelectDialog(
                CreateLegendClass(currentSymbol), _targetLayer))
            {
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    // 高级对话框确认后，把精调好的符号直接渲染到图层
                    IGeoFeatureLayer geoFeatureLayer = _targetLayer as IGeoFeatureLayer;
                    if (geoFeatureLayer != null)
                    {
                        ISimpleRenderer renderer = new SimpleRenderer();
                        renderer.Symbol = dialog.CurrentSymbol;
                        geoFeatureLayer.Renderer = (IFeatureRenderer)renderer;
                        MainMap.ActiveView.Refresh();
                    }
                }
            }
        }

        /// <summary>
        /// 把符号包装为图例类，供符号选择器对话框使用。
        /// </summary>
        /// <param name="symbol">当前符号。</param>
        private static ILegendClass CreateLegendClass(ISymbol symbol)
        {
            ILegendClass legendClass = new LegendClass();
            legendClass.Symbol = symbol;
            return legendClass;
        }

        #endregion
    }
}
