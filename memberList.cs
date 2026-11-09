using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace member_space
{
    public partial class memberList : Form
    {
        public string connectionString = DatabaseConnection.ConnectionString;

        public memberList()
        {
            InitializeComponent();
            this.Load += new EventHandler(MemberList_Load); // Properly wire up the Load event
        }

        // Event handler for Form Load
        private void MemberList_Load(object sender, EventArgs e)
        {
            LoadMemberData(); // Call LoadMemberData method to populate the DataGridView
        }

        // Method to Load Member Data from the database
        private void LoadMemberData()
        {
            try
            {
                // Connect to the database and fill the DataGridView
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open(); // Open the connection

                    // Correct query using the exact column names from your member table
                    string query = "SELECT MemberID, Email, FirstName, LastName, DOB, RegistrationDate, Membership FROM member";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable memberTable = new DataTable();
                    adapter.Fill(memberTable);

                    if (memberTable.Rows.Count == 0)
                    {
                        MessageBox.Show("No data found in the member table.");
                    }

                    // Allow auto-generation of columns for simplicity
                    dataGridMember.AutoGenerateColumns = true;

                    // Bind the DataTable to the DataGridView
                    dataGridMember.DataSource = memberTable;

                    // Set AutoSizeMode for better visibility
                    dataGridMember.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading member data: " + ex.Message);
            }
        }

        // Empty event handler for DataGridView CellContentClick event
        private void dataGridViewMember_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Add any logic here if needed when a cell is clicked
        }
    }
}
