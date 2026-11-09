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
    public partial class Eventavtivity : Form
    {
        private string connectionString = "server=127.0.0.1;user=root;password=;database=together_culture;";
        public Eventavtivity()
        {
            InitializeComponent();
            LoadEvent();
        }

        private void Eventavtivity_Load(object sender, EventArgs e)
        {

        }
        private void LoadEvent()
        {
            // SQL Query to select all data from the event table
            string query = "SELECT * FROM EventActivity";

            try
            {
                // Establishing a connection
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Command to execute the query
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Fill a DataTable with the query result
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Bind the DataTable to the DataGridView
                        dataGridView1.DataSource = dataTable;

                        // Auto-resize the columns to fit the data
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                // Display any errors that occur during the process
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
