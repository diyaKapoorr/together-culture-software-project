using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace member_space
{
    public partial class about : Form
    {
        public about(string text)
        {
            InitializeComponent();
            // Set the text in the RichTextBox
            richTextBox1.Text = text;

        }
            private void richTextBox_TextChanged(object sender, EventArgs e)
            {
                
            }
        

            
    

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
