using System;
using Newtonsoft.Json;

namespace SuiDotNet.Client.Requests
{
    /*
        {
          "newObject": {
            "packageId": "0x0000000000000000000000000000000000000002",
            "transactionModule": "devnet_nft",
            "sender": "0x08c9e31048ce86a3538272d4adaf2069ecf26c01",
            "recipient": {
              "AddressOwner": "0x08c9e31048ce86a3538272d4adaf2069ecf26c01"
            },
            "objectId": "0x6bd6fe4b1f86620976e6d7310c478bcbf6fc9c71"
          }
        }
     */

    [Serializable]
    public class NewObjectEvent: BaseEvent
    {
        [JsonProperty("recipient")]
        public ObjectOwner Recipient { get; set; }
        
        [JsonProperty("objectId")]
        public string ObjectId { get; set; }
        
        public NewObjectEvent(string packageId, string transactionModule, string sender, ObjectOwner recipient, string objId)
            : base(packageId, transactionModule, sender)
        {
            Recipient = recipient;
            ObjectId = objId;
        }

        public override string ToString()
        {
            return "{\n" +
                   $"  packageId: {PackageId},\n" +
                   $"  transactionModule: {TransactionModule},\n" +
                   $"  sender: {Sender},\n" +
                   $"  recipient: {Recipient},\n" +
                   $"  objectId: {ObjectId}\n" +
                   "}";
        }
    }
}