using Newtonsoft.Json;

namespace TheTVDB_API_v2
{
    /// <summary>
    /// Any errors in the results that have been returned. Like translation missing errors.
    /// This isn't the same as a server error due to an invalid request.
    /// </summary>
    public class JSONErrors
    {
        /// <summary>
        /// Invalid filters passed to route
        /// </summary>
        [JsonProperty("invalidFilters")]
        public string[] InvalidFilters { get; set; }

        /// <summary>
        /// Invalid language or translation missing
        /// </summary>
        [JsonProperty("invalidLanguage")]
        public string InvalidLanguage { get; set; }

        /// <summary>
        /// Invalid query params passed to route
        /// </summary>
        [JsonProperty("invalidQueryParams")]
        public string[] InvalidQueryParams { get; set; }


        public override string ToString()
        {
            JsonSerializerSettings jsonsettings = new JsonSerializerSettings();
            jsonsettings.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.SerializeObject(this, jsonsettings);
        }
    }
}