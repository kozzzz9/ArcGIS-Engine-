namespace MyMap
{
    partial class BufferAnalysisDialog
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
            this.lblDistance = new System.Windows.Forms.Label();
            this.numDistance = new System.Windows.Forms.NumericUpDown();
            this.lblTip = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numDistance)).BeginInit();
            this.SuspendLayout();
            //
            // lblDistance
            //
            this.lblDistance.AutoSize = true;
            this.lblDistance.Location = new System.Drawing.Point(15, 25);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(65, 12);
            this.lblDistance.TabIndex = 0;
            this.lblDistance.Text = "缓冲距离：";
            //
            // numDistance
            //
            this.numDistance.DecimalPlaces = 2;
            this.numDistance.Location = new System.Drawing.Point(110, 22);
            this.numDistance.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numDistance.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numDistance.Name = "numDistance";
            this.numDistance.Size = new System.Drawing.Size(160, 21);
            this.numDistance.TabIndex = 1;
            this.numDistance.Value = new decimal(new int[] {
            100,
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
            this.lblTip.Size = new System.Drawing.Size(215, 12);
            this.lblTip.TabIndex = 2;
            this.lblTip.Text = "提示：距离单位为当前地图单位，对选中要素生成缓冲区。";
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
            // BufferAnalysisDialog
            //
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(430, 145);
            this.Controls.Add(this.lblDistance);
            this.Controls.Add(this.numDistance);
            this.Controls.Add(this.lblTip);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BufferAnalysisDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "缓冲区分析";
            ((System.ComponentModel.ISupportInitialize)(this.numDistance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDistance;
        private System.Windows.Forms.NumericUpDown numDistance;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}
