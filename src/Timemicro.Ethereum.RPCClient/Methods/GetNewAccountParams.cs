using System;
namespace Timemicro.Ethereum.RPCClient.Methods
{
    public class GetNewAccountParams : JsonRPCRequestParams
    {
        public GetNewAccountParams(string passphrase)
        {
            this.Passphrase = passphrase;
        }

        public string Passphrase
        {
            get { return Get<string>(0); }
            set { Set(0, value); }
        }
    }
}
