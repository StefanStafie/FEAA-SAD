using Microsoft.Office.Interop.Excel;
using OxyPlot;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Winery.Helper
{
    static public class ExportToExcelHelper
    {
        static public void ExportGridviewToExcel(DataGridView dataGridView, string filePath)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
            Worksheet worksheet = (Worksheet)workbook.Sheets[1];

            int cellRowIndex = 1;
            int cellColumnIndex = 1;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                cellColumnIndex = 1;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    worksheet.Cells[cellRowIndex, cellColumnIndex] = cell.Value;
                    cellColumnIndex++;
                }
                cellRowIndex++;
            }

            workbook.SaveAs(filePath);
            workbook.Close();
            excelApp.Quit();

            releaseObject(worksheet);
            releaseObject(workbook);
            releaseObject(excelApp);
        }

        #region tab11
        static public void ExportPlotModelToExcel11(PlotModel model, string filePath, XlChartType chartType)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

            Workbook workbook = excelApp.Workbooks.Add();

            Worksheet worksheet = workbook.Worksheets.Add();
            worksheet.Name = "ChartData";

            ExportOxyPlotChartToExcel11(model, worksheet, chartType);

            workbook.SaveAs(filePath);

            excelApp.Quit();

            releaseObject(workbook);
            releaseObject(excelApp);
        }

        private static void ExportOxyPlotChartToExcel11(PlotModel model, Worksheet worksheet, XlChartType chartType)
        {
            ChartObjects chartObjects = (ChartObjects)worksheet.ChartObjects();
            ChartObject chartObject = chartObjects.Add(100, 20, 400, 300);
            Chart chart = chartObject.Chart;
            chart.ChartType = chartType;


            Axis xAxis = (Axis)chart.Axes(XlAxisType.xlCategory, XlAxisGroup.xlPrimary);
            xAxis.CategoryType = XlCategoryType.xlTimeScale;
            xAxis.BaseUnit = XlTimeUnit.xlDays; 
            xAxis.MajorUnit = 1;
            xAxis.TickLabels.NumberFormat = "yyyy-MM-dd"; 


            for (int i = 0; i < model.Series.Count; i++)
            {
                OxyPlot.Series.LineSeries oxySeries = (OxyPlot.Series.LineSeries)model.Series[i];

                Series series = chart.SeriesCollection().NewSeries();
                series.Name = oxySeries.Title;
                series.XValues = oxySeries.Points.Select(x=>x.X).ToArray();
                series.Values= oxySeries.Points.Select(x => x.Y).ToArray();
            }
        }
        #endregion

        #region tab13
        static public void ExportPlotModelToExcel13(PlotModel model, string filePath, XlChartType chartType)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

            Workbook workbook = excelApp.Workbooks.Add();

            Worksheet worksheet = workbook.Worksheets.Add();
            worksheet.Name = "ChartData";

            ExportOxyPlotChartToExcel13(model, worksheet, chartType);

            workbook.SaveAs(filePath);

            excelApp.Quit();

            releaseObject(workbook);
            releaseObject(excelApp);
        }

        private static void ExportOxyPlotChartToExcel13(PlotModel model, Worksheet worksheet, XlChartType chartType)
        {
            ChartObjects chartObjects = (ChartObjects)worksheet.ChartObjects();
            ChartObject chartObject = chartObjects.Add(100, 20, 400, 300);
            Chart chart = chartObject.Chart;
            chart.ChartType = chartType;


            for (int i = 0; i < model.Series.Count; i++)
            {
                OxyPlot.Series.PieSeries oxySeries = (OxyPlot.Series.PieSeries)model.Series[i];

                Series series = chart.SeriesCollection().NewSeries();
                series.Name = oxySeries.Title;
                series.Values = oxySeries.Slices.Select(x => x.Value).ToArray();
                series.XValues = oxySeries.Slices.Select(x => x.Label).ToArray();
            }
        }
        #endregion

        #region tab12
        static public void ExportPlotModelToExcel12(PlotModel model, string filePath, XlChartType chartType)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

            Workbook workbook = excelApp.Workbooks.Add();

            Worksheet worksheet = workbook.Worksheets.Add();
            worksheet.Name = "ChartData";

            ExportOxyPlotChartToExcel12(model, worksheet, chartType);

            workbook.SaveAs(filePath);

            excelApp.Quit();

            releaseObject(workbook);
            releaseObject(excelApp);
        }

        private static void ExportOxyPlotChartToExcel12(PlotModel model, Worksheet worksheet, XlChartType chartType)
        {
            ChartObjects chartObjects = (ChartObjects)worksheet.ChartObjects();
            ChartObject chartObject = chartObjects.Add(100, 20, 400, 300);
            Chart chart = chartObject.Chart;
            chart.ChartType = chartType;


            for (int i = 0; i < model.Series.Count; i++)
            {
                OxyPlot.Series.BarSeries oxySeries = (OxyPlot.Series.BarSeries)model.Series[i];

                Series series = chart.SeriesCollection().NewSeries();
                series.Name = oxySeries.Title;
                series.XValues = ((OxyPlot.Axes.CategoryAxis)oxySeries.YAxis).Labels.ToArray();
                series.Values = oxySeries.Items.ToArray();
            }
        }
        #endregion

        #region tab21
        static public void ExportPlotModelToExcel21(PlotModel model, string filePath, XlChartType chartType)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

            Workbook workbook = excelApp.Workbooks.Add();

            Worksheet worksheet = workbook.Worksheets.Add();
            worksheet.Name = "ChartData";

            ExportOxyPlotChartToExcel21(model, worksheet, chartType);

            workbook.SaveAs(filePath);

            excelApp.Quit();

            releaseObject(workbook);
            releaseObject(excelApp);
        }

        private static void ExportOxyPlotChartToExcel21(PlotModel model, Worksheet worksheet, XlChartType chartType)
        {
            ChartObjects chartObjects = (ChartObjects)worksheet.ChartObjects();
            ChartObject chartObject = chartObjects.Add(100, 20, 400, 300);
            Chart chart = chartObject.Chart;
            chart.ChartType = chartType;


            for (int i = 0; i < model.Series.Count; i++)
            {
                OxyPlot.Series.LineSeries oxySeries = (OxyPlot.Series.LineSeries)model.Series[i];

                Series series = chart.SeriesCollection().NewSeries();
                series.Name = oxySeries.Title;
                series.XValues = oxySeries.Points.Select(x => x.X).ToArray();
                series.Values = oxySeries.Points.Select(x => x.Y).ToArray();
            }
        }
        #endregion

        #region tab32
        static public void ExportPlotModelToExcel32(PlotModel model, string filePath, XlChartType chartType)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

            Workbook workbook = excelApp.Workbooks.Add();

            Worksheet worksheet = workbook.Worksheets.Add();
            worksheet.Name = "ChartData";

            ExportOxyPlotChartToExcel32(model, worksheet, chartType);

            workbook.SaveAs(filePath);

            excelApp.Quit();

            releaseObject(workbook);
            releaseObject(excelApp);
        }

        private static void ExportOxyPlotChartToExcel32(PlotModel model, Worksheet worksheet, XlChartType chartType)
        {
            ChartObjects chartObjects = (ChartObjects)worksheet.ChartObjects();
            ChartObject chartObject = chartObjects.Add(100, 20, 400, 300);
            Chart chart = chartObject.Chart;
            chart.ChartType = chartType;

            for (int i = 0; i < model.Series.Count; i++)
            {
                OxyPlot.Series.LineSeries oxySeries = (OxyPlot.Series.LineSeries)model.Series[i];

                Series series = chart.SeriesCollection().NewSeries();
                series.Name = oxySeries.Title;
                series.XValues = oxySeries.Points.Select(x => x.X).ToArray();
                series.Values = oxySeries.Points.Select(x => x.Y).ToArray();
            }
        }
        #endregion

        static private void releaseObject(object obj)
        {
            try
            {
                Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
