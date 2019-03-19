using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PaymentService" in code, svc and config file together.


//need to Explain
[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
public class PaymentService : IPaymentService
{
    public void DoWork()
    {
    }

    /// <summary>
    /// it Helps In Doing Payment 
    /// Instead of the Thread.Sleep we can have Our Actual processing Logic to Process the card.....
    /// </summary>
    /// <param name="objPayment"></param>
    public void DoPayment(Payment objPayment)
    {

        ICallBackPaymetDetails Callbackchannel = OperationContext.Current.GetCallbackChannel<ICallBackPaymetDetails>();
        Callbackchannel.SendStatusUpdate(new Payment() { Status = "A", TransactionID = "2", StatusMessage = "Approved" });
        Thread.Sleep(5000);
        Callbackchannel.SendStatusUpdate(new Payment() { Status = "A", TransactionID = "3", StatusMessage = "Approved" });
        Thread.Sleep(4000);
        Callbackchannel.SendStatusUpdate(new Payment() { Status = "D", TransactionID = "7", StatusMessage = "Declined" });
        Thread.Sleep(6000);
        Callbackchannel.SendStatusUpdate(new Payment() { Status = "C", TransactionID = "4", StatusMessage = "Approved" });
    }
}
