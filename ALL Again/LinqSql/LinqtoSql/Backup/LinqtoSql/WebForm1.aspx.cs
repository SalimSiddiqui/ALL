using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;

namespace LinqtoSql
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SampleDataContext db = new SampleDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
          //var  qry= from person in db.Persons.Take(100)  
          //           select person ;
            //var qry = from a in db.Persons.Skip(1). Take(100)
            //          orderby a.BusinessEntityID 
            //          select new
            //          {
            //             ID= a.BusinessEntityID,
            //             a.FirstName,a.LastName, a.EmailPromotion
            //          };


            //var qry = from a in db.Persons.Take(100)
            //          join b in db.SalesPersons on a.BusinessEntityID equals b.BusinessEntityID 
            //          orderby a.BusinessEntityID
            //          select new
            //          {
            //              ID = a.BusinessEntityID,
            //              a.FirstName,
            //              a.LastName,
            //              a.EmailPromotion,
            //             b.SalesLastYear
            //          };


            var qry = db.ExecuteQuery(typeof(Product), " Select P.*"
        + " FROM Production.Product p"
        + " JOIN Purchasing.ProductVendor pv"
        + " ON p.ProductID = pv.ProductID"
        + " JOIN Purchasing.Vendor v"
        + " ON pv.BusinessEntityID = v.BusinessEntityID"
        + " WHERE ProductSubcategoryID = 15"
        + " ORDER BY v.Name;");
            GridView1.DataSource=qry;
            GridView1.DataBind();
        }
    }
}