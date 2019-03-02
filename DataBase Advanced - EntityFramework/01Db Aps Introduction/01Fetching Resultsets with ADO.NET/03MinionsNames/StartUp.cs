using _01InitialSetup;
using System;
using System.Data.SqlClient;
using System.Text;

namespace _03MinionsNames
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int inputId = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(Configuration.connectionString))
            {
                connection.Open();
                string villainName = GetVillain(inputId, connection);
                if (villainName == null)
                {
                    Console.WriteLine($"No villain with ID {inputId} exists in the database.");
                }
                else
                {
                    Console.WriteLine($"Villain: {villainName}");
                    string minionsNames = GetMinions(inputId, connection);
                    if (minionsNames == null)
                    {
                        Console.WriteLine("(no minions)");
                    }
                    else
                    {
                        Console.WriteLine(minionsNames);
                    }
                }

                connection.Close();
            }
        }

        private static string GetMinions(int villainId, SqlConnection connection)
        {
            string sqlMinionsCommand = @"SELECT m.[Name], m.Age FROM Minions As m JOIN MinionsVillains AS mv ON mv.MinionId = m.Id WHERE mv.VillainId = @id";
            StringBuilder sb = new StringBuilder();
            using (SqlCommand command = new SqlCommand(sqlMinionsCommand, connection))
            {
                command.Parameters.AddWithValue("id", villainId);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    int index = 1;
                    while (reader.Read())
                    {
                        sb.AppendLine($"{index++}. {reader[0]} {reader[1]}");
                    }
                    reader.Close();
                }
            }
            return sb.ToString().TrimEnd();
        }

        private static string GetVillain(int inputId, SqlConnection connection)
        {
            string sqlCommandVillain = @"SELECT Name FROM Villains WHERE Id = @id";
            using (SqlCommand command = new SqlCommand(sqlCommandVillain, connection))
            {
                command.Parameters.AddWithValue("id", inputId);
                return (string)command.ExecuteScalar();
            }
        }
    }
}
