using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
namespace TransactionWCF
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(DataAccess.TransactionService)))
            {
                host.Open();
                Console.WriteLine("started at@"+DateTime.Now);
                Console.ReadKey();
            }
        }
    }
}
