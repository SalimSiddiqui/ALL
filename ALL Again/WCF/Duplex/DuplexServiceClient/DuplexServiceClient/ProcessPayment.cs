using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DuplexServiceClient.PaymentService;
using System.ServiceModel;

namespace DuplexServiceClient
{
    public class ProcessPayment
    {

        public void DoProcessing()
        {
            PaymentServiceClient op = new PaymentServiceClient(new InstanceContext(new AcceptCallBack()));
            op.DoPayment(new Payment());
            Console.ReadLine();
        }


    }
}
