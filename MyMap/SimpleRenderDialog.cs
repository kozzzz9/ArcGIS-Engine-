using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ESRI.ArcGIS.Display;
using esriGeometryType = ESRI.ArcGIS.Geometry.esriGeometryType;

namespace MyMap
{
    /// <summary>
    /// 简单渲染（单一符号）参数设置对话框。
    /// 支持对点、线、面三种图层的符号参数进行调整：
    /// 点：点样式、点大小、点颜色（可选点轮廓颜色与粗细）；
    /// 线：线型、线粗细、线颜色；
    /// 面：填充样式、面填充色、面边线颜色、面边线粗细。
    /// </summary>
    public partial class SimpleRenderDialog : Form
    {
        #region 私有字段

        /// <summary>图层几何类型，决定对话框显示哪些选项卡。</summary>
        private readonly esriGeometryType _geometryType;

        #endregion

        #region 构造函数

        /// <summary>
        /// 创建简单渲染设置对话框。
        /// </summary>
        /// <param name="geometryType">图层几何类型（点/线/面）。</param>
        /// <param name="currentSymbol">图层当前的符号，用于初始化各选项的默认值；可为 null。</param>
        public SimpleRenderDialog(esriGeometryType geometryType, ISymbol currentSymbol)
        {
            _geometryType = geometryType;

            InitializeComponent();
            LoadFromSymbol(currentSymbol);
            UpdateVisibleTabs();
            UpdatePreview();
        }

        #endregion

        #region 公共属性

        /// <summary>
        /// 用户确认后生成的符号；取消则为 null。
        /// </summary>
        public ISymbol ResultSymbol { get; private set; }

        #endregion

        #region 图层类型与默认值

        /// <summary>
        /// 判断当前图层是否为点类型。
        /// </summary>
        private bool IsPointLayer
        {
            get { return _geometryType == esriGeometryType.esriGeometryPoint || _geometryType == esriGeometryType.esriGeometryMultipoint; }
        }

        /// <summary>
        /// 判断当前图层是否为线类型。
        /// </summary>
        private bool IsLineLayer
        {
            get { return _geometryType == esriGeometryType.esriGeometryPolyline || _geometryType == esriGeometryType.esriGeometryPath; }
        }

        /// <summary>
        /// 判断当前图层是否为面类型。
        /// </summary>
        private bool IsPolygonLayer
        {
            get { return _geometryType == esriGeometryType.esriGeometryPolygon; }
        }

        /// <summary>
        /// 根据图层类型显示对应的选项卡。
        /// </summary>
        private void UpdateVisibleTabs()
        {
            tabPoint.Visible = IsPointLayer;
            tabLine.Visible = IsLineLayer;
            tabPolygon.Visible = IsPolygonLayer;

            if (IsPointLayer)
            {
                tabSymbols.SelectedTab = tabPoint;
            }
            else if (IsLineLayer)
            {
                tabSymbols.SelectedTab = tabLine;
            }
            else if (IsPolygonLayer)
            {
                tabSymbols.SelectedTab = tabPolygon;
            }
        }

