using _01InitialSetup;
using System;
using System.Data.SqlClient;

namespace _06RemoveVillain
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(Configuration.connectionString))
            {
                connection.Open();
                string villainIdQuery = @"SELECT Name FROM Villains WHERE Id = @id";
                string villainName = null;

                using (SqlCommand command = new SqlCommand(villainIdQuery, connection))
                {
                    SqlTransaction transaction = connection.BeginTransaction();
                    command.Transaction = transaction;

                    command.Parameters.AddWithValue("id", villainId);
                    villainName = (string)command.ExecuteScalar();
                    if (villainName == null)
                    {
                        Console.WriteLine("No such villain was found.");
                        return;
                    }
                    transaction.Commit();
                }

                string deleteFromMappingTaleQuery = @"DELETE FROM MinionsVillains WHERE VillainId = @id";
                int deletedRows = 0;
                using (SqlCommand command = new SqlCommand(deleteFromMappingTaleQuery, connection))
                {
                    SqlTransaction transaction = connection.BeginTransaction();
                    command.Transaction = transaction;

                    command.Parameters.AddWithValue("id", villainId);
                    deletedRows = (int)command.ExecuteNonQuery();

                    transaction.Commit();
                }

                Console.WriteLine($"{villainName} was deleted.");
                Console.WriteLine($"{deletedRows} minions were released.");
                connection.Close();
            }
        }
    }
}
