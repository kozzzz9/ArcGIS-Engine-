using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using esriGeometryType = ESRI.ArcGIS.Geometry.esriGeometryType;

namespace MyMap
{
    /// <summary>
    /// 唯一值渲染相关的公共辅助方法。
    /// </summary>
    public static class UniqueValueRenderHelper
    {
        /// <summary>
        /// 按几何类型创建默认的符号模板。
        /// </summary>
        /// <param name="geometryType">图层几何类型。</param>
        public static ISymbol CreateDefaultTemplate(esriGeometryType geometryType)
        {
            if (geometryType == esriGeometryType.esriGeometryPoint ||
                geometryType == esriGeometryType.esriGeometryMultipoint)
            {
                ISimpleMarkerSymbol marker = new SimpleMarkerSymbol();
                marker.Style = esriSimpleMarkerStyle.esriSMSCircle;
                marker.Size = 6;
                marker.Outline = true;
                marker.OutlineSize = 1;
                marker.OutlineColor = CreateColor(0, 0, 0);
                marker.Color = CreateColor(255, 0, 0);
                return (ISymbol)marker;
            }

            if (geometryType == esriGeometryType.esriGeometryPolyline ||
                geometryType == esriGeometryType.esriGeometryPath)
            {
                ISimpleLineSymbol line = new SimpleLineSymbol();
                line.Style = esriSimpleLineStyle.esriSLSSolid;
                line.Width = 1;
                line.Color = CreateColor(255, 0, 0);
                return (ISymbol)line;
            }

            ISimpleFillSymbol fill = new SimpleFillSymbol();
            fill.Style = esriSimpleFillStyle.esriSFSSolid;
            fill.Color = CreateColor(255, 0, 0);

            ISimpleLineSymbol outline = new SimpleLineSymbol();
            outline.Style = esriSimpleLineStyle.esriSLSSolid;
            outline.Width = 0.4;
            outline.Color = CreateColor(0, 0, 0);
            fill.Outline = outline;

            return (ISymbol)fill;
        }

        /// <summary>
        /// 按几何类型与颜色创建符号，尽量沿用模板符号的其它属性。
        /// </summary>
        /// <param name="template">符号模板；可为 null。</param>
        /// <param name="geometryType">图层几何类型。</param>
        /// <param name="color">用于填充/描边的颜色；可为 null。</param>
        public static ISymbol CreateSymbol(ISymbol template, esriGeometryType geometryType, IColor color)
        {
            // 优先克隆模板符号，以保留其样式等其它属性
            ISymbol cloned = CloneSymbol(template);
            if (cloned != null && TryApplyColor(cloned, color))
            {
                return cloned;
            }

            // 没有可用模板时按几何类型创建默认符号，并尝试应用颜色
            ISymbol fallback = CreateDefaultTemplate(geometryType);
            TryApplyColor(fallback, color);
            return fallback;
        }

        /// <summary>
        /// 克隆符号模板，克隆失败时返回 null。
        /// </summary>
        public static ISymbol CloneSymbol(ISymbol template)
        {
            if (template == null)
            {
                return null;
            }

            try
            {
                IClone clone = template as IClone;
                if (clone == null)
                {
                    return null;
                }

                IClone cloned = clone.Clone();
                if (cloned == null)
                {
                    return null;
                }

                return cloned as ISymbol;
            }
            catch
            {
                // 克隆失败时退回默认符号
                return null;
            }
        }

