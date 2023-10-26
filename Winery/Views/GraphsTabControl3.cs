using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Winery.Helper;
using Winery.Models;

namespace Winery.Views
{
    public partial class GraphsTabControl3 : UserControl
    {
        private bool loadedTreeview1 = false;
        public GraphsTabControl3()
        {
            InitializeComponent();
            wineList2.Items.AddRange(DatabaseCommandHelper.GetVarietyList().ToArray());
        }

        public bool LoadedTreeview1
        {
            get { return loadedTreeview1; }
            set
            {
                if (value)
                {
                    if (!loadedTreeview1)
                    {
                        InitTreeview();
                    }

                    loadedTreeview1 = true;
                }
                else
                {
                    loadedTreeview1 = false;
                    treeView1.Nodes.Clear();
                }
            }
        }

        #region Tab1

        public void InitTreeview()
        {
            var treeviewData = DatabaseCommandHelper.GetWinesTreeview();

            foreach (var countryKvp in treeviewData)
            {
                var countryNode = new TreeNode(countryKvp.Key);
                treeView1.Nodes.Add(countryNode);

                foreach (var wineryKvp in countryKvp.Value)
                {
                    var wineryNode = new TreeNode(wineryKvp.Key);
                    countryNode.Nodes.Add(wineryNode);

                    foreach (var varietyKvp in wineryKvp.Value)
                    {
                        var varietyNode = new TreeNode(varietyKvp.Key);
                        wineryNode.Nodes.Add(varietyNode);

                        foreach (var wineKvp in varietyKvp.Value)
                        {
                            var wineNode = new TreeNode(wineKvp.Key);
                            wineNode.Tag = wineKvp.Value;
                            varietyNode.Nodes.Add(wineNode);
                        }
                    }
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (IsLeafNode(e.Node))
                {
                    var wineControl = new WineControl((Wine)e.Node.Tag);
                    flowLayoutPanel1.Controls.Add(wineControl);
                    flowLayoutPanel1.Controls.SetChildIndex(wineControl, 0);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        bool IsLeafNode(TreeNode node)
        {
            return node.Nodes.Count == 0;
        }

        #endregion
        #region tab2

        private void createGraph2_Click(object sender, EventArgs e)
        {
            MainForm.StartLoadingDialog();

            List<string> allowedVarieties = wineList2.CheckedItems.Cast<string>().ToList();
            if (allowedVarieties.Count <= 0)
            {
                MainForm.CloseLoadingDialog();
                MessageBox.Show("There is no variety selection. Unable to create Graph.");
                return;
            }


            var wineVarieties = DatabaseCommandHelper.GetClientWineSumary().Where(x => allowedVarieties.Contains(x.Variety));

            var groupedByVariety = wineVarieties.GroupBy(x => x.Variety);

            var plotModel = new PlotModel
            {
                Title = "Variety by age",
            };

            // X-axis
            var dateAxis = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Age",
            };

            plotModel.Axes.Add(dateAxis);

            //  Y-axis
            var salesAxis = new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Quantity sold",
            };
            plotModel.Axes.Add(salesAxis);

            foreach (var group in groupedByVariety)
            {
                var lineSeries = new LineSeries
                {
                    Title = group.Key,
                    Color = RandomGenerator.GetRandomColor(),
                    MarkerType = MarkerType.Circle,
                    MarkerSize = 4,
                };

                foreach (var entry in group)
                {
                    lineSeries.Points.Add(new DataPoint(entry.Age, entry.Quantity));
                }

                var maxQuantity = group.Max(item => item);
                var minQuantity = group.Min(item => item);

                // line for max and min
                plotModel.Annotations.Add(new LineAnnotation
                {
                    Type = LineAnnotationType.Horizontal,
                    Color = OxyColors.Green,
                    Y = maxQuantity.Quantity,
                    Text = group.Key,
                    TextPosition = new DataPoint(maxQuantity.Age, maxQuantity.Quantity),
                    TextVerticalAlignment = VerticalAlignment.Bottom,
                    TextHorizontalAlignment = OxyPlot.HorizontalAlignment.Left,
                    StrokeThickness = 1,
                    LineStyle = LineStyle.Solid,
                });

                plotModel.Annotations.Add(new LineAnnotation
                {
                    Type = LineAnnotationType.Horizontal,
                    Color = OxyColors.Red,
                    Y = minQuantity.Quantity,
                    Text = group.Key,
                    TextPosition = new DataPoint(minQuantity.Age, minQuantity.Quantity),
                    TextVerticalAlignment = VerticalAlignment.Bottom,
                    TextHorizontalAlignment = OxyPlot.HorizontalAlignment.Left,
                    StrokeThickness = 1,
                    LineStyle = LineStyle.Solid,
                });


                plotModel.Series.Add(lineSeries);
            }

            plotView2.Model = plotModel;

            MainForm.CloseLoadingDialog();

        }

        private void selectAllbutton2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < wineList2.Items.Count; i++)
            {
                wineList2.SetItemCheckState(i, CheckState.Checked);
            }
        }

        private void clearAllButton2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < wineList2.Items.Count; i++)
            {
                wineList2.SetItemCheckState(i, CheckState.Unchecked);
            }
        }
        #endregion
        #region tab3

        private void computeResultButton3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(gender3.Text))
            {
                MessageBox.Show("Please select a gender.");
                return;
            }

            MainForm.StartLoadingDialog();

            var soldWines = DatabaseCommandHelper.GetSoldWines((int)ageNumeric3.Value, gender3.Text);
            if (soldWines.Count <= 0)
            {
                MainForm.CloseLoadingDialog();
                MessageBox.Show("There are no sold wines for the selected age/gender group.");
                return;
            }

            var soldWinesFirst20 = soldWines.GetRange(0, 30);

            var plotModel = new PlotModel
            {
                Title = "Wine popularity",
            };

            // Create the category axis for weeks
            var categoryAxis = new CategoryAxis
            {
                Position = AxisPosition.Left,
                Title = "Wine Name"
            };

            categoryAxis.Labels.AddRange(soldWinesFirst20.Select(x => x.Name).ToList());
            plotModel.Axes.Add(categoryAxis);

            // Create the value axis for sales
            var valueAxis = new LinearAxis
            {
                Position = AxisPosition.Top,
                Title = "Quantity"
            };
            plotModel.Axes.Add(valueAxis);

            // Create the bar series
            var barSeries = new BarSeries
            {

                Title = "Sales",
                ValueField = "Quantity",
            };

            int i = 0;
            foreach (var week in soldWinesFirst20)
            {
                barSeries.Items.Add(new BarItem { Value = week.Quantity, CategoryIndex = i });
                i++;
            }


            plotModel.Series.Add(barSeries);

            plotView3.Model = plotModel;

            computeResultLabel3.Text = $"The most popular wine consumed by {gender3.Text} people aged {ageNumeric3.Value} is {soldWines[0].Name}. Sold quantity: {soldWines[0].Quantity}";

            MainForm.CloseLoadingDialog();
        }


        #endregion


    }
}
