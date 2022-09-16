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
        public OwnedObjectRef GasObject { get; set; }
        [JsonProperty("gasUsed")]
        public GasCostSummary GasUsed { get; set; }
        
        [JsonProperty("created")]
        public OwnedObjectRef[]? Created { get; }
        
        [JsonProperty("deleted")]
        public SuiObjectReference[]? Deleted { get; }
        
        [JsonProperty("mutated")]
        public OwnedObjectRef[]? Mutated { get; }
        
        [JsonProperty("dependencies")]
        public string[]? Dependencies { get; set; }
        
        [JsonProperty("events")]
        public SuiEvent[]? Events { get; set; }
        
        [JsonProperty("sharedObjects")]
        public SuiObjectReference[]? SharedObjects { get; }
        
        [JsonProperty("wrapped")]
        public SuiObjectReference[]? Wrapped { get; }
        [JsonProperty("unwrapped")]
        public SuiObjectReference[]? Unwrapped { get; }
        
        public TransactionEffects(
            ExecutionStatus status, 
            string digest,
            OwnedObjectRef gasObject, 
            GasCostSummary gasUsed,
            OwnedObjectRef[]? created,
            SuiObjectReference[]? deleted,
            OwnedObjectRef[]? mutated,
            string[]? dependencies,
            SuiEvent[]? events,
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