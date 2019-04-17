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

        public void SetParent(MyForm form)
        {
            Parent = form;
        }

        public void MakeGraphics()
        {
            ChartAreas.Clear();
            Series.Clear();
            MakeChart();
            Refresh();
        }

        private void MakeChart()
        {
            var chartArea = new ChartArea("Exact Solution");
            chartArea.AxisX.Title = "x";
            chartArea.AxisY.Title = "y";
            ChartAreas.Add(chartArea);
            if (graphicsSettings.ExactSolution)
                MakeSeries(Algorithms.ExactSolution, "Exact Solution",
                    "Точное решение", this, paletteSettings.ExactSolution);
            if (graphicsSettings.ExplicitEulerMethod)
                MakeSeries(Algorithms.ExplicitEulerMethod, "Exact Solution",
                    "Явный метод Эйлера", this, paletteSettings.ExplicitEulerMethod);
            if (graphicsSettings.RungeKuttaMethod)
                MakeSeries(Algorithms.RungeKuttaMethod, "Exact Solution",
                    "Метод Рунге-Кутта", this, paletteSettings.RungeKuttaMethod);
            if (graphicsSettings.TrapeziumMethod)
                MakeSeries(Algorithms.TrapeziumMethod, "Exact Solution",
                    "Метод трапеций", this, paletteSettings.TrapeziumMethod);
        }

        private void MakeSeries(Func<int, Node[]> method, string chartAreaName, string seriesName,
            Chart chart, Color colorLine)
        {
            var series = new Series(seriesName) {ChartType = SeriesChartType.Line, ChartArea = chartAreaName};
            series.Color = colorLine;
            var solution = method(pointsSettings.NumberPoints);
            foreach (var node in solution) series.Points.AddXY(node.X, node.Y);
            chart.Series.Add(series);
        }
    }
}