        /// <summary>
        /// 将颜色应用到符号（填充色或线色），返回是否应用成功。
        /// </summary>
        public static bool TryApplyColor(ISymbol symbol, IColor color)
        {
            if (symbol == null || color == null)
            {
                return false;
            }

            // 优先使用简单符号接口（点、线、面）
            ISimpleMarkerSymbol marker = symbol as ISimpleMarkerSymbol;
            if (marker != null)
            {
                marker.Color = color;
                return true;
            }

            ISimpleLineSymbol line = symbol as ISimpleLineSymbol;
            if (line != null)
            {
                line.Color = color;
                return true;
            }

            ISimpleFillSymbol fill = symbol as ISimpleFillSymbol;
            if (fill != null)
            {
                fill.Color = color;
                return true;
            }

            // 复杂符号（如图片点、渐变面）实现的是基础符号接口，尝试回退设置
            try
            {
                IMarkerSymbol baseMarker = symbol as IMarkerSymbol;
                if (baseMarker != null)
                {
                    baseMarker.Color = color;
                    return true;
                }

                ILineSymbol baseLine = symbol as ILineSymbol;
                if (baseLine != null)
                {
                    baseLine.Color = color;
                    return true;
                }

                IFillSymbol baseFill = symbol as IFillSymbol;
                if (baseFill != null)
                {
                    baseFill.Color = color;
                    return true;
                }
            }
            catch
            {
                // 复杂符号可能不支持单一颜色设置，视为未成功
            }

            return false;
        }

        /// <summary>
        /// 创建 RGB 颜色。
        /// </summary>
        public static IColor CreateColor(int red, int green, int blue)
        {
            IRgbColor rgb = new RgbColor();
            rgb.Red = red;
            rgb.Green = green;
            rgb.Blue = blue;
            return rgb;
        }

        /// <summary>
        /// 按色带类型生成指定数量的颜色。
        /// </summary>
        /// <param name="rampIndex">色带类型索引：0 随机色带、1 渐变色带、2 单色渐变。</param>
        /// <param name="count">颜色数量。</param>
        public static List<IColor> CreateColors(int rampIndex, int count)
        {
            List<IColor> colors = new List<IColor>();
            if (count <= 0)
            {
                return colors;
            }

            try
            {
                if (rampIndex == 0)
                {
                    // 随机色带：色相均匀分布、饱和度与明度随机
                    IRandomColorRamp ramp = new RandomColorRamp();
                    ramp.Size = count;
                    ramp.StartHue = 0;
                    ramp.EndHue = 200;
                    ramp.MinSaturation = 20;
                    ramp.MaxSaturation = 40;
                    ramp.MinValue = 85;
                    ramp.MaxValue = 100;
                    ramp.UseSeed = true;
                    ramp.Seed = 43;

                    bool ok;
                    ramp.CreateRamp(out ok);
                    if (ok)
                    {
                        IEnumColors enumColors = ramp.Colors;
                        enumColors.Reset();
                        IColor color = enumColors.Next();
                        while (color != null)
                        {
                            colors.Add(color);
                            color = enumColors.Next();
                        }
                    }
                }
                else
                {
                    // 渐变色带与单色渐变均基于算法色带
                    IAlgorithmicColorRamp ramp = new AlgorithmicColorRamp();
                    ramp.Algorithm = rampIndex == 1
                        ? esriColorRampAlgorithm.esriHSVAlgorithm
                        : esriColorRampAlgorithm.esriCIELabAlgorithm;

                    if (rampIndex == 1)
                    {
                        // 红 -> 蓝
                        ramp.FromColor = CreateColor(255, 0, 0);
                        ramp.ToColor = CreateColor(0, 0, 255);
                    }
                    else
                    {
                        // 浅蓝 -> 深蓝
                        ramp.FromColor = CreateColor(222, 235, 247);
                        ramp.ToColor = CreateColor(8, 48, 107);
                    }

                    ramp.Size = count;

                    bool ok;
                    ramp.CreateRamp(out ok);
                    if (ok)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            colors.Add(ramp.get_Color(i));
                        }
                    }
                }
            }
            catch
            {
                // 色带创建异常时退回默认颜色
                colors.Clear();
            }

            // 色带创建失败时退回默认颜色
            if (colors.Count == 0)
            {
                for (int i = 0; i < count; i++)
                {
                    int level = count == 1 ? 128 : (int)(255.0 * i / (count - 1));
                    colors.Add(CreateColor(level, level, level));
                }
            }

