using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace WcfEmpService
{
    public partial class EmployeeService : ServiceBase
    {
        public EmployeeService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //using (System.ServiceModel.ServiceHost host = new
            //    System.ServiceModel.ServiceHost(typeof(WcfEmpService.EmployeeService)))
            //{
            //    host.Open();
            //    Console.WriteLine("Host started @ " + DateTime.Now.ToString());
            //    Console.ReadLine();
            //}
        }

        protected override void OnStop()
        {
        }
    }
}
