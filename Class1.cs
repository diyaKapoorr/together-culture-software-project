using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ServiceStack;
using System.Windows.Forms;

namespace member_space
{
    class dashBoard_Data : DatabaseConnection
    {
        private DateTime start_Date;
        private DateTime end_Date;
        private int number_Days; 
        public int total_Members { get; set; }
        public int total_Users { get; set; }

        // dashboard data displayed
        public int Get_Totals() 
        {
            using (var connection = get_Connection()) 
            {
                connection.Open();
                using (var command = new MySqlCommand()) 
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT count(MemberID) FROM `member`";
                    total_Members = Convert.ToInt32(command.ExecuteScalar());
                   
                    command.CommandText = "SELECT count(email) FROM `nonmember`";
                    total_Users = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            return total_Members;
         
        }
        // Queiries to be called into the methods below to display specific data
        public static string total_MembersQ = "SELECT count(MemberID) FROM `member` WHERE RegistrationDate BETWEEN @fromDate AND @toDate";
        public int Get_Data_In_Range(string query,DateTime startDate, DateTime endDate) 
        {
            int output ;
            using (var connection = get_Connection())
            {
                connection.Open();
                using (var command = new MySqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@fromDate",startDate);
                    command.Parameters.AddWithValue("@toDate",endDate);
                    output = Convert.ToInt32(command.ExecuteScalar());

                }
            }
            return output;
        }
       
        public void Update_Data(System.Windows.Forms.Label label, string query, DateTime start_date, DateTime end_date) 
        {
            int data = Get_Data_In_Range(query, start_date, end_date);
            label.Text = data.ToString();
        }
}
}

