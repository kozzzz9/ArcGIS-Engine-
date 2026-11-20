namespace MyMap
{
    partial class CatalogDockWindow
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
            this.pnlCatalogTop = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblCatalogTip = new System.Windows.Forms.Label();
            this.treeCatalog = new System.Windows.Forms.TreeView();
            this.pnlCatalogTop.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlCatalogTop
            //
            this.pnlCatalogTop.Controls.Add(this.btnRefresh);
            this.pnlCatalogTop.Controls.Add(this.lblCatalogTip);
            this.pnlCatalogTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCatalogTop.Location = new System.Drawing.Point(0, 0);
            this.pnlCatalogTop.Name = "pnlCatalogTop";
            this.pnlCatalogTop.Size = new System.Drawing.Size(320, 64);
            this.pnlCatalogTop.TabIndex = 0;
            //
            // btnRefresh
            //
            this.btnRefresh.Location = new System.Drawing.Point(8, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 26);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "刷新目录";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            //
            // lblCatalogTip
            //
            this.lblCatalogTip.AutoSize = true;
            this.lblCatalogTip.Location = new System.Drawing.Point(8, 42);
            this.lblCatalogTip.Name = "lblCatalogTip";
            this.lblCatalogTip.Size = new System.Drawing.Size(287, 12);
            this.lblCatalogTip.TabIndex = 1;
            this.lblCatalogTip.Text = "双击 shp / lyr / mxd 文件即可加载到当前地图。";
            //
            // treeCatalog
            //
            this.treeCatalog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeCatalog.HideSelection = false;
            this.treeCatalog.Location = new System.Drawing.Point(0, 64);
            this.treeCatalog.Name = "treeCatalog";
            this.treeCatalog.Size = new System.Drawing.Size(320, 386);
            this.treeCatalog.TabIndex = 1;
            this.treeCatalog.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeCatalog_BeforeExpand);
            this.treeCatalog.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeCatalog_NodeMouseDoubleClick);
            //
            // CatalogDockWindow
            //
            this.ClientSize = new System.Drawing.Size(320, 450);
            this.Controls.Add(this.treeCatalog);
            this.Controls.Add(this.pnlCatalogTop);
            this.Name = "CatalogDockWindow";
            this.Text = "数据目录";
            this.pnlCatalogTop.ResumeLayout(false);
            this.pnlCatalogTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCatalogTop;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblCatalogTip;
        private System.Windows.Forms.TreeView treeCatalog;
    }
}
