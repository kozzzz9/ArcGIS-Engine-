using System;
using System.Data;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;

namespace MyMap
{
    /// <summary>
    /// 要素属性表窗体：以表格形式展示指定矢量图层的全部属性。
    /// </summary>
    public partial class FeatureAttributeTable : Form
    {
        /// <summary>待展示属性的矢量图层。</summary>
        private readonly IFeatureLayer _featureLayer;

        /// <summary>
        /// 创建要素属性表窗体。
        /// </summary>
        /// <param name="featureLayer">待展示属性的矢量图层。</param>
        public FeatureAttributeTable(IFeatureLayer featureLayer)
        {
            _featureLayer = featureLayer;
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载时读取图层字段与要素，填充属性表格。
        /// </summary>
        private void FeatureAttributeTable_Load(object sender, EventArgs e)
        {
            if (_featureLayer == null)
            {
                return;
            }

            // 窗体标题带图层名，便于区分多个属性表
            Text = "属性表 - " + _featureLayer.Name;

            IFeatureClass featureClass = _featureLayer.FeatureClass;
            if (featureClass == null)
            {
                return;
            }

            DataTable table = new DataTable();
            IFields fields = featureClass.Fields;
            for (int i = 0; i < fields.FieldCount; i++)
            {
                IField field = fields.get_Field(i);
                DataColumn column = new DataColumn(field.Name);
                column.DataType = typeof(string);
                table.Columns.Add(column);
            }

            IFeatureCursor featureCursor = featureClass.Search(null, false);
            IFeature feature = featureCursor.NextFeature();
            while (feature != null)
            {
                DataRow row = table.NewRow();
                for (int i = 0; i < fields.FieldCount; i++)
                {
                    // 空值统一转换为空字符串，避免直接调用 ToString 抛出异常
                    row[i] = UniqueValueRenderHelper.FormatValue(feature.get_Value(i));
                }
                table.Rows.Add(row);
                feature = featureCursor.NextFeature();
            }

            dataGridView.DataSource = table;
            dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
    }
}
