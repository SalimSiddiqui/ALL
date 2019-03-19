using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DuplexServiceClient.PaymentService;

namespace DuplexServiceClient
{
    class AcceptCallBack : IPaymentServiceCallback
    {
        public void SendStatusUpdate(Payment ObjPayment)
        {
            Console.Write(GetStatusString(ObjPayment));
        }


        public string GetStatusString(Payment Obj)
        {
            return Obj.Status + " " + Obj.StatusMessage + " " + Obj.TransactionID + Environment.NewLine;
        }
    }
}
