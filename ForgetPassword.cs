using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // Ensure you include MySQL library

namespace member_space
{
    public partial class ForgetPassword : Form
    {
        public ForgetPassword()
        {
            InitializeComponent();
        }

        public string connectionString = "Server=127.0.0.1;Database=together_culture;Uid=root;Pwd=;";




        private void ForgetPassword_Load(object sender, EventArgs e)
        {
            // Clear existing items
            comboBfpSequrityQues.Items.Clear();

            // Add new security questions
          
            comboBfpSequrityQues.Items.Add("Name of the first school you went to?");
            comboBfpSequrityQues.Items.Add("Name of the city you were born in?");
            comboBfpSequrityQues.Items.Add("Name of your first pet?");

            // Optional: Set a placeholder text
            comboBfpSequrityQues.SelectedIndex = -1; // Ensure no item is selected by default
        }
        private void BfpSubmit_Click(object sender, EventArgs e)
        {
            // Input validation
            if (string.IsNullOrEmpty(textBfpUsername.Text.Trim()))
            {
                MessageBox.Show("Please enter your username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBfpSequrityQues.SelectedItem == null || string.IsNullOrEmpty(comboBfpSequrityQues.Text.Trim()))
            {
                MessageBox.Show("Please select your security question.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(textBfpAnswer.Text.Trim()))
            {
                MessageBox.Show("Please provide an answer to your security question.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Database connection
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Query with TRIM and LOWER to ensure case and space-insensitive matching
                    string query = @"
                    SELECT COUNT(*) 
                    FROM logindetails 
                    WHERE Email = @Email 
                    AND TRIM(LOWER(Security_questions)) = TRIM(LOWER(@Question)) 
                    AND TRIM(LOWER(Security_questions_answers)) = TRIM(LOWER(@Answer));";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Add parameters
                        cmd.Parameters.AddWithValue("@Email", textBfpUsername.Text.Trim());
                        cmd.Parameters.AddWithValue("@Question", comboBfpSequrityQues.Text.Trim());
                        cmd.Parameters.AddWithValue("@Answer", textBfpAnswer.Text.Trim());

                        // Execute query
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count > 0)
                        {
                            // Success
                            MessageBox.Show("Security question and answer verified successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            new ChangePassword().Show();
                            this.Close();
                        }
                        else
                        {
                            // Failure
                            MessageBox.Show("Incorrect security question or answer. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBfpAnswer_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBfpUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBfpSequrityQues_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
