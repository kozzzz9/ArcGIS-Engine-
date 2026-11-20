namespace MyMap
{
    partial class SelectionPanel
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
            this.lblSelectionCount = new System.Windows.Forms.Label();
            this.dgvSelection = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelection)).BeginInit();
            this.SuspendLayout();
            //
            // lblSelectionCount
            //
            this.lblSelectionCount.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSelectionCount.Location = new System.Drawing.Point(0, 0);
            this.lblSelectionCount.Name = "lblSelectionCount";
            this.lblSelectionCount.Padding = new System.Windows.Forms.Padding(6, 6, 0, 6);
            this.lblSelectionCount.Size = new System.Drawing.Size(300, 28);
            this.lblSelectionCount.TabIndex = 0;
            this.lblSelectionCount.Text = "选中要素：0";
            this.lblSelectionCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // dgvSelection
            //
            this.dgvSelection.AllowUserToAddRows = false;
            this.dgvSelection.AllowUserToDeleteRows = false;
            this.dgvSelection.BackgroundColor = System.Drawing.Color.White;
            this.dgvSelection.ColumnHeadersVisible = false;
            this.dgvSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSelection.Location = new System.Drawing.Point(0, 28);
            this.dgvSelection.MultiSelect = false;
            this.dgvSelection.Name = "dgvSelection";
            this.dgvSelection.ReadOnly = true;
            this.dgvSelection.RowHeadersVisible = false;
            this.dgvSelection.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSelection.Size = new System.Drawing.Size(300, 372);
            this.dgvSelection.TabIndex = 1;
            this.dgvSelection.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSelection_CellDoubleClick);
            //
            // SelectionPanel
            //
            this.ClientSize = new System.Drawing.Size(300, 400);
            this.Controls.Add(this.dgvSelection);
            this.Controls.Add(this.lblSelectionCount);
            this.Name = "SelectionPanel";
            this.Text = "选择要素";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSelectionCount;
        private System.Windows.Forms.DataGridView dgvSelection;
    }
}
