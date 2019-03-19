using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace zone_Tree_Calulation
{
    public class Zone_tree
    {
        public static void showdata(LinkButton lnktop, Label lbltop, HtmlImage imgtop, DataSet ds,int index)
        {
            lnktop.Text = ds.Tables["T_ZoneForProgram"].Rows[index]["user_id"].ToString();
            lbltop.Text = ds.Tables["T_ZoneForProgram"].Rows[index]["name"].ToString();
            imgtop.Src = "../images/Green.gif";//
            lnktop.Enabled = false;
            lnktop.ForeColor = System.Drawing.Color.Green;
        }
    }
}