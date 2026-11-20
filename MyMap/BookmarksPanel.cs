using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using WeifenLuo.WinFormsUI.Docking;
using ESRI.ArcGIS.Geometry;

namespace MyMap
{
    /// <summary>
    /// 书签停靠面板（ArcGIS Pro 的 Bookmarks 视图）：
    /// 常驻列出地图书签，双击转到对应视图范围，支持添加当前视图与删除书签。
    /// </summary>
    public partial class BookmarksPanel : DockContent
    {
        /// <summary>目标地图控件，由主窗体在创建面板时注入。</summary>
        public AxMapControl MainMap { get; set; }

        /// <summary>书签列表，与界面列表项一一对应。</summary>
        private readonly List<ISpatialBookmark> _bookmarks = new List<ISpatialBookmark>();

        /// <summary>书签自动编号（用于命名）。</summary>
        private int _bookmarkSequence;

        /// <summary>书签发生变化（添加/删除）时触发，供主窗体记录日志。</summary>
        public event Action<string> BookmarksChanged;

        /// <summary>
        /// 创建书签停靠面板。
        /// </summary>
        public BookmarksPanel()
        {
            InitializeComponent();
        }

        #region 书签加载与操作

        /// <summary>
        /// 刷新书签列表。
        /// </summary>
        public void RefreshBookmarks()
        {
            _bookmarks.Clear();
            lstBookmarks.Items.Clear();

            if (MainMap == null)
            {
                return;
            }

            IMapBookmarks mapBookmarks = (IMapBookmarks)MainMap.Map;
            IEnumSpatialBookmark enumBookmarks = mapBookmarks.Bookmarks;
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
        /// 双击书签：主地图转到对应视图范围。
        /// </summary>
        private void lstBookmarks_DoubleClick(object sender, EventArgs e)
        {
            if (lstBookmarks.SelectedIndex < 0 || MainMap == null)
            {
                return;
            }

            _bookmarks[lstBookmarks.SelectedIndex].ZoomTo(MainMap.Map);
            MainMap.ActiveView.Refresh();
        }

        /// <summary>
        /// 添加当前视图：把主地图当前范围保存为新书签。
        /// </summary>
        private void btnAddBookmark_Click(object sender, EventArgs e)
        {
            if (MainMap == null)
            {
                return;
            }

            IMapBookmarks mapBookmarks = (IMapBookmarks)MainMap.Map;
            IAOIBookmark bookmark = new AOIBookmark();
            bookmark.Name = string.Format("书签{0}", ++_bookmarkSequence);
            bookmark.Location = MainMap.ActiveView.Extent;
            mapBookmarks.AddBookmark(bookmark);

            RefreshBookmarks();
            lstBookmarks.SelectedIndex = lstBookmarks.Items.Count - 1;
            RaiseChanged("已添加书签：" + bookmark.Name);
        }

        /// <summary>
        /// 删除选中的书签。
        /// </summary>
        private void btnDeleteBookmark_Click(object sender, EventArgs e)
        {
            if (lstBookmarks.SelectedIndex < 0)
            {
                MessageBox.Show("请先选择一个书签！");
                return;
            }

            if (MainMap == null)
            {
                return;
            }

            ISpatialBookmark bookmark = _bookmarks[lstBookmarks.SelectedIndex];
            ((IMapBookmarks)MainMap.Map).RemoveBookmark(bookmark);
            RefreshBookmarks();
            RaiseChanged("已删除书签：" + bookmark.Name);
        }

        /// <summary>
        /// 触发书签变化事件。
        /// </summary>
        /// <param name="message">描述文本。</param>
        private void RaiseChanged(string message)
        {
            if (BookmarksChanged != null)
            {
                BookmarksChanged(message);
            }
        }

        #endregion
    }
}
