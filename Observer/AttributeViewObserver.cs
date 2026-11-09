using System;
using NetTopologySuite.Features;

namespace Observer
{
    /// <summary>
    /// 具体观察者：属性视图，要素属性发生变化时更新属性表格显示（此处以控制台输出代替）
    /// </summary>
    class AttributeViewObserver : IObserver
    {
        public void update(IFeature feature, ChangeStatus status)
        {
            // 仅响应属性变更
            if (status == ChangeStatus.ATTRIBUTE)
            {
                Console.WriteLine("要素Attribute改变为：" + feature.Attributes["Name"].ToString());
            }
        }
    }
}
