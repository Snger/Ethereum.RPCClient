using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timemicro.Ethereum.RPCClient.Methods
{
    public class GetBlockByHashParams : JsonRPCRequestParams
    {
        public GetBlockByHashParams(string blockhash, bool hasfulltransaction = false)
        {
            this.BlockHash = blockhash;
            this.hasFullTransaction = hasfulltransaction;
        }

        public string BlockHash { get { return Get<string>(0); } set { Set(0, value); } }

        /// <summary>
        /// If true it returns the full transaction objects, if false only the hashes of the transactions.
        /// </summary>
        public bool hasFullTransaction { get { return Get<bool>(1); } set { Set(1, value); } }
    }
}
