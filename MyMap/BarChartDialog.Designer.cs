using MyMapControls;

namespace MyMap
{
    partial class BarChartDialog
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
            this.lblFields = new System.Windows.Forms.Label();
            this.dgvFields = new System.Windows.Forms.DataGridView();
            this.colInclude = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colFieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColor = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lblWidth = new System.Windows.Forms.Label();
            this.numWidth = new System.Windows.Forms.NumericUpDown();
            this.numOutlineWidth = new System.Windows.Forms.NumericUpDown();
            this.lblOutlineWidth = new System.Windows.Forms.Label();
            this.lblSpacing = new System.Windows.Forms.Label();
            this.numSpacing = new System.Windows.Forms.NumericUpDown();
            this.chkClockwise = new System.Windows.Forms.CheckBox();
            this.lblClockwise = new System.Windows.Forms.Label();
            this.chkFixedStacked = new System.Windows.Forms.CheckBox();
            this.picChartPreview = new System.Windows.Forms.PictureBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.numSize = new System.Windows.Forms.NumericUpDown();
            this.lblBgColor = new System.Windows.Forms.Label();
            this.btnBgColor = new MyMapControls.ColorPickerButton();
            this.chkVerticalBars = new System.Windows.Forms.CheckBox();
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOutlineWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpacing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChartPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSize)).BeginInit();
            this.flpButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 4;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.lblFields, 0, 0);
            this.tlpMain.Controls.Add(this.dgvFields, 0, 1);
            this.tlpMain.Controls.Add(this.lblWidth, 0, 2);
            this.tlpMain.Controls.Add(this.numWidth, 1, 2);
            this.tlpMain.Controls.Add(this.numOutlineWidth, 1, 2);
            this.tlpMain.Controls.Add(this.lblOutlineWidth, 0, 2);
            this.tlpMain.Controls.Add(this.lblSpacing, 0, 3);
            this.tlpMain.Controls.Add(this.numSpacing, 1, 3);
            this.tlpMain.Controls.Add(this.chkClockwise, 1, 3);
            this.tlpMain.Controls.Add(this.lblClockwise, 0, 3);
            this.tlpMain.Controls.Add(this.chkFixedStacked, 2, 3);
            this.tlpMain.Controls.Add(this.picChartPreview, 3, 2);
            this.tlpMain.Controls.Add(this.lblSize, 0, 4);
            this.tlpMain.Controls.Add(this.numSize, 1, 4);
            this.tlpMain.Controls.Add(this.lblBgColor, 0, 5);
            this.tlpMain.Controls.Add(this.btnBgColor, 1, 5);
            this.tlpMain.Controls.Add(this.chkVerticalBars, 2, 5);
            this.tlpMain.Controls.Add(this.flpButtons, 0, 6);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(4);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.Padding = new System.Windows.Forms.Padding(18, 21, 18, 15);
            this.tlpMain.RowCount = 7;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(800, 700);
            this.tlpMain.TabIndex = 0;
            // 
            // lblFields
            // 
            this.lblFields.AutoSize = true;
            this.tlpMain.SetColumnSpan(this.lblFields, 4);
            this.lblFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFields.Location = new System.Drawing.Point(22, 21);
            this.lblFields.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFields.Name = "lblFields";
            this.lblFields.Size = new System.Drawing.Size(756, 18);
            this.lblFields.TabIndex = 0;
            this.lblFields.Text = "参与统计的数值字段（勾选，点击色块改颜色）：";
            // 
            // dgvFields
            // 
            this.dgvFields.AllowUserToAddRows = false;
            this.dgvFields.AllowUserToDeleteRows = false;
            this.dgvFields.AllowUserToResizeRows = false;
            this.dgvFields.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFields.ColumnHeadersHeight = 34;
            this.dgvFields.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colInclude,
            this.colFieldName,
            this.colColor});
            this.tlpMain.SetColumnSpan(this.dgvFields, 4);
            this.dgvFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFields.Location = new System.Drawing.Point(22, 43);
            this.dgvFields.Margin = new System.Windows.Forms.Padding(4);
            this.dgvFields.Name = "dgvFields";
            this.dgvFields.RowHeadersVisible = false;
            this.dgvFields.RowHeadersWidth = 62;
            this.dgvFields.Size = new System.Drawing.Size(756, 428);
            this.dgvFields.TabIndex = 3;
            // 
            // colInclude
            // 
            this.colInclude.HeaderText = "参与";
            this.colInclude.MinimumWidth = 8;
            this.colInclude.Name = "colInclude";
            // 
            // colFieldName
            // 
            this.colFieldName.HeaderText = "字段名";
            this.colFieldName.MinimumWidth = 8;
            this.colFieldName.Name = "colFieldName";
            this.colFieldName.ReadOnly = true;
            // 
            // colColor
            // 
            this.colColor.HeaderText = "颜色";
            this.colColor.MinimumWidth = 8;
            this.colColor.Name = "colColor";
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(260, 475);
            this.lblWidth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(80, 18);
            this.lblWidth.TabIndex = 4;
            this.lblWidth.Text = "柱宽度：";
            this.lblWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numWidth
            // 
            this.numWidth.Location = new System.Drawing.Point(546, 479);
            this.numWidth.Margin = new System.Windows.Forms.Padding(4);
            this.numWidth.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numWidth.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numWidth.Name = "numWidth";
            this.numWidth.Size = new System.Drawing.Size(135, 28);
            this.numWidth.TabIndex = 3;
            this.numWidth.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // numOutlineWidth
            // 
            this.numOutlineWidth.DecimalPlaces = 2;
            this.numOutlineWidth.Location = new System.Drawing.Point(403, 479);
            this.numOutlineWidth.Margin = new System.Windows.Forms.Padding(4);
            this.numOutlineWidth.Name = "numOutlineWidth";
            this.numOutlineWidth.Size = new System.Drawing.Size(135, 28);
            this.numOutlineWidth.TabIndex = 4;
            this.numOutlineWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numOutlineWidth.Visible = false;
            // 
            // lblOutlineWidth
            // 
            this.lblOutlineWidth.AutoSize = true;
            this.lblOutlineWidth.Location = new System.Drawing.Point(22, 475);
            this.lblOutlineWidth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOutlineWidth.Name = "lblOutlineWidth";
            this.lblOutlineWidth.Size = new System.Drawing.Size(98, 18);
            this.lblOutlineWidth.TabIndex = 5;
            this.lblOutlineWidth.Text = "扇区描边：";
            this.lblOutlineWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblOutlineWidth.Visible = false;
            // 
            // lblSpacing
            // 
            this.lblSpacing.AutoSize = true;
            this.lblSpacing.Location = new System.Drawing.Point(403, 511);
            this.lblSpacing.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSpacing.Name = "lblSpacing";
            this.lblSpacing.Size = new System.Drawing.Size(80, 18);
            this.lblSpacing.TabIndex = 6;
            this.lblSpacing.Text = "柱间距：";
            this.lblSpacing.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numSpacing
            // 
            this.numSpacing.Location = new System.Drawing.Point(546, 515);
            this.numSpacing.Margin = new System.Windows.Forms.Padding(4);
            this.numSpacing.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numSpacing.Name = "numSpacing";
            this.numSpacing.Size = new System.Drawing.Size(135, 28);
            this.numSpacing.TabIndex = 5;
            this.numSpacing.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // chkClockwise
            // 
            this.chkClockwise.AutoSize = true;
            this.chkClockwise.Checked = true;
            this.chkClockwise.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClockwise.Location = new System.Drawing.Point(260, 551);
            this.chkClockwise.Margin = new System.Windows.Forms.Padding(4);
            this.chkClockwise.Name = "chkClockwise";
            this.chkClockwise.Size = new System.Drawing.Size(124, 22);
            this.chkClockwise.TabIndex = 6;
            this.chkClockwise.Text = "顺时针方向";
            this.chkClockwise.Visible = false;
            // 
            // lblClockwise
            // 
            this.lblClockwise.AutoSize = true;
            this.lblClockwise.Location = new System.Drawing.Point(260, 511);
            this.lblClockwise.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClockwise.Name = "lblClockwise";
            this.lblClockwise.Size = new System.Drawing.Size(98, 18);
            this.lblClockwise.TabIndex = 7;
            this.lblClockwise.Text = "扇形方向：";
            this.lblClockwise.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblClockwise.Visible = false;
            // 
            // chkFixedStacked
            // 
            this.chkFixedStacked.AutoSize = true;
            this.chkFixedStacked.Location = new System.Drawing.Point(403, 551);
            this.chkFixedStacked.Margin = new System.Windows.Forms.Padding(4);
            this.chkFixedStacked.Name = "chkFixedStacked";
            this.chkFixedStacked.Size = new System.Drawing.Size(124, 22);
            this.chkFixedStacked.TabIndex = 8;
            this.chkFixedStacked.Text = "百分比堆叠";
            // 
            // picChartPreview
            // 
            this.picChartPreview.BackColor = System.Drawing.Color.White;
            this.picChartPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picChartPreview.Location = new System.Drawing.Point(22, 515);
            this.picChartPreview.Margin = new System.Windows.Forms.Padding(4);
            this.picChartPreview.Name = "picChartPreview";
            this.tlpMain.SetRowSpan(this.picChartPreview, 4);
            this.picChartPreview.Size = new System.Drawing.Size(230, 143);
            this.picChartPreview.TabIndex = 10;
            this.picChartPreview.TabStop = false;
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(546, 547);
            this.lblSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(134, 18);
            this.lblSize.TabIndex = 11;
            this.lblSize.Text = "图表最大高度：";
            this.lblSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numSize
            // 
            this.numSize.Location = new System.Drawing.Point(260, 581);
            this.numSize.Margin = new System.Windows.Forms.Padding(4);
            this.numSize.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numSize.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numSize.Name = "numSize";
            this.numSize.Size = new System.Drawing.Size(135, 28);
            this.numSize.TabIndex = 7;
            this.numSize.Value = new decimal(new int[] {
            28,
            0,
            0,
            0});
            // 
            // lblBgColor
            // 
            this.lblBgColor.AutoSize = true;
            this.lblBgColor.Location = new System.Drawing.Point(403, 577);
            this.lblBgColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBgColor.Name = "lblBgColor";
            this.lblBgColor.Size = new System.Drawing.Size(116, 18);
            this.lblBgColor.TabIndex = 12;
            this.lblBgColor.Text = "图表背景色：";
            this.lblBgColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBgColor
            // 
            this.btnBgColor.BackColor = System.Drawing.Color.Red;
            this.btnBgColor.Color = System.Drawing.Color.Red;
            this.btnBgColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBgColor.Location = new System.Drawing.Point(546, 581);
            this.btnBgColor.Margin = new System.Windows.Forms.Padding(4);
            this.btnBgColor.Name = "btnBgColor";
            this.btnBgColor.Size = new System.Drawing.Size(135, 36);
            this.btnBgColor.TabIndex = 9;
            this.btnBgColor.UseVisualStyleBackColor = false;
            // 
            // chkVerticalBars
            // 
            this.chkVerticalBars.AutoSize = true;
            this.chkVerticalBars.Checked = true;
            this.chkVerticalBars.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVerticalBars.Location = new System.Drawing.Point(260, 625);
            this.chkVerticalBars.Margin = new System.Windows.Forms.Padding(4);
            this.chkVerticalBars.Name = "chkVerticalBars";
            this.chkVerticalBars.Size = new System.Drawing.Size(106, 22);
            this.chkVerticalBars.TabIndex = 13;
            this.chkVerticalBars.Text = "垂直柱状";
            // 
            // flpButtons
            // 
            this.tlpMain.SetColumnSpan(this.flpButtons, 4);
            this.flpButtons.Controls.Add(this.btnCancel);
            this.flpButtons.Controls.Add(this.btnOk);
            this.flpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpButtons.Location = new System.Drawing.Point(22, 669);
            this.flpButtons.Margin = new System.Windows.Forms.Padding(4);
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.Size = new System.Drawing.Size(756, 12);
            this.flpButtons.TabIndex = 14;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(624, 4);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(128, 39);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(488, 4);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(128, 39);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // BarChartDialog
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(800, 700);
            this.Controls.Add(this.tlpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BarChartDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "柱状统计专题图";
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFields)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOutlineWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpacing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChartPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSize)).EndInit();
            this.flpButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label lblFields;
        private System.Windows.Forms.DataGridView dgvFields;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colInclude;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFieldName;
        private System.Windows.Forms.DataGridViewButtonColumn colColor;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.NumericUpDown numWidth;
        private System.Windows.Forms.Label lblSpacing;
        private System.Windows.Forms.NumericUpDown numSpacing;
        private System.Windows.Forms.NumericUpDown numOutlineWidth;
        private System.Windows.Forms.Label lblOutlineWidth;
        private System.Windows.Forms.CheckBox chkClockwise;
        private System.Windows.Forms.Label lblClockwise;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.NumericUpDown numSize;
        private System.Windows.Forms.Label lblBgColor;
        private System.Windows.Forms.CheckBox chkVerticalBars;
        private System.Windows.Forms.CheckBox chkFixedStacked;
        private System.Windows.Forms.PictureBox picChartPreview;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private ColorPickerButton btnBgColor;
    }
}
