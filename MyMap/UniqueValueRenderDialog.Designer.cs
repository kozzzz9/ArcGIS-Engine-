namespace MyMap
{
    partial class UniqueValueRenderDialog
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
            this.lblField = new System.Windows.Forms.Label();
            this.cboField = new System.Windows.Forms.ComboBox();
            this.lblRamp = new System.Windows.Forms.Label();
            this.cboRamp = new System.Windows.Forms.ComboBox();
            this.lblColorCount = new System.Windows.Forms.Label();
            this.numColorCount = new System.Windows.Forms.NumericUpDown();
            this.chkAutoColorCount = new System.Windows.Forms.CheckBox();
            this.picRamp = new System.Windows.Forms.PictureBox();
            this.lblValues = new System.Windows.Forms.Label();
            this.lstValues = new System.Windows.Forms.ListBox();
            this.chkUseDefault = new System.Windows.Forms.CheckBox();
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numColorCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRamp)).BeginInit();
            this.flpButtons.SuspendLayout();
            this.SuspendLayout();
            //
            // tlpMain
            //
            this.tlpMain.ColumnCount = 3;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpMain.Controls.Add(this.lblField, 0, 0);
            this.tlpMain.Controls.Add(this.cboField, 1, 0);
            this.tlpMain.Controls.Add(this.picRamp, 2, 0);
            this.tlpMain.Controls.Add(this.lblRamp, 0, 1);
            this.tlpMain.Controls.Add(this.cboRamp, 1, 1);
            this.tlpMain.Controls.Add(this.lblColorCount, 0, 2);
            this.tlpMain.Controls.Add(this.numColorCount, 1, 2);
            this.tlpMain.Controls.Add(this.chkAutoColorCount, 1, 3);
            this.tlpMain.Controls.Add(this.lblValues, 0, 4);
            this.tlpMain.Controls.Add(this.lstValues, 1, 4);
            this.tlpMain.Controls.Add(this.chkUseDefault, 0, 5);
            this.tlpMain.Controls.Add(this.flpButtons, 0, 6);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.Padding = new System.Windows.Forms.Padding(12, 16, 12, 10);
            this.tlpMain.RowCount = 7;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpMain.Size = new System.Drawing.Size(470, 400);
            this.tlpMain.TabIndex = 0;
            this.tlpMain.SetRowSpan(this.picRamp, 4);
            //
            // lblField
            //
            this.lblField.AutoSize = true;
            this.lblField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblField.Location = new System.Drawing.Point(15, 19);
            this.lblField.Name = "lblField";
            this.lblField.Text = "唯一值字段：";
            this.lblField.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cboField
            //
            this.cboField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboField.Location = new System.Drawing.Point(103, 16);
            this.cboField.Name = "cboField";
            this.cboField.SelectedIndexChanged += new System.EventHandler(this.cboField_SelectedIndexChanged);
            //
            // picRamp
            //
            this.picRamp.BackColor = System.Drawing.Color.White;
            this.picRamp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picRamp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picRamp.Location = new System.Drawing.Point(318, 19);
            this.picRamp.Name = "picRamp";
            this.picRamp.TabStop = false;
            this.picRamp.Paint += new System.Windows.Forms.PaintEventHandler(this.picRamp_Paint);
            //
            // lblRamp
            //
            this.lblRamp.AutoSize = true;
            this.lblRamp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRamp.Location = new System.Drawing.Point(15, 48);
            this.lblRamp.Name = "lblRamp";
            this.lblRamp.Text = "色带类型：";
            this.lblRamp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cboRamp
            //
            this.cboRamp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboRamp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRamp.Items.AddRange(new object[] {
            "随机色带",
            "渐变色带",
            "单色渐变"});
            this.cboRamp.Location = new System.Drawing.Point(103, 45);
            this.cboRamp.Name = "cboRamp";
            this.cboRamp.SelectedIndex = 0;
            this.cboRamp.SelectedIndexChanged += new System.EventHandler(this.colorSettingChanged);
            //
            // lblColorCount
            //
            this.lblColorCount.AutoSize = true;
            this.lblColorCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblColorCount.Location = new System.Drawing.Point(15, 77);
            this.lblColorCount.Name = "lblColorCount";
            this.lblColorCount.Text = "颜色数量：";
            this.lblColorCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // numColorCount
            //
            this.numColorCount.Dock = System.Windows.Forms.DockStyle.Left;
            this.numColorCount.Location = new System.Drawing.Point(103, 74);
            this.numColorCount.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numColorCount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numColorCount.Name = "numColorCount";
            this.numColorCount.Size = new System.Drawing.Size(80, 21);
            this.numColorCount.TabIndex = 5;
            this.numColorCount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numColorCount.ValueChanged += new System.EventHandler(this.colorSettingChanged);
            //
            // chkAutoColorCount
            //
            this.chkAutoColorCount.AutoSize = true;
            this.chkAutoColorCount.Checked = true;
            this.chkAutoColorCount.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoColorCount.Location = new System.Drawing.Point(103, 101);
            this.chkAutoColorCount.Name = "chkAutoColorCount";
            this.chkAutoColorCount.Text = "颜色数量与唯一值数量一致";
            this.chkAutoColorCount.CheckedChanged += new System.EventHandler(this.chkAutoColorCount_CheckedChanged);
            //
            // lblValues
            //
            this.lblValues.AutoSize = true;
            this.lblValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblValues.Location = new System.Drawing.Point(15, 125);
            this.lblValues.Name = "lblValues";
            this.lblValues.Text = "唯一值：";
            this.lblValues.TextAlign = System.Drawing.ContentAlignment.TopRight;
            //
            // lstValues
            //
            this.tlpMain.SetColumnSpan(this.lstValues, 2);
            this.lstValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstValues.Location = new System.Drawing.Point(103, 122);
            this.lstValues.Name = "lstValues";
            this.lstValues.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            //
            // chkUseDefault
            //
            this.tlpMain.SetColumnSpan(this.chkUseDefault, 3);
            this.chkUseDefault.AutoSize = true;
            this.chkUseDefault.Checked = true;
            this.chkUseDefault.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseDefault.Location = new System.Drawing.Point(15, 337);
            this.chkUseDefault.Name = "chkUseDefault";
            this.chkUseDefault.Text = "使用默认符号渲染其它值";
            //
            // flpButtons
            //
            this.tlpMain.SetColumnSpan(this.flpButtons, 3);
            this.flpButtons.Controls.Add(this.btnCancel);
            this.flpButtons.Controls.Add(this.btnOk);
            this.flpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpButtons.Location = new System.Drawing.Point(15, 355);
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.Size = new System.Drawing.Size(443, 32);
            //
            // btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(355, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 26);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // btnOk
            //
            this.btnOk.Location = new System.Drawing.Point(264, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 26);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            //
            // UniqueValueRenderDialog
            //
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(470, 400);
            this.Controls.Add(this.tlpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UniqueValueRenderDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "唯一值渲染设置";
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numColorCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRamp)).EndInit();
            this.flpButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label lblField;
        private System.Windows.Forms.ComboBox cboField;
        private System.Windows.Forms.Label lblRamp;
        private System.Windows.Forms.ComboBox cboRamp;
        private System.Windows.Forms.Label lblColorCount;
        private System.Windows.Forms.NumericUpDown numColorCount;
        private System.Windows.Forms.CheckBox chkAutoColorCount;
        private System.Windows.Forms.PictureBox picRamp;
        private System.Windows.Forms.Label lblValues;
        private System.Windows.Forms.ListBox lstValues;
        private System.Windows.Forms.CheckBox chkUseDefault;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}
