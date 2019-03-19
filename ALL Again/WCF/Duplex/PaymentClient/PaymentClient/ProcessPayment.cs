using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.ServiceModel;
using System.Text;
using PaymentClient.PaymentService;

namespace PaymentClient
{
  public  class ProcessPayment
    {

      public void DoProcessing()
      {
          PaymentServiceClient op = new PaymentServiceClient(new InstanceContext(new AcceptCallBack()));
          op.DoPayment(new Payment());
          Console.ReadLine();
      }


    }
}
