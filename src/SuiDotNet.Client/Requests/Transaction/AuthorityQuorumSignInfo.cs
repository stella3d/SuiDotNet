using System;
using Newtonsoft.Json;

namespace SuiDotNet.Client.Requests
{
    [Serializable]
    public class AuthorityQuorumSignInfo
    {
        [JsonProperty("epoch")]
        public ulong Epoch { get; set; }
        
        [JsonProperty("signature")]
        public string[] Signature { get; set; }

        // TODO - this encoding needs to be changed to base64 string instead of byte array on sui side
        [JsonProperty("signers_map")]
        public byte[] SignersMap { get; set;  }

        public AuthorityQuorumSignInfo(ulong epoch, string[] sig, byte[] signersMap)
        {
            Epoch = epoch;
            Signature = sig;
            SignersMap = signersMap;
        }

        public override string ToString()
        {
            var sigLines = $"[\n\t{string.Join(",\n\t", Signature)}\n]";
            var mapLine = $"[{string.Join(',', SignersMap)}]";
            return $"{{\n  epoch: {Epoch},\n  signature: {sigLines},\nsignersMap: {mapLine}";
        }
    }
}