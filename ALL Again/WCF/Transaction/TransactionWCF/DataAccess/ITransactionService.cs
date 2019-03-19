using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DataAccess
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITransactionService" in both code and config file together.
    [ServiceContract]
    public interface ITransactionService
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        string SaveEmployee(string name);
    }
}
