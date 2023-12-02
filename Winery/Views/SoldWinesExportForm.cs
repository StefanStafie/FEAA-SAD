using Microsoft.Office.Interop.Excel;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Winery.GraphsModels;
using Winery.Helper;

namespace Winery.Views
{
    public partial class SoldWinesExportForm : Form
    {
        private DateTime dateTimeFrom;
        private DateTime dateTimeTo;
        private CheckedListBox checkedWineries;

        public SoldWinesExportForm(CheckedListBox checkedWineries, DateTime dateTimeFrom, DateTime dateTimeTo)
        {
            this.dateTimeFrom = dateTimeFrom;
            this.dateTimeTo = dateTimeTo;
            this.checkedWineries = checkedWineries;
            InitializeComponent();
            this.selectedWinery.Items.AddRange(DatabaseCommandHelper.GetWineryList().ToArray());
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            trackBar1Label.Text = $"Percentage: {trackBar1.Value}";
            trackBar2.Minimum = trackBar1.Value;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            trackBar2Label.Text = $"Percentage: {trackBar2.Value}";
            trackBar1.Maximum = trackBar2.Value;
        }

        private void cancelButton_OnClick(object sender, EventArgs e)
        {
            Close();
        }

        private void exportButton_OnClick(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                var filePath = saveFileDialog.FileName;
                saveFileDialog.Dispose();

                MainForm.StartLoadingDialog();

                List<WineryDailySalesModel> salesData = DatabaseCommandHelper.GetDailySales(dateTimeFrom, dateTimeTo);
                List<WineryDailySalesModel> allowedSales = salesData.Where(x => x.Name == this.selectedWinery.Text).ToList();
                if (allowedSales.Count == 0)
                {
                    MainForm.CloseLoadingDialog();
                    MessageBox.Show("Invalid selection.");
                    return;
                }



                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                Worksheet worksheet = (Worksheet)workbook.Sheets[1];

                int cellRowIndex = 1;

                foreach (var sale in allowedSales)
                {
                    worksheet.Cells[cellRowIndex, 1] = sale.Name;
                    worksheet.Cells[cellRowIndex, 2] = sale.Date;
                    worksheet.Cells[cellRowIndex, 3] = sale.Sales;
                    cellRowIndex++;
                }

                // add icons
                Range dataRange = worksheet.Range[$"C1:C{allowedSales.Count()}"];
                IconSetCondition iconSetCondition = dataRange.FormatConditions.AddIconSetCondition();
                iconSetCondition.IconCriteria[1].Icon = XlIcon.xlIconRedFlag;
                iconSetCondition.IconCriteria[2].Icon = XlIcon.xlIconYellowFlag;
                iconSetCondition.IconCriteria[3].Icon = XlIcon.xlIconGreenFlag;
                iconSetCondition.IconCriteria[2].Value = this.trackBar1.Value;
                iconSetCondition.IconCriteria[3].Value = this.trackBar2.Value;
                

                // add trend line chart
                ChartObjects chartObjects = (ChartObjects)worksheet.ChartObjects(Type.Missing);
                ChartObject chartObject = chartObjects.Add(300, 20, 500, 300);

                Chart chart = chartObject.Chart;
                Range chartRange = worksheet.Range[$"B1:C{allowedSales.Count()}"];
                chart.SetSourceData(chartRange);
                
                // Set chart type (e.g., xlLine)
                chart.ChartType = XlChartType.xlLine;
                chart.Axes(XlAxisType.xlCategory, XlAxisGroup.xlPrimary).TickLabels.NumberFormat = "yyyy-mm-dd";

                // Add a trendline for prediction
                SeriesCollection seriesCollection = (SeriesCollection)chart.SeriesCollection();
                Microsoft.Office.Interop.Excel.Series series = seriesCollection.Item(1);
                series.Name = this.selectedWinery.Text;


                foreach(var x in Enum.GetValues(typeof(XlTrendlineType)))
                {
                    Trendline trendline = series.Trendlines().Add(x);
                    trendline.Name = x.ToString();
                    trendline.Forward = (int)this.numericUpDown1.Value;
                }

                worksheet.Columns.AutoFit();


                workbook.SaveAs(filePath);
                workbook.Close();
                excelApp.Quit();

                ExportToExcelHelper.releaseObject(worksheet);
                ExportToExcelHelper.releaseObject(workbook);
                ExportToExcelHelper.releaseObject(excelApp);

            }
            catch (Exception ex)
            {
                MainForm.CloseLoadingDialog();
                MessageBox.Show("There was an error" + ex);
            }

            MainForm.CloseLoadingDialog();
        }
    }
}
