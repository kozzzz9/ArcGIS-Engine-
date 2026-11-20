namespace MyMap
{
    partial class DBSCANParamsDialog
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
            this.lblEps = new System.Windows.Forms.Label();
            this.numEps = new System.Windows.Forms.NumericUpDown();
            this.lblMinPts = new System.Windows.Forms.Label();
            this.numMinPts = new System.Windows.Forms.NumericUpDown();
            this.lblHint = new System.Windows.Forms.Label();
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numEps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinPts)).BeginInit();
            this.tlpMain.SuspendLayout();
            this.flpButtons.SuspendLayout();
            this.SuspendLayout();
            //
            // tlpMain
            //
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.lblEps, 0, 0);
            this.tlpMain.Controls.Add(this.numEps, 1, 0);
            this.tlpMain.Controls.Add(this.lblMinPts, 0, 1);
            this.tlpMain.Controls.Add(this.numMinPts, 1, 1);
            this.tlpMain.Controls.Add(this.lblHint, 0, 2);
            this.tlpMain.Controls.Add(this.flpButtons, 0, 4);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.Padding = new System.Windows.Forms.Padding(12, 16, 12, 10);
            this.tlpMain.RowCount = 5;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpMain.Size = new System.Drawing.Size(400, 190);
            this.tlpMain.TabIndex = 0;
            //
            // lblEps
            //
            this.lblEps.AutoSize = true;
            this.lblEps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEps.Location = new System.Drawing.Point(15, 19);
            this.lblEps.Name = "lblEps";
            this.lblEps.Text = "邻域半径 Eps：";
            this.lblEps.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // numEps
            //
            this.numEps.DecimalPlaces = 2;
            this.numEps.Dock = System.Windows.Forms.DockStyle.Left;
            this.numEps.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numEps.Location = new System.Drawing.Point(118, 16);
            this.numEps.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numEps.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numEps.Name = "numEps";
            this.numEps.Size = new System.Drawing.Size(90, 21);
            this.numEps.TabIndex = 1;
            this.numEps.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            //
            // lblMinPts
            //
            this.lblMinPts.AutoSize = true;
            this.lblMinPts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMinPts.Location = new System.Drawing.Point(15, 48);
            this.lblMinPts.Name = "lblMinPts";
            this.lblMinPts.Text = "核心点最小点数 MinPts：";
            this.lblMinPts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // numMinPts
            //
            this.numMinPts.Dock = System.Windows.Forms.DockStyle.Left;
            this.numMinPts.Location = new System.Drawing.Point(118, 45);
            this.numMinPts.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numMinPts.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numMinPts.Name = "numMinPts";
            this.numMinPts.Size = new System.Drawing.Size(90, 21);
            this.numMinPts.TabIndex = 3;
            this.numMinPts.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            //
            // lblHint
            //
            this.lblHint.AutoSize = true;
            this.lblHint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHint.ForeColor = System.Drawing.Color.Gray;
            this.lblHint.Location = new System.Drawing.Point(15, 75);
            this.lblHint.Name = "lblHint";
            this.lblHint.Text = "Eps 为地图单位（经纬度图层请用较小值，如 1~10 度）；\r\n小于 MinPts 个邻域点且非核心点的点被标记为噪声。";
            //
            // flpButtons
            //
            this.tlpMain.SetColumnSpan(this.flpButtons, 2);
            this.flpButtons.Controls.Add(this.btnCancel);
            this.flpButtons.Controls.Add(this.btnOk);
            this.flpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpButtons.Location = new System.Drawing.Point(15, 119);
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.Size = new System.Drawing.Size(370, 32);
            //
            // btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(282, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 26);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // btnOk
            //
            this.btnOk.Location = new System.Drawing.Point(191, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 26);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            //
            // DBSCANParamsDialog
            //
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(400, 190);
            this.Controls.Add(this.tlpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DBSCANParamsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DBSCAN 聚类参数";
            ((System.ComponentModel.ISupportInitialize)(this.numEps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinPts)).EndInit();
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.flpButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label lblEps;
        private System.Windows.Forms.NumericUpDown numEps;
        private System.Windows.Forms.Label lblMinPts;
        private System.Windows.Forms.NumericUpDown numMinPts;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
    }
}
