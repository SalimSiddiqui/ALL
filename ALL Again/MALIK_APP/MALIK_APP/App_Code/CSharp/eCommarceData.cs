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
using System.Text;
using System.Collections;

/// <summary>
/// Summary description for eCommarce
/// </summary>
public class eCommarceData
{
    public static StringBuilder builder;
    public eCommarceData()
	{
		
	}
    public static string CreateMenu()
    {
        builder = new StringBuilder();
        builder.Append(" <script type='text/javascript'>  " +
 "  " +
  "  stm_bm(['menu61b2',900,'','../menu22/blank.gif',0,'','',1,0,250,0,1000,1,0,0,'','',0,0,1,2,'hand','hand','',1,25],this);" +
  "   stm_bp('p0',[0,4,0,0,0,0,0,0,100,'',-2,'',-2,50,0,0,'#799BD8','transparent','',3,0,0,'#000000']);" +
  "  stm_ai('p0i0',[0,'Home','','',-1,-1,0,'../Member/index.aspx','_self','','','','',0,0,0,'','',0,0,0,1,1,'#FFFFF7',1,'#FFFFF7',1,'../menu22/menu_bg.png','../menu22/over.png',3,3,0,0,'#FFFFF7','#000000','#FFFFFF','#FFFFFF','bold 9pt Arial','bold 9pt Arial',0,0,'','','','',0,0,0],68,33);  " +
  "  stm_aix('p0i1','p0i0',[0,'About Us','','',-1,-1,0,'../Member/about.aspx'],68,33);   " +
  "  stm_aix('p0i2','p0i0',[0,'Products','','',-1,-1,0,'../Member/product.aspx','_self','','','','',0,0,0,'','',-1,-1,0,1,1,'#FFFFF7',1,'#FFFFF7',1,'../menu22/menu_bg.png','../menu22/over1.png'],100,33); " +
  "   stm_bp('p1',[1,4,0,0,0,0,14,0,100,'',-2,'',-2,80,0,0,'#799BD8','transparent','',0,0,0,'#CCCCCC #B2B2B2 #B2B2B2']); ");

        //string n = ds.Tables[0].TableName;
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    builder.Append("stm_aix('p1i0','p0i0',[0,'" + ds.Tables[0].Rows[0]["Name"].ToString() + "','','',-1,-1,0,'../eCommarce/FindProduct.aspx?ProId=" + ds.Tables[0].Rows[0]["ItemCode"].ToString() + "','_self','','','../menu22/p_white.gif','../menu22/icon_82.gif',14,7,0,'','',0,0,0,0,1,'#B7B7B7',1,'#CCCCCC',1,'../menu22/tree_11.png','../menu22/tree_11_hover.png',3,3,0,0,'#FFFFCC','#CCCC00','#FFFFFF','#FFFFFF','8pt Arial','bold 8pt Arial'],149,25);");
        //    try
        //    {

        //        for (int i = 1; i < ds.Tables[0].Rows.Count; i++)
        //        {
        //            string g = ds.Tables[0].Rows[i]["ItemCode"].ToString();
        //            builder.Append("stm_aix('p1i1','p1i0',[0,'" + ds.Tables[0].Rows[i]["Name"].ToString() + "','','',-1,-1,0,'../eCommarce/FindProduct.aspx?ProId=" + ds.Tables[0].Rows[i]["ItemCode"].ToString() + "'],149,25);");
        //        }
              
        //    }
        //    catch { }

        //}
        builder.Append("  stm_aix('p1i3','p0i0',[0,'','','',-1,-1,0,'','_self','','','','',10,7,0,'','',0,0,0,0,1,'#FFFFFF',1,'#FFFFFF',1,'../menu22/tree22.png','../menu22/tree22.png',3,3,0,0,'#FFFFCC','#CCCC00','#333333','#009900','8pt Verdana','8pt Verdana'],149,7);" +
  " stm_ep(); " +
   "  stm_aix('p0i3','p0i0',[0,'Business Plan','','',-1,-1,0,'#','_self','','','','',0,0,0,'','',-1,-1,0,1,1,'#FFFFF7',1,'#FFFFF7',1,'../menu22/menu_bg.png','../menu22/over1.png'],100,33); stm_bp('p2',[1,4,0,0,0,0,14,0,100,'',-2,'',-2,80,0,0,'#799BD8','transparent','',0,0,0,'#CCCCCC #B2B2B2 #B2B2B2']); " +
   "  stm_aix('p2i0','p1i0',[0,'Referral Income','','',-1,-1,0,'../Member/ref_income.aspx','_self','','','../menu22/p_white.gif','../menu22/icon_82.gif',14,7,0,'','',0,0,0,0,1,'#B7B7B7',1,'#CCCCCC',1,'../menu22/tree_11.png','../menu22/tree_11_hover.png',3,3,0,0,'#FFFFCC','#CCCC00','#FFFFFF','#FFFFFF','8pt Arial','bold 8pt Arial'],149,25); " +
   "  stm_aix('p2i1','p1i0',[0,'Binary Income','','',-1,-1,0,'../Member/binary.aspx'],149,25);" +
   "   stm_aix('p2i2','p1i0',[0,'Join Option / How to Join','','',-1,-1,0,'join.aspx'],149,25); " +
   "   stm_aix('p2i3','p1i0',[0,'Commission','','',-1,-1,0,'../Member/commission.aspx'],149,25); " +
   "   stm_aix('p2i4','p1i0',[0,'Rewards','','',-1,-1,0,'../Member/reward.aspx'],149,25); " +
   "   stm_aix('p2i5','p1i0',[0,'Bonanza','','',-1,-1,0,'../Member/bonanza.aspx'],149,25); " +
   "   stm_aix('p2i6','p1i0',[0,'Designation','','',-1,-1,0,'../Member/designation.aspx'],149,25); " +
   "   stm_aix('p2i7','p1i0',[0,'','','',-1,-1,0,'','_self','','','','',10,7,0,'','',0,0,0,0,1,'#FFFFFF',1,'#FFFFFF',1,'../menu22/tree22.png','../menu22/tree22.png',3,3,0,0,'#FFFFCC','#CCCC00','#333333','#009900','8pt Verdana','8pt Verdana'],149,7); stm_ep();" +
   "    stm_aix('p0i4','p0i2',[0,'Our Stores','','',-1,-1,0,'../Member/store.aspx'],80,33); " +
   "    stm_aix('p0i5','p0i2',[0,'Hot Deals','','',-1,-1,0,'../Member/deals.aspx'],80,33);" +
   "     stm_aix('p0i6','p0i0',[0,'Legal','','',-1,-1,0,'../Member/legal.aspx'],68,33); " +
     "     stm_aix('p0i7','p0i4',[0,'Our Depo ','','',-1,-1,0,'../Member/depo.aspx'],90,33); " +
   "    stm_aix('p0i8','p0i4',[0,'Our Bankers','','',-1,-1,0,'../Member/banker.aspx'],90,33); " +
      "     stm_aix('p0i9','p0i4',[0,'Downloads','','',-1,-1,0,'../Member/download.aspx'],90,33); " +
   "     stm_aix('p0i10','p0i2',[0,'Contact Us','','',-1,-1,0,'../Member/contact.aspx'],90,33); stm_ep(); stm_em();  " +     
   "       " +
    "     </script>");
        return builder.ToString();

    }
    public static void FillCartGrid(GridView Grd, ArrayList arr)
    {
        if (arr == null)
            return;
        Grd.DataSource = arr;
        Grd.DataBind();
        double total = 0, Qty = 0;
        for (int i = 0; i < arr.Count; i++)
        {
            Business b = (Business)arr[i];
            total += b.Sub_Total;
            Qty += b.Pro_Qty;
        }
        try
        {
            ((Label)Grd.FooterRow.FindControl("lbltot")).Text = string.Format("{0:0.0}", total);
            ((Label)Grd.FooterRow.FindControl("lbltotqty")).Text = string.Format("{0:0}", Qty);
        }
        catch { }
    }
  
}
