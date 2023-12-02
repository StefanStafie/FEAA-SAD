using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Winery.GraphsModels;
using Winery.Helper;

namespace Winery.Views
{
    public partial class GraphsTabControl1 : UserControl
    {
        public GraphsTabControl1()
        {
            InitializeComponent();
            wineryList1.Items.AddRange(DatabaseCommandHelper.GetWineryList().ToArray());
            wineryList2.Items.AddRange(wineryList1.Items);
            wineryList3.Items.AddRange(wineryList1.Items);
        }

        #region Tab1

        private void createGraph1_Click(object sender, EventArgs e)
        {
            MainForm.StartLoadingDialog();

            if (dateTimeFrom1.Value > dateTimeTo1.Value)
            {
                MainForm.CloseLoadingDialog();
                MessageBox.Show("The start date is set later than the end date. Unable to create Graph.");
                return;
            }

            List<string> allowedWineries = wineryList1.CheckedItems.Cast<string>().ToList();
            if (allowedWineries.Count <= 0)
            {
                MainForm.CloseLoadingDialog();
                MessageBox.Show("There is no winery selection. Unable to create Graph.");
                return;
            }

            List<WineryDailySalesModel> salesData = DatabaseCommandHelper.GetDailySales(dateTimeFrom1.Value, dateTimeTo1.Value);

            var plotModel = new PlotModel
            {
                Title = "Wine Daily Sales",
            };

            var dateAxis = new DateTimeAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Date",
                StringFormat = "yyyy-MM-dd",
            };

            plotModel.Axes.Add(dateAxis);

            var salesAxis = new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Sales $",
            };
            plotModel.Axes.Add(salesAxis);

            var allowedSales = salesData.Where(x => allowedWineries.Contains(x.Name));
            var groupedData = allowedSales.GroupBy(salesRecord => salesRecord.Name);
            foreach (var group in groupedData)
            {
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

            plotView1.Model = plotModel;

            MainForm.CloseLoadingDialog();
        }

