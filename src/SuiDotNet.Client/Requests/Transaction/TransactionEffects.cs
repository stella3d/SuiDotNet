using System;
using Newtonsoft.Json;

namespace SuiDotNet.Client.Requests
{
    [Serializable]
    public class TransactionEffects
    {
        [JsonProperty("status")]
        public ExecutionStatus Status { get; set; }
        
        [JsonProperty("transactionDigest")]
        public string TransactionDigest { get; set; }
        
        [JsonProperty("gasObject")]
        public SuiObjectReference GasObject { get; set; }
        [JsonProperty("gasUsed")]
        public object GasUsed { get; set; }
        
        [JsonProperty("created")]
        public object[]? Created { get; set; }
        [JsonProperty("deleted")]
        public object[]? Deleted { get; set; }
        [JsonProperty("mutated")]
        public object[]? Mutated { get; set; }
        
        [JsonProperty("dependencies")]
        public string[]? Dependencies { get; set; }
        
        [JsonProperty("events")]
        public object[]? Events { get; set; }
        
        [JsonProperty("sharedObjects")]
        public SuiObjectReference[]? SharedObjects { get; set; }
        
        [JsonProperty("wrapped")]
        public SuiObjectReference[]? Wrapped { get; set; }
        [JsonProperty("unwrapped")]
        public SuiObjectReference[]? Unwrapped { get; set; }
    }
}