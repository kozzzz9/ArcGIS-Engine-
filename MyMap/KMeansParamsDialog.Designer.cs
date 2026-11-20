namespace MyMap
{
    partial class KMeansParamsDialog
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
            this.lblK = new System.Windows.Forms.Label();
            this.numK = new System.Windows.Forms.NumericUpDown();
            this.lblIterations = new System.Windows.Forms.Label();
            this.numIterations = new System.Windows.Forms.NumericUpDown();
            this.lblRuns = new System.Windows.Forms.Label();
            this.numRuns = new System.Windows.Forms.NumericUpDown();
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIterations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRuns)).BeginInit();
            this.tlpMain.SuspendLayout();
            this.flpButtons.SuspendLayout();
            this.SuspendLayout();
            //
            // tlpMain
            //
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.lblK, 0, 0);
            this.tlpMain.Controls.Add(this.numK, 1, 0);
            this.tlpMain.Controls.Add(this.lblIterations, 0, 1);
            this.tlpMain.Controls.Add(this.numIterations, 1, 1);
            this.tlpMain.Controls.Add(this.lblRuns, 0, 2);
            this.tlpMain.Controls.Add(this.numRuns, 1, 2);
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
            // lblK
            //
            this.lblK.AutoSize = true;
            this.lblK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblK.Location = new System.Drawing.Point(15, 19);
            this.lblK.Name = "lblK";
            this.lblK.Text = "簇数量 K：";
            this.lblK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // numK
            //
            this.numK.Dock = System.Windows.Forms.DockStyle.Left;
            this.numK.Location = new System.Drawing.Point(118, 16);
            this.numK.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numK.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numK.Name = "numK";
            this.numK.Size = new System.Drawing.Size(90, 21);
            this.numK.TabIndex = 1;
            this.numK.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            //
            // lblIterations
            //
            this.lblIterations.AutoSize = true;
            this.lblIterations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIterations.Location = new System.Drawing.Point(15, 48);
            this.lblIterations.Name = "lblIterations";
            this.lblIterations.Text = "最大迭代次数：";
            this.lblIterations.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // numIterations
            //
            this.numIterations.Dock = System.Windows.Forms.DockStyle.Left;
            this.numIterations.Location = new System.Drawing.Point(118, 45);
            this.numIterations.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numIterations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numIterations.Name = "numIterations";
            this.numIterations.Size = new System.Drawing.Size(90, 21);
            this.numIterations.TabIndex = 3;
            this.numIterations.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            //
            // lblRuns
            //
            this.lblRuns.AutoSize = true;
            this.lblRuns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRuns.Location = new System.Drawing.Point(15, 77);
            this.lblRuns.Name = "lblRuns";
            this.lblRuns.Text = "运行次数（取最优）：";
            this.lblRuns.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // numRuns
            //
            this.numRuns.Dock = System.Windows.Forms.DockStyle.Left;
            this.numRuns.Location = new System.Drawing.Point(118, 74);
            this.numRuns.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numRuns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRuns.Name = "numRuns";
            this.numRuns.Size = new System.Drawing.Size(90, 21);
            this.numRuns.TabIndex = 5;
            this.numRuns.Value = new decimal(new int[] {
            10,
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
            this.flpButtons.Location = new System.Drawing.Point(15, 107);
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
            // KMeansParamsDialog
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
            this.Name = "KMeansParamsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "K-Means 聚类参数";
            ((System.ComponentModel.ISupportInitialize)(this.numK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIterations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRuns)).EndInit();
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.flpButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label lblK;
        private System.Windows.Forms.NumericUpDown numK;
        private System.Windows.Forms.Label lblIterations;
        private System.Windows.Forms.NumericUpDown numIterations;
        private System.Windows.Forms.Label lblRuns;
        private System.Windows.Forms.NumericUpDown numRuns;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}
