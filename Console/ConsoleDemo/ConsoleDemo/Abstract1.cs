using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleDemo
{
    public abstract class a1
    {
       public int i;
       public abstract void show();
    }
    public class child : a1
    {
        
       
       public int j;
        public override void show()
        {
            i = 10;
            j = 15;
            
        }
    }
    public class mainclass
    {
       
        
        public void showall()
        {
            a1 Obj1 = new child();
            Obj1.i = 10;
            child Obj2 = new child();
            Obj2.j = 20;
            Console.WriteLine(   );

        }
    }


    interface c1
    {
        string name { get; set; }
    }
}
