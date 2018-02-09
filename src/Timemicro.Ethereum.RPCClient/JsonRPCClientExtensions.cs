using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Timemicro.Ethereum.RPCClient.DTO;
using Timemicro.Ethereum.RPCClient.Methods;
using TimemicroCore.Ethereum.Hex.HexTypes;

namespace Timemicro.Ethereum.RPCClient
{
    public static class JsonRPCClientExtensions
    {
        private const long towei = 1000000000000000000;
        public static readonly BigInteger DEFAULT_GAS_PRICE = BigInteger.Parse("20000000000");
        public static readonly BigInteger DEFAULT_GAS_LIMIT = BigInteger.Parse("21000");

        /// <summary>
        /// 创建账号，
        /// </summary>
        /// <param name="client"></param>
        /// <param name="passphrase">密码必填</param>
        /// <returns></returns>
        public static string NewAccount(this JsonRPCClient client, string passphrase)
        {
            if (client != null && !string.IsNullOrWhiteSpace(passphrase))
            {
                var resp = client.Call<GetNewAccountResponse>(JsonRPCMethods.personal_newAccount.ToString(), new GetNewAccountParams(passphrase));
                if (resp != null)
                {
                    return resp.Result;
                }
            }
            return null;
        }

        /// <summary>
        /// 解锁账户,解锁时间30秒
        /// </summary>
        /// <param name="client"></param>
        /// <param name="address"></param>
        /// <param name="passphrase"></param>
        /// <returns></returns>
        public static bool UnlockAccount(this JsonRPCClient client, string address, string passphrase, int duration = 30)
        {
            if (client != null && !string.IsNullOrWhiteSpace(passphrase))
            {
                var resp = client.Call<UnlockAccountResponse>(JsonRPCMethods.personal_unlockAccount.ToString(), new UnlockAccountParams(address, passphrase, duration));
                if (resp != null)
                {
                    return resp.Result;
                }
            }
            return false;
        }

        /// <summary>
        /// 获取账号的余额
        /// </summary>
        /// <param name="client"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public static string GetBalance(this JsonRPCClient client, string address)
        {
            if (client != null && !string.IsNullOrWhiteSpace(address))
            {
                var resp = client.Call<GetBalanceResponse>(JsonRPCMethods.eth_getBalance.ToString(), new GetBalanceParams(address, "latest"));
                if (resp != null)
                {
                    return resp.Result;
                }
            }
            return null;
        }

        /// <summary>
        /// 获取用户账号列表
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static List<string> ListAccount(this JsonRPCClient client)
        {
            if (client != null)
            {
                var resp = client.Call<GetAccountsResponse>(JsonRPCMethods.eth_accounts.ToString(), new GetAccountsParams());
                if (resp != null)
                {
                    return resp.Result;
                }
            }

            return null;
        }

        /// <summary>
        /// 返回最新块的数目。
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static string BlockNumber(this JsonRPCClient client)
        {
            if (client != null)
            {
                var resp = client.Call<BlockNumberResponse>(JsonRPCMethods.eth_blockNumber.ToString(), new BlockNumberParams());
                if (resp != null)
                {
                    return resp.Result;
                }
            }

            return null;
        }

        /// <summary>
        /// 根据块编号返回块信息
        /// </summary>
        /// <param name="client"></param>
        /// <param name="blocknumber">nteger of a block number, or the string "earliest", "latest" or "pending", as in the default block parameter.</param>
        /// <returns></returns>
        public static BlockDTO GetBlockByNumber(this JsonRPCClient client, string blocknumber)
        {
            if (client != null)
            {
                var resp = client.Call<GetBlockByNumberResponse>(JsonRPCMethods.eth_getBlockByNumber.ToString(), new GetBlockByNumberParams(blocknumber, false));
                if (resp != null)
                {
                    return resp.Result;
                }
            }

            return null;
        }

