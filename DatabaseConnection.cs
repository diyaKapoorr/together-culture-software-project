using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace member_space
{
    // A class to call for the database connection instead of adding it everytime its needed
    public class DatabaseConnection
    {
        //
        private string connection_String;
        public DatabaseConnection() 
        {
            connection_String = "Server=127.0.0.1;Database=together_culture;Uid=root;Pwd=;";
        }
        public MySqlConnection get_Connection()
        { 
            return new MySqlConnection(connection_String); 
        }
     }
}
