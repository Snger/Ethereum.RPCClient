using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timemicro.Ethereum.RPCClient.DTO
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BlockDTO
    {
        /// <summary>
        ///     QUANTITY - the block number. null when its pending block.
        /// </summary>
        [JsonProperty(PropertyName = "number")]
        public string Number { get; set; }

        /// <summary>
        ///     DATA, 32 Bytes - hash of the block.
        /// </summary>
        [JsonProperty(PropertyName = "hash")]
        public string BlockHash { get; set; }

        /// <summary>
        ///     DATA, 32 Bytes - hash of the parent block.
        /// </summary>
        [JsonProperty(PropertyName = "parentHash")]
        public string ParentHash { get; set; }

        /// <summary>
        ///     DATA, 8 Bytes - hash of the generated proof-of-work. null when its pending block.
        /// </summary>
        [JsonProperty(PropertyName = "nonce")]
        public string Nonce { get; set; }

        /// <summary>
        ///     DATA, 32 Bytes - SHA3 of the uncles data in the block.
        /// </summary>
        [JsonProperty(PropertyName = "sha3Uncles")]
        public string Sha3Uncles { get; set; }

        /// <summary>
        ///     DATA, 256 Bytes - the bloom filter for the logs of the block. null when its pending block.
        /// </summary>
        [JsonProperty(PropertyName = "logsBloom")]
        public string LogsBloom { get; set; }

        /// <summary>
        ///     DATA, 32 Bytes - the root of the transaction trie of the block.
        /// </summary>
        [JsonProperty(PropertyName = "transactionsRoot")]
        public string TransactionsRoot { get; set; }

        /// <summary>
        ///     DATA, 32 Bytes - the root of the final state trie of the block.
        /// </summary>
        [JsonProperty(PropertyName = "stateRoot")]
        public string StateRoot { get; set; }

        /// <summary>
        ///     DATA, 32 Bytes - the root of the receipts trie of the block.
        /// </summary>
        [JsonProperty(PropertyName = "receiptsRoot")]
        public string ReceiptsRoot { get; set; }

        /// <summary>
        ///     DATA, 20 Bytes - the address of the beneficiary to whom the mining rewards were given.
        /// </summary>
        [JsonProperty(PropertyName = "miner")]
        public string Miner { get; set; }

        /// <summary>
        ///     QUANTITY - integer of the difficulty for this block.
        /// </summary>
        [JsonProperty(PropertyName = "difficulty")]
        public string Difficulty { get; set; }

        /// <summary>
        ///     QUANTITY - integer of the total difficulty of the chain until this block.
        /// </summary>
        [JsonProperty(PropertyName = "totalDifficulty")]
        public string TotalDifficulty { get; set; }

        /// <summary>
        ///     DATA - the "extra data" field of this block.
        /// </summary>
        [JsonProperty(PropertyName = "extraData")]
        public string ExtraData { get; set; }

        /// <summary>
        ///     QUANTITY - integer the size of this block in bytes.
        /// </summary>
        [JsonProperty(PropertyName = "size")]
        public string Size { get; set; }

        /// <summary>
        ///     QUANTITY - the maximum gas allowed in this block.
        /// </summary>
        [JsonProperty(PropertyName = "gasLimit")]
        public string GasLimit { get; set; }

        /// <summary>
        ///     QUANTITY - the total used gas by all transactions in this block.
        /// </summary>
        [JsonProperty(PropertyName = "gasUsed")]
        public string GasUsed { get; set; }

        /// <summary>
        ///     QUANTITY - the unix timestamp for when the block was collated.
        /// </summary>
        [JsonProperty(PropertyName = "timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("transactions")]
        public List<string> Transactions { get; set; }

        /// <summary>
        ///     Array - Array of uncle hashes.
        /// </summary>
        [JsonProperty(PropertyName = "uncles")]
        public string[] Uncles { get; set; }
    }
}
