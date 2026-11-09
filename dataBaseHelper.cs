using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace member_space
{
    internal class dataBaseHelper
    {
        // Kept public for compatibility with the existing project.
        // The value now comes from DatabaseConnection instead of being hard-coded here.
        public string connectionString = DatabaseConnection.ConnectionString;

        // Method to fetch and display all rows from a specific table.
        public void QueryTable(string tableName)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine(
                        $"Connected to the database successfully! Fetching data from {tableName}");

                    string query = $"SELECT * FROM {tableName}";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.Write(
                                    $"{reader.GetName(i)}: {reader.GetValue(i)}  ");
                            }

                            Console.WriteLine();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Error fetching data from table {tableName}: {ex.Message}");
            }
        }

        // Method to fetch all table names from the database.
        public List<string> GetAllTableNames()
        {
            List<string> tableNames = new List<string>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Fetching all table names...");

                    const string query = "SHOW TABLES";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tableNames.Add(reader.GetString(0));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Error fetching table names: {ex.Message}");
            }

            return tableNames;
        }

        // Method to fetch all data from all tables.
        public void QueryAllTables()
        {
            try
            {
                List<string> tableNames = GetAllTableNames();

                foreach (string tableName in tableNames)
                {
                    Console.WriteLine(
                        $"\n--- Data from table: {tableName} ---");
                    QueryTable(tableName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Error querying all tables: {ex.Message}");
            }
        }

        // Inserts the new account into both logindetails and nonmember.
        // A transaction is used so both inserts succeed together or both are rolled back.
        public bool InsertLogindetailsAndNonmember(
            string firstName,
            string lastName,
            string email,
            string password,
            string securityQuestion,
            string securityAnswer,
            DateTime dob,
            out string errorMessage)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            const string queryLogindetails =
                                "INSERT INTO logindetails " +
                                "(Email, Password, Security_questions, Security_questions_answers) " +
                                "VALUES (@Email, @Password, @Security_questions, @Security_questions_answers)";

                            using (MySqlCommand command =
                                   new MySqlCommand(queryLogindetails, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@Email", email);
                                command.Parameters.AddWithValue("@Password", password);
                                command.Parameters.AddWithValue(
                                    "@Security_questions", securityQuestion);
                                command.Parameters.AddWithValue(
                                    "@Security_questions_answers", securityAnswer);

                                command.ExecuteNonQuery();
                            }

                            // Interests and Intentions are omitted intentionally.
                            // The GitHub-safe schema gives them default blank values.
                            const string queryNonmember =
                                "INSERT INTO nonmember " +
                                "(Email, FirstName, LastName, DOB) " +
                                "VALUES (@Email, @FirstName, @LastName, @DOB)";

                            using (MySqlCommand command =
                                   new MySqlCommand(queryNonmember, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@Email", email);
                                command.Parameters.AddWithValue("@FirstName", firstName);
                                command.Parameters.AddWithValue("@LastName", lastName);
                                command.Parameters.AddWithValue("@DOB", dob.Date);

                                command.ExecuteNonQuery();
                            }

                            transaction.Commit();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }

                errorMessage = null;
                return true;
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                errorMessage =
                    "An account with this email address already exists.";
                Console.WriteLine(
                    $"Error inserting data: {errorMessage}");
                return false;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                Console.WriteLine(
                    $"Error inserting data into logindetails and nonmember: {ex.Message}");
                return false;
            }
        }
    }
}
