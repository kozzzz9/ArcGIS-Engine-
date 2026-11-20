using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;

namespace MyMap
{

    /// <summary>
    /// 柱状统计专题图参数对话框（实习十八）。
    /// 勾选参与统计的数值字段并为每个字段设置小矩形颜色（加分项），
    /// 设置柱宽、柱间距、图表最大高度、背景色与柱向，确定后由主窗体渲染。
    /// </summary>
    public partial class BarChartDialog : Form
    {
        /// <summary>当前图表类型（由菜单入口通过构造注入）。</summary>
        private ChartType _chartType;

        /// <summary>待统计的矢量图层。</summary>
        private readonly IFeatureLayer _featureLayer;

        #region 公共属性

        /// <summary>选中的字段与颜色列表。</summary>
        public List<BarChartField> SelectedFields { get; private set; }

        /// <summary>柱宽度（地图单位）。</summary>
        public double BarWidth { get { return (double)numWidth.Value; } }

        /// <summary>柱间距（地图单位）。</summary>
        public double BarSpacing { get { return (double)numSpacing.Value; } }

        /// <summary>图表最大高度（IMarkerSymbol.Size）。</summary>
        public double ChartSize { get { return (double)numSize.Value; } }

        /// <summary>是否垂直柱状。</summary>
        public bool VerticalBars { get { return chkVerticalBars.Checked; } }

        /// <summary>选中的图表类型（由菜单入口注入，界面内不再切换）。</summary>
        public ChartType SelectedChartType { get { return _chartType; } }

        /// <summary>堆叠柱状是否按百分比拉伸至最大高度（IStackedChartSymbol.Fixed）。</summary>
        public bool FixedStacked { get { return chkFixedStacked.Checked; } }

        /// <summary>图表背景色。</summary>
        public Color BackgroundColor { get { return btnBgColor.Color; } }

        /// <summary>饼状扇区描边宽度。</summary>
        public double PieOutlineWidth { get { return (double)numOutlineWidth.Value; } }

        /// <summary>饼状扇形是否顺时针方向。</summary>
        public bool PieClockwise { get { return chkClockwise.Checked; } }

        #endregion

        #region 构造函数

        /// <summary>
        /// 创建柱状统计专题图参数对话框（默认柱状类型）。
        /// </summary>
        /// <param name="featureLayer">待统计的矢量图层。</param>
        /// <summary>
        /// 设计器实例化专用无参构造（运行时请使用带图层参数的重载）。
        /// </summary>
        private BarChartDialog()
        {
            InitializeComponent();
            DrawChartPreview();
        }

        public BarChartDialog(IFeatureLayer featureLayer)
            : this(featureLayer, ChartType.BarChart)
        {
        }

        /// <summary>
        /// 创建统计专题图参数对话框，并预置图表类型（供柱状/饼状/堆叠柱状菜单共用）。
        /// </summary>
        /// <param name="featureLayer">待统计的矢量图层。</param>
        /// <param name="initialChartType">预置的图表类型。</param>
        public BarChartDialog(IFeatureLayer featureLayer, ChartType initialChartType)
        {
            _featureLayer = featureLayer;
            InitializeComponent();
            dgvFields.CellClick += new DataGridViewCellEventHandler(dgvFields_CellClick);

            // 参数变化时实时刷新图表预览
            numWidth.ValueChanged += delegate { DrawChartPreview(); };
            numSpacing.ValueChanged += delegate { DrawChartPreview(); };
            numSize.ValueChanged += delegate { DrawChartPreview(); };
            chkVerticalBars.CheckedChanged += delegate { DrawChartPreview(); };
            chkFixedStacked.CheckedChanged += delegate { DrawChartPreview(); };
            numOutlineWidth.ValueChanged += delegate { DrawChartPreview(); };
            chkClockwise.CheckedChanged += delegate { DrawChartPreview(); };
            btnBgColor.ColorChanged += delegate { DrawChartPreview(); };
            ApplyChartType(initialChartType);
            LoadFields();

            // 首次预览推迟到窗体显示后：构造阶段控件尚未布局，尺寸不可靠
            Shown += delegate(object s, EventArgs e2)
            {
                DrawChartPreview();
            };
        }

        /// <summary>
        /// 预置图表类型：同步下拉框选中项、参数启用状态与窗口标题。
        /// </summary>
        private void ApplyChartType(ChartType chartType)
        {
            _chartType = chartType;
            UpdateBarParamState();
            Text = GetChartDialogTitle(chartType);
        }

        /// <summary>
        /// 按图表类型返回对应的窗口标题。
        /// </summary>
        private static string GetChartDialogTitle(ChartType chartType)
        {
            switch (chartType)
            {
                case ChartType.PieChart:
                    return "饼状统计专题图";
                case ChartType.StackedChart:
                    return "堆叠柱状统计专题图";
                default:
                    return "柱状统计专题图";
            }
        }

        #endregion

        #region 数据加载

