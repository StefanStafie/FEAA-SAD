﻿using OxyPlot;
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
    public partial class GraphsTabControl2 : UserControl
    {
        public GraphsTabControl2()
        {
            InitializeComponent();
            comboBox2.Items.AddRange(DatabaseCommandHelper.GetWineList().ToArray());
        }

        public void SelectTab(int i)
        {
            if (i < 0 || i > 2)
            {
                return;
            }

            tabControl1.SelectedIndex = i;
        }

        #region Tab1

        private void createGraph1_Click(object sender, EventArgs e)
        {
            MainForm.StartLoadingDialog();

            if (clientAgeFrom1.Value > clientAgeTo1.Value)
            {
                MainForm.CloseLoadingDialog();
                MessageBox.Show("The age interval is not set correctly. Unable to create Graph.");
                return;
            }

            List<ClientExpensesModel> clientsData = DatabaseCommandHelper.GetClientExpenses((int)clientAgeFrom1.Value, (int)clientAgeTo1.Value);

            var maleData = clientsData
               .Where(client => client.Sex == "male")
               .GroupBy(client => client.Age)
               .Select(group => new
               {
                   Age = group.Key,
                   AverageExpenses = group.Average(client => (double)client.Expenses)
               })
               .OrderBy(group => group.Age);

            var femaleData = clientsData
                .Where(client => client.Sex == "female")
                .GroupBy(client => client.Age)
                .Select(group => new
                {
                    Age = group.Key,
                    AverageExpenses = group.Average(client => (double)client.Expenses)
                })
                .OrderBy(group => group.Age);

            var model = new PlotModel
            {
                Title = "Expenses by Age",
            };

            var maleSeries = new LineSeries
            {
                Title = "Male",
                Color = OxyColor.FromRgb(0, 0, 255),
            };

            var femaleSeries = new LineSeries
            {
                Title = "Female",
                Color = OxyColor.FromRgb(255, 0, 0),
            };

            foreach (var dataPoint in maleData)
            {
                maleSeries.Points.Add(new DataPoint(dataPoint.Age, dataPoint.AverageExpenses));
            }

            foreach (var dataPoint in femaleData)
            {
                femaleSeries.Points.Add(new DataPoint(dataPoint.Age, dataPoint.AverageExpenses));
            }

            model.Series.Add(maleSeries);
            model.Series.Add(femaleSeries);

            var xAxis = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Age",
            };

            var yAxis = new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Average Expenses",
            };

            model.Axes.Add(xAxis);
            model.Axes.Add(yAxis);

            plotView1.Model = model;

            var minMaleExpenseGroup = maleData
                .OrderBy(group => group.AverageExpenses)
                .First();

            var minFemaleExpenseGroup = femaleData
                .OrderBy(group => group.AverageExpenses)
                .First();

            recommandationLabel1.Text = $"Males: Age: {minMaleExpenseGroup.Age}, Average Expenses: {(int)minMaleExpenseGroup.AverageExpenses}" +
                $"{Environment.NewLine}{Environment.NewLine}Females: Age: {minFemaleExpenseGroup.Age}, Average Expenses: {(int)minFemaleExpenseGroup.AverageExpenses}" +
                $"{Environment.NewLine}{Environment.NewLine}Recommendation: Increase publicity to people aged {(minFemaleExpenseGroup.Age + minMaleExpenseGroup.Age) / 2 - 2}";

            MainForm.CloseLoadingDialog();
        }

        private void exportToExcelButton1_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.StartLoadingDialog();
                ExportToExcelHelper.ExportPlotModelToExcel21(plotView1.Model, $@"{Application.StartupPath}\Exports\Export21.xlsx", Microsoft.Office.Interop.Excel.XlChartType.xlLine);
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
        private void computeWineRecommendation2_Click(object sender, EventArgs e)
        {
            MainForm.StartLoadingDialog();

            var similarWines = DatabaseCommandHelper.GetSameVarietyWines(comboBox2.Text);
            int maxRecommendations = 9;
            flowLayoutPanel21.Controls.Clear();
            foreach (var wine in similarWines)
            {
                if (maxRecommendations < 0)
                {
                    break;
                }
                maxRecommendations--;
                flowLayoutPanel21.Controls.Add(new WineControl(wine));
            }

            var peopleAlsoBought = DatabaseCommandHelper.PeopleAlsoBought(comboBox2.Text);
            maxRecommendations = 9;
            flowLayoutPanel22.Controls.Clear();
            foreach (var wine in peopleAlsoBought)
            {
                if (maxRecommendations < 0)
                {
                    break;
                }
                maxRecommendations--;
                flowLayoutPanel22.Controls.Add(new WineControl(wine));
            }

            MainForm.CloseLoadingDialog();

            if (similarWines.Count == 0 && peopleAlsoBought.Count == 0)
            {
                try
                {
                    MainForm.StartLoadingDialog();
                    MessageBox.Show("There were no similar wines and there were no people who also bought this. Nothing to recommend.");
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

        }

        #endregion


    }
}
