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
        public object Data { get; }
        
        [JsonProperty("txSignature")]
        public string Signature { get; }
        
        [JsonProperty("authSignInfo")]
        public AuthorityQuorumSignInfo AuthoritySignInfo { get; }
        
        public CertifiedTransaction(string digest, object data, string sig, AuthorityQuorumSignInfo signInfo)
        {
            TransactionDigest = digest;
            Data = data;
            Signature = sig;
            AuthoritySignInfo = signInfo;
        }
    }
}