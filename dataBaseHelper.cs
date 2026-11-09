using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using MySql.Data.MySqlClient;

namespace member_space
{
    internal class dataBaseHelper
    {
        // Connection string to the database
        public string connectionString = "Server=127.0.0.1;Database=together_culture;Uid=root;Pwd=;";

        // Method to fetch and display all rows from a specific table
        public void QueryTable(string tableName)
        {
            try
            {  // Establish a connection to the database
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine($"Connected to the database successfully! Fetching data from {tableName}");
                    // Query to retrieve all data from the specified table
                    string query = $"SELECT * FROM {tableName}";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())// Iterate through all rows
                            {
                                for (int i = 0; i < reader.FieldCount; i++)// Iterate through all columns
                                {
                                    Console.Write($"{reader.GetName(i)}: {reader.GetValue(i)}  ");
                                }
                                Console.WriteLine();// New line after each row
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            { // Handle any errors and print the error message
                Console.WriteLine($"Error fetching data from table {tableName}: {ex.Message}");
            }
        }

        // Method to fetch all table names from the database
        public List<string> GetAllTableNames()// List to hold table names
        {
            List<string> tableNames = new List<string>();

            try
            {// Establish a connection to the database
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();// Open database connection
                    Console.WriteLine("Fetching all table names...");
                    // Query to retrieve all table names in the database
                    string query = "SHOW TABLES";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read()) // Iterate through the results
                            {
                                tableNames.Add(reader.GetString(0)); // First column contains table names
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {// Handle any errors and print the error message
                Console.WriteLine($"Error fetching table names: {ex.Message}");
            }

            return tableNames;
        }

        // Method to fetch all data from all tables
        public void QueryAllTables()
        {
            try
            {
                // Get all table names
                List<string> tableNames = GetAllTableNames();

                // Query data from each table
                foreach (string tableName in tableNames)
                {
                    Console.WriteLine($"\n--- Data from table: {tableName} ---");
                    QueryTable(tableName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error querying all tables: {ex.Message}");
            }
        }

        // Method to insert data into logindetails and nonmember tables
        public bool InsertLogindetailsAndNonmember(string firstName, string lastName, string email, string password, string securityQuestion, string securityAnswer, string DOB, out string errorMessage)

        {


            try
            { // Establish a connection to the database
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Connected to the database successfully! Inserting data into logindetails and nonmember...");

                    // Query to insert data into the logindetails table
                    string queryLogindetails = "INSERT INTO logindetails (Email, Password, Security_questions, Security_questions_answers) VALUES (@Email, @Password, @Security_questions, @Security_questions_answers)";
                    using (MySqlCommand command = new MySqlCommand(queryLogindetails, connection))
                    {
                        // Set LoginID 
                        // Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@Security_questions", securityQuestion);
                        command.Parameters.AddWithValue("@Security_questions_answers", securityAnswer);
                        command.ExecuteNonQuery();
                    }

                    // Format the DOB before adding it as a parameter
                    //string formattedDOB = DateTime.Parse(DOB).ToString("yyyy-MM-dd");


                    // Insert into nonmember table
                    string queryNonmember = "INSERT INTO nonmember (Email, FirstName, LastName, DOB) VALUES (@Email, @FirstName, @LastName, @DOB)";
                    using (MySqlCommand command = new MySqlCommand(queryNonmember, connection))
                    {// Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@DOB", DOB);
                     
                       command.ExecuteNonQuery();
                    }
                }

                errorMessage = null;// Set error message to null if successful
                return true;// Return true indicating success
            }
            catch (MySqlException ex) when (ex.Number == 1062) // Duplicate entry error
            {
                errorMessage = "A record with the same primary key already exists.";
                Console.WriteLine($"Error inserting data: {errorMessage}");
                return false;
            }
            catch (Exception ex)
            {// Handle any other errors and set error message
                errorMessage = ex.Message;
                Console.WriteLine($"Error inserting data into logindetails and nonmember: {ex.Message}");
                return false;
            }
        }
    }
}
