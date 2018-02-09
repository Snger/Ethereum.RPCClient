using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Timemicro.Ethereum.RPCClient.DTO;

namespace Timemicro.Ethereum.RPCClient.Methods
{
    public class GetBlockByNumberResponse : JsonRPCResponse<BlockDTO>
    {
        public GetBlockByNumberResponse()
        {
        }
    }
}
