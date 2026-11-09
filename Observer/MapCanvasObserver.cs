using System;
using NetTopologySuite.Features;

namespace Observer
{
    /// <summary>
    /// 具体观察者：地图画布，要素几何发生变化时在地图上更新显示（此处以控制台输出 WKT 代替）
    /// </summary>
    class MapCanvasObserver : IObserver
    {
        public void update(IFeature feature, ChangeStatus status)
        {
            // 仅响应几何变更
            if (status == ChangeStatus.GEOMETRY)
            {
                Console.WriteLine("要素Geometry改变为：" + feature.Geometry.ToText());
            }
        }
    }
}
