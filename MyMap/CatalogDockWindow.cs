using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WeifenLuo.WinFormsUI.Docking;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geodatabase;

namespace MyMap
{
    /// <summary>
    /// 数据目录停靠面板（ArcGIS Pro 的 Catalog 视图）：
    /// 以树形浏览本机磁盘目录，双击 shp / lyr / mxd 文件加载到当前地图；
    /// 目录节点懒加载（展开时才枚举子目录与数据文件）。
    /// </summary>
    public partial class CatalogDockWindow : DockContent
    {
        /// <summary>双击加载文件后触发，供主窗体刷新状态与鹰眼。</summary>
        public event Action<string> FileLoaded;

        /// <summary>可加载的数据文件扩展名。</summary>
        private static readonly string[] DataExtensions = { ".shp", ".lyr", ".mxd" };

        /// <summary>
        /// 创建数据目录停靠面板。
        /// </summary>
        public CatalogDockWindow()
        {
            InitializeComponent();
            BuildDriveNodes();
        }

        #region 树构建

        /// <summary>
        /// 重建目录树：根节点"此电脑"下挂全部本地驱动器。
        /// </summary>
        private void BuildDriveNodes()
        {
            treeCatalog.Nodes.Clear();

            TreeNode root = new TreeNode("此电脑");
            root.Tag = "root";
            try
            {
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    TreeNode driveNode = new TreeNode(drive.Name);
                    driveNode.Tag = drive.Name;
                    driveNode.Nodes.Add(new TreeNode()); // 占位，展开时枚举
                    root.Nodes.Add(driveNode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("枚举驱动器失败：" + ex.Message);
            }

            treeCatalog.Nodes.Add(root);
            root.Expand();
        }

        /// <summary>
        /// 节点首次展开：枚举该目录的子目录与数据文件（懒加载）。
        /// </summary>
        private void treeCatalog_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            string path = Convert.ToString(e.Node.Tag);
            if (string.IsNullOrEmpty(path) || path == "root" || e.Node.Nodes.Count != 1)
            {
                return; // 已加载过，或非目录节点
            }

            e.Node.Nodes.Clear();
            try
            {
                // 子目录
                foreach (string dir in Directory.GetDirectories(path))
                {
                    TreeNode dirNode = new TreeNode(Path.GetFileName(dir));
                    dirNode.Tag = dir;
                    try
                    {
                        if (Directory.GetDirectories(dir).Length > 0 ||
                            Directory.GetFiles(dir, "*.shp").Length > 0 ||
                            Directory.GetFiles(dir, "*.lyr").Length > 0 ||
                            Directory.GetFiles(dir, "*.mxd").Length > 0)
                        {
                            dirNode.Nodes.Add(new TreeNode()); // 占位
                        }
                    }
                    catch
                    {
                        // 无权限访问的目录不提供展开
                    }
                    e.Node.Nodes.Add(dirNode);
                }

                // 数据文件
                foreach (string file in Directory.GetFiles(path))
                {
                    string extension = Path.GetExtension(file).ToLower();
                    if (DataExtensions.Contains(extension))
                    {
                        TreeNode fileNode = new TreeNode(Path.GetFileName(file));
                        fileNode.Tag = file;
                        e.Node.Nodes.Add(fileNode);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("枚举目录失败：" + ex.Message);
            }
        }

        #endregion

        #region 文件加载

        /// <summary>
        /// 双击节点：数据文件加载到当前地图（shp / lyr / mxd）。
        /// </summary>
        private void treeCatalog_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string file = Convert.ToString(e.Node.Tag);
            if (string.IsNullOrEmpty(file) || !File.Exists(file))
            {
                return;
            }

            string extension = Path.GetExtension(file).ToLower();
            try
            {
                if (extension == ".shp")
                {
                    LoadShapefile(file);
                }
                else if (extension == ".lyr")
                {
                    LoadLayerFile(file);
                }
                else if (extension == ".mxd")
                {
                    LoadMapDocument(file);
                }
                else
                {
                    return;
                }

                if (FileLoaded != null)
                {
                    FileLoaded(file);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载数据失败：" + ex.Message);
            }
        }

        /// <summary>加载 shapefile 图层。</summary>
        /// <param name="file">.shp 文件完整路径。</param>
        private void LoadShapefile(string file)
        {
            string folder = Path.GetDirectoryName(file);
            string fileName = Path.GetFileName(file);

            IWorkspaceFactory workspaceFactory = new ShapefileWorkspaceFactory();
            IFeatureWorkspace featureWorkspace = (IFeatureWorkspace)workspaceFactory.OpenFromFile(folder, 0);
            IFeatureClass featureClass = featureWorkspace.OpenFeatureClass(fileName);

            IFeatureLayer featureLayer = new FeatureLayer();
            featureLayer.FeatureClass = featureClass;
            featureLayer.Name = featureClass.AliasName;
            MainMap.AddLayer((ILayer)featureLayer);
            MainMap.ActiveView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGraphics, null, null);
        }

        /// <summary>加载图层文件（.lyr）。</summary>
        /// <param name="file">.lyr 文件完整路径。</param>
        private void LoadLayerFile(string file)
        {
            MainMap.AddLayerFromFile(file, 0);
            MainMap.ActiveView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewAll, null, null);
        }

        /// <summary>加载地图文档（.mxd）。</summary>
        /// <param name="file">.mxd 文件完整路径。</param>
        private void LoadMapDocument(string file)
        {
            MainMap.LoadMxFile(file, null, null);
            MainMap.ActiveView.Refresh();
        }

        /// <summary>
        /// 目标地图控件，由主窗体在创建面板时注入。
        /// </summary>
        public AxMapControl MainMap { get; set; }

        /// <summary>
        /// 刷新目录树。
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BuildDriveNodes();
        }

        #endregion
    }
}
