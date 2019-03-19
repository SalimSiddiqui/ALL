using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
public partial class PropertyMaster : System.Web.UI.MasterPage
{
    public StringBuilder ShowDate = new StringBuilder();
    protected void Page_Load(object sender, EventArgs e)
    {
        News();
        if (!IsPostBack)
        {
            Fill_DdlCity();
        }
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
    private void Fill_DdlCity()
    {
        DataSet ds = new DataSet();
        SQL_DB.GetDA("SELECT [CITY_ID] ,[CityName] FROM [CityMaster]").Fill(ds, "1");
        ddlcity.DataSource = ds.Tables[0];
        ddlcity.DataTextField = "CityName";
        ddlcity.DataValueField = "CITY_ID";
        ddlcity.DataBind();
        ddlcity.Items.Insert(0, "--Select--");
    }
}

