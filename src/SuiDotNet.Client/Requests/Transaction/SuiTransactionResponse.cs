using System;
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
    public class SuiParsedTransactionResponse
    {
        public object? Publish { get; set; }
        public object? MergeCoin { get; set; }
        public object? SplitCoin { get; set; }
    }
}