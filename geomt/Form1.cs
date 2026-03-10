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
            SetupChart(); // Настройка графика при создании формы
        }

        /// <summary>
        /// Настраивает внешний вид и свойства графика (Chart).
        /// Создает серии для отображения прямоугольника, отрезка, точек пересечения, центра и внешней точки.
        /// </summary>
        private void SetupChart()
        {
            Chart myChart = chart1 as Chart;
            if (myChart == null) return;

            myChart.Series.Clear();

            // Настройка осей координат
            myChart.ChartAreas[0].AxisX.Title = "X";
            myChart.ChartAreas[0].AxisY.Title = "Y";
            myChart.ChartAreas[0].AxisX.IsStartedFromZero = false;
            myChart.ChartAreas[0].AxisY.IsStartedFromZero = false;

            // Включение масштабирования и прокрутки
            myChart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            myChart.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            myChart.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            myChart.ChartAreas[0].AxisY.ScrollBar.Enabled = true;
            myChart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            myChart.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;

            // Серия для отображения прямоугольника
            Series rectSeries = new Series("Прямоугольник");
            rectSeries.ChartType = SeriesChartType.Line;
            rectSeries.Color = Color.Blue;
            rectSeries.BorderWidth = 2;
            myChart.Series.Add(rectSeries);

            // Серия для отображения отрезка
            Series lineSeries = new Series("Отрезок");
            lineSeries.ChartType = SeriesChartType.Line;
            lineSeries.Color = Color.Red;
            lineSeries.BorderWidth = 2;
            myChart.Series.Add(lineSeries);

            // Серия для отображения точки пересечения
            Series pointSeries = new Series("Точка пересечения");
            pointSeries.ChartType = SeriesChartType.Point;
            pointSeries.Color = Color.Green;
            pointSeries.MarkerStyle = MarkerStyle.Circle;
            pointSeries.MarkerSize = 8;
            myChart.Series.Add(pointSeries);

            // Серия для отображения центра прямоугольника
            Series centerSeries = new Series("Центр");
            centerSeries.ChartType = SeriesChartType.Point;
            centerSeries.Color = Color.Black;
            centerSeries.MarkerStyle = MarkerStyle.Circle;
            centerSeries.MarkerSize = 6;
            myChart.Series.Add(centerSeries);

            // Серия для отображения внешней точки (конца отрезка)
            Series externalPointSeries = new Series("Внешняя точка");
            externalPointSeries.ChartType = SeriesChartType.Point;
            externalPointSeries.Color = Color.Orange;
            externalPointSeries.MarkerStyle = MarkerStyle.Star4;
            externalPointSeries.MarkerSize = 12;
            externalPointSeries.MarkerColor = Color.Orange;
            myChart.Series.Add(externalPointSeries);
        }

        /// <summary>
        /// Автоматически масштабирует график, чтобы все элементы были видны с отступами.
        /// </summary>
        /// <param name="myChart">Объект графика для масштабирования</param>
        /// <param name="x_c">X-координата центра прямоугольника</param>
        /// <param name="y_c">Y-координата центра прямоугольника</param>
        /// <param name="h">Высота прямоугольника</param>
        /// <param name="w">Ширина прямоугольника</param>
        /// <param name="x">X-координата внешней точки</param>
        /// <param name="y">Y-координата внешней точки</param>
        private void AutoScaleChart(Chart myChart, double x_c, double y_c, double h, double w, double x, double y)
        {
            // Вычисление минимальных и максимальных значений координат
            double minX = Math.Min(Math.Min(x_c - w / 2, x_c + w / 2), x);
            double maxX = Math.Max(Math.Max(x_c + w / 2, x_c - w / 2), x);
            double minY = Math.Min(Math.Min(y_c - h / 2, y_c + h / 2), y);
            double maxY = Math.Max(Math.Max(y_c + h / 2, y_c - h / 2), y);

            // Добавление отступов (20% от размера)
            double paddingX = (maxX - minX) * 0.2;
            double paddingY = (maxY - minY) * 0.2;

            if (paddingX == 0) paddingX = 1;
            if (paddingY == 0) paddingY = 1;

            // Установка границ осей
            myChart.ChartAreas[0].AxisX.Minimum = minX - paddingX;
            myChart.ChartAreas[0].AxisX.Maximum = maxX + paddingX;
            myChart.ChartAreas[0].AxisY.Minimum = minY - paddingY;
            myChart.ChartAreas[0].AxisY.Maximum = maxY + paddingY;

            // Настройка сетки
            myChart.ChartAreas[0].AxisX.Interval = 1;
            myChart.ChartAreas[0].AxisY.Interval = 1;
            myChart.ChartAreas[0].AxisX.MajorGrid.Interval = 1;
            myChart.ChartAreas[0].AxisY.MajorGrid.Interval = 1;

            // Настройка внешнего вида сетки
            myChart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            myChart.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            myChart.ChartAreas[0].AxisX.MajorGrid.LineWidth = 1;

            myChart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            myChart.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            myChart.ChartAreas[0].AxisY.MajorGrid.LineWidth = 1;
        }

        /// <summary>
        /// Рисует прямоугольник на графике по заданным параметрам.
        /// </summary>
        /// <param name="myChart">Объект графика</param>
        /// <param name="x_c">X-координата центра</param>
        /// <param name="y_c">Y-координата центра</param>
        /// <param name="h">Высота прямоугольника</param>
        /// <param name="w">Ширина прямоугольника</param>
        private void DrawRectangle(Chart myChart, double x_c, double y_c, double h, double w)
        {
            // Вычисление координат углов прямоугольника
            double left = x_c - w / 2;
            double right = x_c + w / 2;
            double top = y_c + h / 2;
            double bottom = y_c - h / 2;

            // Добавление точек для построения замкнутого прямоугольника
            myChart.Series["Прямоугольник"].Points.AddXY(left, top);
            myChart.Series["Прямоугольник"].Points.AddXY(right, top);
            myChart.Series["Прямоугольник"].Points.AddXY(right, bottom);
            myChart.Series["Прямоугольник"].Points.AddXY(left, bottom);
            myChart.Series["Прямоугольник"].Points.AddXY(left, top);
        }

        /// <summary>
        /// Рисует отрезок на графике от центра до внешней точки.
        /// </summary>
        /// <param name="myChart">Объект графика</param>
        /// <param name="x1">X-координата начала отрезка (центр)</param>
        /// <param name="y1">Y-координата начала отрезка (центр)</param>
        /// <param name="x2">X-координата конца отрезка (внешняя точка)</param>
        /// <param name="y2">Y-координата конца отрезка (внешняя точка)</param>
        private void DrawLine(Chart myChart, double x1, double y1, double x2, double y2)
        {
            myChart.Series["Отрезок"].Points.AddXY(x1, y1);
            myChart.Series["Отрезок"].Points.AddXY(x2, y2);
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Нарисовать".
        /// Считывает входные данные, строит прямоугольник, отрезок и ищет точку пересечения.
        /// </summary>
        private void buttonDraw_Click(object sender, EventArgs e)
        {
            try
            {
                // Считывание данных из текстовых полей
                double xc = double.Parse(x_c.Text);
                double yc = double.Parse(y_c.Text);
                double h = double.Parse(h1.Text);
                double w = double.Parse(w1.Text);
                double x = double.Parse(x1.Text);
                double y = double.Parse(y1.Text);

                Chart myChart = chart1 as Chart;
                if (myChart == null) return;

                // Очистка всех серий
                foreach (var series in myChart.Series)
                {
                    series.Points.Clear();
                }

                // Построение прямоугольника
                DrawRectangle(myChart, xc, yc, h, w);

                // Построение отрезка
                DrawLine(myChart, xc, yc, x, y);

                // Добавление внешней точки
                myChart.Series["Внешняя точка"].Points.AddXY(x, y);

                // Добавление подписи к внешней точке
                var externalPoint = myChart.Series["Внешняя точка"].Points[0];
                externalPoint.Label = $"({x:F1}; {y:F1})";
                externalPoint.LabelForeColor = Color.Orange;
                externalPoint.Font = new Font("Arial", 9, FontStyle.Bold);

                // Добавление центра прямоугольника
                myChart.Series["Центр"].Points.AddXY(xc, yc);
                var center = myChart.Series["Центр"].Points[0];
                center.Label = $"({xc:F1}; {yc:F1})";
                center.LabelForeColor = Color.Black;
                center.Font = new Font("Arial", 9, FontStyle.Bold);

                // Поиск точки пересечения
                PointF? intersectionPoint = FindIntersection(xc, yc, h, w, x, y);

                if (intersectionPoint.HasValue)
                {
                    // Добавление найденной точки пересечения
                    myChart.Series["Точка пересечения"].Points.AddXY(intersectionPoint.Value.X, intersectionPoint.Value.Y);

                    var interPoint = myChart.Series["Точка пересечения"].Points[0];
                    interPoint.Label = $"({intersectionPoint.Value.X:F1}; {intersectionPoint.Value.Y:F1})";
                    interPoint.LabelForeColor = Color.Green;
                    interPoint.Font = new Font("Arial", 9, FontStyle.Bold);

                    MessageBox.Show($"Точка пересечения: ({intersectionPoint.Value.X:F1}, {intersectionPoint.Value.Y:F1})",
                        "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Проверка особого случая - точка на границе
                    if (h == x && w == y && xc != x && yc != y)
                    {
                        myChart.Series["Точка пересечения"].Points.AddXY(x, y);

                        var interPoint = myChart.Series["Точка пересечения"].Points[0];
                        interPoint.Label = $"({x:F1}; {y:F1})";
                        interPoint.LabelForeColor = Color.Green;
                        interPoint.Font = new Font("Arial", 9, FontStyle.Bold);
                        MessageBox.Show("Выбранная внешняя точка совпадает с границей прямоугольника!", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Отрезок не пересекает прямоугольник!", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Очистка всех серий при отсутствии пересечения
                        foreach (var series in myChart.Series)
                        {
                            series.Points.Clear();
                        }
                    }
                }

                // Автоматическое масштабирование графика
                AutoScaleChart(myChart, xc, yc, h, w, x, y);
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите корректные числа!", "Ошибка ввода",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Находит точку пересечения отрезка от центра до внешней точки с прямоугольником.
        /// Использует параметрическое уравнение прямой и проверяет пересечения со всеми сторонами.
        /// </summary>
        /// <param name="x_c">X-координата центра прямоугольника</param>
        /// <param name="y_c">Y-координата центра прямоугольника</param>
        /// <param name="h">Высота прямоугольника</param>
        /// <param name="w">Ширина прямоугольника</param>
        /// <param name="x">X-координата внешней точки</param>
        /// <param name="y">Y-координата внешней точки</param>
        /// <returns>Точка пересечения или null, если пересечения нет</returns>
        private PointF? FindIntersection(double x_c, double y_c, double h, double w, double x, double y)
        {
            // Вычисление границ прямоугольника
            double left = x_c - w / 2;
            double right = x_c + w / 2;
            double bottom = y_c - h / 2;
            double top = y_c + h / 2;

            // Вектор направления от центра к внешней точке
            double dx = x - x_c;
            double dy = y - y_c;

            PointF? intersection = null;
            double minT = double.MaxValue; // Ближайшее пересечение (наименьший параметр t)

            // Проверка пересечения с левой стороной
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

            // Проверка пересечения с правой стороной
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

            // Проверка пересечения с нижней стороной
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

            // Проверка пересечения с верхней стороной
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

        /// <summary>
        /// Обработчик кнопки "Очистить".
        /// Удаляет все точки со всех серий графика.
        /// </summary>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            Chart myChart = chart1 as Chart;
            foreach (var series in myChart.Series)
            {
                series.Points.Clear();
            }
        }
    }
}