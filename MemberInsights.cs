using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using member_space;

namespace member_space
{
    public partial class MemberInsightDashboard : Form
    {
        private dashBoard_Data member_Data;
        public MemberInsightDashboard()
        {
            InitializeComponent();
            member_Data = new dashBoard_Data();
        }
        private void Show_Members() 
        {
            int total_members = member_Data.Get_Totals();
            label3.Text = total_members.ToString();

        }
        public static string total_MembersQ = "SELECT count(MemberID) FROM `member` WHERE RegistrationDate BETWEEN @fromDate AND @toDate";
        public void Update_Dashboard(DateTime startDate, DateTime endDate)
        {
            member_Data.Update_Data(label3,total_MembersQ,startDate,endDate);
            
        }
        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void MemberInsightDashboard_Load(object sender, EventArgs e)
        {
            Show_Members();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            MemberSearch memberSearch = new MemberSearch();
            memberSearch.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            DateTime today = DateTime.Today;
            Update_Dashboard(today,today.AddTicks(-1));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            DateTime start_Of_last_Week = today.AddDays(-(int)today.DayOfWeek - 7);
            DateTime end_Of_Last_Week = start_Of_last_Week.AddDays(7).AddTicks(-1);

            Update_Dashboard(start_Of_last_Week, end_Of_Last_Week);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void buttonMemberList_Click(object sender, EventArgs e)
        {
            new memberList().Show();
        }
    }
}
