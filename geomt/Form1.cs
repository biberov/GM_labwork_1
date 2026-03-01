using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace geomt
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            // Настройка графика
            SetupChart();
        }

        private void SetupChart()
        {
           
            Chart myChart = chart1 as Chart;
            if (myChart == null) return;

            myChart.Series.Clear();
            double pp = 3;
            // область построения
            myChart.ChartAreas[0].AxisX.Title = "X";
            myChart.ChartAreas[0].AxisY.Title = "Y";
            myChart.ChartAreas[0].AxisX.IsStartedFromZero = false;
            myChart.ChartAreas[0].AxisY.IsStartedFromZero = false;

            //масштабирование
            myChart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            myChart.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            myChart.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            myChart.ChartAreas[0].AxisY.ScrollBar.Enabled = true;
            myChart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            myChart.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;

            Series rectSeries = new Series("Прямоугольник");
            rectSeries.ChartType = SeriesChartType.Line;
            rectSeries.Color = Color.Blue;
            rectSeries.BorderWidth = 2;
            myChart.Series.Add(rectSeries);

            Series lineSeries = new Series("Отрезок");
            lineSeries.ChartType = SeriesChartType.Line;
            lineSeries.Color = Color.Red;
            lineSeries.BorderWidth = 2;
            myChart.Series.Add(lineSeries);

            Series pointSeries = new Series("Точка пересечения");
            pointSeries.ChartType = SeriesChartType.Point;
            pointSeries.Color = Color.Green;
            pointSeries.MarkerStyle = MarkerStyle.Circle;
            pointSeries.MarkerSize = 8;
            myChart.Series.Add(pointSeries);

            Series centerSeries = new Series("Центр");
            centerSeries.ChartType = SeriesChartType.Point;
            centerSeries.Color = Color.Black;
            centerSeries.MarkerStyle = MarkerStyle.Circle;
            centerSeries.MarkerSize = 6;
            myChart.Series.Add(centerSeries);


            Series externalPointSeries = new Series("Внешняя точка");
            externalPointSeries.ChartType = SeriesChartType.Point;
            externalPointSeries.Color = Color.Orange;
            externalPointSeries.MarkerStyle = MarkerStyle.Star4;  
            externalPointSeries.MarkerSize = 12;
            externalPointSeries.MarkerColor = Color.Orange;
            myChart.Series.Add(externalPointSeries);
            double c = 1;
            c+=1;
        }

        private void AutoScaleChart(Chart myChart, double x_c, double y_c, double h, double w, double x, double y)
        {
            double minX = Math.Min(Math.Min(x_c - w / 2, x_c + w / 2), x);
            double maxX = Math.Max(Math.Max(x_c + w / 2, x_c - w / 2), x);
            double minY = Math.Min(Math.Min(y_c - h / 2, y_c + h / 2), y);
            double maxY = Math.Max(Math.Max(y_c + h / 2, y_c - h / 2), y);

            // 20% от размера
            double paddingX = (maxX - minX) * 0.2;
            double paddingY = (maxY - minY) * 0.2;

            if (paddingX == 0) paddingX = 1;
            if (paddingY == 0) paddingY = 1;

            myChart.ChartAreas[0].AxisX.Minimum = minX - paddingX;
            myChart.ChartAreas[0].AxisX.Maximum = maxX + paddingX;
            myChart.ChartAreas[0].AxisY.Minimum = minY - paddingY;
            myChart.ChartAreas[0].AxisY.Maximum = maxY + paddingY;

            myChart.ChartAreas[0].AxisX.Interval = 1;
            myChart.ChartAreas[0].AxisY.Interval = 1;
            myChart.ChartAreas[0].AxisX.MajorGrid.Interval = 1;
            myChart.ChartAreas[0].AxisY.MajorGrid.Interval = 1;

            myChart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            myChart.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            myChart.ChartAreas[0].AxisX.MajorGrid.LineWidth = 1;

            myChart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            myChart.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            myChart.ChartAreas[0].AxisY.MajorGrid.LineWidth = 1;
        }

        private void DrawRectangle(Chart myChart, double x_c, double y_c, double h, double w)
        {
            double left = x_c - w / 2;
            double right = x_c + w / 2;
            double top = y_c + h / 2;
            double bottom = y_c - h / 2;

            myChart.Series["Прямоугольник"].Points.AddXY(left, top);
            myChart.Series["Прямоугольник"].Points.AddXY(right, top);
            myChart.Series["Прямоугольник"].Points.AddXY(right, bottom);
            myChart.Series["Прямоугольник"].Points.AddXY(left, bottom);
            myChart.Series["Прямоугольник"].Points.AddXY(left, top);
        }

        private void DrawLine(Chart myChart, double x1, double y1, double x2, double y2)
        {
            myChart.Series["Отрезок"].Points.AddXY(x1, y1);
            myChart.Series["Отрезок"].Points.AddXY(x2, y2);
        }

        private PointF? FindIntersection(double x_c, double y_c, double h, double w, double x, double y)
        {
            double left = x_c - w / 2;
            double right = x_c + w / 2;
            double bottom = y_c - h / 2;
            double top = y_c + h / 2;

            double dx = x - x_c;
            double dy = y - y_c;

            PointF? intersection = null;
            double minT = double.MaxValue;

            // Левая сторона
            if (dx != 0)
            {
                double t = (left - x_c) / dx;
                if (t > 0 && t < 1)
                {
                    double yIntersect = y_c + t * dy;
                    if (yIntersect >= bottom && yIntersect <= top && t < minT)
                    {
                        minT = t;
                        intersection = new PointF((float)left, (float)yIntersect);
                    }
                }
            }

            // Правая сторона
            if (dx != 0)
            {
                double t = (right - x_c) / dx;
                if (t > 0 && t < 1)
                {
                    double yIntersect = y_c + t * dy;
                    if (yIntersect >= bottom && yIntersect <= top && t < minT)
                    {
                        minT = t;
                        intersection = new PointF((float)right, (float)yIntersect);
                    }
                }
            }

            // Нижняя сторона
            if (dy != 0)
            {
                double t = (bottom - y_c) / dy;
                if (t > 0 && t < 1)
                {
                    double xIntersect = x_c + t * dx;
                    if (xIntersect >= left && xIntersect <= right && t < minT)
                    {
                        minT = t;
                        intersection = new PointF((float)xIntersect, (float)bottom);
                    }
                }
            }

            // Верхняя сторона
            if (dy != 0)
            {
                double t = (top - y_c) / dy;
                if (t > 0 && t < 1)
                {
                    double xIntersect = x_c + t * dx;
                    if (xIntersect >= left && xIntersect <= right && t < minT)
                    {
                        minT = t;
                        intersection = new PointF((float)xIntersect, (float)top);
                    }
                }
            }

            return intersection;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Chart myChart = chart1 as Chart;
            foreach (var series in myChart.Series)
            {
                series.Points.Clear();
            }
        }

        private void buttonDraw_Click(object sender, EventArgs e) { DrawWithMode(0); }
        private void button2_Click(object sender, EventArgs e) { DrawWithMode(1); }
        private void button3_Click(object sender, EventArgs e) { DrawWithMode(2); }

        private void DrawWithMode(int mode)
        {
            try
            {
                double xc = double.Parse(x_c.Text);
                double yc = double.Parse(y_c.Text);
                double h = double.Parse(h1.Text);
                double w = double.Parse(w1.Text);
                double x = double.Parse(x1.Text);
                double y = double.Parse(y1.Text);

                Chart myChart = chart1 as Chart;
                if (myChart == null) return;

                foreach (var series in myChart.Series) series.Points.Clear();

                DrawRectangle(myChart, xc, yc, h, w);

                myChart.Series["Центр"].Points.AddXY(xc, yc);
                myChart.Series["Центр"].Points[0].Label = $"({xc:F1}; {yc:F1})";

                myChart.Series["Внешняя точка"].Points.AddXY(x, y);
                myChart.Series["Внешняя точка"].Points[0].Label = $"({x:F1}; {y:F1})";

                PointF? intersectionPoint = FindIntersection(xc, yc, h, w, x, y);

                if (intersectionPoint.HasValue)
                {
                    myChart.Series["Точка пересечения"].Points.AddXY(intersectionPoint.Value.X, intersectionPoint.Value.Y);
                    myChart.Series["Точка пересечения"].Points[0].Label = $"({intersectionPoint.Value.X:F1}; {intersectionPoint.Value.Y:F1})";

                    if (mode == 0) DrawLine(myChart, xc, yc, x, y);
                    if (mode == 1) DrawLine(myChart, xc, yc, intersectionPoint.Value.X, intersectionPoint.Value.Y);
                    if (mode == 2) DrawLine(myChart, intersectionPoint.Value.X, intersectionPoint.Value.Y, x, y);

                    MessageBox.Show($"Точка пересечения: ({intersectionPoint.Value.X:F1}, {intersectionPoint.Value.Y:F1})");
                }
                else
                {
                    if (h == x && w == y && xc != x && yc != y)
                    {
                        myChart.Series["Точка пересечения"].Points.AddXY(x, y);
                        myChart.Series["Точка пересечения"].Points[0].Label = $"({x:F1}; {y:F1})";

                        if (mode == 0) DrawLine(myChart, xc, yc, x, y);
                        if (mode == 1) DrawLine(myChart, xc, yc, x, y);

                        MessageBox.Show("Выбранная внешняя точка совпадает с границей прямоугольника!");
                    }
                    else
                    {
                        MessageBox.Show("Отрезок не пересекает прямоугольник!");
                        foreach (var series in myChart.Series) series.Points.Clear();
                    }
                }

                AutoScaleChart(myChart, xc, yc, h, w, x, y);
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите корректные числа!", "Ошибка ввода");
            }
        }
    }
}