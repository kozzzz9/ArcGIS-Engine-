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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblDistance = new System.Windows.Forms.Label();
            this.numDistance = new System.Windows.Forms.NumericUpDown();
            this.lblTip = new System.Windows.Forms.Label();
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numDistance)).BeginInit();
            this.tlpMain.SuspendLayout();
            this.flpButtons.SuspendLayout();
            this.SuspendLayout();
            //
            // tlpMain
            //
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.lblDistance, 0, 0);
            this.tlpMain.Controls.Add(this.numDistance, 1, 0);
            this.tlpMain.Controls.Add(this.lblTip, 0, 1);
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
            this.tlpMain.Size = new System.Drawing.Size(430, 145);
            this.tlpMain.TabIndex = 0;
            //
            // lblDistance
            //
            this.lblDistance.AutoSize = true;
            this.lblDistance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDistance.Location = new System.Drawing.Point(15, 19);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Text = "缓冲距离：";
            this.lblDistance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // numDistance
            //
            this.numDistance.DecimalPlaces = 2;
            this.numDistance.Dock = System.Windows.Forms.DockStyle.Left;
            this.numDistance.Location = new System.Drawing.Point(103, 16);
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
            this.tlpMain.SetColumnSpan(this.lblTip, 2);
            this.lblTip.Location = new System.Drawing.Point(15, 46);
            this.lblTip.Name = "lblTip";
            this.lblTip.Text = "提示：距离单位为当前地图单位，对选中要素生成缓冲区。";
            //
            // flpButtons
            //
            this.flpButtons.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tlpMain.SetColumnSpan(this.flpButtons, 2);
            this.flpButtons.Controls.Add(this.btnCancel);
            this.flpButtons.Controls.Add(this.btnOk);
            this.flpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpButtons.Location = new System.Drawing.Point(15, 65);
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.Size = new System.Drawing.Size(400, 32);
            //
            // btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(312, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 26);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // btnOk
            //
            this.btnOk.Location = new System.Drawing.Point(221, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 26);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            //
            // BufferAnalysisDialog
            //
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(430, 145);
            this.Controls.Add(this.tlpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BufferAnalysisDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "缓冲区分析";
            ((System.ComponentModel.ISupportInitialize)(this.numDistance)).EndInit();
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.flpButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label lblDistance;
        private System.Windows.Forms.NumericUpDown numDistance;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}
