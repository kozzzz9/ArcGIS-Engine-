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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblField = new System.Windows.Forms.Label();
            this.cboField = new System.Windows.Forms.ComboBox();
            this.lblMethod = new System.Windows.Forms.Label();
            this.cboMethod = new System.Windows.Forms.ComboBox();
            this.lblClassCount = new System.Windows.Forms.Label();
            this.numClassCount = new System.Windows.Forms.NumericUpDown();
            this.lblRamp = new System.Windows.Forms.Label();
            this.cboRamp = new System.Windows.Forms.ComboBox();
            this.chkExcludeZero = new System.Windows.Forms.CheckBox();
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numClassCount)).BeginInit();
            this.tlpMain.SuspendLayout();
            this.flpButtons.SuspendLayout();
            this.SuspendLayout();
            //
            // tlpMain
            //
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.lblField, 0, 0);
            this.tlpMain.Controls.Add(this.cboField, 1, 0);
            this.tlpMain.Controls.Add(this.lblMethod, 0, 1);
            this.tlpMain.Controls.Add(this.cboMethod, 1, 1);
            this.tlpMain.Controls.Add(this.lblClassCount, 0, 2);
            this.tlpMain.Controls.Add(this.numClassCount, 1, 2);
            this.tlpMain.Controls.Add(this.lblRamp, 0, 3);
            this.tlpMain.Controls.Add(this.cboRamp, 1, 3);
            this.tlpMain.Controls.Add(this.chkExcludeZero, 1, 4);
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
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpMain.Size = new System.Drawing.Size(430, 245);
            this.tlpMain.TabIndex = 0;
            //
            // lblField
            //
            this.lblField.AutoSize = true;
            this.lblField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblField.Location = new System.Drawing.Point(15, 19);
            this.lblField.Name = "lblField";
            this.lblField.Text = "分级字段：";
            this.lblField.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cboField
            //
            this.cboField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboField.Location = new System.Drawing.Point(103, 16);
            this.cboField.Margin = new System.Windows.Forms.Padding(3, 3, 60, 3);
            this.cboField.Name = "cboField";
            //
            // lblMethod
            //
            this.lblMethod.AutoSize = true;
            this.lblMethod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMethod.Location = new System.Drawing.Point(15, 48);
            this.lblMethod.Name = "lblMethod";
            this.lblMethod.Text = "分级方法：";
            this.lblMethod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cboMethod
            //
            this.cboMethod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMethod.Items.AddRange(new object[] {
            "等间距分级",
            "自然间断点分级",
            "分位数分级"});
            this.cboMethod.Location = new System.Drawing.Point(103, 45);
            this.cboMethod.Margin = new System.Windows.Forms.Padding(3, 3, 60, 3);
            this.cboMethod.Name = "cboMethod";
            //
            // lblClassCount
            //
            this.lblClassCount.AutoSize = true;
            this.lblClassCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblClassCount.Location = new System.Drawing.Point(15, 77);
            this.lblClassCount.Name = "lblClassCount";
            this.lblClassCount.Text = "分级数量：";
            this.lblClassCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // numClassCount
            //
            this.numClassCount.Dock = System.Windows.Forms.DockStyle.Left;
            this.numClassCount.Location = new System.Drawing.Point(103, 74);
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
            this.numClassCount.Size = new System.Drawing.Size(80, 21);
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
            this.lblRamp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRamp.Location = new System.Drawing.Point(15, 106);
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
            this.cboRamp.Location = new System.Drawing.Point(103, 103);
            this.cboRamp.Margin = new System.Windows.Forms.Padding(3, 3, 60, 3);
            this.cboRamp.Name = "cboRamp";
            //
            // chkExcludeZero
            //
            this.chkExcludeZero.AutoSize = true;
            this.chkExcludeZero.Checked = true;
            this.chkExcludeZero.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExcludeZero.Location = new System.Drawing.Point(103, 132);
            this.chkExcludeZero.Name = "chkExcludeZero";
            this.chkExcludeZero.Text = "排除空值与 0 值";
            //
            // flpButtons
            //
            this.tlpMain.SetColumnSpan(this.flpButtons, 2);
            this.flpButtons.Controls.Add(this.btnCancel);
            this.flpButtons.Controls.Add(this.btnOk);
            this.flpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpButtons.Location = new System.Drawing.Point(15, 161);
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.Size = new System.Drawing.Size(400, 32);
            //
            // btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(312, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 26);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // btnOk
            //
            this.btnOk.Location = new System.Drawing.Point(221, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 26);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            //
            // ClassBreakRenderDialog
            //
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(430, 245);
            this.Controls.Add(this.tlpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClassBreakRenderDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "分级渲染设置";
            ((System.ComponentModel.ISupportInitialize)(this.numClassCount)).EndInit();
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.flpButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label lblField;
        private System.Windows.Forms.ComboBox cboField;
        private System.Windows.Forms.Label lblMethod;
        private System.Windows.Forms.ComboBox cboMethod;
        private System.Windows.Forms.Label lblClassCount;
        private System.Windows.Forms.NumericUpDown numClassCount;
        private System.Windows.Forms.Label lblRamp;
        private System.Windows.Forms.ComboBox cboRamp;
        private System.Windows.Forms.CheckBox chkExcludeZero;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}
