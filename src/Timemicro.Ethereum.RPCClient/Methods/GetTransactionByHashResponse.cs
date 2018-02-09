using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timemicro.Ethereum.RPCClient.DTO;

namespace Timemicro.Ethereum.RPCClient.Methods
{
    public class GetTransactionByHashResponse : JsonRPCResponse<TransactionDTO>
    {
    }
}