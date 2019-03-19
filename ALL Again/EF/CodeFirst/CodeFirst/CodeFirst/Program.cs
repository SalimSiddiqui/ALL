using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;

namespace CodeFirst
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EmployeeContext>());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
