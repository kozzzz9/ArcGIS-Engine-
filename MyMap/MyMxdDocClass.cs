using System;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;

namespace MyMap
{
    /// <summary>
    /// Mxd 地图文档操作类。
    /// 按实习十二扩展内容要求，使用非静态类封装非静态方法，
    /// 实现地图文档的新建、打开、保存与另存为功能。
    /// 使用时先创建本类实例（如主窗体中的 _mxdDoc 字段），再调用相应方法。
    /// </summary>
    public class MyMxdDocClass
    {
        /// <summary>当前操作的地图文档对象（首次访问时创建）。</summary>
        private IMapDocument mapDocument;

        /// <summary>
        /// 获取地图文档对象；首次访问时才创建 COM 组件。
        /// 必须在 ArcGIS 运行时绑定与许可初始化之后创建，
        /// 因此不能放在字段初始化器或构造函数中直接实例化。
        /// </summary>
        private IMapDocument MapDocumentInstance
        {
            get
            {
                if (mapDocument == null)
                {
                    mapDocument = new MapDocument();
                }
                return mapDocument;
            }
        }

        /// <summary>
        /// 关闭当前已打开的地图文档；尚未打开时忽略异常。
        /// </summary>
        private void CloseQuietly()
        {
            if (mapDocument == null)
            {
                return;
            }

            try
            {
                MapDocumentInstance.Close();
            }
            catch
            {
                // 尚未打开任何文档时 Close 会失败，此处忽略即可
            }
        }

        /// <summary>
        /// 新建地图文档：把空白文档保存到指定路径并加载到地图控件。
        /// 之后向控件添加的图层会直接写入该文档的地图对象，可随时保存。
        /// </summary>
        /// <param name="axMapControl">目标地图控件。</param>
        public void newMapDoc(AxMapControl axMapControl)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "新建地图文档";
            saveFileDialog.Filter = "Mxd文档（*.mxd）|*.mxd";
            saveFileDialog.OverwritePrompt = true;
            DialogResult dialogResult = saveFileDialog.ShowDialog();

            if (dialogResult != DialogResult.OK)
            {
                return;
            }

            CloseQuietly();
            MapDocumentInstance.New(saveFileDialog.FileName);
            MapDocumentInstance.Open(saveFileDialog.FileName);

            // 把文档中的地图对象交给地图控件，后续图层添加直接反映在文档中
            axMapControl.Map = MapDocumentInstance.get_Map(0);
            axMapControl.ActiveView.Refresh();
            axMapControl.ActiveView.ScreenDisplay.UpdateWindow();
        }

        /// <summary>
        /// 打开地图文档：校验后加载到地图控件（mxd 含多个数据框时加载第一个）。
        /// </summary>
        /// <param name="axMapControl">目标地图控件。</param>
        public void openMapDoc(AxMapControl axMapControl)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "打开地图文档";
            openFileDialog.Filter = "Mxd文档（*.mxd）|*.mxd";
            DialogResult dialogResult = openFileDialog.ShowDialog();

            if (dialogResult != DialogResult.OK)
            {
                return;
            }

            // 打开地图文档，并加载到 MapControl 控件
            if (MapDocumentInstance.get_IsMapDocument(openFileDialog.FileName))
            {
                CloseQuietly();
                MapDocumentInstance.Open(openFileDialog.FileName);

                // 用控件自带的 LoadMxFile 完成实际加载：由控件自行初始化
                // 渲染缓存，避免直接把文档地图对象赋给控件后部分图层
                //（如海洋格网层）只绘制一部分的问题。文档对象保持打开，
                // 供之后的保存操作使用。
                axMapControl.LoadMxFile(openFileDialog.FileName, null, null);
                axMapControl.ActiveView.Refresh();
                axMapControl.ActiveView.ScreenDisplay.UpdateWindow();
            }
            else
            {
                MessageBox.Show("所选文件不是有效的地图文档！");
            }
        }

        /// <summary>
        /// 保存地图文档：把地图控件当前内容写入已打开的文档。
        /// </summary>
        /// <param name="axMapControl">目标地图控件。</param>
        public void saveMapDoc(AxMapControl axMapControl)
        {
            // 尚未通过新建或打开建立文档时无法直接保存
            if (string.IsNullOrEmpty(MapDocumentInstance.DocumentFilename))
            {
                MessageBox.Show("当前没有已打开的地图文档，请先新建或打开，或使用另存为！");
                return;
            }

            if (MapDocumentInstance.get_IsReadOnly(MapDocumentInstance.DocumentFilename))
            {
                MessageBox.Show("地图文档只读！");
                return;
            }

            // 保存前把控件当前地图写入文档，保证直接添加的图层也能保存
            MapDocumentInstance.ReplaceContents(axMapControl.Map as IMxdContents);
            MapDocumentInstance.Save();
            MessageBox.Show("保存成功！");
        }

        /// <summary>
        /// 地图文档另存为：把控件当前地图保存为新的 Mxd 文档。
        /// </summary>
        /// <param name="axMapControl">目标地图控件。</param>
        public void SaveAsMapDoc(AxMapControl axMapControl)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "地图文档另存为";
            saveFileDialog.Filter = "Mxd文档（*.mxd）|*.mxd";
            saveFileDialog.OverwritePrompt = true;
            DialogResult dialogResult = saveFileDialog.ShowDialog();

            if (dialogResult != DialogResult.OK)
            {
                return;
            }

            if (MapDocumentInstance.get_IsReadOnly(saveFileDialog.FileName))
            {
                MessageBox.Show("目标文件只读！");
                return;
            }

            // 把控件当前地图写入文档后另存，SaveAs 已把当前文档切换到新路径
            MapDocumentInstance.ReplaceContents(axMapControl.Map as IMxdContents);
            MapDocumentInstance.SaveAs(saveFileDialog.FileName, true, false);
            MessageBox.Show("保存成功！");
        }
    }
}
