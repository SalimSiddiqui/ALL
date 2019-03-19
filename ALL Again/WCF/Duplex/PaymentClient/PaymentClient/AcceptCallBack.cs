using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PaymentClient.PaymentService;

namespace PaymentClient
{
    class AcceptCallBack:IPaymentServiceCallback
    {
        public void SendStatusUpdate(Payment ObjPayment)
        {
            Console.Write(GetStatusString(ObjPayment));
        }


        public string GetStatusString(Payment Obj)
        {
            return Obj.Status + " " + Obj.StatusMessage + " " + Obj.TransactionID+Environment.NewLine;
        }
    }
}
