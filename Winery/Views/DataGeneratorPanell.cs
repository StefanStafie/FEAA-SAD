using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winery.Helper;

namespace Winery.Views
{
    public partial class DataGeneratorPanell : UserControl
    {
        public DataGeneratorPanell()
        {
            InitializeComponent();
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
    }
}
