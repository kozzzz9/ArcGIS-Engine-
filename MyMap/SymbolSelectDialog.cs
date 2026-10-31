using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geometry;

namespace MyMap
{
    /// <summary>
    /// 自定义符号选择器
    /// 双击图层树中的符号图例时弹出，根据图层几何类型自动加载
    /// ESRI.ServerStyle 中的点/线/面符号库，选中符号后可调整
    /// 颜色、大小、线宽、角度、外框颜色等参数；“更多符号”菜单
    /// 可勾选加载 ArcGIS 自带的其它符号库，或添加自定义
    /// .ServerStyle 符号库文件扩展符号来源。
    /// </summary>
    public partial class SymbolSelectDialog : Form
    {
        #region 私有字段

        /// <summary>双击选中的图例类，确定后把新符号写回它。</summary>
        private readonly ILegendClass m_legendClass;

        /// <summary>双击选中的图层，用于判断几何类型。</summary>
        private readonly ILayer m_layer;

        /// <summary>符号库中当前选中的样式项。</summary>
        private IStyleGalleryItem m_styleGalleryItem;

        /// <summary>当前符号（样式项符号的副本，参数修改都作用于它）。</summary>
        private ISymbol m_symbol;

        /// <summary>是否正在把符号参数回填到界面控件（防止回填触发修改事件）。</summary>
        private bool _updatingControls;

        /// <summary>“更多符号”菜单是否已初始化（实习十四 1.2）。</summary>
        private bool m_bContextMenuMoreSymbolInitiated = false;

        /// <summary>已加载到 SymbologyControl 的符号库文件路径（忽略大小写），用于同步菜单勾选状态。</summary>
        private readonly HashSet<string> m_loadedStyleFiles = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        /// <summary>ArcGIS 自带符号库文件列表（构建菜单时缓存），用于区分内置库与自定义库。</summary>
        private HashSet<string> m_builtinStyleFiles;

        #endregion

        #region 构造函数

        /// <summary>
        /// 创建符号选择器窗体。
        /// </summary>
        /// <param name="tempLegendClass">双击选中的图例类。</param>
        /// <param name="tempLayer">双击选中的图层。</param>
        public SymbolSelectDialog(ILegendClass tempLegendClass, ILayer tempLayer)
        {
            m_legendClass = tempLegendClass;
            m_layer = tempLayer;
            ApplyToWholeLayer = false;
            InitializeComponent();
        }

        #endregion

        #region 公共属性

        /// <summary>用户确认后的符号。</summary>
        public ISymbol CurrentSymbol
        {
            get { return m_symbol; }
        }

        /// <summary>
        /// 用户是否点击了“应用到整个图层”：为 true 时主窗体把该符号
        /// 应用为整个图层的简单渲染，而不是只替换双击的图例类。
        /// </summary>
        public bool ApplyToWholeLayer { get; private set; }

        #endregion

        #region 初始化

        /// <summary>
        /// 设置 SymbologyControl 的样式类别，并把图层当前符号作为第一项“当前符号”插入。
        /// </summary>
        /// <param name="tempSymbologyStyleClass">样式类别。</param>
        private void SetFeatureClassStyle(esriSymbologyStyleClass tempSymbologyStyleClass)
        {
            axSymbologyControl.StyleClass = tempSymbologyStyleClass;
            ISymbologyStyleClass symbologyStyleClass = axSymbologyControl.GetStyleClass(tempSymbologyStyleClass);

            if (m_legendClass != null && m_legendClass.Symbol != null)
            {
                IStyleGalleryItem currentStyleGalleryItem = new ServerStyleGalleryItem();
                currentStyleGalleryItem.Name = "当前符号";
                currentStyleGalleryItem.Item = m_legendClass.Symbol;
                symbologyStyleClass.AddItem(currentStyleGalleryItem, 0);
                m_styleGalleryItem = currentStyleGalleryItem;
            }

            symbologyStyleClass.SelectItem(0);
        }

