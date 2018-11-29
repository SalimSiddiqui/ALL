using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleDemo.Delegatee
{
    public class studentdata
    {
        public string Name { get; set; }
        public int Mark { get; set; }
        public int act { get; set; }
    }
    public class DelegateDemo1
    {
      
        ////string mostTopperByName 
        /// <summary>
        /// For  if (item.Mark == 100) and  if (item.act == 50) had to write code tiwce (2 method) , we can do in a single bby using del
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// 

        //public string gettopperbymarks(List<studentdata> data)
        //{
        //    string name = string.Empty;
        //    int bestscore;
        //    foreach (var item in data)
        //    {
        //        if (item.Mark == 100)
        //        {
        //            name = item.Name;
        //            bestscore = item.Mark;
        //        }
        //    }
        //    return name;
        //}
        //public string gettopperbyActivity(List<studentdata> data)
        //{
        //    string name = string.Empty;
        //    int bestscore;
        //    foreach (var item in data)
        //    {
        //        if (item.act == 50)
        //        {
        //            name = item.Name;
        //            bestscore = item.Mark;
        //        }
        //    }
        //    return name;
        //}


       
        // Check by dele

      public  delegate bool delCheckByMarks(int i);
      

        public string gettopperbymarks(List<studentdata> data ,delCheckByMarks check)
        {
            string name = string.Empty;
            int bestscore;
            foreach (var item in data)
            {
                if (check(item.Mark))
                {
                    name = item.Name;
                    bestscore = item.Mark;
                }
            }
            return name;
        }
      
    }

    public class Delegatesec
    {

        List<studentdata> data = new List<studentdata>(){ new studentdata {Name="sa",Mark=60 , act=50},new studentdata {Name="sa70",Mark=70,act=10},new studentdata {Name="sa80",Mark=80,act=9},new studentdata {Name="sa90",Mark=100,act=8}};
        DelegateDemo1 f = new DelegateDemo1();
        private bool checkbymarks(int currentmark)
        {
            return currentmark == 100 ? true : false;
        }
        private bool checkbyact(int currentact)
        {
            return currentact == 50 ? true : false;
        }

        public void exefirst()
        {
            //string topperbymarks = f.gettopperbymarks(data);
            //string topperbyact = f.gettopperbyActivity(data);




            string topperbymarks = f.gettopperbymarks(data, checkbymarks);
            string topperbyact = f.gettopperbymarks(data, checkbyact);
            Console.WriteLine("top By mark{0}", topperbymarks);
            Console.WriteLine("top By act{0}", topperbyact);

        }
    }

}
