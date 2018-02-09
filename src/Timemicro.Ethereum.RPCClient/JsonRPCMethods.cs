using System;

namespace Timemicro.Ethereum.RPCClient
{
    public enum JsonRPCMethods
    {
        net_listening,

        eth_protocolVersion,

        eth_syncing,

        eth_coinbase,

        eth_mining,

        eth_hashrate,

        eth_gasPrice,

        eth_accounts,

        eth_blockNumber,

        eth_getBalance,

        eth_getStorageAt,

        eth_getTransactionCount,

        eth_getBlockTransactionCountByHash,

        eth_getBlockTransactionCountByNumber,

        eth_getUncleCountByBlockHash,

        eth_getUncleCountByBlockNumber,

        eth_getCode,

        eth_sign,

        eth_sendTransaction,

        eth_sendRawTransaction,

        eth_call,

        eth_estimateGas,

        eth_getBlockByHash,

        eth_getBlockByNumber,

        eth_getTransactionByHash,

        eth_getTransactionByBlockHashAndIndex,

        eth_getTransactionByBlockNumberAndIndex,

        eth_getTransactionReceipt,

        eth_getUncleByBlockHashAndIndex,

        eth_getUncleByBlockNumberAndIndex,

        eth_getCompilers,

        eth_compileLLL,

        eth_compileSolidity,

        eth_compileSerpent,

        eth_newFilter,

        eth_newBlockFilter,

        eth_newPendingTransactionFilter,

        eth_uninstallFilter,

        eth_getFilterChanges,

        eth_getFilterLogs,

        eth_getLogs,

        eth_getWork,

        eth_submitWork,

        eth_submitHashrate,

        net_peerCount,

        personal_listAccounts,

        personal_newAccount,

        personal_unlockAccount,

        personal_lockAccount,

        personal_sendTransaction
    }
}
