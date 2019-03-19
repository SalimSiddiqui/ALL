using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

public partial class FrmTravel_Detail : System.Web.UI.Page
{
    public string Image = "", flightname = "", city = "", Remark = "", price = "", purpose = "", Overview = "";
    public StringBuilder ShowDate = new StringBuilder();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        News();
        PropertyDetails();
        if (!IsPostBack)
        {

        }
    }
    private void PropertyDetails()
    {
        int id = Convert.ToInt32(Request.QueryString["uid"].ToString());
        DataSet Ds = new DataSet();
        string Qry = "SELECT  [Row_Id],Img_Title,Substring([Remarks],0,40) as [Remarks],[Img_Path],[Cat_Id],[Price],OverView FROM [MasterImage] where Row_Id=" + id + "";

        SQL_DB.GetDA(Qry).Fill(Ds, "1");

        Image = Ds.Tables[0].Rows[0]["Img_Path"].ToString();
        flightname = Ds.Tables[0].Rows[0]["Img_Title"].ToString();
        Remark = Ds.Tables[0].Rows[0]["Remarks"].ToString();       
        price = Ds.Tables[0].Rows[0]["Price"].ToString();
        Overview = Ds.Tables[0].Rows[0]["OverView"].ToString();
        //Discription = Ds.Tables[0].Rows[0]["Description"].ToString();
        //check = Ds.Tables[0].Rows[0]["PDF_File"].ToString();
        //if (check == "" || check == null)
        //{
        //    btnDownload.Visible = false;
        //}
        //else
        //{
        //    btnDownload.Visible = true;
        //}

    }     
    private void News()
    {

        DataSet Ds = new DataSet();
        SQL_DB.GetDA("SELECT tbl_id,substring([News],0,100) + '..... '  as [News] ,day(Updated_Date) as S_Date ,substring(DATENAME(MONTH, Updated_Date),0,4) as M_Month,[News_heading] FROM [News_tab] where Act_Flag=1").Fill(Ds, "1");
        for (int i = 0; i < Ds.Tables[0].Rows.Count; i++)
        {
            ShowDate.Append("<li>");
            ShowDate.Append("<div class='news_panel'>");
            if (i % 2 == 0)
            {
                ShowDate.Append("<div class='news_date1'>");
                ShowDate.Append("<div>" + Ds.Tables[0].Rows[i]["S_Date"].ToString() + "</div>");
                ShowDate.Append("<div>" + Ds.Tables[0].Rows[i]["M_Month"].ToString() + "</div>");
                ShowDate.Append("</div>");
            }
            else
            {
                ShowDate.Append("<div class='news_date2'>");
                ShowDate.Append("<div>" + Ds.Tables[0].Rows[i]["S_Date"].ToString() + "</div>");
                ShowDate.Append("<div>" + Ds.Tables[0].Rows[i]["M_Month"].ToString() + "</div>");
                ShowDate.Append("</div>");
            }
            ShowDate.Append("<div class='news_heading'>" + Ds.Tables[0].Rows[i]["News_heading"].ToString() + "</div>");
            ShowDate.Append("<div class='news_content'>" + Ds.Tables[0].Rows[i]["News"].ToString() + "<br />");
            ShowDate.Append("<span><a href='#'>Continue Reading.....</a></span></div>");
            ShowDate.Append("<br />");
            ShowDate.Append("</div>");
            ShowDate.Append("</li>");
        }
    }

}