using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace RedfinFoodtruck.Services.Services
{
    public static class JsonExtension
    {
        private static readonly JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            DateTimeZoneHandling = DateTimeZoneHandling.Utc

        };
        public static JsonSerializerSettings Settings()
        {
            return _settings;
        }
    }
}
