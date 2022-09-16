using System;
using Newtonsoft.Json;

namespace SuiDotNet.Client.Requests
{
    [Serializable]
    public class PublishEvent
    {
        [JsonProperty("sender")]
        public string Sender { get; set; }
        
        [JsonProperty("packageId")]
        public string PackageId { get; set; }
        
        public PublishEvent(string sender, string packageId)
        {
            Sender = sender;
            PackageId = packageId;
        }

        public override string ToString()
        {
            return $"{{\n  sender: {Sender},\n" +
                   $"  packageId: {PackageId}\n}}";
        }
    }
}