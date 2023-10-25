using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winery.GraphsModels;
using Winery.Helper;
using OxyPlot.Annotations;

namespace Winery.Views
{
    public partial class GraphsTabControl : UserControl
    {
        public GraphsTabControl()
        {
            InitializeComponent();
            this.wineryList1.Items.AddRange(DatabaseCommandHelper.GetWineryList().ToArray()); 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void createGraph1_Click(object sender, EventArgs e)
        {
            List<string> allowedWineries = this.wineryList1.CheckedItems.Cast<string>().ToList();
            List<WineryDailySalesModel> salesData = DatabaseCommandHelper.GetDailySales(this.dateTimeFrom1.Value, this.dateTimeTo1.Value);

            var plotModel = new PlotModel
            {
                Title = "Wine Daily Sales",
            };

            // X-axis
            var dateAxis = new DateTimeAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Date",
                StringFormat = "yyyy-MM-dd", 
            };

            plotModel.Axes.Add(dateAxis);

            //  Y-axis
            var salesAxis = new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Sales $",
            };
            plotModel.Axes.Add(salesAxis);

            // group data by winery name
            var groupedData = salesData.GroupBy(salesRecord => salesRecord.Name);
            foreach(var group in groupedData)
            {
                if (!allowedWineries.Contains(group.Key))
                {
                    continue;
                }

                var lineSeries = new LineSeries
                {
                    Title = group.Key,
                    Color = RandomGenerator.GetRandomColor(),
                    MarkerType = MarkerType.Circle,
                    MarkerSize = 4,
                };

                foreach (var salesRecord in group)
                {
                    lineSeries.Points.Add(new DataPoint(DateTimeAxis.ToDouble(salesRecord.Date), salesRecord.Sales));
                }

                var maxSales = group.Max(item => item);
                var minSales = group.Min(item => item);

                // line for max and min
                plotModel.Annotations.Add(new LineAnnotation
                {
                    Type = LineAnnotationType.Horizontal,
                    Color = OxyColors.Green,
                    Y = maxSales.Sales,
                    Text = group.Key,
                    TextPosition = new DataPoint(maxSales.Date.ToOADate(), maxSales.Sales), // Text position
                    TextVerticalAlignment = VerticalAlignment.Bottom,
                    TextHorizontalAlignment = OxyPlot.HorizontalAlignment.Left,
                    StrokeThickness = 1,
                    LineStyle = LineStyle.Solid,
                });

                plotModel.Annotations.Add(new LineAnnotation
                {
                    Type = LineAnnotationType.Horizontal,
                    Color = OxyColors.Red,
                    Y = minSales.Sales,
                    Text = group.Key,
                    TextPosition = new DataPoint(minSales.Date.ToOADate(), minSales.Sales), // Text position
                    TextVerticalAlignment = VerticalAlignment.Bottom,
                    TextHorizontalAlignment = OxyPlot.HorizontalAlignment.Left,
                    StrokeThickness = 1,
                    LineStyle = LineStyle.Solid,
                });


                plotModel.Series.Add(lineSeries);
            }
            this.plotView1.Model = plotModel;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
