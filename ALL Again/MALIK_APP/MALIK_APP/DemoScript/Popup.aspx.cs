using System;

public partial class DemoScript_Popup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script language='javascript'>");
        sb.Append("window.open('ClientSc.aspx', 'CustomPopUp',");
        sb.Append("'width=200, height=200, menubar=yes, resizable=no');<");
        sb.Append("/script>");

        //register with ClientScript
        //The RegisterStartupScript method is also slightly different
        //from ASP.NET 1.x
        Type t = this.GetType();
        if (!ClientScript.IsClientScriptBlockRegistered(t, "PopupScript"))
            ClientScript.RegisterClientScriptBlock(t, "PopupScript", sb.ToString());
       

    }
}