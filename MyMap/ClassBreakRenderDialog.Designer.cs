namespace MyMap
{
    partial class ClassBreakRenderDialog
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
            this.lblMethod = new System.Windows.Forms.Label();
            this.cboMethod = new System.Windows.Forms.ComboBox();
            this.lblClassCount = new System.Windows.Forms.Label();
            this.numClassCount = new System.Windows.Forms.NumericUpDown();
            this.lblRamp = new System.Windows.Forms.Label();
            this.cboRamp = new System.Windows.Forms.ComboBox();
            this.chkExcludeZero = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numClassCount)).BeginInit();
            this.SuspendLayout();
            //
            // lblField
            //
            this.lblField.AutoSize = true;
            this.lblField.Location = new System.Drawing.Point(15, 20);
            this.lblField.Name = "lblField";
            this.lblField.Size = new System.Drawing.Size(65, 12);
            this.lblField.TabIndex = 0;
            this.lblField.Text = "分级字段：";
            //
            // cboField
            //
            this.cboField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboField.Location = new System.Drawing.Point(110, 17);
            this.cboField.Name = "cboField";
            this.cboField.Size = new System.Drawing.Size(200, 20);
            this.cboField.TabIndex = 1;
            //
            // lblMethod
            //
            this.lblMethod.AutoSize = true;
            this.lblMethod.Location = new System.Drawing.Point(15, 56);
            this.lblMethod.Name = "lblMethod";
            this.lblMethod.Size = new System.Drawing.Size(65, 12);
            this.lblMethod.TabIndex = 2;
            this.lblMethod.Text = "分级方法：";
            //
            // cboMethod
            //
            this.cboMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMethod.Items.AddRange(new object[] {
            "等间距分级",
            "自然间断点分级",
            "分位数分级"});
            this.cboMethod.Location = new System.Drawing.Point(110, 53);
            this.cboMethod.Name = "cboMethod";
            this.cboMethod.Size = new System.Drawing.Size(200, 20);
            this.cboMethod.TabIndex = 3;
            //
            // lblClassCount
            //
            this.lblClassCount.AutoSize = true;
            this.lblClassCount.Location = new System.Drawing.Point(15, 92);
            this.lblClassCount.Name = "lblClassCount";
            this.lblClassCount.Size = new System.Drawing.Size(65, 12);
            this.lblClassCount.TabIndex = 4;
            this.lblClassCount.Text = "分级数量：";
            //
            // numClassCount
            //
            this.numClassCount.Location = new System.Drawing.Point(110, 89);
            this.numClassCount.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numClassCount.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numClassCount.Name = "numClassCount";
            this.numClassCount.Size = new System.Drawing.Size(70, 21);
            this.numClassCount.TabIndex = 5;
            this.numClassCount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            //
            // lblRamp
            //
            this.lblRamp.AutoSize = true;
            this.lblRamp.Location = new System.Drawing.Point(15, 128);
            this.lblRamp.Name = "lblRamp";
            this.lblRamp.Size = new System.Drawing.Size(65, 12);
            this.lblRamp.TabIndex = 6;
            this.lblRamp.Text = "色带类型：";
            //
            // cboRamp
            //
            this.cboRamp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRamp.Items.AddRange(new object[] {
            "随机色带",
            "渐变色带",
            "单色渐变"});
            this.cboRamp.Location = new System.Drawing.Point(110, 125);
            this.cboRamp.Name = "cboRamp";
            this.cboRamp.Size = new System.Drawing.Size(200, 20);
            this.cboRamp.TabIndex = 7;
            //
            // chkExcludeZero
            //
            this.chkExcludeZero.AutoSize = true;
            this.chkExcludeZero.Checked = true;
            this.chkExcludeZero.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExcludeZero.Location = new System.Drawing.Point(110, 160);
            this.chkExcludeZero.Name = "chkExcludeZero";
            this.chkExcludeZero.Size = new System.Drawing.Size(132, 16);
            this.chkExcludeZero.TabIndex = 8;
            this.chkExcludeZero.Text = "排除空值与 0 值";
            //
            // btnOk
            //
            this.btnOk.Location = new System.Drawing.Point(232, 200);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 28);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            //
            // btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(330, 200);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 28);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // ClassBreakRenderDialog
            //
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(430, 245);
            this.Controls.Add(this.lblField);
            this.Controls.Add(this.cboField);
            this.Controls.Add(this.lblMethod);
            this.Controls.Add(this.cboMethod);
            this.Controls.Add(this.lblClassCount);
            this.Controls.Add(this.numClassCount);
            this.Controls.Add(this.lblRamp);
            this.Controls.Add(this.cboRamp);
            this.Controls.Add(this.chkExcludeZero);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClassBreakRenderDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "分级渲染设置";
            ((System.ComponentModel.ISupportInitialize)(this.numClassCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblField;
        private System.Windows.Forms.ComboBox cboField;
        private System.Windows.Forms.Label lblMethod;
        private System.Windows.Forms.ComboBox cboMethod;
        private System.Windows.Forms.Label lblClassCount;
        private System.Windows.Forms.NumericUpDown numClassCount;
        private System.Windows.Forms.Label lblRamp;
        private System.Windows.Forms.ComboBox cboRamp;
        private System.Windows.Forms.CheckBox chkExcludeZero;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}
