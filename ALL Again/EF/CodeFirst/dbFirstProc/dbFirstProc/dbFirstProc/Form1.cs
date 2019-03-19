using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityFramework.Extensions;
using System.Collections;
namespace dbFirstProc
{
    public partial class Form1 : Form
    {
        SampledataEntities db = new SampledataEntities();
        public Form1()
        {

            InitializeComponent();

            ObjectParameter a = new ObjectParameter("Id", 1);
            //db.ExecuteFunction("delemp", a);

            //db.ExecuteStoreCommand<("delemp", a);
            //IEnumerable<getempdataResult_Result> ds = db.ExecuteFunction<getempdataResult_Result>("getempdataResult");          
            //dataGridView1.DataSource = ds;

            //Return Copmpltex type
            LoadAllEmp();
        }

        private void LoadAllEmp()
        {
            IEnumerable<getempwithdept_Result> ds = db.ExecuteFunction<getempwithdept_Result>("getempwithdept");
            dataGridView1.DataSource = ds;


            //label1.Text = c.Count.ToString();

            var aa = (from t in db.Employees
                      select t).Count();

            label1.Text = aa.ToString();
            label1.Text = db.Employees.Count().ToString();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            Employee em = new Employee
            {
                FirstName = "a",
                LastName = "aa",
                Salary = 10,
                DepartmentId = 1,
                City = "newLKO",
                Gender = "Male"
            };
            db.AddToEmployees(em);
            db.SaveChanges();
        }

        private void Bload_Click(object sender, EventArgs e)
        {
            string mess = string.Empty;
            StringBuilder sa = new StringBuilder();

            #region em
            List<Employee> em = new List<Employee>()
            {
                new Employee{
                FirstName = "a",
                LastName = "aa",
                Salary = 10,
                
                DepartmentId = 10,
                City = "newLKO",
                Gender = "Male"},
                new Employee{
                FirstName = "ab",
                LastName = "aab",
                Salary = 100,
                DepartmentId = 2,
                City = "newLKObb",
                Gender = "Maleaa"}
                
                
            };
            #endregion

            try
            {
                DataContext ds = new DataContext();



                ds.employeesdbset.AddRange(em);
                ds.SaveChanges();

                LoadAllEmp();

            }
            catch (Exception ex)
            {
                mess = ex.Message;
                string inn = ex.InnerException.Message;
            }
            finally
            {
                LoadAllEmp();
                label2.Text = mess;
            }
        }

        public void CheckArrayList()
        {
            ArrayList paramList = new ArrayList();

            Employee c = new Employee { Id = 1, FirstName = "MobilePhones" };
            Department p = new Department { Id = 1, Name = "MotoG" };
            paramList.Add(c);
            paramList.Add(p);
        }
    }
}
