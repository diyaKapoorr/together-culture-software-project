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
    public partial class digitalContent : Form
    {
        public digitalContent()
        {
            InitializeComponent();
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            List<Module> modules = new List<Module>
            {
                new Module { ModuleID = 1, Title = "Art of Watches", Description = "This module will explain how watches are made and the several intricacies that is engineered within them" },
                new Module { ModuleID = 2, Title = "Coding 101", Description = "A short intro into the world of developers. How code is made and the process behind making the very apps you use to browse the internet!" },
                new Module { ModuleID = 3, Title = "Forms", Description = "Help" }
            };

            // Set the data source of the ListBox to this list
            listBoxModules.DataSource = modules;

        }

        private void listBoxModules_DoubleClick(object sender, EventArgs e)
        {
            // Get the selected module
            Module selectedModule = (Module)listBoxModules.SelectedItem;

            // Open a new form to show module details
            ModuleDetailsForm detailsForm = new ModuleDetailsForm(selectedModule);
            detailsForm.Show();
        }
    }
}
