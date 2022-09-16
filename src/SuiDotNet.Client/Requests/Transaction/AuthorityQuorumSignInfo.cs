using System;
using Newtonsoft.Json;

namespace SuiDotNet.Client.Requests
{
    [Serializable]
    public class AuthorityQuorumSignInfo
    {
        [JsonProperty("epoch")]
        public ulong Epoch { get; }
        
        [JsonProperty("signature")]
        public string[] Signature { get; }

        // TODO - this encoding needs to be changed to base64 string instead of byte array on sui side
        [JsonProperty("signers_map")]
        public byte[] SignersMap { get; }

        public override string ToString()
        {
            var sigLines = $"[\n\t{string.Join("\n\t", Signature)}\n]";
            var mapLine = $"[{string.Join(',', SignersMap)}]";
            return $"epoch: {Epoch},\nsignature: {sigLines},\nsignersMap: {mapLine}";
        }
    }
}