using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using Winery.GraphsModels;
using Winery.Models;

namespace Winery.Helper
{
    static public class DatabaseCommandHelper
    {
        private const string connectionString = "Data Source=localhost;User Id=NEW_USER;Password=password123;";
        private const string GetClientWineSumaryQuery = "SELECT EXTRACT(YEAR FROM SYSDATE) - EXTRACT(YEAR FROM C.\"date_of_birth\") as Age, W.\"variety\" as variety, SUM(SW.\"quantity\") AS \"Total\" FROM \"NEW_USER\".\"CLIENTS\" C JOIN \"NEW_USER\".\"SOLD_WINES\" SW ON C.\"id\" = SW.\"id_client\" JOIN \"NEW_USER\".\"WINES\" W ON SW.\"id_wine\" = W.\"id\" GROUP BY EXTRACT(YEAR FROM SYSDATE) - EXTRACT(YEAR FROM C.\"date_of_birth\"), W.\"variety\" ORDER BY EXTRACT(YEAR FROM SYSDATE) - EXTRACT(YEAR FROM C.\"date_of_birth\")";
        private const string GetSoldWinesQuery = "SELECT W.\"name\" as name, W.\"variety\" as variety, W.\"winery\" as winery, W.\"price\" as price, SUM(SW.\"quantity\") AS \"Total\" FROM \"NEW_USER\".\"CLIENTS\" C JOIN \"NEW_USER\".\"SOLD_WINES\" SW ON C.\"id\" = SW.\"id_client\" JOIN \"NEW_USER\".\"WINES\" W ON SW.\"id_wine\" = W.\"id\" WHERE C.\"SEX\" = :gender AND EXTRACT(YEAR FROM SYSDATE) - EXTRACT(YEAR FROM C.\"date_of_birth\") = :age GROUP BY W.\"name\", W.\"variety\", W.\"winery\", W.\"price\" ORDER BY SUM(SW.\"quantity\") DESC";
        private const string GetWinesTreeviewQuery = "SELECT WINES.\"name\" as name, WINES.\"variety\" as variety, WINES.\"winery\" as winery, WINES.\"price\" as price, CI.\"name\" as countryName FROM WINES JOIN COUNTRY_INFO CI on CI.\"id\" = WINES.\"country_id\"";
        private const string GetDailySalesQuery = "WITH t1 as (SELECT \"winery\" a, \"SALE_DATE\", SUM(\"price\"*\"quantity\") b FROM SOLD_WINES JOIN NEW_USER.WINES W ON W.\"id\" = SOLD_WINES.\"id_wine\" GROUP BY \"SALE_DATE\", \"winery\") SELECT a, \"SALE_DATE\", b FROM t1 WHERE \"SALE_DATE\" BETWEEN :startDate AND :endDate ORDER BY \"SALE_DATE\" DESC";
        private const string GetCountryIdsQuery = "SELECT \"id\" FROM NEW_USER.COUNTRY_INFO";
        private const string GetCountryIdQuery = "SELECT \"id\" FROM NEW_USER.COUNTRY_INFO WHERE \"name\" = :countryName";
        private const string InsertClientInfoQuery = "INSERT INTO NEW_USER.CLIENTS (\"id\", \"name\", \"country_id\", \"date_of_birth\", \"SEX\") VALUES ( (SELECT MAX(\"id\") + 1 AS ID FROM NEW_USER.CLIENTS), :clientName, :countryId, :dateOfBirth, :clientGender)";
        private const string GetWinesSelectionIdsQuery = "SELECT \"id\" FROM NEW_USER.WINES WHERE \"price\" BETWEEN :winePriceFrom AND :winePriceTo AND \"name\" LIKE '%' || :wineNameFilter || '%'";
        private const string GetWinePriceByIdQuery = "SELECT \"price\" FROM NEW_USER.WINES WHERE \"id\" = :wineId";
        private const string GetWineryListQuery = "SELECT distinct \"winery\" from wines";
        private const string GetWineListQuery = "SELECT distinct \"name\" from wines order by 1";
        private const string InsertSaleInfoQuery = "INSERT INTO NEW_USER.SOLD_WINES (\"id\", \"id_wine\", \"id_client\", \"quantity\", \"SALE_DATE\") VALUES ((SELECT Coalesce(MAX(\"id\") +1, 0) FROM NEW_USER.SOLD_WINES), :wineId, :clientId, :quantity, :dateOfSale)";
        private const string GetNextClientIdQuery = "SELECT MAX(\"id\") + 1 AS ID FROM NEW_USER.CLIENTS";
        private const string GetClientsSelectionIdsQuery = "SELECT \"id\" FROM NEW_USER.CLIENTS WHERE \"date_of_birth\" BETWEEN :birthDateFrom AND :birthDateTo";
        private const string GetVarietyListQuery = "SELECT distinct \"variety\" from wines";
        private const string GetSameVarietyWinesQuery = "SELECT WINES.\"name\" as name, WINES.\"variety\" as variety, WINES.\"winery\" as winery, WINES.\"price\" as price, CI.\"name\" as countryName FROM WINES JOIN COUNTRY_INFO CI on CI.\"id\" = WINES.\"country_id\" WHERE WINES.\"variety\" = (SELECT WINES.\"variety\" from WINES where WINES.\"name\" = :name AND rownum = 1)";
        private const string PeopleAlsoBoughtQuery = "WITH TargetBuyers AS (SELECT SW1.\"id_client\" AS TargetClientId FROM \"NEW_USER\".\"SOLD_WINES\" SW1 JOIN \"NEW_USER\".\"WINES\" W1 ON SW1.\"id_wine\" = W1.\"id\" WHERE W1.\"name\" = :WineName) SELECT W.\"name\" as name, W.\"variety\" as variety, W.\"winery\" as winery, W.\"price\" as price, CI.\"name\" as countryName FROM \"NEW_USER\".\"SOLD_WINES\" SW2 JOIN \"NEW_USER\".\"WINES\" W ON SW2.\"id_wine\" = W.\"id\" JOIN \"NEW_USER\".\"CLIENTS\" C ON SW2.\"id_client\" = C.\"id\" JOIN NEW_USER.COUNTRY_INFO CI on C.\"country_id\" = CI.\"id\" WHERE SW2.\"id_client\" IN (SELECT TargetClientId FROM TargetBuyers) AND W.\"name\" != :WineName\r\n";

