using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Http;

/// Summary description for DDL_Service
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]


[ScriptService]
public class DDL_Service : System.Web.Services.WebService
{
    SqlConnection Cn = new SqlConnection();
    SqlCommand Cmd = new SqlCommand();
    String ConnectionString = @"Initial Catalog=AdventureWorks2008; User Id=sa; Password=Elsevier1; Data Source=DS-GFB18Q2;Integrated Security=true;";

    public DDL_Service()
    {
        Cn.ConnectionString = ConnectionString;
        //Cn.ConnectionString = "Initial Catalog=AdventureWorks2008; User Id=sa; Password=Elsevier1; Server=DS-D02788817CBC; Integrated Security=SSPI;";
    }

    [WebMethod]

    public void GetDepartment()
    {

        DataSet Ds = new DataSet();
        Cn.Open();
        Cmd.CommandType = CommandType.Text;
        SqlDataAdapter Adp = new SqlDataAdapter("Select DepartmentID,Name from HumanResources.Department", Cn);
        Adp.Fill(Ds);
        Cn.Close();

    }

    [WebMethod]
    public void GetDepartmentJson()
    {
        List<Department> DepList = new List<Department>();
        DataSet Ds = new DataSet();
        try
        {
            Cn.Open();
            Cmd.Connection = Cn;
            Cmd.CommandText = "Select DepartmentID,Name from HumanResources.Department";
            Cmd.CommandType = CommandType.Text;
        }
        catch (Exception ex)
        {


        }
        SqlDataReader dr = Cmd.ExecuteReader();
        while (dr.Read())
        {
            Department d = new Department();
            d.Id = Convert.ToInt16(dr["DepartmentID"]);
            d.Dep = dr["Name"].ToString();
            DepList.Add(d);
        }
        dr.Close();
        // Cn.Close();
        JavaScriptSerializer Js = new JavaScriptSerializer();
        Context.Response.Write(Js.Serialize(DepList));

    }
    [WebMethod]
    public void GetpersonDetails()
    {
        List<Person> Plist = new List<Person>();
        Cn.Open();
        Cmd.CommandText = "SELECT TOP 100 [BusinessEntityID],[FirstName],[LastName] ,[ModifiedDate] FROM Person.Person";
        Cmd.Connection = Cn;
        SqlDataReader dr = Cmd.ExecuteReader();
        while (dr.Read())
        {
            Person P = new Person();
            P.BusinessEntityID = Convert.ToInt16(dr["BusinessEntityID"]);
            P.FirstName = dr["FirstName"].ToString();
            P.LastName = dr["LastName"].ToString();
            P.ModifiedDate = Convert.ToDateTime(dr["ModifiedDate"]);
            Plist.Add(P);

        }
        Cn.Close();
        JavaScriptSerializer Js = new JavaScriptSerializer();
        Context.Response.Write(Js.Serialize(Plist));
    }


    /// <summary>
    /// ////////////////////
    /// </summary>

    [WebMethod]
    public void GetList()
    {
        List<Names> names = new List<Names>();
        DataSet ds = new DataSet();
        using (SqlConnection con = new SqlConnection(ConnectionString))
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
        JavaScriptSerializer Js = new JavaScriptSerializer();
        Context.Response.Write(Js.Serialize(names));


    }
    [WebMethod]
    public void Select(int StudentID)
    {
        List<Names> names = new List<Names>();
        DataSet ds = new DataSet();
        using (SqlConnection con = new SqlConnection(ConnectionString))
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
        JavaScriptSerializer Js = new JavaScriptSerializer();
        Context.Response.Write(Js.Serialize(names));

    }
    [WebMethod]
    public void Save(string studetnName)
    {

        using (SqlConnection con = new SqlConnection(ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO Department1    ([Name]) VALUEs (@StudentName);";
                cmd.Parameters.AddWithValue("@StudentName", studetnName);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }


    #region Comp
    [WebMethod]
    public void GetCompData()
    {
        List<Company> DepList = new List<Company>();
        DataSet Ds = new DataSet();
        try
        {
            Cn.Open();
            Cmd.Connection = Cn;
            Cmd.CommandText = "Select * from Company;";
            Cmd.CommandType = CommandType.Text;
        }
        catch (Exception ex)
        {
        }
        SqlDataReader dr = Cmd.ExecuteReader();
        while (dr.Read())
        {
            Company d = new Company();
            d.companyId = Convert.ToInt16(dr["companyId"]);
            d.name = dr["Name"].ToString();
            d.ceo = dr["ceo"].ToString();
            d.country = dr["country"].ToString();
            d.foundationYear = dr["foundationYear"].ToString();
            d.noOfEmployee = dr["noOfEmployee"].ToString();
            DepList.Add(d);
        }
        dr.Close();
         Cn.Close();
        JavaScriptSerializer Js = new JavaScriptSerializer();
        Context.Response.Write(Js.Serialize(DepList));

    }
    [WebMethod]    
    public void InsertCompData(Company Company)
    {
        
        DataSet Ds = new DataSet();
        Company d = new Company();
        int q=0;
        try
        {
            Cn.Open();
            Cmd.Connection = Cn;
            Cmd.CommandText = "Insert into Company (Name,ceo,country,foundationYear,noOfEmployee) values ('" + Company.name + "','" + Company.ceo + "','" + Company.country + "','" + Company.foundationYear + "','" + Company.noOfEmployee + "')";
            Cmd.CommandType = CommandType.Text;
            q = Cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
        }
        Cn.Close();
    }    
    

}
#endregion



