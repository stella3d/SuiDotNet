using System;
using Newtonsoft.Json;

namespace SuiDotNet.Client.Requests
{
    [Serializable]
    public class SuiObjectReference
    {
        [JsonProperty("objectId", Required = Required.Always)]
        public string ObjectId { get; }
        
        [JsonProperty("digest", Required = Required.Always)]
        public string Digest { get; }
        
        [JsonProperty("version", Required = Required.Always)]
        public ulong Version { get; }

        public SuiObjectReference(string objectId, string digest, ulong version)
        {
            ObjectId = objectId;
            Digest = digest;
            Version = version;
        }
        
        public override string ToString()
        {
            return $"{{\n  objectId: {ObjectId},\n  digest: {Digest},\n  version: {Version}\n}}";
        }
    }
}