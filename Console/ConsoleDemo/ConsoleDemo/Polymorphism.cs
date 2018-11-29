using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleDemo
{
    public class Polymorphism
    {
        public void add(int a, int b)
        {

        }
        public int add(int a, sbyte b)
        {
            return 0;
        }
        public virtual void adding(int a, sbyte b)
        {
            Console.WriteLine("Polymorphism Base");
        }
    }
    public class polymorphNew : Polymorphism
    {
        public override void adding(int a, sbyte b)
        {
            Console.WriteLine("polymorphNew De");
        }
    }



    public class Polymorphism_Exceptop
    {
        public void add(int a, int b)
        {

        }
        public int add(int a, sbyte b)
        {
            return 0;
        }
        public virtual void adding(int a)
        {
            Console.WriteLine("Polymorphism Base");
        }
    }
    public class polymorphNewExecetion : Polymorphism_Exceptop
    {
        public override void adding(int a)
        {
            Console.WriteLine("polymorphNew De");
        }
        public void adding(object a)
        {
            Console.WriteLine("object a");
        }
    }
}
