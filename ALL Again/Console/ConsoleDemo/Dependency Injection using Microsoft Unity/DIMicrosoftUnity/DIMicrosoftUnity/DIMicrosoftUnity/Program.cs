using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity.Container;
using Unity;

namespace DIMicrosoftUnity
{
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<Customer>();
            container.RegisterType<IDB,SqlData>();
            container.RegisterType<IDB,OracleData>();
            Customer ob = container.Resolve<Customer>();
            ob.CustomerName = "sal";
            ob.add();
            

        }
    }

    public interface IDB
    {
        void add();
    }
    public class Customer
    {
        IDB _db;
        public string CustomerName { get; set; }
        public void add(IDB db)
        {
            db = _db;
        }
    }

    public class SqlData: IDB
    {
        public void add()
        {
            Console.WriteLine( "SQl Data");    
        }
    }
    public class OracleData :IDB
    {
        public void add()
        {
            Console.WriteLine("Oracle Data");
        }
    }

}
