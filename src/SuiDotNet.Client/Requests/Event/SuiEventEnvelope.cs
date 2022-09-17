using System;
using Newtonsoft.Json;

namespace SuiDotNet.Client.Requests
{
    [Serializable]
    public class BaseEventEnvelope<TEvent>
    {
        [JsonProperty("timestamp")]
        public ulong Timestamp { get; set; }
        
        [JsonProperty("txDigest")]
        public string TxDigest { get; set; }
        
        [JsonProperty("event")]
        public TEvent Event { get; set; }

        // 'event' is reserved, so disable this warning
        // ReSharper disable InconsistentNaming
        public BaseEventEnvelope(ulong time, string digest, TEvent event_)
        {
            Timestamp = time;
            TxDigest = digest;
            Event = event_;
        }
    }
    
    [Serializable]
    public class SuiEventEnvelope: BaseEventEnvelope<SuiEvent>
    {
        // convenience property for reading what time .Timestamp represents
        public DateTimeOffset DateTime => DateTimeOffset.FromUnixTimeMilliseconds((long)Timestamp);

        public SuiEventEnvelope(ulong time, string digest, SuiEvent event_)
            : base(time, digest, event_) { }

        public override string ToString() =>
            $"{{\n\ttimestamp: {Timestamp},\n\ttxDigest: {TxDigest},\n\tevent: {Event}\n}}";
    }
    
    // ReSharper enable InconsistentNaming
}