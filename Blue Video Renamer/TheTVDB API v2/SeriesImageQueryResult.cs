using Newtonsoft.Json;

namespace TheTVDB_API_v2
{
    /// <summary>
    /// contains Information about an image.
    /// </summary>
    public class SeriesImageQueryResult
    {
        [JsonProperty("fileName")]
        public string FileName { get; set; }

        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("keyType")]
        public string KeyType { get; set; }

        [JsonProperty("languageId")]
        public int? LanguageId { get; set; }

        [JsonProperty("ratingsInfo")]
        public RatingsInfo RatingsInfo { get; set; }

        [JsonProperty("resolution")]
        public string Resolution { get; set; }

        [JsonProperty("subKey")]
        public string SubKey { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        public override string ToString()
        {
            JsonSerializerSettings jsonsettings = new JsonSerializerSettings();
            jsonsettings.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.SerializeObject(this, jsonsettings);
        }
    }
    

    /// <summary>
    /// The server response to a search request.
    /// </summary>
    internal class SeriesImageQueryResults : ITVDBResponse
    {
        [JsonProperty("Error")]
        public string Error { get; set; }

        [JsonProperty("data")]
        public SeriesImageQueryResult[] Data { get; set; }

        [JsonProperty("errors")]
        public JSONErrors Errors { get; set; }

        public override string ToString()
        {
            JsonSerializerSettings jsonsettings = new JsonSerializerSettings();
            jsonsettings.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.SerializeObject(this, jsonsettings);
        }
    }
}