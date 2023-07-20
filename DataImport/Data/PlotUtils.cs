using ScottPlot;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImport.Data
{
    public class PlotUtils
    {
        public static void UpdateSactterLinePlot(List<SampleItem> items, FormsPlot plot, Alignment location= Alignment.UpperRight,bool labelVisable=true)
        {
            plot.Plot.Clear();
            Color[] colors = { Color.Black, Color.Red, Color.Goldenrod,Color.DeepPink,Color.DarkCyan,Color.DarkSeaGreen };

            for (int i = 0; i < items.Count; i++)
            {
                var item = items[i];
                double[] xs = item.XAxis;
                double[] ys = item.X;
                plot.Plot.AddScatterLines(
                    xs: xs,
                    ys: ys.Select(t => double.IsNaN(t) || double.IsInfinity(t) ? 0 : t).ToArray(),
                    lineWidth: 1,
                    label: item.Name,
                    color: colors[i%colors.Length]
                    );
            }
            if(labelVisable)
            {
                plot.Plot.Legend(location: location);
            }
            plot.Plot.Grid(false);
            plot.Refresh();
        }

        //public static void UpdateLinePlot(double[] axis,double[] x,FormsPlot plot, Alignment location = Alignment.UpperRight, bool labelVisable = true)
        //{
        //    plot.Plot.Clear();
        //    Color[] colors = { Color.Black, Color.Red, Color.Goldenrod, Color.DeepPink, Color.DarkCyan, Color.DarkSeaGreen };

        //    double[] xs = axis;
        //    double[] ys = x;
        //    plot.Plot.AddScatterLines(
        //        xs: xs,
        //        ys: ys.Select(t => double.IsNaN(t) || double.IsInfinity(t) ? 0 : t).ToArray(),
        //        lineWidth: 1,
        //        label: item.Name,
        //        color: colors[i % colors.Length]
        //        );

        //    if (labelVisable)
        //    {
        //        plot.Plot.Legend(location: location);
        //    }
        //    plot.Plot.Grid(false);
        //    plot.Refresh();
        //}

        public static void UpdateScattertPlot(List<SampleItem> items, FormsPlot plot, Alignment location = Alignment.UpperRight, bool labelVisable = true,int markSize=7)
        {
            plot.Plot.Clear();
            Color[] colors = { Color.Black, Color.Red, Color.Goldenrod, Color.DeepPink, Color.DarkCyan, Color.DarkSeaGreen };

            for (int i = 0; i < items.Count; i++)
            {
                var item = items[i];
                double[] xs = item.XAxis;
                double[] ys = item.X;
                plot.Plot.AddScatter(
                    xs: xs,
                    ys: ys.Select(t => double.IsNaN(t) || double.IsInfinity(t) ? 0 : t).ToArray(),
                    label: item.Name,
                    color: colors[i % colors.Length],
                    markerSize:markSize
                    );
            }
            if (labelVisable)
            {
                plot.Plot.Legend(location: location);
            }
            plot.Plot.Grid(false);
            plot.Refresh();
        }

        public static void UpdateScattertPointPlot(List<SampleItem> items, FormsPlot plot, Alignment location = Alignment.UpperRight, bool labelVisable = true, int markSize = 7)
        {
            plot.Plot.Clear();
            Color[] colors = { Color.Black, Color.Red, Color.Goldenrod, Color.DeepPink, Color.DarkCyan, Color.DarkSeaGreen };

            for (int i = 0; i < items.Count; i++)
            {
                var item = items[i];
                double[] xs = item.XAxis;
                double[] ys = item.X;
                plot.Plot.AddScatterPoints(
                    xs: xs,
                    ys: ys.Select(t => double.IsNaN(t) || double.IsInfinity(t) ? 0 : t).ToArray(),
                    label: item.Name,
                    color: colors[i % colors.Length],
                    markerSize: markSize
                    );
            }
            if (labelVisable)
            {
                plot.Plot.Legend(location: location);
            }
            plot.Plot.Grid(false);
            plot.Refresh();
        }

        public static void UpdatePredictScattertPointPlot(List<SampleItem> items, FormsPlot plot, Alignment location = Alignment.UpperRight, bool labelVisable = true, int markSize = 7)
        {
            plot.Plot.Clear();
            Color[] colors = { Color.Black, Color.Red, Color.Goldenrod, Color.DeepPink, Color.DarkCyan, Color.DarkSeaGreen };

            //var item = items[i];
            //double[] xs = item.XAxis;
            //double[] ys = item.X;
            plot.Plot.AddScatterPoints(
                xs: items[1].X.Select(t => double.IsNaN(t) || double.IsInfinity(t) ? 0 : t).ToArray(),
                ys: items[0].X.Select(t => double.IsNaN(t) || double.IsInfinity(t) ? 0 : t).ToArray(),
                label: "",
                color: colors[1 % colors.Length],
                markerSize: markSize
                );
            //for (int i = 0; i < items.Count; i++)
            //{

            //}
            if (labelVisable)
            {
                plot.Plot.Legend(location: location);
            }
            plot.Plot.Grid(false);
            plot.Refresh();
        }

        public static void SetPlot(string title,string xlabel,string ylabel,FormsPlot plot)
        {
            plot.Plot.Title(title);
            plot.Plot.XLabel(xlabel);
            plot.Plot.YLabel(ylabel);
            plot.Refresh();
        }
    }
}
