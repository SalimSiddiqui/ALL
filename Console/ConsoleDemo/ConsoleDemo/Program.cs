using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleDemo
{
    class AccessMod
    {
        protected int num1=0;
     
    }
    class numbers
    {
        //public numbers()
        //{
        //    Console.WriteLine("Number one value in main");

        //}

        //public numbers(int a)
        //    : this()
        //{
        //    Console.WriteLine("Number one value in main sss");
        //}

        public numbers(int a)
            
        {
            Console.WriteLine("Number one value in main sss");
        }
    }
    class Program 
    {
        //public int num2;
        static void Main(string[] args)
        {
            //string salim = "sa";
            ////string salim = "sa";
            //string EmployeeName = "";
            //string employeename = "";
            //AccessMod ob1 = new AccessMod();
            //Program P = new Program();
            //Direct access to public members

            // numbers a = new numbers(20);
            //Console.WriteLine("Number one value in main {0}", ob1.num1);



            //  new Delegatee.Delegatefirst(); 

            //  new Delegatee.Delegatesec().exefirst();


            //Polymorphism ps;
            //ps = new Polymorphism();
            //ps.adding(0, 0);
            //ps = new polymorphNew();
            //ps.adding(0, 0);

            //Polymorphism_Exceptop ps;
            //ps = new Polymorphism_Exceptop();
            //ps.adding(0);
            //ps = new polymorphNewExecetion();
            //int x = 10;
            //ps.adding(x);


            //if class have overrided and simple method and simple method will be called 
            polymorphNewExecetion ob = new polymorphNewExecetion();
            //ob.adding(10);

            //object a = new object();
            //a = 10;
            //new Check_String_Object().Print(10);
            //new Check_String_Object().Print("10");
            //new Check_String_Object().Print(a);


            //  new Ref_Key().call();
            //Console.WriteLine("-----------");
            //new Out_Ket().call();

            Console.WriteLine("-----------");
            new Ref_Key2().call();

            Console.WriteLine("-----------");
            new Out_Key2().call();

            //string newmap = string.Empty;
            //string map10 = "10104302001480840630010632";
            //int lenCount = map10.Length % 3;
            //if (lenCount>0)
            //{
            //    newmap = map10.Remove(map10.Length - lenCount, lenCount);
            //}

            // int lenCount = map10.Length % 3;

            //Console.WriteLine(map10);
            //Console.WriteLine(map10.Length);

            //Console.WriteLine(newmap);
            //Console.WriteLine(newmap.Length);


            //string nameFull = "code";

            ////string LastChar = nameFull.Remove(nameFull.Length - 1, 1);
            //string LastChar = nameFull.Remove(4);

            //Console.WriteLine("Remaining characters :" + LastChar);

            //CanInstantiateSealedClass obj = new CanInstantiateSealedClass();
            //obj.Print();

            new MainClass().Call();



            Console.ReadLine();
        }
    }
}
