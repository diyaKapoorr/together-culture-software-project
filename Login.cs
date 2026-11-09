using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;



namespace member_space
{
   

    public partial class Login : Form
    {
        public string connectionString = "Server=127.0.0.1;Database=together_culture;Uid=root;Pwd=;";
        public Login()
        {
            InitializeComponent();

        }

      

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            string email = txtbLogUsername.Text.Trim();

            if (string.IsNullOrEmpty(txtbLogUsername.Text) || string.IsNullOrEmpty(txtbLogPassword.Text))
            {
                MessageBox.Show("Username and Password fields cannot be empty", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Initialize the database helper
                dataBaseHelper dbHelper = new dataBaseHelper();
                dbHelper.QueryTable("logindetails");

                // SQL Query to check the username and password
                string query = "SELECT Email FROM logindetails WHERE Email = @Email AND Password = @Password";

                using (MySqlConnection connection = new MySqlConnection(dbHelper.connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@Email", txtbLogUsername.Text);
                        command.Parameters.AddWithValue("@Password", txtbLogPassword.Text);

                        // Execute the reader
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // If a match is found, close the reader before proceeding
                                reader.Close();

                                // Check if the email exists in the `member` table
                                string memberQuery = "SELECT MemberID,Membership FROM member WHERE Email = @Email";

                                using (MySqlCommand memberCmd = new MySqlCommand(memberQuery, connection))
                                {
                                    memberCmd.Parameters.AddWithValue("@Email", email);
                                    using (MySqlDataReader memberReader = memberCmd.ExecuteReader())
                                    {
                                        if (memberReader.Read())
                                        {

                                            MessageBox.Show("Login Successful! Welcome, Member.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            // If the email exists in the `member` table, open the Member page
                                            string memberType = memberReader["Membership"].ToString();
                                            string memberId = memberReader["MemberID"].ToString();
                                            memberDashboard memberPage = new memberDashboard(memberId,memberType); // Pass email and membership type
                                            memberPage.Show();
                                            this.Hide();
                                            return; // Exit the method
                                        }
                                    }
                                }

                                // If not in the `member` table, check if it exists in the `non_member` table
                                string nonMemberQuery = "SELECT Email FROM nonmember WHERE Email = @Email";

                                using (MySqlCommand nonMemberCmd = new MySqlCommand(nonMemberQuery, connection))
                                {
                                    nonMemberCmd.Parameters.AddWithValue("@Email", email);
                                    using (MySqlDataReader nonMemberReader = nonMemberCmd.ExecuteReader())
                                    {
                                        if (nonMemberReader.Read())
                                        {

                                            MessageBox.Show("Login Successful! Welcome, Non-Member.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            // If the email exists in the `non_member` table, open the Non-Member page
                                            nonmember nonMemberPage = new nonmember(email); // Pass Email to the page
                                            nonMemberPage.Show();
                                            this.Hide();
                                            return; // Exit the method
                                        }
                                    }
                                }
                                // If not in the `nonmember` table, check if it exists in the `non_member` table
                                string adminQuery = "SELECT Email FROM administrator WHERE Email = @Email";

                                using (MySqlCommand adminCmd = new MySqlCommand(adminQuery, connection))
                                {
                                    adminCmd.Parameters.AddWithValue("@Email", email);
                                    using (MySqlDataReader adminReader = adminCmd.ExecuteReader())
                                    {
                                        if (adminReader.Read())
                                        {

                                            MessageBox.Show("Login Successful! Welcome, Admin.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            // If the email exists in the `non_member` table, open the Non-Member page
                                            AdminDashboard adminPage = new AdminDashboard(email); // Pass Email to the page
                                            adminPage.Show();
                                            this.Hide();
                                            return; // Exit the method
                                        }
                                    }
                                }
                                // If the email is not found in either table, show an error
                                MessageBox.Show("Your account could not be found as either a Member or Non-Member.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                            else
                            {
                                // If no match is found, show an error message
                                MessageBox.Show("Invalid Username or Password. Please Try Again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                // Clear the input fields
                                txtbLogUsername.Text = "";
                                txtbLogPassword.Text = "";
                                txtbLogUsername.Focus();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }




        private void CHbxLogShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (CHbxLogShowPass.Checked)
            {
                txtbLogPassword.PasswordChar = '\0';
                
            }
            else
            {
                txtbLogPassword.PasswordChar = '*';
               

            }
        }

        private void LcreateAccount_Click(object sender, EventArgs e)
        {
            new signUp().Show();
            this.Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void txtbLogUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void ButtonForgetPass_Click(object sender, EventArgs e)
        {
          new  ForgetPassword().Show();
        }
    }
}
