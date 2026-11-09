using System;
using System.Windows.Forms;

namespace member_space
{

    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void is_Valid_Email(TextBox text_Box)
        {
            if (text_Box != null)
            {
                MessageBox.Show("Please input a valid email");
            }
            //if (text_Box != " ")
        }
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrontPage());
        }
    }
}
