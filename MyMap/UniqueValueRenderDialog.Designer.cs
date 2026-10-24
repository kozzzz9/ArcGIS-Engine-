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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numColorCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRamp)).BeginInit();
            this.SuspendLayout();
            // 
            // lblField
            // 
            this.lblField.AutoSize = true;
            this.lblField.Location = new System.Drawing.Point(22, 30);
            this.lblField.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblField.Name = "lblField";
            this.lblField.Size = new System.Drawing.Size(116, 18);
            this.lblField.TabIndex = 0;
            this.lblField.Text = "唯一值字段：";
            // 
            // cboField
            // 
            this.cboField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboField.Location = new System.Drawing.Point(165, 26);
            this.cboField.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboField.Name = "cboField";
            this.cboField.Size = new System.Drawing.Size(298, 26);
            this.cboField.TabIndex = 1;
            this.cboField.SelectedIndexChanged += new System.EventHandler(this.cboField_SelectedIndexChanged);
            // 
            // lblRamp
            // 
            this.lblRamp.AutoSize = true;
            this.lblRamp.Location = new System.Drawing.Point(22, 87);
            this.lblRamp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRamp.Name = "lblRamp";
            this.lblRamp.Size = new System.Drawing.Size(98, 18);
            this.lblRamp.TabIndex = 2;
            this.lblRamp.Text = "色带类型：";
            // 
            // cboRamp
            // 
            this.cboRamp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRamp.Items.AddRange(new object[] {
            "随机色带",
            "渐变色带",
            "单色渐变"});
            this.cboRamp.Location = new System.Drawing.Point(165, 82);
            this.cboRamp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboRamp.Name = "cboRamp";
            this.cboRamp.Size = new System.Drawing.Size(298, 26);
            this.cboRamp.TabIndex = 3;
            this.cboRamp.SelectedIndexChanged += new System.EventHandler(this.colorSettingChanged);
            // 
            // lblColorCount
            // 
            this.lblColorCount.AutoSize = true;
            this.lblColorCount.Location = new System.Drawing.Point(22, 144);
            this.lblColorCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColorCount.Name = "lblColorCount";
            this.lblColorCount.Size = new System.Drawing.Size(98, 18);
            this.lblColorCount.TabIndex = 4;
            this.lblColorCount.Text = "颜色数量：";
            // 
            // numColorCount
            // 
            this.numColorCount.Location = new System.Drawing.Point(165, 140);
            this.numColorCount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.numColorCount.Size = new System.Drawing.Size(105, 28);
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
            this.chkAutoColorCount.Location = new System.Drawing.Point(292, 144);
            this.chkAutoColorCount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkAutoColorCount.Name = "chkAutoColorCount";
            this.chkAutoColorCount.Size = new System.Drawing.Size(178, 22);
            this.chkAutoColorCount.TabIndex = 6;
            this.chkAutoColorCount.Text = "数量与唯一值一致";
            this.chkAutoColorCount.CheckedChanged += new System.EventHandler(this.chkAutoColorCount_CheckedChanged);
            // 
            // picRamp
            // 
            this.picRamp.BackColor = System.Drawing.Color.White;
            this.picRamp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picRamp.Location = new System.Drawing.Point(480, 82);
            this.picRamp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picRamp.Name = "picRamp";
            this.picRamp.Size = new System.Drawing.Size(194, 89);
            this.picRamp.TabIndex = 7;
            this.picRamp.TabStop = false;
            this.picRamp.Paint += new System.Windows.Forms.PaintEventHandler(this.picRamp_Paint);
            // 
            // lblValues
            // 
            this.lblValues.AutoSize = true;
            this.lblValues.Location = new System.Drawing.Point(22, 210);
            this.lblValues.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValues.Name = "lblValues";
            this.lblValues.Size = new System.Drawing.Size(80, 18);
            this.lblValues.TabIndex = 8;
            this.lblValues.Text = "唯一值：";
            // 
            // lstValues
            // 
            this.lstValues.ItemHeight = 18;
            this.lstValues.Location = new System.Drawing.Point(165, 206);
            this.lstValues.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstValues.Name = "lstValues";
            this.lstValues.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstValues.Size = new System.Drawing.Size(508, 256);
            this.lstValues.TabIndex = 9;
            // 
            // chkUseDefault
            // 
            this.chkUseDefault.AutoSize = true;
            this.chkUseDefault.Checked = true;
            this.chkUseDefault.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseDefault.Location = new System.Drawing.Point(165, 488);
            this.chkUseDefault.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkUseDefault.Name = "chkUseDefault";
            this.chkUseDefault.Size = new System.Drawing.Size(232, 22);
            this.chkUseDefault.TabIndex = 10;
            this.chkUseDefault.Text = "使用默认符号渲染其它值";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(398, 532);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(128, 42);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(540, 532);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(128, 42);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // UniqueValueRenderDialog
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(705, 600);
            this.Controls.Add(this.lblField);
            this.Controls.Add(this.cboField);
            this.Controls.Add(this.lblRamp);
            this.Controls.Add(this.cboRamp);
            this.Controls.Add(this.lblColorCount);
            this.Controls.Add(this.numColorCount);
            this.Controls.Add(this.chkAutoColorCount);
            this.Controls.Add(this.picRamp);
            this.Controls.Add(this.lblValues);
            this.Controls.Add(this.lstValues);
            this.Controls.Add(this.chkUseDefault);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UniqueValueRenderDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "唯一值渲染设置";
            ((System.ComponentModel.ISupportInitialize)(this.numColorCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRamp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}
