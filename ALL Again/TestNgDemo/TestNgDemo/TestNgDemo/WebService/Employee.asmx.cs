using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Data.SqlClient;
using System.Configuration;

namespace TestNgDemo.WebService
{
    /// <summary>
    /// Summary description for Employee
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Employee : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //Create new objec Insert
        public void AddEmployee(int id, string Name, string Gender, Decimal Salary)
        {


            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Insert into EmployeeTbl values('" + id + "','" + Name + "','" + Gender + "','" + Salary + "')", con);

                con.Open();
                cmd.ExecuteNonQuery();

            }

        }
    }
}
