using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterfaceCustomer;
namespace Customers
{
    public class SimpleCustomer :ICustomer
    {
        public void Calculate()
        {
            Console.WriteLine("Simple Customer");
        }
    }

    public class DiscountCustomer : ICustomer
    {
        public void Calculate()
        {
            Console.WriteLine("Discount Customer");
        }
    }
}
