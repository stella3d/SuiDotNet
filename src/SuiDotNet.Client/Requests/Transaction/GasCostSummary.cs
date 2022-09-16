using System;
using Newtonsoft.Json;

namespace SuiDotNet.Client.Requests
{
    [Serializable]
    public class GasCostSummary
    {
        [JsonProperty("computationCost")]
        public double ComputationCost { get; }
        [JsonProperty("storageCost")]
        public double StorageCost { get; }
        [JsonProperty("storageRebate")]
        public double StorageRebate { get; }

        public GasCostSummary(double computationCost, double storageCost, double storageRebate)
        {
            ComputationCost = computationCost;
            StorageCost = storageCost;
            StorageRebate = storageRebate;
        }

        public override string ToString()
        {
            return "{\n" +
                   $"  computationCost: {ComputationCost},\n" +
                   $"  storageCost: {StorageCost},\n" +
                   $"  storageRebate: {StorageRebate}\n" +
                   "}";
        }
    }
}