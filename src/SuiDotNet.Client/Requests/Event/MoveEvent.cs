using System;
using Newtonsoft.Json;

namespace SuiDotNet.Client.Requests
{
    [Serializable]
    public class MoveEvent<T>
    {
        [JsonProperty("packageId")]
        public string PackageId { get; }
        
        [JsonProperty("transactionModule")]
        public string TransactionModule { get; }
        
        [JsonProperty("sender")]
        public string Sender { get; }
        
        [JsonProperty("type")]
        public string Type { get; }
        
        [JsonProperty("fields")]
        public T Fields { get; }
        
        [JsonProperty("bcs")]
        public string Bcs { get; }
        
        public MoveEvent(string packageId, string transactionModule, string sender, string type, T fields, string bcs)
        {
            PackageId = packageId;
            TransactionModule = transactionModule;
            Sender = sender;
            Type = type;
            Fields = fields;
            Bcs = bcs;
        }

        public override string ToString()
        {
            return "{\n" +
                   $"  packageId: {PackageId},\n" +
                   $"  transactionModule: {TransactionModule},\n" +
                   $"  sender: {Sender},\n" +
                   $"  type: {Type},\n" +
                   $"  fields: {Fields},\n" +
                   $"  bcs: {Bcs}" +
                   "}";
        }
    }
}