using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace MyMap
{
    /// <summary>
    /// 簇颜色调色板：按簇编号给出固定颜色（黄金角色环），噪声点固定灰色；
    /// 地图渲染与聚类结果窗共用，保证两处颜色一致。
    /// </summary>
    public static class ClusterColorPalette
    {
        /// <summary>黄金角（度）：使相邻簇编号的颜色差异最大化。</summary>
        private const double GoldenAngle = 137.5;

        /// <summary>
        /// 获取簇编号对应的显示颜色。
        /// </summary>
        /// <param name="clusterId">簇编号；负值返回噪声灰色。</param>
        /// <returns>颜色。</returns>
        public static Color GetColor(int clusterId)
        {
            if (clusterId < 0)
            {
                return Color.FromArgb(150, 150, 150);
            }

            double hue = (clusterId * GoldenAngle) % 360;
            int h = (int)Math.Round(hue);
            return HsvToRgb(h, 0.82, 0.92);
        }

        /// <summary>
        /// HSV 转换为 RGB 颜色。
        /// </summary>
        private static Color HsvToRgb(int hue, double saturation, double value)
        {
            int hi = (hue / 60) % 6;
            double f = hue / 60.0 - (hue / 60);
            double p = value * (1 - saturation);
            double q = value * (1 - f * saturation);
            double t = value * (1 - (1 - f) * saturation);
            double r, g, b;
            switch (hi)
            {
                case 0: r = value; g = t; b = p; break;
                case 1: r = q; g = value; b = p; break;
                case 2: r = p; g = value; b = t; break;
                case 3: r = p; g = q; b = value; break;
                case 4: r = t; g = p; b = value; break;
                default: r = value; g = p; b = q; break;
            }
            return Color.FromArgb((int)(r * 255), (int)(g * 255), (int)(b * 255));
        }
    }
    /// <summary>
    /// 聚类结果：算法名、参数描述、回写簇编号后的点集与耗时，并提供簇统计。
    /// </summary>
    public class ClusterResult
    {
        /// <summary>算法名称。</summary>
        public string AlgorithmName { get; private set; }

        /// <summary>参数描述文本。</summary>
        public string ParameterInfo { get; private set; }

        /// <summary>已回写簇编号的点集。</summary>
        public List<ClusterPoint> Points { get; private set; }

        /// <summary>算法耗时（毫秒）。</summary>
        public long ElapsedMilliseconds { get; private set; }

        /// <summary>
        /// 构建聚类结果。
        /// </summary>
        /// <param name="algorithmName">算法名称。</param>
        /// <param name="parameterInfo">参数描述文本。</param>
        /// <param name="points">已回写簇编号的点集。</param>
        /// <param name="elapsedMilliseconds">算法耗时（毫秒）。</param>
        public static ClusterResult Build(string algorithmName, string parameterInfo,
            List<ClusterPoint> points, long elapsedMilliseconds)
        {
            ClusterResult result = new ClusterResult();
            result.AlgorithmName = algorithmName;
            result.ParameterInfo = parameterInfo;
            result.Points = points;
            result.ElapsedMilliseconds = elapsedMilliseconds;
            return result;
        }

        /// <summary>
        /// 获取全部有效簇编号（升序，不含噪声点）。
        /// </summary>
        public List<int> GetClusterIds()
        {
            List<int> ids = Points.Select(p => p.ClusterId)
                .Where(id => id >= 0)
                .Distinct()
                .OrderBy(id => id)
                .ToList();
            return ids;
        }

        /// <summary>
        /// 有效簇的数量。
        /// </summary>
        public int ClusterCount
        {
            get { return GetClusterIds().Count; }
        }

        /// <summary>
        /// 噪声点数量（簇编号为负的点）。
        /// </summary>
        public int NoiseCount
        {
            get { return Points.Count(p => p.ClusterId < 0); }
        }
    }

    /// <summary>
    /// 聚类质量指标：簇内误差平方和 SSE（越小越紧凑）与轮廓系数 Silhouette（越接近 1 越好）。
    /// 噪声点不参与两项计算；点数超过上限时轮廓系数跳过（O(n²) 计算量）。
    /// </summary>
    public static class ClusterQuality
    {
        /// <summary>轮廓系数计算的最大点数上限，超出返回 NaN。</summary>
        private const int MaxSilhouettePoints = 2000;

        /// <summary>
        /// 计算 SSE：每个有效簇以其质心为基准，累加簇内点到质心的欧氏距离平方。
        /// </summary>
        public static double CalculateSse(List<ClusterPoint> points)
        {
            Dictionary<int, List<ClusterPoint>> groups = GroupValidClusters(points);
            double sse = 0.0;
            foreach (List<ClusterPoint> bucket in groups.Values)
            {
                double centerX = 0.0;
                double centerY = 0.0;
                foreach (ClusterPoint point in bucket)
                {
                    centerX += point.X;
                    centerY += point.Y;
                }
                centerX /= bucket.Count;
                centerY /= bucket.Count;

                foreach (ClusterPoint point in bucket)
                {
                    double dx = point.X - centerX;
                    double dy = point.Y - centerY;
                    sse += dx * dx + dy * dy;
                }
            }
            return sse;
        }

        /// <summary>
        /// 计算平均轮廓系数：a(i)=点 i 到同簇其它点的平均距离，
        /// b(i)=点 i 到最近异簇各点平均距离的最小值，s=(b-a)/max(a,b)。
        /// 簇数不足 2 或点数超上限时返回 NaN（无法计算/计算量过大）。
        /// </summary>
        public static double CalculateSilhouette(List<ClusterPoint> points)
        {
            Dictionary<int, List<ClusterPoint>> groups = GroupValidClusters(points);
            if (groups.Count < 2)
            {
                return double.NaN;
            }
            List<ClusterPoint> valid = new List<ClusterPoint>();
            foreach (List<ClusterPoint> bucket in groups.Values)
            {
                valid.AddRange(bucket);
            }
            if (valid.Count > MaxSilhouettePoints || valid.Count == 0)
            {
                return double.NaN;
            }

            int n = valid.Count;
            int[] labelOf = new int[n];
            for (int i = 0; i < n; i++) labelOf[i] = valid[i].ClusterId;

            // 预计算点对欧氏距离，供 a/b 复用
            double[][] dist = new double[n][];
            for (int i = 0; i < n; i++)
            {
                dist[i] = new double[n];
                dist[i][i] = 0.0;
            }
            // 先分配全部行再填对称值：原写法在写入 dist[j][i] 时
            // 第 j 行尚未分配，任意数据首次聚类必触发空引用
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    double dx = valid[i].X - valid[j].X;
                    double dy = valid[i].Y - valid[j].Y;
                    double d = Math.Sqrt(dx * dx + dy * dy);
                    dist[i][j] = d;
                    dist[j][i] = d;
                }
            }

            double total = 0.0;
            for (int i = 0; i < n; i++)
            {
                // a(i)：同簇其它点的平均距离
                double sumSame = 0.0;
                int countSame = 0;
                for (int j = 0; j < n; j++)
                {
                    if (j != i && labelOf[j] == labelOf[i])
                    {
                        sumSame += dist[i][j];
                        countSame++;
                    }
                }
                if (countSame == 0)
                {
                    continue; // 单点簇不参与轮廓系数
                }
                double a = sumSame / countSame;

                // b(i)：到最近异簇的平均距离的最小值
                double b = double.MaxValue;
                foreach (int clusterId in groups.Keys)
                {
                    if (clusterId == labelOf[i]) continue;
                    double sumOther = 0.0;
                    foreach (ClusterPoint other in groups[clusterId])
                    {
                        // 异簇点的下标未知，直接按点算距离（簇规模小时开销可忽略）
                        double dx = valid[i].X - other.X;
                        double dy = valid[i].Y - other.Y;
                        sumOther += Math.Sqrt(dx * dx + dy * dy);
                    }
                    double avg = sumOther / groups[clusterId].Count;
                    if (avg < b) b = avg;
                }

                double maxAb = Math.Max(a, b);
                if (maxAb > 0)
                {
                    total += (b - a) / maxAb;
                }
            }
            return total / n;
        }

        /// <summary>
        /// 按簇编号（不含噪声）分组。
        /// </summary>
        private static Dictionary<int, List<ClusterPoint>> GroupValidClusters(List<ClusterPoint> points)
        {
            Dictionary<int, List<ClusterPoint>> groups = new Dictionary<int, List<ClusterPoint>>();
            foreach (ClusterPoint point in points)
            {
                if (point.ClusterId < 0) continue;
                List<ClusterPoint> bucket;
                if (!groups.TryGetValue(point.ClusterId, out bucket))
                {
                    bucket = new List<ClusterPoint>();
                    groups[point.ClusterId] = bucket;
                }
                bucket.Add(point);
            }
            return groups;
        }
    }
}