        #region Graphs
        static public List<string> GetWineList()
        {
            var result = new List<string>();

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                string query = GetWineListQuery;

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(reader.GetString(0));
                        }
                    }
                }
            }

            return result;
        }

        static public List<ClientWineSummary> GetClientWineSumary()
        {
            var result = new List<ClientWineSummary>();

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                string query = GetClientWineSumaryQuery;

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ClientWineSummary clientWineSummary = new ClientWineSummary
                            {
                                Age = reader.GetInt32(0),
                                Variety = reader.GetString(1),
                                Quantity = reader.GetInt32(2)
                            };

                            result.Add(clientWineSummary);
                        }
                    }
                }
            }

            return result;
        }

        static public List<SoldWines> GetSoldWines(int age, string gender)
        {
            var result = new List<SoldWines>();

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                string query = GetSoldWinesQuery;

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("gender", OracleDbType.Varchar2)).Value = gender;
                    command.Parameters.Add(new OracleParameter("age", OracleDbType.Int32)).Value = age;

                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SoldWines soldWine = new SoldWines
                            {
                                Name = reader.GetString(0),
                                Variety = reader.GetString(1),
                                Winery = reader.GetString(2),
                                Price = reader.GetInt32(3),
                                Quantity = reader.GetInt32(4)
                            };

                            result.Add(soldWine);
                        }
                    }
                }
            }

            return result;
        }

        static public Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, Wine>>>> GetWinesTreeview()
        {
            var result = new Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, Wine>>>>();

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                string query = GetWinesTreeviewQuery;

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Wine wine = new Wine
                            {
                                Name = reader.GetString(0),
                                Variety = reader.GetString(1),
                                Winery = reader.GetString(2),
                                Price = reader.GetInt32(3),
                                CountryName = reader.GetString(4)
                            };

                            if (!result.ContainsKey(wine.CountryName))
                            {
                                result[wine.CountryName] = new Dictionary<string, Dictionary<string, Dictionary<string, Wine>>>();
                            }

                            if (!result[wine.CountryName].ContainsKey(wine.Winery))
                            {
                                result[wine.CountryName][wine.Winery] = new Dictionary<string, Dictionary<string, Wine>>();
                            }

                            if (!result[wine.CountryName][wine.Winery].ContainsKey(wine.Variety))
                            {
                                result[wine.CountryName][wine.Winery][wine.Variety] = new Dictionary<string, Wine>();
                            }

                            result[wine.CountryName][wine.Winery][wine.Variety][wine.Name] = wine;
                        }
                    }
                }

            }

            return result;
        }

        static public List<WineryDailySalesModel> GetDailySales(DateTime startDate, DateTime endDate)
        {
            var result = new List<WineryDailySalesModel>();

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                string query = GetDailySalesQuery;

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("startDate", OracleDbType.Date)).Value = startDate;
                    command.Parameters.Add(new OracleParameter("endDate", OracleDbType.Date)).Value = endDate;

                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new WineryDailySalesModel(reader.GetString(0), reader.GetDateTime(1), reader.GetInt32(2)));
                        }
                    }
                }
            }

            return result;
        }

        public static List<string> GetWineryList()
        {
            var result = new List<string>();

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                string query = GetWineryListQuery;

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(reader.GetString(0));
                        }
                    }
                }
            }

            return result;
        }

        internal static List<string> GetVarietyList()
        {
            var result = new List<string>();

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                string query = GetVarietyListQuery;

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(reader.GetString(0));
                        }
                    }
                }
            }

            return result;
        }

        internal static List<Wine> GetSameVarietyWines(string wineName)
        {
            var result = new List<Wine>();

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                string query = GetSameVarietyWinesQuery;

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("name", OracleDbType.Varchar2)).Value = wineName;

                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Wine wine = new Wine
                            {
                                Name = reader.GetString(0),
                                Variety = reader.GetString(1),
                                Winery = reader.GetString(2),
                                Price = reader.GetInt32(3),
                                CountryName = reader.GetString(4)
                            };

                            result.Add(wine);
                        }
                    }
                }
            }

            return result;
        }

        internal static List<Wine> PeopleAlsoBought(string wineName)
        {
            var result = new List<Wine>();

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                string query = PeopleAlsoBoughtQuery;

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("WineName", OracleDbType.Varchar2)).Value = wineName;

                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Wine wine = new Wine
                            {
                                Name = reader.GetString(0),
                                Variety = reader.GetString(1),
                                Winery = reader.GetString(2),
                                Price = reader.GetInt32(3),
                                CountryName = reader.GetString(4)
                            };

                            result.Add(wine);
                        }
                    }
                }
            }

            return result;
        }

        static public List<ClientExpensesModel> GetClientExpenses(int startAge, int endAge)
        {
            var result = new List<ClientExpensesModel>();

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT C.\"name\" AS \"clientName\", C.\"SEX\" AS \"clientSex\", EXTRACT(YEAR FROM SYSDATE) - EXTRACT(YEAR FROM \"date_of_birth\") AS \"ClientAge\", CI.\"name\" AS \"countryName\", SUM(W.\"price\" * SW.\"quantity\") AS \"Expenses\" FROM \"NEW_USER\".\"CLIENTS\" C JOIN \"NEW_USER\".\"SOLD_WINES\" SW ON C.\"id\" = SW.\"id_client\" JOIN \"NEW_USER\".\"WINES\" W ON SW.\"id_wine\" = W.\"id\" JOIN \"NEW_USER\".\"COUNTRY_INFO\" CI ON CI.\"id\" = C.\"country_id\" WHERE EXTRACT(YEAR FROM SYSDATE) - EXTRACT(YEAR FROM \"date_of_birth\") BETWEEN :startAge AND :endAge GROUP BY C.\"name\", C.\"SEX\", C.\"date_of_birth\", CI.\"name\"";

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("startAge", OracleDbType.Int32)).Value = startAge;
                    command.Parameters.Add(new OracleParameter("endAge", OracleDbType.Int32)).Value = endAge;

                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new ClientExpensesModel(reader.GetString(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3), reader.GetInt32(4)));
                        }
                    }
                }
            }

            return result;
        }

        #endregion

        #region DataGenerator

        static public List<int> GetCountryIds()
        {
            List<int> countryIds = new List<int>();

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                string query = GetCountryIdsQuery;

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(reader.GetOrdinal("id"));
                            countryIds.Add(id);
                        }
                    }
                }
            }

            return countryIds;
        }

        public static int GetCountryId(string countryName)
        {
            int countryId = -1;

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                string query = GetCountryIdQuery;

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("countryName", countryName));
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            countryId = reader.GetInt32(reader.GetOrdinal("id"));
                        }
                    }
                }
            }

            return countryId;
        }

        public static int InsertClientInfo(string clientName, DateTime dateOfBirth, int countryId, string clientGender)
        {
            var clientId = GetNextClientId();

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                string query = InsertClientInfoQuery;

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("clientName", clientName));
                    command.Parameters.Add(new OracleParameter("countryId", countryId));
                    command.Parameters.Add(new OracleParameter("dateOfBirth", dateOfBirth));
                    command.Parameters.Add(new OracleParameter("clientGender", clientGender));

                    command.ExecuteNonQuery();
                }
            }

            return clientId;
        }

        public static List<int> GetWinesSelectionIds(decimal winePriceFrom, decimal winePriceTo, string wineNameFilter)
        {
            List<int> wineIds = new List<int>();

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                string query = GetWinesSelectionIdsQuery;

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("winePriceFrom", winePriceFrom));
                    command.Parameters.Add(new OracleParameter("winePriceTo", winePriceTo));
                    command.Parameters.Add(new OracleParameter("wineNameFilter", wineNameFilter));

                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int wineId = reader.GetInt32(reader.GetOrdinal("id"));
                            wineIds.Add(wineId);
                        }
                    }
                }
            }

            return wineIds;
        }

        public static int GetWinePriceById(int wineId)
        {
            decimal price = -1;

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                string query = GetWinePriceByIdQuery;

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("wineId", wineId));
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            price = reader.GetDecimal(reader.GetOrdinal("price"));
                        }
                    }
                }
            }

            return (int)price;
        }

        public static void InsertSaleInfo(int clientId, int wineId, int quantity, DateTime dateOfSale)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                string query = InsertSaleInfoQuery;

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("wineId", wineId));
                    command.Parameters.Add(new OracleParameter("clientId", clientId));
                    command.Parameters.Add(new OracleParameter("quantity", quantity));
                    command.Parameters.Add(new OracleParameter("dateOfSale", dateOfSale));

                    command.ExecuteNonQuery();
                }
            }
        }

        private static int GetNextClientId()
        {
            int nextClientId = -1;

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                string query = GetNextClientIdQuery;

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read() && !reader.IsDBNull(reader.GetOrdinal("ID")))
                        {
                            nextClientId = reader.GetInt32(reader.GetOrdinal("ID"));
                        }
                    }
                }
            }

            return nextClientId;
        }

        internal static List<int> GetClientsSelectionIds(DateTime birthDateFrom, DateTime birthDateTo)
        {
            List<int> clientIds = new List<int>();

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                string query = GetClientsSelectionIdsQuery;

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(new OracleParameter("birthDateFrom", OracleDbType.Date)).Value = birthDateFrom;
                    command.Parameters.Add(new OracleParameter("birthDateTo", OracleDbType.Date)).Value = birthDateTo;


                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int clientId = reader.GetInt32(reader.GetOrdinal("id"));
                            clientIds.Add(clientId);
                        }
                    }
                }
            }

            return clientIds;
        }

        #endregion
    }
}
