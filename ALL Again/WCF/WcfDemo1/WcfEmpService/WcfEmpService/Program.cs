using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace WcfEmpService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            //ServiceBase[] ServicesToRun;
            //ServicesToRun = new ServiceBase[] 
            //{ 
            //    new EmployeeService() 
            //};
            //ServiceBase.Run(ServicesToRun);


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
