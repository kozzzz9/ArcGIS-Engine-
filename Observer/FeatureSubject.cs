using System;
using System.Collections.Generic;
using NetTopologySuite.Features;

namespace Observer
{
    /// <summary>
    /// 具体目标：要素，维护观察者列表，要素变更时通过 notify 通知所有注册的观察者
    /// </summary>
    class FeatureSubject : ISubject
    {
        // 观察者列表
        private List<IObserver> observers = new List<IObserver>();

        // 被修改的要素与变更类型
        public ChangeStatus mChangeStatus { get; set; }
        public IFeature mFeature { get; set; }

        /// <summary>
        /// 注册观察者
        /// </summary>
        public void attach(IObserver observer)
        {
            observers.Add(observer);
        }

        /// <summary>
        /// 移除观察者
        /// </summary>
        public void detach(IObserver observer)
        {
            observers.Remove(observer);
        }

        /// <summary>
        /// 通知：遍历调用所有已注册观察者的 update 方法
        /// </summary>
        public void notify()
        {
            foreach (IObserver observer in observers)
            {
                observer.update(mFeature, mChangeStatus);
            }
        }
    }
}
