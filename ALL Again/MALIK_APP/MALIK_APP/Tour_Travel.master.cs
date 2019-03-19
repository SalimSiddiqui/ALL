using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Tour_Travel : System.Web.UI.MasterPage
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
        ddlcityfrom.DataSource = ds.Tables[0];
        ddlcityfrom.DataTextField = "CityName";
        ddlcityfrom.DataValueField = "CITY_ID";
        ddlcityfrom.DataBind();
        ddlcityfrom.Items.Insert(0, "--Select--");
        ddlcityto.DataSource = ds.Tables[0];
        ddlcityto.DataTextField = "CityName";
        ddlcityto.DataValueField = "CITY_ID";
        ddlcityto.DataBind();
        ddlcityto.Items.Insert(0, "--Select--");
    }
}
