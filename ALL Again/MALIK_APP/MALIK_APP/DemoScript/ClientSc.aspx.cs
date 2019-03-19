using System;
using System.Web.UI;

public partial class DemoScript_ClientSc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    void Page_Init(object sender, EventArgs e)
    {
        SetFocus(TextBox1);
    }

    private void SetFocus(String ctrlID)
    {
        // Build the JavaScript String
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script language='javascript'>");
        sb.Append("document.getElementById('");
        sb.Append(ctrlID);
        sb.Append("').focus()");
        sb.Append("</script>");

        // Register the script code with the page.
        Page.RegisterStartupScript("FocusScript", sb.ToString());
       
    }

}