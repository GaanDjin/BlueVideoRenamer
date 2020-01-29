using Newtonsoft.Json;

namespace TheTVDB_API_v2
{
    /// <summary>
    /// Server response for a Series image query parameters request.
    /// </summary>
    internal class SeriesImagesQueryParams : ITVDBResponse
    {
        [JsonProperty("data")]
        public SeriesImagesQueryParam[] Parameters { get; internal set; }
        
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