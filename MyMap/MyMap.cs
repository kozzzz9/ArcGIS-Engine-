using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geodatabase;
using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyMap
{
    public partial class MyMap : Form
    {
        public MyMap()
        {
            ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.EngineOrDesktop);
            InitializeComponent();
        }

        private void MyMap_Load(object sender, EventArgs e)
        {

        }

        private void axToolbarControl1_OnMouseDown(object sender, ESRI.ArcGIS.Controls.IToolbarControlEvents_OnMouseDownEvent e)
        {

        }

        private void addVectorLayerMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "shapefile文件（*.shp）|*.shp";

            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult != DialogResult.OK)
            {
                return;
            }

            string path = openFileDialog.FileName;
            string folder = System.IO.Path.GetDirectoryName(path);
            string fileName = System.IO.Path.GetFileName(path);

            IWorkspaceFactory workspaceFactory = new ShapefileWorkspaceFactory();
            IWorkspace workspace = workspaceFactory.OpenFromFile(folder, 0);
            if (workspace == null)
            {
                MessageBox.Show("无法打开该工作空间！");
                return;
            }
            IFeatureWorkspace featureWorkspace = workspace as IFeatureWorkspace;
            IFeatureClass featureClass = featureWorkspace.OpenFeatureClass(fileName);
            if (featureClass == null)
            {
                MessageBox.Show("无法打开该矢量数据集！");
                return;
            }
            IFeatureLayer featureLayer = new FeatureLayer();
            featureLayer.FeatureClass = featureClass;
            featureLayer.Name = featureClass.AliasName;
            ILayer layer = featureLayer as ILayer;
            axMapControl1.Map.AddLayer(layer);
            axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        private void addRasterLayerMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // 支持常见栅格格式
            openFileDialog.Filter = "栅格影像(*.tif;*.tiff;*.img;*.jpg;*.png)|*.tif;*.tiff;*.img;*.jpg;*.png";
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult != DialogResult.OK)
            {
                return;
            }
            string path = openFileDialog.FileName;
            string folder = System.IO.Path.GetDirectoryName(path);
            string fileName = System.IO.Path.GetFileName(path);

            IRasterLayer rasterLayer = new RasterLayer();
            IWorkspaceFactory workspaceFactory = new RasterWorkspaceFactory();
            IWorkspace workspace = workspaceFactory.OpenFromFile(folder, 0);
            IRasterWorkspace rasterWorkspace = workspace as IRasterWorkspace;
            IRasterDataset rasterDataset = null;

            bool loadSuccess = false;
            if (rasterWorkspace != null)
            {
                rasterDataset = rasterWorkspace.OpenRasterDataset(fileName);
                if (rasterDataset != null)
                {
                    rasterLayer.CreateFromDataset(rasterDataset);
                    loadSuccess = true;
                }
            }

            if (!loadSuccess)
            {
                try
                {
                    rasterLayer.CreateFromFilePath(path);
                    loadSuccess = true;
                }
                catch
                {
                    MessageBox.Show("栅格文件打开失败！");
                    return;
                }
            }

            rasterLayer.Name = fileName;
            ILayer layer = rasterLayer as ILayer;
            if (layer == null)
            {
                MessageBox.Show("栅格图层转换失败！");
                return;
            }
            axMapControl1.Map.AddLayer(layer);
            axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewAll, null, null);
        }
    }
}
