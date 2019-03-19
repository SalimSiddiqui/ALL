using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Net;
using System.Text;

public partial class Admin_ShoppingDetail : System.Web.UI.Page
{
    public int sr = 0,index=0;
    StringBuilder ProductList = new StringBuilder();
    public string mailServer12 = ConfigurationManager.ConnectionStrings["servername"].ConnectionString.ToString();
    public string UserId12 = ConfigurationManager.ConnectionStrings["user_id"].ConnectionString.ToString();
    public string Pass12 = ConfigurationManager.ConnectionStrings["password"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtDateFrom.Text = "";
            txtDateTo.Text = "";
            txtSearchTraId.Text = "";
            txtSearchUserName.Text = "";
            FillGrd();
        }
    }

    private void FillGrd()
    {
        DataSet ds = new DataSet();
        string str="";
        if (txtDateFrom.Text != "")
            str += " and convert(varchar,[Entry_Date],103)>="+txtDateFrom.Text;
        if (txtDateTo.Text != "")
            str += " and convert(varchar,[Entry_Date],103)<=" + txtDateTo.Text;
        SQL_DB.GetDA("SELECT [Trans_id],[User_Name],[User_Email],[Mobile_No],[Address],convert(varchar,[Entry_Date],103) as Entry_Date,[Deliver_Status],(case when Deliver_Status=0 then 'Pending' else 'Delivered' end) as Status FROM [User_Detail] where User_Name like '%" + txtSearchUserName.Text.Trim().Replace("'", "''") + "%' and Trans_id like '%" + txtSearchTraId.Text.Trim().Replace("'", "''") + "%'" + str).Fill(ds, "1");
        GridView1.DataSource = ds.Tables["1"];
        GridView1.DataBind();
       // LblmsgHead.Text = "Shopping Detail (" + Convert.ToString(ds.Tables["1"].Rows.Count)+" Rows Found)";
             
    }
    protected void imgBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        FillGrd();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        FillGrd();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblrow_id.Text = e.CommandArgument.ToString();
        DataSet ds = new DataSet();
        SQL_DB.GetDA("SELECT     Product_Master.Product_Name,User_Detail.User_Name, User_Detail.User_Email,User_Detail.Mobile_No, User_Detail.Address, User_Purchage.Quantity, User_Purchage.Total_Amount, convert(varchar,User_Purchage.Purchage_date,103) as Purchage_date,Product_Master.Product_Image  FROM   User_Detail INNER JOIN  User_Purchage ON User_Detail.Trans_id = User_Purchage.Trans_id INNER JOIN   Product_Master ON User_Purchage.Produt_Code = Product_Master.Produt_Code where User_Detail.Trans_id='" + lblrow_id.Text + "'").Fill(ds, "1");
        if (e.CommandName.ToString() == "ViewProduct")
        {
            TransactionId.Text = lblrow_id.Text;
            PurhaseDate.Text = ds.Tables["1"].Rows[0]["Purchage_date"].ToString();
            UserName.Text = ds.Tables["1"].Rows[0]["User_Name"].ToString();
            Address.Text = ds.Tables["1"].Rows[0]["Address"].ToString();
            MobileNo.Text = ds.Tables["1"].Rows[0]["Mobile_No"].ToString();
            BillingAmount.Text = Convert.ToString(ds.Tables["1"].Compute("sum(Total_Amount)",""));
            GridView2.DataSource = ds.Tables["1"];
            GridView2.DataBind();
            ModalPopupExtender1.Show();
        }
        else if (e.CommandName.ToString() == "DStatus")
        {

            SQL_DB.ExecuteNonQuery("Update User_Detail Set Deliver_Status =1 where Trans_id='" + lblrow_id.Text + "'");
            #region SendMail
            string E_body = ""; string email = ds.Tables["1"].Rows[0]["User_Email"].ToString(); string admindata = ""; string name = "";
            FillProduct(ds);
            E_body = "<table width='625' align='left' border='0' style='font-family: Verdana, Geneva, sans-serif;font-size: 11px;border-width:medium; border:solid; border-spacing:10;border-color:#CCCCCC'> <tr><td width='653'></td> </tr> <tr>    <td valign='middle'><img src='../images/banner.png' alt='' width='624' height='50'/></td>  </tr><tr> <td align='justify'><p><br>" +
            " Dear :<strong>" + ds.Tables["1"].Rows[0]["User_Name"].ToString() + "</strong>,</p>" +
            " <p>Your request has been approved.</p>" +
            " <p>Your requested products has been delivered to your mentioned address.</p>" +
            " <p> Sort Details for Products are :</p>" +
            "<p>Transaction Id : " + lblrow_id.Text + "</p>" +
               ProductList.ToString() +
            " <p>For any queries or assistance, please do email us at <a>support@malikassociates.in</a></p>" +
            " </td>  </tr>  <tr><td><p><br>Warm Regards,<br> Website Administrator<br>" +
            " <a href='http://malikassociates.in/'>malikassociates.in</a></p></td></tr></table>";
            DataProvider.Uttils.sendMail(mailServer12, UserId12, Pass12, email, E_body, "Malik Associates Details");
            admindata = "<table width='625' align='left' border='0' style='font-family: Verdana, Geneva, sans-serif;font-size: 11px;border-width:medium; border:solid; border-spacing:10;border-color:#CCCCCC'> <tr><td width='653'></td> </tr> <tr>    <td valign='middle'><img src='../images/banner.png' alt='' width='624' height='50'/></td>  </tr><tr> <td align='justify'><p><br>" +
            " <p>Visit for Malik Products</p>" +
            "<p>Transaction Id : " + lblrow_id.Text + "</p>" +
             ProductList.ToString() +
            " <p>Customer Name :<strong>" + ds.Tables["1"].Rows[0]["User_Name"].ToString() + "</strong>,</p>" +
            " <p>Customer Email : " + email + "</p>" +
             " <p>Address : " + ds.Tables["1"].Rows[0]["Address"].ToString() + "</p>" +
             " <p>Mobile No. : " + ds.Tables["1"].Rows[0]["Mobile_No"].ToString() + "</p>" +
             " <p>Shopping Status : Delivered</p>" +
            " </td>  </tr> </table>";//"support@malikassociates.in"
            DataProvider.Uttils.sendMail(mailServer12, UserId12, Pass12, "support@malikassociates.in", admindata, "Deliver Product");
            #endregion
            FillGrd();
        }
    }

    private void FillProduct(DataSet ds)
    {       
        if (ds.Tables["1"].Rows.Count > 0)
        {
            ProductList.Append("<table width='100%'><tr><th>Product Name</th><th>Quantity</th><th>Total Price</th></tr>");

            for (int i = 0; i < ds.Tables["1"].Rows.Count; i++)
            {
                ProductList.Append("<tr>");
                ProductList.Append("<td>" + ds.Tables["1"].Rows[i]["Product_Name"].ToString() + "</td>");
                ProductList.Append("<td>" + ds.Tables["1"].Rows[i]["Quantity"].ToString() + "</td>");
                ProductList.Append("<td>" + ds.Tables["1"].Rows[i]["Total_Amount"].ToString() + "</td>");
                ProductList.Append("</tr>");
            }
            ProductList.Append("</table>");
        }
    }
}