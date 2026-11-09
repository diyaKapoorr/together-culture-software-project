using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace member_space
{
    public partial class Login : Form
    {
        public string connectionString = DatabaseConnection.ConnectionString;

        public Login()
        {
            InitializeComponent();
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            string email = txtbLogUsername.Text.Trim();
            string password = txtbLogPassword.Text;

            if (string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(
                    "Email and Password fields cannot be empty.",
                    "Login Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            try
            {
                const string loginQuery =
                    "SELECT Email FROM logindetails " +
                    "WHERE Email = @Email AND Password = @Password";

                using (MySqlConnection connection =
                       new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command =
                           new MySqlCommand(loginQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Password", password);

                        object loginResult = command.ExecuteScalar();

                        if (loginResult == null)
                        {
                            MessageBox.Show(
                                "Invalid Email or Password. Please try again.",
                                "Login Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                            txtbLogPassword.Clear();
                            txtbLogUsername.Focus();
                            return;
                        }
                    }

                    const string memberQuery =
                        "SELECT MemberID, Membership FROM member WHERE Email = @Email";

                    using (MySqlCommand memberCmd =
                           new MySqlCommand(memberQuery, connection))
                    {
                        memberCmd.Parameters.AddWithValue("@Email", email);

                        using (MySqlDataReader memberReader =
                               memberCmd.ExecuteReader())
                        {
                            if (memberReader.Read())
                            {
                                string memberType =
                                    memberReader["Membership"].ToString();
                                string memberId =
                                    memberReader["MemberID"].ToString();

                                memberReader.Close();

                                MessageBox.Show(
                                    "Login Successful! Welcome, Member.",
                                    "Success",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                                memberDashboard memberPage =
                                    new memberDashboard(memberId, memberType);

                                memberPage.Show();
                                Hide();
                                return;
                            }
                        }
                    }

                    const string nonMemberQuery =
                        "SELECT Email FROM nonmember WHERE Email = @Email";

                    using (MySqlCommand nonMemberCmd =
                           new MySqlCommand(nonMemberQuery, connection))
                    {
                        nonMemberCmd.Parameters.AddWithValue("@Email", email);

                        object nonMemberResult = nonMemberCmd.ExecuteScalar();

                        if (nonMemberResult != null)
                        {
                            MessageBox.Show(
                                "Login Successful! Welcome, Non-Member.",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            nonmember nonMemberPage = new nonmember(email);
                            nonMemberPage.Show();
                            Hide();
                            return;
                        }
                    }

                    const string adminQuery =
                        "SELECT Email FROM administrator WHERE Email = @Email";

                    using (MySqlCommand adminCmd =
                           new MySqlCommand(adminQuery, connection))
                    {
                        adminCmd.Parameters.AddWithValue("@Email", email);

                        object adminResult = adminCmd.ExecuteScalar();

                        if (adminResult != null)
                        {
                            MessageBox.Show(
                                "Login Successful! Welcome, Admin.",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            AdminDashboard adminPage =
                                new AdminDashboard(email);

                            adminPage.Show();
                            Hide();
                            return;
                        }
                    }

                    MessageBox.Show(
                        "The account was authenticated but no matching role was found.",
                        "Login Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An error occurred: " + ex.Message,
                    "Login Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CHbxLogShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtbLogPassword.PasswordChar =
                CHbxLogShowPass.Checked ? '\0' : '*';
        }

        private void LcreateAccount_Click(object sender, EventArgs e)
        {
            new signUp().Show();
            Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }

        private void txtbLogUsername_TextChanged(object sender, EventArgs e)
        {
        }

        private void ButtonForgetPass_Click(object sender, EventArgs e)
        {
            new ForgetPassword().Show();
        }
    }
}
