using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterfaceCustomer;
using Customer;
namespace Factory
{
    public class ClassFactory
    {
        List<ICustomer> list = new List<ICustomer>();
        public ClassFactory()
        {
            list.Add(new SimpleCustomer());
            list.Add(new DsCustomer());
        }
        public ICustomer Create(int i)
        {
            return list[i];
        }
    }
}
