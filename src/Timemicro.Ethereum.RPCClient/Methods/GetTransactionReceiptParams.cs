using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timemicro.Ethereum.RPCClient.Methods
{
    public class GetTransactionReceiptParams : JsonRPCRequestParams
    {
        public GetTransactionReceiptParams(string transactionhash)
        {
            this.TransactionHash = transactionhash;
        }

        public string TransactionHash
        {
            get { return Get<string>(0); }
            set { Set(0, value); }
        }

    }
}
