using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleDemo
{
    class ref_Out
    {

    }
   public    class Ref_Key
    {
      public  void call()
        {
            int num =10;
            MyMethodRef(ref num);
            Console.WriteLine("Value Outer Method : {0}", num);

        }

        private static void MyMethodRef(ref int number)
        {
            number += 20;
            Console.WriteLine("Value Inner Method : {0}", number);
        }
    }
    public class Out_Ket
    {
        public void call()
        {
            int num = 10;
            
            MyMethodOut(out num);
            Console.WriteLine("Value Outer Method : {0}", num);

        }

        private static void MyMethodOut(out int number)
        {
           number = 20;
            Console.WriteLine("Value Inner Method : {0}", number);
        }
    }


}
