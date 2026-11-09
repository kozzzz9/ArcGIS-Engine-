namespace MyMap
{
    partial class CoordinateLocationDialog
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
            this.lblX = new System.Windows.Forms.Label();
            this.numX = new System.Windows.Forms.NumericUpDown();
            this.lblY = new System.Windows.Forms.Label();
            this.numY = new System.Windows.Forms.NumericUpDown();
            this.lblTip = new System.Windows.Forms.Label();
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).BeginInit();
            this.tlpMain.SuspendLayout();
            this.flpButtons.SuspendLayout();
            this.SuspendLayout();
            //
            // tlpMain
            //
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.lblX, 0, 0);
            this.tlpMain.Controls.Add(this.numX, 1, 0);
            this.tlpMain.Controls.Add(this.lblY, 0, 1);
            this.tlpMain.Controls.Add(this.numY, 1, 1);
            this.tlpMain.Controls.Add(this.lblTip, 0, 2);
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
            this.tlpMain.Size = new System.Drawing.Size(430, 175);
            this.tlpMain.TabIndex = 0;
            //
            // lblX
            //
            this.lblX.AutoSize = true;
            this.lblX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblX.Location = new System.Drawing.Point(15, 19);
            this.lblX.Name = "lblX";
            this.lblX.Text = "X：";
            this.lblX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // numX
            //
            this.numX.DecimalPlaces = 4;
            this.numX.Dock = System.Windows.Forms.DockStyle.Left;
            this.numX.Location = new System.Drawing.Point(103, 16);
            this.numX.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numX.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
            this.numX.Name = "numX";
            this.numX.Size = new System.Drawing.Size(220, 21);
            this.numX.TabIndex = 1;
            //
            // lblY
            //
            this.lblY.AutoSize = true;
            this.lblY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblY.Location = new System.Drawing.Point(15, 46);
            this.lblY.Name = "lblY";
            this.lblY.Text = "Y：";
            this.lblY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // numY
            //
            this.numY.DecimalPlaces = 4;
            this.numY.Dock = System.Windows.Forms.DockStyle.Left;
            this.numY.Location = new System.Drawing.Point(103, 43);
            this.numY.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numY.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
            this.numY.Name = "numY";
            this.numY.Size = new System.Drawing.Size(220, 21);
            this.numY.TabIndex = 2;
            //
            // lblTip
            //
            this.lblTip.AutoSize = true;
            this.lblTip.ForeColor = System.Drawing.Color.Gray;
            this.tlpMain.SetColumnSpan(this.lblTip, 2);
            this.lblTip.Location = new System.Drawing.Point(15, 73);
            this.lblTip.Name = "lblTip";
            this.lblTip.Text = "提示：坐标为当前地图坐标系下的坐标。";
            //
            // flpButtons
            //
            this.tlpMain.SetColumnSpan(this.flpButtons, 2);
            this.flpButtons.Controls.Add(this.btnCancel);
            this.flpButtons.Controls.Add(this.btnOk);
            this.flpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpButtons.Location = new System.Drawing.Point(15, 95);
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.Size = new System.Drawing.Size(400, 32);
            //
            // btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(312, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 26);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // btnOk
            //
            this.btnOk.Location = new System.Drawing.Point(221, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 26);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "定位";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            //
            // CoordinateLocationDialog
            //
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(430, 175);
            this.Controls.Add(this.tlpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CoordinateLocationDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "坐标定位";
            ((System.ComponentModel.ISupportInitialize)(this.numX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).EndInit();
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.flpButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.NumericUpDown numX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.NumericUpDown numY;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}
