using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;

namespace member_space
{
    public class SearchMembers : DatabaseConnection
    {
        public DataTable DataBaseSearch(string member_ID) 
        {
            DataTable search_Result = new DataTable();
            string query;
            
            query = "SELECT * FROM `member` WHERE `MemberID` = @member_ID";
            using (var connection = get_Connection())
            {
                connection.Open();
                using (var command = new MySqlCommand(query, connection)) 
                {
                    
                        command.Parameters.AddWithValue("@member_ID", member_ID);
                    
                    using (var adapter = new MySqlDataAdapter(command)) 
                    {
                        adapter.Fill(search_Result);
                    }
                }
            }
            return search_Result;
        }
        
        
        
        
    }
}
