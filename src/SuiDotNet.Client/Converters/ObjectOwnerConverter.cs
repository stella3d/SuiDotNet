using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SuiDotNet.Client.Requests;

namespace SuiDotNet.Client.Converters
{
    public class ObjectOwnerConverter : JsonConverter<ObjectOwner>
    {
        public override bool CanWrite => true;

        public override void WriteJson(JsonWriter writer, ObjectOwner value, JsonSerializer serializer)
        {
            switch (value.Type)
            {
                case OwnerType.Address:
                    writer.WriteStartObject();
                    writer.WritePropertyName("AddressOwner");
                    writer.WriteValue(value.Address);
                    writer.WriteEndObject();
                    break;
                case OwnerType.Object:
                    writer.WriteStartObject();
                    writer.WritePropertyName("ObjectOwner");
                    writer.WriteValue(value.Address);
                    writer.WriteEndObject();
                    break;
                case OwnerType.Single:
                    writer.WriteStartObject();
                    writer.WritePropertyName("SingleOwner");
                    writer.WriteValue(value.Address);
                    writer.WriteEndObject();
                    break;
                case OwnerType.Shared:
                    writer.WriteValue("Shared");
                    break;
                case OwnerType.Immutable:
                    writer.WriteValue("Immutable");
                    break;
                case OwnerType.Unknown:
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override ObjectOwner ReadJson(JsonReader reader, Type objectType, ObjectOwner existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                switch (reader.Value.ToString())
                {
                    case "Shared":
                        return new ObjectOwner(OwnerType.Shared);
                    case "Immutable":
                        return new ObjectOwner(OwnerType.Immutable);
                }
            }
            else
            {
                var jObject = serializer.Deserialize<JObject>(reader);
                if (jObject.ContainsKey("AddressOwner"))
                {
                    return new ObjectOwner(OwnerType.Address, jObject["AddressOwner"].Value<string>());
                }
                if (jObject.ContainsKey("ObjectOwner"))
                {
                    return new ObjectOwner(OwnerType.Object, jObject["ObjectOwner"].Value<string>());
                }
                if (jObject.ContainsKey("SingleOwner"))
                {
                    return new ObjectOwner(OwnerType.Single, jObject["SingleOwner"].Value<string>());
                }
            }

            return new ObjectOwner(OwnerType.Unknown);
        }
    }
}