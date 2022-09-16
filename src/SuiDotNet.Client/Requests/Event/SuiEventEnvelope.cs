using System;
using Newtonsoft.Json;

namespace SuiDotNet.Client.Requests
{
    [Serializable]
    public class SuiEventEnvelope
    {
        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; }
        
        [JsonProperty("txDigest")]
        public string TxDigest { get; }
        
        [JsonProperty("event")]
        public object Event { get; }

        // 'event' is reserved, so disable this warning
        // ReSharper disable once InconsistentNaming
        public SuiEventEnvelope(ulong time, string digest, object event_)
        {
            Timestamp = DateTimeOffset.FromUnixTimeMilliseconds((long) time);
            TxDigest = digest;
            Event = event_;
        }
    }
}