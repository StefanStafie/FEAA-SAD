using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Winery.Helper
{
    static public class DatabaseCommandHelper
    {
        const string connectionString = "Data Source=localhost;User Id=NEW_USER;Password=password123;";

        static public List<int> GetCountryIds()
        {
            List<int> countryIds = new List<int>();

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT \"id\" FROM NEW_USER.COUNTRY_INFO";

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

                string query = "SELECT \"id\" FROM NEW_USER.COUNTRY_INFO WHERE \"name\" = :countryName";

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

                string query = "INSERT INTO NEW_USER.CLIENTS (\"id\", \"name\", \"country_id\", \"date_of_birth\", \"SEX\") VALUES ( (SELECT MAX(\"id\") + 1 AS ID FROM NEW_USER.CLIENTS), :clientName, :countryId, :dateOfBirth, :clientGender)";

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

                string query = "SELECT \"id\" FROM NEW_USER.WINES WHERE \"price\" BETWEEN :winePriceFrom AND :winePriceTo AND \"name\" LIKE '%' || :wineNameFilter || '%'";

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

                string query = "SELECT \"price\" FROM NEW_USER.WINES WHERE \"id\" = :wineId";

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

                string query = "INSERT INTO NEW_USER.SOLD_WINES (\"id\", \"id_wine\", \"id_client\", \"quantity\", \"SALE_DATE\") " +
                               "VALUES ((SELECT MAX(\"id\") +1 FROM NEW_USER.SOLD_WINES), :wineId, :clientId, :quantity, :dateOfSale)";

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

                string query = "SELECT MAX(\"id\") + 1 AS ID FROM NEW_USER.CLIENTS";

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
    }
}
