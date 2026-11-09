using System;
using MySql.Data.MySqlClient;

namespace member_space
{
    // Central database connection configuration.
    // Real database credentials are read from environment variables so that
    // passwords do not need to be committed to GitHub.
    public class DatabaseConnection
    {
        public static string ConnectionString
        {
            get
            {
                string user = Environment.GetEnvironmentVariable("TC_DB_USER");
                string password = Environment.GetEnvironmentVariable("TC_DB_PASSWORD");

                if (string.IsNullOrWhiteSpace(user))
                {
                    user = "root";
                }

                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
                {
                    Server = "127.0.0.1",
                    Database = "together_culture",
                    UserID = user,
                    Password = password ?? ""
                };

                return builder.ConnectionString;
            }
        }

        public MySqlConnection get_Connection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
