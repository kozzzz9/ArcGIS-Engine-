using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;

namespace MyMap
{
    /// <summary>
    /// 选择要素停靠面板（ArcGIS Pro 的 Select 视图）：
    /// 实时列出当前地图选中的要素（OID 与标注字段值），
    /// 双击行在地图上闪烁定位对应要素。
    /// </summary>
    public partial class SelectionPanel : DockContent
    {
        /// <summary>目标地图控件，由主窗体在创建面板时注入。</summary>
        public AxMapControl MainMap { get; set; }

        /// <summary>
        /// 创建选择要素面板。
        /// </summary>
        public SelectionPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 刷新面板：读取当前地图的选中要素集合填充表格。
        /// </summary>
        public void RefreshSelection()
        {
            if (MainMap == null)
            {
                return;
            }

            DataTable table = new DataTable();
            table.Columns.Add("OID");
            table.Columns.Add("要素");

            // 取全部可见矢量图层中的第一个文本字段值作为要素描述
            List<IFeatureLayer> textLayers = new List<IFeatureLayer>();
            for (int i = 0; i < MainMap.Map.LayerCount; i++)
            {
                IFeatureLayer featureLayer = MainMap.Map.get_Layer(i) as IFeatureLayer;
                if (featureLayer != null && featureLayer.Visible)
                {
                    textLayers.Add(featureLayer);
                }
            }

            IEnumFeature enumFeature = MainMap.Map.FeatureSelection as IEnumFeature;
            if (enumFeature != null)
            {
                enumFeature.Reset();
                IFeature feature = enumFeature.Next();
                int shown = 0;
                while (feature != null)
                {
                    DataRow row = table.NewRow();
                    row["OID"] = feature.OID.ToString();
                    row["要素"] = DescribeFeature(feature, textLayers);
                    table.Rows.Add(row);

                    feature = enumFeature.Next();
                    shown++;
                    if (shown >= 200)
                    {
                        break; // 大选择集只列前 200 条，避免面板卡顿
                    }
                }
            }

            dgvSelection.DataSource = table;
            lblSelectionCount.Text = "选中要素：" + MainMap.Map.SelectionCount
                + (MainMap.Map.SelectionCount > 200 ? "（列表显示前 200 条）" : string.Empty);
        }

        /// <summary>
        /// 生成要素描述文本：优先取该要素所属图层的第一个文本字段值。
        /// </summary>
        /// <param name="feature">要素。</param>
        /// <param name="featureLayers">可见矢量图层列表。</param>
        private static string DescribeFeature(IFeature feature, List<IFeatureLayer> featureLayers)
        {
            // 通过 OID 与图层要素类匹配所属图层
            foreach (IFeatureLayer featureLayer in featureLayers)
            {
                IFeatureClass featureClass = featureLayer.FeatureClass;
                if (featureClass == null || featureClass.ShapeType != feature.Shape.GeometryType)
                {
                    continue;
                }

                int fieldIndex = GetFirstTextFieldIndex(featureClass);
                if (fieldIndex >= 0)
                {
                    object value = feature.get_Value(fieldIndex);
                    if (value != null && value != System.DBNull.Value)
                    {
                        return value.ToString();
                    }
                }
            }
            return feature.Class.AliasName;
        }

        /// <summary>
        /// 获取要素类第一个文本字段的位置；没有文本字段时返回 -1。
        /// </summary>
        private static int GetFirstTextFieldIndex(IFeatureClass featureClass)
        {
            IFields fields = featureClass.Fields;
            for (int i = 0; i < fields.FieldCount; i++)
            {
                IField field = fields.get_Field(i);
                if (field.Type == esriFieldType.esriFieldTypeString)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// 双击行：在地图上闪烁定位对应要素。
        /// </summary>
        private void dgvSelection_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || MainMap == null)
            {
                return;
            }

            object oidValue = dgvSelection.Rows[e.RowIndex].Cells["OID"].Value;
            if (oidValue == null)
            {
                return;
            }

            int oid;
            if (!int.TryParse(oidValue.ToString(), out oid))
            {
                return;
            }

            IEnumFeature enumFeature = MainMap.Map.FeatureSelection as IEnumFeature;
            if (enumFeature == null)
            {
                return;
            }

            enumFeature.Reset();
            IFeature feature = enumFeature.Next();
            while (feature != null)
            {
                if (feature.OID == oid && feature.Shape != null && !feature.Shape.IsEmpty)
                {
                    MainMap.FlashShape(feature.Shape, 3, 400, UniqueValueRenderHelper.CreateFlashSymbol(feature.Shape));
                    return;
                }
                feature = enumFeature.Next();
            }
        }
    }
}
