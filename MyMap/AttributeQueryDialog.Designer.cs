namespace MyMap
{
    partial class AttributeQueryDialog
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
            this.lblWhere = new System.Windows.Forms.Label();
            this.txtWhere = new System.Windows.Forms.TextBox();
            this.lblTip = new System.Windows.Forms.Label();
            this.lblValues = new System.Windows.Forms.Label();
            this.lstValues = new System.Windows.Forms.ListBox();
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
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
            this.tlpMain.Controls.Add(this.lblWhere, 0, 2);
            this.tlpMain.Controls.Add(this.txtWhere, 1, 2);
            this.tlpMain.Controls.Add(this.lblTip, 0, 3);
            this.tlpMain.Controls.Add(this.lblValues, 0, 4);
            this.tlpMain.Controls.Add(this.lstValues, 1, 4);
            this.tlpMain.Controls.Add(this.flpButtons, 0, 5);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.Padding = new System.Windows.Forms.Padding(12, 16, 12, 10);
            this.tlpMain.RowCount = 6;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpMain.Size = new System.Drawing.Size(470, 345);
            this.tlpMain.TabIndex = 0;
            //
            // lblLayer
            //
            this.lblLayer.AutoSize = true;
            this.lblLayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLayer.Location = new System.Drawing.Point(15, 19);
            this.lblLayer.Name = "lblLayer";
            this.lblLayer.Text = "查询图层：";
            this.lblLayer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cboLayer
            //
            this.cboLayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLayer.Location = new System.Drawing.Point(103, 16);
            this.cboLayer.Name = "cboLayer";
            this.cboLayer.SelectedIndexChanged += new System.EventHandler(this.cboLayer_SelectedIndexChanged);
            //
            // lblField
            //
            this.lblField.AutoSize = true;
            this.lblField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblField.Location = new System.Drawing.Point(15, 48);
            this.lblField.Name = "lblField";
            this.lblField.Text = "查询字段：";
            this.lblField.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cboField
            //
            this.cboField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboField.Location = new System.Drawing.Point(103, 45);
            this.cboField.Name = "cboField";
            this.cboField.SelectedIndexChanged += new System.EventHandler(this.cboField_SelectedIndexChanged);
            //
            // lblWhere
            //
            this.lblWhere.AutoSize = true;
            this.lblWhere.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWhere.Location = new System.Drawing.Point(15, 77);
            this.lblWhere.Name = "lblWhere";
            this.lblWhere.Text = "查询条件：";
            this.lblWhere.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // txtWhere
            //
            this.txtWhere.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtWhere.Location = new System.Drawing.Point(103, 74);
            this.txtWhere.Name = "txtWhere";
            //
            // lblTip
            //
            this.lblTip.AutoSize = true;
            this.lblTip.ForeColor = System.Drawing.Color.Gray;
            this.tlpMain.SetColumnSpan(this.lblTip, 2);
            this.lblTip.Location = new System.Drawing.Point(15, 105);
            this.lblTip.Name = "lblTip";
            this.lblTip.Text = "提示：双击下方字段值可插入条件，也可直接输入标准 SQL 表达式。";
            //
            // lblValues
            //
            this.lblValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblValues.Location = new System.Drawing.Point(15, 122);
            this.lblValues.Name = "lblValues";
            this.lblValues.Text = "字段值：";
            this.lblValues.TextAlign = System.Drawing.ContentAlignment.TopRight;
            //
            // lstValues
            //
            this.lstValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstValues.ItemHeight = 12;
            this.lstValues.Location = new System.Drawing.Point(103, 119);
            this.lstValues.Name = "lstValues";
            this.lstValues.DoubleClick += new System.EventHandler(this.lstValues_DoubleClick);
            //
            // flpButtons
            //
            this.tlpMain.SetColumnSpan(this.flpButtons, 2);
            this.flpButtons.Controls.Add(this.btnCancel);
            this.flpButtons.Controls.Add(this.btnOk);
            this.flpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpButtons.Location = new System.Drawing.Point(15, 300);
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.Size = new System.Drawing.Size(443, 32);
            //
            // btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(355, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 26);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // btnOk
            //
            this.btnOk.Location = new System.Drawing.Point(264, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 26);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "查询";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            //
            // AttributeQueryDialog
            //
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(470, 345);
            this.Controls.Add(this.tlpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AttributeQueryDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "属性查询";
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
        private System.Windows.Forms.Label lblWhere;
        private System.Windows.Forms.TextBox txtWhere;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.Label lblValues;
        private System.Windows.Forms.ListBox lstValues;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}
