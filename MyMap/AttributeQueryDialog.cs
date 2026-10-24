using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;

namespace MyMap
{
    /// <summary>
    /// 属性查询设置对话框。
    /// 选择待查询的矢量图层并输入 SQL 查询条件（如 NAME = '北京'），
    /// 确定后由主窗体按条件选择要素。
    /// </summary>
    public partial class AttributeQueryDialog : Form
    {
        #region 私有字段

        /// <summary>地图中全部可查询的矢量图层。</summary>
        private readonly List<IFeatureLayer> _featureLayers;

        #endregion

        #region 公共属性

        /// <summary>用户选择的待查询图层。</summary>
        public IFeatureLayer SelectedLayer { get; private set; }

        /// <summary>用户输入的 SQL 查询条件。</summary>
        public string WhereClause { get; private set; }

        #endregion

        #region 构造函数

        /// <summary>
        /// 创建属性查询设置对话框。
        /// </summary>
        /// <param name="featureLayers">地图中全部可查询的矢量图层。</param>
        public AttributeQueryDialog(List<IFeatureLayer> featureLayers)
        {
            _featureLayers = featureLayers;

            InitializeComponent();
            LoadLayers();
        }

        #endregion

        #region 数据加载

        /// <summary>
        /// 将可查询的矢量图层填充到图层下拉框。
        /// </summary>
        private void LoadLayers()
        {
            cboLayer.Items.Clear();
            if (_featureLayers == null)
            {
                return;
            }

            foreach (IFeatureLayer featureLayer in _featureLayers)
            {
                if (featureLayer != null)
                {
                    cboLayer.Items.Add(featureLayer.Name);
                }
            }

            if (cboLayer.Items.Count > 0)
            {
                cboLayer.SelectedIndex = 0;
            }
        }

        #endregion

        #region 确定与取消

        /// <summary>
        /// 查询：校验输入并关闭对话框，由主窗体执行选择。
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cboLayer.SelectedIndex < 0)
            {
                MessageBox.Show("请选择查询图层！");
                return;
            }

            if (string.IsNullOrEmpty(txtWhere.Text.Trim()))
            {
                MessageBox.Show("请输入查询条件！");
                return;
            }

            int selectedIndex = cboLayer.SelectedIndex;
            if (_featureLayers != null && selectedIndex < _featureLayers.Count)
            {
                SelectedLayer = _featureLayers[selectedIndex];
            }

            if (SelectedLayer == null)
            {
                MessageBox.Show("未获取到查询图层！");
                return;
            }

            WhereClause = txtWhere.Text.Trim();
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// 取消：直接关闭对话框。
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion
    }
}
