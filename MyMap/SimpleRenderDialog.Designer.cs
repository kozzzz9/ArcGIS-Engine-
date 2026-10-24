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
            this.tabSymbols = new System.Windows.Forms.TabControl();
            this.tabPoint = new System.Windows.Forms.TabPage();
            this.tabLine = new System.Windows.Forms.TabPage();
            this.tabPolygon = new System.Windows.Forms.TabPage();
            this.lblPointStyle = new System.Windows.Forms.Label();
            this.cboPointStyle = new System.Windows.Forms.ComboBox();
            this.lblPointSize = new System.Windows.Forms.Label();
            this.numPointSize = new System.Windows.Forms.NumericUpDown();
            this.lblPointColor = new System.Windows.Forms.Label();
            this.btnPointColor = new global::MyMap.ColorButton();
            this.chkPointOutline = new System.Windows.Forms.CheckBox();
            this.lblPointOutlineColor = new System.Windows.Forms.Label();
            this.btnPointOutlineColor = new global::MyMap.ColorButton();
            this.lblPointOutlineSize = new System.Windows.Forms.Label();
            this.numPointOutlineSize = new System.Windows.Forms.NumericUpDown();
            this.lblLineStyle = new System.Windows.Forms.Label();
            this.cboLineStyle = new System.Windows.Forms.ComboBox();
            this.lblLineWidth = new System.Windows.Forms.Label();
            this.numLineWidth = new System.Windows.Forms.NumericUpDown();
            this.lblLineColor = new System.Windows.Forms.Label();
            this.btnLineColor = new global::MyMap.ColorButton();
            this.lblFillStyle = new System.Windows.Forms.Label();
            this.cboFillStyle = new System.Windows.Forms.ComboBox();
            this.lblFillColor = new System.Windows.Forms.Label();
            this.btnFillColor = new global::MyMap.ColorButton();
            this.lblOutlineColor = new System.Windows.Forms.Label();
            this.btnOutlineColor = new global::MyMap.ColorButton();
            this.lblOutlineWidth = new System.Windows.Forms.Label();
            this.numOutlineWidth = new System.Windows.Forms.NumericUpDown();
            this.lblPreview = new System.Windows.Forms.Label();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabSymbols.SuspendLayout();
            this.tabPoint.SuspendLayout();
            this.tabLine.SuspendLayout();
            this.tabPolygon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPointSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPointOutlineSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLineWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOutlineWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();
            //
            // tabSymbols
            //
            this.tabSymbols.Controls.Add(this.tabPoint);
            this.tabSymbols.Controls.Add(this.tabLine);
            this.tabSymbols.Controls.Add(this.tabPolygon);
            this.tabSymbols.Location = new System.Drawing.Point(12, 10);
            this.tabSymbols.Name = "tabSymbols";
            this.tabSymbols.SelectedIndex = 0;
            this.tabSymbols.Size = new System.Drawing.Size(406, 205);
            this.tabSymbols.TabIndex = 0;
            //
            // tabPoint
            //
            this.tabPoint.Controls.Add(this.lblPointStyle);
            this.tabPoint.Controls.Add(this.cboPointStyle);
            this.tabPoint.Controls.Add(this.lblPointSize);
            this.tabPoint.Controls.Add(this.numPointSize);
            this.tabPoint.Controls.Add(this.lblPointColor);
            this.tabPoint.Controls.Add(this.btnPointColor);
            this.tabPoint.Controls.Add(this.chkPointOutline);
            this.tabPoint.Controls.Add(this.lblPointOutlineColor);
            this.tabPoint.Controls.Add(this.btnPointOutlineColor);
            this.tabPoint.Controls.Add(this.lblPointOutlineSize);
            this.tabPoint.Controls.Add(this.numPointOutlineSize);
            this.tabPoint.Location = new System.Drawing.Point(4, 25);
            this.tabPoint.Name = "tabPoint";
            this.tabPoint.Padding = new System.Windows.Forms.Padding(10);
            this.tabPoint.Size = new System.Drawing.Size(398, 176);
            this.tabPoint.TabIndex = 0;
            this.tabPoint.Text = "点符号";
            this.tabPoint.UseVisualStyleBackColor = true;
            //
            // lblPointStyle
            //
            this.lblPointStyle.AutoSize = true;
            this.lblPointStyle.Location = new System.Drawing.Point(13, 13);
            this.lblPointStyle.Name = "lblPointStyle";
            this.lblPointStyle.Size = new System.Drawing.Size(65, 12);
            this.lblPointStyle.TabIndex = 0;
            this.lblPointStyle.Text = "点样式：";
            //
            // cboPointStyle
            //
            this.cboPointStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPointStyle.Items.AddRange(new object[] {
            "圆形",
            "方形",
            "十字",
            "X 形",
            "菱形"});
            this.cboPointStyle.Location = new System.Drawing.Point(90, 10);
            this.cboPointStyle.SelectedIndex = 0;
            this.cboPointStyle.Name = "cboPointStyle";
            this.cboPointStyle.Size = new System.Drawing.Size(140, 20);
            this.cboPointStyle.TabIndex = 1;
            this.cboPointStyle.SelectedIndexChanged += new System.EventHandler(this.symbolParameterChanged);
            //
            // lblPointSize
            //
            this.lblPointSize.AutoSize = true;
            this.lblPointSize.Location = new System.Drawing.Point(13, 51);
            this.lblPointSize.Name = "lblPointSize";
            this.lblPointSize.Size = new System.Drawing.Size(65, 12);
            this.lblPointSize.TabIndex = 2;
            this.lblPointSize.Text = "点大小：";
            //
            // numPointSize
            //
            this.numPointSize.DecimalPlaces = 1;
            this.numPointSize.Location = new System.Drawing.Point(90, 48);
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
            this.numPointSize.Size = new System.Drawing.Size(90, 21);
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
            this.lblPointColor.Location = new System.Drawing.Point(13, 89);
            this.lblPointColor.Name = "lblPointColor";
            this.lblPointColor.Size = new System.Drawing.Size(65, 12);
            this.lblPointColor.TabIndex = 4;
            this.lblPointColor.Text = "点颜色：";
            //
            // btnPointColor
            //
            this.btnPointColor.Location = new System.Drawing.Point(90, 86);
            this.btnPointColor.Name = "btnPointColor";
            this.btnPointColor.Size = new System.Drawing.Size(140, 24);
            this.btnPointColor.TabIndex = 5;
            this.btnPointColor.UseVisualStyleBackColor = false;
            this.btnPointColor.ColorChanged += new System.EventHandler(this.symbolParameterChanged);
            //
            // chkPointOutline
            //
            this.chkPointOutline.AutoSize = true;
            this.chkPointOutline.Location = new System.Drawing.Point(13, 128);
            this.chkPointOutline.Name = "chkPointOutline";
            this.chkPointOutline.Size = new System.Drawing.Size(96, 16);
            this.chkPointOutline.TabIndex = 6;
            this.chkPointOutline.Text = "显示点轮廓";
            this.chkPointOutline.CheckedChanged += new System.EventHandler(this.symbolParameterChanged);
            //
            // lblPointOutlineColor
            //
            this.lblPointOutlineColor.AutoSize = true;
            this.lblPointOutlineColor.Location = new System.Drawing.Point(13, 158);
            this.lblPointOutlineColor.Name = "lblPointOutlineColor";
            this.lblPointOutlineColor.Size = new System.Drawing.Size(65, 12);
            this.lblPointOutlineColor.TabIndex = 7;
            this.lblPointOutlineColor.Text = "轮廓颜色：";
            //
            // btnPointOutlineColor
            //
            this.btnPointOutlineColor.Location = new System.Drawing.Point(90, 154);
            this.btnPointOutlineColor.Name = "btnPointOutlineColor";
            this.btnPointOutlineColor.Size = new System.Drawing.Size(140, 24);
            this.btnPointOutlineColor.TabIndex = 8;
            this.btnPointOutlineColor.UseVisualStyleBackColor = false;
            this.btnPointOutlineColor.ColorChanged += new System.EventHandler(this.symbolParameterChanged);
            //
            // lblPointOutlineSize
            //
            this.lblPointOutlineSize.AutoSize = true;
            this.lblPointOutlineSize.Location = new System.Drawing.Point(13, 190);
            this.lblPointOutlineSize.Name = "lblPointOutlineSize";
            this.lblPointOutlineSize.Size = new System.Drawing.Size(65, 12);
            this.lblPointOutlineSize.TabIndex = 9;
            this.lblPointOutlineSize.Text = "轮廓粗细：";
            //
            // numPointOutlineSize
            //
            this.numPointOutlineSize.DecimalPlaces = 2;
            this.numPointOutlineSize.Location = new System.Drawing.Point(90, 187);
            this.numPointOutlineSize.Name = "numPointOutlineSize";
            this.numPointOutlineSize.Size = new System.Drawing.Size(90, 21);
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
            this.tabLine.Controls.Add(this.lblLineStyle);
            this.tabLine.Controls.Add(this.cboLineStyle);
            this.tabLine.Controls.Add(this.lblLineWidth);
            this.tabLine.Controls.Add(this.numLineWidth);
            this.tabLine.Controls.Add(this.lblLineColor);
            this.tabLine.Controls.Add(this.btnLineColor);
            this.tabLine.Location = new System.Drawing.Point(4, 25);
            this.tabLine.Name = "tabLine";
            this.tabLine.Padding = new System.Windows.Forms.Padding(10);
            this.tabLine.Size = new System.Drawing.Size(398, 176);
            this.tabLine.TabIndex = 1;
            this.tabLine.Text = "线符号";
            this.tabLine.UseVisualStyleBackColor = true;
            //
            // lblLineStyle
            //
            this.lblLineStyle.AutoSize = true;
            this.lblLineStyle.Location = new System.Drawing.Point(13, 13);
            this.lblLineStyle.Name = "lblLineStyle";
            this.lblLineStyle.Size = new System.Drawing.Size(53, 12);
            this.lblLineStyle.TabIndex = 0;
            this.lblLineStyle.Text = "线型：";
            //
            // cboLineStyle
            //
            this.cboLineStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLineStyle.Items.AddRange(new object[] {
            "实线",
            "虚线",
            "点线",
            "点划线",
            "双点划线"});
            this.cboLineStyle.Location = new System.Drawing.Point(90, 10);
            this.cboLineStyle.SelectedIndex = 0;
            this.cboLineStyle.Name = "cboLineStyle";
            this.cboLineStyle.Size = new System.Drawing.Size(140, 20);
            this.cboLineStyle.TabIndex = 1;
            this.cboLineStyle.SelectedIndexChanged += new System.EventHandler(this.symbolParameterChanged);
            //
            // lblLineWidth
            //
            this.lblLineWidth.AutoSize = true;
            this.lblLineWidth.Location = new System.Drawing.Point(13, 51);
            this.lblLineWidth.Name = "lblLineWidth";
            this.lblLineWidth.Size = new System.Drawing.Size(53, 12);
            this.lblLineWidth.TabIndex = 2;
            this.lblLineWidth.Text = "线粗细：";
            //
            // numLineWidth
            //
            this.numLineWidth.DecimalPlaces = 2;
            this.numLineWidth.Location = new System.Drawing.Point(90, 48);
            this.numLineWidth.Name = "numLineWidth";
            this.numLineWidth.Size = new System.Drawing.Size(90, 21);
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
            this.lblLineColor.Location = new System.Drawing.Point(13, 89);
            this.lblLineColor.Name = "lblLineColor";
            this.lblLineColor.Size = new System.Drawing.Size(53, 12);
            this.lblLineColor.TabIndex = 4;
            this.lblLineColor.Text = "线颜色：";
            //
            // btnLineColor
            //
            this.btnLineColor.Location = new System.Drawing.Point(90, 86);
            this.btnLineColor.Name = "btnLineColor";
            this.btnLineColor.Size = new System.Drawing.Size(140, 24);
            this.btnLineColor.TabIndex = 5;
            this.btnLineColor.UseVisualStyleBackColor = false;
            this.btnLineColor.ColorChanged += new System.EventHandler(this.symbolParameterChanged);
            //
            // tabPolygon
            //
            this.tabPolygon.Controls.Add(this.lblFillStyle);
            this.tabPolygon.Controls.Add(this.cboFillStyle);
            this.tabPolygon.Controls.Add(this.lblFillColor);
            this.tabPolygon.Controls.Add(this.btnFillColor);
            this.tabPolygon.Controls.Add(this.lblOutlineColor);
            this.tabPolygon.Controls.Add(this.btnOutlineColor);
            this.tabPolygon.Controls.Add(this.lblOutlineWidth);
            this.tabPolygon.Controls.Add(this.numOutlineWidth);
            this.tabPolygon.Location = new System.Drawing.Point(4, 25);
            this.tabPolygon.Name = "tabPolygon";
            this.tabPolygon.Padding = new System.Windows.Forms.Padding(10);
            this.tabPolygon.Size = new System.Drawing.Size(398, 176);
            this.tabPolygon.TabIndex = 2;
            this.tabPolygon.Text = "面符号";
            this.tabPolygon.UseVisualStyleBackColor = true;
            //
            // lblFillStyle
            //
            this.lblFillStyle.AutoSize = true;
            this.lblFillStyle.Location = new System.Drawing.Point(13, 13);
            this.lblFillStyle.Name = "lblFillStyle";
            this.lblFillStyle.Size = new System.Drawing.Size(65, 12);
            this.lblFillStyle.TabIndex = 0;
            this.lblFillStyle.Text = "填充样式：";
            //
            // cboFillStyle
            //
            this.cboFillStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFillStyle.Items.AddRange(new object[] {
            "实心",
            "空心",
            "水平线",
            "垂直线",
            "斜线",
            "交叉线"});
            this.cboFillStyle.Location = new System.Drawing.Point(90, 10);
            this.cboFillStyle.SelectedIndex = 0;
            this.cboFillStyle.Name = "cboFillStyle";
            this.cboFillStyle.Size = new System.Drawing.Size(140, 20);
            this.cboFillStyle.TabIndex = 1;
            this.cboFillStyle.SelectedIndexChanged += new System.EventHandler(this.symbolParameterChanged);
            //
            // lblFillColor
            //
            this.lblFillColor.AutoSize = true;
            this.lblFillColor.Location = new System.Drawing.Point(13, 51);
            this.lblFillColor.Name = "lblFillColor";
            this.lblFillColor.Size = new System.Drawing.Size(65, 12);
            this.lblFillColor.TabIndex = 2;
            this.lblFillColor.Text = "填充颜色：";
            //
            // btnFillColor
            //
            this.btnFillColor.Location = new System.Drawing.Point(90, 48);
            this.btnFillColor.Name = "btnFillColor";
            this.btnFillColor.Size = new System.Drawing.Size(140, 24);
            this.btnFillColor.TabIndex = 3;
            this.btnFillColor.UseVisualStyleBackColor = false;
            this.btnFillColor.ColorChanged += new System.EventHandler(this.symbolParameterChanged);
            //
            // lblOutlineColor
            //
            this.lblOutlineColor.AutoSize = true;
            this.lblOutlineColor.Location = new System.Drawing.Point(13, 89);
            this.lblOutlineColor.Name = "lblOutlineColor";
            this.lblOutlineColor.Size = new System.Drawing.Size(65, 12);
            this.lblOutlineColor.TabIndex = 4;
            this.lblOutlineColor.Text = "边线颜色：";
            //
            // btnOutlineColor
            //
            this.btnOutlineColor.Location = new System.Drawing.Point(90, 86);
            this.btnOutlineColor.Name = "btnOutlineColor";
            this.btnOutlineColor.Size = new System.Drawing.Size(140, 24);
            this.btnOutlineColor.TabIndex = 5;
            this.btnOutlineColor.UseVisualStyleBackColor = false;
            this.btnOutlineColor.ColorChanged += new System.EventHandler(this.symbolParameterChanged);
            //
            // lblOutlineWidth
            //
            this.lblOutlineWidth.AutoSize = true;
            this.lblOutlineWidth.Location = new System.Drawing.Point(13, 128);
            this.lblOutlineWidth.Name = "lblOutlineWidth";
            this.lblOutlineWidth.Size = new System.Drawing.Size(65, 12);
            this.lblOutlineWidth.TabIndex = 6;
            this.lblOutlineWidth.Text = "边线粗细：";
            //
            // numOutlineWidth
            //
            this.numOutlineWidth.DecimalPlaces = 2;
            this.numOutlineWidth.Location = new System.Drawing.Point(90, 125);
            this.numOutlineWidth.Name = "numOutlineWidth";
            this.numOutlineWidth.Size = new System.Drawing.Size(90, 21);
            this.numOutlineWidth.TabIndex = 7;
            this.numOutlineWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numOutlineWidth.ValueChanged += new System.EventHandler(this.symbolParameterChanged);
            //
            // lblPreview
            //
            this.lblPreview.AutoSize = true;
            this.lblPreview.Location = new System.Drawing.Point(14, 225);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new System.Drawing.Size(65, 12);
            this.lblPreview.TabIndex = 1;
            this.lblPreview.Text = "效果预览：";
            //
            // picPreview
            //
            this.picPreview.BackColor = System.Drawing.Color.White;
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPreview.Location = new System.Drawing.Point(90, 220);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(200, 55);
            this.picPreview.TabIndex = 2;
            this.picPreview.TabStop = false;
            this.picPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.picPreview_Paint);
            //
            // btnOk
            //
            this.btnOk.Location = new System.Drawing.Point(232, 285);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 28);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            //
            // btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(330, 285);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 28);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // SimpleRenderDialog
            //
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(430, 330);
            this.Controls.Add(this.tabSymbols);
            this.Controls.Add(this.lblPreview);
            this.Controls.Add(this.picPreview);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SimpleRenderDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "简单渲染设置";
            this.tabSymbols.ResumeLayout(false);
            this.tabPoint.ResumeLayout(false);
            this.tabPoint.PerformLayout();
            this.tabLine.ResumeLayout(false);
            this.tabLine.PerformLayout();
            this.tabPolygon.ResumeLayout(false);
            this.tabPolygon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPointSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPointOutlineSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLineWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOutlineWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabSymbols;
        private System.Windows.Forms.TabPage tabPoint;
        private System.Windows.Forms.TabPage tabLine;
        private System.Windows.Forms.TabPage tabPolygon;
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
        private System.Windows.Forms.Label lblLineStyle;
        private System.Windows.Forms.ComboBox cboLineStyle;
        private System.Windows.Forms.Label lblLineWidth;
        private System.Windows.Forms.NumericUpDown numLineWidth;
        private System.Windows.Forms.Label lblLineColor;
        private ColorButton btnLineColor;
        private System.Windows.Forms.Label lblFillStyle;
        private System.Windows.Forms.ComboBox cboFillStyle;
        private System.Windows.Forms.Label lblFillColor;
        private ColorButton btnFillColor;
        private System.Windows.Forms.Label lblOutlineColor;
        private ColorButton btnOutlineColor;
        private System.Windows.Forms.Label lblOutlineWidth;
        private System.Windows.Forms.NumericUpDown numOutlineWidth;
        private System.Windows.Forms.Label lblPreview;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}