        /// <summary>
        /// 窗体加载：按图层几何类型载入 ESRI.ServerStyle 对应的符号库并设置参数控件可用性。
        /// </summary>
        private void SymbolSelectDialog_Load(object sender, EventArgs e)
        {
            IFeatureLayer featureLayer = m_layer as IFeatureLayer;
            if (featureLayer == null || featureLayer.FeatureClass == null)
            {
                Close();
                return;
            }

            try
            {
                // 取得 ArcGIS 安装路径并载入 ESRI.ServerStyle 符号库
                string sInstall = ESRI.ArcGIS.RuntimeManager.ActiveRuntime.Path;
                string esriStyleFile = System.IO.Path.Combine(sInstall, "Styles", "ESRI.ServerStyle");
                axSymbologyControl.LoadStyleFile(esriStyleFile);
                m_loadedStyleFiles.Add(esriStyleFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show("载入符号库失败：" + ex.Message);
            }

            switch (featureLayer.FeatureClass.ShapeType)
            {
                case esriGeometryType.esriGeometryPoint:
                case esriGeometryType.esriGeometryMultipoint:
                    SetFeatureClassStyle(esriSymbologyStyleClass.esriStyleClassMarkerSymbols);
                    UpdateControlAvailability(true, false, false);
                    break;
                case esriGeometryType.esriGeometryPolyline:
                    SetFeatureClassStyle(esriSymbologyStyleClass.esriStyleClassLineSymbols);
                    UpdateControlAvailability(false, true, false);
                    break;
                case esriGeometryType.esriGeometryPolygon:
                case esriGeometryType.esriGeometryMultiPatch:
                    SetFeatureClassStyle(esriSymbologyStyleClass.esriStyleClassFillSymbols);
                    UpdateControlAvailability(false, true, true);
                    break;
                default:
                    Close();
                    break;
            }

            // 用图层当前符号初始化参数控件
            if (m_legendClass != null)
            {
                SyncParameterControls(m_legendClass.Symbol);
            }
        }

        /// <summary>
        /// 设置大小/线宽/角度/外框颜色参数控件的可用性。
        /// </summary>
        /// <param name="markerParameters">点符号参数（大小、角度）是否可用。</param>
        /// <param name="widthParameter">线宽参数是否可用。</param>
        /// <param name="frameColorParameter">外框颜色参数是否可用。</param>
        private void UpdateControlAvailability(bool markerParameters, bool widthParameter, bool frameColorParameter)
        {
            numericUpDownSize.Enabled = markerParameters;
            labelSize.Enabled = markerParameters;
            numericUpDownAngle.Enabled = markerParameters;
            labelAngle.Enabled = markerParameters;
            numericUpDownWidth.Enabled = widthParameter;
            labelWidth.Enabled = widthParameter;
            buttonFrameColor.Enabled = frameColorParameter;
            labelFrameColor.Enabled = frameColorParameter;
        }

        #endregion

        #region 符号参数同步与修改

        /// <summary>
        /// 把符号当前参数回填到界面控件（数值框、颜色按钮背景色）。
        /// 使用基接口 IMarkerSymbol/ILineSymbol/IFillSymbol，
        /// 对字符标记、制图线、多层符号等库内符号同样有效。
        /// </summary>
        /// <param name="symbol">要读取参数的符号。</param>
        private void SyncParameterControls(ISymbol symbol)
        {
            if (symbol == null)
            {
                return;
            }

            _updatingControls = true;
            try
            {
                IMarkerSymbol markerSymbol = symbol as IMarkerSymbol;
                if (markerSymbol != null)
                {
                    numericUpDownSize.Value = Clamp((decimal)markerSymbol.Size, numericUpDownSize.Minimum, numericUpDownSize.Maximum);
                    numericUpDownAngle.Value = Clamp((decimal)markerSymbol.Angle, numericUpDownAngle.Minimum, numericUpDownAngle.Maximum);
                }

                ILineSymbol lineSymbol = symbol as ILineSymbol;
                if (lineSymbol != null)
                {
                    numericUpDownWidth.Value = Clamp((decimal)lineSymbol.Width, numericUpDownWidth.Minimum, numericUpDownWidth.Maximum);
                }

                IFillSymbol fillSymbol = symbol as IFillSymbol;
                if (fillSymbol != null && fillSymbol.Outline != null)
                {
                    numericUpDownWidth.Value = Clamp((decimal)fillSymbol.Outline.Width, numericUpDownWidth.Minimum, numericUpDownWidth.Maximum);
                }

                // 颜色按钮背景显示符号当前颜色，透明度回填到数值框
                IColor symbolColor = GetSymbolColor(symbol);
                if (symbolColor != null)
                {
                    buttonColor.BackColor = ToWinColor(symbolColor);
                    numericUpDownTransparency.Value = Clamp(symbolColor.Transparency,
                        numericUpDownTransparency.Minimum, numericUpDownTransparency.Maximum);
                }

                IFillSymbol fillForOutline = symbol as IFillSymbol;
                if (fillForOutline != null && fillForOutline.Outline != null)
                {
                    buttonFrameColor.BackColor = ToWinColor(fillForOutline.Outline.Color);
                }
            }
            finally
            {
                _updatingControls = false;
            }
        }

        /// <summary>
        /// 读取符号颜色：点/线/面分别取各自基接口的颜色。
        /// </summary>
        private static IColor GetSymbolColor(ISymbol symbol)
        {
            IMarkerSymbol markerSymbol = symbol as IMarkerSymbol;
            if (markerSymbol != null)
            {
                return markerSymbol.Color;
            }

            ILineSymbol lineSymbol = symbol as ILineSymbol;
            if (lineSymbol != null)
            {
                return lineSymbol.Color;
            }

            IFillSymbol fillSymbol = symbol as IFillSymbol;
            if (fillSymbol != null)
            {
                return fillSymbol.Color;
            }

            return null;
        }

        /// <summary>
        /// 设置符号颜色（点/线/面分别通过各自基接口设置）。
        /// </summary>
        private static void SetSymbolColor(ISymbol symbol, IColor color)
        {
            IMarkerSymbol markerSymbol = symbol as IMarkerSymbol;
            if (markerSymbol != null)
            {
                markerSymbol.Color = color;
            }

            ILineSymbol lineSymbol = symbol as ILineSymbol;
            if (lineSymbol != null)
            {
                lineSymbol.Color = color;
            }

            IFillSymbol fillSymbol = symbol as IFillSymbol;
            if (fillSymbol != null)
            {
                fillSymbol.Color = color;
            }
        }

        /// <summary>
        /// 参数控件值变化：用基接口把新参数写回符号并刷新预览。
        /// </summary>
        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (_updatingControls || m_symbol == null)
            {
                return;
            }

            IMarkerSymbol markerSymbol = m_symbol as IMarkerSymbol;
            if (markerSymbol != null)
            {
                markerSymbol.Size = (double)numericUpDownSize.Value;
                markerSymbol.Angle = (double)numericUpDownAngle.Value;
            }

            ILineSymbol lineSymbol = m_symbol as ILineSymbol;
            if (lineSymbol != null)
            {
                lineSymbol.Width = (double)numericUpDownWidth.Value;
            }

            // 面符号通过外框线接口设置轮廓宽度
            IFillSymbol fillSymbol = m_symbol as IFillSymbol;
            if (fillSymbol != null && fillSymbol.Outline != null)
            {
                fillSymbol.Outline.Width = (double)numericUpDownWidth.Value;
            }

            if (m_styleGalleryItem != null)
            {
                m_styleGalleryItem.Item = m_symbol;
            }
            PreviewImage();
        }

