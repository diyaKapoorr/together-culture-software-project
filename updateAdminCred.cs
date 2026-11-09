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
using ServiceStack.Script;

namespace member_space
{
    public partial class updateAdminCred : Form
    {
        private string connectionString = "Server=localhost;Database=together_culture;User ID=root;Password=;SslMode=none;";

        // Constructor to initialize the form
        public updateAdminCred()
        {
            InitializeComponent();
        }

        // Update the admin password only
        private void updateButton_Click(object sender, EventArgs e)
        {
            // Check if Email or Password field is empty
            if (string.IsNullOrEmpty(textBoxEmail.Text) || string.IsNullOrEmpty(textBoxPass.Text) || string.IsNullOrEmpty(textBoxAConfPass.Text))
            {
                MessageBox.Show("All fields are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Verify if the entered password matches the confirmation password
            else if (textBoxPass.Text == textBoxAConfPass.Text)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                try
                {
                    conn.Open();// Open database connection
                                // Query to check if the new password already exists for the specified email
                        string checkQuery = "SELECT COUNT(*) FROM logindetails WHERE Password = @Password AND Email = @Email";
                        using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                        {
                            // Add parameters to prevent SQL injection
                            checkCmd.Parameters.AddWithValue("@Password", textBoxPass.Text);
                          checkCmd.Parameters.AddWithValue("@Email", textBoxEmail.Text);

                            // Execute query and check the count
                            int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                         if (count > 0)
                         {
                                // If the password already exists, display an error message
                                MessageBox.Show("The password already exists for the specified email. Please choose a different password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                // Clear and reset the password fields
                                textBoxPass.Text = "";
                            textBoxAConfPass.Text = "";
                            textBoxPass.Focus(); 

                          return;
                         }
                         
                        }

                        // Query to update the password for the specified email
                        string query = "UPDATE logindetails SET Password = @Password WHERE Email = @Email";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Password", textBoxPass.Text);
                    cmd.Parameters.AddWithValue("@Email", textBoxEmail.Text);

                        // Execute the update query
                        int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {

                        // Display success message and open the Admin Dashboard form
                        MessageBox.Show("Password updated successfully!");
                        AdminDashboard adminDashboard = new AdminDashboard(textBoxEmail.Text);
                        adminDashboard.Show();
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Error: No user found with the specified email.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while updating the password: " + ex.Message);
                }
                finally
                {
                  
                    conn.Close();
                }

            }
            else
            {
                // If passwords do not match, display an error message and reset fields
                MessageBox.Show("Passwords do not match. Please re-enter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPass.Text = "";
                textBoxAConfPass.Text = "";
                textBoxPass.Focus();// Focus on the password field for re-entry

            }
        }



        // Event handler for email text change (currently unused)
        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            // Any additional functionality on email change (if required)
        }

       

        private void updateAdminCred_Load(object sender, EventArgs e)
        {
            // Display the FrontPage form and hide the current form
            new FrontPage().Show();
            this.Hide();

        }

        private void chbxAShowPass_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (chbxAShowPass.Checked)
                {
                    // Display the password in plain text
                    textBoxPass.PasswordChar = '\0';
                    textBoxAConfPass.PasswordChar = '\0';
                }
                else
                {
                    // Mask the password characters
                    textBoxPass.PasswordChar = '*';
                    textBoxAConfPass.PasswordChar = '*';

                }


            }
        }

        private void labelEmail_Click(object sender, EventArgs e)
        {

        }
    }
}
