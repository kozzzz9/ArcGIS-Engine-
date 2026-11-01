namespace MyMap
{
    partial class TextAnnotationDialog
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
            this.lblText = new System.Windows.Forms.Label();
            this.txtText = new System.Windows.Forms.TextBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.numSize = new System.Windows.Forms.NumericUpDown();
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numSize)).BeginInit();
            this.tlpMain.SuspendLayout();
            this.flpButtons.SuspendLayout();
            this.SuspendLayout();
            //
            // tlpMain
            //
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.lblText, 0, 0);
            this.tlpMain.Controls.Add(this.txtText, 1, 0);
            this.tlpMain.Controls.Add(this.lblSize, 0, 1);
            this.tlpMain.Controls.Add(this.numSize, 1, 1);
            this.tlpMain.Controls.Add(this.flpButtons, 0, 3);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.Padding = new System.Windows.Forms.Padding(12, 16, 12, 10);
            this.tlpMain.RowCount = 4;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpMain.Size = new System.Drawing.Size(400, 150);
            this.tlpMain.TabIndex = 0;
            //
            // lblText
            //
            this.lblText.AutoSize = true;
            this.lblText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblText.Location = new System.Drawing.Point(15, 19);
            this.lblText.Name = "lblText";
            this.lblText.Text = "标注文字：";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // txtText
            //
            this.txtText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtText.Location = new System.Drawing.Point(103, 16);
            this.txtText.Name = "txtText";
            //
            // lblSize
            //
            this.lblSize.AutoSize = true;
            this.lblSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSize.Location = new System.Drawing.Point(15, 48);
            this.lblSize.Name = "lblSize";
            this.lblSize.Text = "文字大小：";
            this.lblSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // numSize
            //
            this.numSize.Dock = System.Windows.Forms.DockStyle.Left;
            this.numSize.Location = new System.Drawing.Point(103, 45);
            this.numSize.Maximum = new decimal(new int[] {
            72,
            0,
            0,
            0});
            this.numSize.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numSize.Name = "numSize";
            this.numSize.Size = new System.Drawing.Size(80, 21);
            this.numSize.TabIndex = 3;
            this.numSize.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
            //
            // flpButtons
            //
            this.tlpMain.SetColumnSpan(this.flpButtons, 2);
            this.flpButtons.Controls.Add(this.btnCancel);
            this.flpButtons.Controls.Add(this.btnOk);
            this.flpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpButtons.Location = new System.Drawing.Point(15, 68);
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.Size = new System.Drawing.Size(370, 32);
            //
            // btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(282, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 26);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // btnOk
            //
            this.btnOk.Location = new System.Drawing.Point(191, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 26);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            //
            // TextAnnotationDialog
            //
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(400, 150);
            this.Controls.Add(this.tlpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TextAnnotationDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加文字标注";
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSize)).EndInit();
            this.flpButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.NumericUpDown numSize;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}
