namespace MyMap
{
    partial class CoordinateLocationDialog
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
            this.lblX = new System.Windows.Forms.Label();
            this.numX = new System.Windows.Forms.NumericUpDown();
            this.lblY = new System.Windows.Forms.Label();
            this.numY = new System.Windows.Forms.NumericUpDown();
            this.lblTip = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).BeginInit();
            this.SuspendLayout();
            //
            // lblX
            //
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(15, 25);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(29, 12);
            this.lblX.TabIndex = 0;
            this.lblX.Text = "X：";
            //
            // numX
            //
            this.numX.DecimalPlaces = 4;
            this.numX.Location = new System.Drawing.Point(110, 22);
            this.numX.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numX.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
            this.numX.Name = "numX";
            this.numX.Size = new System.Drawing.Size(220, 21);
            this.numX.TabIndex = 1;
            //
            // lblY
            //
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(15, 62);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(29, 12);
            this.lblY.TabIndex = 2;
            this.lblY.Text = "Y：";
            //
            // numY
            //
            this.numY.DecimalPlaces = 4;
            this.numY.Location = new System.Drawing.Point(110, 59);
            this.numY.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numY.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
            this.numY.Name = "numY";
            this.numY.Size = new System.Drawing.Size(220, 21);
            this.numY.TabIndex = 3;
            //
            // lblTip
            //
            this.lblTip.AutoSize = true;
            this.lblTip.ForeColor = System.Drawing.Color.Gray;
            this.lblTip.Location = new System.Drawing.Point(15, 95);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(197, 12);
            this.lblTip.TabIndex = 4;
            this.lblTip.Text = "提示：坐标为当前地图坐标系下的坐标。";
            //
            // btnOk
            //
            this.btnOk.Location = new System.Drawing.Point(232, 130);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 28);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "定位";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            //
            // btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(330, 130);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 28);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // CoordinateLocationDialog
            //
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(430, 175);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.numX);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.numY);
            this.Controls.Add(this.lblTip);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CoordinateLocationDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "坐标定位";
            ((System.ComponentModel.ISupportInitialize)(this.numX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.NumericUpDown numX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.NumericUpDown numY;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}
