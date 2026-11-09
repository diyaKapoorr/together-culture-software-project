using System;
using System.Windows.Forms;

namespace member_space
{
    public partial class signUp : Form
    {
        public signUp()
        {
            InitializeComponent();
        }

        private void signUp_Load(object sender, EventArgs e)
        {
            // Security questions can also be configured in the WinForms Designer.
        }

        // Register button.
        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            string email = txtbUsername.Text.Trim();
            string firstName = textBxFirstName.Text.Trim();
            string lastName = textBxLastname.Text.Trim();
            string securityAnswer = textbSecurityQuesAns.Text.Trim();

            if (string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(txtbPassword.Text) ||
                string.IsNullOrWhiteSpace(txtbConfirmpass.Text) ||
                string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName) ||
                combobxSecurityQues.SelectedItem == null ||
                string.IsNullOrWhiteSpace(securityAnswer))
            {
                MessageBox.Show(
                    "All fields are required.",
                    "Registration Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (txtbPassword.Text != txtbConfirmpass.Text)
            {
                MessageBox.Show(
                    "Passwords do not match. Please re-enter.",
                    "Registration Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                txtbPassword.Text = "";
                txtbConfirmpass.Text = "";
                txtbPassword.Focus();
                return;
            }

            if (dateTimePicker2.Value.Date > DateTime.Today)
            {
                MessageBox.Show(
                    "Date of birth cannot be in the future.",
                    "Registration Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            try
            {
                dataBaseHelper dbHelper = new dataBaseHelper();
                string errorMessage;

                bool isInserted = dbHelper.InsertLogindetailsAndNonmember(
                    firstName,
                    lastName,
                    email,
                    txtbPassword.Text,
                    combobxSecurityQues.SelectedItem.ToString(),
                    securityAnswer,
                    dateTimePicker2.Value.Date,
                    out errorMessage);

                if (isInserted)
                {
                    txtbUsername.Clear();
                    txtbPassword.Clear();
                    txtbConfirmpass.Clear();
                    textBxFirstName.Clear();
                    textBxLastname.Clear();
                    combobxSecurityQues.SelectedItem = null;
                    textbSecurityQuesAns.Clear();
                    dateTimePicker2.Value = DateTime.Today;

                    MessageBox.Show(
                        "Your account has been successfully created.",
                        "Registration Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    new Login().Show();
                    Close();
                }
                else
                {
                    MessageBox.Show(
                        "An error occurred: " + errorMessage,
                        "Registration Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An unexpected error occurred: " + ex.Message,
                    "Registration Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CHbxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            char passwordCharacter = CHbxShowPass.Checked ? '\0' : '*';

            txtbPassword.PasswordChar = passwordCharacter;
            txtbConfirmpass.PasswordChar = passwordCharacter;
        }

        private void LbacktoLogin_Click(object sender, EventArgs e)
        {
            new Login().Show();
            Close();
        }

        // Existing Designer event handlers.
        private void txtbPassword_TextChanged(object sender, EventArgs e) { }
        private void textbSecurityQuesAns_TextChanged(object sender, EventArgs e) { }
        private void combobxSecurityQues_SelectedIndexChanged(object sender, EventArgs e) { }
        private void LAnswer_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void txtbConfirmpass_TextChanged(object sender, EventArgs e) { }
        private void textBxFirstName_TextChanged(object sender, EventArgs e) { }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) { }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e) { }
        private void LalreadyHaveAccount_Click(object sender, EventArgs e) { }
    }
}
