using System;
using Newtonsoft.Json;

namespace SuiDotNet.Client.Requests
{
    [Serializable]
    public class DeleteObjectEvent: BaseEvent
    {
        [JsonProperty("objectId")]
        public string ObjectId { get; set; }
        
        public DeleteObjectEvent(string packageId, string transactionModule, string sender, string objId)
            : base(packageId, transactionModule, sender)
        {
            ObjectId = objId;
        }

        public override string ToString()
        {
            return "{\n" +
                   $"  packageId: {PackageId},\n" +
                   $"  transactionModule: {TransactionModule},\n" +
                   $"  sender: {Sender},\n" +
                   $"  objectId: {ObjectId}\n" +
                   "}";
        }
    }
}