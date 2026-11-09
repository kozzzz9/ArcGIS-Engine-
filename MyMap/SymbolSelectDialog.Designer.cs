namespace MyMap
{
    partial class SymbolSelectDialog
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SymbolSelectDialog));
            this.tlpRoot = new System.Windows.Forms.TableLayoutPanel();
            this.tlpRight = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tlpParams = new System.Windows.Forms.TableLayoutPanel();
            this.labelColor = new System.Windows.Forms.Label();
            this.buttonColor = new System.Windows.Forms.Button();
            this.labelSize = new System.Windows.Forms.Label();
            this.numericUpDownSize = new System.Windows.Forms.NumericUpDown();
            this.labelWidth = new System.Windows.Forms.Label();
            this.numericUpDownWidth = new System.Windows.Forms.NumericUpDown();
            this.labelAngle = new System.Windows.Forms.Label();
            this.numericUpDownAngle = new System.Windows.Forms.NumericUpDown();
            this.labelTransparency = new System.Windows.Forms.Label();
            this.numericUpDownTransparency = new System.Windows.Forms.NumericUpDown();
            this.labelFrameColor = new System.Windows.Forms.Label();
            this.buttonFrameColor = new System.Windows.Forms.Button();
            this.flpTools = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonMore = new System.Windows.Forms.Button();
            this.buttonApplyLayer = new System.Windows.Forms.Button();
            this.buttonArcMapSelector = new System.Windows.Forms.Button();
            this.buttonExportPreview = new System.Windows.Forms.Button();
            this.flpOkCancel = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.saveFileDialogPreview = new System.Windows.Forms.SaveFileDialog();
            this.contextMenuStripMoreSymbol = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.axSymbologyControl = new ESRI.ArcGIS.Controls.AxSymbologyControl();
            this.tlpRoot.SuspendLayout();
            this.tlpRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tlpParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTransparency)).BeginInit();
            this.flpTools.SuspendLayout();
            this.flpOkCancel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axSymbologyControl)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpRoot
            // 
            this.tlpRoot.ColumnCount = 2;
            this.tlpRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 495F));
            this.tlpRoot.Controls.Add(this.axSymbologyControl, 0, 0);
            this.tlpRoot.Controls.Add(this.tlpRight, 1, 0);
            this.tlpRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRoot.Location = new System.Drawing.Point(0, 0);
            this.tlpRoot.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tlpRoot.Name = "tlpRoot";
            this.tlpRoot.Padding = new System.Windows.Forms.Padding(15, 15, 15, 15);
            this.tlpRoot.RowCount = 1;
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRoot.Size = new System.Drawing.Size(1020, 980);
            this.tlpRoot.TabIndex = 0;
            // 
            // tlpRight
            // 
            this.tlpRight.ColumnCount = 1;
            this.tlpRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRight.Controls.Add(this.pictureBoxPreview, 0, 0);
            this.tlpRight.Controls.Add(this.groupBox1, 0, 1);
            this.tlpRight.Controls.Add(this.flpTools, 0, 2);
            this.tlpRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRight.Location = new System.Drawing.Point(514, 19);
            this.tlpRight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tlpRight.Name = "tlpRight";
            this.tlpRight.RowCount = 3;
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 330F));
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRight.Size = new System.Drawing.Size(487, 942);
            this.tlpRight.TabIndex = 1;
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.BackColor = System.Drawing.Color.White;
            this.pictureBoxPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxPreview.Location = new System.Drawing.Point(4, 4);
            this.pictureBoxPreview.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(479, 292);
            this.pictureBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPreview.TabIndex = 1;
            this.pictureBoxPreview.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tlpParams);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(4, 424);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(479, 322);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "符号参数";
            // 
            // tlpParams
            // 
            this.tlpParams.ColumnCount = 2;
            this.tlpParams.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpParams.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpParams.Controls.Add(this.labelColor, 0, 0);
            this.tlpParams.Controls.Add(this.buttonColor, 1, 0);
            this.tlpParams.Controls.Add(this.labelSize, 0, 1);
            this.tlpParams.Controls.Add(this.numericUpDownSize, 1, 1);
            this.tlpParams.Controls.Add(this.labelWidth, 0, 2);
            this.tlpParams.Controls.Add(this.numericUpDownWidth, 1, 2);
            this.tlpParams.Controls.Add(this.labelAngle, 0, 3);
            this.tlpParams.Controls.Add(this.numericUpDownAngle, 1, 3);
            this.tlpParams.Controls.Add(this.labelTransparency, 0, 4);
            this.tlpParams.Controls.Add(this.numericUpDownTransparency, 1, 4);
            this.tlpParams.Controls.Add(this.labelFrameColor, 0, 5);
            this.tlpParams.Controls.Add(this.buttonFrameColor, 1, 5);
            this.tlpParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpParams.Location = new System.Drawing.Point(4, 25);
            this.tlpParams.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tlpParams.Name = "tlpParams";
            this.tlpParams.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tlpParams.RowCount = 6;
            this.tlpParams.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpParams.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpParams.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpParams.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpParams.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpParams.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpParams.Size = new System.Drawing.Size(471, 293);
            this.tlpParams.TabIndex = 0;
            // 
            // labelColor
            // 
            this.labelColor.AutoSize = true;
            this.labelColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelColor.Location = new System.Drawing.Point(10, 6);
            this.labelColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(98, 42);
            this.labelColor.TabIndex = 0;
            this.labelColor.Text = "颜色：";
            this.labelColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonColor
            // 
            this.buttonColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonColor.Location = new System.Drawing.Point(116, 10);
            this.buttonColor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonColor.Name = "buttonColor";
            this.buttonColor.Size = new System.Drawing.Size(345, 34);
            this.buttonColor.TabIndex = 1;
            this.buttonColor.UseVisualStyleBackColor = false;
            this.buttonColor.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSize.Location = new System.Drawing.Point(10, 48);
            this.labelSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(98, 36);
            this.labelSize.TabIndex = 2;
            this.labelSize.Text = "大小：";
            this.labelSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDownSize
            // 
            this.numericUpDownSize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDownSize.DecimalPlaces = 1;
            this.numericUpDownSize.Location = new System.Drawing.Point(116, 52);
            this.numericUpDownSize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDownSize.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDownSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSize.Name = "numericUpDownSize";
            this.numericUpDownSize.Size = new System.Drawing.Size(180, 28);
            this.numericUpDownSize.TabIndex = 3;
            this.numericUpDownSize.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDownSize.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelWidth.Location = new System.Drawing.Point(10, 84);
            this.labelWidth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(98, 36);
            this.labelWidth.TabIndex = 4;
            this.labelWidth.Text = "线宽：";
            this.labelWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDownWidth
            // 
            this.numericUpDownWidth.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDownWidth.DecimalPlaces = 2;
            this.numericUpDownWidth.Location = new System.Drawing.Point(116, 88);
            this.numericUpDownWidth.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDownWidth.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownWidth.Name = "numericUpDownWidth";
            this.numericUpDownWidth.Size = new System.Drawing.Size(180, 28);
            this.numericUpDownWidth.TabIndex = 5;
            this.numericUpDownWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownWidth.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // labelAngle
            // 
            this.labelAngle.AutoSize = true;
            this.labelAngle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAngle.Location = new System.Drawing.Point(10, 120);
            this.labelAngle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAngle.Name = "labelAngle";
            this.labelAngle.Size = new System.Drawing.Size(98, 36);
            this.labelAngle.TabIndex = 6;
            this.labelAngle.Text = "角度：";
            this.labelAngle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDownAngle
            // 
            this.numericUpDownAngle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDownAngle.DecimalPlaces = 1;
            this.numericUpDownAngle.Location = new System.Drawing.Point(116, 124);
            this.numericUpDownAngle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDownAngle.Maximum = new decimal(new int[] {
            359,
            0,
            0,
            0});
            this.numericUpDownAngle.Name = "numericUpDownAngle";
            this.numericUpDownAngle.Size = new System.Drawing.Size(180, 28);
            this.numericUpDownAngle.TabIndex = 7;
            this.numericUpDownAngle.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // labelTransparency
            // 
            this.labelTransparency.AutoSize = true;
            this.labelTransparency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTransparency.Location = new System.Drawing.Point(10, 156);
            this.labelTransparency.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTransparency.Name = "labelTransparency";
            this.labelTransparency.Size = new System.Drawing.Size(98, 36);
            this.labelTransparency.TabIndex = 8;
            this.labelTransparency.Text = "透明度：";
            this.labelTransparency.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDownTransparency
            // 
            this.numericUpDownTransparency.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDownTransparency.Location = new System.Drawing.Point(116, 160);
            this.numericUpDownTransparency.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDownTransparency.Name = "numericUpDownTransparency";
            this.numericUpDownTransparency.Size = new System.Drawing.Size(180, 28);
            this.numericUpDownTransparency.TabIndex = 9;
            this.numericUpDownTransparency.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownTransparency.ValueChanged += new System.EventHandler(this.numericUpDownTransparency_ValueChanged);
            // 
            // labelFrameColor
            // 
            this.labelFrameColor.AutoSize = true;
            this.labelFrameColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFrameColor.Location = new System.Drawing.Point(10, 192);
            this.labelFrameColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFrameColor.Name = "labelFrameColor";
            this.labelFrameColor.Size = new System.Drawing.Size(98, 155);
            this.labelFrameColor.TabIndex = 10;
            this.labelFrameColor.Text = "外框颜色：";
            this.labelFrameColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonFrameColor
            // 
            this.buttonFrameColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonFrameColor.Location = new System.Drawing.Point(116, 196);
            this.buttonFrameColor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonFrameColor.Name = "buttonFrameColor";
            this.buttonFrameColor.Size = new System.Drawing.Size(345, 147);
            this.buttonFrameColor.TabIndex = 11;
            this.buttonFrameColor.UseVisualStyleBackColor = false;
            this.buttonFrameColor.Click += new System.EventHandler(this.buttonFrameColor_Click);
            // 
            // flpTools
            // 
            this.flpTools.Controls.Add(this.buttonMore);
            this.flpTools.Controls.Add(this.buttonApplyLayer);
            this.flpTools.Controls.Add(this.buttonArcMapSelector);
            this.flpTools.Controls.Add(this.buttonExportPreview);
            this.flpTools.Controls.Add(this.flpOkCancel);
            this.flpTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTools.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpTools.Location = new System.Drawing.Point(4, 814);
            this.flpTools.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flpTools.Name = "flpTools";
            this.flpTools.Size = new System.Drawing.Size(479, 258);
            this.flpTools.TabIndex = 3;
            // 
            // buttonMore
            // 
            this.buttonMore.Location = new System.Drawing.Point(4, 4);
            this.buttonMore.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonMore.Name = "buttonMore";
            this.buttonMore.Size = new System.Drawing.Size(468, 48);
            this.buttonMore.TabIndex = 3;
            this.buttonMore.Text = "更多符号...";
            this.buttonMore.UseVisualStyleBackColor = true;
            this.buttonMore.Click += new System.EventHandler(this.buttonMore_Click);
            // 
            // buttonApplyLayer
            // 
            this.buttonApplyLayer.Location = new System.Drawing.Point(4, 60);
            this.buttonApplyLayer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonApplyLayer.Name = "buttonApplyLayer";
            this.buttonApplyLayer.Size = new System.Drawing.Size(468, 48);
            this.buttonApplyLayer.TabIndex = 4;
            this.buttonApplyLayer.Text = "应用到整个图层";
            this.buttonApplyLayer.UseVisualStyleBackColor = true;
            this.buttonApplyLayer.Click += new System.EventHandler(this.buttonApplyLayer_Click);
            // 
            // buttonArcMapSelector
            // 
            this.buttonArcMapSelector.Location = new System.Drawing.Point(4, 116);
            this.buttonArcMapSelector.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonArcMapSelector.Name = "buttonArcMapSelector";
            this.buttonArcMapSelector.Size = new System.Drawing.Size(468, 48);
            this.buttonArcMapSelector.TabIndex = 5;
            this.buttonArcMapSelector.Text = "打开ArcMap符号选择器";
            this.buttonArcMapSelector.UseVisualStyleBackColor = true;
            this.buttonArcMapSelector.Click += new System.EventHandler(this.buttonArcMapSelector_Click);
            // 
            // buttonExportPreview
            // 
            this.buttonExportPreview.Location = new System.Drawing.Point(4, 172);
            this.buttonExportPreview.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonExportPreview.Name = "buttonExportPreview";
            this.buttonExportPreview.Size = new System.Drawing.Size(468, 48);
            this.buttonExportPreview.TabIndex = 6;
            this.buttonExportPreview.Text = "导出预览图";
            this.buttonExportPreview.UseVisualStyleBackColor = true;
            this.buttonExportPreview.Click += new System.EventHandler(this.buttonExportPreview_Click);
            // 
            // flpOkCancel
            // 
            this.flpOkCancel.Controls.Add(this.buttonCancel);
            this.flpOkCancel.Controls.Add(this.buttonOk);
            this.flpOkCancel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpOkCancel.Location = new System.Drawing.Point(4, 228);
            this.flpOkCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flpOkCancel.Name = "flpOkCancel";
            this.flpOkCancel.Size = new System.Drawing.Size(477, 54);
            this.flpOkCancel.TabIndex = 7;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonCancel.Location = new System.Drawing.Point(327, 4);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(146, 45);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonOk.Location = new System.Drawing.Point(173, 4);
            this.buttonOk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(146, 45);
            this.buttonOk.TabIndex = 7;
            this.buttonOk.Text = "确定";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Server Style 文件|*.ServerStyle|所有文件|*.*";
            this.openFileDialog1.Title = "添加符号库文件";
            // 
            // saveFileDialogPreview
            // 
            this.saveFileDialogPreview.Filter = "PNG 图片(*.png)|*.png|JPEG 图片(*.jpg)|*.jpg";
            // 
            // contextMenuStripMoreSymbol
            // 
            this.contextMenuStripMoreSymbol.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripMoreSymbol.Name = "contextMenuStripMoreSymbol";
            this.contextMenuStripMoreSymbol.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStripMoreSymbol.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStripMoreSymbol_ItemClicked);
            // 
            // axSymbologyControl
            // 
            this.axSymbologyControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axSymbologyControl.Location = new System.Drawing.Point(19, 19);
            this.axSymbologyControl.Margin = new System.Windows.Forms.Padding(4);
            this.axSymbologyControl.Name = "axSymbologyControl";
            this.axSymbologyControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSymbologyControl.OcxState")));
            this.axSymbologyControl.Size = new System.Drawing.Size(487, 1162);
            this.axSymbologyControl.TabIndex = 0;
            this.axSymbologyControl.OnDoubleClick += new ESRI.ArcGIS.Controls.ISymbologyControlEvents_Ax_OnDoubleClickEventHandler(this.axSymbologyControl_OnDoubleClick);
            this.axSymbologyControl.OnStyleClassChanged += new ESRI.ArcGIS.Controls.ISymbologyControlEvents_Ax_OnStyleClassChangedEventHandler(this.axSymbologyControl_OnStyleClassChanged);
            this.axSymbologyControl.OnItemSelected += new ESRI.ArcGIS.Controls.ISymbologyControlEvents_Ax_OnItemSelectedEventHandler(this.axSymbologyControl_OnItemSelected);
            // 
            // SymbolSelectDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 980);
            this.Controls.Add(this.tlpRoot);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SymbolSelectDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "符号选择器";
            this.Load += new System.EventHandler(this.SymbolSelectDialog_Load);
            this.tlpRoot.ResumeLayout(false);
            this.tlpRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tlpParams.ResumeLayout(false);
            this.tlpParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTransparency)).EndInit();
            this.flpTools.ResumeLayout(false);
            this.flpOkCancel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axSymbologyControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpRoot;
        private System.Windows.Forms.TableLayoutPanel tlpRight;
        private ESRI.ArcGIS.Controls.AxSymbologyControl axSymbologyControl;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tlpParams;
        private System.Windows.Forms.Label labelColor;
        private System.Windows.Forms.Button buttonColor;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.NumericUpDown numericUpDownSize;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.NumericUpDown numericUpDownWidth;
        private System.Windows.Forms.Label labelAngle;
        private System.Windows.Forms.NumericUpDown numericUpDownAngle;
        private System.Windows.Forms.Label labelTransparency;
        private System.Windows.Forms.NumericUpDown numericUpDownTransparency;
        private System.Windows.Forms.Label labelFrameColor;
        private System.Windows.Forms.Button buttonFrameColor;
        private System.Windows.Forms.FlowLayoutPanel flpTools;
        private System.Windows.Forms.Button buttonMore;
        private System.Windows.Forms.Button buttonApplyLayer;
        private System.Windows.Forms.Button buttonArcMapSelector;
        private System.Windows.Forms.Button buttonExportPreview;
        private System.Windows.Forms.FlowLayoutPanel flpOkCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialogPreview;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMoreSymbol;
    }
}
