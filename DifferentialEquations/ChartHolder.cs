using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DifferentialEquations.Settings;

namespace DifferentialEquations
{
    public sealed class ChartHolder : Chart
    {
        private readonly GraphicsSettings graphicsSettings;
        private readonly PaletteSettings paletteSettings;
        private readonly NumberPointsSettings pointsSettings;
        private List<Series> series;

        public ChartHolder(GraphicsSettings graphicsSettings, NumberPointsSettings pointsSettings,
            PaletteSettings paletteSettings)
        {
            this.graphicsSettings = graphicsSettings;
            this.pointsSettings = pointsSettings;
            this.paletteSettings = paletteSettings;
            Dock = DockStyle.Fill;
        }

        public void SetParent(Control form)
        {
            Parent = form;
        }

        public void MakeGraphics()
        {
            ChartAreas.Clear();
            Series.Clear();
            Legends.Clear();
            MakeChart();
            Refresh();
        }

        private void MakeChart()
        {
            var chartArea = new ChartArea("Chart1");
            ChartAreas.Add(chartArea);
            Legends.Add("Chart1");

            if (graphicsSettings.ExactSolution)
                MakeSeries(Algorithms.ExactSolution, "Chart1",
                    "Точное решение", this, paletteSettings.ExactSolution,
                    graphicsSettings.ExactSolutionBorderWidth);
            if (graphicsSettings.ExplicitEulerMethod)
                MakeSeries(Algorithms.ExplicitEulerMethod, "Chart1",
                    "Явный метод Эйлера", this, paletteSettings.ExplicitEulerMethod,
                    graphicsSettings.ExplicitEulerMethodBorderWidth);
            if (graphicsSettings.RungeKuttaMethod)
                MakeSeries(Algorithms.RungeKuttaMethod, "Chart1",
                    "Метод Рунге-Кутта", this, paletteSettings.RungeKuttaMethod,
                    graphicsSettings.RungeKuttaMethodBorderWidth);
            if (graphicsSettings.TrapeziumMethod)
                MakeSeries(Algorithms.TrapeziumMethod, "Chart1",
                    "Метод трапеций", this, paletteSettings.TrapeziumMethod,
                    graphicsSettings.TrapeziumMethodBorderWidth);
        }

        private void MakeSeries(Func<int, Node[]> method, string chartAreaName, string seriesName,
            Chart chart, Color colorLine, int borderWidth)
        {
            var series = new Series(seriesName) {ChartType = SeriesChartType.Line, ChartArea = chartAreaName};
            series.ShadowColor = colorLine;
            series.Color = colorLine;
            series.BorderWidth = borderWidth;
            series.Name = seriesName;
            series.Legend = seriesName;
            series.IsVisibleInLegend = true;
            var solution = method(pointsSettings.NumberPoints);
            foreach (var node in solution) series.Points.AddXY(node.X, node.Y);
            chart.Series.Add(series);
            series.Legend = "Chart1";
        }
    }
}