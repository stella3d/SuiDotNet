using System;
using Newtonsoft.Json;

namespace SuiDotNet.Client.Requests
{
    [Serializable]
    public class SuiObjectReference
    {
        [JsonProperty("objectId")]
        public string ObjectId { get; }
        [JsonProperty("digest")]
        public string Digest { get; }

        public SuiObjectReference(string objectId, string digest)
        {
            ObjectId = objectId;
            Digest = digest;
        }
    }
}