            return colors;
        }

        /// <summary>
        /// 将 ArcGIS 的 IColor 转换为 System.Drawing.Color。
        /// </summary>
        public static Color ToWinColor(IColor color)
        {
            if (color == null)
            {
                return Color.Red;
            }

            try
            {
                // 空颜色不参与显示
                if (color.NullColor)
                {
                    return Color.Transparent;
                }

                // IRgbColor 单独提供红、绿、蓝三个分量，直接读取最可靠
                IRgbColor rgb = color as IRgbColor;
                if (rgb != null)
                {
                    return Color.FromArgb(rgb.Red, rgb.Green, rgb.Blue);
                }

                // 其它颜色模型（HsvColor/HlsColor/CmykColor/GrayColor）只实现 IColor，
                // 并不实现 IRgbColor。必须改用 IColor.RGB 读取 OLE 格式（0x00BBGGRR）
                // 的整数值再转换，否则色带生成的颜色会全部退化成默认的纯红色。
                // 读取前需要打开抖动，否则高字节会带有系统颜色标记而失真。
                color.UseWindowsDithering = true;
                return ColorTranslator.FromOle(color.RGB);
            }
            catch
            {
                // 转换失败时退回默认颜色
                return Color.Red;
            }
        }

        /// <summary>
        /// 将字段值转换为用于唯一值渲染的字符串。
        /// </summary>
        public static string FormatValue(object value)
        {
            if (value == null || value == DBNull.Value)
            {
                return string.Empty;
            }

            IFormattable formattable = value as IFormattable;
            if (formattable != null)
            {
                return formattable.ToString(null, CultureInfo.InvariantCulture);
            }
            return value.ToString();
        }

        /// <summary>
        /// 创建唯一值渲染器。
        /// </summary>
        /// <param name="fieldName">唯一值字段名。</param>
        /// <param name="fieldIsString">字段是否为字符串类型（影响 FieldType 设置）。</param>
        /// <param name="valueSymbols">唯一值与符号的对应关系。</param>
        /// <param name="defaultSymbol">默认符号。</param>
        /// <param name="useDefaultSymbol">是否使用默认符号渲染其它值。</param>
        public static IUniqueValueRenderer CreateRenderer(
            string fieldName,
            bool fieldIsString,
            IDictionary<string, ISymbol> valueSymbols,
            ISymbol defaultSymbol,
            bool useDefaultSymbol)
        {
            IUniqueValueRenderer renderer = new UniqueValueRenderer();

            // 设置唯一值字段（FieldCount 为非索引属性，不能显式调用 set_FieldCount）
            renderer.FieldCount = 1;
            renderer.set_Field(0, fieldName);

            // FieldType 表示该索引处的字段是否为字符串类型
            renderer.set_FieldType(0, fieldIsString);
            renderer.FieldDelimiter = ",";

            // 默认符号必须先于 UseDefaultSymbol 设置。
            // UniqueValueRenderer 在 DefaultSymbol 为 NULL 时设置 UseDefaultSymbol = true
            // 会抛出 E_INVALIDARG(0x80070057)，因此这里调整了赋值顺序。
            if (defaultSymbol != null)
            {
                renderer.DefaultSymbol = defaultSymbol;
                renderer.DefaultLabel = "其它";
                renderer.UseDefaultSymbol = useDefaultSymbol;
            }
            else
            {
                // 没有默认符号时不能启用默认符号渲染，否则同样会触发上面的异常
                renderer.UseDefaultSymbol = false;
            }

            // 添加每个唯一值及其符号
            if (valueSymbols != null)
            {
                foreach (KeyValuePair<string, ISymbol> item in valueSymbols)
                {
                    if (item.Value == null)
                    {
                        continue;
                    }

                    renderer.AddValue(item.Key, item.Key, item.Value);
                }
            }

            return renderer;
        }

        /// <summary>
        /// 释放 COM 对象，释放失败时忽略。
        /// </summary>
        public static void ReleaseComObject(object comObject)
        {
            if (comObject == null)
            {
                return;
            }

            try
            {
                if (Marshal.IsComObject(comObject))
                {
                    Marshal.ReleaseComObject(comObject);
                }
            }
            catch
            {
                // 释放失败不影响后续处理
            }
        }
    }

}
