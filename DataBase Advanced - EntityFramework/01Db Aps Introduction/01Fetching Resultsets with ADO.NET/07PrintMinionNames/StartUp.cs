using _01InitialSetup;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _07PrintMinionNames
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<string> minions = new List<string>();
            using (SqlConnection connection = new SqlConnection(Configuration.connectionString))
            {
                connection.Open();
                string minionNamesQuery = @"SELECT Name FROM Minions";


                using (SqlCommand command = new SqlCommand(minionNamesQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            minions.Add((string)reader[0]);
                        }
                    }
                }
                connection.Close();
            }
            PrintResult(minions);

        }

        private static void PrintResult(List<string> minions)
        {
            if (minions.Count % 2 == 0)
            {
                for (int i = 0; i < minions.Count / 2; i++)
                {
                    Console.WriteLine(minions[i]);
                    Console.WriteLine(minions[minions.Count - 1 - i]);
                }
            }
            else
            {
                for (int i = 0; i < minions.Count / 2 + 1; i++)
                {
                    Console.WriteLine(minions[i]);

                    if (i != minions.Count / 2)
                    {
                        Console.WriteLine(minions[minions.Count - 1 - i]);
                    }

                }
            }
        }
    }
}
