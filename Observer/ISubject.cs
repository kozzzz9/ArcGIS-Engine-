using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetTopologySuite.Features;

namespace Observer
{
    interface ISubject
    {
        // 声明属性
        public ChangeStatus mChangeStatus { get; set; }
        public IFeature mFeature { get; set; }
        // 声明方法
        public void attach(IObserver observer);
        public void detach(IObserver observer);
        public void notify();
    }
}