        /// <summary>
        /// 透明度变化：修改符号颜色的透明度分量并刷新预览。
        /// </summary>
        private void numericUpDownTransparency_ValueChanged(object sender, EventArgs e)
        {
            if (_updatingControls || m_symbol == null)
            {
                return;
            }

            IColor symbolColor = GetSymbolColor(m_symbol);
            if (symbolColor != null)
            {
                symbolColor.Transparency = (byte)numericUpDownTransparency.Value;
                if (m_styleGalleryItem != null)
                {
                    m_styleGalleryItem.Item = m_symbol;
                }
                PreviewImage();
            }
        }

        /// <summary>
        /// 应用到整个图层：关闭窗体并通知主窗体把符号应用为图层简单渲染。
        /// </summary>
        private void buttonApplyLayer_Click(object sender, EventArgs e)
        {
            if (m_styleGalleryItem != null)
            {
                ISymbol selectedSymbol = m_styleGalleryItem.Item as ISymbol;
                if (selectedSymbol != null)
                {
                    m_symbol = selectedSymbol;
                }
            }

            if (m_symbol == null)
            {
                MessageBox.Show("请先选择一个符号！");
                return;
            }

            ApplyToWholeLayer = true;
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// 打开 ArcMap 符号选择器（手册第一部分方式，需安装 ArcGIS Desktop）。
        /// </summary>
        private void buttonArcMapSelector_Click(object sender, EventArgs e)
        {
            if (m_symbol == null)
            {
                MessageBox.Show("请先选择一个符号！");
                return;
            }

            try
            {
                // 直接调用 ArcMap 自带的符号选择器
                ESRI.ArcGIS.DisplayUI.ISymbolSelector symbolSelector =
                    (ESRI.ArcGIS.DisplayUI.ISymbolSelector)new ESRI.ArcGIS.DisplayUI.SymbolSelector();
                symbolSelector.AddSymbol(m_symbol);
                if (symbolSelector.SelectSymbol(0))
                {
                    m_symbol = symbolSelector.GetSymbolAt(0);
                    if (m_styleGalleryItem != null)
                    {
                        m_styleGalleryItem.Item = m_symbol;
                    }
                    PreviewImage();
                    SyncParameterControls(m_symbol);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("无法打开 ArcMap 符号选择器（需要安装 ArcGIS Desktop）：" + ex.Message);
            }
        }

        /// <summary>
        /// 导出预览图：把当前预览图像保存为 PNG/JPG 图片。
        /// </summary>
        private void buttonExportPreview_Click(object sender, EventArgs e)
        {
            if (pictureBoxPreview.Image == null)
            {
                MessageBox.Show("当前没有可导出的预览图！");
                return;
            }

            if (saveFileDialogPreview.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            try
            {
                System.Drawing.Imaging.ImageFormat imageFormat = System.Drawing.Imaging.ImageFormat.Png;
                if (saveFileDialogPreview.FileName.ToLower().EndsWith(".jpg"))
                {
                    imageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
                }
                pictureBoxPreview.Image.Save(saveFileDialogPreview.FileName, imageFormat);
                MessageBox.Show("预览图导出成功：" + saveFileDialogPreview.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("预览图导出失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 颜色按钮：弹出取色器并把新颜色应用到符号。
        /// </summary>
        private void buttonColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog(this) != DialogResult.OK || m_symbol == null)
            {
                return;
            }

            SetSymbolColor(m_symbol, ToArcGisColor(colorDialog1.Color));
            buttonColor.BackColor = colorDialog1.Color;

            if (m_styleGalleryItem != null)
            {
                m_styleGalleryItem.Item = m_symbol;
            }
            PreviewImage();
        }

        /// <summary>
        /// 外框颜色按钮：弹出取色器并修改面符号轮廓颜色。
        /// </summary>
        private void buttonFrameColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog(this) != DialogResult.OK || m_symbol == null)
            {
                return;
            }

            IFillSymbol fillSymbol = m_symbol as IFillSymbol;
            if (fillSymbol != null && fillSymbol.Outline != null)
            {
                fillSymbol.Outline.Color = ToArcGisColor(colorDialog1.Color);
                buttonFrameColor.BackColor = colorDialog1.Color;

                if (m_styleGalleryItem != null)
                {
                    m_styleGalleryItem.Item = m_symbol;
                }
                PreviewImage();
            }
        }

        #endregion

        #region 预览与辅助方法

        /// <summary>
        /// 把当前选中的符号渲染到预览框。
        /// </summary>
        private void PreviewImage()
        {
            if (m_styleGalleryItem == null)
            {
                return;
            }

            try
            {
                // 用 dynamic 访问 IPictureDisp 的 Handle 属性，避免直接依赖 stdole 类型
                dynamic picture = axSymbologyControl.GetStyleClass(axSymbologyControl.StyleClass)
                    .PreviewItem(m_styleGalleryItem, pictureBoxPreview.Width, pictureBoxPreview.Height);
                Image image = Image.FromHbitmap(new IntPtr(picture.Handle));

                Image oldImage = pictureBoxPreview.Image;
                pictureBoxPreview.Image = image;
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

        /// <summary>
        /// 把 System.Drawing.Color 转换为 ArcGIS 的 IColor。
        /// </summary>
        private static IColor ToArcGisColor(Color color)
        {
            IRgbColor rgbColor = new RgbColor();
            rgbColor.Red = color.R;
            rgbColor.Green = color.G;
            rgbColor.Blue = color.B;
            return rgbColor;
        }

        /// <summary>
        /// 把 ArcGIS 的 IColor 转换为 System.Drawing.Color。
        /// </summary>
        private static Color ToWinColor(IColor color)
        {
            if (color == null)
            {
                return Color.Black;
            }

            try
            {
                if (color.NullColor)
                {
                    return Color.Transparent;
                }

                IRgbColor rgbColor = color as IRgbColor;
                if (rgbColor != null)
                {
                    return Color.FromArgb(rgbColor.Red, rgbColor.Green, rgbColor.Blue);
                }

                color.UseWindowsDithering = true;
                return ColorTranslator.FromOle(color.RGB);
            }
            catch
            {
                return Color.Black;
            }
        }

        /// <summary>
        /// 把数值限制在指定范围内。
        /// </summary>
        private static decimal Clamp(decimal value, decimal min, decimal max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        #endregion

        #region 更多符号菜单

        /// <summary>
        /// “更多符号”按钮：首次单击时按 ArcGIS 安装目录下的 *.ServerStyle
        /// 文件生成可勾选菜单，之后在按钮正下方显示菜单。
        /// </summary>
        private void buttonMore_Click(object sender, EventArgs e)
        {
            if (!m_bContextMenuMoreSymbolInitiated)
            {
                InitMoreSymbolMenu();
                m_bContextMenuMoreSymbolInitiated = true;
            }

            // 手册示例的 Show(buttonMore.Location) 把窗体坐标当作屏幕坐标，
            // 菜单会弹到屏幕左上角；这里改为在按钮正下方弹出
            contextMenuStripMoreSymbol.Show(buttonMore, new System.Drawing.Point(0, buttonMore.Height));
        }

        /// <summary>
        /// 构建“更多符号”菜单：内置符号库 + 重置项 + “添加符号”。
        /// </summary>
        private void InitMoreSymbolMenu()
        {
            // 取得 ArcGIS 安装路径 Styles 目录下的符号库文件
            string sInstall = ESRI.ArcGIS.RuntimeManager.ActiveRuntime.Path;
            string sPath = System.IO.Path.Combine(sInstall, "Styles");
            string[] styleNames = System.IO.Directory.GetFiles(sPath, "*.ServerStyle");
            m_builtinStyleFiles = new HashSet<string>(styleNames, StringComparer.OrdinalIgnoreCase);

            List<ToolStripItem> menuItems = new List<ToolStripItem>();
            for (int i = 0; i < styleNames.Length; i++)
            {
                menuItems.Add(CreateStyleMenuItem(styleNames[i]));
            }

            menuItems.Add(new ToolStripSeparator());

            // 扩展：一键移除除 ESRI 外的所有符号库，恢复默认
            ToolStripMenuItem resetItem = new ToolStripMenuItem("重置为默认符号库");
            resetItem.Name = "ResetDefaultStyles";
            resetItem.ToolTipText = "移除除 ESRI 之外所有已加载的符号库";
            menuItems.Add(resetItem);

            // “添加符号”：选择其它 ServerStyle 文件加载
            ToolStripMenuItem addMoreItem = new ToolStripMenuItem("添加符号...");
            addMoreItem.Name = "AddMoreSymbol";
            menuItems.Add(addMoreItem);

            contextMenuStripMoreSymbol.Items.AddRange(menuItems.ToArray());
        }

        /// <summary>
        /// 为一个符号库文件生成菜单项，勾选标记与实际加载状态一致。
        /// 不使用 CheckOnClick 自动翻转，勾选状态统一由代码按实际
        /// 加载状态设置，避免与真实状态脱节。
        /// </summary>
        private ToolStripMenuItem CreateStyleMenuItem(string styleFile)
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem();
            menuItem.Text = System.IO.Path.GetFileNameWithoutExtension(styleFile);
            menuItem.Name = styleFile;
            menuItem.ToolTipText = styleFile;
            menuItem.Checked = m_loadedStyleFiles.Contains(styleFile);
            return menuItem;
        }

        /// <summary>
        /// 菜单项单击：切换符号库的加载/移除，或执行“添加符号”/“重置”。
        /// </summary>
        private void contextMenuStripMoreSymbol_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripMenuItem menuItem = e.ClickedItem as ToolStripMenuItem;
            if (menuItem == null)
            {
                return;
            }

            if (menuItem.Name == "AddMoreSymbol")
            {
                AddCustomStyleFile();
            }
            else if (menuItem.Name == "ResetDefaultStyles")
            {
                ResetDefaultStyles();
            }
            else
            {
                ToggleStyleFile(menuItem);
            }
        }

        /// <summary>
        /// 加载/移除一个符号库文件，并保持菜单勾选标记与实际状态一致。
        /// </summary>
        private void ToggleStyleFile(ToolStripMenuItem menuItem)
        {
            string styleFile = menuItem.Name;
            bool wasLoaded = m_loadedStyleFiles.Contains(styleFile);

            try
            {
                if (wasLoaded)
                {
                    axSymbologyControl.RemoveFile(styleFile);
                    m_loadedStyleFiles.Remove(styleFile);
                }
                else
                {
                    axSymbologyControl.LoadStyleFile(styleFile);
                    m_loadedStyleFiles.Add(styleFile);
                }
                menuItem.Checked = !wasLoaded;
                RefreshSymbolGrid();
            }
            catch (Exception ex)
            {
                // 失败时按实际状态回写勾选标记
                menuItem.Checked = m_loadedStyleFiles.Contains(styleFile);
                MessageBox.Show("切换符号库 \"" + System.IO.Path.GetFileName(styleFile) + "\" 失败：" + ex.Message);
            }
        }

        /// <summary>
        /// “添加符号”：选择自定义 ServerStyle 文件载入，并把该文件加入
        /// 菜单，使其同样可以随时勾选/取消（手册示例载入后无法再移除）。
        /// </summary>
        private void AddCustomStyleFile()
        {
            if (openFileDialog1.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            string styleFile = openFileDialog1.FileName;
            if (m_loadedStyleFiles.Contains(styleFile))
            {
                MessageBox.Show("该符号库文件已加载。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                axSymbologyControl.LoadStyleFile(styleFile);
                m_loadedStyleFiles.Add(styleFile);
                RefreshSymbolGrid();

                // 自定义符号库菜单项插到内置项之后、分隔线之前
                if (m_bContextMenuMoreSymbolInitiated &&
                    (m_builtinStyleFiles == null || !m_builtinStyleFiles.Contains(styleFile)))
                {
                    int resetIndex = contextMenuStripMoreSymbol.Items.IndexOfKey("ResetDefaultStyles");
                    contextMenuStripMoreSymbol.Items.Insert(Math.Max(0, resetIndex - 1), CreateStyleMenuItem(styleFile));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("载入符号库失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 重置为默认符号库：移除除 ESRI 外的所有符号库，并清理菜单中的自定义项。
        /// </summary>
        private void ResetDefaultStyles()
        {
            try
            {
                // 复制一份再遍历，遍历过程中要修改集合本身
                List<string> loadedFiles = new List<string>(m_loadedStyleFiles);
                foreach (string styleFile in loadedFiles)
                {
                    if (string.Equals(System.IO.Path.GetFileNameWithoutExtension(styleFile), "ESRI", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    axSymbologyControl.RemoveFile(styleFile);
                    m_loadedStyleFiles.Remove(styleFile);
                }

                // 从后往前同步菜单：删除自定义项，内置项按实际状态回写勾选标记
                for (int i = contextMenuStripMoreSymbol.Items.Count - 1; i >= 0; i--)
                {
                    ToolStripMenuItem menuItem = contextMenuStripMoreSymbol.Items[i] as ToolStripMenuItem;
                    if (menuItem == null || menuItem.Name == "AddMoreSymbol" || menuItem.Name == "ResetDefaultStyles")
                    {
                        continue;
                    }

                    if (m_builtinStyleFiles == null || !m_builtinStyleFiles.Contains(menuItem.Name))
                    {
                        contextMenuStripMoreSymbol.Items.RemoveAt(i);
                    }
                    else
                    {
                        menuItem.Checked = m_loadedStyleFiles.Contains(menuItem.Name);
                    }
                }

                RefreshSymbolGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("重置符号库失败：" + ex.Message);
            }
        }

        /// <summary>刷新当前样式类别的符号网格。</summary>
        private void RefreshSymbolGrid()
        {
            try
            {
                axSymbologyControl.GetStyleClass(axSymbologyControl.StyleClass).Update();
            }
            catch
            {
                // 刷新失败不影响功能
            }
        }

        #endregion

        #region 事件处理

        /// <summary>
        /// 符号库选中项变化：克隆符号为工作副本并刷新预览与参数控件。
        /// </summary>
        private void axSymbologyControl_OnItemSelected(object sender, ISymbologyControlEvents_OnItemSelectedEvent e)
        {
            m_styleGalleryItem = e.styleGalleryItem as IStyleGalleryItem;
            if (m_styleGalleryItem == null)
            {
                return;
            }

            // 克隆符号作为工作副本，参数修改不影响符号库原符号
            ISymbol originalSymbol = m_styleGalleryItem.Item as ISymbol;
            if (originalSymbol is IClone)
            {
                m_symbol = ((IClone)originalSymbol).Clone() as ISymbol;
                m_styleGalleryItem.Item = m_symbol;
            }
            else
            {
                m_symbol = originalSymbol;
            }

            PreviewImage();
            SyncParameterControls(m_symbol);
        }

        /// <summary>
        /// 双击符号等同于按下确定按钮。
        /// </summary>
        private void axSymbologyControl_OnDoubleClick(object sender, ISymbologyControlEvents_OnDoubleClickEvent e)
        {
            buttonOk.PerformClick();
        }

        /// <summary>
        /// 样式类别切换：更新参数控件可用性。
        /// </summary>
        private void axSymbologyControl_OnStyleClassChanged(object sender, ISymbologyControlEvents_OnStyleClassChangedEvent e)
        {
            switch (((ISymbologyStyleClass)e.symbologyStyleClass).StyleClass)
            {
                case esriSymbologyStyleClass.esriStyleClassMarkerSymbols:
                    UpdateControlAvailability(true, false, false);
                    break;
                case esriSymbologyStyleClass.esriStyleClassLineSymbols:
                    UpdateControlAvailability(false, true, false);
                    break;
                case esriSymbologyStyleClass.esriStyleClassFillSymbols:
                    UpdateControlAvailability(false, true, true);
                    break;
            }
        }

        /// <summary>
        /// 确定：从选中样式项取最终符号并关闭窗体。
        /// </summary>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            // 从当前选中样式项兜底取符号，避免事件未触发时符号为空
            if (m_styleGalleryItem != null)
            {
                ISymbol selectedSymbol = m_styleGalleryItem.Item as ISymbol;
                if (selectedSymbol != null)
                {
                    m_symbol = selectedSymbol;
                }
            }

            if (m_symbol == null)
            {
                MessageBox.Show("请先选择一个符号！");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// 取消：直接关闭窗体。
        /// </summary>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion
    }
}
