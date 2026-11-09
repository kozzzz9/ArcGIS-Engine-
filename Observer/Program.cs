using System;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using NetTopologySuite.Features;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            // 创建几何
            Geometry geometry = new Point(new Coordinate(100.87, 23.22));
            // 创建属性
            IAttributesTable attributes = new AttributesTable();
            attributes.Add("Name", "301食堂");
            // 创建要素
            IFeature feature = new Feature(geometry, attributes);
            Console.WriteLine("要素Geometry为：" + feature.Geometry.ToText());
            Console.WriteLine("要素Attribute为：" + feature.Attributes["Name"].ToString());

            // 创建目标（要素）并注册观察者：地图画布观察者 + 属性视图观察者
            FeatureSubject subject = new FeatureSubject();
            subject.mFeature = feature;
            MapCanvasObserver mapCanvas = new MapCanvasObserver();
            subject.attach(mapCanvas);
            subject.attach(new AttributeViewObserver());

            // 修改要素属性：目标置变更类型为 ATTRIBUTE，通知观察者，由属性视图观察者输出
            subject.mChangeStatus = ChangeStatus.ATTRIBUTE;
            feature.Attributes["Name"] = "302食堂";
            subject.notify();

            // 修改要素几何：目标置变更类型为 GEOMETRY，通知观察者，由地图画布观察者输出 WKT
            subject.mChangeStatus = ChangeStatus.GEOMETRY;
            feature.Geometry = new Point(new Coordinate(120.31, 11.54));
            subject.notify();

            // 注册日志观察者：其后的属性、几何变更均会被记录
            LogObserver logger = new LogObserver();
            subject.attach(logger);
            subject.mChangeStatus = ChangeStatus.ATTRIBUTE;
            feature.Attributes["Name"] = "303食堂";
            subject.notify();

            // 移除地图画布观察者：几何变更不再驱动地图更新，仅日志观察者响应
            subject.detach(mapCanvas);
            subject.mChangeStatus = ChangeStatus.GEOMETRY;
            feature.Geometry = new Point(new Coordinate(130.66, 20.87));
            subject.notify();

            if (!Console.IsInputRedirected) Console.ReadKey();
        }
    }
}
