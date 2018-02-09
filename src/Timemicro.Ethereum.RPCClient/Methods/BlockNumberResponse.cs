using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Timemicro.Ethereum.RPCClient.Methods
{
    public class BlockNumberResponse : JsonRPCResponse<string>
    {
        public BlockNumberResponse()
        {
        }
    }
}
