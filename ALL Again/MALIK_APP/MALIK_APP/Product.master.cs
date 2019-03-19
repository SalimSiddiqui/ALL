using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Product : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Fill_DdlCity();
        }
    }
    private void Fill_DdlCity()
    {
        DataSet ds = new DataSet();
        SQL_DB.GetDA("SELECT [CITY_ID] ,[CityName] FROM [CityMaster]").Fill(ds, "1");
        ddlcity.DataSource = ds.Tables[0];
        ddlcity.DataTextField = "CityName";
        ddlcity.DataValueField = "CITY_ID";
        ddlcity.DataBind();
        ddlcity.Items.Insert(0, "--Select--");
    }

}
