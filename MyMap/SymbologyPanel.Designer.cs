namespace MyMap
{
    partial class SymbologyPanel
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
            this.pnlSymbologyTop = new System.Windows.Forms.Panel();
            this.lblSymbologyLayer = new System.Windows.Forms.Label();
            this.btnApplySymbol = new System.Windows.Forms.Button();
            this.btnAdvancedSymbol = new System.Windows.Forms.Button();
            this.pictureBoxSymbolPreview = new System.Windows.Forms.PictureBox();
            this.axSymbologyPanelControl = new ESRI.ArcGIS.Controls.AxSymbologyControl();
            this.pnlSymbologyTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSymbolPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axSymbologyPanelControl)).BeginInit();
            this.SuspendLayout();
            //
            // pnlSymbologyTop
            //
            this.pnlSymbologyTop.Controls.Add(this.lblSymbologyLayer);
            this.pnlSymbologyTop.Controls.Add(this.btnApplySymbol);
            this.pnlSymbologyTop.Controls.Add(this.btnAdvancedSymbol);
            this.pnlSymbologyTop.Controls.Add(this.pictureBoxSymbolPreview);
            this.pnlSymbologyTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSymbologyTop.Location = new System.Drawing.Point(0, 0);
            this.pnlSymbologyTop.Name = "pnlSymbologyTop";
            this.pnlSymbologyTop.Size = new System.Drawing.Size(320, 190);
            this.pnlSymbologyTop.TabIndex = 0;
            //
            // lblSymbologyLayer
            //
            this.lblSymbologyLayer.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSymbologyLayer.Location = new System.Drawing.Point(0, 0);
            this.lblSymbologyLayer.Name = "lblSymbologyLayer";
            this.lblSymbologyLayer.Padding = new System.Windows.Forms.Padding(6, 6, 0, 6);
            this.lblSymbologyLayer.Size = new System.Drawing.Size(320, 28);
            this.lblSymbologyLayer.TabIndex = 0;
            this.lblSymbologyLayer.Text = "图层：（未选择）";
            this.lblSymbologyLayer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // btnApplySymbol
            //
            this.btnApplySymbol.Location = new System.Drawing.Point(8, 36);
            this.btnApplySymbol.Name = "btnApplySymbol";
            this.btnApplySymbol.Size = new System.Drawing.Size(145, 28);
            this.btnApplySymbol.TabIndex = 1;
            this.btnApplySymbol.Text = "应用到选中图层";
            this.btnApplySymbol.UseVisualStyleBackColor = true;
            this.btnApplySymbol.Click += new System.EventHandler(this.btnApplySymbol_Click);
            //
            // btnAdvancedSymbol
            //
            this.btnAdvancedSymbol.Location = new System.Drawing.Point(165, 36);
            this.btnAdvancedSymbol.Name = "btnAdvancedSymbol";
            this.btnAdvancedSymbol.Size = new System.Drawing.Size(145, 28);
            this.btnAdvancedSymbol.TabIndex = 2;
            this.btnAdvancedSymbol.Text = "高级参数设置...";
            this.btnAdvancedSymbol.UseVisualStyleBackColor = true;
            this.btnAdvancedSymbol.Click += new System.EventHandler(this.btnAdvancedSymbol_Click);
            //
            // pictureBoxSymbolPreview
            //
            this.pictureBoxSymbolPreview.BackColor = System.Drawing.Color.White;
            this.pictureBoxSymbolPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxSymbolPreview.Location = new System.Drawing.Point(8, 72);
            this.pictureBoxSymbolPreview.Name = "pictureBoxSymbolPreview";
            this.pictureBoxSymbolPreview.Size = new System.Drawing.Size(302, 108);
            this.pictureBoxSymbolPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSymbolPreview.TabIndex = 3;
            this.pictureBoxSymbolPreview.TabStop = false;
            //
            // axSymbologyPanelControl
            //
            this.axSymbologyPanelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axSymbologyPanelControl.Location = new System.Drawing.Point(0, 190);
            this.axSymbologyPanelControl.Name = "axSymbologyPanelControl";
            this.axSymbologyPanelControl.Size = new System.Drawing.Size(320, 210);
            this.axSymbologyPanelControl.TabIndex = 1;
            this.axSymbologyPanelControl.OnItemSelected += new ESRI.ArcGIS.Controls.ISymbologyControlEvents_Ax_OnItemSelectedEventHandler(this.axSymbologyPanelControl_OnItemSelected);
            this.axSymbologyPanelControl.OnDoubleClick += new ESRI.ArcGIS.Controls.ISymbologyControlEvents_Ax_OnDoubleClickEventHandler(this.axSymbologyPanelControl_OnDoubleClick);
            //
            // SymbologyPanel
            //
            this.ClientSize = new System.Drawing.Size(320, 400);
            this.Controls.Add(this.axSymbologyPanelControl);
            this.Controls.Add(this.pnlSymbologyTop);
            this.Name = "SymbologyPanel";
            this.Text = "符号系统";
            this.pnlSymbologyTop.ResumeLayout(false);
            this.pnlSymbologyTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSymbolPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axSymbologyPanelControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSymbologyTop;
        private System.Windows.Forms.Label lblSymbologyLayer;
        private System.Windows.Forms.Button btnApplySymbol;
        private System.Windows.Forms.Button btnAdvancedSymbol;
        private System.Windows.Forms.PictureBox pictureBoxSymbolPreview;
        private ESRI.ArcGIS.Controls.AxSymbologyControl axSymbologyPanelControl;
    }
}
