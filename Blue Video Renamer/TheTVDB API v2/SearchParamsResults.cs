using Newtonsoft.Json;

namespace TheTVDB_API_v2
{
    /// <summary>
    /// The list of Keys that can be used for a Search request. 
    /// </summary>
    internal class SearchParamsResults : ITVDBResponse
    {
        [JsonProperty("Error")]
        public string Error { get; set; }

        [JsonProperty("data")]
        public string[] Results { get; set; }

        public override string ToString()
        {
            JsonSerializerSettings jsonsettings = new JsonSerializerSettings();
            jsonsettings.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.SerializeObject(this, jsonsettings);
        }
    }
}