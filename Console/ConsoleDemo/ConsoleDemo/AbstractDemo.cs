using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleDemo
{
    public interface IA
    {
        void PrintA();
    }

    public interface IB
    {
        void PrintA();
    }
 public   class AbstractDemo1 :  IA,IB
    {
         void IA.PrintA()
        {
            Console.WriteLine("From  IA.PrintA");
        }


         void IB.PrintA()
        {
            Console.WriteLine("From  IB.PrintA");
        }

        public void PrintA()
        {
            Console.WriteLine("Simple PrintA");

        }

    }

    public class MainClass
    {        
        public void Call()
        {

            // We cant call print() IA.print /Ib.print by making object of AbstractDemo class 
            //Bcoz compiler gets Confused which method u r going to call; will have to call by IA Ia = new AbstractDemo();  Ia.PrintA();
            IA Ia = new AbstractDemo1();
            Ia.PrintA();
            IB Ib = new AbstractDemo1();
            Ib.PrintA();
            AbstractDemo1 Ob = new AbstractDemo1();
            Ob.PrintA();

            ///////////////////
            AbstractDemo2 AbstractDemo2 = new AbstractDemo2();

            AbstractDemo2.PrintA();
            AbstractDemo2.PrintB();
        }
    }
    /// <summary>
    /// ///////////////// An other way
    /// </summary>
    public interface IC
    {
        void PrintB();
    }
    public class AbstractDemo2 : IA, IC
    {
        public void PrintA()
        {
            Console.WriteLine("From  IA.PrintA");
        }
        public void PrintB()
        {
            Console.WriteLine("From  IC.PrintB");
        }  

    }

}
