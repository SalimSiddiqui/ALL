using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DuplexServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            new ProcessPayment().DoProcessing();
        }
    }
}