        /// <summary>
        /// 根据块的hash值返回块信息
        /// </summary>
        /// <param name="client"></param>
        /// <param name="blockhash">nteger of a block number, or the string "earliest", "latest" or "pending", as in the default block parameter.</param>
        /// <returns></returns>
        public static BlockDTO GetBlockByHash(this JsonRPCClient client, string blockhash)
        {
            if (client != null)
            {
                var resp = client.Call<GetBlockByHashResponse>(JsonRPCMethods.eth_getBlockByHash.ToString(), new GetBlockByHashParams(blockhash, false));
                if (resp != null)
                {
                    return resp.Result;
                }
            }

            return null;
        }

        /// <summary>
        /// 获取交易信息
        /// </summary>
        /// <param name="client"></param>
        /// <param name="transactionhash"></param>
        /// <returns></returns>
        public static TransactionDTO GetTransactionByHash(this JsonRPCClient client, string transactionhash)
        {
            if (client != null)
            {
                var resp = client.Call<GetTransactionByHashResponse>(JsonRPCMethods.eth_getTransactionByHash.ToString(), new GetTransactionByHashParams(transactionhash));
                if (resp != null)
                {
                    return resp.Result;
                }
            }

            return null;
        }

        /// <summary>
        /// 获取交易回执单，只有交易成功的才有返回值，否则为null
        /// </summary>
        /// <param name="client"></param>
        /// <param name="transactionhash"></param>
        /// <returns></returns>
        public static TransactionReceiptDTO GetTransactionReceipt(this JsonRPCClient client, string transactionhash)
        {
            if (client != null)
            {
                var resp = client.Call<GetTransactionReceiptResponse>(JsonRPCMethods.eth_getTransactionReceipt.ToString(), new GetTransactionReceiptParams(transactionhash));
                if (resp != null)
                {
                    return resp.Result;
                }
            }

            return null;
        }

        private static void SetDefaultGasPriceAndCostIfNotSet(SendTransactionParams transactionInput)
        {
            if (DEFAULT_GAS_LIMIT != null)
            {
                if (transactionInput.Gas == null) transactionInput.Gas = new HexBigInteger(DEFAULT_GAS_LIMIT).HexValue;
            }

            if (DEFAULT_GAS_PRICE != null)
            {
                if (transactionInput.GasPrice == null) transactionInput.GasPrice = new HexBigInteger(DEFAULT_GAS_PRICE).HexValue;
            }
        }

        /// <summary>
        /// 获取交易回执单，只有交易成功的才有返回值，否则为null
        /// </summary>
        /// <param name="client"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="value"></param>
        /// <param name="gas">默认值21000，</param>
        /// <param name="gasprice">默认值为20000000000</param>
        /// <returns></returns>
        public static string SendTransaction(this JsonRPCClient client, string from, string to, decimal value, long? gas=null, long? gasprice = null)
        {
            if (client != null && !string.IsNullOrWhiteSpace(from) && !string.IsNullOrWhiteSpace(to))
            {
                var param = new SendTransactionParams();
                param.From = from;
                param.To = to;

                if (gas > 0)
                {
                    param.Gas = new HexBigInteger(BigInteger.Parse(gas.Value.ToString("f0"))).HexValue;
                }
                if (gasprice > 0)
                {
                    param.GasPrice = new HexBigInteger(BigInteger.Parse(gasprice.Value.ToString("f0"))).HexValue;
                }
                SetDefaultGasPriceAndCostIfNotSet(param);

                param.Value = value.ToWeiHex();

                var resp = client.Call<SendTransactionResponse>(JsonRPCMethods.eth_sendTransaction.ToString(), param);

                if (resp != null)
                {
                    return resp.Result;
                }
            }

            return null;
        }

        public static decimal HexToEther(this string val)
        {
            if (!string.IsNullOrWhiteSpace(val))
            {
                return new HexBigInteger(val).HexToEther();
            }
            return 0;
        }

        public static int HexToInt(this string val)
        {
            if (!string.IsNullOrWhiteSpace(val))
            {
                return int.Parse(new HexBigInteger(val).Value.ToString());
            }
            return 0;
        }

        public static string ToWeiHex(this decimal value)
        {
            return value.EtherToWeiHex();
        }

        public static string ToHex(this int value)
        {
            return new HexBigInteger(BigInteger.Parse(value.ToString())).HexValue;
        }
    }
}