        /// <summary>
        /// 使用图层当前的符号初始化各选项的默认值。
        /// </summary>
        private void LoadFromSymbol(ISymbol symbol)
        {
            if (symbol == null)
            {
                return;
            }

            ISimpleMarkerSymbol markerSymbol = symbol as ISimpleMarkerSymbol;
            if (markerSymbol != null)
            {
                cboPointStyle.SelectedIndex = GetMarkerStyleIndex(markerSymbol.Style);
                numPointSize.Value = Clamp((decimal)markerSymbol.Size, numPointSize.Minimum, numPointSize.Maximum);
                btnPointColor.Color = ToWinColor(markerSymbol.Color);
                chkPointOutline.Checked = markerSymbol.Outline;
                btnPointOutlineColor.Color = ToWinColor(markerSymbol.OutlineColor);
                numPointOutlineSize.Value = Clamp((decimal)markerSymbol.OutlineSize, numPointOutlineSize.Minimum, numPointOutlineSize.Maximum);
                return;
            }

            ISimpleLineSymbol lineSymbol = symbol as ISimpleLineSymbol;
            if (lineSymbol != null)
            {
                cboLineStyle.SelectedIndex = GetLineStyleIndex(lineSymbol.Style);
                numLineWidth.Value = Clamp((decimal)lineSymbol.Width, numLineWidth.Minimum, numLineWidth.Maximum);
                btnLineColor.Color = ToWinColor(lineSymbol.Color);
                return;
            }

            ISimpleFillSymbol fillSymbol = symbol as ISimpleFillSymbol;
            if (fillSymbol != null)
            {
                cboFillStyle.SelectedIndex = GetFillStyleIndex(fillSymbol.Style);
                btnFillColor.Color = ToWinColor(fillSymbol.Color);
                ILineSymbol outline = fillSymbol.Outline;
                if (outline != null)
                {
                    btnOutlineColor.Color = ToWinColor(outline.Color);
                    numOutlineWidth.Value = Clamp((decimal)outline.Width, numOutlineWidth.Minimum, numOutlineWidth.Maximum);
                }
            }
        }

        #endregion

        #region 符号生成

        /// <summary>
        /// 根据用户设置生成对应的符号。
        /// </summary>
        private ISymbol BuildSymbol()
        {
            if (IsPointLayer)
            {
                ISimpleMarkerSymbol markerSymbol = new SimpleMarkerSymbol();
                markerSymbol.Style = GetMarkerStyle(cboPointStyle.SelectedIndex);
                markerSymbol.Size = (double)numPointSize.Value;
                markerSymbol.Color = ToArcGisColor(btnPointColor.Color);
                markerSymbol.Outline = chkPointOutline.Checked;
                markerSymbol.OutlineColor = ToArcGisColor(btnPointOutlineColor.Color);
                markerSymbol.OutlineSize = (double)numPointOutlineSize.Value;
                return (ISymbol)markerSymbol;
            }

            if (IsLineLayer)
            {
                ISimpleLineSymbol lineSymbol = new SimpleLineSymbol();
                lineSymbol.Style = GetLineStyle(cboLineStyle.SelectedIndex);
                lineSymbol.Width = (double)numLineWidth.Value;
                lineSymbol.Color = ToArcGisColor(btnLineColor.Color);
                return (ISymbol)lineSymbol;
            }

            ISimpleFillSymbol fillSymbol = new SimpleFillSymbol();
            fillSymbol.Style = GetFillStyle(cboFillStyle.SelectedIndex);
            fillSymbol.Color = ToArcGisColor(btnFillColor.Color);

            ISimpleLineSymbol outlineSymbol = new SimpleLineSymbol();
            outlineSymbol.Style = esriSimpleLineStyle.esriSLSSolid;
            outlineSymbol.Color = ToArcGisColor(btnOutlineColor.Color);
            outlineSymbol.Width = (double)numOutlineWidth.Value;
            fillSymbol.Outline = outlineSymbol;

            return (ISymbol)fillSymbol;
        }

        #endregion

        #region 预览绘制

        /// <summary>
        /// 刷新预览区。
        /// </summary>
        private void UpdatePreview()
        {
            if (picPreview != null)
            {
                picPreview.Invalidate();
            }
        }

        /// <summary>
        /// 使用 GDI+ 绘制符号预览。
        /// </summary>
        private void picPreview_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            RectangleF area = new RectangleF(6, 6, picPreview.Width - 12, picPreview.Height - 12);

            if (IsPointLayer)
            {
                DrawPointPreview(g, area);
            }
            else if (IsLineLayer)
            {
                DrawLinePreview(g, area);
            }
            else if (IsPolygonLayer)
            {
                DrawPolygonPreview(g, area);
            }
        }

