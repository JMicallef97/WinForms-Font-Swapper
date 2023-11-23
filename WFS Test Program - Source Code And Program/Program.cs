using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WFS_Test_Program
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.Run(new WFS_Test_Form());
        }
    }
}
