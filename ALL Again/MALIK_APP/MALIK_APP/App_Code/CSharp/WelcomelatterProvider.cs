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

/// <summary>
/// Summary description for Welcomelatter
/// </summary>
public class WelcomelatterProvider
{
    public WelcomelatterProvider()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static string GetWelcomelatterString(string user_id)
    {
        string date = "", name = "", address = "", State = "", pass = "", acc_pass = "", sponsor_name = "", sponsor_id = "", Join_Date = "", Ref_id = "", Ref_Name = "", Product_name = "";
       
        DataSet ds = new DataSet();
        SQL_DB.GetDA("SELECT    Registration.name as U_Name ,Registration_1.name AS Ref_Name, Registration.Parent_Id as ref_id,convert(varchar,Registration.reg_date,106) as reg_date2 ,convert(varchar,Registration.reg_date,100) as reg_date, Registration.Acc_pass, Registration.pwd,Registration.address, isnull(Registration.pincode,'') as pincode, Registration.state, Product_master.Product_Name+' ('+convert(varchar,Product_master.Product_Amount)+')' as Product, Registration.sponsor_id, Registration.sponsor_name FROM         Registration INNER JOIN Registration AS Registration_1 ON Registration.Parent_Id = Registration_1.user_id INNER JOIN Product_master ON Registration.product_code = Product_master.Product_Code where Registration.user_id='" + user_id + "'").Fill(ds, "1");
        if (ds.Tables[0].Rows.Count > 0)
        {
            Ref_id = ds.Tables["1"].Rows[0]["ref_id"].ToString();
            Ref_Name = ds.Tables["1"].Rows[0]["Ref_Name"].ToString();
            sponsor_id = ds.Tables["1"].Rows[0]["sponsor_id"].ToString();
            sponsor_name = ds.Tables["1"].Rows[0]["sponsor_name"].ToString();
            address = ds.Tables["1"].Rows[0]["address"].ToString();
            State = ds.Tables["1"].Rows[0]["state"].ToString() + ds.Tables["1"].Rows[0]["pincode"].ToString();
            pass = ds.Tables["1"].Rows[0]["pwd"].ToString();
            acc_pass = ds.Tables["1"].Rows[0]["Acc_pass"].ToString();
            Join_Date = ds.Tables["1"].Rows[0]["reg_date"].ToString();
            date = ds.Tables["1"].Rows[0]["reg_date2"].ToString();
            Product_name = ds.Tables["1"].Rows[0]["Product"].ToString();
            name = ds.Tables["1"].Rows[0]["U_Name"].ToString();
        }

        string Str1 = " <script type=\"text/javascript\"> "+
"function CallPrint12(strid)" +
"{ " +
" var divv = document.getElementById('forprint'); " +
" divv.style.display='block'; "+
" var prtContent = document.getElementById(strid); " +
"var WinPrint = window.open('','','letf=0,top=0,width=700 ,height=600,toolbar=0,scrollbars=0,status=0'); "+
" var content=prtContent.innerHTML; "+
" WinPrint.document.write(content); "+
" WinPrint.document.close(); "+
" WinPrint.focus();"+
" WinPrint.print();"+
" WinPrint.close();"+
" divv.style.display='none'; " +
"} " +
" </script>" +
"<style type=\"text/css\">"+
 ".latter" +
"{"+
"	width:80%;"+
"	border:1px solid #ccc;"+
"	display:inline-block;"+
"	-webkit-box-shadow: #cfd0d0 3px 3px 3px;"+
"	-moz-box-shadow: #cfd0d0 3px 3px 3px; "+
"	box-shadow: #cfd0d0 3px 3px 3px;"+
"	padding:5px;"+
"	margin-left:100px;"+
"}"+
".latter div.w_logo"+
"{"+
"	width:100%;"+
"	margin:0 auto;"+
"	background:url(../images/logo.png) no-repeat; "+
"	background-position:center top;"+
"	height:101px;"+
"	margin-bottom:0px;"+
"   clear:both; "+
"}"+


".latter div.w_logo div.l_head"+
"{"+
"	font-size:15pt;"+
"	color:#222;"+
"	float:right;"+
"	font-weight:bold;"+ 
"	margin-top:5px;"+
"	width:400px;" +
"	height:50px; margin-left:100px;  " +
"}"+
".latter div.w_logo img"+
"{"+
"	height:60px;"+
"	width:130px;"+
"}"+
".latter div.w_frame"+
"{"+
"	width:98%;"+
"	margin:0 auto;"+
"	font-family:Arial, Helvetica, sans-serif;"+
"	font-size:9pt;"+
"	color:#333;"+
"	line-height:20px;"+
"	margin-bottom:10px;"+
"}"+
".latter div.w_frame p"+
"{"+
"	text-align:justify;"+
"	padding-bottom:5px;"+
"}"+
".latter div.w_frame p span"+
"{"+
"	padding-left:20px;"+
"}"+    
".w_detail"+
"{"+
"	padding-left:20px;"+
"	text-align:justify;	"+
"}"+
".w_foot"+
"{"+
"	width:99%;"+
"	padding:5px;"+
"	color:#333;"+
	"font-size:8pt;"+
"	text-align:center;"+
"	line-height:13px;"+
"	margin:0 auto;"+
"} "+
"</style>";



        string str = Str1+ "  <div id=\"maindiv\"> " +
        "<p align=\"right\">" +
         "   <img src=\"http://Propertyebazar.com/images/Print1.png\" alt=\"print\" onclick=\"CallPrint12('maindiv');\" /></p>" +
        "<div class=\"latter\">" +
         "   <div class=\"w_logo\" >" +

          "<div style=\"float:none;\" class=\"l_head\">" +
           " <em style=\"font-size:9pt; font-weight:normal;\"></em></div></div>" +
           "<div id='forprint' style=\"height:0px;display:none\"></div> <hr />" +
           " <div class=\"w_frame\">" +
            "    <p>" +
            "        " +
             "       <strong>Date: </strong>" +
              "      " + date + "<br />" +
               "     <br />" +
               "     <strong>To,<br />" +
                "        <!--<span>Coordinator no : 456789</span><br />-->" +
                 "       <span>Mr." +
                 "           " + name + "</span></strong><br />" +
                 "   <span>" +
                 "       " + address + ",</span><br />" +
               " </p>" +
            "</div>" +
            "<div class=\"w_frame\">" +
             "   <p>" +
              "      <div class=\"w_detail\">" +
               "         <span><strong>Subject:</strong> Welcome Letter of ID No. <strong>" +
                "            " + user_id + "</strong></span><br />" +
                 "       <br />" +
                  "      <span>Dear <em><strong>Mr." +
                   "         " + name + ",</strong></em></span><br />" +
                    "    <br />" +
                    "<span><strong>Warm Regards From Propertyebazar</strong></span>" +
                    "<br />"+
                    "We <em><strong>(Propertyebazar)</strong></em> are delighted you have join us! Your " +
                    "contribution is important to ensure our sustained success and growth. We hope that "+
                    "your career here will be a gratifying one. You would get maximum support from the "+
                    "whole of our team and we look forward to having the best relations with you."+
                    "</div>" +
                "</p>" +
                "<p>" +
                 "   <div class=\"w_detail\">" +
                  "      We hope you will find <em><strong>Propertyebazar</strong></em> as a cool place to work" +
                   "     with. !!" +
                    "</div>" +
                "</p>" +
                "<p>" +
                 "   <div class=\"w_detail\">" +
                  "      Your account details are as follows:-" +
                   "     <table border=\"0\" cellspacing=\"2\">" +
                    "        <tr>" +
                     "           <td width=\"126\" align=\"right\">" +
                      "              <strong>Member ID&nbsp;:&nbsp; </strong>" +
                       "         </td>" +
                        "        <td width=\"282\">" +
                         "          " + user_id + "" +
                          "      </td>" +
                           " </tr>" +
                           " <tr>" +
                            "    <td align=\"right\" valign=\"top\">" +
                             "       <strong>Password&nbsp;:&nbsp;</strong>" +
                              "  </td>" +
                                "<td>" +
                                "    " + pass + "" +
                                "</td>" +
                            "</tr>" +
                            "<tr>" +
                             "   <td align=\"right\" valign=\"top\">" +
                              "      <strong>Account Password :&nbsp;</strong>" +
                              "  </td>" +
                              "  <td> " +
                              "      " + acc_pass +
                              "  </td>" +
                            "</tr>" +
                            "<tr>" +
                             "   <td align=\"right\" valign=\"top\">" +
                              "      <strong>Date of Joining&nbsp;:&nbsp;</strong>" +
                              "  </td>" +
                              "  <td>" +
                              "      " + Join_Date + "" +
                              "  </td>" +
                            "</tr>" +
                            "<tr>" +
                            "    <td align=\"right\" valign=\"top\">" +
                            "        <strong>Upline&nbsp;:&nbsp; </strong>" +
                             "   </td>" +
                             "   <td>" +
                             "      " + sponsor_id +                       
                             "   </td>" +
                            "</tr>" +
                            "<tr>" +
                             "   <td align=\"right\" valign=\"top\">" +
                             "       <strong>Referred By&nbsp;:&nbsp;</strong>" +
                             "   </td>" +
                             "   <td>" +
                             "       " + Ref_id +                         
                              "  </td>" +
                           " </tr>" +
                           " <tr>" +
                            "    <td align=\"right\" valign=\"top\">" +
                            "        <strong>Product Choosen&nbsp;:&nbsp;</strong>" +
                            "    </td>" +
                            "    <td>" +
                            "        " + Product_name +
                            "    </td>" +
                            "</tr>" +
                        "</table>" +
                    "</div>" +
                "</p>" +
               " <p>" +
                "    <div class=\"w_detail\">" +
                 "       Assuring you of our best services always.<br />" +
                 "       Thank you,<br />" +
                 "       <br />" +
                 "       For <em><strong>Propertyebazar,</strong></em><br />" +
                 "       <br />" +
                 "       <br />" +
                 "       Authorised Signatory" +
                 "   </div>" +
               " </p>" +
            "</div>" +
            "<br />" +
            "<hr />" +
            "<br />" +
            "<div class=\"w_foot\">" +
           "     Ph: &nbsp; |&nbsp; Email: support@Propertyebazar.com &nbsp;| &nbsp;Website: http://www.Propertyebazar.com<br />" +
            "</div>" +
            "<br />" +
        "</div> " +
    "</div>";
        return str;
    }
}
