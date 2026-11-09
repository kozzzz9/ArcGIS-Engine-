using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetTopologySuite.Features;

namespace Observer
{
    interface IObserver
    {
        public void update(IFeature feature, ChangeStatus status);
    }
}
