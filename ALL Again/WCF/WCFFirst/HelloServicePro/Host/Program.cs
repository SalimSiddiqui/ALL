using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (
            System.ServiceModel.ServiceHost host = new ServiceHost(typeof(HelloServicePro.HelloService)))
            {
                host.Open();
                Console.WriteLine("Host Started at" + DateTime.Now.ToString());
                Console.ReadKey();
            }
            
            //HelloServicePro.HelloService client = new HelloServicePro.HelloService();
            //client.GetMessage("a");

        }
    }
}
