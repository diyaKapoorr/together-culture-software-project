using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace member_space
{
    public partial class paymentInfo : Form
    {

        public event EventHandler PaymentCompleted;
        public paymentInfo()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            // Populate the purpose ComboBox
            comboBox1.Items.Add("Book ");
            comboBox1.Items.Add("Event");
            comboBox1.Items.Add("Module");
            comboBox1.SelectedIndex = 0; // Default to "Book Event"
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Check if required fields are filled
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please enter your full name.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus(); // Set focus to the empty field
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Please enter your 16 digit card number.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Focus();
                return;
            }
            if (textBox3.Text.Length != 16 || !Is16DigitsOnly(textBox3.Text))
            {
                MessageBox.Show("Card number must be 16 digits.", "Invalid Card Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Focus();
                return;
            }
           

            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Please enter the expiration date.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox4.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Please enter the CVV.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox5.Focus();
                return;
            }



            


            // Retrieve payment details
            string cardholder_Name = textBox2.Text;
            string cardNumber = textBox3.Text;
            string expiration_Date = textBox4.Text;
            string CVV = textBox5.Text;
            string memberId = textBox10.Text; // Member ID from the new text box
            string Pay_for = comboBox1.Text; // Purpose from the combo box


            SavePaymentToDatabase(memberId, Pay_for);
            // Open confirmation form with payment details
            purchase confirmationForm = new purchase(cardholder_Name, cardNumber, expiration_Date, CVV);
            confirmationForm.PaymentConfirmed += ConfirmationForm_PaymentConfirmed; // Event handler for confirmation
            confirmationForm.Show();
        }
        private void SavePaymentToDatabase(string memberId, string Pay_for)
        {
            string connectionString = "Server=127.0.0.1;Database=together_culture;Uid=root;Pwd=;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Get the next Billing ID
                    string getNextBillingIdQuery = "SELECT IFNULL(MAX(PaymentID), 0) + 1 FROM billings";
                    int nextBillingId = 1;
                    using (MySqlCommand command = new MySqlCommand(getNextBillingIdQuery, connection))
                    {
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            nextBillingId = Convert.ToInt32(result);
                        }
                    }

                    // Insert the payment record with MemberID, Purpose, Current Date, and Default Payment Type
                    string insertQuery = "INSERT INTO billings (PaymentID, MemberID, Payment_Date, PaymentType,Pay_for) " +
                                         "VALUES (@PaymentID, @MemberID, @Payment_Date, @PaymentType,@Pay_for)";
                    using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@PaymentID", nextBillingId);
                        command.Parameters.AddWithValue("@MemberID", memberId);
                        command.Parameters.AddWithValue("@Pay_for", Pay_for);
                        command.Parameters.AddWithValue("@Payment_Date", DateTime.Now); // Current date and time
                        command.Parameters.AddWithValue("@PaymentType", "Online");    // Default payment type

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while saving the payment: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool Is16DigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }
        
        private void ConfirmationForm_PaymentConfirmed(object sender, EventArgs e)
        {
            // Raise the PaymentCompleted event to notify Form1
            PaymentCompleted?.Invoke(this, EventArgs.Empty);
            this.Close(); // Close Form after confirmation
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
