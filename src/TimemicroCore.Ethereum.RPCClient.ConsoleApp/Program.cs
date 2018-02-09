using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Timemicro.Ethereum.RPCClient;
using Timemicro.Ethereum.RPCClient.Methods;
using TimemicroCore.Ethereum.Hex.HexTypes;

namespace TimemicroCore.Ethereum.RPCClient.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            JsonRPCClient client = new JsonRPCClient("http://192.168.1.123:8101", "Ulysseys", "YourSuperGreatPasswordNumber","123.asd");

            var de = new HexBigInteger("0x8670e9ec6598c0000").HexToEther();

            var decc = "0x8670e9ec6598c0000".HexToEther();

            var list = client.ListAccount();

            if (list != null)
            {
                foreach (var item in list)
                {
                    var balance = client.GetBalance(item);
                    Console.WriteLine($"address[{item}] has {new HexBigInteger(balance).HexToEther()} .");
                }
            }

            var blocknumber = client.BlockNumber();
            Console.WriteLine($"最新块编号 {blocknumber} .");

            if (!string.IsNullOrWhiteSpace(blocknumber))
            {
                var block = client.GetBlockByNumber(blocknumber);
                if (block != null)
                {
                    Console.WriteLine($"block number[{blocknumber}]: {JsonConvert.SerializeObject(block)}");

                    if (block.Transactions != null && block.Transactions.Count > 0)
                    {
                        foreach (var item in block.Transactions)
                        {
                            var transaction = client.GetTransactionByHash(item);

                            if (transaction != null)
                            {
                                Console.WriteLine($"交易【hash {item} 】内容 : {JsonConvert.SerializeObject(transaction)}");
                            }

                            var transactionreceipt = client.GetTransactionReceipt(item);

                            if (transactionreceipt != null)
                            {
                                Console.WriteLine($"交易【hash {item} 】回执单信息 : {JsonConvert.SerializeObject(transactionreceipt)}");
                            }
                        }
                    }
                }
            }

            //转账操作
            if (list.Count > 1)
            {
                //账户解锁
                if (client.UnlockAccount(list[0], client.WalletPassphrase, duration: 60))
                {
                    string transactionHash = client.SendTransaction(list[0], list[1], (decimal)1.555);

                    Console.WriteLine($"转账交易的hash {transactionHash} ");
                }
                else
                {
                    Console.WriteLine($"{list[0]}解锁失败");
                }
            }
        }
    }
}
