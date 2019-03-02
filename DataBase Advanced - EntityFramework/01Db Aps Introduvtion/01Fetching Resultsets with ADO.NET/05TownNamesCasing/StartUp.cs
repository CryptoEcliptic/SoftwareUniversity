using _01InitialSetup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace _05TownNamesCasing
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string countryName = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(Configuration.connectionString))
            {
                connection.Open();

                string updateNamesQuery = @"UPDATE Towns SET Name = UPPER(Name) FROM Towns WHERE CountryCode IN (SELECT Id FROM Countries WHERE Name = @countryName)";

                string capitalLetterQuery = @"SELECT UPPER(Name) FROM Towns WHERE CountryCode IN (SELECT Id FROM Countries WHERE Name = @countryName)";

                List<string> townList = new List<string>();
                int affectedRows = 0;

                using (SqlCommand command = new SqlCommand(updateNamesQuery, connection))
                {
                    command.Parameters.AddWithValue("countryName", countryName);
                    affectedRows = command.ExecuteNonQuery();
                    if (affectedRows > 0)
                    {
                        Console.WriteLine($"{affectedRows} town names were affected.");
                    }                
                }

                using (SqlCommand selectCommand = new SqlCommand(capitalLetterQuery, connection))
                {
                    selectCommand.Parameters.AddWithValue("countryName", countryName);
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("No town names were affected.");
                            return;
                        }
                        while (reader.Read())
                        {
                            townList.Add((string)reader[0]);
                        }
                        reader.Close();
                        Console.WriteLine("[" + (string.Join(", ", townList)) + "]");                
                    }
                }
                connection.Close();
            }
        } 
    }
}
