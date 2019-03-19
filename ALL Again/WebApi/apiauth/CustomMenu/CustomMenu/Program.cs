using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            
            CustomMenu.MenuItem ob = new MenuItem();
            List<MenuItem> list = ob.getMenuItem();            
            List<MenuItem> Childd = null;
            for (int i = 0; i < list.Count; i++)
            {
                MenuItem mainm = list[i];
                Console.WriteLine(" ---------------" );                
                    Console.WriteLine(mainm.Name);
                    Console.WriteLine(mainm.Url);
                    Childd = mainm.Child;
                    if (Childd.Count > 0)
                    {
                        rect(mainm.Child);
                    }
            }
            Console.ReadKey();

        }
        public static void rect(List<MenuItem> Child)
        {          
            foreach (var item in Child)
            {
                Console.WriteLine("\t");
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Url);
                if (item.Child!=null && item.Child.Count>0)
                {
                    rect(item.Child);
                }
            }
        }
    }
}
