using System;
using System.Web.Services;
using System.Data.SqlClient;
using System.Web.Script.Services;
using System.Collections.Generic;
using System.Data;

namespace TestNgDemo
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        //public static String ConnectionString = @"Initial Catalog=AdventureWorks2008R2; User Id=sa; Password=cyber; Server=DESKTOP-TCNCG2F; Integrated Security=SSPI;";
        public static String ConnectionString = @"Initial Catalog=AdventureWorks2008; User Id=sa; Password=Elsevier1; Server=DS-D02788817CBC\SQLSERVER2012; Integrated Security=SSPI;";

        [System.Web.Services.WebMethod()]
        public List<student> FillMoh(int Id)
        {
            List<student> names = new List<student>();

            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "select StudentID,StudentName from tblStudents where IsActive=1 and StudentID>" + Id;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                }
            }
            if (ds != null && ds.Tables.Count > 0)
            {

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    student emp = new student();
                    emp.StudentID = int.Parse(dr["StudentID"].ToString());
                    emp.StudentName = dr["StudentName"].ToString();
                    names.Add(emp);
                }
            }
            return names;
        }

        [System.Web.Services.WebMethod()]
        public List<student> FillCity(int Id)
        {
            List<student> names = new List<student>();

            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "select StudentID,StudentName from tblStudents where IsActive=1 and StudentID>"+Id;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                }
            }
            if (ds != null && ds.Tables.Count > 0)
            {

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    student emp = new student();
                    emp.StudentID = int.Parse(dr["StudentID"].ToString());
                    emp.StudentName = dr["StudentName"].ToString();
                    names.Add(emp);
                }
            }
            return names;
        }
        [System.Web.Services.WebMethod()]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<student> Fillddl()
        {
            List<student> names = new List<student>();

            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "select StudentID,StudentName from tblStudents where IsActive=1;";
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                }
            }
            if (ds != null && ds.Tables.Count > 0)
            {

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    student emp = new student();
                    emp.StudentID = int.Parse(dr["StudentID"].ToString());
                    emp.StudentName = dr["StudentName"].ToString();
                    names.Add(emp);
                }
            }
            return names;
        }


        #region CrudStudent
        [WebMethod]
        public string HelloWorld(string StudentName)
        {
            return "Hello World" + StudentName;
        }

        [System.Web.Services.WebMethod()]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]

        public void InsertSave(student student)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "insert into tblStudents (StudentName) values (@StudentName);";
                    cmd.Parameters.AddWithValue("@StudentName", student.StudentName);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        [System.Web.Services.WebMethod()]
        public string UpdateStudent(student student)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.Connection = con;
                    cmd.CommandText = "Update tblStudents set StudentName=@StudentName where StudentID=@StudentID;";
                    cmd.Parameters.AddWithValue("@StudentName", student.StudentName);
                    cmd.Parameters.AddWithValue("@StudentID", student.StudentID); ;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return "success";
                }
            }
        }

        [System.Web.Services.WebMethod()]
        public void deleteStudent(int StudentID)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "update tblStudents set IsActive=0 where StudentID=@StudentID;";
                    cmd.Parameters.AddWithValue("@StudentID", StudentID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        [System.Web.Services.WebMethod()]
        public List<student> GetList()
        {
            List<student> names = new List<student>();

            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "select StudentID,StudentName from tblStudents where IsActive=1;";
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                }
            }
            if (ds != null && ds.Tables.Count > 0)
            {

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    student emp = new student();
                    emp.StudentID = int.Parse(dr["StudentID"].ToString());
                    emp.StudentName = dr["StudentName"].ToString();
                    names.Add(emp);
                }
            }
            return names;
        }
        [WebMethod]
        public student GetStudentById(int StudentId)
        {
            student emp = new student();
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "select StudentID,StudentName from tblStudents where IsActive=1 and StudentID=" + StudentId;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                }
            }
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    emp.StudentID = int.Parse(dr["StudentID"].ToString());
                    emp.StudentName = dr["StudentName"].ToString();

                }
            }
            return emp;
        }
        #endregion
    }
}
