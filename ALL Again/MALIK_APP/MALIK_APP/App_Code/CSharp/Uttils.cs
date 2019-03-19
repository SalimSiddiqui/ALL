using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Uttils
/// </summary>
/// 
namespace DataProvider
{
    public class LocalDateTime 
    {
        DateTime Date;
        public LocalDateTime()
        {

        }
        public LocalDateTime(int Year,int Month,int day)
        {
            Date = new DateTime(Year, Month, day);
        }

        public static DateTime Now
        {
            get {                
                DateTime univerTime = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Local);
                univerTime = univerTime.AddSeconds(1);
                TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                return TimeZoneInfo.ConvertTime(univerTime, tz);
                }
        }
    }
    public class Uttils
    {
        
        private static DateTime dto, dfrom;
        public static int Count;
        public static int TDSCount;
        public static int AdminCount;
        public static int AccSMCount;
        public static int CalCount;
        public static int TransCount;       
        public Uttils()
        { 
            
        }
        private static int GetPageIndex(int maximumRows, int startRowIndex)
        {
            double d=startRowIndex / maximumRows;
            return Convert.ToInt32(Math.Ceiling(d)) + 1;
        }
        public static DataTable GetRegistration(string User_Id, string City, string Mobile, int Pair, int Pro_Id, string Member, int Status,string SortCol, int maximumRows, int startRowIndex)
        {
            if (startRowIndex > 0)
                startRowIndex = GetPageIndex(maximumRows, startRowIndex);
            SqlParameter ParamUser_Id = new SqlParameter("Usr_Id", User_Id);
            SqlParameter ParamCity = new SqlParameter("City", City);
            SqlParameter ParamMob = new SqlParameter("Mobile", Mobile);
            SqlParameter ParamPair = new SqlParameter("Pair", Pair);
            SqlParameter ParamPro_Id = new SqlParameter("Pro_Id", Pro_Id);
            SqlParameter ParamMember = new SqlParameter("Member", Member);
            SqlParameter ParamStatus = new SqlParameter("Status", Status);
            SqlParameter ParamPIndex = new SqlParameter("Page_Index", startRowIndex);
            SqlParameter ParamPSize = new SqlParameter("Page_Size", maximumRows);           
            DataTable dt = new DataTable();
            dt = Procedure.GetProcedureData("GeRegistration", ParamUser_Id, ParamPIndex, ParamPSize, ParamCity, ParamMob, ParamMember, ParamPair, ParamPro_Id, ParamStatus);
            DataView dv = dt.DefaultView;
            dv.Sort = SortCol;
            return dv.ToTable();
        }

        public static int RegCount(string User_Id, string City, string Mobile, int Pair, int Pro_Id, string Member, int Status, string SortCol)
        {
            Count = GetRegistration(User_Id, City, Mobile, Pair, Pro_Id, Member, Status, SortCol, 999999, 0).Rows.Count;
            return Count;
            //return Convert.ToInt32(SQL_DB.ExecuteScalar("select count(*) from registration"));
        }
        public static DataTable GetCalData(string User_Id, string Datefrom, string Dateto, string Condition, int maximumRows, int startRowIndex)
        {
            if (startRowIndex > 0)
                startRowIndex = GetPageIndex(maximumRows, startRowIndex);
            if (startRowIndex == 0)
                startRowIndex = 1;

            if (Datefrom != "" && Datefrom!=" ")
            {
              
                dfrom = Convert.ToDateTime(Datefrom);
                Datefrom = dfrom.ToString("MM/dd/yyyy");
            }
            if (Dateto != "" && Dateto!=" ")
            {
                string[] str = Dateto.Split('/');
                dto = Convert.ToDateTime(Dateto);
                Dateto = dto.ToString("MM/dd/yyyy");
            }
            DataSet ds = new DataSet();
            string s = "Select * from (SELECT row_number() over(order by tbl_id) as Row_No ,Cal_Payment_Tab.tbl_id, Cal_Payment_Tab.ID, Cal_Payment_Tab.Left_Child_Current_Date, Cal_Payment_Tab.Right_Child_Current_Date,  Cal_Payment_Tab.Paired_Current_Date, Cal_Payment_Tab.Leps_Bv_Current_Date, Cal_Payment_Tab.BV_Amount, Cal_Payment_Tab.Admin, Cal_Payment_Tab.TDS, Cal_Payment_Tab.WelFair, Cal_Payment_Tab.Final_Amount, Cal_Payment_Tab.Entry_Date, Cal_Payment_Tab.Cal_Date, Cal_Payment_Tab.Referal_amt, Cal_Payment_Tab.Binary_Amt,  Cal_Payment_Tab.User_Id, Registration.Status ,Registration.name FROM   Cal_Payment_Tab INNER JOIN Registration ON Cal_Payment_Tab.User_Id = Registration.user_id  where (''='" + User_Id + "' or '" + User_Id + "' is null or  Cal_Payment_Tab.User_Id='" + User_Id + "') and  ((''='" + Datefrom + "' or '" + Datefrom + "' is null or Cal_Payment_Tab.Cal_Date>='" + dfrom.ToString("MM/dd/yyyy") + "') and (''='" + Dateto + "' or '" + Dateto + "' is null or Cal_Payment_Tab.Cal_Date<='" + dto.ToString("MM/dd/yyyy") + "')) " + Condition + ") Cal_Tab where Row_No>(" + (startRowIndex - 1) * maximumRows + ") and Row_No<=(" + (startRowIndex) * maximumRows + ")     order by Cal_Tab.Cal_Date ";
            SQL_DB.GetDA("Select * from (SELECT row_number() over(order by tbl_id) as Row_No ,Cal_Payment_Tab.Indirect_amt,Cal_Payment_Tab.Left_Pv,Cal_Payment_Tab.Right_Pv,Cal_Payment_Tab.tbl_id, Cal_Payment_Tab.ID, Cal_Payment_Tab.Left_Child_Current_Date, Cal_Payment_Tab.Right_Child_Current_Date,  Cal_Payment_Tab.Paired_Current_Date, Cal_Payment_Tab.Leps_Bv_Current_Date, Cal_Payment_Tab.BV_Amount, Cal_Payment_Tab.Admin, Cal_Payment_Tab.TDS, Cal_Payment_Tab.WelFair, Cal_Payment_Tab.Final_Amount, Cal_Payment_Tab.Entry_Date, Cal_Payment_Tab.Cal_Date, Cal_Payment_Tab.Referal_amt, Cal_Payment_Tab.Binary_Amt,  Cal_Payment_Tab.User_Id, Registration.Status ,Registration.name FROM   Cal_Payment_Tab INNER JOIN Registration ON Cal_Payment_Tab.User_Id = Registration.user_id  where (''='" + User_Id + "' or '" + User_Id + "' is null or  Cal_Payment_Tab.User_Id='" + User_Id + "') and  ((''='" + Datefrom + "' or '" + Datefrom + "' is null or Cal_Payment_Tab.Cal_Date>='" + dfrom.ToString("MM/dd/yyyy") + "') and (''='" + Dateto + "' or '" + Dateto + "' is null or Cal_Payment_Tab.Cal_Date<='" + dto.ToString("MM/dd/yyyy") + "')) " + Condition + ") Cal_Tab where Row_No>(" + (startRowIndex - 1) * maximumRows + ") and Row_No<=(" + (startRowIndex) * maximumRows + ")     order by Cal_Tab.Cal_Date ").Fill(ds, "1");
            return ds.Tables[0];
        }
        public static int CalDataCount(string User_Id, string Datefrom, string Dateto, string Condition)
        {
            if (Datefrom != "" && Datefrom != " ")
            {
             
                dfrom = Convert.ToDateTime(Datefrom);
                Datefrom = dfrom.ToString("MM/dd/yyyy");
            }
            if (Dateto != "" && Dateto != " ")
            {
                dto = Convert.ToDateTime(Dateto);              

                Dateto = dto.ToString("MM/dd/yyyy");
            }

            CalCount = Convert.ToInt32(SQL_DB.ExecuteScalar( "Select count(*) from (SELECT row_number() over(order by tbl_id) as Row_No ,Cal_Payment_Tab.tbl_id, Cal_Payment_Tab.ID, Cal_Payment_Tab.Left_Child_Current_Date, Cal_Payment_Tab.Right_Child_Current_Date,  Cal_Payment_Tab.Paired_Current_Date, Cal_Payment_Tab.Leps_Bv_Current_Date, Cal_Payment_Tab.BV_Amount, Cal_Payment_Tab.Admin, Cal_Payment_Tab.TDS, Cal_Payment_Tab.WelFair, Cal_Payment_Tab.Final_Amount, Cal_Payment_Tab.Entry_Date, Cal_Payment_Tab.Cal_Date, Cal_Payment_Tab.Referal_amt, Cal_Payment_Tab.Binary_Amt,  Cal_Payment_Tab.User_Id, Registration.Status ,Registration.name FROM   Cal_Payment_Tab INNER JOIN Registration ON Cal_Payment_Tab.User_Id = Registration.user_id  where (''='" + User_Id + "' or '" + User_Id + "' is null or  Cal_Payment_Tab.User_Id='" + User_Id + "') and  ((''='" + Datefrom + "' or '" + Datefrom + "' is null or Cal_Payment_Tab.Cal_Date>='" + dfrom.ToString("MM/dd/yyyy") + "') and (''='" + Dateto + "' or '" + Dateto + "' is null or Cal_Payment_Tab.Cal_Date<='" + dto.ToString("MM/dd/yyyy") + "')) " + Condition + ") Cal_Tab    "));
            return CalCount;
            //return Convert.ToInt32(SQL_DB.ExecuteScalar("select count(*) from registration"));
        }

        public static DataTable GetAdminTransactgion(string User_Id, string Datefrom, string Dateto,string TransId, int maximumRows, int startRowIndex)
        {
            if (startRowIndex > 0)
                startRowIndex = GetPageIndex(maximumRows, startRowIndex);
            if (startRowIndex == 0)
                startRowIndex = 1;
            DataSet ds = new DataSet();
            
            SQL_DB.GetDA("Select * from (SELECT   row_number() over(order by F_Transa_Tab.tbl_id) as Row_No ,  F_Transa_Tab.tbl_id, F_Transa_Tab.Tra_ID, F_Transa_Tab.Tra_Date, F_Transa_Tab.Tra_Name, F_Transa_Tab.Cr_Amt, F_Transa_Tab.Dr_Amt, F_Transa_Tab.Remarks, Registration.name, F_Transa_Tab.User_Id FROM   F_Transa_Tab INNER JOIN Registration ON F_Transa_Tab.User_Id = Registration.user_id ) Tab  where Row_No>(" + (startRowIndex - 1) * maximumRows + ") and Row_No<=(" + (startRowIndex) * maximumRows + ") and (' '='" + TransId + "' or Tab.Tra_ID='" + TransId + "') and  (''='" + User_Id + "' or '" + User_Id + "' is null or User_Id='" + User_Id + "') and  ((''='" + Datefrom + "' or '" + Datefrom + "' is null or Tra_Date>='" + Datefrom + "') and (''='" + Dateto + "' or '" + Dateto + "' is null or Tra_Date<='" + Dateto + "')) order by Tra_Date").Fill(ds, "1");
            return ds.Tables[0];
        }
        public static int GetAdminTransactgionCount(string User_Id, string Datefrom, string Dateto, string TransId)
        {
            TransCount = Convert.ToInt32(SQL_DB.ExecuteScalar("Select count(*) from (SELECT    F_Transa_Tab.Tra_ID, F_Transa_Tab.Tra_Date,   F_Transa_Tab.User_Id FROM   F_Transa_Tab INNER JOIN Registration ON F_Transa_Tab.User_Id = Registration.user_id ) Tab  where (''='" + TransId + "' or Tab.Tra_ID='" + TransId + "') and (''='" + User_Id + "' or '" + User_Id + "' is null or User_Id='" + User_Id + "') and  ((''='" + Datefrom + "' or '" + Datefrom + "' is null or Tra_Date>='" + Datefrom + "') and (''='" + Dateto + "' or '" + Dateto + "' is null or Tra_Date<='" + Dateto + "')) "));
            return TransCount;
        }
        public static DataTable GetTDS(string User_Id, string DateFrom, string DateTo, int maximumRows, int startRowIndex)
        {
            DataSet ds = new DataSet();
            if (DateTo == " " || DateTo == null)
                dto = new DateTime(2010, 2, 2);
            else
                dto = Convert.ToDateTime(DateTo);
            if (DateFrom == " " || DateFrom == null)
                dfrom = new DateTime(2010, 2, 2);
            else
                dfrom = Convert.ToDateTime(DateFrom);
            if (startRowIndex > 0)
                startRowIndex = GetPageIndex(maximumRows, startRowIndex);
            if (startRowIndex == 0)
                startRowIndex = 1;
            string g = "select * from ( " +
                     "Select row_number() over(order by User_Id) as Row_No,* from (" +
                     "select Registration.name,Tab.User_Id,sum(Tab.Admin) as Admin,sum(Tab.TDS)as TDS ,sum(Tab.Leader_Deduct)as Leader_Deduct from (" +
                     "SELECT    User_Id,Admin, TDS,Leader_Deduct  FROM   Cal_Payment_Tab where tds>0 and (''='" + DateFrom + "' or  Entry_Date>='" + dfrom.ToString("MM/dd/yyyy") + "') and (''='" + DateTo + "' or Entry_Date<='" + dto.ToString("MM/dd/yyyy") + "')" +
                     " ) as Tab " +
                     "inner join Registration on registration.User_Id=Tab.User_Id where (''='" + User_Id + "' or registration.user_id='" + User_Id + "') group by Registration.name,Tab.User_Id  " +
                     ") as T )as Tab where  Tab.Row_No>" + (startRowIndex - 1) * maximumRows + " and Tab.Row_No<=" + (startRowIndex) * maximumRows;
           SQL_DB.GetDA(g).Fill(ds, "1");
            return ds.Tables["1"];
        }
        public static int GetTDSCount(string User_Id, string DateFrom, string DateTo)
        {
            if (DateTo == " " || DateTo == null)
                dto = new DateTime(2010, 2, 2);
            else
                dto = Convert.ToDateTime(DateTo);
            if (DateFrom == " " || DateFrom == null)
                dfrom = new DateTime(2010, 2, 2);
            else
                dfrom = Convert.ToDateTime(DateFrom);
            string g = "select count(*)  from ( " +
                  "Select row_number() over(order by User_Id) as Row_No,* from (" +
                  "select Registration.name,Tab.User_Id,sum(Tab.Admin) as Admin,sum(Tab.TDS)as TDS from (" +
                  "SELECT    User_Id,Admin, TDS FROM   Cal_Payment_Tab where  tds>0 and (''='" + DateFrom + "' or  Entry_Date>='" + dfrom.ToString("MM/dd/yyyy") + "') and (''='" + DateTo + "' or Entry_Date<='" + dto.ToString("MM/dd/yyyy") + "')" +
                 " ) as Tab " +
                  "inner join Registration on registration.User_Id=Tab.User_Id where (''='" + User_Id + "' or registration.user_id='" + User_Id + "') group by Registration.name,Tab.User_Id  " +
                  ") as T )as Tab  ";
            TDSCount = Convert.ToInt32(SQL_DB.ExecuteScalar(g));
            return TDSCount;

        }
        public static DataTable GetAdmin(string User_Id, string DateFrom, string DateTo, int maximumRows, int startRowIndex)
        {
            DataSet ds = new DataSet();
            if (DateTo == " " || DateTo == null)
                dto = new DateTime(2010, 2, 2);
            else
                dto = Convert.ToDateTime(DateTo);
            if (DateFrom == " " || DateFrom == null)
                dfrom = new DateTime(2010, 2, 2);
            else
                dfrom = Convert.ToDateTime(DateFrom);
            if (startRowIndex > 0)
                startRowIndex = GetPageIndex(maximumRows, startRowIndex);
            if (startRowIndex == 0)
                startRowIndex = 1;
            SQL_DB.GetDA("select * from (SELECT     row_number() over(order by Registration.user_id ) as Row_No,Registration.user_id, Registration.name, sum(Cal_Payment_Tab.Admin) As Admin FROM  Registration INNER JOIN Cal_Payment_Tab ON Registration.user_id = Cal_Payment_Tab.User_Id where  ((' '='" + DateFrom + "' or Cal_Payment_Tab.Cal_date>='" + dfrom.ToString("MM/dd/yyyy") + "') and (' '='" + DateTo + "' or Cal_Payment_Tab.Cal_date<='" + dto.ToString("MM/dd/yyyy") + "')) and Cal_Payment_Tab.Admin>0  group by  Registration.user_id, Registration.name) as Tab where Tab.Row_No>" + (startRowIndex - 1) * maximumRows + " and Tab.Row_No<=" + (startRowIndex) * maximumRows + " and (''='" + User_Id + "' or Tab.User_Id='" + User_Id + "')").Fill(ds, "1");
            return ds.Tables["1"];
        }
        public static int GetAdminCount(string User_Id, string DateFrom, string DateTo)
        {
            if (DateTo == " " || DateTo == null)
                dto = new DateTime(2010, 2, 2);
            else
                dto = Convert.ToDateTime(DateTo);
            if (DateFrom == " " || DateFrom == null)
                dfrom = new DateTime(2010, 2, 2);
            else
                dfrom = Convert.ToDateTime(DateFrom);
            AdminCount= Convert.ToInt32(SQL_DB.ExecuteScalar("select count(*) from (SELECT     Registration.user_id, Registration.name, sum(Cal_Payment_Tab.Admin) As Admin FROM  Registration INNER JOIN Cal_Payment_Tab ON Registration.user_id = Cal_Payment_Tab.User_Id where  ((' '='" + DateFrom + "' or Cal_Payment_Tab.Cal_date>='" + dfrom.ToString("MM/dd/yyyy") + "') and (' '='" + DateTo + "' or Cal_Payment_Tab.Cal_date<='" + dto.ToString("MM/dd/yyyy") + "')) and  Cal_Payment_Tab.Admin>0  group by  Registration.user_id, Registration.name) as Tab where  (''='" + User_Id + "' or Tab.User_Id='" + User_Id + "')"));
            return AdminCount;
        }
        public static DataTable GetAccSummary(string Option, string User_Id, string DateFrom, string DateTo,string TraType, int maximumRows, int startRowIndex, string Trans_Id)
        {
            DataSet ds = new DataSet();
            if (DateTo == " " || DateTo == null)
                dto = new DateTime(2010, 2, 2);
            else
                dto = Convert.ToDateTime(DateTo);
            if (DateFrom == " " || DateFrom == null)
                dfrom = new DateTime(2010, 2, 2);
            else
                dfrom = Convert.ToDateTime(DateFrom);
            if (startRowIndex > 0)
                startRowIndex = GetPageIndex(maximumRows, startRowIndex);
            if (startRowIndex == 0)
                startRowIndex = 1;
            //****Deepak********            
            string Qry = "select * from (SELECT row_number() over(order by Tra_ID ) as Row_No,[Tra_ID],[User_Id],[Tra_Date] ,Tra_Name,[Cr_Amt],[Dr_Amt],[Remarks] FROM [F_Transa_Tab] where (''='" + User_Id + "' or User_Id='" + User_Id + "')  and (''='" + Trans_Id + "' or F_Transa_Tab.Tra_ID='" + Trans_Id + "') and ((' '='" + DateFrom + "' or F_Transa_Tab.Tra_Date>='" + dfrom.ToString("MM/dd/yyyy") + "') and (' '='" + DateTo + "' or F_Transa_Tab.Tra_Date<='" + dto.ToString("MM/dd/yyyy") + "')) " + Option + " ) as Tab where Tab.Row_No>" + (startRowIndex - 1) * maximumRows + " and Tab.Row_No<=" + (startRowIndex) * maximumRows;
            SQL_DB.GetDA("select * from (SELECT row_number() over(order by Tra_ID ) as Row_No,[Tra_ID],[User_Id],[Tra_Date] ,Tra_Name,[Cr_Amt],[Dr_Amt],[Remarks] FROM [F_Transa_Tab] where (''='" + User_Id + "' or User_Id='" + User_Id + "')  and (''='" + Trans_Id + "' or F_Transa_Tab.Tra_ID='" + Trans_Id + "') and ((' '='" + DateFrom + "' or F_Transa_Tab.Tra_Date>='" + dfrom.ToString("MM/dd/yyyy") + "') and (' '='" + DateTo + "' or F_Transa_Tab.Tra_Date<='" + dto.ToString("MM/dd/yyyy") + "')) and (''='"+TraType+"' or  Tra_Name='"+TraType+"') " + Option + " ) as Tab where Tab.Row_No>" + (startRowIndex - 1) * maximumRows + " and Tab.Row_No<=" + (startRowIndex) * maximumRows).Fill(ds, "1");
            return ds.Tables["1"];
        }
        public static int GetAccSummaryCount(string Option, string User_Id, string DateFrom, string DateTo, string Trans_Id, string TraType)
        {
            if (DateTo == " " || DateTo == null)
                dto = new DateTime(2010, 2, 2);
            else
                dto = Convert.ToDateTime(DateTo);
            if (DateFrom == " " || DateFrom == null)
                dfrom = new DateTime(2010, 2, 2);
            else
                dfrom = Convert.ToDateTime(DateFrom);

            AccSMCount = Convert.ToInt32(SQL_DB.ExecuteScalar("select count(*) from (SELECT row_number() over(order by Tra_ID ) as Row_No,[Tra_ID],[User_Id],[Tra_Date] ,Tra_Name,[Cr_Amt],[Dr_Amt],[Remarks] FROM [F_Transa_Tab] where (''='" + User_Id + "' or User_Id='" + User_Id + "')  and (''='" + Trans_Id + "' or F_Transa_Tab.Tra_ID='" + Trans_Id + "') and ((' '='" + DateFrom + "' or F_Transa_Tab.Tra_Date>='" + dfrom.ToString("MM/dd/yyyy") + "') and (' '='" + DateTo + "' or F_Transa_Tab.Tra_Date<='" + dto.ToString("MM/dd/yyyy") + "')) and (''='" + TraType + "' or  Tra_Name='" + TraType + "')  " + Option + " ) as Tab"));
           return AccSMCount;
        }
        public static DataTable GetAccSummaryMember(string Option, string User_Id, string DateFrom, string DateTo, int maximumRows, int startRowIndex, string Trans_Id)
        {
            DataSet ds = new DataSet();
            if (DateTo == " " || DateTo == null)
                dto = new DateTime(2010, 2, 2);
            else
                dto = Convert.ToDateTime(DateTo);
            if (DateFrom == " " || DateFrom == null)
                dfrom = new DateTime(2010, 2, 2);
            else
                dfrom = Convert.ToDateTime(DateFrom);
            if (startRowIndex > 0)
                startRowIndex = GetPageIndex(maximumRows, startRowIndex);
            if (startRowIndex == 0)
                startRowIndex = 1;
            //****Deepak********            
            string Qry = "select * from (SELECT row_number() over(order by Tra_ID ) as Row_No,[Tra_ID],[User_Id],[Tra_Date] ,Tra_Name,[Cr_Amt],[Dr_Amt],[Remarks] FROM [F_Transa_Tab] where (''='" + User_Id + "' or User_Id='" + User_Id + "')  and (''='" + Trans_Id + "' or F_Transa_Tab.Tra_ID='" + Trans_Id + "') and ((' '='" + DateFrom + "' or F_Transa_Tab.Tra_Date>='" + dfrom.ToString("MM/dd/yyyy") + "') and (' '='" + DateTo + "' or F_Transa_Tab.Tra_Date<='" + dto.ToString("MM/dd/yyyy") + "')) " + Option + " ) as Tab where Tab.Row_No>" + (startRowIndex - 1) * maximumRows + " and Tab.Row_No<=" + (startRowIndex) * maximumRows;
            SQL_DB.GetDA("select * from (SELECT row_number() over(order by Tra_ID ) as Row_No,[Tra_ID],[User_Id],[Tra_Date] ,Tra_Name,[Cr_Amt],[Dr_Amt],[Remarks] FROM [F_Transa_Tab] where (''='" + User_Id + "' or User_Id='" + User_Id + "')  and (''='" + Trans_Id + "' or F_Transa_Tab.Tra_ID='" + Trans_Id + "') and ((' '='" + DateFrom + "' or F_Transa_Tab.Tra_Date>='" + dfrom.ToString("MM/dd/yyyy") + "') and (' '='" + DateTo + "' or F_Transa_Tab.Tra_Date<='" + dto.ToString("MM/dd/yyyy") + "'))  " + Option + " ) as Tab where Tab.Row_No>" + (startRowIndex - 1) * maximumRows + " and Tab.Row_No<=" + (startRowIndex) * maximumRows).Fill(ds, "1");
            return ds.Tables["1"];
        }
        public static int GetAccSummaryMemberCount(string Option, string User_Id, string DateFrom, string DateTo, string Trans_Id)
        {
            if (DateTo == " " || DateTo == null)
                dto = new DateTime(2010, 2, 2);
            else
                dto = Convert.ToDateTime(DateTo);
            if (DateFrom == " " || DateFrom == null)
                dfrom = new DateTime(2010, 2, 2);
            else
                dfrom = Convert.ToDateTime(DateFrom);

            AccSMCount = Convert.ToInt32(SQL_DB.ExecuteScalar("select count(*) from (SELECT row_number() over(order by Tra_ID ) as Row_No,[Tra_ID],[User_Id],[Tra_Date] ,Tra_Name,[Cr_Amt],[Dr_Amt],[Remarks] FROM [F_Transa_Tab] where (''='" + User_Id + "' or User_Id='" + User_Id + "')  and (''='" + Trans_Id + "' or F_Transa_Tab.Tra_ID='" + Trans_Id + "') and ((' '='" + DateFrom + "' or F_Transa_Tab.Tra_Date>='" + dfrom.ToString("MM/dd/yyyy") + "') and (' '='" + DateTo + "' or F_Transa_Tab.Tra_Date<='" + dto.ToString("MM/dd/yyyy") + "'))   " + Option + " ) as Tab"));
            return AccSMCount;
        }
        public static void sendMail(string server, string userID, string password, string sendTo, string body, string subject)
        {
            try
            {
                using (System.Net.Mail.MailMessage mess = new System.Net.Mail.MailMessage())
                {
                    System.Net.Mail.SmtpClient sc = new System.Net.Mail.SmtpClient();
                    mess.To.Add(sendTo);
                    mess.Subject = subject;
                    mess.Body = body;
                    mess.IsBodyHtml = true;
                    mess.From = new System.Net.Mail.MailAddress(userID);
                    sc.Host = server;
                    sc.Port = 25;
                    sc.UseDefaultCredentials = false;
                    sc.Credentials = new System.Net.NetworkCredential(userID, password);
                    sc.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    sc.Send(mess);
                }
            }
            catch (Exception)
            {
                
            }
        }

        public static void UpdateForRefferalIncome(string Refferal)
        {
            SqlParameter ParamUser_Id = new SqlParameter("User_Id", Refferal);
            Procedure.ExecuteProcedure("UpdateUserForZoneIncome", ParamUser_Id);
        }
        public static string GetNewUserID()
        {
            Random r = new Random();
            return r.Next().ToString().Substring(0, 8);
            
        }
    }
    public class Procedure
    {      
        private static SqlCommand cmd;
        private static SqlConnection con;
        private static SqlDataAdapter adp;
        public static void ExecuteProcedure(string ProcedureName,params   SqlParameter [] ProParameters)
        {          
            con = SQL_DB.CreateConnection();
            cmd = SQL_DB.CreateCommand(con, ProcedureName);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(ProParameters);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static DataTable GetProcedureData(string ProcedureName, params   SqlParameter[] ProParameters)
        {
            con = SQL_DB.CreateConnection();
            cmd = SQL_DB.CreateCommand(con, ProcedureName);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(ProParameters);
            adp = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adp.Fill(ds);
            return ds;
        }


    }
    public class RegistrationUtility
    {

         
        public bool InsertAbove(string User_ID)
        {
            DataSet ds = new DataSet();
            SQL_DB.GetDA("Select * From registration where USer_id='" + User_ID + "'").Fill(ds, "1");
            if (ds.Tables["1"].Rows.Count == 0)
                return false;
            DataTable dt = ds.Tables["1"].Copy();
            dt.Rows[0]["User_Id"] = Uttils.GetNewUserID();
            string Qry=Class1.GetQry(dt.Rows[0]["User_Id"].ToString(), dt.Rows[0]["sponsor_id"].ToString(), dt.Rows[0]["parent_Id"].ToString(), dt.Rows[0]["sponsor_name"].ToString(), 1, dt.Rows[0]["Pos"].ToString(), dt.Rows[0]["User_ID"].ToString(), dt.Rows[0]["User_Id"].ToString(), Convert.ToDateTime(dt.Rows[0]["d_o_b"]), dt.Rows[0]["name"].ToString(), dt.Rows[0]["father_name"].ToString(), dt.Rows[0]["mother_name"].ToString(), dt.Rows[0]["address"].ToString(), dt.Rows[0]["city"].ToString(), dt.Rows[0]["state"].ToString(), dt.Rows[0]["mobile"].ToString(), dt.Rows[0]["pan_no"].ToString(), dt.Rows[0]["e_mail"].ToString(), dt.Rows[0]["bank_name"].ToString(), dt.Rows[0]["account_no"].ToString(), dt.Rows[0]["product_code"].ToString(), dt.Rows[0]["nominee_name"].ToString(), dt.Rows[0]["nominee_relation"].ToString(), dt.Rows[0]["payment_mode"].ToString(), dt.Rows[0]["dd_no"].ToString(), dt.Rows[0]["dd_date"].ToString(), dt.Rows[0]["bank"].ToString(), dt.Rows[0]["ifc"].ToString(), dt.Rows[0]["Branch_name"].ToString(), dt.Rows[0]["pin"].ToString(), "");
            SQL_DB.ExecuteNonQuery(Qry);
            SQL_DB.ExecuteNonQuery("Update Registration set Sponsor_Id='" + dt.Rows[0]["User_Id"].ToString() + "', sponsor_name=name where User_id='" + User_ID + "'");
            return true;


        }
    }
   
}

