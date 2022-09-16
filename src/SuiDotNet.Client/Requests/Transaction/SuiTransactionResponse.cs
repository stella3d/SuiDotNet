using System;
using Newtonsoft.Json;

namespace SuiDotNet.Client.Requests
{
    [Serializable]
    public class SuiTransactionResponse
    {
        [JsonProperty("certificate", Required = Required.Always)]
        public object Certificate { get; set; }
        
        [JsonProperty("effects", Required = Required.Always)]
        public object Effects { get; }
        
        [JsonProperty("parsed_data", Required = Required.AllowNull)]
        public SuiParsedTransactionResponse? ParsedData { get; set; }
        
        [JsonProperty("timestamp_ms")]
        public ulong? Timestamp { get; set;}
        
        public SuiTransactionResponse(
            object cert,
            object effects,
            SuiParsedTransactionResponse? parsed,
            ulong? time)
        {
            Certificate = cert;
            Effects = effects;
            ParsedData = parsed;
            Timestamp = time;
        }
    }
}