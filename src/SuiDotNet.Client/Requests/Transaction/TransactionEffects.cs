using System;
using Newtonsoft.Json;

namespace SuiDotNet.Client.Requests
{
    [Serializable]
    public class TransactionEffects
    {
        [JsonProperty("status")]
        public ExecutionStatus Status { get; }
        
        [JsonProperty("transactionDigest")]
        public string TransactionDigest { get; set; }
        
        [JsonProperty("gasObject")]
        public OwnedObjectReference GasObject { get; set; }
        [JsonProperty("gasUsed")]
        public GasCostSummary GasUsed { get; set; }
        
        [JsonProperty("created")]
        public object[]? Created { get; }
        [JsonProperty("deleted")]
        public object[]? Deleted { get; }
        [JsonProperty("mutated")]
        public object[]? Mutated { get; }
        
        [JsonProperty("dependencies")]
        public string[]? Dependencies { get; set; }
        
        [JsonProperty("events")]
        public object[]? Events { get; set; }
        
        [JsonProperty("sharedObjects")]
        public SuiObjectReference[]? SharedObjects { get; }
        
        [JsonProperty("wrapped")]
        public SuiObjectReference[]? Wrapped { get; }
        [JsonProperty("unwrapped")]
        public SuiObjectReference[]? Unwrapped { get; }
        
        public TransactionEffects(
            ExecutionStatus status, 
            string digest,
            OwnedObjectReference gasObject, 
            GasCostSummary gasUsed,
            object[]? created,
            object[]? deleted,
            object[]? mutated,
            string[]? dependencies,
            object[]? events,
            SuiObjectReference[]? sharedObjects,
            SuiObjectReference[]? wrapped,
            SuiObjectReference[]? unwrapped)
        {
            Status = status;
            TransactionDigest = digest;
            GasObject = gasObject;
            GasUsed = gasUsed;
            Created = created;
            Deleted = deleted;
            Mutated = mutated;
            Dependencies = dependencies;
            Events = events;
            SharedObjects = sharedObjects;
            Wrapped = wrapped;
            Unwrapped = unwrapped;
        }
    }
}