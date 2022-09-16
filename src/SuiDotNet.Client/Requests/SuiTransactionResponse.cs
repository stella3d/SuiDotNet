using System;
using System.Linq;
using Newtonsoft.Json;

namespace SuiDotNet.Client.Requests
{
    [Serializable]
    public class SuiTransactionResponse
    {
        [JsonProperty("certificate")]
        public CertifiedTransaction Certificate { get; set; }
        
        [JsonProperty("effects")]
        public TransactionEffects Effects { get; set; }
        
        [JsonProperty("parsed_data")]
        public SuiParsedTransactionResponse? ParsedData { get; set; }
        
        [JsonProperty("timestamp_ms")]
        public ulong? Timestamp { get; set; }
    }

    [Serializable]
    public class CertifiedTransaction
    {
        [JsonProperty("transactionDigest")]
        public string TransactionDigest { get; set; }

        [JsonProperty("data")]
        public object Data { get; set; }
        
        [JsonProperty("txSignature")]
        public string Signature { get; set; }
        
        [JsonProperty("authSignInfo")]
        public AuthorityQuorumSignInfo AuthoritySignInfo { get; set; }
    }

    public class SuiParsedTransactionResponse
    {
        public object? Publish;
        public object? MergeCoin;
        public object? SplitCoin;
    }
    
    [Serializable]
    public class TransactionEffects
    {
        [JsonProperty("status")]
        public ExecutionStatus Status { get; set; }
        
        [JsonProperty("transactionDigest")]
        public string TransactionDigest { get; set; }
        
        [JsonProperty("gasObject")]
        public SuiObjectReference GasObject { get; set; }
        [JsonProperty("gasUsed")]
        public object GasUsed { get; set; }
        
        [JsonProperty("created")]
        public object[]? Created { get; set; }
        [JsonProperty("deleted")]
        public object[]? Deleted { get; set; }
        [JsonProperty("mutated")]
        public object[]? Mutated { get; set; }
        
        [JsonProperty("dependencies")]
        public string[]? Dependencies { get; set; }
        
        [JsonProperty("events")]
        public object[]? Events { get; set; }
        
        [JsonProperty("sharedObjects")]
        public SuiObjectReference[]? SharedObjects { get; set; }
        
        [JsonProperty("wrapped")]
        public SuiObjectReference[]? Wrapped { get; set; }
        [JsonProperty("unwrapped")]
        public SuiObjectReference[]? Unwrapped { get; set; }
    }

    [Serializable]
    public class ExecutionStatus
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("error")]
        public string? Error { get; set; }
    }
    
    [Serializable]
    public class AuthorityQuorumSignInfo
    {
        [JsonProperty("epoch")]
        public ulong Epoch { get; set; }
        
        [JsonProperty("signature")]
        public string[] Signature { get; set; }

        // TODO - this encoding needs to be changed to base64 string instead of byte array on sui side
        [JsonProperty("signers_map")]
        public byte[] SignersMap { get; set; }

        public override string ToString()
        {
            var sigLines = $"[\n\t{string.Join("\n\t", Signature)}\n]";
            var mapLine = $"[{string.Join(',', SignersMap)}]";
            return $"epoch: {Epoch},\nsignature: {sigLines},\nsignersMap: {mapLine}";
        }
    }
}