using System;
using NetTopologySuite.Features;

namespace Observer
{
    /// <summary>
    /// 具体观察者：日志，对属性与几何两种变更均响应，
    /// 在控制台记录带时间戳的变更日志（模拟要素编辑历史记录）。
    /// </summary>
    class LogObserver : IObserver
    {
        public void update(IFeature feature, ChangeStatus status)
        {
            String time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (status == ChangeStatus.ATTRIBUTE)
            {
                Console.WriteLine("[日志 " + time + "] 要素属性变更，当前Name=" + feature.Attributes["Name"].ToString());
            }
            else if (status == ChangeStatus.GEOMETRY)
            {
                Console.WriteLine("[日志 " + time + "] 要素几何变更，当前Geometry=" + feature.Geometry.ToText());
            }
        }
    }
}
