using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Text;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Class1
{
   
    public static string server = Convert.ToString(ConfigurationManager.ConnectionStrings["servername"].ConnectionString), userID = Convert.ToString(ConfigurationManager.ConnectionStrings["user_id"].ConnectionString), password = Convert.ToString(ConfigurationManager.ConnectionStrings["password"].ConnectionString), sendTo = "helpdesk@astitav.co.in", subject = "Enquiry";

    public static int i = 0;
    public static int  Percent=10;

    public Class1()
    {
        //
        // TODO: Add constructor logic here
        //  
    }
    public static string GetRandom()
    {
        Random r = new Random();
        return r.Next().ToString();
    }
    public static bool CheckValidDOB(DateTime dob)
    {
        dob = Convert.ToDateTime(dob);
        TimeSpan t = DataProvider.LocalDateTime.Now.Subtract(dob);
        if (t.Days < 4380)
            return false;
        else
            return true;

    }
    public static string GetNewCode(string KeyCol)
    {
        return Convert.ToString(SQL_DB.ExecuteScalar("select Prefix + convert(varchar,startwith) from code_gen where Key_col='" + KeyCol.Trim() + "'"));
    }
    public static void SetNewCode(string KeyCol)
    {
        SQL_DB.ExecuteNonQuery("update code_gen set startwith=(select max(startwith) from code_gen where Key_col='" + KeyCol.Trim() + "')+1  where Key_col='" + KeyCol.Trim() + "'");
    }
    public static string GetQry(string user_Id, string sponsor_id, string parentid, string sponsor_name, int act_reg, string pos, string pass, string Acc_Pass, DateTime dob, string name, string father, string mother, string address, string city, string state, string phon, string pan, string email, string bank, string acc, string produ, string nomname, string relation, string paymode, string dddetail, string dddate, string bankname, string ifc, string branch,string pin,string AppFormNo)
    {
        if (dddate != "")
            dddate = Convert.ToDateTime(dddate).ToString("MM/dd/yyyy");
        string act_date = "";
        if (act_reg == 1)
            act_date = DataProvider.LocalDateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
        return " INSERT INTO [Registration] " +
               "([user_id]" +
               ",[pwd]" +
                ",[Acc_pass]" +
               ",[name]" +
               ",[father_name]" +
               ",[User_Name]" +
               ",[address]" +
               ",[city]" +
               ",[state]" +
               ",[country]" +
                ",[Mobile]" +
               ",[d_o_b]" +
               ",[pan_no]" +
               ",[e_mail]" +
               ",[bank_name]" +
               ",[account_no]" +
               ",[product_code]" +
               ",[nominee_name]" +
               ",[nominee_relation]" +
               ",[payment_mode]" +
               ",[sponsor_id]" +
               ",[sponsor_name]" +
               ",[pos]" +
               ",[status]" +
               ",[reg_date]" +
               ",[act_date]" +
                 ",[ifc]" +
               ",[Level_Id],[Parent_Id],[Branch_name],[pin],[appformno])" +
         " VALUES " +
               "('" + user_Id + "'" +
               ",'" + pass + "'" +
                  ",'" + Acc_Pass + "'" +
              ",'" + name.Replace("'", "''") + "'" +
               ",'" + father.Replace("'", "''") + "'" +
               ",'" + mother.Replace("'", "''") + "'" +
               ",'" + address.Replace("'", "''") + "'" +
              " ,'" + city + "'" +
               ",'" + state + "'" +
               ",'India'" +
               ",'" + phon.Replace("'", "''") + "'" +
               ",'" + dob.ToString("MM/dd/yyyy") + "'" +
               ",'" + pan + "'" +
               ",'" + email.Replace("'", "''") + "'" +
               ",'" + bank + "'" +
               ",'" + acc.Replace("'", "''") + "'" +
               ",'" + produ + "'" +
               ",'" + nomname.Replace("'", "''") + "'" +
               ",'" + relation + "'" +
               ",'" + paymode + "'" +
               ",'" + sponsor_id + "'" +
               ",'" + sponsor_name + "'" +
               ",'" + pos + "'" +
               "," + act_reg +
               ",'" + DateTime.Now.ToString("MM/dd/yy H:mm:ss") + "'" +
               ",'" + act_date + "'" +
                      ",'" + ifc + "'" +
               "," + SQL_DB.ExecuteScalar("select level_id+1 from Registration where user_id='" + sponsor_id + "'") + ",'" + parentid + "','" + branch + "','" + pin + "','" + AppFormNo + "');";
    }
    public static void sendSms(string Message, string phone)
    {
        //if (validateSms() == false)
        //    return;
        string str = "";
        try
        {



            str = "http://sms.goforsms.com/sendsmsv2.asp?user=tauseef&password=368131160&sender=7001&text=" + Message + "&PhoneNumber=" + phone + "&track=1";

            WebRequest request = WebRequest.Create(str);
            request.Method = "POST";
            string postData = "";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            Console.WriteLine(responseFromServer);
            reader.Close();
            dataStream.Close();
            response.Close();
        }
        catch
        {

            //SQL_DB.ExecuteNonQuery("INSERT INTO [Message]([Msg_detail],[Mobile_No]) VALUES ('" + Message + "','" + phone + "')");
        }


    }
    public static void sendauto()
    {
         
        //WebRequest request = WebRequest.Create(str);
        //request.Method = "POST";
        //string postData = "";
        //byte[] byteArray = Encoding.UTF8.GetBytes(postData);
        //request.ContentType = "application/x-www-form-urlencoded";
        //request.ContentLength = byteArray.Length;
        //Stream dataStream = request.GetRequestStream();
        //dataStream.Write(byteArray, 0, byteArray.Length);
        //dataStream.Close();

    }
    public static bool validateSms()
    {
        try
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["consms"].ConnectionString;
            cmd.Connection = cn;
            cmd.CommandText = "select isnull(SMS_Master.No_SMS,0) from SMS_Master inner join Sms_Reg on SMS_Master.Cust_id=Sms_Reg.Cust_Id where Sms_Reg.Email_Id='sun@vashundhara.com' and Sms_Reg.password='123' and Sms_Reg.Status=1 ;;";
            cn.Open();
            if (Convert.ToInt32(cmd.ExecuteScalar()) > 1)
            {
                cmd.CommandText = "UPDATE    dbo.SMS_Master SET  No_SMS =(select isnull(max(SMS_Master.No_SMS),0)-1 from SMS_Master inner join Sms_Reg on SMS_Master.Cust_id=Sms_Reg.Cust_Id where Sms_Reg.Email_Id='sun@vashundhara.com' and Sms_Reg.password='123' and Sms_Reg.Status=1) FROM    dbo.Sms_Reg INNER JOIN  dbo.SMS_Master ON dbo.Sms_Reg.Cust_id = dbo.SMS_Master.Cust_Id where Sms_Reg.Email_Id='sun@vashundhara.com' and Sms_Reg.password='123'";
                cmd.ExecuteNonQuery();
                cn.Close();
                return true;
            }
            else
            {
                cn.Close();
                return false;
            }
        }
        catch (Exception ex)
        {
            return true;
        }
    }
    public static void SaveTransaction(string Tra_Name, string Credited_UserId, double amount,  string Admin_Msg)
    {

        /* This Function Called on Following Function 
         from Product Sale 
        
          get Transction Id */
        string Tra_Id = SQL_DB.ExecuteScalar("select isnull(max(Tra_Id),0)+1 from F_Transa_Tab").ToString();


        string Trans_Entry = " ; INSERT INTO [F_Transa_Tab] " +
                      "([User_Id]" +
                       ",[Tra_Id]" +
                      ",[Tra_Date]" +
                      ",[Tra_Name]" +
                      ",[Dr_Amt]" +
                      ",[Cr_Amt]" +
                      ",[Remarks])" +
                " VALUES " +
                      " ('" + Credited_UserId + "'" +
                          "," + Tra_Id +
                      ",'" + DataProvider.LocalDateTime.Now.ToString("MM/dd/yy H:mm:ss") + "'" +
                      ",'" + Tra_Name + "'" +
                      ",0 " +
                      "," + amount +
                     ",'" + Admin_Msg + "')";

        SQL_DB.ExecuteNonQuery(Trans_Entry);
    }
  
    public static void SaveTransaction(string Tra_Name, string Credited_UserId, string Debited_Userid, double amount, string user_Msg, string Admin_Msg, params string[] DDdetail)
    {

        /* This Function Called on Following Function 
         -------Admin---------
         * AdminPanel.aspx.cs
         * Pin_Manage.aspx.cs
         * Man_Request.aspx.cs
         * Show_Growth.aspx.cs
         * TdsForm.aspx.cs
         ------Member-----------
         * Pin_reg.aspx.cs
         * Pin_Request.aspx.cs
         * Pin_trans.aspx.cs      
         */
        // get Transction Id
        string Tra_Id = SQL_DB.ExecuteScalar("select isnull(max(Tra_Id),0)+1 from F_Transa_Tab").ToString();

        string Trans_Entry = "";
        if (DDdetail.Length == 3)
        {
            string DDNo = DDdetail[0];
            string DDDate = DDdetail[1];
            string DDBank = DDdetail[2];
            Trans_Entry = " ; INSERT INTO [F_Transa_Tab] " +
                   "([User_Id]" +
                    ",[Tra_Id]" +
                   ",[Tra_Date]" +
                   ",[Tra_Name]" +
                   ",[Dr_Amt]" +
                   ",[Cr_Amt]" +
                   ",[Remarks] " +
                   ",[DD_No] " +
                   ",[DD_Date] " +
                   ",[DD_Bank])" +
             " VALUES " +
                   " ('" + Debited_Userid + "'" +
                     ","+ Tra_Id +
                   ",'" + DataProvider.LocalDateTime.Now.ToString("MM/dd/yy H:mm:ss") + "'" +
                   ",'" + Tra_Name + "'" +
                   "," + amount +
                   ",0 " +
                    ",'" + user_Msg + " (" + Debited_Userid + ")'" +
                    ",'" + DDNo + "'" +
                    ",'" + Convert.ToDateTime(DDDate).ToString("MM/dd/yyyy") + "'" +
                   ",'" + DDBank + "')";

        }
        else
        {

            Trans_Entry = Trans_Entry + " ; INSERT INTO [F_Transa_Tab] " +
                 "([User_Id]" +
                  ",[Tra_Id]" +
                 ",[Tra_Date]" +
                 ",[Tra_Name]" +
                 ",[Dr_Amt]" +
                 ",[Cr_Amt]" +
                 ",[Remarks])" +
           " VALUES " +
                 " ('" + Debited_Userid + "'" +
                    "," + Tra_Id +
                 ",'" + DataProvider.LocalDateTime.Now.ToString("MM/dd/yy H:mm:ss") + "'" +
                  ",'" + Tra_Name + "'" +
                  "," + amount +
                   ",0 " +
                 ",'" + Admin_Msg + "')";


        }
        Trans_Entry += " ; INSERT INTO [F_Transa_Tab] " +
                      "([User_Id]" +
                       ",[Tra_Id]" +
                      ",[Tra_Date]" +
                      ",[Tra_Name]" +
                      ",[Dr_Amt]" +
                      ",[Cr_Amt]" +
                      ",[Remarks])" +
                " VALUES " +
                      " ('" + Credited_UserId + "'" +
                          "," + Tra_Id +
                      ",'" + DataProvider.LocalDateTime.Now.ToString("MM/dd/yy H:mm:ss") + "'" +
                      ",'" + Tra_Name + "'" +
                      ",0 " +
                      "," + amount +
                     ",'" + user_Msg + " (" + Debited_Userid + ")')";

        SQL_DB.ExecuteNonQuery(Trans_Entry);
    }
    public static int sendMail(string Server, string UserID, string Pass, string SendTo, string Body, string Subject, params string[] FilePath)
    {

        try
        {

            System.Net.Mail.MailMessage Msg = new System.Net.Mail.MailMessage();
            for (int i = 0; i < FilePath.Length; i++)
            {
                System.Net.Mail.Attachment att = new System.Net.Mail.Attachment(FilePath[i]);
                Msg.Attachments.Add(att);
            }
            Msg.To.Add(SendTo);
            Msg.From = new System.Net.Mail.MailAddress(UserID);
            Msg.Subject = Subject;
            Msg.Body = Body;
            Msg.IsBodyHtml = true;
            System.Net.Mail.SmtpClient SmtpServer = new System.Net.Mail.SmtpClient();
            SmtpServer.Host = Server;
            SmtpServer.Port = 25;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential(UserID, Pass);
            SmtpServer.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            SmtpServer.Send(Msg);
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    public static void SaveSalaryIncome()
    {
        double PointValue = 0;
        DataSet ds = new DataSet();
        SQL_DB.GetDA("SELECT [id],[Pv_Left],[Pv_Right],[Salary_Amount],[Year] FROM  [M_SalaryMaster] order by id").Fill(ds, "Salary_Master");
        if( ds.Tables["Salary_Master"].Rows.Count == 0)
            return;
        if( Convert.ToDouble(ds.Tables["Salary_Master"].Rows[0]["Pv_Left"])< Convert.ToDouble(ds.Tables["Salary_Master"].Rows[0]["Pv_Right"]))
            PointValue = Convert.ToDouble(ds.Tables["Salary_Master"].Rows[0]["Pv_Left"]);
        else
            PointValue = Convert.ToDouble(ds.Tables["Salary_Master"].Rows[0]["Pv_Right"]);
        
        // query get result that is  greater than or equal to parameter of pv
        
        SQL_DB.GetDA("select User_Id,Left_Pv,Right_Pv from Get300PVUser(" + PointValue + ")").Fill(ds, "1");
        SQL_DB.GetDA("SELECT [id],[User_Id],[Entry_Date],[Salary_Id] FROM [T_Salary] ").Fill(ds, "2");
      
        DataView Dv = ds.Tables["2"].DefaultView;
        if (ds.Tables["1"].Rows.Count == 0 || ds.Tables["Salary_Master"].Rows.Count == 0)
            return;
        
        // deduction master
        SQL_DB.GetDA("SELECT [Admin_Charge],[TDS] FROM [Detect_Master]").Fill(ds, "Deduct_Master");
        double admin = 0;
        double tds = 0;
        if (ds.Tables["Deduct_Master"].Rows.Count == 0)
            return;
        admin = Convert.ToDouble(ds.Tables["Deduct_Master"].Rows[0]["Admin_Charge"]);
        tds = Convert.ToDouble(ds.Tables["Deduct_Master"].Rows[0]["TDS"]);


        DataRowCollection Row;
        double SalaryAmount = 0;
        for (int i = 0; i < ds.Tables["1"].Rows.Count; i++)
        {
            double Left_Pv = Convert.ToDouble(ds.Tables["1"].Rows[i]["Left_Pv"].ToString());
            double Right_Pv = Convert.ToDouble(ds.Tables["1"].Rows[i]["Right_Pv"].ToString());

            bool IsPay = false;
            Dv.RowFilter = "User_Id='" + ds.Tables["1"].Rows[i]["User_Id"].ToString() + "'";
            Dv.Sort = "Entry_Date desc";
            Row = Dv.ToTable().Rows;
            if (Row.Count == 0)
                IsPay = true;
            else
            {
                // check one month has completed
                TimeSpan T = DataProvider.LocalDateTime.Now.Subtract(Convert.ToDateTime(Row[0]["Entry_Date"].ToString()));
                if (T.Days >= 30)                  
                    IsPay = true;
            }

            //if (Left_Pv >= Convert.ToDouble(ds.Tables["Salary_Master"].Rows[0]["Pv_Left"]) && Right_Pv >= Convert.ToDouble(ds.Tables["Salary_Master"].Rows[0]["Pv_Right"]))
            //    SalaryAmount = Convert.ToDouble(ds.Tables["Salary_Master"].Rows[0]["Salary_Amount"]);
            //if (Left_Pv >= Convert.ToDouble(ds.Tables["Salary_Master"].Rows[1]["Pv_Left"]) && Right_Pv >= Convert.ToDouble(ds.Tables["Salary_Master"].Rows[1]["Pv_Right"]))
            //    SalaryAmount = Convert.ToDouble(ds.Tables["Salary_Master"].Rows[1]["Salary_Amount"]);
            //if (Left_Pv >= Convert.ToDouble(ds.Tables["Salary_Master"].Rows[2]["Pv_Left"]) && Right_Pv >= Convert.ToDouble(ds.Tables["Salary_Master"].Rows[2]["Pv_Right"]))
            //    SalaryAmount = Convert.ToDouble(ds.Tables["Salary_Master"].Rows[2]["Salary_Amount"]);
            if (!IsPay)
                continue;
            DataView SalaryMaster = ds.Tables["Salary_Master"].DefaultView;
            SalaryMaster.RowFilter = "Pv_Left<=" + Left_Pv + " and Pv_Right<=" + Right_Pv;
            SalaryMaster.Sort = "id desc";
            DataRowCollection Rows = SalaryMaster.ToTable().Rows;
            if (Rows.Count == 0)
                continue;
            SalaryAmount = Convert.ToDouble(Rows[0]["Salary_Amount"]);
            int Sal_Id = Convert.ToInt32(Rows[0]["id"]);
            int Year = Convert.ToInt32(Rows[0]["id"]);
            Dv.RowFilter = "User_Id='" + ds.Tables["1"].Rows[i]["User_Id"].ToString() + "' and Salary_Id=" + Sal_Id;
               // check for 3 years compreted or not and check moth is completed or not
            Row = Dv.ToTable().Rows;
            if (Row.Count < (Year*12) && SalaryAmount>0)
            {
                double FilanAmt = SalaryAmount;
                double a = FilanAmt * admin / 100;
                FilanAmt -= a;
                double tdscharge = FilanAmt * tds / 100;
                FilanAmt -= tdscharge;
                string Qry = "INSERT INTO [T_Salary]" +
                "([User_Id]" +
                ",[Salary_Amt]" +
                 ",[Admin]" +
                 ",[TDS]" +
                  ",[Final_Amt]" +
                 ",[Salary_Id]" +
                ",[Entry_Date])" +
                 "VALUES " +
              "  ('" + ds.Tables["1"].Rows[i]["User_Id"].ToString() + "'" +
               " ," + SalaryAmount +
                 " ," + a +
                  " ," + tdscharge +
                  " ," + FilanAmt +
                   " ," + Sal_Id +
               " ,'" + DataProvider.LocalDateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "')";
                SQL_DB.ExecuteNonQuery(Qry);
            }
        }
    }
    public static void AllotPin(string User_Id)
    {

        DataSet ds = new DataSet();
        int pro_code = Convert.ToInt32(SQL_DB.ExecuteScalar("select isnull(max(product_code),0) from product_master where PV=0 and del_flag=0"));
        if (pro_code == 0)
            return;
        l:
        SQL_DB.GetDA("select top 6 Tra_Id,Pin from pin  where Used_Flag=0 and Iss_Flag=0 and product_code=" + pro_code.ToString() + " order by Tra_Id").Fill(ds, "1");
        if (ds.Tables["1"].Rows.Count < 6)
        {
            GeneratePin(pro_code.ToString(), 6);
            goto l;
        }
        SQL_DB.GetDA("select Product_Amount,Product_Name from Product_master where Product_Code=" + pro_code.ToString()).Fill(ds, "Product");
        if (ds.Tables["Product"].Rows.Count == 0)
            return;
        double Pro_Amt = Convert.ToDouble(ds.Tables["Product"].Rows[0]["Product_Amount"].ToString());
        //----Fund Transaction Entry Table name - F_Transa_Tab--------------//
        Class1.SaveTransaction("PIN", "Admin",User_Id, Convert.ToDouble(6 * Pro_Amt), "" + 6 + " Pin Sale to " +User_Id + " [Product : " + ds.Tables["Product"].Rows[0]["Product_Name"].ToString() + " ]", "" + User_Id + " Pin Purchase From Admin [Product : " + ds.Tables["Product"].Rows[0]["Product_Name"].ToString() + " ]");
        //----End-------------//
        SQL_DB.ExecuteNonQuery("update Pin Set Auto=1,Transfer_Id='" + User_Id + "',Issue_To='" + User_Id + "',Iss_Flag=1 ,Issue_Date='" + DataProvider.LocalDateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "' where Tra_Id in (select top " + User_Id + " Tra_Id from pin  where Used_Flag=0 and Iss_Flag=0 and product_code=" + pro_code.ToString() + " order by Tra_Id )");     
     
   
    
    }
    public static void GeneratePin(string Code,int cnt)
    {
       
        Random R = new Random();
        int i = cnt;
        StringBuilder Qry = new StringBuilder();
        string d = "";
        int Tra_id = Convert.ToInt32(SQL_DB.ExecuteScalar("select isnull(max(Tra_id),1) from pin"));
        for (; i > 0; i--)
        {

        chk:
            try
            {
                string p = Tra_id.ToString() + R.Next().ToString();
                d = p.Substring(0, 10);
                // Response.Write("<script>alert('try')</script>");
            }
            catch
            {
                //  Response.Write("<script>alert('catch')</script>");
                goto chk;
            }
            //   Response.Write("<script>alert('for')</script>");
            Qry.Append("INSERT INTO [Pin] " +
                "([Pin] " +
                ",[product_code]) " +
               " VALUES " +
               " ('" + (Code + d.ToString()) + "'" +
                "," + Code + ");");
            Tra_id++;
        }
        SQL_DB.ExecuteNonQuery(Qry.ToString());
    }

    public static void SendWelComeLatter(string User_Id)
    {
        try
        {
            string responseFromServer = WelcomelatterProvider.GetWelcomelatterString(User_Id);
            string email = Convert.ToString(SQL_DB.ExecuteScalar("select e_mail from Registration where User_Id='" + User_Id + "'"));
            Class1.sendMail(server, userID, password, email, responseFromServer, "Welcome Latter");
        }
        catch { }

    }
}
public enum TransType
{
    Payout
    ,
    FundTransfer
        ,
    PinRequest
        ,
    Recharge
    ,
    FundRequest
        ,
    AddFundrequest
        ,
    DepositForPin
        ,
    PinPurchased
        ,
    NormalReward
    ,
    BonanzaReward
        ,
    CustomMessage
        ,
    PinUsed
        ,
    ReferralReward
        ,
    NewEntry
        , DepositTDS
}


