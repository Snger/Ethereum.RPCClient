using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timemicro.Ethereum.RPCClient.Methods;

namespace Timemicro.Ethereum.RPCClient.MSUnitTests
{
    [TestClass]
    public class ListTransactionsTest
    {
        static JsonRPCClient client = new JsonRPCClient("http://192.168.1.123:8101", "Ulysseys", "YourSuperGreatPasswordNumber", "123.asd");

        [TestMethod]
        public void TestBlockNumber()
        {
            var blocknumber = client.BlockNumber();

            Assert.IsNotNull(blocknumber);
        }

        [TestMethod]
        public void TestTransaction()
        {
            var tran = client.GetTransactionByHash("0x02f9b455c4a3afc0b5e6112ed6ef9f21b5f8b13731cd5a4747652ad2213b67d6");

            Assert.IsNotNull(tran);
        }

        [TestMethod]
        public void TestTransactionReceipt()
        {
            var tran = client.GetTransactionReceipt("0x02f9b455c4a3afc0b5e6112ed6ef9f21b5f8b13731cd5a4747652ad2213b67d6");

            Assert.IsNotNull(tran);
        }
    }
}
