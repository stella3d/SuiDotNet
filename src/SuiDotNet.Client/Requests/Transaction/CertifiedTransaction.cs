using System;
using Newtonsoft.Json;

namespace SuiDotNet.Client.Requests
{
    [Serializable]
    public class CertifiedTransaction
    {
        [JsonProperty("transactionDigest")]
        public string TransactionDigest { get; set; }

        [JsonProperty("data")]
        public TransactionData Data { get; set; }
        
        [JsonProperty("txSignature")]
        public string Signature { get; set; }
        
        [JsonProperty("authSignInfo")]
        public AuthorityQuorumSignInfo AuthoritySignInfo { get; set; }
    }
}