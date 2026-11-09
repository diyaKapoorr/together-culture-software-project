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
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void textBcpConfirmPass_TextChanged(object sender, EventArgs e)
        {
           

        }


        private void ChangePassword_Load_1(object sender, EventArgs e)
        {

        }

        private void textBcpNewPass_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void BcpBacktoLogin_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Close();
                
                
        }


      
        private void confirmButton_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBcpNewPass.Text) || string.IsNullOrEmpty(textBcpConfirmPass.Text))
            {
                MessageBox.Show("Please enter and confirm your new password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if the new password matches the confirm password
            if (textBcpNewPass.Text == textBcpConfirmPass.Text)
            {
                // Passwords match - you can proceed with changing the password here
                MessageBox.Show("Password successfully changed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Optionally, clear the fields after a successful password change
                textBcpNewPass.Text = "";
                textBcpConfirmPass.Text = "";
            }
            else
            {
                // Passwords do not match - notify the user
                MessageBox.Show("Passwords do not match. Please try again.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Optionally, clear the confirm password field to help user try again
                textBcpConfirmPass.Text = "";
                textBcpConfirmPass.Focus();
            }
        }
    }
}
