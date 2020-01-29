using Newtonsoft.Json;

namespace TheTVDB_API_v2
{
    /// <summary>
    /// Parameters that can be used to search for images in the assotiated series. 
    /// </summary>
    public class SeriesImagesQueryParam : ITVDBResponse
    {
        [JsonProperty("keyType")]
        public string KeyType { get; set; }

        [JsonProperty("languageId")]
        public string LanuageId { get; set; }

        [JsonProperty("resolution")]
        public string[] Resolution { get; set; }

        [JsonProperty("subKey")]
        public string[] SubKey { get; set; }

        [JsonProperty("Error")]
        public string Error { get; set; }

        public override string ToString()
        {
            JsonSerializerSettings jsonsettings = new JsonSerializerSettings();
            jsonsettings.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.SerializeObject(this, jsonsettings);
        }
    }
}