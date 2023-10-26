using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Axes;
using OxyPlot.Legends;
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
            this.comboBox2.Items.AddRange(DatabaseCommandHelper.GetWineList().ToArray());
        }

        public void SelectTab(int i)
        {
            if(i<0 || i > 2)
            {
                return;
            }
            
            this.tabControl1.SelectedIndex = i;
        }

        #region Tab1

        private void createGraph1_Click(object sender, EventArgs e)
        {
            MainForm.StartLoadingDialog();

            if (this.clientAgeFrom1.Value > this.clientAgeTo1.Value)
            {
                MessageBox.Show("The age interval is not set correctly. Unable to create Graph.");
                return;
            }

            List<ClientExpensesModel> clientsData = DatabaseCommandHelper.GetClientExpenses((int)this.clientAgeFrom1.Value, (int)this.clientAgeTo1.Value);

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

            this.plotView1.Model = model;

            // Find the age group with the least expenses for males
            var minMaleExpenseGroup = maleData
                .OrderBy(group => group.AverageExpenses)
                .First();

            // Find the age group with the least expenses for females
            var minFemaleExpenseGroup = femaleData
                .OrderBy(group => group.AverageExpenses)
                .First();

            this.recommandationLabel1.Text = $"Males: Age: {minMaleExpenseGroup.Age}, Average Expenses: {(int)minMaleExpenseGroup.AverageExpenses}" +
                $"{Environment.NewLine}{Environment.NewLine}Females: Age: {minFemaleExpenseGroup.Age}, Average Expenses: {(int)minFemaleExpenseGroup.AverageExpenses}" +
                $"{Environment.NewLine}{Environment.NewLine}Recommendation: Increase publicity to people aged {(minFemaleExpenseGroup.Age + minMaleExpenseGroup.Age)/2-2}";

            MainForm.CloseLoadingDialog();
        }


        #endregion
        #region tab2
        private void computeWineRecommendation2_Click(object sender, EventArgs e)
        {
            MainForm.StartLoadingDialog();

            var similarWines = DatabaseCommandHelper.GetSameVarietyWines(this.comboBox2.Text);
            int maxRecommendations = 9;
            this.flowLayoutPanel21.Controls.Clear();
            foreach(var wine in similarWines)
            {
                if (maxRecommendations < 0)
                {
                    break;
                }
                maxRecommendations--;
                this.flowLayoutPanel21.Controls.Add(new WineControl(wine));
            }

            var peopleAlsoBought = DatabaseCommandHelper.PeopleAlsoBought(this.comboBox2.Text);
            maxRecommendations = 9;
            this.flowLayoutPanel22.Controls.Clear();
            foreach (var wine in peopleAlsoBought)
            {
                if (maxRecommendations < 0)
                {
                    break;
                }
                maxRecommendations--;
                this.flowLayoutPanel22.Controls.Add(new WineControl(wine));
            }

            MainForm.CloseLoadingDialog();

        }

        #endregion
        #region tab3

        private void createGraph3_Click(object sender, EventArgs e)
        {
            MainForm.StartLoadingDialog();

            var plotModel = new PlotModel
            {
                Title = $"Wine Sales in period: {this.dateTimeFrom3.Text} - {this.dateTimeTo3.Text}",
            };

            List<string> allowedWineries = this.wineryList3.CheckedItems.Cast<string>().ToList();

            if (allowedWineries.Count <= 0)
            {
                MessageBox.Show("There is no winery selection. Unable to create Graph.");
                return;
            }

            if (this.dateTimeFrom3.Value > this.dateTimeTo3.Value)
            {
                MessageBox.Show("The start date is set later than the end date. Unable to create Graph.");
                return;
            }

            List<WineryDailySalesModel> salesData = DatabaseCommandHelper.GetDailySales(this.dateTimeFrom3.Value, this.dateTimeTo3.Value);

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
            for (int i = 0; i < this.wineryList3.Items.Count; i++)
            {
                this.wineryList3.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void selectAllButton3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.wineryList3.Items.Count; i++)
            {
                this.wineryList3.SetItemCheckState(i, CheckState.Checked);
            }
        }

        #endregion

        private void dateTimeFrom1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimeTo1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
