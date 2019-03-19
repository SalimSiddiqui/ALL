using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class admin_AccSetting : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["u_reg"] == null)
            Response.Redirect("index.aspx");    
    }
    protected void btnchange_Click(object sender, ImageClickEventArgs e)
    {

        int i = Convert.ToInt32(SQL_DB.ExecuteScalar("select count(*) from Admin_login where pwd='" + txtold.Text.Trim() + "' and user_id='" + Session["User_Id"].ToString() + "' and typ='" + Session["Type"].ToString() + "'"));
            if (i >= 1)
            {
                SQL_DB.ExecuteNonQuery("update Admin_login set pwd='" + txtnew.Text.Trim().Replace("'", "''") + "' where  pwd='" + txtold.Text.Trim() + "' and user_id='" + Session["User_Id"].ToString() + "' and typ='" + Session["Type"].ToString() + "'");
                lblmsg.Text = "Password Change Successfully";
            }
            else
                lblmsg.Text = "Old Password are Not Matching";  

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        txtold.Text = "";
        txtnew.Text = "";
        txtcon.Text = "";
        lblmsg.Text = ""; 
    }
}
