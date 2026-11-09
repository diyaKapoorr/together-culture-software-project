using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace member_space
{
    public partial class InteractiveCalendar : Form
    {
        string connectionString = "Server=127.0.0.1;Database=together_culture;Uid=root;Pwd=;";

        public void ConnectionCheck() 
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    MessageBox.Show("connected successfully");
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public InteractiveCalendar()
        {
            
            ConnectionCheck();
            InitializeComponent();
            calendar_creator(DateTime.Now.Year, DateTime.Now.Month);
        }
        private void calendar_creator(int year, int month)
        {
            //This will clear the previous controls
            Calendar.Controls.Clear();

            //This will get the first day of the month so we can create the ordering of the panels off of it
            DateTime month_Start = new DateTime(year, month, 1);

            //This will calculate the days in the current month to get number of panels needed
            int days_Month = DateTime.DaysInMonth(year, month);

            //This gets the day of the week of the first date -1 so the week starts on sunday
            int first_Day = (int)month_Start.DayOfWeek - 1;
            //This is the panel size from testing
            int panel_Width = 156;
            int panel_Height = 100;
           
            //This will loop through the days in the month creating a button for each day
            for (int i = 1; i <= days_Month; i++) {
                //Calc the rows needed
                int col = (first_Day + i - 1) % 7;
                int row = (first_Day + i - 1) / 7;
                
                //Create the new button each iteration
                Button day_Button = new Button
                {
                    Size = new Size(panel_Width - 5, panel_Height - 5),
                    Location = new Point(col * panel_Width, row * panel_Height),
                    Text = i.ToString() +"th",
                    TextAlign = ContentAlignment.TopLeft,
                    //BorderStyle = BorderStyle.FixedSingle,
                    
                    BackColor = Color.IndianRed,
                    Tag = new DateTime(year, month, i)
                };
                DateTime currentDate = new DateTime(year, month, i);
                
                day_Button.Click += day_Button_Click;
                //This will generate the dates for each label
                for (int j = 1; j <= days_Month; j++) 
                {
                    
                }
            
            Calendar.Controls.Add(day_Button);
            
            }

        }
        private void day_Button_Click(object sender, EventArgs e) 
        {
            Button clicked = sender as Button; 
            if (clicked != null) 
            {  
                DateTime selected = (DateTime)clicked.Tag;

                EventBooking booking = new EventBooking(selected);
                booking.ShowDialog();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void InteractiveCalendar_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Calendar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }
    }
}
