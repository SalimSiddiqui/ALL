﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfEmpService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Emp : IEmpService
    {
        public void DoWork()
        {
        }

        public string Sayhello(string name)
        {
            return "Hello :-" + name;
        }
    }
}
