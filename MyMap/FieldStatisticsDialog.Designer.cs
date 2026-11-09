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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblLayer = new System.Windows.Forms.Label();
            this.cboLayer = new System.Windows.Forms.ComboBox();
            this.lblField = new System.Windows.Forms.Label();
            this.cboField = new System.Windows.Forms.ComboBox();
            this.chkOnlySelected = new System.Windows.Forms.CheckBox();
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnStatistic = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.tlpMain.SuspendLayout();
            this.flpButtons.SuspendLayout();
            this.SuspendLayout();
            //
            // tlpMain
            //
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.lblLayer, 0, 0);
            this.tlpMain.Controls.Add(this.cboLayer, 1, 0);
            this.tlpMain.Controls.Add(this.lblField, 0, 1);
            this.tlpMain.Controls.Add(this.cboField, 1, 1);
            this.tlpMain.Controls.Add(this.chkOnlySelected, 1, 2);
            this.tlpMain.Controls.Add(this.flpButtons, 0, 3);
            this.tlpMain.Controls.Add(this.txtResult, 0, 4);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.Padding = new System.Windows.Forms.Padding(12, 14, 12, 10);
            this.tlpMain.RowCount = 5;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(375, 320);
            this.tlpMain.TabIndex = 0;
            //
            // lblLayer
            //
            this.lblLayer.AutoSize = true;
            this.lblLayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLayer.Location = new System.Drawing.Point(15, 17);
            this.lblLayer.Name = "lblLayer";
            this.lblLayer.Text = "统计图层：";
            this.lblLayer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cboLayer
            //
            this.cboLayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLayer.Location = new System.Drawing.Point(103, 14);
            this.cboLayer.Name = "cboLayer";
            this.cboLayer.SelectedIndexChanged += new System.EventHandler(this.cboLayer_SelectedIndexChanged);
            //
            // lblField
            //
            this.lblField.AutoSize = true;
            this.lblField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblField.Location = new System.Drawing.Point(15, 46);
            this.lblField.Name = "lblField";
            this.lblField.Text = "统计字段：";
            this.lblField.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cboField
            //
            this.cboField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboField.Location = new System.Drawing.Point(103, 43);
            this.cboField.Name = "cboField";
            //
            // chkOnlySelected
            //
            this.chkOnlySelected.AutoSize = true;
            this.chkOnlySelected.Location = new System.Drawing.Point(103, 70);
            this.chkOnlySelected.Name = "chkOnlySelected";
            this.chkOnlySelected.Text = "仅统计当前选中的要素";
            //
            // flpButtons
            //
            this.tlpMain.SetColumnSpan(this.flpButtons, 2);
            this.flpButtons.Controls.Add(this.btnStatistic);
            this.flpButtons.Controls.Add(this.btnClose);
            this.flpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpButtons.Location = new System.Drawing.Point(15, 95);
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.Size = new System.Drawing.Size(348, 34);
            //
            // btnStatistic
            //
            this.btnStatistic.Location = new System.Drawing.Point(3, 3);
            this.btnStatistic.Name = "btnStatistic";
            this.btnStatistic.Size = new System.Drawing.Size(100, 28);
            this.btnStatistic.TabIndex = 5;
            this.btnStatistic.Text = "统计";
            this.btnStatistic.UseVisualStyleBackColor = true;
            this.btnStatistic.Click += new System.EventHandler(this.btnStatistic_Click);
            //
            // btnClose
            //
            this.btnClose.Location = new System.Drawing.Point(109, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 28);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // txtResult
            //
            this.txtResult.BackColor = System.Drawing.Color.White;
            this.tlpMain.SetColumnSpan(this.txtResult, 2);
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResult.Location = new System.Drawing.Point(15, 135);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            //
            // FieldStatisticsDialog
            //
            this.AcceptButton = this.btnStatistic;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(375, 320);
            this.Controls.Add(this.tlpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FieldStatisticsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "字段统计";
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.flpButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label lblLayer;
        private System.Windows.Forms.ComboBox cboLayer;
        private System.Windows.Forms.Label lblField;
        private System.Windows.Forms.ComboBox cboField;
        private System.Windows.Forms.CheckBox chkOnlySelected;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;
        private System.Windows.Forms.Button btnStatistic;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtResult;
    }
}
