using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timemicro.Ethereum.RPCClient.Methods
{
    public class UnlockAccountParams : JsonRPCRequestParams
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <param name="passphrase"></param>
        /// <param name="duration">单位秒</param>
        public UnlockAccountParams(string address, string passphrase, int duration)
        {
            this.Address = address;
            this.Passphrase = passphrase;
            this.Duration = duration;
        }

        public string Address
        {
            get { return Get<string>(0); }
            set { Set(0, value); }
        }

        public string Passphrase
        {
            get { return Get<string>(1); }
            set { Set(1, value); }
        }

        public int Duration
        {
            get { return Get<int>(2); }
            set { Set(2, value); }
        }
    }
}
