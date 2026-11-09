using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace member_space
{
    
    public partial class memberDashboard : Form
    {
        private string memberId;
        private string memberType;
        private string memberName;
       
        private string smtpServer = "smtp.gmail.com"; // Gmail's SMTP server
        private int smtpPort = 587; // Port for TLS
        private string smtpEmail = "dheerajkodwani21@gmail.com"; // Sender's email
        private string smtpPassword = "dheeraj2122222"; // Sender's email password 
        private List<string> pinBoardPosts = new List<string>();
        //int memberId = 1029;
        public memberDashboard(string memberId, string memberType)
        {
            InitializeComponent();
            this.Load += Form1_Load;
            this.memberId = memberId;
            this.memberType = memberType;

            LoadMemberDetails();
            
            LoadMembershipBenefits();
            UpdatePinBoard();



        }
        //Testing the connection to DB
        public static void DbConnectionTest()

        {
            //Establishing connection to the MySql Server
            string connectionString = "Server=127.0.0.1;Database=together_culture;Uid=root;Pwd=;";
            //member_space.DatabaseConnection
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                MessageBox.Show("Connected to MySQL!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }


        // Event handler for Form Load
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        // Method to load data from the database
        private void LoadData()
        {

        }

        private void togethercultureTextbox_TextChanged(object sender, EventArgs e)
        {

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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

            shop form6 = new shop(textToDisplay,textToDisplay1,textToDisplay2,textToDisplay3,textToDisplay4);
            

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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            digitalContent form13 = new digitalContent();
            form13.Show();
        }

        private void Settings_Click(object sender, EventArgs e)
        {
             // Retrieve the member's ID from login or session
            SettingForm settingform = new SettingForm(memberId);
            settingform.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            feedback f14 = new feedback();
            f14.Show();
        }




        private void textBoxPost_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //int memberId = 1029;
            BillingHistory billinghistory = new BillingHistory(memberId);
            billinghistory.ShowDialog();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                // Fetch the logged-in user's email
                string userEmail = "dheerajkodwani21@gmail.com";

                // Fetch all event details
                string eventDetails = LoadEvent();

                // Send the email with event details
                SendEmail(userEmail, "Event Reminder", eventDetails);

                MessageBox.Show("Reminder email sent successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending email: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SendEmail(string toEmail, string subject, string body)
        {
            using (System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient(smtpServer, smtpPort))
            {
                smtpClient.Credentials = new System.Net.NetworkCredential(smtpEmail, smtpPassword);
                smtpClient.EnableSsl = true; // Use TLS for security

                // Set up the email message
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(smtpEmail); // Sender
                mailMessage.To.Add(toEmail); // Recipient
                mailMessage.Subject = subject; // Email Subject
                mailMessage.Body = body; // Email Body

                smtpClient.Send(mailMessage); // Send the email
            }
        }
        private void LoadMemberDetails()
        {
            string query = "SELECT CONCAT(FirstName, ' ', LastName) AS FullName FROM member WHERE MemberID = @MemberID";

            DatabaseConnection dbConnection = new DatabaseConnection();
            using (MySqlConnection conn = dbConnection.get_Connection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MemberID", memberId);
                    conn.Open();

                    object result = cmd.ExecuteScalar();
                    memberName = result != null ? result.ToString() : "Unknown Member";
                }
            }
        }
        private void LoadMembershipBenefits()
        {
            // Define the benefits for Standard and Premium members
            string benefits = string.Empty;

            if (memberType == "Standard")
            {
                benefits = "Standard Membership Benefits:\n" +
               "- Access to basic community events\n" +
               "- Monthly newsletter with updates\n" +
               "- Limited customer support (9 AM - 5 PM)\n" +
               "- Participation in free workshops\n" +
               "- Free access to digital resources\n" +
               "- Invites to volunteer activities\n" +
               "- Opportunity to join group forums\n" +
               "- Access to members-only discounts on select events\n" +
               "- Annual feedback sessions\n" +
               "- Recognition in our annual community report";
            }
            else if (memberType == "Premium")
            {
                benefits = "Premium Membership Benefits:\n" +
               "- Unlimited access to all community events\n" +
               "- Weekly updates and exclusive insights\n" +
               "- Priority 24/7 customer support\n" +
               "- Participation in premium workshops and webinars\n" +
               "- Access to exclusive digital resources\n" +
               "- Personalized mentoring sessions\n" +
               "- VIP invites to special events and galas\n" +
               "- Heavily discounted rates for paid events\n" +
               "- Early access to new programs and initiatives\n" +
               "- Exclusive recognition in premium member spotlights";
            }
            else
            {
                benefits = "Membership type not recognized.";
            }

            // Display the benefits in a textbox
            textBox1.Text = benefits;
        }
        private void UpdatePinBoard()
        {
            pinBoardPosts.Clear();
            richTextBoxPinBoard.Clear();

            string query = "SELECT MemberName, Content, Timestamp FROM PinboardMessages ORDER BY Timestamp DESC";

            DatabaseConnection dbConnection = new DatabaseConnection();
            using (MySqlConnection conn = dbConnection.get_Connection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string posterName = reader["MemberName"].ToString();
                            string content = reader["Content"].ToString();
                            DateTime timestamp = Convert.ToDateTime(reader["Timestamp"]);

                            string date = timestamp.ToString("dd/MM");
                            string time = timestamp.ToString("HH:mm");

                            string post = $"[{date} - {time}] {posterName}: {content}";
                            pinBoardPosts.Add(post);
                        }
                    }
                }
            }

            foreach (var post in pinBoardPosts)
            {
                richTextBoxPinBoard.AppendText(post + Environment.NewLine + Environment.NewLine);
            }
        }
        private string LoadEvent()
        {
            string eventDetails = "Upcoming Events:\n\n";
            string connectionString = "Server=127.0.0.1;Database=together_culture;Uid=root;Pwd=;";
            string query = "SELECT * FROM EventActivity";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            eventDetails += $"Event: {reader["Type"]}\n";
                            eventDetails += $"Description: {reader["Description"]}\n";
                            eventDetails += $"Date: {reader["EventDate"]}\n";
                            eventDetails += $"Location: {reader["BuildingName"]}, {reader["Address"]}\n";
                            eventDetails += $"Max Capacity: {reader["MaxCapacity"]}\n";
                            eventDetails += "-----------------------------------------\n";
                        }
                    }
                }
            }

            return eventDetails;
        }

        private void buttonPost_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxPost.Text))
            {
                MessageBox.Show("Please enter a message before posting.");
                return;
            }

            string dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string content = textBoxPost.Text.Trim();

            string query = "INSERT INTO PinboardMessages (MemberName, Content, Timestamp) VALUES (@MemberName, @Content, @Timestamp)";

            DatabaseConnection dbConnection = new DatabaseConnection();
            using (MySqlConnection conn = dbConnection.get_Connection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MemberName", memberName);
                    cmd.Parameters.AddWithValue("@Content", content);
                    cmd.Parameters.AddWithValue("@Timestamp", dateTime);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            textBoxPost.Clear();
            UpdatePinBoard();
        }
    

        private void listBoxPinBoard_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
