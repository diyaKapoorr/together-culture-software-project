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
    public partial class AdminDashboard : Form
    {
        private DatabaseConnection dbConnection = new DatabaseConnection(); // Instantiate the DatabaseConnection class
        private dataBaseHelper dbHelper = new dataBaseHelper(); // Instantiate the dataBaseHelper class
        private string email;

        public AdminDashboard(string email)
        {
            InitializeComponent();
            LoadFeedback();
            this.email= email;
        }
        private void LoadFeedback()
        {
            // Create a list to hold the feedback items
            List<Feedback> feedbackList = new List<Feedback>();

            // SQL query to fetch all feedback records from the database
            string query = "SELECT Type, Message FROM feedback";

            try
            {
                // Use the connection from DatabaseConnection class
                using (MySqlConnection conn = dbConnection.get_Connection())
                {
                    conn.Open(); // Open the connection
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Execute the query and retrieve the data
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Create a new Feedback object for each record
                                Feedback feedback = new Feedback
                                {
                                    Type = reader.GetString("Type"),
                                    Message = reader.GetString("Message")
                                };

                                // Add the feedback to the list
                                feedbackList.Add(feedback);
                            }
                        }
                    }
                }

                // Clear existing items in the ListBox before adding new feedback items
                listBoxFeedback.Items.Clear();

                // Add each feedback item to the ListBox
                foreach (var feedback in feedbackList)
                {
                    listBoxFeedback.Items.Add(feedback);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading feedback: " + ex.Message);
            }
        }

        public class Feedback
        {
            public string Type { get; set; }
            public string Message { get; set; }

            // Override ToString to format the output in the ListBox
            public override string ToString()
            {
                return $"{Type}: {Message}";
            }
        }



        private void button5_Click(object sender, EventArgs e)
        {
            // Display a message box to confirm logout
            MessageBox.Show("You have been logged out of the system.", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FrontPage mainpage = new FrontPage();
            mainpage.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new MemberInsightDashboard().Show();
            this.Hide();

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Eventavtivity eventavtivity = new Eventavtivity();  
            eventavtivity.ShowDialog();
        }

        private void buttonStafflist_Click(object sender, EventArgs e)
        {
            new staffList().Show();
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void updateCredButton_Click(object sender, EventArgs e)
        {
            new updateAdminCred().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {

            string textToDisplay = "1.The Future We Choose: 'Everyone should read this book' MATT HAIG - £17.99";
            string textToDisplay1 = "2.The Sum of Us: What Racism Costs Everyone and How We Can Prosper Together - £17.99";
            string textToDisplay2 = "3.The Mindful Kitchen: Vegetarian Cooking to Relate to Nature - £17.99";
            string textToDisplay3 = "4.#futuregen: Lessons from a Small Country - £17.99";
            string textToDisplay4 = "5.Invisible Work: The Hidden Ingredient of True Creativity, Purpose and Power - £17.99";

            shop form6 = new shop(textToDisplay, textToDisplay1, textToDisplay2, textToDisplay3, textToDisplay4);


            form6.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
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

        private void button9_Click(object sender, EventArgs e)
        {
            AdminPinboardForm f24 = new AdminPinboardForm();
            f24.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            EventSearch eventSearch = new EventSearch();
            eventSearch.Show();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {

        }
    }

}
