using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Entity;
namespace CodeFirst
{
    public partial class Form1 : Form
    {
        EmployeeRepository db = new EmployeeRepository();
        EmployeeContext dp = new EmployeeContext();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource= db.GetDepartment();
            //dataGridView1.DataSource = (from dep in dp.departments
            //                            from em in dep.employees
            //                            select new
            //                            {
            //                                dep.Name,
            //                                em.FirstName

            //                            }).ToList();

            
        }
    }
}
