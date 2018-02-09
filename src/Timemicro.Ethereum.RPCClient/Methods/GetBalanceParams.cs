using System;
namespace Timemicro.Ethereum.RPCClient.Methods
{
    public class GetBalanceParams : JsonRPCRequestParams
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <param name="quantity"> integer block number, or the string "latest", "earliest" or "pending", see the default block parameter</param>
        public GetBalanceParams(string address, string quantity)
        {
            Address = address;
            Quantity = quantity;
        }

        public string Address { get { return Get<string>(0); } set { Set(0, value); } }

        public string Quantity { get { return Get<string>(1); } set { Set(1, value); } }
    }
}
