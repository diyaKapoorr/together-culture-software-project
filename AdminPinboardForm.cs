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
    public partial class AdminPinboardForm : Form
    {
        public AdminPinboardForm()
        {
            InitializeComponent();
            LoadPosts();
        }

        private void LoadPosts()
        {
            string query = "SELECT ID, MemberName, Content, Timestamp FROM PinboardMessages ORDER BY Timestamp DESC";

            DatabaseConnection dbConnection = new DatabaseConnection();
            using (MySqlConnection conn = dbConnection.get_Connection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    DataTable table = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(table);

                    dataGridViewPosts.DataSource = table;

                    // Set up DataGridView appearance (optional)
                    dataGridViewPosts.Columns["ID"].Visible = false; // Hide ID column
                    dataGridViewPosts.Columns["MemberName"].HeaderText = "Posted By";
                    dataGridViewPosts.Columns["Content"].HeaderText = "Message";
                    dataGridViewPosts.Columns["Timestamp"].HeaderText = "Date & Time";
                    dataGridViewPosts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewPosts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a post to delete.");
                return;
            }

            // Get the selected post's ID
            int selectedPostId = Convert.ToInt32(dataGridViewPosts.SelectedRows[0].Cells["ID"].Value);

            string query = "DELETE FROM PinboardMessages WHERE ID = @ID";

            DatabaseConnection dbConnection = new DatabaseConnection();
            using (MySqlConnection conn = dbConnection.get_Connection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", selectedPostId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Post deleted successfully!");
            LoadPosts(); // Refresh the list of posts
        }
    }

}