        /// <summary>
        /// 绘制点符号预览。
        /// </summary>
        private void DrawPointPreview(Graphics g, RectangleF area)
        {
            float size = (float)numPointSize.Value;
            PointF center = new PointF(area.Left + area.Width / 2, area.Top + area.Height / 2);
            // 预览区大小有限，这里按比例缩放显示
            float scale = Math.Min(1.0f, area.Height / (size + 8));
            size = Math.Max(3f, size * scale);

            using (SolidBrush brush = new SolidBrush(btnPointColor.Color))
            using (Pen outlinePen = new Pen(btnPointOutlineColor.Color, (float)numPointOutlineSize.Value))
            {
                switch (cboPointStyle.SelectedIndex)
                {
                    case 1: // 方形
                        RectangleF rect = new RectangleF(center.X - size / 2, center.Y - size / 2, size, size);
                        g.FillRectangle(brush, rect);
                        if (chkPointOutline.Checked) g.DrawRectangle(outlinePen, rect.X, rect.Y, rect.Width, rect.Height);
                        break;
                    case 2: // 十字
                        float t = size / 6f;
                        g.FillRectangle(brush, center.X - size / 2, center.Y - t, size, t * 2);
                        g.FillRectangle(brush, center.X - t, center.Y - size / 2, t * 2, size);
                        break;
                    case 3: // X 形
                        g.DrawLine(outlinePen, center.X - size / 2, center.Y - size / 2, center.X + size / 2, center.Y + size / 2);
                        g.DrawLine(outlinePen, center.X - size / 2, center.Y + size / 2, center.X + size / 2, center.Y - size / 2);
                        break;
                    case 4: // 菱形
                        PointF[] diamond =
                        {
                            new PointF(center.X, center.Y - size / 2),
                            new PointF(center.X + size / 2, center.Y),
                            new PointF(center.X, center.Y + size / 2),
                            new PointF(center.X - size / 2, center.Y)
                        };
                        g.FillPolygon(brush, diamond);
                        if (chkPointOutline.Checked) g.DrawPolygon(outlinePen, diamond);
                        break;
                    default: // 圆形
                        g.FillEllipse(brush, center.X - size / 2, center.Y - size / 2, size, size);
                        if (chkPointOutline.Checked) g.DrawEllipse(outlinePen, center.X - size / 2, center.Y - size / 2, size, size);
                        break;
                }
            }
        }

        /// <summary>
        /// 绘制线符号预览。
        /// </summary>
        private void DrawLinePreview(Graphics g, RectangleF area)
        {
            float width = Math.Max(1f, (float)numLineWidth.Value);
            using (Pen pen = new Pen(btnLineColor.Color, width))
            {
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;
                switch (cboLineStyle.SelectedIndex)
                {
                    case 1:
                        pen.DashStyle = DashStyle.Dash;
                        break;
                    case 2:
                        pen.DashStyle = DashStyle.Dot;
                        break;
                    case 3:
                        pen.DashStyle = DashStyle.DashDot;
                        break;
                    case 4:
                        pen.DashStyle = DashStyle.DashDotDot;
                        break;
                }
                g.DrawLine(pen, area.Left, area.Top + area.Height / 2, area.Right, area.Top + area.Height / 2);
            }
        }

