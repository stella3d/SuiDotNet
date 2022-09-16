using System;
using Newtonsoft.Json;

namespace SuiDotNet.Client.Requests
{
    [Serializable]
    public class DevnetNftFields
    {
        [JsonProperty("creator")]
        public string Creator { get; }
        
        [JsonProperty("name")]
        public string Name { get; }
        
        [JsonProperty("objectId")]
        public string ObjectId { get; }

        public DevnetNftFields(string creator, string name, string objectId)
        {
            Creator = creator;
            Name = name;
            ObjectId = objectId;
        }

        public override string ToString()
        {
            return "{\n" +
                   $"  creator: {Creator},\n" +
                   $"  name: {Name},\n" +
                   $"  objectId: {ObjectId}" +
                   "}";
        }
    }

    /* a DevnetNftMoveEvent in JSON
      {
        "packageId": "0x0000000000000000000000000000000000000002",
        "transactionModule": "devnet_nft",
        "sender": "0x08c9e31048ce86a3538272d4adaf2069ecf26c01",
        "type": "0x2::devnet_nft::MintNFTEvent",
        "fields": {
          "creator": "0x08c9e31048ce86a3538272d4adaf2069ecf26c01",
          "name": "Example NFT",
          "object_id": "0x6bd6fe4b1f86620976e6d7310c478bcbf6fc9c71"
        },
        "bcs": "a9b+Sx+GYgl25tcxDEeLy/b8nHEIyeMQSM6Go1OCctStryBp7PJsAQtFeGFtcGxlIE5GVA=="
      }
    */
    [Serializable]
    public class DevnetNftMoveEvent : MoveEvent<DevnetNftFields>
    {
        public DevnetNftMoveEvent(
            string packageId,
            string transactionModule,
            string sender,
            string type,
            DevnetNftFields fields,
            string bcs) 
            : base(packageId, transactionModule, sender, type, fields, bcs) { }
    }
}