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


public partial class Admin_SafarRegistration : System.Web.UI.Page
{
    public Int32 index = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillddlCategory();
            fillgridview();
            ImageOldUrl.Visible = false;            
            fillddlCategoryorder1();
        }
    }
    private void ClearTxt()
    {
        txtImgTitle.Text = "";
        LblMsg.Text = "";
        txtOverView.Text = "";
        txtReamrk.Text = "";
        txtPrice.Text = "";
        fillddlCategory();
        txtImgTitle.Focus();
        lblrow_id.Text = "";
        ImageOldUrl.Visible = false;
        imgBtnSubmit.ImageUrl = "../images/Button/save.png";
    }
    private void fillddlCategoryorder1()
    {
        DataSet ds = new DataSet();
        ddlcategory_Id.Items.Clear();        
        SQL_DB.GetDA("SELECT Cat_Id, Cat_Name FROM  CategoryMaster ORDER BY Cat_Id ASC").Fill(ds,"1");
        ddlcategory_Id.DataSource = ds.Tables["1"];
        ddlcategory_Id.DataTextField = "Cat_Name";
        ddlcategory_Id.DataValueField = "Cat_Id";
        ddlcategory_Id.DataBind();
        ddlcategory_Id.Items.Insert(0, "Selected Image Category");
    }
    private void fillgridvieworder(int category_id)
    {
        DataSet ds1 = new DataSet();
        SQL_DB.GetDA("SELECT    row_number() over(order by MasterImage.Row_Id) as srm, MasterImage.Row_Id, MasterImage.Img_Title, MasterImage.Remarks, MasterImage.OverView, '../'+MasterImage.Img_Path as Img_Path, MasterImage.Cat_Id,MasterImage.Entry_Date, MasterImage.Price,CategoryMaster.Cat_Name AS Cat_Name FROM MasterImage INNER JOIN CategoryMaster ON MasterImage.Cat_Id = CategoryMaster.Cat_Id    where MasterImage.Cat_Id='" + category_id + "'").Fill(ds1, "1");
        GridView1.DataSource = ds1.Tables["1"];
        GridView1.DataBind();
        ds1.Tables["1"].Clear();
    }
    private void fillgridview()
    {
        DataSet ds1 = new DataSet();
        SQL_DB.GetDA("SELECT   row_number() over(order by MasterImage.Row_Id) as srm,MasterImage.Row_Id, MasterImage.Img_Title, MasterImage.Remarks, MasterImage.OverView, '../'+MasterImage.Img_Path as Img_Path, MasterImage.Cat_Id,MasterImage.Entry_Date, MasterImage.Price,CategoryMaster.Cat_Name AS Cat_Name FROM MasterImage INNER JOIN CategoryMaster ON MasterImage.Cat_Id = CategoryMaster.Cat_Id order by Row_Id").Fill(ds1, "1");
        GridView1.DataSource = ds1.Tables["1"];
        GridView1.DataBind();
        ds1.Tables["1"].Clear();
    }
    private void fillddlCategory()
    {
        DataSet ds = new DataSet();
        ddlCategory.Items.Clear();     
        SQL_DB.GetDA("SELECT Cat_Id, Cat_Name FROM  CategoryMaster").Fill(ds,"1");
        ddlCategory.DataSource = ds.Tables["1"];
        ddlCategory.DataTextField = "Cat_Name";
        ddlCategory.DataValueField = "Cat_Id";
        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, "Selected Image Category");
    }
    protected void imgBtnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        string ImageFile = "";
        string Img = "";
        string cate_Id = "";
        string maxrow_id = "";
        int lindex = 0;
        string ext = "";
        string Path = Server.MapPath("../UploadDocument");
        cate_Id = Convert.ToString(SQL_DB.ExecuteScalar("SELECT rtrim([Prefix]) FROM [CategoryMaster] where CAt_Id=" + ddlCategory.SelectedValue + ""));
        if (imgBtnSubmit.ImageUrl == "../images/Button/save.png")
        {
            if (FileUploadImage.FileName == "")
            {
                LblMsg.Text = "Please Upload Image .jpg or .png";
                ModalPopupExtender1.Show();
                return;
            }
            else if (FileUploadImage.FileName != "")
            {
                maxrow_id = Convert.ToString(SQL_DB.ExecuteScalar("SELECT isnull(max([Row_Id]),0) + 1 as [Row_Id] FROM [MasterImage]"));
                lindex = FileUploadImage.FileName.LastIndexOf('.');
                ext = FileUploadImage.FileName.Substring(lindex, FileUploadImage.FileName.Length - lindex);
                if ((ext == ".jpg" && ext.ToUpper() == ".JPG") || (ext.ToUpper() == ". GPEJ" && ext == ".jpeg") || (ext.ToUpper() == ".png" || ext.ToUpper() == ".PNG"))
                {
                    ImageFile = cate_Id + "_" + maxrow_id + ext;
                    Path = Path + "\\" + ImageFile;
                    FileUploadImage.SaveAs(Path);
                }
                else
                {
                    LblMsg.Text = "Please Upload .png or jpg file";
                    ModalPopupExtender1.Show();
                    return;
                }
            }
            Img = Convert.ToString("UploadDocument/" + ImageFile);
            SQL_DB.ExecuteNonQuery("INSERT INTO [MasterImage]([Img_Title],[Remarks],[OverView],[Img_Path],[Cat_Id],[Entry_Date],[Price]) VALUES ('" + txtImgTitle.Text.Trim().Replace("'", "''") + "','" + txtReamrk.Text.Trim().Replace("'", "''") + "','" + txtOverView.Text.Trim().Replace("'", "''") + "','" + Img + "'," + ddlCategory.SelectedValue + ",'" + System.DateTime.Now + "','" + txtPrice.Text.Trim().Replace("'", "''") + "')");
        }
        else if (imgBtnSubmit.ImageUrl == "../images/Button/update.png")
        {
            //maxrow_id=Convert.ToString(SQL_DB.ExecuteScalar("SELECT [Row_Id] FROM [MasterImage] where Row_Id='" + lblrow_id.Text + "' "));
            maxrow_id = lblrow_id.Text;
            // if (FileUploadImage.FileName == "")
            //{
            SQL_DB.ExecuteNonQuery("UPDATE [MasterImage] SET [Img_Title] = '" + txtImgTitle.Text.Trim().Replace("'", "''") + "',[Remarks] ='" + txtReamrk.Text.Trim().Replace("'", "''") + "' ,[OverView] = '" + txtOverView.Text.Trim().Replace("'", "''") + "',[Cat_Id] = " + ddlCategory.SelectedValue + ", [Price]='" + txtPrice.Text.Trim().Replace("'", "''") + "' WHERE  Row_Id='" + lblrow_id.Text.Trim() + "'");
            // }
            if (FileUploadImage.FileName != "")
            {

                lindex = FileUploadImage.FileName.LastIndexOf('.');
                ext = FileUploadImage.FileName.Substring(lindex, FileUploadImage.FileName.Length - lindex);
                if ((ext == ".jpg" && ext.ToUpper() == ".JPG") || (ext.ToUpper() == ". GPEJ" && ext == ".jpeg") || (ext.ToUpper() == ".png" || ext.ToUpper() == ".PNG"))
                {
                    ImageFile = cate_Id + "_" + maxrow_id + ext;
                    Path = Path + "\\" + ImageFile;
                    FileUploadImage.SaveAs(Path);
                }
                else
                {
                    LblMsg.Text = "Please Upload .png or jpg file";
                    ModalPopupExtender1.Show();
                    return;
                }
                Img = Convert.ToString("UploadDocument/" + ImageFile);
                SQL_DB.ExecuteNonQuery("UPDATE [MasterImage] SET [Img_Path] = '" + Img + "' WHERE  Row_Id='" + lblrow_id.Text.Trim() + "'");
                lblrow_id.Text = "";
                ImageOldUrl.NavigateUrl = "";
            }
            imgBtnSubmit.ImageUrl = "../images/Button/save.png";
            ImageOldUrl.Visible = false;
        }
        ClearTxt();
        fillgridview();
    }
    protected void imgBtnReset_Click(object sender, ImageClickEventArgs e)
    {
        ClearTxt();
        ModalPopupExtender1.Show();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataSet ds = new DataSet();
        if (e.CommandName == "RegEdit")
        {
            lblrow_id.Text = e.CommandArgument.ToString();
            SQL_DB.GetDA("SELECT Row_Id, Img_Title, Remarks, OverView, Img_Path, Cat_Id,[Price] FROM   MasterImage WHERE Row_Id='" + lblrow_id.Text + "'").Fill(ds, "1");
            txtImgTitle.Text = ds.Tables["1"].Rows[0]["Img_Title"].ToString();
            txtReamrk.Text = ds.Tables["1"].Rows[0]["Remarks"].ToString();
            txtOverView.Text = ds.Tables["1"].Rows[0]["OverView"].ToString();
            ddlCategory.SelectedValue = ds.Tables["1"].Rows[0]["Cat_Id"].ToString();
            ImageOldUrl.NavigateUrl ="../"+ ds.Tables["1"].Rows[0]["Img_Path"].ToString();
            txtPrice.Text = ds.Tables["1"].Rows[0]["Price"].ToString();
            imgBtnSubmit.ImageUrl = "../images/Button/update.png";
            ddlCategory.Enabled = true;
            ImageOldUrl.Visible = true;
            ModalPopupExtender1.Show();
        }
        else if (e.CommandName == "RegDelete")
        {
            SQL_DB.ExecuteNonQuery("DELETE FROM [MasterImage] WHERE Row_Id='" + e.CommandArgument.ToString() + "'");
            fillgridview();
            ImageOldUrl.Visible = false;
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgridview();
    }

    protected void Unnamed1_Click(object sender, ImageClickEventArgs e)
    {
        ClearTxt();
        ImageOldUrl.Visible = false;
        imgBtnSubmit.ImageUrl = "../images/Button/save.png";
        ModalPopupExtender1.Show();
    }
    protected void ddlcategory_Id_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlcategory_Id.SelectedIndex == 0)
            fillgridview();
        else
        {
            fillgridvieworder(Convert.ToInt32(ddlcategory_Id.SelectedValue));
            LblmsgHead.Text = "";
        }
    }
}