        /// <summary>
        /// 绘制面符号预览。
        /// </summary>
        private void DrawPolygonPreview(Graphics g, RectangleF area)
        {
            RectangleF rect = new RectangleF(area.Left, area.Top, area.Width * 0.55f, area.Height * 0.7f);

            using (SolidBrush brush = new SolidBrush(btnFillColor.Color))
            using (Pen outlinePen = new Pen(btnOutlineColor.Color, Math.Max(1f, (float)numOutlineWidth.Value)))
            {
                switch (cboFillStyle.SelectedIndex)
                {
                    case 1: // 空心
                        g.DrawRectangle(outlinePen, rect.X, rect.Y, rect.Width, rect.Height);
                        break;
                    case 2: // 水平线
                        g.DrawRectangle(outlinePen, rect.X, rect.Y, rect.Width, rect.Height);
                        using (Pen hatch = new Pen(btnFillColor.Color, 1))
                        {
                            for (float y = rect.Top; y <= rect.Bottom; y += 6)
                            {
                                g.DrawLine(hatch, rect.Left, y, rect.Right, y);
                            }
                        }
                        break;
                    case 3: // 垂直线
                        g.DrawRectangle(outlinePen, rect.X, rect.Y, rect.Width, rect.Height);
                        using (Pen hatch = new Pen(btnFillColor.Color, 1))
                        {
                            for (float x = rect.Left; x <= rect.Right; x += 6)
                            {
                                g.DrawLine(hatch, x, rect.Top, x, rect.Bottom);
                            }
                        }
                        break;
                    case 4: // 斜线
                        g.DrawRectangle(outlinePen, rect.X, rect.Y, rect.Width, rect.Height);
                        using (Pen hatch = new Pen(btnFillColor.Color, 1))
                        {
                            for (float d = -rect.Height; d <= rect.Width; d += 6)
                            {
                                g.DrawLine(hatch, rect.Left + d, rect.Bottom, rect.Left + d + rect.Height, rect.Top);
                            }
                        }
                        break;
                    case 5: // 交叉线
                        g.DrawRectangle(outlinePen, rect.X, rect.Y, rect.Width, rect.Height);
                        using (Pen hatch = new Pen(btnFillColor.Color, 1))
                        {
                            for (float d = -rect.Height; d <= rect.Width; d += 6)
                            {
                                g.DrawLine(hatch, rect.Left + d, rect.Bottom, rect.Left + d + rect.Height, rect.Top);
                                g.DrawLine(hatch, rect.Left + d, rect.Top, rect.Left + d + rect.Height, rect.Bottom);
                            }
                        }
                        break;
                    default: // 实心
                        g.FillRectangle(brush, rect);
                        g.DrawRectangle(outlinePen, rect.X, rect.Y, rect.Width, rect.Height);
                        break;
                }
            }
        }

        #endregion

        #region 事件处理

        /// <summary>
        /// 任一符号参数变化时刷新预览。
        /// </summary>
        private void symbolParameterChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        /// <summary>
        /// 确定：生成符号并关闭对话框。
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            ResultSymbol = BuildSymbol();
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// 取消：直接关闭对话框。
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion

        #region 辅助方法

        /// <summary>
        /// 将 System.Drawing.Color 转换为 ArcGIS 的 IColor。
        /// </summary>
        private static IColor ToArcGisColor(Color color)
        {
            IRgbColor rgbColor = new RgbColor();
            rgbColor.Red = color.R;
            rgbColor.Green = color.G;
            rgbColor.Blue = color.B;
            return (IColor)rgbColor;
        }

        /// <summary>
        /// 将 ArcGIS 的 IColor 转换为 System.Drawing.Color。
        /// </summary>
        private static Color ToWinColor(IColor color)
        {
            if (color == null)
            {
                return Color.Red;
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

                // 非 RGB 颜色模型（HsvColor/HlsColor/CmykColor/GrayColor）只实现 IColor，
                // 需要通过 IColor.RGB 读取 OLE 格式（0x00BBGGRR）的整数值再转换。
                color.UseWindowsDithering = true;
                return ColorTranslator.FromOle(color.RGB);
            }
            catch
            {
                return Color.Red;
            }
        }

