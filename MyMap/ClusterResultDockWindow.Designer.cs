namespace MyMap
{
    partial class ClusterResultDockWindow
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
            this.lblSummary = new System.Windows.Forms.Label();
            this.dgvClusters = new System.Windows.Forms.DataGridView();
            this.clmClusterId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPointCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRatio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCenterX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCenterY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClusters)).BeginInit();
            this.SuspendLayout();
            //
            // tlpMain
            //
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.lblSummary, 0, 0);
            this.tlpMain.Controls.Add(this.dgvClusters, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.Padding = new System.Windows.Forms.Padding(8);
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(384, 261);
            this.tlpMain.TabIndex = 0;
            //
            // lblSummary
            //
            this.lblSummary.AutoSize = true;
            this.lblSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSummary.Location = new System.Drawing.Point(11, 11);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(362, 30);
            this.lblSummary.TabIndex = 0;
            this.lblSummary.Text = "算法：-";
            //
            // dgvClusters
            //
            this.dgvClusters.AllowUserToAddRows = false;
            this.dgvClusters.AllowUserToDeleteRows = false;
            this.dgvClusters.AllowUserToOrderColumns = true;
            this.dgvClusters.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClusters.BackgroundColor = System.Drawing.Color.White;
            this.dgvClusters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClusters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmClusterId,
            this.clmPointCount,
            this.clmRatio,
            this.clmCenterX,
            this.clmCenterY});
            this.dgvClusters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvClusters.Location = new System.Drawing.Point(11, 47);
            this.dgvClusters.Name = "dgvClusters";
            this.dgvClusters.ReadOnly = true;
            this.dgvClusters.RowHeadersVisible = false;
            this.dgvClusters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClusters.Size = new System.Drawing.Size(362, 203);
            this.dgvClusters.TabIndex = 1;
            //
            // clmClusterId
            //
            this.clmClusterId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.clmClusterId.DataPropertyName = "簇编号";
            this.clmClusterId.HeaderText = "簇编号";
            this.clmClusterId.Name = "clmClusterId";
            this.clmClusterId.ReadOnly = true;
            //
            // clmPointCount
            //
            this.clmPointCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.clmPointCount.DataPropertyName = "点数";
            this.clmPointCount.HeaderText = "点数";
            this.clmPointCount.Name = "clmPointCount";
            this.clmPointCount.ReadOnly = true;
            //
            // clmRatio
            //
            this.clmRatio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.clmRatio.DataPropertyName = "占比(%)";
            this.clmRatio.HeaderText = "占比(%)";
            this.clmRatio.Name = "clmRatio";
            this.clmRatio.ReadOnly = true;
            //
            // clmCenterX
            //
            this.clmCenterX.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmCenterX.DataPropertyName = "质心X";
            this.clmCenterX.HeaderText = "质心X";
            this.clmCenterX.Name = "clmCenterX";
            this.clmCenterX.ReadOnly = true;
            //
            // clmCenterY
            //
            this.clmCenterY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmCenterY.DataPropertyName = "质心Y";
            this.clmCenterY.HeaderText = "质心Y";
            this.clmCenterY.Name = "clmCenterY";
            this.clmCenterY.ReadOnly = true;
            //
            // ClusterResultDockWindow
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "ClusterResultDockWindow";
            this.ShowIcon = false;
            this.TabText = "聚类结果";
            this.Text = "聚类结果";
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClusters)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.DataGridView dgvClusters;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmClusterId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPointCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRatio;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCenterX;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCenterY;
    }
}
