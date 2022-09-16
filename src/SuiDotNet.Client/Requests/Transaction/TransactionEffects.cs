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
        public string TransactionDigest { get; }
        
        [JsonProperty("gasObject")]
        public object GasObject { get; }
        [JsonProperty("gasUsed")]
        public object GasUsed { get; }
        
        [JsonProperty("created")]
        public object[]? Created { get; }
        [JsonProperty("deleted")]
        public object[]? Deleted { get; }
        [JsonProperty("mutated")]
        public object[]? Mutated { get; }
        
        [JsonProperty("dependencies")]
        public string[]? Dependencies { get; }
        
        [JsonProperty("events")]
        public object[]? Events { get; }
        
        [JsonProperty("sharedObjects")]
        public SuiObjectReference[]? SharedObjects { get; }
        
        [JsonProperty("wrapped")]
        public SuiObjectReference[]? Wrapped { get; }
        [JsonProperty("unwrapped")]
        public SuiObjectReference[]? Unwrapped { get; }
        
        public TransactionEffects(
            ExecutionStatus status, 
            string digest,
            object gas, 
            object gasUsed,
            object[]? created = null,
            object[]? deleted = null,
            object[]? mutated = null,
            string[]? dependencies = null,
            object[]? events = null,
            SuiObjectReference[]? sharedObjects = null,
            SuiObjectReference[]? wrapped = null,
            SuiObjectReference[]? unwrapped = null)
        {
            Status = status;
            TransactionDigest = digest;
            GasObject = gas;
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