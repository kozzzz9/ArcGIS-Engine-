namespace MyMap
{
    partial class BookmarkDialog
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
            this.lblBookmarks = new System.Windows.Forms.Label();
            this.lstBookmarks = new System.Windows.Forms.ListBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblBookmarks
            //
            this.lblBookmarks.AutoSize = true;
            this.lblBookmarks.Location = new System.Drawing.Point(15, 18);
            this.lblBookmarks.Name = "lblBookmarks";
            this.lblBookmarks.Size = new System.Drawing.Size(65, 12);
            this.lblBookmarks.TabIndex = 0;
            this.lblBookmarks.Text = "书签列表：";
            //
            // lstBookmarks
            //
            this.lstBookmarks.ItemHeight = 12;
            this.lstBookmarks.Location = new System.Drawing.Point(15, 45);
            this.lstBookmarks.Name = "lstBookmarks";
            this.lstBookmarks.Size = new System.Drawing.Size(200, 208);
            this.lstBookmarks.TabIndex = 1;
            //
            // btnGo
            //
            this.btnGo.Location = new System.Drawing.Point(235, 45);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(100, 30);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "转到";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            //
            // btnDelete
            //
            this.btnDelete.Location = new System.Drawing.Point(235, 85);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            //
            // btnClose
            //
            this.btnClose.Location = new System.Drawing.Point(235, 225);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // BookmarkDialog
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(360, 300);
            this.Controls.Add(this.lblBookmarks);
            this.Controls.Add(this.lstBookmarks);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BookmarkDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "书签管理";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBookmarks;
        private System.Windows.Forms.ListBox lstBookmarks;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
    }
}
