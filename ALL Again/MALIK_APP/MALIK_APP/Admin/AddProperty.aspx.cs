using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Drawing;
using System.Web.Services;
using System.Text;

public partial class admin_AddProperty : System.Web.UI.Page
{
    public int count = 0,sr=0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["UploadeFileList"] = null;
            fillDdlstate();
            fillDDlcity();
            FillGrid();
        }
    }

    private void fillDdlstate()
    {
        DataSet ds = new DataSet();
        SQL_DB.GetDA("SELECT [STATE_ID] ,[stateName] FROM  [StateMaster] where Country_id=4 order by stateName").Fill(ds, "1");
        ddlstate.DataTextField = "stateName";
        ddlstate.DataValueField = "STATE_ID";
        ddlstate.DataSource = ds.Tables["1"];
        ddlstate.DataBind();
    }

    private void fillDDlcity()
    {
        DataSet ds = new DataSet();
        SQL_DB.GetDA("SELECT [CITY_ID] ,[CityName]  FROM [CityMaster] where [State_id]=" + ddlstate.SelectedValue + " order by CityName").Fill(ds, "1");
        ddlcity.DataTextField = "CityName";
        ddlcity.DataValueField = "CityName";
        ddlcity.DataSource = ds.Tables["1"];
        ddlcity.DataBind();

    }
    private void FillGrid()
    {
        DataSet ds = new DataSet();
        SQL_DB.GetDA("SELECT [id],[Pro_Name],[City],[Price],[BV],[Description],IsActive,case when IsActive=1  then 'Activated' else 'Deactivated' end as status FROM [Property_tab] where Del_Flag=0").Fill(ds, "1");
        GridView1.DataSource = ds.Tables["1"];
        GridView1.DataBind();
        count = ds.Tables["1"].Rows.Count;
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        int OnHomePage = 0;
        if (chkshow.Checked)
            OnHomePage = 1;
        string Qry = "";
        if (imgbtnsave.ImageUrl == "~/images/Button/save.png")
        {
            Qry = "INSERT INTO [Property_tab]" +
              "([Pro_Name]" +
              ",[State_Id]" +
              ",[City]" +
              ",[Price]" +
              ",[BV]" +
              ",[Prop_typ]" +
              ",[Prop_Perpose]" +
              ",[show_Home]" +
               ",[url]" +
              ",[Description])" +
        " VALUES " +
            "  ('" + txtptotitle.Text + "'" + 
            "  ," + ddlstate.SelectedValue +
            "  ,'" + ddlcity.SelectedItem.Text + "'" +
            "  ," + txtprice.Text +
            "  ," + txtbv.Text +
              "  ,'" + ddltype.SelectedItem.Text + "'" +
                "  ,'" + ddlperpose.SelectedItem.Text + "'" +
                "  ," + OnHomePage +
                    "  ,'" + txturl.Text + "'" +
            "  ,'" + txtdetail.Text + "');select max(id) from Property_tab";
            string id = Convert.ToString(SQL_DB.ExecuteScalar(Qry));
            string path = Server.MapPath("img");
            if (FileUpload2.FileName.Length > 0)
            {
                FileUpload2.SaveAs(path + "\\" + id.ToString() + Path.GetExtension(FileUpload2.FileName));
                SQL_DB.ExecuteNonQuery("Update Property_tab set PDF_File='" + id.ToString() + Path.GetExtension(FileUpload2.FileName) + "' where id=" + id);
            }
            if (Request.Files.Count > 0)
            {
                SaveFile(id);
            }

        }
        else
        {
            Qry = "UPDATE [Property_tab] " +
       " SET [Pro_Name] = '" + txtptotitle.Text + "'" +
       " ,[State_Id] = " + ddlstate.SelectedValue +  
         " ,[City] = '" + ddlcity.SelectedItem.Text + "'" +
         " ,[Price] = " + txtprice.Text +
         " ,[BV] = " + txtbv.Text +
         " ,[show_Home] = " + OnHomePage+
        ",[Prop_typ]='" + ddltype.SelectedValue + "'" +
          ",[Prop_Perpose]='" + ddlperpose.SelectedValue + "'" +
          " ,[Description] = '" + txtdetail.Text + "'" +
             " ,[url] = '" + txturl.Text + "'" +
     " WHERE id=" + lblid.Text;
            SQL_DB.ExecuteNonQuery(Qry);
            string path = Server.MapPath("img");
            if (FileUpload2.FileName.Length > 0)
            {
                FileUpload2.SaveAs(path + "\\" + lblid.Text + Path.GetExtension(FileUpload2.FileName));
                SQL_DB.ExecuteNonQuery("Update Property_tab set PDF_File='" + lblid.Text + Path.GetExtension(FileUpload2.FileName) + "' where id=" + lblid.Text);
         
            }
            if (Request.Files.Count > 0)
            {
                DeleteFiles(lblid.Text);
                SaveFile(lblid.Text);
            }
        }

        FillGrid();
        Reset();
    }
    private void DeleteFiles(string Id)
    {
        DataSet ds = new DataSet();
        SQL_DB.GetDA("select image_Name from Property_Img_tab where Prop_Id=" + Id).Fill(ds, "1");
        string path = Server.MapPath("img");
        for (int i = 0; i < ds.Tables["1"].Rows.Count; i++)
        {
            if (File.Exists(path + "//" + ds.Tables["1"].Rows[i]["image_Name"].ToString()))
                File.Delete(path + "//" + ds.Tables["1"].Rows[i]["image_Name"].ToString());
            if (File.Exists(path + "//Thmb//" + ds.Tables["1"].Rows[i]["image_Name"].ToString()))
                File.Delete(path + "//Thmb//" + ds.Tables["1"].Rows[i]["image_Name"].ToString());
        }
        SQL_DB.ExecuteNonQuery("delete from Property_Img_tab where Prop_Id=" + Id);
    }
    private void Reset()
    {
        txtbv.Text = "";
        txtdetail.Text = "";
        txtprice.Text = "";
        txtptotitle.Text = "";
        chkshow.Checked = false;
        imgbtnsave.ImageUrl = "~/images/Button/save.png";
        txturl.Text = "";
         list.InnerHtml = "";
         Session["UploadeFileList"] = null;
    }
    private void SaveFile(string Id)
    {
        string Qry = "";
        string path = Server.MapPath("img");
        PostedFiles();
        if (Session["UploadeFileList"] == null)
            return;
        List<UploadeFile> FileDetail = (List<UploadeFile>)Session["UploadeFileList"];  
        for (int i = 0; i < FileDetail.Count; i++)
        {
            try
            {
                string imgName = path + "//" + Id + "_" + i.ToString() + ".jpg";
                string temp = imgName;
                Stream m = FileDetail[i].File;
                System.Drawing.Image img = System.Drawing.Image.FromStream(m);
                img.Save(imgName);
                Bitmap newThumbnail = new Bitmap(img, 217, 119);
                imgName = path + "//Thmb//" + Id + "_" + i.ToString() + ".jpg";
                newThumbnail.Save(imgName);
                Qry = Qry + " INSERT INTO  [Property_Img_tab] " +
               "([Prop_Id]" +
               ",[image_Name])" +
               " VALUES " +
              " (" + Id +
                 " ,'" + Id + "_" + i.ToString() + ".jpg')";
            }
            catch { }

        }
        if (Qry!="")
        SQL_DB.ExecuteNonQuery(Qry);
        Session["UploadeFileList"] = null;
         list.InnerHtml = "";
    }
    private void PostedFiles()
    {
        HttpFileCollection uploads = HttpContext.Current.Request.Files; 
        List<UploadeFile> FileDetailList = new List<UploadeFile>();
        if (Session["UploadeFileList"] != null)
            FileDetailList = (List<UploadeFile>)Session["UploadeFileList"];
        UploadeFile FileD;
        for (int i = 0; i < uploads.Count; i++)
        {
            HttpPostedFile upload = uploads[i];
            if (upload.ContentLength == 0)
                continue;
            string d=upload.ContentType;
            if (d.IndexOf("image") < 0)
                continue;
            FileD = new UploadeFile();
            FileD.File = upload.InputStream;
            FileD.FileName = upload.FileName;
            FileD.Status = 1;
            FileDetailList.Add(FileD);
        }
        if (FileDetailList.Count > 0)
            Session["UploadeFileList"] = FileDetailList;
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        FillGrid();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "Activate")
        {
            SQL_DB.ExecuteNonQuery("update Property_tab set IsActive=abs(IsActive-1) where id=" + e.CommandArgument.ToString());
        }
        else if (e.CommandName.ToString() == "DeleteRow")
        {
            SQL_DB.ExecuteNonQuery("update Property_tab set Del_Flag=1 where id=" + e.CommandArgument.ToString());
        }
        else if (e.CommandName.ToString() == "EditRow")
        {
            DataSet ds = new DataSet();
            SQL_DB.GetDA("SELECT [id],[Pro_Name],[City],State_Id,[url],[show_Home],[Prop_Perpose],[Prop_typ],[show_Home],[Price],[BV],[Description],IsActive,case when IsActive=1  then 'Activated' else 'Deactivated' end as status FROM [Property_tab]  where id=" + e.CommandArgument.ToString()).Fill(ds, "1");
            if (ds.Tables["1"].Rows.Count == 0)
                return;
            txtptotitle.Text = ds.Tables["1"].Rows[0]["Pro_Name"].ToString();
            txtbv.Text = ds.Tables["1"].Rows[0]["BV"].ToString();
            txtdetail.Text = ds.Tables["1"].Rows[0]["Description"].ToString();
            txtprice.Text = ds.Tables["1"].Rows[0]["Price"].ToString();
            ddltype.SelectedValue = ds.Tables["1"].Rows[0]["Prop_typ"].ToString();
            ddlperpose.SelectedValue = ds.Tables["1"].Rows[0]["Prop_Perpose"].ToString();
            txturl.Text = ds.Tables["1"].Rows[0]["url"].ToString();
            if (Convert.ToInt32(ds.Tables["1"].Rows[0]["show_Home"].ToString()) == 1)
                chkshow.Checked = true;
            else
                chkshow.Checked = false;
            try
            {
                ddlstate.SelectedValue = ds.Tables["1"].Rows[0]["State_Id"].ToString();
                ddlstate_SelectedIndexChanged(new object(), new EventArgs());
                int index = ddlcity.Items.IndexOf(ddlcity.Items.FindByText(ds.Tables["1"].Rows[0]["City"].ToString()));
                if (index > -1)
                    ddlcity.SelectedIndex = index;
            }
            catch
            {

            }
            lblid.Text = e.CommandArgument.ToString();
            imgbtnsave.ImageUrl = "~/images/Button/update.png";
            ds.Clear();
            SQL_DB.GetDA("SELECT  [image_Name] FROM [Property_Img_tab] WHERE  [Prop_Id]=" + e.CommandArgument.ToString()).Fill(ds, "1");
            List<UploadeFile> FDetail = new List<UploadeFile>();
            Session["UploadeFileList"] = FDetail;
             UploadeFile f;
             StringBuilder str = new StringBuilder();          
            for (int i = 0; i < ds.Tables["1"].Rows.Count; i++)
            {
                try
                {
                    f = new UploadeFile();
                    f.FileName = ds.Tables["1"].Rows[i]["image_Name"].ToString();
                    f.FileUrl = f.FileName;
                    f.Status = 0;
                    byte[] buffer = File.ReadAllBytes(Path.Combine(Server.MapPath("img"), f.FileName));
                    f.FileSize = buffer.Length;
                    MemoryStream ms = new MemoryStream(buffer);
                    f.File = ms;
                    FDetail.Add(f);
                    str.Append("<div>");
                    str.Append("<div  onclick=\"DeleteFile(this,\'" + f.FileName + "')\">");
                    str.Append("</div>");
                    str.Append(" <img alt=\"\"   src=\"img/" + f.FileName + "\" class=\"thumb\" /> ");
                    str.Append("</div>");                
                }
                catch { }
            }
           
          
            list.InnerHtml = str.ToString();
           // this.RegisterStartupScript("google", "<script language='javascript'> Testfunction('"+str.ToString()+"'); </script>");
        }
        FillGrid();
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Reset();
    }
    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillDDlcity();
    }

    #region Web Method for file uploader
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public static string GetWebProgress11()
    {
        return "sdsadasd";
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public static object GetWebProgress()
    {

        if (HttpContext.Current.Session["UploadeFileSession"] == null)
            return "";
        UploadeFile FileDetail = (UploadeFile)HttpContext.Current.Session["UploadeFileSession"];
        return new
        {
            Message = FileDetail.UploadedLength.ToString(),
            FileSize = FileDetail.FileSize,
            UploadedLength = FileDetail.UploadedLength,
            FileUrl = Path.Combine(FileDetail.UploadFolder, FileDetail.FileName),
            Status = FileDetail.Status,
            FileName = FileDetail.FileName
        };
       
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public static void DeleteWebFile(string name)
    {

        List<UploadeFile> FileDetailList = (List<UploadeFile>)HttpContext.Current.Session["UploadeFileList"];
        UploadeFile FileDetail = FileDetailList.Find(P => P.FileName == name);
        FileDetailList.Remove(FileDetail);
        HttpContext.Current.Session["UploadeFileList"] = FileDetailList;
       // delete file from server
        string path = HttpContext.Current.Server.MapPath("img");
        string FilePath = Path.Combine(path, name);
        if (File.Exists(FilePath))        
            File.Delete(FilePath);
        path = Path.Combine(HttpContext.Current.Server.MapPath("img"), "Thmb");
         FilePath = Path.Combine(path, name);
         if (File.Exists(FilePath))
             File.Delete(FilePath);
     
    }
    #endregion
}