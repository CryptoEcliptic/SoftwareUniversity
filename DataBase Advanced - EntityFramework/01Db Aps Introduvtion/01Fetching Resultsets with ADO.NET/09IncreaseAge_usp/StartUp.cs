using _01InitialSetup;
using System;
using System.Data.SqlClient;

namespace _09IncreaseAge_usp
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());
            using (SqlConnection connection = new SqlConnection(Configuration.connectionString))
            {
                connection.Open();
                string ageProcedureQuery = @"EXECUTE usp_GetOlder @minionId";
                using (SqlCommand command = new SqlCommand(ageProcedureQuery, connection))
                {
                    command.Parameters.Add(new SqlParameter("minionId", id));
                    command.ExecuteNonQuery();
                }

                string selectMinionQuery = @"SELECT Name, Age FROM Minions WHERE Id = @id";

                using (SqlCommand command = new SqlCommand(selectMinionQuery, connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader[0]} – {reader[1]} years old");
                        }
                        reader.Close();
                    }
                }

                connection.Close();
            }
        }
    }
}
