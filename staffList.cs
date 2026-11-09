using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace member_space
{
    public partial class staffList : Form
    {
        public string connectionString = "Server=127.0.0.1;Database=together_culture;Uid=root;Pwd=;";

        public staffList()
        {
            InitializeComponent();
            this.Load += new EventHandler(StaffList_Load); // Properly wire up the Load event
        }

        // Event handler for Form Load
        private void StaffList_Load(object sender, EventArgs e)
        {
            LoadStaffData(); // Call LoadStaffData method to populate the DataGridView
        }

        // Method to Load Staff Data from the database
        private void LoadStaffData()
        {
            try
            {
                // Connect to the database and fill the DataGridView
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open(); // Open the connection

                    string query = "SELECT StaffID, FirstName, LastName, JoiningDate, Department, Email FROM staff";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable staffTable = new DataTable();
                    adapter.Fill(staffTable);

                    if (staffTable.Rows.Count == 0)
                    {
                        MessageBox.Show("No data found in the staff table.");
                    }

                   

                    // Bind the DataTable to the DataGridView
                    dataGridViewStaff.DataSource = staffTable;

                    // Set AutoSizeMode for better visibility
                    dataGridViewStaff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading staff data: " + ex.Message);
            }
        }
    }
}
