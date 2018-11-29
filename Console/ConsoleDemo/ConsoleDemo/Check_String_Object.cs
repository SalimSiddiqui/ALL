using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleDemo
{
  public  class Check_String_Object
    {
        public void Print(string p)
        {
            Console.WriteLine("string P");
        }
        public void Print(object p)
        {
            Console.WriteLine("object P");
        }
        public void Print(int p)
        {
            Console.WriteLine("int P");
        }
    }
}
