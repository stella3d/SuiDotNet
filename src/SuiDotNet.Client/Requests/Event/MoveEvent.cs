using System;
using Newtonsoft.Json;

namespace SuiDotNet.Client.Requests
{
    [Serializable]
    public class MoveEvent<T>: BaseEvent
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        
        [JsonProperty("fields")]
        public T Fields { get; set; }
        
        [JsonProperty("bcs")]
        public string Bcs { get; set; }
        
        public MoveEvent(string packageId, string transactionModule, string sender, string type, T fields, string bcs)
            : base(packageId, transactionModule, sender)
        {
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