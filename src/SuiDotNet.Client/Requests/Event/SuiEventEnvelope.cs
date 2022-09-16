using System;
using Newtonsoft.Json;

namespace SuiDotNet.Client.Requests
{
    [Serializable]
    public class BaseEventEnvelope<TTime, TEvent>
    {
        [JsonProperty("timestamp")]
        public TTime Timestamp { get; set; }
        
        [JsonProperty("txDigest")]
        public string TxDigest { get; set; }
        
        [JsonProperty("event")]
        public TEvent Event { get; set; }

        // 'event' is reserved, so disable this warning
        // ReSharper disable InconsistentNaming
        public BaseEventEnvelope(TTime time, string digest, TEvent event_)
        {
            Timestamp = time;
            TxDigest = digest;
            Event = event_;
        }
    }
    
    [Serializable]
    public class SuiEventEnvelope: BaseEventEnvelope<DateTimeOffset, object>
    {
        public SuiEventEnvelope(DateTimeOffset time, string digest, object event_)
            : base(time, digest, event_) { }

        public SuiEventEnvelope(RawSuiEventEnvelope raw)
            : base(
                DateTimeOffset.FromUnixTimeMilliseconds((long) raw.Timestamp),
                raw.TxDigest,
                raw.Event) { }
        
        public override string ToString()
        {
            return $"{{\n\ttimestamp: {Timestamp},\n\ttxDigest: {TxDigest},\n\tevent: {Event}\n}}";
        }
    }
    
    [Serializable]
    public class RawSuiEventEnvelope/*: BaseEventEnvelope<ulong, object>*/
    {
        [JsonProperty("timestamp")]
        public ulong Timestamp { get; set; }
        
        [JsonProperty("txDigest")]
        public string TxDigest { get; set; }
        
        [JsonProperty("event")]
        public object Event { get; set; }

        public RawSuiEventEnvelope(ulong time, string digest, object event_)
            /*: base(time, digest, event_)*/
        {
            Timestamp = time;
            TxDigest = digest;
            Event = event_;
        }
        
        public override string ToString()
        {
            return $"{{\n\ttimestamp: {Timestamp},\n\ttxDigest: {TxDigest},\n\tevent: {Event}\n}}";
        }
    }
    
    // ReSharper enable InconsistentNaming
}