namespace MyMap
{
    partial class FieldStatisticsDialog
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
            this.lblLayer = new System.Windows.Forms.Label();
            this.cboLayer = new System.Windows.Forms.ComboBox();
            this.lblField = new System.Windows.Forms.Label();
            this.cboField = new System.Windows.Forms.ComboBox();
            this.chkOnlySelected = new System.Windows.Forms.CheckBox();
            this.btnStatistic = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblLayer
            //
            this.lblLayer.AutoSize = true;
            this.lblLayer.Location = new System.Drawing.Point(15, 20);
            this.lblLayer.Name = "lblLayer";
            this.lblLayer.Size = new System.Drawing.Size(65, 12);
            this.lblLayer.TabIndex = 0;
            this.lblLayer.Text = "统计图层：";
            //
            // cboLayer
            //
            this.cboLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLayer.Location = new System.Drawing.Point(110, 17);
            this.cboLayer.Name = "cboLayer";
            this.cboLayer.Size = new System.Drawing.Size(250, 20);
            this.cboLayer.TabIndex = 1;
            this.cboLayer.SelectedIndexChanged += new System.EventHandler(this.cboLayer_SelectedIndexChanged);
            //
            // lblField
            //
            this.lblField.AutoSize = true;
            this.lblField.Location = new System.Drawing.Point(15, 56);
            this.lblField.Name = "lblField";
            this.lblField.Size = new System.Drawing.Size(65, 12);
            this.lblField.TabIndex = 2;
            this.lblField.Text = "统计字段：";
            //
            // cboField
            //
            this.cboField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboField.Location = new System.Drawing.Point(110, 53);
            this.cboField.Name = "cboField";
            this.cboField.Size = new System.Drawing.Size(250, 20);
            this.cboField.TabIndex = 3;
            //
            // chkOnlySelected
            //
            this.chkOnlySelected.AutoSize = true;
            this.chkOnlySelected.Location = new System.Drawing.Point(110, 88);
            this.chkOnlySelected.Name = "chkOnlySelected";
            this.chkOnlySelected.Size = new System.Drawing.Size(156, 16);
            this.chkOnlySelected.TabIndex = 4;
            this.chkOnlySelected.Text = "仅统计当前选中的要素";
            //
            // btnStatistic
            //
            this.btnStatistic.Location = new System.Drawing.Point(110, 118);
            this.btnStatistic.Name = "btnStatistic";
            this.btnStatistic.Size = new System.Drawing.Size(100, 28);
            this.btnStatistic.TabIndex = 5;
            this.btnStatistic.Text = "统计";
            this.btnStatistic.UseVisualStyleBackColor = true;
            this.btnStatistic.Click += new System.EventHandler(this.btnStatistic_Click);
            //
            // txtResult
            //
            this.txtResult.BackColor = System.Drawing.Color.White;
            this.txtResult.Location = new System.Drawing.Point(15, 158);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(345, 150);
            this.txtResult.TabIndex = 6;
            //
            // btnClose
            //
            this.btnClose.Location = new System.Drawing.Point(275, 118);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 28);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // FieldStatisticsDialog
            //
            this.AcceptButton = this.btnStatistic;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(375, 320);
            this.Controls.Add(this.lblLayer);
            this.Controls.Add(this.cboLayer);
            this.Controls.Add(this.lblField);
            this.Controls.Add(this.cboField);
            this.Controls.Add(this.chkOnlySelected);
            this.Controls.Add(this.btnStatistic);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FieldStatisticsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "字段统计";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLayer;
        private System.Windows.Forms.ComboBox cboLayer;
        private System.Windows.Forms.Label lblField;
        private System.Windows.Forms.ComboBox cboField;
        private System.Windows.Forms.CheckBox chkOnlySelected;
        private System.Windows.Forms.Button btnStatistic;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnClose;
    }
}
