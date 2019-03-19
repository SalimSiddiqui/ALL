using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Data.SqlClient;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [System.Web.Services.WebMethod()]
    public static void Save(string StudentName)
    {
        using (SqlConnection con = new SqlConnection(@"data source=USER-LAPP;user id=sa; password=Elsevier1; database=AdventureWorks2008R2;"))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO Department1    ([Name]) VALUEs (@StudentName);";
                cmd.Parameters.AddWithValue("@StudentName", StudentName);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }

    [System.Web.Services.WebMethod()]
    public static void Delete(int StudentID)
    {
        using (SqlConnection con = new SqlConnection(@"data source=USER-LAPP;user id=sa; password=Elsevier1; database=AdventureWorks2008R2;"))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = "delete from Department1 where DepartmentID=@StudentID;";
                cmd.Parameters.AddWithValue("@StudentID", StudentID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }

    [System.Web.Services.WebMethod()]
    public static List<Names> GetList()
    {
        List<Names> names = new List<Names>();
        DataSet ds = new DataSet();
        using (SqlConnection con = new SqlConnection(@"data source=USER-LAPP;user id=sa; password=Elsevier1; database=AdventureWorks2008R2;"))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = "select DepartmentID StudentID, Name StudentName from Department1;";
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds);
                }
            }
        }
        if (ds != null && ds.Tables.Count > 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
                names.Add(new Names(int.Parse(dr["StudentID"].ToString()), dr["StudentName"].ToString()));
        }
        return names;
    }


    [System.Web.Services.WebMethod()]
    public static List<Names> Select(int StudentID)
    {
        List<Names> names = new List<Names>();
        DataSet ds = new DataSet();
        using (SqlConnection con = new SqlConnection(@"data source=USER-LAPP;user id=sa; password=Elsevier1; database=AdventureWorks2008R2;"))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = "select DepartmentID StudentID,  Name StudentName from Department1 where DepartmentID=@StudentID;";
             //   cmd.CommandText = "delete from Department1 where DepartmentID=@StudentID;";
                cmd.Parameters.AddWithValue("@StudentID", StudentID);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds);
                }
            }
        }
        if (ds != null && ds.Tables.Count > 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
                names.Add(new Names(int.Parse(dr["StudentID"].ToString()), dr["StudentName"].ToString()));
        }
        return names;
    }


    [System.Web.Services.WebMethod()]
    public static void Update(int StudentID, string StudentName)
    {
        using (SqlConnection con = new SqlConnection(@"data source=USER-LAPP;user id=sa; password=Elsevier1; database=AdventureWorks2008R2;"))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = "update Department1 set  Name=@StudentName where DepartmentID=@StudentID;";
                cmd.Parameters.AddWithValue("@StudentID", StudentID);
                cmd.Parameters.AddWithValue("@StudentName", StudentName);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}

public class Names
{
    public int StudentID;
    public string StudentName;
    public Names(int _StudentID, string _StudentName)
    {
        StudentID = _StudentID;
        StudentName = _StudentName;
    }
}

