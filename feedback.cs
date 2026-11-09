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
    public partial class feedback : Form
    {
        private List<Feedback> feedbackList = new List<Feedback>();
        private DatabaseConnection dbConnection = new DatabaseConnection(); // Instantiate the DatabaseConnection class
        private dataBaseHelper dbHelper = new dataBaseHelper(); // Instantiate the dataBaseHelper class

        public feedback()
        {
            InitializeComponent();
            comboBoxFeedbackType.Items.Add("Bug Report");
            comboBoxFeedbackType.Items.Add("Suggestion");
            comboBoxFeedbackType.Items.Add("Other");

            comboBoxFeedbackType.SelectedIndex = 0;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxMessage.Text))
            {
                MessageBox.Show("Please enter a feedback message.");
                return;
            }

            // Create new feedback object
            Feedback newFeedback = new Feedback
            {
                Type = comboBoxFeedbackType.SelectedItem.ToString(),
                Message = textBoxMessage.Text
            };

            // Insert feedback into the database
            InsertFeedbackToDatabase(newFeedback);

            // Clear the message box
            textBoxMessage.Clear();

            // Optionally, show a confirmation message
            MessageBox.Show("Feedback Sent!");
        }

        private void InsertFeedbackToDatabase(Feedback feedback)
        {
            try
            {
                // Prepare SQL query to insert feedback into the 'feedback' table
                string query = "INSERT INTO feedback (Type, Message) VALUES (@Type, @Message)";

                // Use the connection from DatabaseConnection class
                using (MySqlConnection conn = dbConnection.get_Connection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Add parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@Type", feedback.Type);
                        cmd.Parameters.AddWithValue("@Message", feedback.Message);

                        cmd.ExecuteNonQuery(); // Execute the query
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while submitting feedback: " + ex.Message);
            }
        }

        private void Form14_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

    public class Feedback
    {
        public string Type { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return $"{Type}: {Message}";
        }
    }
}