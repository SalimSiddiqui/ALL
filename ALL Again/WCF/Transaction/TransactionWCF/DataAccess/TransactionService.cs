using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.Entity;

namespace DataAccess
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TransactionService" in both code and config file together.
    public class TransactionService : ITransactionService
    {
        [OperationBehavior(TransactionScopeRequired=true)]
        public string SaveEmployee(string name)
        {
            return "Hello" + name;           
        }
    }


}
