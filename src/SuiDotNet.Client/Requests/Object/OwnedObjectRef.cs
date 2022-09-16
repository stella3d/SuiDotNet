using System;
using Newtonsoft.Json;

namespace SuiDotNet.Client.Requests
{
    [Serializable]
    public class OwnedObjectRef
    {
        [JsonProperty("owner")]
        public ObjectOwner Owner { get; set; }
        
        [JsonProperty("reference")]
        public SuiObjectReference Reference { get; set;  }

        public OwnedObjectRef(ObjectOwner owner, SuiObjectReference reference)
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