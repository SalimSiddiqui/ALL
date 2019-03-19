using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Data.SqlClient;
using System.Data;

public partial class Default : System.Web.UI.Page
{
   public static String ConnectionString = @"Initial Catalog=AdventureWorks2008R2; User Id=sa; Password=cyber; Server=DESKTOP-TCNCG2F; Integrated Security=SSPI;";

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //[System.Web.Services.WebMethod()]
    //public static void Save(string StudentName)
    //{
    //    using (SqlConnection con = new SqlConnection(ConnectionString))
    //    {
    //        using (SqlCommand cmd = new SqlCommand())
    //        {
    //            cmd.Connection = con;
    //            cmd.CommandText = "insert into tblStudents (StudentName) values (@StudentName);";
    //            cmd.Parameters.AddWithValue("@StudentName", StudentName);
    //            con.Open();
    //            cmd.ExecuteNonQuery();
    //            con.Close();
    //        }
    //    }
    //}

    //[System.Web.Services.WebMethod()]
    //public static void Delete(int StudentID)
    //{
    //    using (SqlConnection con = new SqlConnection(ConnectionString))
    //    {
    //        using (SqlCommand cmd = new SqlCommand())
    //        {
    //            cmd.Connection = con;
    //            cmd.CommandText = "update tblStudents set IsActive=0 where StudentID=@StudentID;";
    //            cmd.Parameters.AddWithValue("@StudentID", StudentID);
    //            con.Open();
    //            cmd.ExecuteNonQuery();
    //            con.Close();
    //        }
    //    }
    //}

    //[System.Web.Services.WebMethod()]
    //public static List<Names> GetList()
    //{
    //    List<Names> names = new List<Names>();
    //    DataSet ds = new DataSet();
    //    using (SqlConnection con = new SqlConnection(ConnectionString))
    //    {
    //        using (SqlCommand cmd = new SqlCommand())
    //        {
    //            cmd.Connection = con;
    //            cmd.CommandText = "select StudentID,StudentName from tblStudents where IsActive=1;";
    //            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
    //            {
    //                da.Fill(ds);
    //            }
    //        }
    //    }
    //    if (ds != null && ds.Tables.Count > 0)
    //    {
    //        foreach (DataRow dr in ds.Tables[0].Rows)
    //            names.Add(new Names(int.Parse(dr["StudentID"].ToString()), dr["StudentName"].ToString()));
    //    }
    //    return names;
    //}

}
[Serializable]
public class student
{
    private int _StudentID;

    public int StudentID
    {
        get { return _StudentID; }
        set { _StudentID = value; }
    }
    private string _StudentName;

    public string StudentName
    {
        get { return _StudentName; }
        set { _StudentName = value; }
    }

    //public int StudentID;
    //public string StudentName;
    //public student(int _StudentID, string _StudentName)
    //{
    //    StudentID = _StudentID;
    //    StudentName = _StudentName;
    //}
}

