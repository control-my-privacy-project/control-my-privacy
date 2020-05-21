using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace SocialMediaProvider.Providers.VK.Response
{
    public class ResponseCountersConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => Nullable.GetUnderlyingType(objectType) != null;
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                return JArray.Load(reader).ToObject(objectType);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public override bool CanWrite => false;
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();
    }
}
