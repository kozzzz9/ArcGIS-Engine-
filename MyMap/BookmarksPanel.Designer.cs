namespace MyMap
{
    partial class BookmarksPanel
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
            this.flpBookmarkTools = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddBookmark = new System.Windows.Forms.Button();
            this.btnDeleteBookmark = new System.Windows.Forms.Button();
            this.lstBookmarks = new System.Windows.Forms.ListBox();
            this.flpBookmarkTools.SuspendLayout();
            this.SuspendLayout();
            //
            // flpBookmarkTools
            //
            this.flpBookmarkTools.Controls.Add(this.btnAddBookmark);
            this.flpBookmarkTools.Controls.Add(this.btnDeleteBookmark);
            this.flpBookmarkTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpBookmarkTools.Location = new System.Drawing.Point(0, 0);
            this.flpBookmarkTools.Name = "flpBookmarkTools";
            this.flpBookmarkTools.Size = new System.Drawing.Size(300, 40);
            this.flpBookmarkTools.TabIndex = 0;
            //
            // btnAddBookmark
            //
            this.btnAddBookmark.Location = new System.Drawing.Point(6, 6);
            this.btnAddBookmark.Name = "btnAddBookmark";
            this.btnAddBookmark.Size = new System.Drawing.Size(135, 28);
            this.btnAddBookmark.TabIndex = 0;
            this.btnAddBookmark.Text = "添加当前视图";
            this.btnAddBookmark.UseVisualStyleBackColor = true;
            this.btnAddBookmark.Click += new System.EventHandler(this.btnAddBookmark_Click);
            //
            // btnDeleteBookmark
            //
            this.btnDeleteBookmark.Location = new System.Drawing.Point(147, 6);
            this.btnDeleteBookmark.Name = "btnDeleteBookmark";
            this.btnDeleteBookmark.Size = new System.Drawing.Size(90, 28);
            this.btnDeleteBookmark.TabIndex = 1;
            this.btnDeleteBookmark.Text = "删除";
            this.btnDeleteBookmark.UseVisualStyleBackColor = true;
            this.btnDeleteBookmark.Click += new System.EventHandler(this.btnDeleteBookmark_Click);
            //
            // lstBookmarks
            //
            this.lstBookmarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstBookmarks.ItemHeight = 12;
            this.lstBookmarks.Location = new System.Drawing.Point(0, 40);
            this.lstBookmarks.Name = "lstBookmarks";
            this.lstBookmarks.Size = new System.Drawing.Size(300, 360);
            this.lstBookmarks.TabIndex = 1;
            this.lstBookmarks.DoubleClick += new System.EventHandler(this.lstBookmarks_DoubleClick);
            //
            // BookmarksPanel
            //
            this.ClientSize = new System.Drawing.Size(300, 400);
            this.Controls.Add(this.lstBookmarks);
            this.Controls.Add(this.flpBookmarkTools);
            this.Name = "BookmarksPanel";
            this.Text = "书签";
            this.flpBookmarkTools.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpBookmarkTools;
        private System.Windows.Forms.Button btnAddBookmark;
        private System.Windows.Forms.Button btnDeleteBookmark;
        private System.Windows.Forms.ListBox lstBookmarks;
    }
}
