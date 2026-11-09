using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;  // Use MySQL Client for .NET


namespace member_space
{

    public partial class SettingForm : Form

    {
        private string memberId;
        
        private string connectionString = "Server=localhost;Database=together_culture;User ID=root;Password=;SslMode=none;";

        public SettingForm(string memberId)
        {
            InitializeComponent();
            this.memberId = memberId;
            LoadMemberDetails();
        }
        private void LoadMemberDetails()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT FirstName, LastName, Email FROM member WHERE MemberID = @MemberID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MemberID", memberId);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    textBoxFirstname.Text = reader["FirstName"].ToString();
                    textBoxLastname.Text = reader["LastName"].ToString();
                    textBoxEmail.Text = reader["Email"].ToString();
                }
                conn.Close();
            }
        }



        private void textBoxLastname_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE member SET FirstName = @FirstName, LastName = @LastName, Email = @Email WHERE MemberID = @MemberID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FirstName", textBoxFirstname.Text);
                cmd.Parameters.AddWithValue("@LastName", textBoxLastname.Text);
                cmd.Parameters.AddWithValue("@Email", textBoxEmail.Text);
                cmd.Parameters.AddWithValue("@MemberID", memberId);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Details updated successfully!");
                }
                else
                {
                    MessageBox.Show("Error updating details.");
                }
                conn.Close();
            }
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {

        }

        private void textBoxFirstname_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
