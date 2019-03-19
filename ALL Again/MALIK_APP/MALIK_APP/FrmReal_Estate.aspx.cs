using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

public partial class FrmReal_Estate : System.Web.UI.Page
{

    public StringBuilder PropertiesAdd = new StringBuilder();
    protected void Page_Load(object sender, EventArgs e)
    {
        Properties();
        if (!IsPostBack)
        {
        }

    }
    private void Properties()
    {
        DataSet Ds = new DataSet();
        string Qry = "SELECT     id, Pro_Name, City, Price, IsActive, url, BV, Prop_Perpose,'Admin/img/'+(Select top(1) image_Name from Property_Img_tab where Prop_Id=Property_tab.id Order by image_Name desc) as image_Name FROM Property_tab WHERE     (IsActive = 1)";
        SQL_DB.GetDA(Qry).Fill(Ds);
        if (Ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < Ds.Tables[0].Rows.Count; i++)
            {

                PropertiesAdd.Append("<li>");
                PropertiesAdd.Append("<a href='FrmReal_EstateDetail.aspx?uid=" + Ds.Tables[0].Rows[i]["id"].ToString() + "'><img class='img' src='" + Ds.Tables[0].Rows[i]["image_Name"].ToString() + "' data-bw=''/></a><h2>");
                PropertiesAdd.Append("<a href='FrmReal_EstateDetail.aspx?uid=" + Ds.Tables[0].Rows[i]["id"].ToString() + "'>" + Ds.Tables[0].Rows[i]["Pro_Name"].ToString() + "</a></h2>");
                PropertiesAdd.Append("<table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td> Price: </td> <td align='right'>");
                PropertiesAdd.Append("<span class='red'>INR " + Ds.Tables[0].Rows[i]["Price"].ToString() + " </span></td></tr><tr><td> City:</td> <td align='right'><span>" + Ds.Tables[0].Rows[i]["City"].ToString() + " </span></td></tr><tr><td> Area:</td> <td align='right'> ");
                PropertiesAdd.Append("<span>" + Ds.Tables[0].Rows[i]["BV"].ToString() + " Sq. Ft.</span> </td></tr><tr><td> Status: </td> <td align='right'>");
                PropertiesAdd.Append("<span>" + Ds.Tables[0].Rows[i]["Prop_Perpose"].ToString() + "</span>");
                PropertiesAdd.Append("</td></tr></table>");
                PropertiesAdd.Append("</li>");
            }
        }

    }
}