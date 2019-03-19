using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Class1
{
    SqlConnection Cn = new SqlConnection();
    SqlCommand Cmd = new SqlCommand();
   
	public Class1()
	{
        //Cn.ConnectionString = "Initial Catalog=AdventureWorks2008; User Id=sa; Password=Elsevier1; Server=DS-D02788817CBC; Integrated Security=SSPI;";
        Cn.ConnectionString = "Initial Catalog=AdventureWorks2008; User Id=sa; Password=Elsevier1; Server=User-Lapp; Integrated Security=SSPI;";
	}
    public DataTable ExeDataSet(string Qry)
    {
       
        DataSet Ds = new DataSet();
        Cn.Open();        
        Cmd.CommandType = CommandType.Text;
        SqlDataAdapter Adp = new SqlDataAdapter(Qry, Cn);
        Adp.Fill(Ds);
        Cn.Close();
        return Ds.Tables[0];
    }
    public int credit(int a)
    {
        return 100 - a;
    }
}