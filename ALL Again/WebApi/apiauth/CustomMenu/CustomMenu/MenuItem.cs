using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomMenu
{
  public  class  MenuItem
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public List <MenuItem> Child { get; set; }

        public  List<MenuItem> getMenuItem()
        {
            MenuItem p1 = new MenuItem();
            p1.Name = "google";
            p1.Url = "google.com";
            p1.Child = new List<MenuItem>();
            p1.Child.Add(new MenuItem{ Name = "C1", Url = "bing1.com" }) ;
            p1.Child.Add(new MenuItem { Name = "C2", Url = "bing2.com" } );

            //p1.Child = new List<MenuItem> { new MenuItem { Name = "C1", Url = "bing.com" } };
            //p1.Child = new List<MenuItem> { new MenuItem { Name = "C2", Url = "bing2.com" } };

           


            MenuItem p2 = new MenuItem();
            p2.Name = "youtube";
            p2.Url = "youtue.com";

            p2.Child = new List<MenuItem>();
            p2.Child.Add ( new MenuItem { Name = "C3", Url = "bing3.com" } );
            p2.Child.Add(new MenuItem { Name = "C4", Url = "bing4.com" } );

            List<MenuItem> list = new List<MenuItem>();
            list.Add(p1);
            list.Add(p2);
            return list;
        }

    }
    

}