        /// <summary>
        /// 把图层中的数值字段填入表格：默认不勾选，颜色按渐变色带预分配。
        /// </summary>
        private void LoadFields()
        {
            dgvFields.Rows.Clear();
            if (_featureLayer == null || _featureLayer.FeatureClass == null)
            {
                return;
            }

            List<string> numericFields = new List<string>();
            IFields fields = _featureLayer.FeatureClass.Fields;
            for (int i = 0; i < fields.FieldCount; i++)
            {
                IField field = fields.get_Field(i);
                if (field == null)
                {
                    continue;
                }

                if (field.Type == esriFieldType.esriFieldTypeInteger ||
                    field.Type == esriFieldType.esriFieldTypeSmallInteger ||
                    field.Type == esriFieldType.esriFieldTypeSingle ||
                    field.Type == esriFieldType.esriFieldTypeDouble)
                {
                    numericFields.Add(field.Name);
                }
            }

            // 预分配颜色：红色系渐变，可在表格中逐字段修改（加分项）
            List<ESRI.ArcGIS.Display.IColor> colors =
                UniqueValueRenderHelper.CreateColors(1, Math.Max(numericFields.Count, 1));

            for (int i = 0; i < numericFields.Count; i++)
            {
                Color color = UniqueValueRenderHelper.ToWinColor(colors[i % colors.Count]);
                int rowIndex = dgvFields.Rows.Add(false, numericFields[i], "颜色");
                dgvFields.Rows[rowIndex].Cells["colColor"].Style.BackColor = color;
                dgvFields.Rows[rowIndex].Cells["colColor"].Style.ForeColor = color;
            }
        }

        #endregion

        #region 事件处理

        /// <summary>
        /// 按当前图表类型启用/禁用专属参数：
        /// 饼状不用柱宽/柱间距/柱向；堆叠柱状不用柱间距，但用柱宽/柱向/百分比堆叠。
        /// </summary>
        private void UpdateBarParamState()
        {
            ChartType chartType = _chartType;
            bool isPie = chartType == ChartType.PieChart;
            bool isStacked = chartType == ChartType.StackedChart;

            // 行 2：柱宽（柱/堆叠）与扇区描边宽度（饼）同格互斥显隐
            numWidth.Visible = !isPie;
            lblWidth.Visible = !isPie;
            numOutlineWidth.Visible = isPie;
            lblOutlineWidth.Visible = isPie;

            // 行 3：柱间距（柱）与扇形方向（饼）同格互斥显隐
            numSpacing.Visible = !isPie && !isStacked;
            lblSpacing.Visible = !isPie && !isStacked;
            chkClockwise.Visible = isPie;
            lblClockwise.Visible = isPie;

            chkVerticalBars.Visible = !isPie;
            chkFixedStacked.Enabled = isStacked;
        }

        /// <summary>
        /// 点击颜色列：弹出取色器修改该字段小矩形的颜色（加分项）。
        /// </summary>
        private void dgvFields_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (dgvFields.Columns[e.ColumnIndex].Name != "colColor")
            {
                DrawChartPreview(); // 勾选状态变化也会改变图表构成
                return;
            }

