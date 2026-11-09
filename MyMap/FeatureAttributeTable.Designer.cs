
namespace MyMap
{
    partial class FeatureAttributeTable
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeatureAttributeTable));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.pnlTools = new System.Windows.Forms.FlowLayoutPanel();
            this.chkEditMode = new System.Windows.Forms.CheckBox();
            this.btnZoomToFeature = new System.Windows.Forms.Button();
            this.btnExportCsv = new System.Windows.Forms.Button();
            this.btnDeleteFeature = new System.Windows.Forms.Button();
            this.lblFilter = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.pnlTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.ColumnHeadersHeight = 34;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 44);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 62;
            this.dataGridView.Size = new System.Drawing.Size(1200, 579);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellDoubleClick);
            this.dataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellEndEdit);
            // 
            // pnlTools
            // 
            this.pnlTools.Controls.Add(this.chkEditMode);
            this.pnlTools.Controls.Add(this.btnZoomToFeature);
            this.pnlTools.Controls.Add(this.btnExportCsv);
            this.pnlTools.Controls.Add(this.btnDeleteFeature);
            this.pnlTools.Controls.Add(this.lblFilter);
            this.pnlTools.Controls.Add(this.txtFilter);
            this.pnlTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTools.Location = new System.Drawing.Point(0, 0);
            this.pnlTools.Name = "pnlTools";
            this.pnlTools.Padding = new System.Windows.Forms.Padding(8, 8, 8, 4);
            this.pnlTools.Size = new System.Drawing.Size(1200, 44);
            this.pnlTools.TabIndex = 0;
            this.pnlTools.WrapContents = false;
            // 
            // chkEditMode
            // 
            this.chkEditMode.AutoSize = true;
            this.chkEditMode.Location = new System.Drawing.Point(11, 19);
            this.chkEditMode.Margin = new System.Windows.Forms.Padding(3, 11, 12, 3);
            this.chkEditMode.Name = "chkEditMode";
            this.chkEditMode.Size = new System.Drawing.Size(232, 22);
            this.chkEditMode.TabIndex = 0;
            this.chkEditMode.Text = "编辑模式（可修改属性）";
            this.chkEditMode.CheckedChanged += new System.EventHandler(this.chkEditMode_CheckedChanged);
            // 
            // btnZoomToFeature
            // 
            this.btnZoomToFeature.Location = new System.Drawing.Point(258, 12);
            this.btnZoomToFeature.Margin = new System.Windows.Forms.Padding(3, 4, 12, 4);
            this.btnZoomToFeature.Name = "btnZoomToFeature";
            this.btnZoomToFeature.Size = new System.Drawing.Size(110, 28);
            this.btnZoomToFeature.TabIndex = 1;
            this.btnZoomToFeature.Text = "定位选中要素";
            this.btnZoomToFeature.Click += new System.EventHandler(this.btnZoomToFeature_Click);
            // 
            // btnExportCsv
            // 
            this.btnExportCsv.Location = new System.Drawing.Point(383, 12);
            this.btnExportCsv.Margin = new System.Windows.Forms.Padding(3, 4, 12, 4);
            this.btnExportCsv.Name = "btnExportCsv";
            this.btnExportCsv.Size = new System.Drawing.Size(100, 28);
            this.btnExportCsv.TabIndex = 2;
            this.btnExportCsv.Text = "导出 CSV";
            this.btnExportCsv.Click += new System.EventHandler(this.btnExportCsv_Click);
            // 
            // btnDeleteFeature
            // 
            this.btnDeleteFeature.Location = new System.Drawing.Point(498, 12);
            this.btnDeleteFeature.Margin = new System.Windows.Forms.Padding(3, 4, 12, 4);
            this.btnDeleteFeature.Name = "btnDeleteFeature";
            this.btnDeleteFeature.Size = new System.Drawing.Size(110, 28);
            this.btnDeleteFeature.TabIndex = 3;
            this.btnDeleteFeature.Text = "删除选中要素";
            this.btnDeleteFeature.Click += new System.EventHandler(this.btnDeleteFeature_Click);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(623, 19);
            this.lblFilter.Margin = new System.Windows.Forms.Padding(3, 11, 6, 3);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(62, 18);
            this.lblFilter.TabIndex = 4;
            this.lblFilter.Text = "筛选：";
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(694, 16);
            this.txtFilter.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(160, 28);
            this.txtFilter.TabIndex = 5;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // FeatureAttributeTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 623);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.pnlTools);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FeatureAttributeTable";
            this.Text = "属性查看";
            this.Load += new System.EventHandler(this.FeatureAttributeTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.pnlTools.ResumeLayout(false);
            this.pnlTools.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.FlowLayoutPanel pnlTools;
        private System.Windows.Forms.CheckBox chkEditMode;
        private System.Windows.Forms.Button btnZoomToFeature;
        private System.Windows.Forms.Button btnExportCsv;
        private System.Windows.Forms.Button btnDeleteFeature;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.TextBox txtFilter;
    }
}