        /// <summary>
        /// 将数值限制在 NumericUpDown 的取值范围内。
        /// </summary>
        private static decimal Clamp(decimal value, decimal min, decimal max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        #endregion

        #region 样式索引与枚举转换

        private static esriSimpleMarkerStyle GetMarkerStyle(int index)
        {
            switch (index)
            {
                case 1: return esriSimpleMarkerStyle.esriSMSSquare;
                case 2: return esriSimpleMarkerStyle.esriSMSCross;
                case 3: return esriSimpleMarkerStyle.esriSMSX;
                case 4: return esriSimpleMarkerStyle.esriSMSDiamond;
                default: return esriSimpleMarkerStyle.esriSMSCircle;
            }
        }

        private static int GetMarkerStyleIndex(esriSimpleMarkerStyle style)
        {
            switch (style)
            {
                case esriSimpleMarkerStyle.esriSMSSquare: return 1;
                case esriSimpleMarkerStyle.esriSMSCross: return 2;
                case esriSimpleMarkerStyle.esriSMSX: return 3;
                case esriSimpleMarkerStyle.esriSMSDiamond: return 4;
                default: return 0;
            }
        }

        private static esriSimpleLineStyle GetLineStyle(int index)
        {
            switch (index)
            {
                case 1: return esriSimpleLineStyle.esriSLSDash;
                case 2: return esriSimpleLineStyle.esriSLSDot;
                case 3: return esriSimpleLineStyle.esriSLSDashDot;
                case 4: return esriSimpleLineStyle.esriSLSDashDotDot;
                default: return esriSimpleLineStyle.esriSLSSolid;
            }
        }

        private static int GetLineStyleIndex(esriSimpleLineStyle style)
        {
            switch (style)
            {
                case esriSimpleLineStyle.esriSLSDash: return 1;
                case esriSimpleLineStyle.esriSLSDot: return 2;
                case esriSimpleLineStyle.esriSLSDashDot: return 3;
                case esriSimpleLineStyle.esriSLSDashDotDot: return 4;
                default: return 0;
            }
        }

        private static esriSimpleFillStyle GetFillStyle(int index)
        {
            switch (index)
            {
                case 1: return esriSimpleFillStyle.esriSFSNull;
                case 2: return esriSimpleFillStyle.esriSFSHorizontal;
                case 3: return esriSimpleFillStyle.esriSFSVertical;
                case 4: return esriSimpleFillStyle.esriSFSForwardDiagonal;
                case 5: return esriSimpleFillStyle.esriSFSCross;
                default: return esriSimpleFillStyle.esriSFSSolid;
            }
        }

        private static int GetFillStyleIndex(esriSimpleFillStyle style)
        {
            switch (style)
            {
                case esriSimpleFillStyle.esriSFSNull: return 1;
                case esriSimpleFillStyle.esriSFSHorizontal: return 2;
                case esriSimpleFillStyle.esriSFSVertical: return 3;
                case esriSimpleFillStyle.esriSFSForwardDiagonal: return 4;
                case esriSimpleFillStyle.esriSFSCross: return 5;
                default: return 0;
            }
        }

        #endregion
    }

    /// <summary>
    /// 颜色选择按钮：点击弹出系统颜色选择对话框，并显示当前颜色。
    /// </summary>
    public class ColorButton : Button
    {
        private Color _color = System.Drawing.Color.Red;

        public ColorButton()
        {
            Text = string.Empty;
            BackColor = System.Drawing.Color.Red;
            FlatStyle = FlatStyle.Flat;
            UseVisualStyleBackColor = false;
        }

        /// <summary>
        /// 当前选择的颜色。
        /// </summary>
        public Color Color
        {
            get { return _color; }
            set
            {
                _color = value;
                BackColor = value;
                if (ColorChanged != null)
                {
                    ColorChanged(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// 颜色变化时触发的事件。
        /// </summary>
        public event EventHandler ColorChanged;

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            using (ColorDialog dialog = new ColorDialog())
            {
                dialog.Color = _color;
                dialog.FullOpen = true;
                if (dialog.ShowDialog(FindForm()) == DialogResult.OK)
                {
                    Color = dialog.Color;
                }
            }
        }
    }
}
