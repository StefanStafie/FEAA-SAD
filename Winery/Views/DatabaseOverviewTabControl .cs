using System;
using System.Text;
using System.Windows.Forms;
using Winery.Helper;

namespace Winery.Views
{
    public partial class DatabaseOverviewTabControl : UserControl
    {
        public DatabaseOverviewTabControl()
        {
            InitializeComponent();
        }

        public void Init()
        {
            WinformsHelper.InvokeIfRequired(this, () => { wINESTableAdapter.Fill(dataSet.WINES); });
        }


        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainForm.StartLoadingDialog();

            WinformsHelper.InvokeIfRequired(this, () =>
            {
                switch (((TabControl)sender).SelectedIndex)
                {
                    case 0:
                        wINESTableAdapter.Fill(dataSet.WINES);
                        break;
                    case 1:
                        cLIENTSTableAdapter.Fill(dataSet.CLIENTS);
                        break;
                    case 2:
                        sOLD_WINESTableAdapter.Fill(dataSet.SOLD_WINES);
                        break;
                    case 3:
                        cOUNTRY_INFOTableAdapter.Fill(dataSet.COUNTRY_INFO);
                        break;
                    case 4:
                        allDataTableTableAdapter.Fill(dataSet.AllDataTable);
                        break;
                }
            });

            MainForm.CloseLoadingDialog();
        }

        #region filter_buttons
        private void winesFilterButton_Click(object sender, EventArgs e)
        {
            MainForm.StartLoadingDialog();

            WinformsHelper.InvokeIfRequired(this, () =>
            {
                BindingSource filteredBs = new BindingSource();
                filteredBs.DataSource = winesGridView.DataSource;

                StringBuilder builder = new StringBuilder();
                builder.Append($"CONVERT(id, 'System.String') LIKE '%{idFilter1.Text}%' ");
                if (winePriceLowFilter1.Value < winePriceHighFilter1.Value && winePriceHighFilter1.Value > 0 && winePriceLowFilter1.Value > 0)
                {
                    builder.Append($"AND price >= {winePriceLowFilter1.Value} AND price <= {winePriceHighFilter1.Value} ");
                }

                builder.Append($"AND CONVERT(country_id, 'System.String') LIKE '%{countryIdFilter1.Text}%' ");
                builder.Append($"AND winery LIKE '%{WineryFilter1.Text}%' ");
                builder.Append($"AND name LIKE '%{nameFilter1.Text}%' ");
                builder.Append($"AND variety LIKE '%{varietyFilter1.Text}%' ");

                filteredBs.Filter = builder.ToString();
                winesGridView.DataSource = filteredBs;
            });

            MainForm.CloseLoadingDialog();
        }

        private void clientsFilterButton_Click(object sender, EventArgs e)
        {
            MainForm.StartLoadingDialog();

            WinformsHelper.InvokeIfRequired(this, () =>
            {
                BindingSource filteredBs = new BindingSource();
                filteredBs.DataSource = clientsDataGrid.DataSource;

                StringBuilder builder = new StringBuilder();
                builder.Append($"id LIKE '%{idFilter2.Text}%' ");
                builder.Append($"AND name LIKE '%{nameFilter2.Text}%' ");
                builder.Append($"AND country_id LIKE '%{countryFilter2.Text}%' ");
                clientsDataGrid.DataSource = filteredBs;
            });

            MainForm.CloseLoadingDialog();
        }

        private void allDataMergedFilterButton_Click(object sender, EventArgs e)
        {
            MainForm.StartLoadingDialog();

            WinformsHelper.InvokeIfRequired(this, () =>
            {
                BindingSource filteredBs = new BindingSource();
                filteredBs.DataSource = allDataMergedDataGrid.DataSource;

                StringBuilder builder = new StringBuilder();
                builder.Append($"ClientName LIKE '%{clientNameFilter3.Text}%' ");
                builder.Append($"AND ClientDateOfBirth LIKE '%{clientDateOfBirthFilter3.Text}%' ");
                builder.Append($"AND WineName LIKE '%{wineNameFlter3.Text}%' ");
                builder.Append($"AND WineVariety LIKE '%{wineVarietyFilter3.Text}%' ");
                builder.Append($"AND WineCountry LIKE '%{wineCountryFilter3.Text}%' ");
                if (winePriceLowFilter3.Value < winePriceHighFilter3.Value && winePriceHighFilter3.Value > 0 && winePriceLowFilter3.Value > 0)
                {
                    builder.Append($"AND price >= {winePriceLowFilter3.Value} AND price <= {winePriceHighFilter3.Value} ");
                }

                filteredBs.Filter = builder.ToString();
                allDataMergedDataGrid.DataSource = filteredBs;
            });

            MainForm.CloseLoadingDialog();

        }

        private void soldWinesFilterButton_Click(object sender, EventArgs e)
        {
            MainForm.StartLoadingDialog();

            WinformsHelper.InvokeIfRequired(this, () =>
            {
                BindingSource filteredBs = new BindingSource();
                filteredBs.DataSource = soldWinesDataGrip.DataSource;

                StringBuilder builder = new StringBuilder();
                builder.Append($"id LIKE '%{idFilter4.Text}%' ");
                builder.Append($"AND id_wine LIKE '%{idWineFilter4.Text}%' ");
                builder.Append($"AND id_client LIKE '%{idClientFilter4.Text}%' ");
                builder.Append($"AND quantity LIKE '%{quantityFilter4.Text}%' ");
                filteredBs.Filter = builder.ToString();
                soldWinesDataGrip.DataSource = filteredBs;
            });

            MainForm.CloseLoadingDialog();
        }

        private void countriesFilterButton_Click(object sender, EventArgs e)
        {
            MainForm.StartLoadingDialog();

            WinformsHelper.InvokeIfRequired(this, () =>
            {
                BindingSource filteredBs = new BindingSource();
                filteredBs.DataSource = dataGridView4.DataSource;

                StringBuilder builder = new StringBuilder();
                builder.Append($"CONVERT(id, 'System.String') LIKE '%{idFilter5.Text}%' ");
                builder.Append($"AND name LIKE '%{nameFilter5.Text}%' ");
                filteredBs.Filter = builder.ToString();
                dataGridView4.DataSource = filteredBs;
            });

            MainForm.CloseLoadingDialog();
        }

        #endregion


        #region Exports
        private void exportToExcelButton1_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.StartLoadingDialog();
                ExportToExcelHelper.ExportGridviewToExcel(winesGridView, $@"{Application.StartupPath}\ExportWines.xlsx");
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
    }
}
