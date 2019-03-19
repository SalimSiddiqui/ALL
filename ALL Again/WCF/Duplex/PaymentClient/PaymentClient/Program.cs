using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using PaymentClient.PaymentService;

namespace PaymentClient
{
    class Program
    {
        static void Main(string[] args)
        {
            new ProcessPayment().DoProcessing();
        }
    }
}