        private void ClearSelectionButton1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < wineryList1.Items.Count; i++)
            {
                wineryList1.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void SelectAllButton1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < wineryList1.Items.Count; i++)
            {
                wineryList1.SetItemCheckState(i, CheckState.Checked);
            }
        }

        private void exportToExcelButton1_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.StartLoadingDialog();
                ExportToExcelHelper.ExportPlotModelToExcel11(plotView1.Model, $@"{Application.StartupPath}\Exports\Export11.xlsx", Microsoft.Office.Interop.Excel.XlChartType.xlLine);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                MainForm.CloseLoadingDialog();
            }
        }

        #endregion
        #region Tab2

        private void createGraph2_Click(object sender, EventArgs e)
        {
            MainForm.StartLoadingDialog();

            List<string> allowedWineries = wineryList2.CheckedItems.Cast<string>().ToList();
            if (dateTimeFrom2.Value > dateTimeTo2.Value)
            {
                MainForm.CloseLoadingDialog();
                MessageBox.Show("The start date is set later than the end date. Unable to create Graph.");
                return;
            }

            if (allowedWineries.Count <= 0)
            {
                MainForm.CloseLoadingDialog();
                MessageBox.Show("There is no winery selection. Unable to create Graph.");
                return;
            }

            List<WineryDailySalesModel> salesData = DatabaseCommandHelper.GetDailySales(dateTimeFrom2.Value, dateTimeTo2.Value);

            var weeklySales = salesData.Where(x => allowedWineries.Contains(x.Name))
                                       .GroupBy(s => new { Year = s.Date.Year, Week = WinformsHelper.GetWeek(s.Date) })
                                       .Select(g => new
                                       {
                                           Name = g.Key,
                                           Year = g.Key.Year,
                                           Week = g.Key.Week,
                                           Sales = g.Sum(s => s.Sales)
                                       });

            var plotModel = new PlotModel
            {
                Title = "Wine Weekly Sales",
            };


            var categoryAxis = new CategoryAxis
            {
                Position = AxisPosition.Left,
                Title = "Week"
            };

            categoryAxis.Labels.AddRange(weeklySales.Select(ws => $"{ws.Year}-W{ws.Week}").ToList());

            plotModel.Axes.Add(categoryAxis);

            var valueAxis = new LinearAxis
            {
                Position = AxisPosition.Top,
                Title = "Sales"
            };

            plotModel.Axes.Add(valueAxis);

            // Create the bar series
            var barSeries = new BarSeries
            {

                Title = "Weekly Sales",
                ValueField = "Sales",
            };


            foreach (var week in weeklySales)
            {
                barSeries.Items.Add(new BarItem { Value = week.Sales, CategoryIndex = categoryAxis.Labels.IndexOf($"{week.Year}-W{week.Week}") });
            }


            plotModel.Series.Add(barSeries);

            plotView2.Model = plotModel;

            MainForm.CloseLoadingDialog();
        }

        private void selectAllbutton2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < wineryList2.Items.Count; i++)
            {
                wineryList2.SetItemCheckState(i, CheckState.Checked);
            }
        }

        private void clearAllButton2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < wineryList2.Items.Count; i++)
            {
                wineryList2.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void exportToExcelButton2_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.StartLoadingDialog();
                ExportToExcelHelper.ExportPlotModelToExcel12(plotView2.Model, $@"{Application.StartupPath}\Exports\Export12.xlsx", Microsoft.Office.Interop.Excel.XlChartType.xlBarStacked);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                MainForm.CloseLoadingDialog();
            }
        }

        #endregion
        #region Tab3

        private void createGraph3_Click(object sender, EventArgs e)
        {
            MainForm.StartLoadingDialog();

            if (dateTimeFrom3.Value > dateTimeTo3.Value)
            {
                MainForm.CloseLoadingDialog();
                MessageBox.Show("The start date is set later than the end date. Unable to create Graph.");
                return;
            }

            List<string> allowedWineries = wineryList3.CheckedItems.Cast<string>().ToList();
            if (allowedWineries.Count <= 0)
            {
                MainForm.CloseLoadingDialog();
                MessageBox.Show("There is no winery selection. Unable to create Graph.");
                return;
            }

            var plotModel = new PlotModel
            {
                Title = $"Wine Sales in period: {dateTimeFrom3.Text} - {dateTimeTo3.Text}",
            };

            List<WineryDailySalesModel> salesData = DatabaseCommandHelper.GetDailySales(dateTimeFrom3.Value, dateTimeTo3.Value);

            var allowedSales = salesData.Where(x => allowedWineries.Contains(x.Name));
            var groupedData = allowedSales.GroupBy(salesRecord => salesRecord.Name);

            var pieSeries = new PieSeries();

            foreach (var group in groupedData)
            {
                pieSeries.Slices.Add(new PieSlice(group.Key, group.Sum(x => x.Sales)));
            }

            plotModel.Series.Add(pieSeries);
            plotView3.Model = plotModel;

            MainForm.CloseLoadingDialog();
        }

        private void clearSelectionButton3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < wineryList3.Items.Count; i++)
            {
                wineryList3.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void selectAllButton3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < wineryList3.Items.Count; i++)
            {
                wineryList3.SetItemCheckState(i, CheckState.Checked);
            }
        }

        private void exportToExcelButton3_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.StartLoadingDialog();
                ExportToExcelHelper.ExportPlotModelToExcel13(plotView3.Model, $@"{Application.StartupPath}\Exports\Export13.xlsx", Microsoft.Office.Interop.Excel.XlChartType.xlPie);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                MainForm.CloseLoadingDialog();
            }
        }


        #endregion

        private void button7_Click(object sender, EventArgs e)
        {
            var form = new SoldWinesExportForm(this.wineryList1, this.dateTimeFrom1.Value, this.dateTimeTo1.Value);
            form.ShowDialog();
            form.Dispose();
        }
    }
}
