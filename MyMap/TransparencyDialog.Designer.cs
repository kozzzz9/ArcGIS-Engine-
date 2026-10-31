namespace MyMap
{
    partial class TransparencyDialog
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
            this.lblTransparency = new System.Windows.Forms.Label();
            this.numTransparency = new System.Windows.Forms.NumericUpDown();
            this.lblTip = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numTransparency)).BeginInit();
            this.SuspendLayout();
            //
            // lblTransparency
            //
            this.lblTransparency.AutoSize = true;
            this.lblTransparency.Location = new System.Drawing.Point(15, 25);
            this.lblTransparency.Name = "lblTransparency";
            this.lblTransparency.Size = new System.Drawing.Size(89, 12);
            this.lblTransparency.TabIndex = 0;
            this.lblTransparency.Text = "图层透明度：";
            //
            // numTransparency
            //
            this.numTransparency.Location = new System.Drawing.Point(110, 22);
            this.numTransparency.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numTransparency.Name = "numTransparency";
            this.numTransparency.Size = new System.Drawing.Size(100, 21);
            this.numTransparency.TabIndex = 1;
            this.numTransparency.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            //
            // lblTip
            //
            this.lblTip.AutoSize = true;
            this.lblTip.ForeColor = System.Drawing.Color.Gray;
            this.lblTip.Location = new System.Drawing.Point(15, 60);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(233, 12);
            this.lblTip.TabIndex = 2;
            this.lblTip.Text = "提示：0 表示完全不透明，100 表示完全透明。";
            //
            // btnOk
            //
            this.btnOk.Location = new System.Drawing.Point(232, 100);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 28);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            //
            // btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(330, 100);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 28);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // TransparencyDialog
            //
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(430, 145);
            this.Controls.Add(this.lblTransparency);
            this.Controls.Add(this.numTransparency);
            this.Controls.Add(this.lblTip);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TransparencyDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "图层透明度";
            ((System.ComponentModel.ISupportInitialize)(this.numTransparency)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTransparency;
        private System.Windows.Forms.NumericUpDown numTransparency;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}
