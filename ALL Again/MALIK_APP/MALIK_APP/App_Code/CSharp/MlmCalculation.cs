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
using System.Text;
using System.Collections; 
using System.Collections.Specialized;
using System.Globalization;
using System.Data.SqlClient;

/// <summary>
/// Summary description for MlmCalculation
/// </summary>
public class MlmCalculation
{
    public static string server = "smtp.squire.net";
    public static string User = "";
    public static string Password = "";
    private StringCollection AllLeftUsersID = new StringCollection();
    private StringCollection AllRightUsersID = new StringCollection();
    private DataTable GrowthIncome = new DataTable();
    private int LeftLegMember = 0;
    private int RightLegMember = 0;
    private int LeftRegLegMember = 0;
    private int RightRedLegMember = 0;
    private string Level_Id = "";
    int Second = 0;

    public MlmCalculation()
    {
        //
        // TODO: Add constructor logic here
        //        

    }
    public void CalculateAmount(DataTable Registration, DataView Pro_Master, DataView Cal_Data, DataView Detect_Master, DateTime Cal_Date, DataView Reward_Master)
    {
        DataView Reg_Data = Registration.DefaultView;
        DataTable dt = Reg_Data.ToTable(true, new string[] { "User_Id", "reg_date", "status", "act_date" });
        Cal_Date = DataProvider.LocalDateTime.Now;//Cal_Date.AddDays(15);     
        DataTable Code_Gen = new DataTable();
        SQL_DB.GetDA("select prefix,startwith from code_gen where key_col='Calculate'").Fill(Code_Gen);
        Int64 StartWith = 0;
        string PreFix = "";
        if (Code_Gen.Rows.Count > 0)
        {
            StartWith = Convert.ToInt64(Code_Gen.Rows[0]["startwith"].ToString());
            PreFix = Code_Gen.Rows[0]["prefix"].ToString();
        }
        DataSet ds = new DataSet();
        SQL_DB.GetDA("SELECT [Tra_Id],[User_Id],[Reward_Name],[Reward_Pair],[Status],[Reward_Type],[Remark],[IsBonanza] FROM [Reward_Trans]").Fill(ds, "Reward_Trans");
        SQL_DB.GetDA("SELECT [tbl_id],[Pair],[Offer_Name] FROM [Bonanza_Master]").Fill(ds, "Bonanza");
        SQL_DB.GetDA("SELECT  Medal, Pair,tbl_id FROM  Recog_Pins").Fill(ds, "Reco");
        SQL_DB.GetDA("SELECT [Tra_Id],[User_Id],[Rec_Id] FROM [Rec_Trans_Tab]").Fill(ds, "Rec_Trans");
        SQL_DB.GetDA("SELECT [User_Id], sum(isnull(BV,0)) as BV FROM [Sale_Tra] group by User_Id").Fill(ds, "SalesEntry");
        Reg_Data.RowFilter = "";
        DataView Reward_Trans = ds.Tables["Reward_Trans"].DefaultView;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (Convert.ToInt32(dt.Rows[i]["status"].ToString()) == 1)
            {
                Reg_Data.RowFilter = "";
                string User_Id = dt.Rows[i]["User_Id"].ToString();
                DateTime Date_Reg = Convert.ToDateTime(dt.Rows[i]["reg_date"].ToString());
                StartWith = StartProcess(User_Id, Reg_Data, Pro_Master, Cal_Data, Detect_Master, Cal_Date, Reward_Master, StartWith, PreFix, Date_Reg, Reward_Trans, ds.Tables["Bonanza"].DefaultView, ds.Tables["Reco"].DefaultView, ds.Tables["Rec_Trans"].DefaultView, Convert.ToDateTime(dt.Rows[i]["reg_date"].ToString()), ds.Tables["SalesEntry"].DefaultView);
            }
        }
        Level_Id = Level_Id + "-1";
        SQL_DB.ExecuteNonQuery("update Code_gen set startwith=" + StartWith + " where key_col='Calculate' ;");
        SQL_DB.ExecuteNonQuery("update Sale_Tra set IsPaid=1");
    }
    private Int64 StartProcess(string User_Id, DataView Reg_Data, DataView Pro_Master, DataView Cal_Data, DataView Detect_Master, DateTime Cal_Date, DataView Reward_Master, Int64 StartWith, string PreFix, DateTime Date_Reg, DataView Reward_Trans, DataView Bonanza, DataView Reco, DataView Rec_Tra, DateTime act_date, DataView SalesEntry)
    {
        //reg_date act like Reg_Date

        AllLeftUsersID.Clear();
        AllRightUsersID.Clear();
        LeftLegMember = 0;
        RightLegMember = 0;
        LeftRegLegMember = 0;
        RightRedLegMember = 0;
        // get count method also fill  all user id in left and all userid in right in AllUsersIDLeft AllUsersIDRight respectivaly
        if (User_Id == "E-Bazar")
        {
            string g = "";
        }
        int LeftDtl = GetCountUser(User_Id, "Left");
        int Tot_Left_User = LeftDtl;
        //max achive level in left        
        LeftDtl = GetCountUser(User_Id, "Right");
        int Tot_Right_User = LeftDtl;
        //max level od right        
        int LeftUserAll = Tot_Left_User;//GetCountUserForBinary(User_Id, "Left", Reg_Data, Detect_Master);
        int RightUserAll = Tot_Right_User;// GetCountUserForBinary(User_Id, "Right", Reg_Data, Detect_Master);


        int OldLeftChild = GetOldLeftChild(User_Id, Cal_Data);
        int OldRightChild = GetOldRightChild(User_Id, Cal_Data);

        /* Check point Value */


        int Tot_Pair_TillDate = (int)GetTotalPair(LeftUserAll, RightUserAll);

        // check bonanza offer available or not
        bool IsBonanza = GetBonanzaOfferId(Pro_Master);
        string BonanzaID = "";
        if (IsBonanza)
        {
            // calculate bonanza offer, Parameter 1 use for Bonanza pair
            double BonanzaPair = GetPairForReward(User_Id, Reg_Data, Pro_Master, 1);
            BonanzaID = GetBonanzaRewardID(Convert.ToInt32(BonanzaPair), User_Id, Bonanza, Reward_Trans);
        }
        // check reward for member 0 for simple reward
        int SmplRwPair = (int)GetPairForReward(User_Id, Reg_Data, Pro_Master, 0);
        string RewardId = "";
        RewardId = GetRewardID(SmplRwPair, Cal_Data, User_Id, Reward_Master, Reward_Trans);

        int LeftChildCurr = LeftUserAll - OldLeftChild;
        int RightChildCurr = RightUserAll - OldRightChild;

        //
        //
        //LeftChildCurr += oldForwordLeft;
        //RightChildCurr += oldForwordRight; 
        double LeftPointValue = GetPointValue(User_Id, Reg_Data, AllLeftUsersID, Pro_Master, Convert.ToDouble(Detect_Master.ToTable().Rows[0]["Join_BV"]), Convert.ToDouble(Detect_Master.ToTable().Rows[0]["Network_per"]), SalesEntry);
        double RightPointValue = GetPointValue(User_Id, Reg_Data, AllRightUsersID, Pro_Master, Convert.ToDouble(Detect_Master.ToTable().Rows[0]["Join_BV"]), Convert.ToDouble(Detect_Master.ToTable().Rows[0]["Network_per"]), SalesEntry);

        double OldLeftPoint = GetOldPoint(User_Id, Cal_Data, "Left_Pv");
        double OldRightPoint = GetOldPoint(User_Id, Cal_Data, "Right_Pv");

        double LeftCurrPoint = LeftPointValue - OldLeftPoint;
        double RightCurrPoint = RightPointValue - OldRightPoint;

        double oldForwordLeftPoint = GetForwordedChild(Cal_Data, User_Id, "Forword_Left");
        double oldForwordRightPoint = GetForwordedChild(Cal_Data, User_Id, "Forword_Right");

        double TotLeftPoint = LeftCurrPoint + oldForwordLeftPoint;
        double TotRightPoint = RightCurrPoint + oldForwordRightPoint;

        double PairCurr = 0, OwnPoint = 0;
        // check 2:1 or 1:2 for pairing
        int IsFirst = CheckFirsyTime(Reg_Data, User_Id);
        if (IsFirst == 0)
        {
            if (TotLeftPoint > TotRightPoint)
            {
                if (TotLeftPoint >= Convert.ToDouble(Detect_Master.ToTable().Rows[0]["Join_BV"]) * 2 && TotRightPoint >= Convert.ToDouble(Detect_Master.ToTable().Rows[0]["Join_BV"]))
                {
                    PairCurr = GetTotalPair(TotLeftPoint - Convert.ToDouble(Detect_Master.ToTable().Rows[0]["Join_BV"]), TotRightPoint);
                    if (PairCurr > 0)
                        SQL_DB.ExecuteNonQuery("update Registration Set IsFirst=1 where User_Id='" + User_Id + "'");
                    //IsFirst = 1;  
                    // for own work
                    OwnPoint += GetOwnPV(User_Id, Reg_Data, Pro_Master, Convert.ToDouble(Detect_Master.ToTable().Rows[0]["Self_Per"]));
                }
            }
            else
            {
                if (TotLeftPoint >= Convert.ToDouble(Detect_Master.ToTable().Rows[0]["Join_BV"]) && TotRightPoint > Convert.ToDouble(Detect_Master.ToTable().Rows[0]["Join_BV"]) * 2)
                {

                    PairCurr = GetTotalPair(TotLeftPoint, TotRightPoint - Convert.ToDouble(Detect_Master.ToTable().Rows[0]["Join_BV"]));
                    if (PairCurr > 0)
                        SQL_DB.ExecuteNonQuery("update Registration Set IsFirst=2 where User_Id='" + User_Id + "'");
                    //IsFirst = 2;
                    // for own work
                    OwnPoint += GetOwnPV(User_Id, Reg_Data, Pro_Master, Convert.ToDouble(Detect_Master.ToTable().Rows[0]["Self_Per"]));
                }

            }
        }
        else
        {
            if (IsFirst == 1)
                PairCurr = GetTotalPair(TotLeftPoint - Convert.ToDouble(Detect_Master.ToTable().Rows[0]["Join_BV"]), TotRightPoint);
            else if (IsFirst == 2)
                PairCurr = GetTotalPair(TotLeftPoint, TotRightPoint - Convert.ToDouble(Detect_Master.ToTable().Rows[0]["Join_BV"]));
           
        }
        double IndirectRefAmount = 0;
        //check member have two referral if two referral exist then binary will be given else no binary will calculate
        string[] ReferUser = ChackTwoReferral(User_Id);
        if ((ReferUser[0] != null || ReferUser[0] != "") && (ReferUser[1] != null || ReferUser[1] != ""))
        {
            string[] LeftIndirect = ChackTwoReferral(ReferUser[0]);
            string[] RightIndirect = ChackTwoReferral(ReferUser[1]);
            if (((LeftIndirect[0] != "") && ( LeftIndirect[1] != "")) )
            {
               
                    Reg_Data.RowFilter = "IsPayIndReferal=0 and user_id in ('" + LeftIndirect[0] + "','" + LeftIndirect[1] + "')";
                    var row = from reg in Reg_Data.ToTable().AsEnumerable()
                              join dt in Pro_Master.ToTable().AsEnumerable() on Convert.ToInt32(reg["Product_Code"]) equals Convert.ToInt32(dt["Product_Code"])
                              select new
                              {
                                  Amount = Convert.ToDouble(dt["IndirectRef"])
                              };

                    foreach (var r in row)
                        IndirectRefAmount += r.Amount;
                    SQL_DB.ExecuteNonQuery("update Registration set IsPayIndReferal=1 where user_id in ('" + LeftIndirect[0] + "','" + LeftIndirect[1] + "')");
                
            }
            if (((RightIndirect[0] != "") && (RightIndirect[1] != "")))
            {
                Reg_Data.RowFilter = "IsPayIndReferal=0 and user_id in ('" + RightIndirect[0] + "','" + RightIndirect[1] + "')";
                var row = from reg in Reg_Data.ToTable().AsEnumerable()
                          join dt in Pro_Master.ToTable().AsEnumerable() on Convert.ToInt32(reg["Product_Code"]) equals Convert.ToInt32(dt["Product_Code"])
                          select new
                          {
                              Amount = Convert.ToDouble(dt["IndirectRef"])
                          };

                foreach (var r in row)
                    IndirectRefAmount += r.Amount;
                SQL_DB.ExecuteNonQuery("update Registration set IsPayIndReferal=1 where user_id in ('" + RightIndirect[0] + "','" + RightIndirect[1] + "')");
        
            }
        }
        else
        {
            // Pair of all Green Member           
            PairCurr = 0;//GetTotalPair(LeftChildCurr - LeftRedUser, RightChildCurr - RightRedUser);
        }
        Reg_Data.RowFilter = "";
        double Forword_Left = TotLeftPoint - PairCurr;
        double Forword_Right = TotRightPoint - PairCurr;
        PairCurr += OwnPoint;
        int OldPair = GetOldTotPair(User_Id, Cal_Data);
        // Recognization  calculation
        if (OldPair + PairCurr > 0)
        {
            #region calculate recognition
            int? Recog_Id;
            Recog_Id = CalculateRecogntion(User_Id, Rec_Tra, Reco, OldPair + PairCurr);

            if (Recog_Id != 0)
            {
                //int tbl_id = 0;
                //if (Rec_Tra.ToTable().Rows.Count == 0)
                //    tbl_id = 1;
                //else
                //    tbl_id = Convert.ToInt32(Rec_Tra.ToTable().Rows[0]["tbl_id"].ToString()) + 1;
                //Rec_Tra.Sort = "Tra_Id desc";
                //DataRowView NewRow = Rec_Tra.AddNew();
                //NewRow["tbl_id"] = tbl_id;
                //NewRow["User_Id"] = User_Id;
                //NewRow["Rec_Id"] = Recog_Id;
                //NewRow.EndEdit();
                //Rec_Tra.Sort = "";
                SQL_DB.ExecuteNonQuery("INSERT INTO [Rec_Trans_Tab] " +
              " ([User_Id]" +
              " ,[Rec_Id]" +
              " ,[Cal_Date])" +
         "VALUES " +
               "('" + User_Id + "'" +
               "," + Recog_Id +
               ",'" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "')");

            }
            #endregion

            Rec_Tra.RowFilter = "";
            Reco.RowFilter = "";
        }
        double Laps_Pair = 0;
        // leps Pair if Max_pair
        DataRowCollection Row = Detect_Master.ToTable().Rows;

        if (Convert.ToInt32(Row[0]["Max_Pair"].ToString()) < PairCurr)
        {
            Laps_Pair = PairCurr - Convert.ToInt32(Row[0]["Max_Pair"].ToString());
            PairCurr = Convert.ToInt32(Row[0]["Max_Pair"].ToString());
        }
        // additional income start
        double OldVal = 0, SalesBV = 0;
          if (SalesEntry.ToTable().Rows.Count > 0)
          {
              Cal_Data.RowFilter = "User_Id='" + User_Id + "'";
              DataRowCollection Rw = Cal_Data.ToTable().Rows;
              OldVal = Sum(Rw, "Additional_Pv");
              SalesEntry.RowFilter = "User_Id='" + User_Id + "'";
              Rw = SalesEntry.ToTable().Rows;
              OldVal = Sum(Rw, "BV") - OldVal;
              Cal_Data.RowFilter = "";
              // 60 % on self joining
              SalesBV = OldVal;
              OldVal = (OldVal * Convert.ToInt32(Row[0]["Self_Per"].ToString())) / 100;
          }
        // end 

          double Pair_Income = GetBinaryIncome(PairCurr + OldVal, OldPair, Detect_Master);
        double ReferalIncome = GetReferalIncome(User_Id, Reg_Data, Pro_Master, act_date);
        // commented by tauseef
        //double Total_Income = Pair_Income + ReferalIncome + Single_Leg_Income[0] + Single_Leg_Income[1] + GrowthAmount;
        //tauseef
        double LeaderShipIncome = 0;
        #region LeaderShipBonus
        string RefUsers = GetReferral(User_Id, Reg_Data, Cal_Date);
        LeaderShipIncome = Convert.ToDouble(SQL_DB.ExecuteScalar("select isnull(sum(BV_Amount),0) from Cal_Payment_Tab where User_Id in('" + RefUsers + "') and Cal_Date>='" + Cal_Date.ToString("MM/dd/yyyy") + "' "));
        LeaderShipIncome = (LeaderShipIncome * Convert.ToDouble(Row[0]["LeaderShip"])) / 100;
        Reg_Data.RowFilter = "";
        Cal_Data.RowFilter = "";
        #endregion

        string TransId = (PreFix + StartWith.ToString());

        double Total_Income = Pair_Income + ReferalIncome + LeaderShipIncome; 

        //tauseef
        double Final_Amount = Total_Income;
        double Leader_Deduct = (Final_Amount * Convert.ToDouble(Row[0]["LeaderShip"])) / 100;
        Final_Amount = Final_Amount - Leader_Deduct;
        double TDS = Convert.ToDouble(Row[0]["TDS"].ToString());
        // TDS DEDUCTION 20 % FOR THAT PERSION WHO DOES NOT HAVE PAN CARD
        Reg_Data.RowFilter = "user_id='" + User_Id + "'";
        string tds_chk = "";
        if (Reg_Data.ToTable().Rows.Count > 0)
            tds_chk = Reg_Data.ToTable().Rows[0]["pan_no"].ToString();
        if (tds_chk == "" || tds_chk.Length < 10)
            TDS = 20;
        Reg_Data.RowFilter = "";
        double Temp_TDS = TDS;
        double Admin = Convert.ToDouble(Row[0]["Admin_Charge"].ToString());
        double Temp_Admin = Admin;
        double Welfair = Convert.ToDouble(Row[0]["Welfair"].ToString());
        Admin = (Final_Amount * Admin) / 100;
        Final_Amount -= Admin;
        Welfair = (Final_Amount * Welfair) / 100;
        Final_Amount -= Welfair;
        TDS = (Final_Amount * TDS) / 100;
        Final_Amount -= TDS;

        string Qry = "INSERT INTO [Cal_Payment_Tab]" +
           " ([User_Id]" +
          " ,ID" +
          " ,[Left_Child]" +
           ",[Right_Child]" +
           ",[Left_Child_Current_Date]" +
           ",[Right_Child_Current_Date]" +
           ",[Left_Pv]" +
           ",[Right_Pv]" +
           ",[Paired_Current_Date]" +
           ",[Leps_Bv_Current_Date]" +
           ",[BV_Amount]" +
           ",[Admin]" +
           ",[TDS]" +
           ",[WelFair]" +
           ",[Final_Amount]" +
           ",[Entry_Date]" +
           ",[Cal_Date],[Referal_amt],[Binary_Amt],[Tot_Left_User],[Tot_Right_User],[TDS_Per],[Admin_Per],[Forword_Left],[Forword_Right],[Indirect_amt],[Additional_Pv],[Leader_ship],[Leader_Deduct] )" +
     " VALUES " +
       "    ('" + User_Id + "'" +
       "   ,'" + (PreFix + StartWith.ToString()) + "'" +
        "   ," + LeftUserAll +
         "  ," + RightUserAll +
          " ," + LeftChildCurr +
           "," + RightChildCurr +
           "," + LeftCurrPoint +
           "," + RightCurrPoint +
           "," + PairCurr +
           "," + Laps_Pair +
           "," + Total_Income +
           "," + Admin +
           "," + TDS +
           "," + Welfair +
           "," + Final_Amount +
           ",'" + DataProvider.LocalDateTime.Now.ToString("MM/dd/yy H:mm:ss") + "'" +
           ",'" + Cal_Date.ToString("MM/dd/yy H:mm:ss") + "'," + ReferalIncome + "," + Pair_Income + "," + Tot_Left_User + "," + Tot_Right_User + "," + Temp_TDS + "," + Temp_Admin + "," + Forword_Left + "," + Forword_Right + "," + IndirectRefAmount + "," + SalesBV + "," + LeaderShipIncome + ","+Leader_Deduct+")";
        string Trans_Entry = ";";
        /*if (Final_Amount != 0)
        {
            Trans_Entry = " ; INSERT INTO [F_Transa_Tab] " +
                  "([Tra_ID]" +
                  ",[User_Id]" +
                  ",[Tra_Date]" +
                  ",[Tra_Name]" +
                  ",[Cr_Amt]" +
                  ",[Dr_Amt]" +
                  ",[Remarks])" +
            " VALUES " +
                  " ('" + (PreFix + StartWith.ToString()) + "'" +
                  ",'" + User_Id + "'" +
                  ",'" + DataProvider.LocalDateTime.Now + "'" +
                  ",'" + TransType.Payout + "'" +
                  "," + Final_Amount + "" +
                  ",0 " +
                  ",'Payment Calculated')";
        }*/
        Trans_Entry = Trans_Entry + ";; Update Registration Set Tot_Pair=" + Tot_Pair_TillDate + " where User_Id='" + User_Id + "'";

        if (RewardId.Length > 0)
        {
            string[] Reward = RewardId.Split(',');
            string RewardQry = "";
            for (int cnt = 0; cnt < Reward.Length; cnt++)
            {
                Reward_Master.RowFilter = "id=" + Reward[cnt];
                DataRowCollection RewRow = Reward_Master.ToTable().Rows;
                if (RewRow.Count == 0)
                    continue;
                RewardQry = RewardQry + " ;INSERT INTO [Reward_Trans] " +
                   "([Tra_Id]" +
                   ",[User_Id]" +
                   ",[Reward_Date]" +
                   ",[Reward_Name]" +
                   ",[Reward_Pair]" +
                   ",[Reward_Type]" +
                   ",[Status])" +
             "VALUES " +
                  " ('" + TransId + "'" +
                  " ,'" + User_Id + "'" +
                  " ,'" + DataProvider.LocalDateTime.Now.ToString("MM/dd/yy H:mm:ss") + "'" +
                  " ,'" + RewRow[0]["rewards"].ToString() + "'" +
                  " ," + RewRow[0]["pairs"].ToString() +
                  " ,'" + TransType.NormalReward + "'" +
                  " ,0)";

            }

            SQL_DB.ExecuteNonQuery(RewardQry);
        }
        if (BonanzaID.Length > 0)
        {
            string[] Reward = BonanzaID.Split(',');
            string RewardQry = "";
            for (int cnt = 0; cnt < Reward.Length; cnt++)
            {
                Bonanza.RowFilter = "tbl_id=" + Reward[cnt];
                DataRowCollection RewRow = Bonanza.ToTable().Rows;
                if (RewRow.Count == 0)
                    continue;
                RewardQry = RewardQry + " ;INSERT INTO [Reward_Trans] " +
                   "([Tra_Id]" +
                   ",[User_Id]" +
                   ",[Reward_Date]" +
                   ",[Reward_Name]" +
                   ",[Reward_Pair]" +
                   ",[Reward_Type]" +
                   ",[IsBonanza]" +
                   ",[Status])" +
             "VALUES " +
                  " ('" + TransId + "'" +
                  " ,'" + User_Id + "'" +
                  " ,'" + DataProvider.LocalDateTime.Now.ToString("MM/dd/yy H:mm:ss") + "'" +
                  " ,'" + RewRow[0]["Offer_Name"].ToString() + "'" +
                  " ," + RewRow[0]["pair"].ToString() +
                  " ,'" + TransType.BonanzaReward + "'" +
                  " ,1" +
                  " ,0)";

            }
            SQL_DB.ExecuteNonQuery(RewardQry);
        }

        SQL_DB.ExecuteNonQuery(Qry + Trans_Entry);
        StartWith += 1;
        return StartWith;
    }
    private string GetReferral(string User_Id, DataView Reg_Data, DateTime Cal_Date)
    {
        Reg_Data.RowFilter = "Parent_Id='" + User_Id + "' and Reg_Date<='" + Cal_Date.ToString("dd/MM/yyyy") + "'";
        DataRowCollection Row = Reg_Data.ToTable(true, "User_Id").Rows;
        string usersid = "";
        for (int i = 0; i < Row.Count; i++)
            usersid = usersid + Row[i]["User_Id"].ToString() + "','";
        if (usersid.Length > 0)
            usersid = usersid.Substring(0, usersid.Length - 3);
        return usersid;
    }
    private double GetOwnPV(string User_Id, DataView Reg_Data, DataView Pro_Master, double p)
    {
        var row = from dt in Reg_Data.ToTable(false, "User_Id", "Product_Code", "status").AsEnumerable()
                  join Pro in Pro_Master.ToTable().AsEnumerable() on Convert.ToInt32(dt["Product_Code"]) equals Convert.ToInt32(Pro["Product_Code"])
                  where Convert.ToString(dt["User_Id"]) == User_Id && Convert.ToInt32(dt["status"]) == 1
                  select new
                  {
                      Point_Value = Convert.ToDouble(Pro["PV"])
                  };
        double PV = 0;
        foreach (var r in row)
        {
            PV += (r.Point_Value * p / 100);
        }
        return PV;
    }


    private double GetReferralPoint(string User_Id, string Pose)
    {
        return Convert.ToDouble(SQL_DB.ExecuteScalar("SELECT   isnull(sum(Product_master.PV),0) FROM Registration INNER JOIN   Product_master ON Registration.product_code = Product_master.Product_Code where Registration.status=1 and  Registration.User_id in(select * from getChildUser('" + User_Id + "','" + Pose + "')) and  Registration.Parent_Id='" + User_Id + "'"));
    }

    private double GetPointValue(string User_Id, DataView Reg_Data, StringCollection AllUsersID, DataView Pro_Master, double joinPV, double Network_per,DataView Additional_Sale)
    {
        var row = from dt in Reg_Data.ToTable(false, "User_Id", "Product_Code", "status").AsEnumerable()
                  join Pro in Pro_Master.ToTable().AsEnumerable() on Convert.ToInt32(dt["Product_Code"]) equals Convert.ToInt32(Pro["Product_Code"])
                  where AllUsersID.Contains(Convert.ToString(dt["User_Id"])) && Convert.ToInt32(dt["status"]) == 1
                  select new
                  {
                      Point_Value = Convert.ToDouble(Pro["PV"])
                  };
        double PV = 0;
        foreach (var r in row)
        {
            //double Value = r.Point_Value - joinPV;
            //PV += joinPV + (Value * Network_per / 100);
            PV += r.Point_Value;
        }
      

        // for additional sales
        row = from dt in Reg_Data.ToTable(false, "User_Id","status").AsEnumerable()
              join Sale in Additional_Sale.ToTable().AsEnumerable() on Convert.ToString(dt["User_Id"]) equals Convert.ToString(Sale["User_Id"])
              where AllUsersID.Contains(Convert.ToString(dt["User_Id"])) && Convert.ToInt32(dt["status"]) == 1
              select new
              {
                  Point_Value = Convert.ToDouble(Sale["BV"])
              };
        double Add_Pv = 0;
        foreach (var r in row)
        {
            Add_Pv += r.Point_Value;
        }
        Add_Pv = (Add_Pv * Network_per) / 100;
        return PV + Add_Pv; 

    }
    private string[] ChackTwoReferral(string User_Id)
    {
        string left = Convert.ToString(SQL_DB.ExecuteScalar("select User_Id from Registration where user_id in (select * from getChildUser('" + User_Id + "','Left')) and Parent_id='" + User_Id + "' and status=1 order by id desc"));
        string right = Convert.ToString(SQL_DB.ExecuteScalar("select User_Id from Registration where user_id in (select * from getChildUser('" + User_Id + "','Right')) and Parent_id='" + User_Id + "'  and status=1 order by id desc"));
        string[] arr = new string[2];
        arr[0] = left;
        arr[1] = right;
        return arr;
    }

    private int GetAllPaid(string User_Id, DataView Cal_Data, string Col)
    {
        Cal_Data.RowFilter = "User_Id='" + User_Id + "'";
        return Convert.ToInt32(Sum(Cal_Data.ToTable().Rows, Col));
    }
    private double GetPairForReward(string User_Id, DataView Reg_Data, DataView Pro_Master, int IsBonanza)
    {
        Reg_Data.RowFilter = "";
        Pro_Master.RowFilter = "";
        double cnt = 0;
        //for left users
        var row = from Reg in Reg_Data.ToTable().AsEnumerable()
                  join Pro in Pro_Master.ToTable().AsEnumerable() on Reg["product_code"] equals Pro["Product_Code"]
                  where Convert.ToInt32(Pro["IsBonanza"].ToString()) == IsBonanza && AllLeftUsersID.Contains(Reg["User_Id"].ToString().Trim()) && Convert.ToInt32(Reg["status"]) == 1
                  select new
                  {
                      Point = Convert.ToDouble(Pro["PV"])

                  };
        foreach (var item in row)
            cnt += item.Point;
        //for right users
        row = from Reg in Reg_Data.ToTable().AsEnumerable()
              join Pro in Pro_Master.ToTable().AsEnumerable() on Reg["product_code"] equals Pro["Product_Code"]
              where Convert.ToInt32(Pro["IsBonanza"].ToString()) == IsBonanza && AllRightUsersID.Contains(Reg["User_Id"].ToString().Trim()) && Convert.ToInt32(Reg["status"]) == 1
              select new
              {
                  Point = Convert.ToDouble(Pro["PV"])

              };
        double RightCnt = 0;
        foreach (var item in row)
            RightCnt += item.Point;
        if (cnt < RightCnt)
            return cnt;
        else
            return RightCnt;

    }
    private double GetTotEarnTillDate(string User_Id, DataView Cal_Data)
    {
        Cal_Data.RowFilter = "User_Id='" + User_Id + "'";
        return Sum(Cal_Data.ToTable().Rows, "Bv_Amount");
    }
    private int CheckFirsyTime(DataView dt, string User_Id)
    {
        dt.RowFilter = "User_Id='" + User_Id + "'";
        DataRowCollection Row = dt.ToTable().Rows;
        if (Row.Count == 0)
            return 0;
        else
            return Convert.ToInt32(Row[0]["IsFirst"].ToString());
    }
    private double GetForwordedChild(DataView dt, string User_Id, string Forword)
    {
        dt.RowFilter = "User_Id='" + User_Id + "'";
        dt.Sort = "tbl_id";
        DataRowCollection Row = dt.ToTable().Rows;
        if (Row.Count == 0)
            return 0;
        return Convert.ToDouble(Row[Row.Count - 1][Forword].ToString());
    }
    private double GetTotalPair(double LeftUserAll, double RightUserAll)
    {
        if (LeftUserAll > RightUserAll)
            return Math.Floor(RightUserAll);
        else if (LeftUserAll < RightUserAll)
            return Math.Floor(LeftUserAll);
        else
            return Math.Floor(LeftUserAll);
    }
    private int GetOldLeftChild(string User_Id, DataView Cal_Data)
    {
        Cal_Data.RowFilter = "User_Id='" + User_Id + "'";
        DataRowCollection Row = Cal_Data.ToTable().Rows;
        double d = Sum(Row, "Left_Child_Current_Date");
        return Convert.ToInt32(d);
    }
    private double GetOldPoint(string User_Id, DataView Cal_Data, string Col_Name)
    {
        Cal_Data.RowFilter = "User_Id='" + User_Id + "'";
        DataRowCollection Row = Cal_Data.ToTable().Rows;
        double d = Sum(Row, Col_Name);
        return d;
    }
    private int GetOldRightChild(string User_Id, DataView Cal_Data)
    {
        Cal_Data.RowFilter = "User_Id='" + User_Id + "'";
        DataRowCollection Row = Cal_Data.ToTable().Rows;
        double d = Sum(Row, "Right_Child_Current_Date");
        return Convert.ToInt32(d);
    }
    private int GetCountUser(string User_Id, string Pos)
    {

        DataSet ds = new DataSet();
        SQL_DB.GetDA("Select user_id,status from Registration where user_id in (select * from getChildUser('" + User_Id + "','" + Pos + "')) ").Fill(ds, "1");
        if (Pos.ToUpper().Trim() == "LEFT")
            for (int i = 0; i < ds.Tables["1"].Rows.Count; i++)
                AllLeftUsersID.Add(ds.Tables["1"].Rows[i]["User_Id"].ToString().Trim());
        if (Pos.ToUpper().Trim() == "RIGHT")
            for (int i = 0; i < ds.Tables["1"].Rows.Count; i++)
                AllRightUsersID.Add(ds.Tables["1"].Rows[i]["User_Id"].ToString().Trim());
        return ds.Tables["1"].Rows.Count;

    }

    private double Sum(DataRowCollection Row, string ColName)
    {
        double Total = 0;
        for (int i = 0; i < Row.Count; i++)
            Total += Convert.ToDouble(Row[i][ColName].ToString());
        return Total;
    }
    private double GetReferalIncome(string User_Id, DataView Reg_Data, DataView Pro_Master, DateTime act_date)
    {
        Reg_Data.RowFilter = "Parent_id='" + User_Id + "' and IsPayReferal=0  and status=1";
        DataTable dt = Reg_Data.ToTable();
        var Row = from dt1 in dt.AsEnumerable()
                  join dt2 in Pro_Master.ToTable().AsEnumerable() on (int)dt1["Product_Code"] equals (int)dt2["product_code"]
                  where (DateTime)dt1["act_date"] >= act_date && Convert.ToInt32(dt1["status"]) == 1
                  select new
                  {
                      UserID = dt1["User_Id"].ToString(),
                      Business_Value = dt2["Business_Value"].ToString()

                  };
        double BV = 0;
        StringBuilder str = new StringBuilder();
        foreach (var r in Row)
        {
            BV = BV + Convert.ToDouble(r.Business_Value);
            str = str.Append("'" + r.UserID + "',");
        }
        string Users = "";
        if (str.ToString().Length > 0)
        {
            Users = str.ToString().Substring(0, str.ToString().Length - 1);
            SQL_DB.ExecuteNonQuery("Update Registration set IsPayReferal=1 where User_Id in (" + Users + ") ");
        }
        return BV;
    }
    private int GetOldTotPair(string User_Id, DataView Cal_Data)
    {
        Cal_Data.RowFilter = "User_Id='" + User_Id + "'";
        DataRowCollection Row = Cal_Data.ToTable(false, new string[] { "Paired_Current_Date" }).Rows;
        return (int)Sum(Row, "Paired_Current_Date");
    }
    private double GetBinaryIncome(double NewPair, double OldPair, DataView Deduct_Master)
    {
        if (NewPair == 0 || (NewPair + OldPair) <= 0) return 0;
        // multiply 10 % of new point value
        return Convert.ToDouble(Deduct_Master.ToTable().Rows[0]["PV_Amount"].ToString()) * ((NewPair * 10) / 100);
    }
    private string GetRewardID(int New_Pair, DataView Cal_Amount, string User_Id, DataView Reward_Master, DataView Reward_Trans)
    {
        // New Pair variable contain Total pair Till date
        Reward_Trans.RowFilter = "User_Id='" + User_Id + "' and Status<>-1 and IsBonanza=0";
        DataRowCollection Rwrd_colle = Reward_Trans.ToTable().Rows;
        int PairReceived = Convert.ToInt32(Sum(Rwrd_colle, "Reward_Pair"));
        New_Pair = New_Pair - PairReceived;
        // if canceled by user that reward will not be taken next time 
        Reward_Trans.RowFilter = "User_Id='" + User_Id + "' and IsBonanza=0";
        Rwrd_colle = Reward_Trans.ToTable().Rows;
        StringBuilder PreRwrdName = new StringBuilder();
        for (int i = 0; i < Rwrd_colle.Count; i++)
            PreRwrdName.Append("'" + Rwrd_colle[i]["Reward_Name"].ToString() + "',");
        if (PreRwrdName.ToString().Length > 0)
            PreRwrdName.ToString().Remove(PreRwrdName.ToString().Length - 1, 1);
        else
            PreRwrdName.Append("''");
        string RewardId = "";
        Reward_Master.RowFilter = "rewards not in (" + PreRwrdName.ToString() + ")";
        Reward_Master.Sort = "pairs";
        DataRowCollection Row = Reward_Master.ToTable().Rows;
        RewardId = "";
        for (int i = 0; i < Row.Count; i++)
        {
            int idd = Convert.ToInt32(Row[i]["id"].ToString());
            int pair = Convert.ToInt32(Row[i]["pairs"].ToString());
            if (pair <= New_Pair)
            {
                RewardId = RewardId + Row[i]["id"].ToString() + ",";
                New_Pair -= pair;
            }
        }
        if (RewardId.Length > 0)
            RewardId = RewardId.Remove(RewardId.Length - 1, 1);
        return RewardId;

        // save reward transaction
    }

    private double[] GetSingleLegIncome(int AllInLeft, int AllInright, int LeftMemToday, int RightMemToday, DataView Deduct_Master, DateTime Date_Reg)
    {
        double[] Amount = { 0, 0 };

        TimeSpan t = DataProvider.LocalDateTime.Now.Subtract(Date_Reg);
        if (t.Days > Convert.ToInt32(Deduct_Master.ToTable().Rows[0]["Leg_Days"].ToString()))
            return Amount;
        if ((AllInLeft + AllInright) > Convert.ToInt32(Deduct_Master.ToTable().Rows[0]["Leg_Max_Member"].ToString()) || LeftMemToday > Convert.ToInt32(Deduct_Master.ToTable().Rows[0]["Leg_Max_Member"].ToString()))
            return Amount;
        Amount[0] = Convert.ToInt32(Deduct_Master.ToTable().Rows[0]["Leg_Pay"].ToString()) * LeftMemToday;
        Amount[1] = Convert.ToInt32(Deduct_Master.ToTable().Rows[0]["Leg_Pay"].ToString()) * RightMemToday;
        return Amount;
    }
    private bool IsBonanza(DateTime Cal_Date, DataView Bonanza)
    {
        Bonanza.RowFilter = "DateFrom>='" + Cal_Date.ToString("MM/dd/yyyy") + "'";
        if (Bonanza.ToTable().Rows.Count > 0)
            return true;
        else
            return false;
    }
    private bool GetBonanzaOfferId(DataView Pro_Master)
    {
        DataTable dt1 = new DataTable();
        Pro_Master.RowFilter = "IsBonanza=1";
        dt1 = Pro_Master.ToTable();
        int cnt = 0;
        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            DateTime dat = Convert.ToDateTime(dt1.Rows[i]["End_Date"].ToString());
            TimeSpan spn = dat.Subtract(DataProvider.LocalDateTime.Now);
            if (spn.Days > 0)
                cnt++;
            if (cnt > 0)
                return true;
        }
        return false;
    }
    private string GetBonanzaRewardID(int New_Pair, string User_Id, DataView Reward_Master, DataView Reward_Trans)
    {
        // New Pair variable contain Total pair Till date
        Reward_Trans.RowFilter = "User_Id='" + User_Id + "' and Status<>-1 and IsBonanza=1";
        DataRowCollection Rwrd_colle = Reward_Trans.ToTable().Rows;
        int PairReceived = Convert.ToInt32(Sum(Rwrd_colle, "Reward_Pair"));
        New_Pair = New_Pair - PairReceived;
        // if canceled by user that reward will not be taken next time 
        Reward_Trans.RowFilter = "User_Id='" + User_Id + "' and IsBonanza=1";
        Rwrd_colle = Reward_Trans.ToTable().Rows;
        StringBuilder PreRwrdName = new StringBuilder();
        for (int i = 0; i < Rwrd_colle.Count; i++)
            PreRwrdName.Append("'" + Rwrd_colle[i]["Reward_Name"].ToString() + "',");
        if (PreRwrdName.ToString().Length > 0)
            PreRwrdName.ToString().Remove(PreRwrdName.ToString().Length - 1, 1);
        else
            PreRwrdName.Append("''");
        string RewardId = "";
        Reward_Master.RowFilter = "Offer_Name not in (" + PreRwrdName.ToString() + ")";
        Reward_Master.Sort = "pair";
        DataRowCollection Row = Reward_Master.ToTable().Rows;
        RewardId = "";
        for (int i = 0; i < Row.Count; i++)
        {
            int idd = Convert.ToInt32(Row[i]["tbl_id"].ToString());
            int pair = Convert.ToInt32(Row[i]["pair"].ToString());
            if (pair <= New_Pair)
            {
                RewardId = RewardId + Row[i]["tbl_id"].ToString() + ",";
                New_Pair -= pair;
            }
        }
        if (RewardId.Length > 0)
            RewardId = RewardId.Remove(RewardId.Length - 1, 1);
        return RewardId;

        // save reward transaction
    }
    // designation calculation
    #region Calculate Designation

    private int CalculateRecogntion(string User_Id, DataView Rec_Tra, DataView RecoMaster, double Tot_Pair)
    {
        StringBuilder str = new StringBuilder();
        DataRow[] RowCol = Rec_Tra.ToTable().Select("User_Id='" + User_Id + "'");
        foreach (DataRow Row in RowCol)
            str.Append(Row["Rec_id"].ToString() + ",");
        str.Append("0");
        RecoMaster.RowFilter = "Pair<=" + Tot_Pair + " and tbl_id Not In (" + str.ToString() + ")";
        RecoMaster.Sort = "tbl_id";
        DataRowCollection RowR = RecoMaster.ToTable(false, "tbl_id").Rows;
        if (RowR.Count == 0)
            return 0;
        else
            return Convert.ToInt32(RowR[RowR.Count - 1]["tbl_id"]);
    }

    #endregion

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



}
