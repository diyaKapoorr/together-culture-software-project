using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace member_space
{
    public partial class purchase : Form
    {
        public event EventHandler PaymentConfirmed;
        public purchase(string cardholder_Name, string cardNumber, string expiration_Date, string CVV)
        {
            InitializeComponent();
            // Display payment details in labels
            label1.Text = "Cardholder Name: " + cardholder_Name;
            label2.Text = "Card Number: " + cardNumber;
            label3.Text = "Expiration Date: " + expiration_Date;
            label4.Text = "CVV: " + CVV;
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Show confirmation message
            MessageBox.Show("Payment has been processed successfully!", "Payment Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Raise the PaymentConfirmed event to notify Form2
            PaymentConfirmed?.Invoke(this, EventArgs.Empty);

            this.Close(); // Close the confirmation form
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
