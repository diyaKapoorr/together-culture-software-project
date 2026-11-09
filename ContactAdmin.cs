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
    public partial class ContactAdmin : Form
    {
        public ContactAdmin()
        {
            InitializeComponent();
            LoadAdmin();
        }

        private void ContactAdmin_Load(object sender, EventArgs e)
        {

        }
        private void LoadAdmin()
        {
            string connectionString = "Server=localhost;Database=together_culture;Uid=root;Pwd=;";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Email FROM administrator"; // Adjust the table/column name
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    comboBox1.DataSource = dt;
                    comboBox1.DisplayMember = "Email"; // Set the display member
                    comboBox1.ValueMember = "Email";   // Optional, set value member
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading admins: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an admin.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please type a message.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Show confirmation
            string selectedAdmin = comboBox1.SelectedItem.ToString();
            string userMessage = textBox1.Text.Trim();

            MessageBox.Show($"Message sent to {selectedAdmin}:\n\n{userMessage}", "Message Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Clear the message box after sending
            textBox1.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
