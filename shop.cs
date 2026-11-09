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
    public partial class shop : Form
    {
        public shop(string textToDisplay, string textToDisplay1, string textToDisplay2, string textToDisplay3, string textToDisplay4)
        {
            InitializeComponent();
            textBox1.Text = textToDisplay;
            textBox2.Text = textToDisplay1;
            textBox3.Text = textToDisplay2;
            textBox4.Text = textToDisplay3;
            textBox5.Text = textToDisplay4;

            
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Open the payment details form
            paymentInfo paymentForm = new paymentInfo();
            paymentForm.PaymentCompleted += label1_Click; // Event handler for payment completion
            paymentForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {// Open the payment details form
            paymentInfo paymentForm = new paymentInfo();
            paymentForm.PaymentCompleted += label1_Click; // Event handler for payment completion
            paymentForm.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Open the payment details form
            paymentInfo paymentForm = new paymentInfo();
            paymentForm.PaymentCompleted += label1_Click; // Event handler for payment completion
            paymentForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Open the payment details form
            paymentInfo paymentForm = new paymentInfo();
            paymentForm.PaymentCompleted += label1_Click; // Event handler for payment completion
            paymentForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Open the payment details form
            paymentInfo paymentForm = new paymentInfo();
            paymentForm.PaymentCompleted += label1_Click; // Event handler for payment completion
            paymentForm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Display a thank-you message after payment is confirmed
            label1.Text = "Thank you for your purchase!. Purchase was complete";
            label1.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
