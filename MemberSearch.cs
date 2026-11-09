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
    public partial class MemberSearch : Form
    {
        private SearchMembers search_Members;
        public MemberSearch()
        {
            InitializeComponent();
            search_Members = new SearchMembers();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBox1.Text.Trim();
            if (!string.IsNullOrEmpty(searchText))
            {
                DataTable results = search_Members.DataBaseSearch(searchText);
                dataGridView1.DataSource = results;

            }
            else 
            {
                dataGridView1.DataSource = null;
                
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void MemberSearch_Load(object sender, EventArgs e)
        {

        }
    }
}
