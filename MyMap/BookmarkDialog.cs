using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;

namespace MyMap
{
    /// <summary>
    /// 书签管理对话框。
    /// 列出地图中的全部书签，支持转到指定书签与删除书签。
    /// </summary>
    public partial class BookmarkDialog : Form
    {
        #region 私有字段

        /// <summary>地图的书签集合。</summary>
        private readonly IMapBookmarks _mapBookmarks;

        /// <summary>书签列表，与界面列表项一一对应。</summary>
        private readonly List<ISpatialBookmark> _bookmarks = new List<ISpatialBookmark>();

        #endregion

        #region 公共属性

        /// <summary>用户选择要转到的书签。</summary>
        public ISpatialBookmark SelectedBookmark { get; private set; }

        #endregion

        #region 构造函数

        /// <summary>
        /// 创建书签管理对话框。
        /// </summary>
        /// <param name="mapBookmarks">地图的书签集合。</param>
        public BookmarkDialog(IMapBookmarks mapBookmarks)
        {
            _mapBookmarks = mapBookmarks;

            InitializeComponent();
            LoadBookmarks();
        }

        #endregion

        #region 书签加载与操作

        /// <summary>
        /// 读取地图中的全部书签并填充列表。
        /// </summary>
        private void LoadBookmarks()
        {
            _bookmarks.Clear();
            lstBookmarks.Items.Clear();

            if (_mapBookmarks == null)
            {
                return;
            }

            IEnumSpatialBookmark enumBookmarks = _mapBookmarks.Bookmarks;
            enumBookmarks.Reset();
            ISpatialBookmark bookmark = enumBookmarks.Next();
            while (bookmark != null)
            {
                _bookmarks.Add(bookmark);
                lstBookmarks.Items.Add(bookmark.Name);
                bookmark = enumBookmarks.Next();
            }
        }

        /// <summary>
        /// 转到：返回用户选择的书签并由主窗体缩放过去。
        /// </summary>
        private void btnGo_Click(object sender, EventArgs e)
        {
            if (lstBookmarks.SelectedIndex < 0)
            {
                MessageBox.Show("请先选择一个书签！");
                return;
            }

            SelectedBookmark = _bookmarks[lstBookmarks.SelectedIndex];
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// 删除：从地图中移除选中的书签并刷新列表。
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstBookmarks.SelectedIndex < 0)
            {
                MessageBox.Show("请先选择一个书签！");
                return;
            }

            ISpatialBookmark bookmark = _bookmarks[lstBookmarks.SelectedIndex];
            if (_mapBookmarks != null)
            {
                _mapBookmarks.RemoveBookmark(bookmark);
            }
            LoadBookmarks();
        }

        /// <summary>
        /// 关闭：直接关闭对话框。
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion
    }
}
