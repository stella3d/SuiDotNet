using System;
using Newtonsoft.Json;

namespace SuiDotNet.Client.Requests
{
    [Serializable]
    public abstract class BaseEvent
    {
        [JsonProperty("packageId")] public string PackageId { get; protected set; }

        [JsonProperty("transactionModule")] public string TransactionModule { get; protected set; }

        [JsonProperty("sender")] public string Sender { get; protected set; }

        protected BaseEvent(string packageId, string transactionModule, string sender)
        {
            PackageId = packageId;
            TransactionModule = transactionModule;
            Sender = sender;
        }
    }
}