            using (ColorDialog dialog = new ColorDialog())
            {
                dialog.FullOpen = true;
                dialog.Color = dgvFields.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor;
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    dgvFields.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = dialog.Color;
                    dgvFields.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = dialog.Color;
                    DrawChartPreview();
                }
            }
        }

        /// <summary>
        /// 确定：收集选中的字段与颜色并关闭对话框。
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            List<BarChartField> selected = new List<BarChartField>();
            foreach (DataGridViewRow row in dgvFields.Rows)
            {
                object included = row.Cells["colInclude"].Value;
                bool isChecked = included != null && (bool)included;
                if (!isChecked)
                {
                    continue;
                }

                BarChartField field = new BarChartField();
                field.FieldName = Convert.ToString(row.Cells["colFieldName"].Value);
                field.Color = row.Cells["colColor"].Style.BackColor;
                selected.Add(field);
            }

            if (selected.Count == 0)
            {
                MessageBox.Show("请至少勾选一个参与统计的字段！");
                return;
            }

            SelectedFields = selected;
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

        #region 图表预览

        /// <summary>
        /// 按当前参数用 GDI+ 绘制示例图表预览：柱状/饼状/堆叠柱状，
        /// 使用表格勾选字段的颜色（不足时循环补足）。
        /// </summary>
        private void DrawChartPreview()
        {
            // 尺寸过小（未布局或被压缩）时不绘制，避免 FillPie 收到负半径
            if (picChartPreview == null || picChartPreview.Width < 60 || picChartPreview.Height < 50)
            {
                return;
            }

            List<Color> colors = new List<Color>();
            foreach (DataGridViewRow row in dgvFields.Rows)
            {
                object included = row.Cells["colInclude"].Value;
                if (included != null && (bool)included)
                {
                    colors.Add(row.Cells["colColor"].Style.BackColor);
                }
            }
            if (colors.Count == 0)
            {
                foreach (DataGridViewRow row in dgvFields.Rows)
                {
                    colors.Add(row.Cells["colColor"].Style.BackColor);
                }
            }
            if (colors.Count == 0)
            {
                // 表格无行（设计器实例化）时给示例三色，避免模零运算
                colors.Add(Color.Red);
                colors.Add(Color.FromArgb(0, 120, 255));
                colors.Add(Color.FromArgb(255, 170, 0));
            }

            ChartType chartType = _chartType;
            using (Bitmap bitmap = new Bitmap(picChartPreview.Width, picChartPreview.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.Clear(btnBgColor.Color);

                    int w = bitmap.Width;
                    int h = bitmap.Height;
                    int barWidth = Math.Max(2, Math.Min((int)numWidth.Value * 3, w / 4));
                    int gap = Math.Max(1, (int)numSpacing.Value);
                    int maxHeight = Math.Max(10, Math.Min((int)numSize.Value * 2, h - 24));
                    int baseLine = h - 12;

                    if (chartType == ChartType.PieChart)
                    {
                        // 饼状：三段扇区 50% / 30% / 20%
                        float radius = Math.Max(5f, Math.Min(w, h) / 2f - 10);
                        PointF center = new PointF(w / 2f, h / 2f);
                        double[] ratios = { 0.5, 0.3, 0.2 };
                        float startAngle = chkClockwise.Checked ? 0f : 180f;
                        float direction = chkClockwise.Checked ? 1f : -1f;
                        for (int i = 0; i < ratios.Length; i++)
                        {
                            float sweep = (float)(ratios[i] * 360) * direction;
                            Color color = colors[i % colors.Count];
                            using (SolidBrush brush = new SolidBrush(color))
                            {
                                g.FillPie(brush, center.X - radius, center.Y - radius,
                                    radius * 2, radius * 2, startAngle, sweep);
                            }
                            startAngle += sweep;
                        }
                        using (Pen outline = new Pen(Color.FromArgb(120, 120, 120),
                            Math.Max(0.5f, (float)numOutlineWidth.Value)))
                        {
                            g.DrawPie(outline, center.X - radius, center.Y - radius,
                                radius * 2, radius * 2, 0, 360);
                        }
                    }
                    else if (chartType == ChartType.StackedChart)
                    {
                        // 堆叠柱状：一根柱按 40% / 35% / 25% 分段
                        double[] ratios = { 0.4, 0.35, 0.25 };
                        int x = w / 2 - barWidth / 2;
                        float y = baseLine;
                        for (int i = 0; i < ratios.Length; i++)
                        {
                            float segHeight = chkFixedStacked.Checked
                                ? maxHeight / ratios.Length
                                : maxHeight * (float)ratios[i];
                            y -= segHeight;
                            Color color = colors[i % colors.Count];
                            using (SolidBrush brush = new SolidBrush(color))
                            {
                                g.FillRectangle(brush, x, y, barWidth, segHeight);
                            }
                            using (Pen outline = new Pen(Color.FromArgb(120, 120, 120), 0.6f))
                            {
                                g.DrawRectangle(outline, x, y, barWidth, segHeight);
                            }
                        }
                    }
                    else
                    {
                        // 柱状：三根柱按 100% / 60% / 30% 高度
                        double[] ratios = { 1.0, 0.6, 0.3 };
                        int x = (w - (barWidth * 3 + gap * 2)) / 2;
                        for (int i = 0; i < ratios.Length; i++)
                        {
                            int barHeight = Math.Max(2, (int)(maxHeight * ratios[i]));
                            Color color = colors[i % colors.Count];
                            using (SolidBrush brush = new SolidBrush(color))
                            {
                                if (chkVerticalBars.Checked)
                                {
                                    g.FillRectangle(brush, x, baseLine - barHeight, barWidth, barHeight);
                                }
                                else
                                {
                                    int barLen = Math.Max(2, (int)(maxHeight * ratios[i]));
                                    g.FillRectangle(brush, 10, x - 2, barLen, barWidth);
                                }
                            }
                            x += barWidth + gap;
                        }
                    }

                    using (Pen axis = new Pen(Color.FromArgb(150, 150, 150)))
                    {
                        g.DrawLine(axis, 6, baseLine, w - 6, baseLine);
                    }
                }

                Image oldImage = picChartPreview.Image;
                picChartPreview.Image = (Image)bitmap.Clone();
                if (oldImage != null)
                {
                    oldImage.Dispose();
                }
            }
        }

        #endregion
    }

    public enum ChartType
    {
        BarChart = 0,
        PieChart = 1,
        StackedChart = 2
    }

    /// <summary>
    /// 单个统计字段的柱状颜色描述：字段名与对应小矩形颜色。
    /// </summary>
    public class BarChartField
    {
        /// <summary>字段名。</summary>
        public string FieldName { get; set; }

        /// <summary>该字段小矩形的颜色（System.Drawing）。</summary>
        public Color Color { get; set; }
    }
}