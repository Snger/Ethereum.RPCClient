using System;
namespace Timemicro.Ethereum.RPCClient.Methods
{
    public class GetBlockByNumberParams : JsonRPCRequestParams
    {
        public GetBlockByNumberParams(string blocknumber, bool hasfulltransaction = false)
        {
            this.BlockNumber = blocknumber;
            this.hasFullTransaction = hasfulltransaction;
        }

        public string BlockNumber { get { return Get<string>(0); } set { Set(0, value); } }

        /// <summary>
        /// If true it returns the full transaction objects, if false only the hashes of the transactions.
        /// </summary>
        public bool hasFullTransaction { get { return Get<bool>(1); } set { Set(1, value); } }
    }
}
