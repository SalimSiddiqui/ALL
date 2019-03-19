using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterfaceCustomer;
namespace Customer
{
    public class SimpleCustomer :ICustomer
    {
        public void Calculate()
        {
            Console.WriteLine( "Simpple");
        }
    }

    public class DsCustomer : ICustomer
    {
        public void Calculate()
        {
            Console.WriteLine("Disc");
        }
    }
}
