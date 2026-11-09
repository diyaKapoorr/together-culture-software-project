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
    public partial class ModuleDetailsForm : Form
    {
        public ModuleDetailsForm(Module module)
        {
            InitializeComponent();

            // Display module details
            lblTitle.Text = module.Title;
            lblDescription.Text = module.Description;
        }
    }
}
