using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace ImageViewer
{
    /// <summary>
    /// 图片查看器主窗体：支持打开、缩放、旋转、翻页、全屏、拖拽等。
    /// </summary>
    public partial class Form1 : Form
    {
        #region 字段定义

        private Bitmap _sourceImage;          // 原始图片（未旋转）
        private Bitmap _displayImage;         // 应用旋转后用于显示的图片
        private float _zoom = 1.0f;           // 缩放系数，1.0 表示实际大小
        private RotateFlipType _rotation = RotateFlipType.RotateNoneFlipNone; // 当前旋转方式
        private bool _stretchMode;            // 是否处于“拉伸填满窗口”模式
        private bool _isFullscreen;           // 是否处于全屏状态
        private FormBorderStyle _prevBorderStyle;   // 进入全屏前的边框样式
        private FormWindowState _prevWindowState;   // 进入全屏前的窗口状态
        private string _currentPath;          // 当前打开的图片路径
        private List<string> _imageList = new List<string>(); // 同目录下的图片列表
        private int _currentIndex = -1;       // 当前图片在列表中的下标

        private const float MinZoom = 0.05f;  // 最小缩放
        private const float MaxZoom = 20f;    // 最大缩放

        // 支持的图片扩展名
        private static readonly string[] ImageExts =
        {
            ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".tif", ".tiff", ".ico"
        };

        #endregion

        /// <summary>构造函数</summary>
        public Form1()
        {
            InitializeComponent();
        }

        #region 窗体级事件

        /// <summary>窗体加载</summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateStatusBar("请打开一张图片开始浏览（可直接把图片拖到窗口）");
        }

        /// <summary>关闭前确认（避免误关闭）</summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                this, "确定要退出图片查看器吗？", "退出确认",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true; // 取消关闭
            }
        }

        /// <summary>窗体关闭后释放图片资源</summary>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            DisposeImages();
        }

        /// <summary>键盘快捷键</summary>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.O)
            {
                OpenImage();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus)
            {
                ZoomIn();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus)
            {
                ZoomOut();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Delete)
            {
                ClearImage();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Left)
            {
                Navigate(-1);
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Right)
            {
                Navigate(1);
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.F11)
            {
                ToggleFullscreen();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Escape && _isFullscreen)
            {
                ToggleFullscreen();
                e.SuppressKeyPress = true;
            }
        }

        /// <summary>拖拽进入：判断是否为文件</summary>
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        /// <summary>拖拽放下：加载图片</summary>
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (files != null && files.Length > 0 && IsImageFile(files[0]))
            {
                LoadImageFromPath(files[0]);
            }
        }

        #endregion

        #region 基本功能（显示 / 清除 / 背景色 / 关闭 / 拉伸）

        /// <summary>“显示图片”按钮：打开文件对话框并加载</summary>
        private void showButton_Click(object sender, EventArgs e)
        {
            OpenImage();
        }

        /// <summary>打开文件对话框确定后的回调（保留以供扩展）</summary>
        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // 实际的加载在 OpenImage() 中完成，这里保留事件占位。
        }

        /// <summary>“清除图片”按钮</summary>
        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearImage();
        }

        /// <summary>“设置背景色”按钮</summary>
        private void backgroundButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                pictureBox1.BackColor = colorDialog1.Color;
            }
        }

        /// <summary>“关闭”按钮</summary>
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>“拉伸填满窗口”复选框</summary>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            _stretchMode = checkBox1.Checked;
            RenderImage();
        }

        #endregion

        #region 工具栏与交互

        /// <summary>工具栏“打开”</summary>
        private void tsOpen_Click(object sender, EventArgs e)
        {
            OpenImage();
        }

        /// <summary>工具栏“放大”</summary>
        private void tsZoomIn_Click(object sender, EventArgs e)
        {
            ZoomIn();
        }

        /// <summary>工具栏“缩小”</summary>
        private void tsZoomOut_Click(object sender, EventArgs e)
        {
            ZoomOut();
        }

        /// <summary>工具栏“实际大小 1:1”</summary>
        private void tsActual_Click(object sender, EventArgs e)
        {
            SetZoom(1.0f);
        }

        /// <summary>工具栏“适应窗口”</summary>
        private void tsFit_Click(object sender, EventArgs e)
        {
            FitToWindow();
        }

        /// <summary>工具栏“向左旋转”</summary>
        private void tsRotateL_Click(object sender, EventArgs e)
        {
            RotateImage(RotateFlipType.Rotate270FlipNone);
        }

        /// <summary>工具栏“向右旋转”</summary>
        private void tsRotateR_Click(object sender, EventArgs e)
        {
            RotateImage(RotateFlipType.Rotate90FlipNone);
        }

        /// <summary>工具栏“上一张”</summary>
        private void tsPrev_Click(object sender, EventArgs e)
        {
            Navigate(-1);
        }

        /// <summary>工具栏“下一张”</summary>
        private void tsNext_Click(object sender, EventArgs e)
        {
            Navigate(1);
        }

        /// <summary>工具栏“全屏 / 退出全屏”</summary>
        private void tsFull_Click(object sender, EventArgs e)
        {
            ToggleFullscreen();
        }

        /// <summary>双击图片切换全屏</summary>
        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            ToggleFullscreen();
        }

        /// <summary>容器尺寸变化时（非拉伸模式）让图片重新居中</summary>
        private void panelContainer_Resize(object sender, EventArgs e)
        {
            if (!_stretchMode && _displayImage != null)
            {
                CenterPicture();
            }
        }

        #endregion

        #region 核心逻辑（加载与显示）

        /// <summary>打开文件对话框选择图片</summary>
        private void OpenImage()
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                LoadImageFromPath(openFileDialog1.FileName);
            }
        }

        /// <summary>从指定路径加载图片（带异常处理，失败不崩溃）</summary>
        private void LoadImageFromPath(string path)
        {
            try
            {
                Bitmap bmp = new Bitmap(path);   // 先加载，失败则进入 catch
                DisposeImages();

                _sourceImage = bmp;
                _rotation = RotateFlipType.RotateNoneFlipNone;
                _zoom = 1.0f;
                _currentPath = path;
                BuildImageList(path);

                if (checkBox1.Checked)
                    checkBox1.Checked = false;   // 加载新图时复位拉伸状态
                _stretchMode = false;

                BuildDisplayImage();
                RenderImage();

                string sizeInfo = string.Empty;
                try
                {
                    sizeInfo = string.Format("（{0} KB）", new FileInfo(path).Length / 1024);
                }
                catch { }

                UpdateStatusBar("已加载: " + Path.GetFileName(path) + sizeInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "无法打开该图片：\n" + ex.Message,
                    "打开失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                UpdateStatusBar("打开失败");
            }
        }

        /// <summary>枚举同目录下的图片，用于上一张 / 下一张</summary>
        private void BuildImageList(string path)
        {
            try
            {
                string dir = Path.GetDirectoryName(path);
                _imageList = Directory.GetFiles(dir)
                    .Where(IsImageFile)
                    .OrderBy(f => f, StringComparer.OrdinalIgnoreCase)
                    .ToList();
                _currentIndex = _imageList.FindIndex(
                    f => string.Equals(f, path, StringComparison.OrdinalIgnoreCase));
            }
            catch
            {
                _imageList = new List<string> { path };
                _currentIndex = 0;
            }
        }

        /// <summary>根据源图和旋转方式生成用于显示的图片</summary>
        private void BuildDisplayImage()
        {
            if (_sourceImage == null)
            {
                _displayImage = null;
                return;
            }

            Bitmap old = _displayImage;
            _displayImage = new Bitmap(_sourceImage);
            _displayImage.RotateFlip(_rotation);

            if (old != null && !ReferenceEquals(old, _displayImage))
                old.Dispose();
        }

        /// <summary>按当前模式（拉伸 / 缩放居中）刷新显示</summary>
        private void RenderImage()
        {
            if (_displayImage == null)
            {
                pictureBox1.Image = null;
                UpdateStatusBar();
                return;
            }

            if (_stretchMode)
            {
                // 拉伸模式：铺满容器，保持比例
                pictureBox1.Dock = DockStyle.Fill;
                pictureBox1.Location = new Point(0, 0);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                // 缩放模式：按系数设置实际像素尺寸，超出可滚动
                pictureBox1.Dock = DockStyle.None;
                int w = Math.Max(1, (int)Math.Round(_displayImage.Width * _zoom));
                int h = Math.Max(1, (int)Math.Round(_displayImage.Height * _zoom));
                pictureBox1.Size = new Size(w, h);
                pictureBox1.SizeMode = (w < 3 || h < 3)
                    ? PictureBoxSizeMode.Zoom
                    : PictureBoxSizeMode.Normal;
                CenterPicture();
            }

            pictureBox1.Image = _displayImage;
            UpdateStatusBar();
        }

        /// <summary>让图片在容器中居中（小于容器时）</summary>
        private void CenterPicture()
        {
            int x = Math.Max(0, (panelContainer.ClientSize.Width - pictureBox1.Width) / 2);
            int y = Math.Max(0, (panelContainer.ClientSize.Height - pictureBox1.Height) / 2);
            pictureBox1.Location = new Point(x, y);
        }

        /// <summary>设置缩放系数（自动退出拉伸模式）</summary>
        private void SetZoom(float zoom)
        {
            if (_displayImage == null) return;

            _zoom = zoom < MinZoom ? MinZoom : (zoom > MaxZoom ? MaxZoom : zoom);
            _stretchMode = false;

            if (checkBox1.Checked)
                checkBox1.Checked = false;

            RenderImage();
        }

        /// <summary>放大</summary>
        private void ZoomIn()
        {
            SetZoom(_zoom * 1.25f);
        }

        /// <summary>缩小</summary>
        private void ZoomOut()
        {
            SetZoom(_zoom / 1.25f);
        }

        /// <summary>适应窗口：计算刚好完整显示的缩放比</summary>
        private void FitToWindow()
        {
            if (_displayImage == null) return;

            float ratioW = panelContainer.ClientSize.Width / (float)_displayImage.Width;
            float ratioH = panelContainer.ClientSize.Height / (float)_displayImage.Height;
            _zoom = Math.Min(ratioW, ratioH);
            if (_zoom < MinZoom) _zoom = MinZoom;
            else if (_zoom > MaxZoom) _zoom = MaxZoom;

            _stretchMode = false;
            if (checkBox1.Checked)
                checkBox1.Checked = false;

            RenderImage();
        }

        #endregion

        #region 旋转 / 翻页 / 清除 / 全屏

        /// <summary>旋转图片（左旋或右旋 90 度）</summary>
        private void RotateImage(RotateFlipType type)
        {
            if (_displayImage == null) return;

            _rotation = type;
            BuildDisplayImage();
            RenderImage();
        }

        /// <summary>浏览同目录的上一张 / 下一张</summary>
        private void Navigate(int delta)
        {
            if (_imageList == null || _imageList.Count <= 1) return;

            int n = _imageList.Count;
            _currentIndex = ((_currentIndex + delta) % n + n) % n;   // 循环
            LoadImageFromPath(_imageList[_currentIndex]);
        }

        /// <summary>清除当前图片并复位状态</summary>
        private void ClearImage()
        {
            DisposeImages();
            pictureBox1.Image = null;
            pictureBox1.Dock = DockStyle.None;

            _sourceImage = null;
            _displayImage = null;
            _zoom = 1.0f;
            _rotation = RotateFlipType.RotateNoneFlipNone;
            _stretchMode = false;
            _currentPath = null;
            _imageList = new List<string>();
            _currentIndex = -1;

            UpdateStatusBar("图片已清除");
        }

        /// <summary>切换全屏 / 退出全屏</summary>
        private void ToggleFullscreen()
        {
            if (!_isFullscreen)
            {
                _prevBorderStyle = this.FormBorderStyle;
                _prevWindowState = this.WindowState;

                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                _isFullscreen = true;
                tsFull.Text = "退出全屏";
            }
            else
            {
                this.FormBorderStyle = _prevBorderStyle;
                this.WindowState = _prevWindowState;
                _isFullscreen = false;
                tsFull.Text = "全屏";
            }
        }

        #endregion

        #region 辅助方法

        /// <summary>判断文件是否为受支持的图片格式</summary>
        private bool IsImageFile(string path)
        {
            string ext = Path.GetExtension(path);
            return ImageExts.Any(x => string.Equals(x, ext, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>释放图片资源，避免内存泄漏</summary>
        private void DisposeImages()
        {
            if (_displayImage != null)
            {
                _displayImage.Dispose();
                _displayImage = null;
            }
            if (_sourceImage != null)
            {
                _sourceImage.Dispose();
                _sourceImage = null;
            }
        }

        /// <summary>更新底部状态栏（尺寸、缩放比例等）</summary>
        private void UpdateStatusBar(string message = null)
        {
            if (message != null)
                tssStatus.Text = message;

            if (_displayImage != null)
                tssSize.Text = string.Format("尺寸: {0} × {1} px", _displayImage.Width, _displayImage.Height);
            else
                tssSize.Text = "尺寸: --";

            if (_displayImage == null)
                tssZoom.Text = "缩放: --";
            else if (_stretchMode)
                tssZoom.Text = "缩放: 拉伸";
            else
                tssZoom.Text = string.Format("缩放: {0}%", (int)Math.Round(_zoom * 100));
        }

        #endregion
    }
}
