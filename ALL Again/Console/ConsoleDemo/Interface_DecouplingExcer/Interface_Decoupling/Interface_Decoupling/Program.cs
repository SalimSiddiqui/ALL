using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Customer;
using InterfaceCustomer;
using Factory;
namespace Interface_Decoupling
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassFactory cs = new ClassFactory();
            ICustomer IC = null;
            IC = cs.Create(0);
            IC = cs.Create(1);

            Console.WriteLine(cs.Create(0));
            Console.WriteLine(cs.Create(1));

            Console.ReadLine();
        }
    }
}
