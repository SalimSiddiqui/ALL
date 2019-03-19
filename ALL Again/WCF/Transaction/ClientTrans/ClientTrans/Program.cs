using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientTrans.TransactionSer;

namespace ClientTrans
{
    class Program
    {
        static void Main(string[] args)
        {
            TransactionSer.TransactionServiceClient client = new TransactionServiceClient("WSHttpBinding_ITransactionService");
         string name=   client.SaveEmployee("sa");
        }
    }
}
