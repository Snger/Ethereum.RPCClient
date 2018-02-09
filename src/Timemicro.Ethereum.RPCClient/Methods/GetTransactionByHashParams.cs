using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timemicro.Ethereum.RPCClient.Methods
{
    public class GetTransactionByHashParams : JsonRPCRequestParams
    {
        public GetTransactionByHashParams(string hash)
        {
            this.Hash = hash;
        }

        public string Hash
        {
            get { return Get<string>(0); }
            set { Set(0, value); }
        }

    }
}
