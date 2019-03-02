using _01InitialSetup;
using System;
using System.Data.SqlClient;

namespace _04AddMinion
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] inputMinion = Console.ReadLine().Split(": ");
            string[] minionData = inputMinion[1].Split();
            string minionName = minionData[0];
            int age = int.Parse(minionData[1]);
            string city = minionData[2];

            string[] villainData = Console.ReadLine().Split(": ");
            string villainName = villainData[1];
            Console.WriteLine();

            using (SqlConnection connection = new SqlConnection(Configuration.connectionString))
            {
                connection.Open();
                bool isCityExists = CheckCityExists(city, connection);
                if (!isCityExists)
                {
                    AddCityToTheDatabase(city, connection);
                }
                CheckVillain(villainName, connection);
                AddMinion(minionName, age, city, connection);
                AddMinionToVillain(villainName, minionName, connection);

                connection.Close();
            }
        }

        private static void AddMinionToVillain(string villainName, string minionName, SqlConnection connection)
        {
            string villainIdSqlQuery = @"SELECT Id From Villains WHERE Name = @villainName";

            string minionIdSqlQuery = @"SELECT Id FROM Minions WHERE Name = @minionName";

            string insertIntoMapTableSql = @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@MinionId, @VillainId)";

            int villainId = 0;
            int minionId = 0;

            using (SqlCommand command = new SqlCommand(villainIdSqlQuery, connection))
            {
                command.Parameters.AddWithValue("villainName", villainName);
                villainId = (int)command.ExecuteScalar();
            }

            using (SqlCommand command = new SqlCommand(minionIdSqlQuery, connection))
            {
                command.Parameters.AddWithValue("minionName", minionName);
                minionId = (int)command.ExecuteScalar();
            }

            using (SqlCommand command = new SqlCommand(insertIntoMapTableSql, connection))
            {
                command.Parameters.AddWithValue("MinionId", minionId);
                command.Parameters.AddWithValue("VillainId", villainId);
                command.ExecuteNonQuery();
            }

            Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
        }

        private static void AddMinion(string minionName, int age, string city, SqlConnection connection)
        {
            int townId = 0;
            string SqlCheckTownCommand = @"SELECT Id From Towns WHERE Name = @name";
            string SqlAddMinionCommand = @"INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";

            using (SqlCommand command = new SqlCommand(SqlCheckTownCommand, connection))
            {
                command.Parameters.AddWithValue("name", city);
                townId = (int)command.ExecuteScalar();
            }
            using (SqlCommand command = new SqlCommand(SqlAddMinionCommand, connection))
            {
                command.Parameters.AddWithValue("name", minionName);
                command.Parameters.AddWithValue("age", age);
                command.Parameters.AddWithValue("townId", townId);

                command.ExecuteNonQuery();
            }

        }

        private static void CheckVillain(string villainName, SqlConnection connection)
        {
            bool isVillainExists = false;
            string sqlVillainCommand = @"SELECT Name FROM Villains WHERE Name = @name";

            using (SqlCommand command = new SqlCommand(sqlVillainCommand, connection))
            {
                command.Parameters.AddWithValue("name", villainName);
                string result = (string)command.ExecuteScalar();
                if (result != null)
                {
                    isVillainExists = true;
                }
            }
            if (!isVillainExists)
            {
                string sqlAddVillainCommand = @"INSERT INTO Villains (Name, EvilnessFactorId) VALUES (@name, 4)";
                using (SqlCommand command = new SqlCommand(sqlAddVillainCommand, connection))
                {
                    command.Parameters.AddWithValue("name", villainName);
                    command.ExecuteNonQuery();
                }
                Console.WriteLine($"Villain {villainName} was added to the database.");
            }



        }

        private static void AddCityToTheDatabase(string city, SqlConnection connection)
        {
            string sqlInsertTownName = @"INSERT INTO Towns (Name) VALUES (@name)";
            using (SqlCommand command = new SqlCommand(sqlInsertTownName, connection))
            {
                command.Parameters.AddWithValue("name", city);
                command.ExecuteNonQuery();
            }
            Console.WriteLine($"Town {city} was added to the database.");
        }

        private static bool CheckCityExists(string city, SqlConnection connection)
        {
            string sqlTownCommand = @"SELECT Name FROM Towns WHERE Name = @name";
            string result = null;
            using (SqlCommand command = new SqlCommand(sqlTownCommand, connection))
            {
                command.Parameters.AddWithValue("name", city);
                result = (string)command.ExecuteScalar();
            }
            if (result == null)
            {
                return false;
            }
            return true;
        }
    }
}
