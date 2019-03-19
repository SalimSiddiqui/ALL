using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.IO;

public partial class FrmReal_EstateDetail : System.Web.UI.Page
{
    public string Image="", propname="", city="", sqrfeet="", price="",purpose="",Discription="";
    string check;
    public StringBuilder PropertyDetail = new StringBuilder();
    protected void Page_Load(object sender, EventArgs e)
    {
      //  PropertyDetails();
        if (!IsPostBack)
        {
         
        }
    }
    //private void PropertyDetails()
    //{
    //    int id = Convert.ToInt32(Request.QueryString["uid"].ToString());
    //    DataSet Ds = new DataSet();
    //    string Qry = "SELECT [id],[Pro_Name],[City] ,[Price] ,[BV] ,[Description],[Prop_typ],[Prop_Perpose],[PDF_File],[url],'Admin/img/'+(select top(1)image_Name from Property_Img_tab where Prop_Id=" + id + "Order by image_Name desc) as image_Name FROM [Property_tab] where id=" + id + "";
        
    //    SQL_DB.GetDA(Qry).Fill(Ds, "1");

    //    Image = Ds.Tables[0].Rows[0]["image_Name"].ToString();
    //    propname = Ds.Tables[0].Rows[0]["Pro_Name"].ToString();
    //    city = Ds.Tables[0].Rows[0]["City"].ToString();
    //    sqrfeet = Ds.Tables[0].Rows[0]["BV"].ToString();
    //    price = Ds.Tables[0].Rows[0]["Price"].ToString();
    //    purpose = Ds.Tables[0].Rows[0]["Prop_Perpose"].ToString();
    //    Discription = Ds.Tables[0].Rows[0]["Description"].ToString();
    //    check = Ds.Tables[0].Rows[0]["PDF_File"].ToString();
    //    if (check == "" || check == null)
    //    {            
    //      // btnDownload.Visible = false;
    //    }
    //    else
    //    {          
    //     //// btnDownload.Visible = true;
    //    }
        
    //}     
    //protected void btnEnquiry_Click(object sender, EventArgs e)
    //{
    //   // ModalPopupExtender2.Show();
    //}
    //protected void btnDownload_Click(object sender, EventArgs e)
    //{
    //    string filepath = Server.MapPath("~/Admin/img/" + check + "");
    //    FileInfo myfile = new FileInfo(filepath);
    //    if (myfile.Exists)
    //    {
    //        System.Web.HttpContext.Current.Response.ClearContent();
    //        string s = System.DateTime.Now.ToString();
    //        System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + check + "");
    //        System.Web.HttpContext.Current.Response.AddHeader("Content-Length", myfile.Length.ToString());
    //        System.Web.HttpContext.Current.Response.ContentType = "application/pdf";
    //        System.Web.HttpContext.Current.Response.TransmitFile(myfile.FullName);
    //        System.Web.HttpContext.Current.Response.End();
    //    }
    //}
}