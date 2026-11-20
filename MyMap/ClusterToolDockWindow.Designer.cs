namespace MyMap
{
    partial class ClusterToolDockWindow
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
            this.lblAlgorithm = new System.Windows.Forms.Label();
            this.cboAlgorithm = new System.Windows.Forms.ComboBox();
            this.pnlParams = new System.Windows.Forms.Panel();
            this.gbKMeans = new System.Windows.Forms.GroupBox();
            this.tlpKMeans = new System.Windows.Forms.TableLayoutPanel();
            this.lblK = new System.Windows.Forms.Label();
            this.numK = new System.Windows.Forms.NumericUpDown();
            this.lblIterations = new System.Windows.Forms.Label();
            this.numIterations = new System.Windows.Forms.NumericUpDown();
            this.lblRuns = new System.Windows.Forms.Label();
            this.numRuns = new System.Windows.Forms.NumericUpDown();
            this.gbDBSCAN = new System.Windows.Forms.GroupBox();
            this.tlpDBSCAN = new System.Windows.Forms.TableLayoutPanel();
            this.lblEps = new System.Windows.Forms.Label();
            this.numEps = new System.Windows.Forms.NumericUpDown();
            this.lblMinPts = new System.Windows.Forms.Label();
            this.numMinPts = new System.Windows.Forms.NumericUpDown();
            this.gbHierarchical = new System.Windows.Forms.GroupBox();
            this.tlpHierarchical = new System.Windows.Forms.TableLayoutPanel();
            this.lblTargetClusters = new System.Windows.Forms.Label();
            this.numTargetClusters = new System.Windows.Forms.NumericUpDown();
            this.btnExecute = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.tlpMain.SuspendLayout();
            this.pnlParams.SuspendLayout();
            this.gbKMeans.SuspendLayout();
            this.tlpKMeans.SuspendLayout();
            this.gbDBSCAN.SuspendLayout();
            this.tlpDBSCAN.SuspendLayout();
            this.gbHierarchical.SuspendLayout();
            this.tlpHierarchical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIterations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRuns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinPts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTargetClusters)).BeginInit();
            this.SuspendLayout();
            //
            // tlpMain
            //
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.lblAlgorithm, 0, 0);
            this.tlpMain.Controls.Add(this.cboAlgorithm, 0, 1);
            this.tlpMain.Controls.Add(this.pnlParams, 0, 2);
            this.tlpMain.Controls.Add(this.btnExecute, 0, 3);
            this.tlpMain.Controls.Add(this.txtLog, 0, 4);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.Padding = new System.Windows.Forms.Padding(8);
            this.tlpMain.RowCount = 5;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(316, 546);
            this.tlpMain.TabIndex = 0;
            //
            // lblAlgorithm
            //
            this.lblAlgorithm.AutoSize = true;
            this.lblAlgorithm.Location = new System.Drawing.Point(11, 11);
            this.lblAlgorithm.Name = "lblAlgorithm";
            this.lblAlgorithm.Size = new System.Drawing.Size(65, 12);
            this.lblAlgorithm.TabIndex = 0;
            this.lblAlgorithm.Text = "聚类算法：";
            //
            // cboAlgorithm
            //
            this.cboAlgorithm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlgorithm.FormattingEnabled = true;
            this.cboAlgorithm.Location = new System.Drawing.Point(11, 26);
            this.cboAlgorithm.Name = "cboAlgorithm";
            this.cboAlgorithm.Size = new System.Drawing.Size(294, 20);
            this.cboAlgorithm.TabIndex = 1;
            //
            // pnlParams
            //
            this.pnlParams.AutoSize = true;
            this.pnlParams.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlParams.Controls.Add(this.gbKMeans);
            this.pnlParams.Controls.Add(this.gbDBSCAN);
            this.pnlParams.Controls.Add(this.gbHierarchical);
            this.pnlParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlParams.Location = new System.Drawing.Point(11, 49);
            this.pnlParams.Name = "pnlParams";
            this.pnlParams.Size = new System.Drawing.Size(294, 176);
            this.pnlParams.TabIndex = 2;
            //
            // gbKMeans
            //
            this.gbKMeans.AutoSize = true;
            this.gbKMeans.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbKMeans.Controls.Add(this.tlpKMeans);
            this.gbKMeans.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbKMeans.Location = new System.Drawing.Point(0, 0);
            this.gbKMeans.Name = "gbKMeans";
            this.gbKMeans.Size = new System.Drawing.Size(294, 106);
            this.gbKMeans.TabIndex = 0;
            this.gbKMeans.Text = "K-Means 参数";
            //
            // tlpKMeans
            //
            this.tlpKMeans.ColumnCount = 2;
            this.tlpKMeans.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpKMeans.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpKMeans.Controls.Add(this.lblK, 0, 0);
            this.tlpKMeans.Controls.Add(this.numK, 1, 0);
            this.tlpKMeans.Controls.Add(this.lblIterations, 0, 1);
            this.tlpKMeans.Controls.Add(this.numIterations, 1, 1);
            this.tlpKMeans.Controls.Add(this.lblRuns, 0, 2);
            this.tlpKMeans.Controls.Add(this.numRuns, 1, 2);
            this.tlpKMeans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpKMeans.Location = new System.Drawing.Point(3, 17);
            this.tlpKMeans.Name = "tlpKMeans";
            this.tlpKMeans.RowCount = 3;
            this.tlpKMeans.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpKMeans.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpKMeans.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpKMeans.Size = new System.Drawing.Size(288, 86);
            this.tlpKMeans.TabIndex = 0;
            //
            // lblK
            //
            this.lblK.AutoSize = true;
            this.lblK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblK.Location = new System.Drawing.Point(3, 0);
            this.lblK.Name = "lblK";
            this.lblK.Text = "聚类数 K：";
            this.lblK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // numK
            //
            this.numK.Dock = System.Windows.Forms.DockStyle.Left;
            this.numK.Location = new System.Drawing.Point(90, 3);
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
            4,
            0,
            0,
            0});
            //
            // lblIterations
            //
            this.lblIterations.AutoSize = true;
            this.lblIterations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIterations.Location = new System.Drawing.Point(3, 27);
            this.lblIterations.Name = "lblIterations";
            this.lblIterations.Text = "最大迭代次数：";
            this.lblIterations.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // numIterations
            //
            this.numIterations.Dock = System.Windows.Forms.DockStyle.Left;
            this.numIterations.Location = new System.Drawing.Point(90, 30);
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
            this.lblRuns.Location = new System.Drawing.Point(3, 54);
            this.lblRuns.Name = "lblRuns";
            this.lblRuns.Text = "运行次数（取最优）：";
            this.lblRuns.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // numRuns
            //
            this.numRuns.Dock = System.Windows.Forms.DockStyle.Left;
            this.numRuns.Location = new System.Drawing.Point(90, 57);
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
            // gbDBSCAN
            //
            this.gbDBSCAN.AutoSize = true;
            this.gbDBSCAN.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbDBSCAN.Controls.Add(this.tlpDBSCAN);
            this.gbDBSCAN.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbDBSCAN.Location = new System.Drawing.Point(0, 106);
            this.gbDBSCAN.Name = "gbDBSCAN";
            this.gbDBSCAN.Size = new System.Drawing.Size(294, 70);
            this.gbDBSCAN.TabIndex = 1;
            this.gbDBSCAN.Text = "DBSCAN 参数";
            //
            // tlpDBSCAN
            //
            this.tlpDBSCAN.ColumnCount = 2;
            this.tlpDBSCAN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpDBSCAN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDBSCAN.Controls.Add(this.lblEps, 0, 0);
            this.tlpDBSCAN.Controls.Add(this.numEps, 1, 0);
            this.tlpDBSCAN.Controls.Add(this.lblMinPts, 0, 1);
            this.tlpDBSCAN.Controls.Add(this.numMinPts, 1, 1);
            this.tlpDBSCAN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDBSCAN.Location = new System.Drawing.Point(3, 17);
            this.tlpDBSCAN.Name = "tlpDBSCAN";
            this.tlpDBSCAN.RowCount = 2;
            this.tlpDBSCAN.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpDBSCAN.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpDBSCAN.Size = new System.Drawing.Size(288, 50);
            this.tlpDBSCAN.TabIndex = 0;
            //
            // lblEps
            //
            this.lblEps.AutoSize = true;
            this.lblEps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEps.Location = new System.Drawing.Point(3, 0);
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
            this.numEps.Location = new System.Drawing.Point(90, 3);
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
            this.lblMinPts.Location = new System.Drawing.Point(3, 27);
            this.lblMinPts.Name = "lblMinPts";
            this.lblMinPts.Text = "最小点数 MinPts：";
            this.lblMinPts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // numMinPts
            //
            this.numMinPts.Dock = System.Windows.Forms.DockStyle.Left;
            this.numMinPts.Location = new System.Drawing.Point(90, 30);
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
            // gbHierarchical
            //
            this.gbHierarchical.AutoSize = true;
            this.gbHierarchical.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbHierarchical.Controls.Add(this.tlpHierarchical);
            this.gbHierarchical.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbHierarchical.Location = new System.Drawing.Point(0, 176);
            this.gbHierarchical.Name = "gbHierarchical";
            this.gbHierarchical.Size = new System.Drawing.Size(294, 43);
            this.gbHierarchical.TabIndex = 2;
            this.gbHierarchical.Text = "层次聚类参数";
            //
            // tlpHierarchical
            //
            this.tlpHierarchical.ColumnCount = 2;
            this.tlpHierarchical.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpHierarchical.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHierarchical.Controls.Add(this.lblTargetClusters, 0, 0);
            this.tlpHierarchical.Controls.Add(this.numTargetClusters, 1, 0);
            this.tlpHierarchical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpHierarchical.Location = new System.Drawing.Point(3, 17);
            this.tlpHierarchical.Name = "tlpHierarchical";
            this.tlpHierarchical.RowCount = 1;
            this.tlpHierarchical.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpHierarchical.Size = new System.Drawing.Size(288, 23);
            this.tlpHierarchical.TabIndex = 0;
            //
            // lblTargetClusters
            //
            this.lblTargetClusters.AutoSize = true;
            this.lblTargetClusters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTargetClusters.Location = new System.Drawing.Point(3, 0);
            this.lblTargetClusters.Name = "lblTargetClusters";
            this.lblTargetClusters.Text = "目标簇数：";
            this.lblTargetClusters.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // numTargetClusters
            //
            this.numTargetClusters.Dock = System.Windows.Forms.DockStyle.Left;
            this.numTargetClusters.Location = new System.Drawing.Point(90, 3);
            this.numTargetClusters.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numTargetClusters.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numTargetClusters.Name = "numTargetClusters";
            this.numTargetClusters.Size = new System.Drawing.Size(90, 21);
            this.numTargetClusters.TabIndex = 1;
            this.numTargetClusters.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            //
            // btnExecute
            //
            this.btnExecute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExecute.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold);
            this.btnExecute.Location = new System.Drawing.Point(11, 228);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(294, 34);
            this.btnExecute.TabIndex = 3;
            this.btnExecute.Text = "执 行 聚 类";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            //
            // txtLog
            //
            this.txtLog.BackColor = System.Drawing.Color.White;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(11, 265);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(294, 270);
            this.txtLog.TabIndex = 4;
            //
            // ClusterToolDockWindow
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 546);
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "ClusterToolDockWindow";
            this.ShowIcon = false;
            this.TabText = "聚类分析";
            this.Text = "聚类分析";
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.pnlParams.ResumeLayout(false);
            this.pnlParams.PerformLayout();
            this.gbKMeans.ResumeLayout(false);
            this.tlpKMeans.ResumeLayout(false);
            this.tlpKMeans.PerformLayout();
            this.gbDBSCAN.ResumeLayout(false);
            this.tlpDBSCAN.ResumeLayout(false);
            this.tlpDBSCAN.PerformLayout();
            this.gbHierarchical.ResumeLayout(false);
            this.tlpHierarchical.ResumeLayout(false);
            this.tlpHierarchical.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIterations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRuns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinPts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTargetClusters)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label lblAlgorithm;
        private System.Windows.Forms.ComboBox cboAlgorithm;
        private System.Windows.Forms.Panel pnlParams;
        private System.Windows.Forms.GroupBox gbKMeans;
        private System.Windows.Forms.TableLayoutPanel tlpKMeans;
        private System.Windows.Forms.Label lblK;
        private System.Windows.Forms.NumericUpDown numK;
        private System.Windows.Forms.Label lblIterations;
        private System.Windows.Forms.NumericUpDown numIterations;
        private System.Windows.Forms.Label lblRuns;
        private System.Windows.Forms.NumericUpDown numRuns;
        private System.Windows.Forms.GroupBox gbDBSCAN;
        private System.Windows.Forms.TableLayoutPanel tlpDBSCAN;
        private System.Windows.Forms.Label lblEps;
        private System.Windows.Forms.NumericUpDown numEps;
        private System.Windows.Forms.Label lblMinPts;
        private System.Windows.Forms.NumericUpDown numMinPts;
        private System.Windows.Forms.GroupBox gbHierarchical;
        private System.Windows.Forms.TableLayoutPanel tlpHierarchical;
        private System.Windows.Forms.Label lblTargetClusters;
        private System.Windows.Forms.NumericUpDown numTargetClusters;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.TextBox txtLog;
    }
}
