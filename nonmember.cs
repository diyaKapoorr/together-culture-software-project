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
    public partial class nonmember : Form
    {
        private string email;
       

        private string connectionString = "Server=localhost;Database=together_culture;User ID=root;Password=;SslMode=none;";
        public nonmember(string email)
        {
            InitializeComponent();
            this.email = email;
            LoadNonMemberDetails();
        }
        private void LoadNonMemberDetails()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT FirstName, LastName, Email FROM nonmember WHERE Email = @Email";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    textBox3.Text = reader["FirstName"].ToString();
                    textBox4.Text = reader["LastName"].ToString();
                    textBox5.Text = reader["Email"].ToString();
                }
                conn.Close();
            }
        }
            private void nonmember_Load(object sender, EventArgs e)
        {
            // Display or use the email as needed
            MessageBox.Show("Welcome Non-Member with Email: " + email, "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
            string connectionString = "Server=127.0.0.1;Database=together_culture;Uid=root;Pwd=;";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Firstname, Email FROM administrator";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable; // Binding data to DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void blogButton_Click(object sender, EventArgs e)
        {

            string textToDisplay = "Together Culture is growing a community of outrageously curious," +
                " open-minded and creative members who care for each other and want to build a more " +
                "inclusive and ecological Cambridge. Today, we’re introducing you to Lele, an illustrator " +
                "and designer. You can find out more about her work here. I’m an illustrator and designer, so " +
                "I work on books, magazines, advertising campaigns, games, and all sorts of products.\r\n\r\nI" +
                " dip in and out when I'm at Together Culture. There’s always someone that you can meet and I " +
                "really enjoy attending the workshops, Helping Each Other Forums, and if I can contribute something " +
                "it’s always interesting and exciting to be a part of.  \r\n\r\nTwo years ago I did an illustration " +
                "for a course I was on - it was part of an assignment to imagine a world in which creatives are happy."
                ;
            blog form4 = new blog(textToDisplay); form4.ShowDialog();
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            string textToDisplay = "We are gathering a membership community" +
                " united in their desire to help create a more equitable and ecological " +
                "creative economy. We provide facilities, creative leadership and entrepreneurial " +
                "skills development, momentum, structure, and resources for people to come together " +
                "and make change happen.From 15 - 20 August 2023, we installed a Cabinet of Curiosities at the Fitzwilliam Museum. Inside, visitors " +
                "could explore and discover portraits co-created through the summer, and watch the Together Culture Manifesto" +
                " film made in partnership with Anglia Ruskin University and director Pablo Tranchell.";


            about form3 = new about(textToDisplay);
            form3.ShowDialog();
        }

        private void whatsonButton_Click(object sender, EventArgs e)
        {
            string textToDisplay = "Abbey in Action was developed by Together Culture and Abbey People, " +
                "and we will be working in collaboration with CCVS. We'll be recruiting 10 leaders who" +
                " live in Abbey and have the ambition of making positive change in their community, aspire" +
                " to develop their own voices as local changemakers, and who will work as a team to develop " +
                "a programme to help more of their neighbours to do the same. The leaders will work across" +
                " the next six months to contribute their expertise in a series of workshops that culminates " +
                "in the delivery of an event that the cohort develops.";
            eventCalendar form5 = new eventCalendar(textToDisplay);
            form5.ShowDialog();
        }

        private void shopButton_Click(object sender, EventArgs e)
        {
            string textToDisplay = "1.The Future We Choose: 'Everyone should read this book' MATT HAIG - £17.99";
            string textToDisplay1 = "2.The Sum of Us: What Racism Costs Everyone and How We Can Prosper Together - £17.99";
            string textToDisplay2 = "3.The Mindful Kitchen: Vegetarian Cooking to Relate to Nature - £17.99";
            string textToDisplay3 = "4.#futuregen: Lessons from a Small Country - £17.99";
            string textToDisplay4 = "5.Invisible Work: The Hidden Ingredient of True Creativity, Purpose and Power - £17.99";

            shop form6 = new shop(textToDisplay, textToDisplay1, textToDisplay2, textToDisplay3, textToDisplay4);


            form6.ShowDialog();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            // Display a message box to confirm logout
            MessageBox.Show("You have been logged out of the system.", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FrontPage mainpage = new FrontPage();
            mainpage.Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            paymentInfo paymentForm = new paymentInfo();
            paymentForm.PaymentCompleted += label2_Click; // Event handler for payment completion
            paymentForm.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE nonmember SET FirstName = @FirstName, LastName = @LastName, Email = @Email WHERE Email = @Email";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FirstName", textBox3.Text);
                cmd.Parameters.AddWithValue("@LastName", textBox4.Text);
                cmd.Parameters.AddWithValue("@Email", textBox5.Text);
                //cmd.Parameters.AddWithValue("@Email", email);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Details updated successfully!");
                }
                else
                {
                    MessageBox.Show("Error updating details.");
                }
                conn.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ContactAdmin contactForm = new ContactAdmin();
            contactForm.ShowDialog();
        }
    }
}
