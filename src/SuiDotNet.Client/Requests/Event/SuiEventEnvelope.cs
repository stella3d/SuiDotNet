using System;

namespace SuiDotNet.Client.Requests
{
    [Serializable]
    public class SuiEventEnvelope
    {
        public DateTimeOffset Timestamp { get; }
        public string TxDigest { get; }
        public object Event { get; }

        public SuiEventEnvelope(ulong time, string digest, object evnt)
        {
            Timestamp = DateTimeOffset.FromUnixTimeMilliseconds((long) time);
            TxDigest = digest;
            Event = evnt;
        }
    }
}