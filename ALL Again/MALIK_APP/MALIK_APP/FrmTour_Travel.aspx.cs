using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

public partial class FrmTour_Travel : System.Web.UI.Page
{
    public StringBuilder first = new StringBuilder();
    public StringBuilder second = new StringBuilder();
    public StringBuilder third = new StringBuilder();
    int max1, max2, max3;
    protected void Page_Load(object sender, EventArgs e)
    {
        flight_Builder();
        if (!IsPostBack)
        {

        }
    }
    private void flight_Builder()
    {
        DataSet FirstDs=new DataSet();
        SQL_DB.GetDA("SELECT top(4) [Row_Id],Img_Title,Substring([Remarks],0,40) as [Remarks],[Img_Path],[Cat_Id],[Price]FROM [MasterImage] where Cat_Id=1").Fill(FirstDs, "1");
        SQL_DB.GetDA("SELECT top(4) [Row_Id],Img_Title,Substring([Remarks],0,40) as [Remarks],[Img_Path],[Cat_Id],[Price]FROM [MasterImage] where Cat_Id=2").Fill(FirstDs, "2");
        SQL_DB.GetDA("SELECT top(4) [Row_Id],Img_Title,Substring([Remarks],0,40) as [Remarks],[Img_Path],[Cat_Id],[Price]FROM [MasterImage] where Cat_Id=3").Fill(FirstDs, "3");
        if (FirstDs.Tables["1"].Rows.Count > 3)
            max1 = 3;
        else max1 = FirstDs.Tables["1"].Rows.Count;
        if (FirstDs.Tables["2"].Rows.Count > 3)
            max2 = 3;
        else max2 = FirstDs.Tables["2"].Rows.Count;
        if (FirstDs.Tables["3"].Rows.Count > 3)
            max3 = 3;
        else max3 = FirstDs.Tables["3"].Rows.Count;
        if(FirstDs.Tables["1"].Rows.Count>0)
        {
            for (int i = 0; i < max1; i++)
            {

                first.Append("<table width='100%' border='0' cellspacing='0' cellpadding='0'>");
                first.Append("<tr><td width='53%' rowspan='4'>");
                first.Append("<div class='package_image'><a href='FrmTravel_Detail.aspx?uid=" + FirstDs.Tables["1"].Rows[i]["Row_Id"].ToString() + "'><img src='" + FirstDs.Tables["1"].Rows[i]["Img_Path"].ToString() + "' width='120' height='75' /></a></div>");
                first.Append("</td><td> <p class='airline_name'>  " + FirstDs.Tables["1"].Rows[i]["Img_Title"].ToString() + "</p> </td> </tr><tr><td><p class='package_duration'> " + FirstDs.Tables["1"].Rows[i]["Remarks"].ToString() + "</p></td></tr><tr><td> <p class='package_price'> INR " + FirstDs.Tables["1"].Rows[i]["Price"].ToString() + "/-</p> </td> </tr><tr> <td> <p class='package_per_cost'> INR per person</p> </td> </tr></table>");
            }
            if(FirstDs.Tables["1"].Rows.Count>3)
            first.Append("<div class='more'> <a href='#'>More...</a></div>");
        }
        if (FirstDs.Tables["2"].Rows.Count > 0)
        {
            for (int i = 0; i <max2; i++)
            {

                second.Append("<table width='100%' border='0' cellspacing='0' cellpadding='0'>");
                second.Append("<tr><td width='53%' rowspan='4'>");
                second.Append("<div class='package_image'><a href='FrmTravel_Detail.aspx?uid=" + FirstDs.Tables["2"].Rows[i]["Row_Id"].ToString() + "'><img src='" + FirstDs.Tables["2"].Rows[i]["Img_Path"].ToString() + "' width='120' height='75' /></a></div>");
                second.Append("</td><td> <p class='airline_name'>" + FirstDs.Tables["2"].Rows[i]["Img_Title"].ToString() + "</p> </td> </tr><tr><td><p class='package_duration'> " + FirstDs.Tables["2"].Rows[i]["Remarks"].ToString() + "</p></td></tr><tr><td> <p class='package_price'> INR " + FirstDs.Tables["2"].Rows[i]["Price"].ToString() + "/-</p> </td> </tr><tr> <td> <p class='package_per_cost'> INR per person</p> </td> </tr></table>");
            }
            if (FirstDs.Tables["2"].Rows.Count > 3)
            second.Append("<div class='more'> <a href='#'>More...</a></div> ");
        }
        if (FirstDs.Tables["3"].Rows.Count > 0)
        {
            for (int i = 0; i < max3; i++)
            {

                third.Append("<table width='100%' border='0' cellspacing='0' cellpadding='0'>");
                third.Append("<tr><td width='53%' rowspan='4'>");
                third.Append("<div class='package_image'><a href='FrmTravel_Detail.aspx?uid=" + FirstDs.Tables["3"].Rows[i]["Row_Id"].ToString() + "'><img src='" + FirstDs.Tables["3"].Rows[i]["Img_Path"].ToString() + "' width='120' height='75' /></a></div>");
                third.Append("</td><td> <p class='airline_name'> " + FirstDs.Tables["3"].Rows[i]["Img_Title"].ToString() + "</p> </td> </tr><tr><td><p class='package_duration'> " + FirstDs.Tables["3"].Rows[i]["Remarks"].ToString() + "</p></td></tr><tr><td> <p class='package_price'> INR " + FirstDs.Tables["3"].Rows[i]["Price"].ToString() + "/-</p> </td> </tr><tr> <td> <p class='package_per_cost'> INR per person</p> </td> </tr></table>");
            }
            if (FirstDs.Tables["3"].Rows.Count > 3)
            third.Append("<div class='more'> <a href='#'>More...</a></div>");
        }
    }  
}