using System;
using Newtonsoft.Json;

namespace SuiDotNet.Client.Requests
{
    [Serializable]
    public class SuiEvent<T>
    {
        [JsonProperty("moveEvent")] public MoveEvent<T>? MoveEvent { get; set; }
        [JsonProperty("publish")] public PublishEvent? Publish { get; set; }
        [JsonProperty("transferObject")] public TransferObjectEvent? TransferObject { get; set; }
        [JsonProperty("deleteObject")] public DeleteObjectEvent? DeleteObject { get; set; }
        [JsonProperty("newObject")] public NewObjectEvent? NewObject { get; set; }
        [JsonProperty("epochChange")] public ulong? EpochChange { get; set; }
        [JsonProperty("checkpoint")] public ulong? Checkpoint { get; set; }
    }
}