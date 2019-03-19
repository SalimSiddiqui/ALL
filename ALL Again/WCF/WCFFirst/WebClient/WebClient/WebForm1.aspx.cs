using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebClient
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btngetmsg_Click(object sender, EventArgs e)
        {
            HelloServiceRef.HelloServiceClient client = new HelloServiceRef.HelloServiceClient("BasicHttpBinding_IHelloService");
            Label1.Text = client.GetMessage(txt.Text); 
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["username"] = "sa";
            Session["pass"] = "0000";

            Response.Redirect("WebForm2.aspx", false);

        }

    }
}