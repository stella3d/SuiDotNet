using System;
using Newtonsoft.Json;

namespace SuiDotNet.Client.Requests
{
    [Serializable]
    public class OwnedObjectReference
    {
        [JsonProperty("owner")]
        public ObjectOwner Owner { get; set; }
        
        [JsonProperty("reference")]
        public SuiObjectReference Reference { get; set;  }

        public OwnedObjectReference(ObjectOwner owner, SuiObjectReference reference)
        {
            Owner = owner;
            Reference = reference;
        }

        public override string ToString()
        {
            return "{\n" +
                   $"  owner: {Owner},\n" +
                   $"  reference: {Reference}" +
                   "}";
        }
    }
}