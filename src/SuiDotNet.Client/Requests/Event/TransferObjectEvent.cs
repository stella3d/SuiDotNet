using System;
using Newtonsoft.Json;

namespace SuiDotNet.Client.Requests
{
    [Serializable]
    public class TransferObjectEvent: BaseEvent
    {
        [JsonProperty("recipient")]
        public ObjectOwner Recipient { get; }
        
        [JsonProperty("objectId")]
        public string ObjectId { get; }
        
        [JsonProperty("type")]
        public string Type { get; }
        
        [JsonProperty("version")]
        public ulong Version { get; }
        
        public TransferObjectEvent(
            string packageId,
            string transactionModule,
            string sender,
            ObjectOwner recipient,
            string objId,
            string type,
            ulong version)
            : base(packageId, transactionModule, sender)
        {
            Recipient = recipient;
            ObjectId = objId;
            Type = type;
            Version = version;
        }

        public override string ToString()
        {
            return "{\n" +
                   $"  packageId: {PackageId},\n" +
                   $"  transactionModule: {TransactionModule},\n" +
                   $"  sender: {Sender},\n" +
                   $"  recipient: {Recipient},\n" +
                   $"  objectId: {ObjectId},\n" +
                   $"  type: {Type},\n" +
                   $"  version: {Version}\n" +
                   "}";
        }
    }
}