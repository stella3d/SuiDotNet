using System;
using Newtonsoft.Json;

namespace SuiDotNet.Client.Requests
{
    [Serializable]
    public class BaseEventEnvelope<TTime, TEvent>
    {
        [JsonProperty("timestamp")]
        public TTime Timestamp { get; }
        
        [JsonProperty("txDigest")]
        public string TxDigest { get; }
        
        [JsonProperty("event")]
        public TEvent Event { get; }

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
    }
    
    [Serializable]
    public class RawSuiEventEnvelope: BaseEventEnvelope<ulong, object>
    {
        public RawSuiEventEnvelope(ulong time, string digest, object event_)
            : base(time, digest, event_) { }
    }
    
    // ReSharper enable InconsistentNaming
}