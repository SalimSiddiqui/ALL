using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class Admin_ProductMaster : System.Web.UI.Page
{
    public int sr = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillGrid();
        }
    }
    protected void imgBtnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        string path = "";
        if (ProductImage.HasFile)
        {
            path = Server.MapPath("Product_Image");
            string filename = ProductImage.FileName;
            int lindex = filename.LastIndexOf('.');
            string ext = filename.Substring(lindex, filename.Length - lindex);
            filename = GetProductCode() + ext;
            path = path + "\\" + filename;
            ProductImage.SaveAs(path);
            path = "Product_Image/" + filename;
        }
        else
            path = "NA";
        if (txtOfferPrice.Text == "" || txtOfferPrice.Text == null)
            txtOfferPrice.Text = "0";
        else if (Convert.ToDouble(txtprdprice.Text) <= Convert.ToDouble(txtOfferPrice.Text))
        {
            LblmsgHead.Text = "<script type='text/javascript'>alert('Offer Price must be less than Actual Price')</script>";
            ModalPopupExtender1.Show();
            return;
        }
        LblmsgHead.Text = "";
        if (imgBtnSubmit.ImageUrl == "../images/Button/save.png")
        {

            SQL_DB.ExecuteNonQuery("INSERT INTO [Product_Master] ([Produt_Code],[Product_Name],[Product_Price],[Offer_Price],[Product_Description],[Product_Image],[Cat_id],[Product_Qty]) VALUES('" + GetProductCode() + "' ,'" + txtprdname.Text.Trim().Replace("'", "''") + "'," + Convert.ToDouble(txtprdprice.Text) + "," + Convert.ToDouble(txtOfferPrice.Text) + ",'" + txtdescription.Text.Trim().Replace("'", "''") + "','" + path + "'," + ddlcategory.SelectedValue.ToString() + ","+txtQuantity.Text+")");
            SetProductCode();
        }
        else if (imgBtnSubmit.ImageUrl == "../images/Button/update.png")
        {
            if(path=="NA")
                SQL_DB.ExecuteNonQuery("UPDATE [Product_Master] SET [Product_Name] = '" + txtprdname.Text.Trim().Replace("'", "''") + "',[Product_Price] = " + Convert.ToDouble(txtprdprice.Text) + ",[Offer_Price] = " + Convert.ToDouble(txtOfferPrice.Text) + ",[Product_Description] = '" + txtdescription.Text.Trim().Replace("'", "''") + "',[Cat_id]=" + ddlcategory.SelectedValue.ToString() + ",[Product_Qty]=" + txtQuantity.Text + " WHERE Produt_Code='" + lblprdid.Text + "'");
            else
                SQL_DB.ExecuteNonQuery("UPDATE [Product_Master] SET [Product_Name] = '" + txtprdname.Text.Trim().Replace("'", "''") + "',[Product_Price] = " + Convert.ToDouble(txtprdprice.Text) + ",[Offer_Price] = " + Convert.ToDouble(txtOfferPrice.Text) + ",[Product_Description] = '" + txtdescription.Text.Trim().Replace("'", "''") + "',[Product_Image] = '" + path + "',[Cat_id]=" + ddlcategory.SelectedValue.ToString() + ",[Product_Qty]=" + txtQuantity.Text + " WHERE Produt_Code='" + lblprdid.Text + "'");
        }
        FillGrid();
    }
    protected void imgBtnReset_Click(object sender, ImageClickEventArgs e)
    {
        Clear();
        ModalPopupExtender1.Show();
    }
    
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Clear();
        FillCategory();
        ModalPopupExtender1.Show();
    }
    protected void imgBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        FillGrid();
    }

    private void Clear()
    {
        txtOfferPrice.Text = string.Empty;
        txtprdname.Text = string.Empty;
        txtprdprice.Text = string.Empty;
        txtQuantity.Text = string.Empty;
        txtSearchProid.Text = string.Empty;
        txtSearchProName.Text = string.Empty;
        imgBtnSubmit.ImageUrl = "../images/Button/save.png";
        RequiredFieldValidator3.ValidationGroup = "Reg_Img";
        txtdescription.Text = string.Empty;
    }

    private void FillGrid()
    {
        DataSet ds = new DataSet();
        SQL_DB.GetDA("SELECT [Produt_Code],[Product_Name],[Product_Qty],[Product_Price],[Offer_Price],[Product_Description],[Product_Image] FROM [Product_Master] where Produt_Code like '%" + txtSearchProid.Text.Trim().Replace("'", "''") + "%' and Product_Name like '%" + txtSearchProName.Text.Trim().Replace("'", "''") + "%'").Fill(ds, "1");
        GridView1.DataSource = ds.Tables["1"];
        GridView1.DataBind();
    }

    private String GetProductCode()
    {
        return Convert.ToString(SQL_DB.ExecuteScalar("SELECT [prefix]+convert(varchar,[startwith]) as PrdCode FROM [code_gen] where [key_col]='Product'"));
    }
    private void SetProductCode()
    {
        SQL_DB.ExecuteNonQuery("Update code_gen Set startwith=startwith+1 where [key_col]='Product'");
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        FillGrid();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblprdid.Text=e.CommandArgument.ToString();
        if (e.CommandName.ToString() == "RegEdit")
        {
            DataSet ds = new DataSet();
            SQL_DB.GetDA("SELECT [Produt_Code],[Product_Name],[Product_Qty],[Product_Price],[Cat_id],[Offer_Price],[Product_Description],[Product_Image] FROM [Product_Master] where Produt_Code='" + lblprdid.Text + "'").Fill(ds, "1");
            if (ds.Tables["1"].Rows.Count > 0)
            {
                FillCategory();
                txtprdname.Text = ds.Tables["1"].Rows[0]["Product_Name"].ToString();
                txtOfferPrice.Text = ds.Tables["1"].Rows[0]["Offer_Price"].ToString();
                txtdescription.Text = ds.Tables["1"].Rows[0]["Product_Description"].ToString();
                txtprdprice.Text = ds.Tables["1"].Rows[0]["Product_Price"].ToString();
                txtQuantity.Text = ds.Tables["1"].Rows[0]["Product_Qty"].ToString();
                imgBtnSubmit.ImageUrl = "../images/Button/update.png";
                ddlcategory.SelectedValue = ds.Tables["1"].Rows[0]["Cat_id"].ToString();
                RequiredFieldValidator3.ValidationGroup = "xyz";
            }
            ModalPopupExtender1.Show();
        }
        else if (e.CommandName.ToString() == "RegDelete")
        {
            SQL_DB.ExecuteNonQuery("Delete From [Product_Master] where Produt_Code='" + lblprdid.Text + "'");
            FillGrid();
        }
    }

    private void FillCategory()
    {
        DataSet ds = new DataSet();
        ddlcategory.Items.Clear();
        SQL_DB.GetDA("SELECT [Cat_id],[Cat_Name] FROM [Product_Category]").Fill(ds,"1");
        ddlcategory.DataSource = ds.Tables["1"];
        ddlcategory.DataTextField = "Cat_Name";
        ddlcategory.DataValueField = "Cat_id";
        ddlcategory.DataBind();
        ddlcategory.Items.Insert(0, "--Select--");
    }
}