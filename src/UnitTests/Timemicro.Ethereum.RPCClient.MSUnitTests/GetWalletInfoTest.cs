using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Timemicro.Ethereum.RPCClient.Methods;

namespace Timemicro.Ethereum.RPCClient.MSUnitTests
{
    [TestClass]
    public class GetWalletInfoTest
    {
        static JsonRPCClient client = new JsonRPCClient("http://192.168.1.123:8101", "Ulysseys", "YourSuperGreatPasswordNumber", "123.asd");

        [TestMethod]
        public void TestBalance()
        {
            string result = null;
            var list = client.ListAccount();

            if (list.Count > 0)
            {
                result = client.GetBalance(list[0]);

                Assert.IsNotNull(result);
                return;
            }

            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestUnlockAccount()
        {
            var result = false;
            var list = client.ListAccount();

            if (list.Count > 0)
            {
                result = client.UnlockAccount(list[0], client.WalletPassphrase, duration: 60);

                Assert.IsTrue(result);
                return;
            }

            Assert.IsFalse(result);
        }
    }
}
