namespace MyMap
{
    partial class SimpleRenderDialog
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tabSymbols = new System.Windows.Forms.TabControl();
            this.tabPoint = new System.Windows.Forms.TabPage();
            this.tlpPoint = new System.Windows.Forms.TableLayoutPanel();
            this.lblPointStyle = new System.Windows.Forms.Label();
            this.cboPointStyle = new System.Windows.Forms.ComboBox();
            this.lblPointSize = new System.Windows.Forms.Label();
            this.numPointSize = new System.Windows.Forms.NumericUpDown();
            this.lblPointColor = new System.Windows.Forms.Label();
            this.btnPointColor = new MyMap.ColorButton();
            this.chkPointOutline = new System.Windows.Forms.CheckBox();
            this.lblPointOutlineColor = new System.Windows.Forms.Label();
            this.btnPointOutlineColor = new MyMap.ColorButton();
            this.lblPointOutlineSize = new System.Windows.Forms.Label();
            this.numPointOutlineSize = new System.Windows.Forms.NumericUpDown();
            this.tabLine = new System.Windows.Forms.TabPage();
            this.tlpLine = new System.Windows.Forms.TableLayoutPanel();
            this.lblLineStyle = new System.Windows.Forms.Label();
            this.cboLineStyle = new System.Windows.Forms.ComboBox();
            this.lblLineWidth = new System.Windows.Forms.Label();
            this.numLineWidth = new System.Windows.Forms.NumericUpDown();
            this.lblLineColor = new System.Windows.Forms.Label();
            this.btnLineColor = new MyMap.ColorButton();
            this.tabPolygon = new System.Windows.Forms.TabPage();
            this.tlpPolygon = new System.Windows.Forms.TableLayoutPanel();
            this.lblFillStyle = new System.Windows.Forms.Label();
            this.cboFillStyle = new System.Windows.Forms.ComboBox();
            this.lblFillColor = new System.Windows.Forms.Label();
            this.btnFillColor = new MyMap.ColorButton();
            this.lblOutlineColor = new System.Windows.Forms.Label();
            this.btnOutlineColor = new MyMap.ColorButton();
            this.lblOutlineWidth = new System.Windows.Forms.Label();
            this.numOutlineWidth = new System.Windows.Forms.NumericUpDown();
            this.tlpPreview = new System.Windows.Forms.TableLayoutPanel();
            this.lblPreview = new System.Windows.Forms.Label();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            this.tabSymbols.SuspendLayout();
            this.tabPoint.SuspendLayout();
            this.tlpPoint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPointSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPointOutlineSize)).BeginInit();
            this.tabLine.SuspendLayout();
            this.tlpLine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLineWidth)).BeginInit();
            this.tabPolygon.SuspendLayout();
            this.tlpPolygon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOutlineWidth)).BeginInit();
            this.tlpPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.flpButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tabSymbols, 0, 0);
            this.tlpMain.Controls.Add(this.tlpPreview, 0, 1);
            this.tlpMain.Controls.Add(this.flpButtons, 0, 3);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(4);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.Padding = new System.Windows.Forms.Padding(15);
            this.tlpMain.RowCount = 4;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 322F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.Size = new System.Drawing.Size(645, 504);
            this.tlpMain.TabIndex = 0;
            // 
            // tabSymbols
            // 
            this.tabSymbols.Controls.Add(this.tabPoint);
            this.tabSymbols.Controls.Add(this.tabLine);
            this.tabSymbols.Controls.Add(this.tabPolygon);
            this.tabSymbols.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSymbols.Location = new System.Drawing.Point(19, 19);
            this.tabSymbols.Margin = new System.Windows.Forms.Padding(4);
            this.tabSymbols.Name = "tabSymbols";
            this.tabSymbols.SelectedIndex = 0;
            this.tabSymbols.Size = new System.Drawing.Size(607, 314);
            this.tabSymbols.TabIndex = 0;
            // 
            // tabPoint
            // 
            this.tabPoint.Controls.Add(this.tlpPoint);
            this.tabPoint.Location = new System.Drawing.Point(4, 28);
            this.tabPoint.Margin = new System.Windows.Forms.Padding(4);
            this.tabPoint.Name = "tabPoint";
            this.tabPoint.Padding = new System.Windows.Forms.Padding(4);
            this.tabPoint.Size = new System.Drawing.Size(599, 282);
            this.tabPoint.TabIndex = 0;
            this.tabPoint.Text = "点符号";
            this.tabPoint.UseVisualStyleBackColor = true;
            // 
            // tlpPoint
            // 
            this.tlpPoint.ColumnCount = 2;
            this.tlpPoint.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPoint.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPoint.Controls.Add(this.lblPointStyle, 0, 0);
            this.tlpPoint.Controls.Add(this.cboPointStyle, 1, 0);
            this.tlpPoint.Controls.Add(this.lblPointSize, 0, 1);
            this.tlpPoint.Controls.Add(this.numPointSize, 1, 1);
            this.tlpPoint.Controls.Add(this.lblPointColor, 0, 2);
            this.tlpPoint.Controls.Add(this.btnPointColor, 1, 2);
            this.tlpPoint.Controls.Add(this.chkPointOutline, 1, 3);
            this.tlpPoint.Controls.Add(this.lblPointOutlineColor, 0, 4);
            this.tlpPoint.Controls.Add(this.btnPointOutlineColor, 1, 4);
            this.tlpPoint.Controls.Add(this.lblPointOutlineSize, 0, 5);
            this.tlpPoint.Controls.Add(this.numPointOutlineSize, 1, 5);
            this.tlpPoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPoint.Location = new System.Drawing.Point(4, 4);
            this.tlpPoint.Margin = new System.Windows.Forms.Padding(4);
            this.tlpPoint.Name = "tlpPoint";
            this.tlpPoint.Padding = new System.Windows.Forms.Padding(6);
            this.tlpPoint.RowCount = 6;
            this.tlpPoint.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPoint.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPoint.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPoint.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPoint.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPoint.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPoint.Size = new System.Drawing.Size(591, 274);
            this.tlpPoint.TabIndex = 0;
            // 
            // lblPointStyle
            // 
            this.lblPointStyle.AutoSize = true;
            this.lblPointStyle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPointStyle.Location = new System.Drawing.Point(10, 6);
            this.lblPointStyle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPointStyle.Name = "lblPointStyle";
            this.lblPointStyle.Size = new System.Drawing.Size(98, 34);
            this.lblPointStyle.TabIndex = 0;
            this.lblPointStyle.Text = "点样式：";
            this.lblPointStyle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboPointStyle
            // 
            this.cboPointStyle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboPointStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPointStyle.Items.AddRange(new object[] {
            "圆形",
            "方形",
            "十字",
            "X 形",
            "菱形"});
            this.cboPointStyle.Location = new System.Drawing.Point(116, 10);
            this.cboPointStyle.Margin = new System.Windows.Forms.Padding(4, 4, 60, 4);
            this.cboPointStyle.Name = "cboPointStyle";
            this.cboPointStyle.Size = new System.Drawing.Size(409, 26);
            this.cboPointStyle.TabIndex = 1;
            this.cboPointStyle.SelectedIndexChanged += new System.EventHandler(this.symbolParameterChanged);
            // 
            // lblPointSize
            // 
            this.lblPointSize.AutoSize = true;
            this.lblPointSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPointSize.Location = new System.Drawing.Point(10, 40);
            this.lblPointSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPointSize.Name = "lblPointSize";
            this.lblPointSize.Size = new System.Drawing.Size(98, 36);
            this.lblPointSize.TabIndex = 2;
            this.lblPointSize.Text = "点大小：";
            this.lblPointSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numPointSize
            // 
            this.numPointSize.DecimalPlaces = 1;
            this.numPointSize.Dock = System.Windows.Forms.DockStyle.Left;
            this.numPointSize.Location = new System.Drawing.Point(116, 44);
            this.numPointSize.Margin = new System.Windows.Forms.Padding(4);
            this.numPointSize.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numPointSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPointSize.Name = "numPointSize";
            this.numPointSize.Size = new System.Drawing.Size(150, 28);
            this.numPointSize.TabIndex = 3;
            this.numPointSize.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numPointSize.ValueChanged += new System.EventHandler(this.symbolParameterChanged);
            // 
            // lblPointColor
            // 
            this.lblPointColor.AutoSize = true;
            this.lblPointColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPointColor.Location = new System.Drawing.Point(10, 76);
            this.lblPointColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPointColor.Name = "lblPointColor";
            this.lblPointColor.Size = new System.Drawing.Size(98, 42);
            this.lblPointColor.TabIndex = 4;
            this.lblPointColor.Text = "点颜色：";
            this.lblPointColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPointColor
            // 
            this.btnPointColor.BackColor = System.Drawing.Color.Red;
            this.btnPointColor.Color = System.Drawing.Color.Red;
            this.btnPointColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPointColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPointColor.Location = new System.Drawing.Point(116, 80);
            this.btnPointColor.Margin = new System.Windows.Forms.Padding(4, 4, 60, 4);
            this.btnPointColor.Name = "btnPointColor";
            this.btnPointColor.Size = new System.Drawing.Size(409, 34);
            this.btnPointColor.TabIndex = 5;
            this.btnPointColor.UseVisualStyleBackColor = false;
            this.btnPointColor.ColorChanged += new System.EventHandler(this.symbolParameterChanged);
            // 
            // chkPointOutline
            // 
            this.chkPointOutline.AutoSize = true;
            this.chkPointOutline.Location = new System.Drawing.Point(116, 122);
            this.chkPointOutline.Margin = new System.Windows.Forms.Padding(4);
            this.chkPointOutline.Name = "chkPointOutline";
            this.chkPointOutline.Size = new System.Drawing.Size(124, 22);
            this.chkPointOutline.TabIndex = 6;
            this.chkPointOutline.Text = "显示点轮廓";
            this.chkPointOutline.CheckedChanged += new System.EventHandler(this.symbolParameterChanged);
            // 
            // lblPointOutlineColor
            // 
            this.lblPointOutlineColor.AutoSize = true;
            this.lblPointOutlineColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPointOutlineColor.Location = new System.Drawing.Point(10, 148);
            this.lblPointOutlineColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPointOutlineColor.Name = "lblPointOutlineColor";
            this.lblPointOutlineColor.Size = new System.Drawing.Size(98, 42);
            this.lblPointOutlineColor.TabIndex = 7;
            this.lblPointOutlineColor.Text = "轮廓颜色：";
            this.lblPointOutlineColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPointOutlineColor
            // 
            this.btnPointOutlineColor.BackColor = System.Drawing.Color.Red;
            this.btnPointOutlineColor.Color = System.Drawing.Color.Red;
            this.btnPointOutlineColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPointOutlineColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPointOutlineColor.Location = new System.Drawing.Point(116, 152);
            this.btnPointOutlineColor.Margin = new System.Windows.Forms.Padding(4, 4, 60, 4);
            this.btnPointOutlineColor.Name = "btnPointOutlineColor";
            this.btnPointOutlineColor.Size = new System.Drawing.Size(409, 34);
            this.btnPointOutlineColor.TabIndex = 8;
            this.btnPointOutlineColor.UseVisualStyleBackColor = false;
            this.btnPointOutlineColor.ColorChanged += new System.EventHandler(this.symbolParameterChanged);
            // 
            // lblPointOutlineSize
            // 
            this.lblPointOutlineSize.AutoSize = true;
            this.lblPointOutlineSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPointOutlineSize.Location = new System.Drawing.Point(10, 190);
            this.lblPointOutlineSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPointOutlineSize.Name = "lblPointOutlineSize";
            this.lblPointOutlineSize.Size = new System.Drawing.Size(98, 78);
            this.lblPointOutlineSize.TabIndex = 9;
            this.lblPointOutlineSize.Text = "轮廓粗细：";
            this.lblPointOutlineSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numPointOutlineSize
            // 
            this.numPointOutlineSize.DecimalPlaces = 2;
            this.numPointOutlineSize.Dock = System.Windows.Forms.DockStyle.Left;
            this.numPointOutlineSize.Location = new System.Drawing.Point(116, 194);
            this.numPointOutlineSize.Margin = new System.Windows.Forms.Padding(4);
            this.numPointOutlineSize.Name = "numPointOutlineSize";
            this.numPointOutlineSize.Size = new System.Drawing.Size(150, 28);
            this.numPointOutlineSize.TabIndex = 10;
            this.numPointOutlineSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPointOutlineSize.ValueChanged += new System.EventHandler(this.symbolParameterChanged);
            // 
            // tabLine
            // 
            this.tabLine.Controls.Add(this.tlpLine);
            this.tabLine.Location = new System.Drawing.Point(4, 28);
            this.tabLine.Margin = new System.Windows.Forms.Padding(4);
            this.tabLine.Name = "tabLine";
            this.tabLine.Padding = new System.Windows.Forms.Padding(4);
            this.tabLine.Size = new System.Drawing.Size(599, 282);
            this.tabLine.TabIndex = 1;
            this.tabLine.Text = "线符号";
            this.tabLine.UseVisualStyleBackColor = true;
            // 
            // tlpLine
            // 
            this.tlpLine.ColumnCount = 2;
            this.tlpLine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpLine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLine.Controls.Add(this.lblLineStyle, 0, 0);
            this.tlpLine.Controls.Add(this.cboLineStyle, 1, 0);
            this.tlpLine.Controls.Add(this.lblLineWidth, 0, 1);
            this.tlpLine.Controls.Add(this.numLineWidth, 1, 1);
            this.tlpLine.Controls.Add(this.lblLineColor, 0, 2);
            this.tlpLine.Controls.Add(this.btnLineColor, 1, 2);
            this.tlpLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLine.Location = new System.Drawing.Point(4, 4);
            this.tlpLine.Margin = new System.Windows.Forms.Padding(4);
            this.tlpLine.Name = "tlpLine";
            this.tlpLine.Padding = new System.Windows.Forms.Padding(6);
            this.tlpLine.RowCount = 3;
            this.tlpLine.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpLine.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpLine.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpLine.Size = new System.Drawing.Size(591, 274);
            this.tlpLine.TabIndex = 0;
            // 
            // lblLineStyle
            // 
            this.lblLineStyle.AutoSize = true;
            this.lblLineStyle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLineStyle.Location = new System.Drawing.Point(10, 6);
            this.lblLineStyle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLineStyle.Name = "lblLineStyle";
            this.lblLineStyle.Size = new System.Drawing.Size(80, 34);
            this.lblLineStyle.TabIndex = 0;
            this.lblLineStyle.Text = "线型：";
            this.lblLineStyle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboLineStyle
            // 
            this.cboLineStyle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboLineStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLineStyle.Items.AddRange(new object[] {
            "实线",
            "虚线",
            "点线",
            "点划线",
            "双点划线"});
            this.cboLineStyle.Location = new System.Drawing.Point(98, 10);
            this.cboLineStyle.Margin = new System.Windows.Forms.Padding(4, 4, 60, 4);
            this.cboLineStyle.Name = "cboLineStyle";
            this.cboLineStyle.Size = new System.Drawing.Size(427, 26);
            this.cboLineStyle.TabIndex = 1;
            this.cboLineStyle.SelectedIndexChanged += new System.EventHandler(this.symbolParameterChanged);
            // 
            // lblLineWidth
            // 
            this.lblLineWidth.AutoSize = true;
            this.lblLineWidth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLineWidth.Location = new System.Drawing.Point(10, 40);
            this.lblLineWidth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLineWidth.Name = "lblLineWidth";
            this.lblLineWidth.Size = new System.Drawing.Size(80, 36);
            this.lblLineWidth.TabIndex = 2;
            this.lblLineWidth.Text = "线粗细：";
            this.lblLineWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numLineWidth
            // 
            this.numLineWidth.DecimalPlaces = 2;
            this.numLineWidth.Dock = System.Windows.Forms.DockStyle.Left;
            this.numLineWidth.Location = new System.Drawing.Point(98, 44);
            this.numLineWidth.Margin = new System.Windows.Forms.Padding(4);
            this.numLineWidth.Name = "numLineWidth";
            this.numLineWidth.Size = new System.Drawing.Size(150, 28);
            this.numLineWidth.TabIndex = 3;
            this.numLineWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLineWidth.ValueChanged += new System.EventHandler(this.symbolParameterChanged);
            // 
            // lblLineColor
            // 
            this.lblLineColor.AutoSize = true;
            this.lblLineColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLineColor.Location = new System.Drawing.Point(10, 76);
            this.lblLineColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLineColor.Name = "lblLineColor";
            this.lblLineColor.Size = new System.Drawing.Size(80, 192);
            this.lblLineColor.TabIndex = 4;
            this.lblLineColor.Text = "线颜色：";
            this.lblLineColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnLineColor
            // 
            this.btnLineColor.BackColor = System.Drawing.Color.Red;
            this.btnLineColor.Color = System.Drawing.Color.Red;
            this.btnLineColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLineColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLineColor.Location = new System.Drawing.Point(98, 80);
            this.btnLineColor.Margin = new System.Windows.Forms.Padding(4, 4, 60, 4);
            this.btnLineColor.Name = "btnLineColor";
            this.btnLineColor.Size = new System.Drawing.Size(427, 184);
            this.btnLineColor.TabIndex = 5;
            this.btnLineColor.UseVisualStyleBackColor = false;
            this.btnLineColor.ColorChanged += new System.EventHandler(this.symbolParameterChanged);
            // 
            // tabPolygon
            // 
            this.tabPolygon.Controls.Add(this.tlpPolygon);
            this.tabPolygon.Location = new System.Drawing.Point(4, 28);
            this.tabPolygon.Margin = new System.Windows.Forms.Padding(4);
            this.tabPolygon.Name = "tabPolygon";
            this.tabPolygon.Padding = new System.Windows.Forms.Padding(4);
            this.tabPolygon.Size = new System.Drawing.Size(599, 282);
            this.tabPolygon.TabIndex = 2;
            this.tabPolygon.Text = "面符号";
            this.tabPolygon.UseVisualStyleBackColor = true;
            // 
            // tlpPolygon
            // 
            this.tlpPolygon.ColumnCount = 2;
            this.tlpPolygon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPolygon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPolygon.Controls.Add(this.lblFillStyle, 0, 0);
            this.tlpPolygon.Controls.Add(this.cboFillStyle, 1, 0);
            this.tlpPolygon.Controls.Add(this.lblFillColor, 0, 1);
            this.tlpPolygon.Controls.Add(this.btnFillColor, 1, 1);
            this.tlpPolygon.Controls.Add(this.lblOutlineColor, 0, 2);
            this.tlpPolygon.Controls.Add(this.btnOutlineColor, 1, 2);
            this.tlpPolygon.Controls.Add(this.lblOutlineWidth, 0, 3);
            this.tlpPolygon.Controls.Add(this.numOutlineWidth, 1, 3);
            this.tlpPolygon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPolygon.Location = new System.Drawing.Point(4, 4);
            this.tlpPolygon.Margin = new System.Windows.Forms.Padding(4);
            this.tlpPolygon.Name = "tlpPolygon";
            this.tlpPolygon.Padding = new System.Windows.Forms.Padding(6);
            this.tlpPolygon.RowCount = 4;
            this.tlpPolygon.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPolygon.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPolygon.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPolygon.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPolygon.Size = new System.Drawing.Size(591, 274);
            this.tlpPolygon.TabIndex = 0;
            // 
            // lblFillStyle
            // 
            this.lblFillStyle.AutoSize = true;
            this.lblFillStyle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFillStyle.Location = new System.Drawing.Point(10, 6);
            this.lblFillStyle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFillStyle.Name = "lblFillStyle";
            this.lblFillStyle.Size = new System.Drawing.Size(98, 34);
            this.lblFillStyle.TabIndex = 0;
            this.lblFillStyle.Text = "填充样式：";
            this.lblFillStyle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboFillStyle
            // 
            this.cboFillStyle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboFillStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFillStyle.Items.AddRange(new object[] {
            "实心",
            "空心",
            "水平线",
            "垂直线",
            "斜线",
            "交叉线"});
            this.cboFillStyle.Location = new System.Drawing.Point(116, 10);
            this.cboFillStyle.Margin = new System.Windows.Forms.Padding(4, 4, 60, 4);
            this.cboFillStyle.Name = "cboFillStyle";
            this.cboFillStyle.Size = new System.Drawing.Size(409, 26);
            this.cboFillStyle.TabIndex = 1;
            this.cboFillStyle.SelectedIndexChanged += new System.EventHandler(this.symbolParameterChanged);
            // 
            // lblFillColor
            // 
            this.lblFillColor.AutoSize = true;
            this.lblFillColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFillColor.Location = new System.Drawing.Point(10, 40);
            this.lblFillColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFillColor.Name = "lblFillColor";
            this.lblFillColor.Size = new System.Drawing.Size(98, 42);
            this.lblFillColor.TabIndex = 2;
            this.lblFillColor.Text = "填充颜色：";
            this.lblFillColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnFillColor
            // 
            this.btnFillColor.BackColor = System.Drawing.Color.Red;
            this.btnFillColor.Color = System.Drawing.Color.Red;
            this.btnFillColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFillColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFillColor.Location = new System.Drawing.Point(116, 44);
            this.btnFillColor.Margin = new System.Windows.Forms.Padding(4, 4, 60, 4);
            this.btnFillColor.Name = "btnFillColor";
            this.btnFillColor.Size = new System.Drawing.Size(409, 34);
            this.btnFillColor.TabIndex = 3;
            this.btnFillColor.UseVisualStyleBackColor = false;
            this.btnFillColor.ColorChanged += new System.EventHandler(this.symbolParameterChanged);
            // 
            // lblOutlineColor
            // 
            this.lblOutlineColor.AutoSize = true;
            this.lblOutlineColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOutlineColor.Location = new System.Drawing.Point(10, 82);
            this.lblOutlineColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOutlineColor.Name = "lblOutlineColor";
            this.lblOutlineColor.Size = new System.Drawing.Size(98, 42);
            this.lblOutlineColor.TabIndex = 4;
            this.lblOutlineColor.Text = "边线颜色：";
            this.lblOutlineColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnOutlineColor
            // 
            this.btnOutlineColor.BackColor = System.Drawing.Color.Red;
            this.btnOutlineColor.Color = System.Drawing.Color.Red;
            this.btnOutlineColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOutlineColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOutlineColor.Location = new System.Drawing.Point(116, 86);
            this.btnOutlineColor.Margin = new System.Windows.Forms.Padding(4, 4, 60, 4);
            this.btnOutlineColor.Name = "btnOutlineColor";
            this.btnOutlineColor.Size = new System.Drawing.Size(409, 34);
            this.btnOutlineColor.TabIndex = 5;
            this.btnOutlineColor.UseVisualStyleBackColor = false;
            this.btnOutlineColor.ColorChanged += new System.EventHandler(this.symbolParameterChanged);
            // 
            // lblOutlineWidth
            // 
            this.lblOutlineWidth.AutoSize = true;
            this.lblOutlineWidth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOutlineWidth.Location = new System.Drawing.Point(10, 124);
            this.lblOutlineWidth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOutlineWidth.Name = "lblOutlineWidth";
            this.lblOutlineWidth.Size = new System.Drawing.Size(98, 144);
            this.lblOutlineWidth.TabIndex = 6;
            this.lblOutlineWidth.Text = "边线粗细：";
            this.lblOutlineWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numOutlineWidth
            // 
            this.numOutlineWidth.DecimalPlaces = 2;
            this.numOutlineWidth.Dock = System.Windows.Forms.DockStyle.Left;
            this.numOutlineWidth.Location = new System.Drawing.Point(116, 128);
            this.numOutlineWidth.Margin = new System.Windows.Forms.Padding(4);
            this.numOutlineWidth.Name = "numOutlineWidth";
            this.numOutlineWidth.Size = new System.Drawing.Size(150, 28);
            this.numOutlineWidth.TabIndex = 7;
            this.numOutlineWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numOutlineWidth.ValueChanged += new System.EventHandler(this.symbolParameterChanged);
            // 
            // tlpPreview
            // 
            this.tlpPreview.ColumnCount = 2;
            this.tlpPreview.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPreview.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPreview.Controls.Add(this.lblPreview, 0, 0);
            this.tlpPreview.Controls.Add(this.picPreview, 1, 0);
            this.tlpPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPreview.Location = new System.Drawing.Point(19, 341);
            this.tlpPreview.Margin = new System.Windows.Forms.Padding(4);
            this.tlpPreview.Name = "tlpPreview";
            this.tlpPreview.RowCount = 1;
            this.tlpPreview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPreview.Size = new System.Drawing.Size(607, 85);
            this.tlpPreview.TabIndex = 1;
            // 
            // lblPreview
            // 
            this.lblPreview.AutoSize = true;
            this.lblPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPreview.Location = new System.Drawing.Point(4, 0);
            this.lblPreview.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new System.Drawing.Size(98, 85);
            this.lblPreview.TabIndex = 0;
            this.lblPreview.Text = "效果预览：";
            this.lblPreview.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // picPreview
            // 
            this.picPreview.BackColor = System.Drawing.Color.White;
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPreview.Location = new System.Drawing.Point(110, 4);
            this.picPreview.Margin = new System.Windows.Forms.Padding(4);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(493, 77);
            this.picPreview.TabIndex = 1;
            this.picPreview.TabStop = false;
            this.picPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.picPreview_Paint);
            // 
            // flpButtons
            // 
            this.flpButtons.Controls.Add(this.btnCancel);
            this.flpButtons.Controls.Add(this.btnOk);
            this.flpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpButtons.Location = new System.Drawing.Point(19, 431);
            this.flpButtons.Margin = new System.Windows.Forms.Padding(4);
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.Size = new System.Drawing.Size(607, 54);
            this.flpButtons.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(475, 4);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(128, 42);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(339, 4);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(128, 42);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // SimpleRenderDialog
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(645, 504);
            this.Controls.Add(this.tlpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SimpleRenderDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "简单渲染设置";
            this.tlpMain.ResumeLayout(false);
            this.tabSymbols.ResumeLayout(false);
            this.tabPoint.ResumeLayout(false);
            this.tlpPoint.ResumeLayout(false);
            this.tlpPoint.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPointSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPointOutlineSize)).EndInit();
            this.tabLine.ResumeLayout(false);
            this.tlpLine.ResumeLayout(false);
            this.tlpLine.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLineWidth)).EndInit();
            this.tabPolygon.ResumeLayout(false);
            this.tlpPolygon.ResumeLayout(false);
            this.tlpPolygon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOutlineWidth)).EndInit();
            this.tlpPreview.ResumeLayout(false);
            this.tlpPreview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.flpButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TabControl tabSymbols;
        private System.Windows.Forms.TabPage tabPoint;
        private System.Windows.Forms.TableLayoutPanel tlpPoint;
        private System.Windows.Forms.Label lblPointStyle;
        private System.Windows.Forms.ComboBox cboPointStyle;
        private System.Windows.Forms.Label lblPointSize;
        private System.Windows.Forms.NumericUpDown numPointSize;
        private System.Windows.Forms.Label lblPointColor;
        private ColorButton btnPointColor;
        private System.Windows.Forms.CheckBox chkPointOutline;
        private System.Windows.Forms.Label lblPointOutlineColor;
        private ColorButton btnPointOutlineColor;
        private System.Windows.Forms.Label lblPointOutlineSize;
        private System.Windows.Forms.NumericUpDown numPointOutlineSize;
        private System.Windows.Forms.TabPage tabLine;
        private System.Windows.Forms.TableLayoutPanel tlpLine;
        private System.Windows.Forms.Label lblLineStyle;
        private System.Windows.Forms.ComboBox cboLineStyle;
        private System.Windows.Forms.Label lblLineWidth;
        private System.Windows.Forms.NumericUpDown numLineWidth;
        private System.Windows.Forms.Label lblLineColor;
        private ColorButton btnLineColor;
        private System.Windows.Forms.TabPage tabPolygon;
        private System.Windows.Forms.TableLayoutPanel tlpPolygon;
        private System.Windows.Forms.Label lblFillStyle;
        private System.Windows.Forms.ComboBox cboFillStyle;
        private System.Windows.Forms.Label lblFillColor;
        private ColorButton btnFillColor;
        private System.Windows.Forms.Label lblOutlineColor;
        private ColorButton btnOutlineColor;
        private System.Windows.Forms.Label lblOutlineWidth;
        private System.Windows.Forms.NumericUpDown numOutlineWidth;
        private System.Windows.Forms.TableLayoutPanel tlpPreview;
        private System.Windows.Forms.Label lblPreview;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}
