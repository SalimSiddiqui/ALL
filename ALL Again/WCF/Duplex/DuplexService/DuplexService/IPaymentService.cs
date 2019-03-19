using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPaymentService" in both code and config file together.
[ServiceContract(CallbackContract = typeof(ICallBackPaymetDetails))]
public interface IPaymentService
{
	[OperationContract]
	void DoWork();

    [OperationContract]
    void DoPayment(Payment objPayment);

}


public interface ICallBackPaymetDetails
{
     [OperationContract(IsOneWay = true)]
    void SendStatusUpdate(Payment ObjPayment);
}