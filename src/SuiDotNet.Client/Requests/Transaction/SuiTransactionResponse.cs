using System;
using Newtonsoft.Json;

namespace SuiDotNet.Client.Requests
{
    [Serializable]
    public class SuiTransactionResponse
    {
        [JsonProperty("certificate")]
        public CertifiedTransaction Certificate { get; }
        
        [JsonProperty("effects")]
        public TransactionEffects Effects { get; }
        
        [JsonProperty("parsed_data")]
        public SuiParsedTransactionResponse? ParsedData { get; }
        
        [JsonProperty("timestamp_ms")]
        public ulong? Timestamp { get; }
    }

    [Serializable]
    public class SuiParsedTransactionResponse
    {
        public object? Publish { get; }
        public object? MergeCoin { get; }
        public object? SplitCoin { get; }
    }
}