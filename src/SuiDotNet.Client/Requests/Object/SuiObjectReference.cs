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
        
        [JsonProperty("version", Required = Required.DisallowNull)]
        public ulong? Version { get; }

        public SuiObjectReference(string objectId, string digest, ulong? version)
        {
            ObjectId = objectId;
            Digest = digest;
            Version = version;
        }
    }
}