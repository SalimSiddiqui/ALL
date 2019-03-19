using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterfaceCustomer;
using Customers;
namespace Factory
{
    public class FactoryCustomer
    {
        public List<ICustomer> List = new List<ICustomer>();
        public FactoryCustomer()
        {
            List.Add(new SimpleCustomer());
            List.Add(new DiscountCustomer());

        }

        public ICustomer Create(int i)
        {

            return List[i];
            //if (i == 1)
            //{
            //    return new SimpleCustomer();

            //}
            //else
            //{
            //    return new DiscountCustomer();
            //}
        }
    }
}
