using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Winery.Helper;
using Winery.Views;

namespace Winery
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.databaseOverviewTabControl.Dock = DockStyle.Fill;
            this.panel1.Dock = DockStyle.Fill;
            LoadingForm loadingDialog = new LoadingForm(() =>
             {
                 Thread.Sleep(5000);

                 if (InvokeRequired)
                 {
                     Invoke(new Action(() =>
                     {
                         this.WinesTableAdapter.Fill(this.dataSet2.WINES);
                     }));
                 }
                 else
                 {
                     this.WinesTableAdapter.Fill(this.dataSet2.WINES);
                 }
             });

            loadingDialog.ShowDialog();
            loadingDialog.Dispose();

            this.databaseOverviewTabControl.Visible = true;
        }

        private void winesFilterButton_Click(object sender, EventArgs e)
        {
            LoadingForm loadingDialog = new LoadingForm(() =>
            {
                Thread.Sleep(1000);

                this.Invoke(new Action(() =>
                {
                    BindingSource bs = new BindingSource();
                    bs.DataSource = dataGridView1.DataSource;

                    StringBuilder builder = new StringBuilder();
                    builder.Append($"CONVERT(id, 'System.String') LIKE '%{idFilter.Text}%' ");
                    if (numericUpDown1.Value < numericUpDown3.Value && numericUpDown3.Value > 0 && numericUpDown1.Value > 0)
                        builder.Append($"AND price >= {numericUpDown1.Value} AND price <= {numericUpDown3.Value} ");
                    builder.Append($"AND CONVERT(country_id, 'System.String') LIKE '%{countryIdFilter.Text}%' ");
                    builder.Append($"AND winery LIKE '%{WineryFilter.Text}%' ");
                    builder.Append($"AND name LIKE '%{nameFilter.Text}%' ");
                    builder.Append($"AND variety LIKE '%{varietyFilter.Text}%' ");

                    bs.Filter = builder.ToString();
                    dataGridView1.DataSource = bs;
                }));
            });

            loadingDialog.ShowDialog();
            loadingDialog.Dispose();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ResetMenuItems()
        {
            foreach (ToolStripMenuItem item in this.menuStrip1.Items)
            {
                item.BackColor = SystemColors.ActiveCaption;
            }
        }

        private void toolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ResetMenuItems();
            ((ToolStripMenuItem)sender).BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ResetViews();
            this.ChangeView((ToolStripMenuItem)sender);
        }

        private void ResetViews()
        {
            foreach (Control control in this.splitContainer2.Panel2.Controls)
            {
                control.Visible = false;
            }
        }

        private void ChangeView(ToolStripMenuItem sender)
        {
            switch (sender.Text)
            {
                case "Database Overview":
                    this.databaseOverviewTabControl.Visible = true;
                    break;

                case "Data Generator":
                    this.panel1.Visible = true;
                    break;

                case "Graphs":

                    break;

            }

        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadingForm loadingDialog = new LoadingForm(() =>
            {
                Thread.Sleep(1000);
                if (InvokeRequired)
                {
                    Invoke(new Action(() =>
                    {
                        switch (((TabControl)sender).SelectedIndex)
                        {
                            case 0:
                                this.WinesTableAdapter.Fill(this.dataSet2.WINES);
                                break;
                            case 1:
                                this.cLIENTSTableAdapter.Fill(this.dataSet2.CLIENTS);
                                break;
                            case 2:
                                this.sOLD_WINESTableAdapter.Fill(this.dataSet2.SOLD_WINES);
                                break;
                            case 3:
                                this.cOUNTRY_INFOTableAdapter.Fill(this.dataSet2.COUNTRY_INFO);
                                break;
                            case 4:
                                this.allDataTableTableAdapter.Fill(this.dataSet2.AllDataTable);
                                break;
                        }
                    }));
                }
                else
                {
                    switch (((TabControl)sender).SelectedIndex)
                    {
                        case 0:
                            this.WinesTableAdapter.Fill(this.dataSet2.WINES);
                            break;
                        case 1:
                            this.cLIENTSTableAdapter.Fill(this.dataSet2.CLIENTS);
                            break;
                        case 2:
                            this.sOLD_WINESTableAdapter.Fill(this.dataSet2.SOLD_WINES);
                            break;
                        case 3:
                            this.cOUNTRY_INFOTableAdapter.Fill(this.dataSet2.COUNTRY_INFO);
                            break;
                        case 4:
                            this.allDataTableTableAdapter.Fill(this.dataSet2.AllDataTable);
                            break;
                    }
                }
            });

            loadingDialog.ShowDialog();
            loadingDialog.Dispose();
        }

        private void clientsFilterButton_Click(object sender, EventArgs e)
        {
            LoadingForm loadingDialog = new LoadingForm(() =>
            {
                Thread.Sleep(1000);

                this.Invoke(new Action(() =>
                {
                    BindingSource bs = new BindingSource();
                    bs.DataSource = dataGridView2.DataSource;

                    StringBuilder builder = new StringBuilder();
                    builder.Append($"id LIKE '%{textBox4.Text}%' ");
                    builder.Append($"AND name LIKE '%{textBox5.Text}%' ");
                    builder.Append($"AND country_id LIKE '%{textBox3.Text}%' ");
                    dataGridView2.DataSource = bs;
                }));
            });

            loadingDialog.ShowDialog();
            loadingDialog.Dispose();
        }

        private void allDataMergedFilterButton_Click(object sender, EventArgs e)
        {
            LoadingForm loadingDialog = new LoadingForm(() =>
            {
                Thread.Sleep(1000);

                this.Invoke(new Action(() =>
                {
                    BindingSource bs = new BindingSource();
                    bs.DataSource = dataGridView5.DataSource;

                    StringBuilder builder = new StringBuilder();
                    builder.Append($"ClientName LIKE '%{textBox15.Text}%' ");
                    builder.Append($"AND ClientDateOfBirth LIKE '%{textBox16.Text}%' ");
                    builder.Append($"AND WineName LIKE '%{textBox14.Text}%' ");
                    builder.Append($"AND WineVariety LIKE '%{textBox13.Text}%' ");
                    builder.Append($"AND WineCountry LIKE '%{textBox12.Text}%' ");
                    if (numericUpDown5.Value < numericUpDown6.Value && numericUpDown6.Value > 0 && numericUpDown5.Value > 0)
                        builder.Append($"AND price >= {numericUpDown5.Value} AND price <= {numericUpDown6.Value} ");
                    bs.Filter = builder.ToString();
                    dataGridView5.DataSource = bs;
                }));
            });

            loadingDialog.ShowDialog();
            loadingDialog.Dispose();
        }

        private void soldWinesFilterButton_Click(object sender, EventArgs e)
        {
            LoadingForm loadingDialog = new LoadingForm(() =>
            {
                Thread.Sleep(1000);

                this.Invoke(new Action(() =>
                {
                    BindingSource bs = new BindingSource();
                    bs.DataSource = dataGridView3.DataSource;

                    StringBuilder builder = new StringBuilder();
                    builder.Append($"id LIKE '%{textBox2.Text}%' ");
                    builder.Append($"AND id_wine LIKE '%{textBox6.Text}%' ");
                    builder.Append($"AND id_client LIKE '%{textBox1.Text}%' ");
                    builder.Append($"AND quantity LIKE '%{textBox17.Text}%' ");
                    bs.Filter = builder.ToString();
                    dataGridView3.DataSource = bs;
                }));
            });

            loadingDialog.ShowDialog();
            loadingDialog.Dispose();
        }

        private void countriesFilterButton_Click(object sender, EventArgs e)
        {
            LoadingForm loadingDialog = new LoadingForm(() =>
            {
                Thread.Sleep(1000);

                this.Invoke(new Action(() =>
                {
                    BindingSource bs = new BindingSource();
                    bs.DataSource = dataGridView4.DataSource;

                    StringBuilder builder = new StringBuilder();
                    builder.Append($"CONVERT(id, 'System.String') LIKE '%{textBox10.Text}%' ");
                    builder.Append($"AND name LIKE '%{textBox11.Text}%' ");
                    bs.Filter = builder.ToString();
                    dataGridView4.DataSource = bs;
                }));
            });

            loadingDialog.ShowDialog();
            loadingDialog.Dispose();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void GenerateClientsButton_Click(object sender, EventArgs e)
        {
            int legalAge = 18;
            if (this.birthDateTo.Value < this.birthDateFrom.Value)
            {
                MessageBox.Show("Client date of birth is set incorrectly. End time should be after start time.");
                return;
            }

            if (this.birthDateFrom.Value < DateTime.Now.Subtract(TimeSpan.FromDays(legalAge * 365.25)))
            {
                MessageBox.Show($"Generated clients would be too young to drink. Please set date of birth before {DateTime.Now.Subtract(TimeSpan.FromDays(legalAge * 365.25)).ToShortDateString()}");
                return;
            }

            if (this.winePriceTo.Value < this.winePriceFrom.Value)
            {
                MessageBox.Show($"Wine Price interval is set incorrectly. {this.winePriceFrom.Value} -> {this.winePriceTo.Value}");
                return;
            }

            if (this.totalExpensesTo.Value < this.totalExpensesFrom.Value)
            {
                MessageBox.Show($"Total Expenses interval is set incorrectly. {this.totalExpensesFrom.Value} -> {this.totalExpensesTo.Value}");
                return;
            }

            if (this.saleDateFrom.Value > this.saleDateTo.Value)
            {
                MessageBox.Show("Date of sale is set incorrectly. End time should be after start time.");
                return;
            }

            if (this.saleDateFrom.Value > DateTime.Now.Subtract(TimeSpan.FromDays(legalAge * 365.25)))
            {
                MessageBox.Show($"Generated clients would be too young to drink. Please set date of birth before {DateTime.Now.Subtract(TimeSpan.FromDays(legalAge * 365.25)).ToShortDateString()}");
                return;
            }

            this.GenerateClients(
                this.birthDateFrom.Value,
                this.birthDateTo.Value,
                this.clientGender.Text,
                this.countryName.Text,
                this.winePriceFrom.Value,
                this.winePriceTo.Value,
                this.totalExpensesFrom.Value,
                this.totalExpensesTo.Value,
                this.maxQuantity.Value,
                this.wineNameFilter.Text,
                this.saleDateFrom.Value,
                this.saleDateTo.Value,
                this.generateCount.Value);

            MessageBox.Show("Finished generating.");
        }

        private void GenerateClients(
            DateTime birthDateFrom,
            DateTime birthDateTo,
            string clientGender,
            string countryName,
            decimal winePriceFrom,
            decimal winePriceTo,
            decimal totalExpensesFrom,
            decimal totalExpensesTo,
            decimal maxQuantity,
            string wineNameFilter,
            DateTime saleDateFrom,
            DateTime saleDateTo,
            decimal generateCount)
        {
            List<int> wines = DatabaseCommandHelper.GetWinesSelectionIds(winePriceFrom, winePriceTo, wineNameFilter);
            if (wines == null || wines.Count == 0)
            {
                MessageBox.Show($"There are no wines within the selected interval: [{winePriceFrom}]-[{winePriceTo}]");
                return;
            }

            for (int i = 0; i < generateCount; i++)
            {
                var clientId = this.CreateNewClient(birthDateFrom, birthDateTo, countryName, clientGender);
                var budget = RandomGenerator.GenerateRandomNumberBetween(totalExpensesFrom, totalExpensesTo);
                bool finishedBudget = false;
                while (!finishedBudget)
                {
                    var wineId = RandomGenerator.GetRandomWineFromList(wines);
                    var winePrice = DatabaseCommandHelper.GetWinePriceById(wineId);
                    var quantity = RandomGenerator.GenerateRandomNumber(maxQuantity);

                    if (winePrice * quantity > budget)
                    {
                        quantity = budget / winePrice;
                        finishedBudget = true;
                    }
                    var dateOfSale = RandomGenerator.GenerateRandomDate(saleDateFrom, saleDateTo);

                    DatabaseCommandHelper.InsertSaleInfo(clientId, wineId, quantity, dateOfSale);
                    budget -= winePrice * quantity;
                }
            }

            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "";
        }

        private int CreateNewClient(DateTime birthDateFrom, DateTime birthDateTo, string countryName, string clientGender)
        {
            var clientName = RandomGenerator.GenerateClientName();
            var dateOfBirth = RandomGenerator.GenerateRandomDate(birthDateFrom, birthDateTo);
            if (clientGender.Equals("ANY"))
            {
                clientGender = RandomGenerator.GenerateRandomGender();
            }

            int countryId = DatabaseCommandHelper.GetCountryId(countryName);
            if (countryId == -1)
            {
                countryId = RandomGenerator.GenerateRandomCountry();
            }

            return DatabaseCommandHelper.InsertClientInfo(clientName, dateOfBirth, countryId, clientGender); ;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
