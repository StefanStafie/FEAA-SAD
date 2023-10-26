using System;
using System.Collections.Generic;
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
            MainForm.StartLoadingDialog();

            if (!CheckFormData())
            {
                return;
            }

            GenerateClients(
                birthDateFrom.Value,
                birthDateTo.Value,
                clientGender.Text,
                countryName.Text,
                winePriceFrom.Value,
                winePriceTo.Value,
                totalExpensesFrom.Value,
                totalExpensesTo.Value,
                maxQuantity.Value,
                wineNameFilter.Text,
                saleDateFrom.Value,
                saleDateTo.Value,
                generateCount.Value);

            MainForm.CloseLoadingDialog();
            MessageBox.Show("Finished generating.");
        }

        private bool CheckFormData()
        {
            int legalAge = 18;
            if (birthDateTo.Value < birthDateFrom.Value)
            {
                MessageBox.Show("Client date of birth is set incorrectly. End time should be after start time.");
                return false;
            }

            if (birthDateFrom.Value > DateTime.Now.Subtract(TimeSpan.FromDays(legalAge * 365.25)))
            {
                MessageBox.Show($"Generated clients would be too young to drink. Please set date of birth before {DateTime.Now.Subtract(TimeSpan.FromDays(legalAge * 365.25)).ToShortDateString()}");
                return false;
            }

            if (winePriceTo.Value < winePriceFrom.Value)
            {
                MessageBox.Show($"Wine Price interval is set incorrectly. {winePriceFrom.Value} -> {winePriceTo.Value}");
                return false;
            }

            if (totalExpensesTo.Value < totalExpensesFrom.Value)
            {
                MessageBox.Show($"Total Expenses interval is set incorrectly. {totalExpensesFrom.Value} -> {totalExpensesTo.Value}");
                return false;
            }

            if (saleDateFrom.Value > saleDateTo.Value)
            {
                MessageBox.Show("Date of sale is set incorrectly. End time should be after start time.");
                return false;
            }

            if (saleDateFrom.Value < birthDateTo.Value.Add(TimeSpan.FromDays(legalAge * 365.25)))
            {
                MessageBox.Show($"Generated clients would be too young to drink. Please set date of birth before {DateTime.Now.Subtract(TimeSpan.FromDays(legalAge * 365.25)).ToShortDateString()}");
                return false;
            }

            if (String.IsNullOrEmpty(clientGender.Text))
            {
                clientGender.SelectedValue = "ANY";
            }

            if (String.IsNullOrEmpty(countryName.Text))
            {
                countryName.SelectedValue = "ANY";
            }

            return true;
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
                var clientId = CreateNewClient(birthDateFrom, birthDateTo, countryName, clientGender);
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

        private void GenerateSalesOnlyButton_Click(object sender, EventArgs e)
        {
            MainForm.StartLoadingDialog();

            if (!CheckFormData())
            {
                return;
            }

            GenerateSales(
                birthDateFrom.Value,
                birthDateTo.Value,
                clientGender.Text,
                countryName.Text,
                winePriceFrom.Value,
                winePriceTo.Value,
                totalExpensesFrom.Value,
                totalExpensesTo.Value,
                maxQuantity.Value,
                wineNameFilter.Text,
                saleDateFrom.Value,
                saleDateTo.Value,
                generateCount.Value);

            MainForm.CloseLoadingDialog();
            MessageBox.Show("Finished generating.");
        }

        private void GenerateSales(
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

            List<int> clients = DatabaseCommandHelper.GetClientsSelectionIds(birthDateFrom, birthDateTo);
            if (clients == null || clients.Count == 0)
            {
                MessageBox.Show($"There are no clients within the selected interval: [{winePriceFrom}]-[{winePriceTo}]");
                return;
            }

            for (int i = 0; i < generateCount; i++)
            {
                var clientId = RandomGenerator.GetRandomClient(clients);
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
        }
    }
}
