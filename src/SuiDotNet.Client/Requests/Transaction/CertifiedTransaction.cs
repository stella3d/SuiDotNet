using System;
using Newtonsoft.Json;

namespace SuiDotNet.Client.Requests
{
    [Serializable]
    public class CertifiedTransaction
    {
        [JsonProperty("transactionDigest")]
        public string TransactionDigest { get; }

        [JsonProperty("data")]
        public TransactionData Data { get; }
        
        [JsonProperty("txSignature")]
        public string Signature { get; }
        
        [JsonProperty("authSignInfo")]
        public AuthorityQuorumSignInfo AuthoritySignInfo { get; }
    }
}