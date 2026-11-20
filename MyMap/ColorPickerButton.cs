using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyMapControls
{
    /// <summary>
    /// 颜色选择按钮：点击弹出系统颜色选择对话框，并显示当前颜色。
    /// </summary>
    public class ColorPickerButton : Button
    {
        private Color _color = System.Drawing.Color.Red;

        public ColorPickerButton()
        {
            Text = string.Empty;
            BackColor = System.Drawing.Color.Red;
            FlatStyle = FlatStyle.Flat;
            UseVisualStyleBackColor = false;
        }

        /// <summary>
        /// 当前选择的颜色。
        /// </summary>
        public Color Color
        {
            get { return _color; }
            set
            {
                _color = value;
                BackColor = value;
                if (ColorChanged != null)
                {
                    ColorChanged(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// 颜色变化时触发的事件。
        /// </summary>
        public event EventHandler ColorChanged;

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            using (ColorDialog dialog = new ColorDialog())
            {
                dialog.Color = _color;
                dialog.FullOpen = true;
                if (dialog.ShowDialog(FindForm()) == DialogResult.OK)
                {
                    Color = dialog.Color;
                }
            }
        }
    }
}
