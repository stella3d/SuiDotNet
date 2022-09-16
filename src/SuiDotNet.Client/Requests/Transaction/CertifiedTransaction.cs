using System;
using Newtonsoft.Json;

namespace SuiDotNet.Client.Requests
{
    [Serializable]
    public class CertifiedTransaction
    {
        [JsonProperty("transactionDigest", Required = Required.Always)]
        public string TransactionDigest { get; set; }

        [JsonProperty("data", Required = Required.Always)]
        public object Data { get; }
        
        [JsonProperty("txSignature", Required = Required.Always)]
        public string Signature { get; set; }
        
        [JsonProperty("authSignInfo", Required = Required.Always)]
        public AuthorityQuorumSignInfo AuthoritySignInfo { get; set; }
        
        public CertifiedTransaction(string digest, object data, string sig, AuthorityQuorumSignInfo signInfo)
        {
            TransactionDigest = digest;
            Data = data;
            Signature = sig;
            AuthoritySignInfo = signInfo;
        }
    }
}