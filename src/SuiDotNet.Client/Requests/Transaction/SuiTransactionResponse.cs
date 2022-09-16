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
        
        public SuiTransactionResponse(
            CertifiedTransaction cert,
            TransactionEffects effects,
            SuiParsedTransactionResponse? parsed = null,
            ulong? time = null)
        {
            Certificate = cert;
            Effects = effects;
            ParsedData = parsed;
            Timestamp = time;
        }
    }
}