using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace ServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {

            using (System.ServiceModel.ServiceHost host = new
            System.ServiceModel.ServiceHost(typeof(WcfEmpService.EmployeeService)))
          
            {
                host.Open();
                Console.WriteLine("Host started @ " + DateTime.Now.ToString());
                Console.ReadLine();
            }
        }
    }
}
