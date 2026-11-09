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
    public partial class eventCalendar : Form
    {
        public eventCalendar(string text)
        {
            InitializeComponent();
            richTextBox1.Text = text; 

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            InteractiveCalendar cal = new InteractiveCalendar();
       
            cal.Show();
            this.Close();
            
        }
    }
}
