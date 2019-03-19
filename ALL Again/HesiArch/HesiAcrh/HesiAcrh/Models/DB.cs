using System.Configuration;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for Class1
/// </summary>
public class DB
{
    private static SqlConnection CreateConnection(SqlConnection con)
    {
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ConPlan"].ConnectionString;
        return con;
    }
    private static SqlConnection OpenConnection(SqlConnection con)
    {
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
            return con;
        }
        else
            return con;
    }
    private static void CloseConnection(SqlConnection con)
    {
        if (con.State != ConnectionState.Closed)
            con.Close();
    }
    private static SqlCommand CreateCommand(string Qry, SqlConnection con)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = Qry;
        con = CreateConnection(con);
        OpenConnection(con);
        cmd.Connection = con;
        return cmd;
    }
    public static SqlDataAdapter GetDA(string Qry)
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = CreateCommand(Qry, con);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        CloseConnection(con);
        return adp;
    }
    public static void ExecuteNonQuery(string Qry)
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = CreateCommand(Qry, con);
        cmd.ExecuteNonQuery();
        CloseConnection(con);
    }
    public static object ExecuteScaler(string Qry)
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = CreateCommand(Qry, con);        
        object ob = cmd.ExecuteScalar();
        CloseConnection(con);
        return ob;
    }

    public static void ExecuteProcedure(string ProcedureName, params   SqlParameter[] ProParameters)
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = CreateCommand(ProcedureName,con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddRange(ProParameters);
        con.Open();
        cmd.ExecuteNonQuery();
        CloseConnection(con);
       
    }
    public static DataTable GetProcedureData(string ProcedureName, params   SqlParameter[] ProParameters)
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = CreateCommand(ProcedureName, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddRange(ProParameters);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataTable ds = new DataTable();
        adp.Fill(ds);
        CloseConnection(con);
        return ds;
    }
}
