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

public partial class admin_NewsUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["u_reg"] == null)
            Response.Redirect("index.aspx");    
        if (!IsPostBack)
            FillGrid();
    }
    protected void btnsave_Click(object sender, ImageClickEventArgs e)
    {
        if (btnsave.ImageUrl == "~/images/Button/save.png")
        {
            string s = "INSERT INTO [News_tab] " +
               " ([News]" +
               ",[Entry_Date],Updated_Date,News_heading) " +
         " VALUES " +
               "('" + Editor1.Content.Replace("'", "''") + "' " +
               ",'" + DataProvider.LocalDateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "','" + DataProvider.LocalDateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "','" + Editor2.Content.Trim() +"')";
            SQL_DB.ExecuteNonQuery(s);
            Editor1.Content = "";
            FillGrid();
            lblmdg.Text = "Record Sasve Successfully";
        }
        else
        {
            SQL_DB.ExecuteNonQuery("update News_tab set news='" + Editor1.Content.Replace("'", "''") + "',Updated_Date='" + DataProvider.LocalDateTime.Now.ToString("MM/dd/yyyy") + "',News_heading='" + Editor2.Content.Trim() + "'  where tbl_id=" + lblid.Text);
            lblmdg.Text = "Record Update Successfully";
            lblid.Text = "0";
        }
        FillGrid();
        Editor1.Content = "";
        Editor2.Content = "";
        lblConmsg.Text = "";
        btnsave.ImageUrl = "~/images/Button/save.png";
    }
    protected void btncancel_Click(object sender, ImageClickEventArgs e)
    {
        Editor1.Content = "";
        lblConmsg.Text = "";
        btnsave.ImageUrl = "~/images/Button/save.png";
        lblmdg.Text = "";
        Editor2.Content = "";
    }
    private void FillGrid()
    {
        DataSet ds = new DataSet();
        SQL_DB.GetDA("select row_number() over(order by tbl_id) as sr_no,[Updated_Date],tbl_id, case when Act_Flag=1 then 'Activated' else 'Deactivated' end as Act_Flag,News,News_heading,Entry_date from News_tab order by Entry_date").Fill(ds, "1");
        GridView1.DataSource = ds.Tables["1"];
        GridView1.DataBind();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "EditRow")
        {
            lblConmsg.Text = "";
            DataSet ds = new DataSet();
            int tbl_id = Convert.ToInt16(e.CommandArgument);
            SQL_DB.GetDA("select row_number() over(order by tbl_id) as sr_no,tbl_id,News,News_heading,Entry_date from News_tab  where tbl_id=" + tbl_id).Fill(ds, "1");
            Editor1.Content = ds.Tables["1"].Rows[0]["news"].ToString();
            Editor2.Content = ds.Tables["1"].Rows[0]["News_heading"].ToString();
            lblid.Text = tbl_id.ToString();
            btnsave.ImageUrl = "~/images/Button/update.png";
        }
       
        //btndave.Text = "Update";
            
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (Request.Form["chkselect"] == null)
        {
            lblConmsg.Text = "Select News First";
            return;
        }
        else
        {
            SQL_DB.ExecuteNonQuery("delete from  News_tab where  tbl_id in (" + Request.Form["chkselect"].ToString()+")");
            lblConmsg.Text = "News Deleted Successfully...";
            FillGrid();
        }
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        if (Request.Form["chkselect"] == null)
        {
            lblConmsg.Text = "Select News First";
            return;
        }
        else
        {
            SQL_DB.ExecuteNonQuery("UPDATE [News_tab]  SET [Act_Flag] = (case when [Act_Flag]=1 then 0 else 1 end) WHERE tbl_id in (" + Request.Form["chkselect"].ToString() + ")");
            lblConmsg.Text = "News Status Changed Successfully...";
            FillGrid();
        }
    }
}
