using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace member_space
{
    public partial class UserInsightsDashboard : Form

    {

        private dashBoard_Data user_Data;
        public UserInsightsDashboard()
        {
            InitializeComponent();
            user_Data = new dashBoard_Data();

        }

        private void FillingData() 
        {
            int total_users = user_Data.Get_Totals();
            label3.Text = total_users.ToString();
        }
        
        private void UserInsightsDashboard_Load(object sender, EventArgs e)
        {
            FillingData();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }
    }
}
