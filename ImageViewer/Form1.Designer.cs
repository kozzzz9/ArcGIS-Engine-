namespace ImageViewer
{
    partial class Form1
    {
        /// <summary>设计器容器</summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>清理所有正在使用的资源</summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>设计器支持所需的方法，请勿直接修改</summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsOpen = new System.Windows.Forms.ToolStripButton();
            this.tsSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsZoomIn = new System.Windows.Forms.ToolStripButton();
            this.tsZoomOut = new System.Windows.Forms.ToolStripButton();
            this.tsActual = new System.Windows.Forms.ToolStripButton();
            this.tsFit = new System.Windows.Forms.ToolStripButton();
            this.tsSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsRotateL = new System.Windows.Forms.ToolStripButton();
            this.tsRotateR = new System.Windows.Forms.ToolStripButton();
            this.tsSep3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsPrev = new System.Windows.Forms.ToolStripButton();
            this.tsNext = new System.Windows.Forms.ToolStripButton();
            this.tsFull = new System.Windows.Forms.ToolStripButton();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.closeButton = new System.Windows.Forms.Button();
            this.backgroundButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.showButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssZoom = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.toolStrip1.SuspendLayout();
            this.panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsOpen,
            this.tsSep1,
            this.tsZoomIn,
            this.tsZoomOut,
            this.tsActual,
            this.tsFit,
            this.tsSep2,
            this.tsRotateL,
            this.tsRotateR,
            this.tsSep3,
            this.tsPrev,
            this.tsNext,
            this.tsFull});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1064, 42);
            this.toolStrip1.TabIndex = 0;
            // 
            // tsOpen
            // 
            this.tsOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsOpen.Name = "tsOpen";
            this.tsOpen.Size = new System.Drawing.Size(67, 37);
            this.tsOpen.Text = "打开";
            this.tsOpen.ToolTipText = "打开一张图片 (Ctrl+O)";
            this.tsOpen.Click += new System.EventHandler(this.tsOpen_Click);
            // 
            // tsSep1
            // 
            this.tsSep1.Name = "tsSep1";
            this.tsSep1.Size = new System.Drawing.Size(6, 42);
            // 
            // tsZoomIn
            // 
            this.tsZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsZoomIn.Name = "tsZoomIn";
            this.tsZoomIn.Size = new System.Drawing.Size(67, 37);
            this.tsZoomIn.Text = "放大";
            this.tsZoomIn.ToolTipText = "放大图片 (+)";
            this.tsZoomIn.Click += new System.EventHandler(this.tsZoomIn_Click);
            // 
            // tsZoomOut
            // 
            this.tsZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsZoomOut.Name = "tsZoomOut";
            this.tsZoomOut.Size = new System.Drawing.Size(67, 37);
            this.tsZoomOut.Text = "缩小";
            this.tsZoomOut.ToolTipText = "缩小图片 (-)";
            this.tsZoomOut.Click += new System.EventHandler(this.tsZoomOut_Click);
            // 
            // tsActual
            // 
            this.tsActual.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsActual.Name = "tsActual";
            this.tsActual.Size = new System.Drawing.Size(54, 37);
            this.tsActual.Text = "1:1";
            this.tsActual.ToolTipText = "按实际大小显示 (100%)";
            this.tsActual.Click += new System.EventHandler(this.tsActual_Click);
            // 
            // tsFit
            // 
            this.tsFit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsFit.Name = "tsFit";
            this.tsFit.Size = new System.Drawing.Size(115, 37);
            this.tsFit.Text = "适应窗口";
            this.tsFit.ToolTipText = "缩放到刚好完整显示整张图片";
            this.tsFit.Click += new System.EventHandler(this.tsFit_Click);
            // 
            // tsSep2
            // 
            this.tsSep2.Name = "tsSep2";
            this.tsSep2.Size = new System.Drawing.Size(6, 42);
            // 
            // tsRotateL
            // 
            this.tsRotateL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsRotateL.Name = "tsRotateL";
            this.tsRotateL.Size = new System.Drawing.Size(67, 37);
            this.tsRotateL.Text = "左旋";
            this.tsRotateL.ToolTipText = "逆时针旋转 90 度";
            this.tsRotateL.Click += new System.EventHandler(this.tsRotateL_Click);
            // 
            // tsRotateR
            // 
            this.tsRotateR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsRotateR.Name = "tsRotateR";
            this.tsRotateR.Size = new System.Drawing.Size(67, 37);
            this.tsRotateR.Text = "右旋";
            this.tsRotateR.ToolTipText = "顺时针旋转 90 度";
            this.tsRotateR.Click += new System.EventHandler(this.tsRotateR_Click);
            // 
            // tsSep3
            // 
            this.tsSep3.Name = "tsSep3";
            this.tsSep3.Size = new System.Drawing.Size(6, 42);
            // 
            // tsPrev
            // 
            this.tsPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsPrev.Name = "tsPrev";
            this.tsPrev.Size = new System.Drawing.Size(91, 37);
            this.tsPrev.Text = "上一张";
            this.tsPrev.ToolTipText = "浏览同目录的上一张图片 (←)";
            this.tsPrev.Click += new System.EventHandler(this.tsPrev_Click);
            // 
            // tsNext
            // 
            this.tsNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsNext.Name = "tsNext";
            this.tsNext.Size = new System.Drawing.Size(91, 37);
            this.tsNext.Text = "下一张";
            this.tsNext.ToolTipText = "浏览同目录的下一张图片 (→)";
            this.tsNext.Click += new System.EventHandler(this.tsNext_Click);
            // 
            // tsFull
            // 
            this.tsFull.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsFull.Name = "tsFull";
            this.tsFull.Size = new System.Drawing.Size(67, 37);
            this.tsFull.Text = "全屏";
            this.tsFull.ToolTipText = "全屏 / 退出全屏 (F11 或双击图片)";
            this.tsFull.Click += new System.EventHandler(this.tsFull_Click);
            // 
            // panelContainer
            // 
            this.panelContainer.AutoScroll = true;
            this.panelContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelContainer.Controls.Add(this.pictureBox1);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 42);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1064, 541);
            this.panelContainer.TabIndex = 1;
            this.panelContainer.Resize += new System.EventHandler(this.panelContainer_Resize);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1064, 541);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.checkBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 583);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1064, 60);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(3, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(142, 22);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "拉伸填满窗口";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.closeButton);
            this.flowLayoutPanel1.Controls.Add(this.backgroundButton);
            this.flowLayoutPanel1.Controls.Add(this.clearButton);
            this.flowLayoutPanel1.Controls.Add(this.showButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(240, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(6, 14, 6, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(824, 60);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // closeButton
            // 
            this.closeButton.AutoSize = true;
            this.closeButton.Location = new System.Drawing.Point(734, 17);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 28);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "关闭";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // backgroundButton
            // 
            this.backgroundButton.AutoSize = true;
            this.backgroundButton.Location = new System.Drawing.Point(620, 17);
            this.backgroundButton.Name = "backgroundButton";
            this.backgroundButton.Size = new System.Drawing.Size(108, 28);
            this.backgroundButton.TabIndex = 1;
            this.backgroundButton.Text = "设置背景色";
            this.backgroundButton.UseVisualStyleBackColor = true;
            this.backgroundButton.Click += new System.EventHandler(this.backgroundButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.AutoSize = true;
            this.clearButton.Location = new System.Drawing.Point(524, 17);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(90, 28);
            this.clearButton.TabIndex = 2;
            this.clearButton.Text = "清除图片";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // showButton
            // 
            this.showButton.AutoSize = true;
            this.showButton.Location = new System.Drawing.Point(428, 17);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(90, 28);
            this.showButton.TabIndex = 3;
            this.showButton.Text = "显示图片";
            this.showButton.UseVisualStyleBackColor = true;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssStatus,
            this.tssSize,
            this.tssZoom});
            this.statusStrip1.Location = new System.Drawing.Point(0, 643);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1064, 40);
            this.statusStrip1.TabIndex = 3;
            // 
            // tssStatus
            // 
            this.tssStatus.Name = "tssStatus";
            this.tssStatus.Size = new System.Drawing.Size(779, 33);
            this.tssStatus.Spring = true;
            this.tssStatus.Text = "请打开一张图片开始浏览";
            this.tssStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tssSize
            // 
            this.tssSize.AutoSize = false;
            this.tssSize.Name = "tssSize";
            this.tssSize.Size = new System.Drawing.Size(180, 33);
            this.tssSize.Text = "尺寸: --";
            this.tssSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tssZoom
            // 
            this.tssZoom.AutoSize = false;
            this.tssZoom.Name = "tssZoom";
            this.tssZoom.Size = new System.Drawing.Size(90, 33);
            this.tssZoom.Text = "缩放: --";
            this.tssZoom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "图像文件|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tif;*.tiff;*.ico|JPEG 图片|*.jpg;*.jpeg|PNG 图" +
    "片|*.png|BMP 图片|*.bmp|GIF 图片|*.gif|所有文件|*.*";
            this.openFileDialog1.InitialDirectory = "C:\\Users\\17901\\Pictures";
            this.openFileDialog1.Title = "请选择要打开的图片";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // colorDialog1
            // 
            this.colorDialog1.AnyColor = true;
            this.colorDialog1.FullOpen = true;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 683);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(720, 480);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图片查看器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsOpen;
        private System.Windows.Forms.ToolStripSeparator tsSep1;
        private System.Windows.Forms.ToolStripButton tsZoomIn;
        private System.Windows.Forms.ToolStripButton tsZoomOut;
        private System.Windows.Forms.ToolStripButton tsActual;
        private System.Windows.Forms.ToolStripButton tsFit;
        private System.Windows.Forms.ToolStripSeparator tsSep2;
        private System.Windows.Forms.ToolStripButton tsRotateL;
        private System.Windows.Forms.ToolStripButton tsRotateR;
        private System.Windows.Forms.ToolStripSeparator tsSep3;
        private System.Windows.Forms.ToolStripButton tsPrev;
        private System.Windows.Forms.ToolStripButton tsNext;
        private System.Windows.Forms.ToolStripButton tsFull;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button backgroundButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button showButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssStatus;
        private System.Windows.Forms.ToolStripStatusLabel tssSize;
        private System.Windows.Forms.ToolStripStatusLabel tssZoom;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}
