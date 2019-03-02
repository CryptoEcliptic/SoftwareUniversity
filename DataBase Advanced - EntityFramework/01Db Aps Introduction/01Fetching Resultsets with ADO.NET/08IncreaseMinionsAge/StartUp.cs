using _01InitialSetup;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace _08IncreaseMinionsAge
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] minionIds = Console.ReadLine().Split().Select(int.Parse).ToArray();

            using (SqlConnection connection = new SqlConnection(Configuration.connectionString))
            {
                connection.Open();
                string updateMinionsQuery = @"UPDATE Minions SET Name = UPPER(LEFT(Name, 1)) + LOWER(RIGHT(Name, LEN(Name) - 1)), Age += 1 WHERE Id = (@minionsId)";

                for (int i = 0; i < minionIds.Length; i++)
                {
                    int currentId = minionIds[i];

                    using (SqlCommand command = new SqlCommand(updateMinionsQuery, connection))
                    {
                        command.Parameters.AddWithValue("minionsId", currentId);
                        command.ExecuteNonQuery();
                    }
                }
                string selectAllMInionsQuery = @"SELECT Name, Age FROM Minions";

                using (SqlCommand command = new SqlCommand(selectAllMInionsQuery, connection))
                {
                    using (SqlDataReader reader =  command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = (string)reader[0];
                            int age = (int)reader[1];
                            Console.WriteLine($"{name} {age}");
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
        }
    }
}
