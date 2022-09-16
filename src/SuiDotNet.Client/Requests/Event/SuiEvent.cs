using System;
using Newtonsoft.Json;

namespace SuiDotNet.Client.Requests
{
    [Serializable]
    public class SuiEvent
    {
        [JsonProperty("moveEvent")] public MoveEvent<object>? MoveEvent { get; set; }
        [JsonProperty("publish")] public PublishEvent? Publish { get; set; }
        [JsonProperty("transferObject")] public TransferObjectEvent? TransferObject { get; set; }
        [JsonProperty("deleteObject")] public DeleteObjectEvent? DeleteObject { get; set; }
        [JsonProperty("newObject")] public NewObjectEvent? NewObject { get; set; }
        [JsonProperty("epochChange")] public ulong? EpochChange { get; set; }
        [JsonProperty("checkpoint")] public ulong? Checkpoint { get; set; }

        public override string ToString()
        {
            if (MoveEvent != null) return MoveEvent.ToString();
            if (TransferObject != null) return TransferObject.ToString();
            if (NewObject != null) return NewObject.ToString();
            if (DeleteObject != null) return DeleteObject.ToString();
            if (Publish != null) return Publish.ToString();
            if (EpochChange != null) return EpochChange.ToString();
            if (Checkpoint != null) return Checkpoint.ToString();
            return "{}";
        }
    }
}