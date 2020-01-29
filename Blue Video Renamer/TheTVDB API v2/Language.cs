using Newtonsoft.Json;

namespace TheTVDB_API_v2
{
    /// <summary>
    /// Contains information about a valid language that can be used to make requests.
    /// </summary>
    public class Language : ITVDBResponse
    {
        /// <summary>
        /// The abbreviation is used by <see cref="TheTVDB.AcceptLanguage"/>.
        /// </summary>
        [JsonProperty("abbreviation")]
        public string Abbreviation { get; set; }

        /// <summary>
        /// The English name of the language
        /// </summary>
        [JsonProperty("englishName")]
        public string EnglishName { get; set; }

        /// <summary>
        /// The Id of the language
        /// </summary>
        [JsonProperty("id")]
        public int? Id { get; set; }

        /// <summary>
        /// The native name of the language
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Contains an error if there was a problem with the request.
        /// </summary>
        [JsonProperty("Error")]
        public string Error { get; set; }

        public override string ToString()
        {
            JsonSerializerSettings jsonsettings = new JsonSerializerSettings();
            jsonsettings.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.SerializeObject(this, jsonsettings);
        }
    }

    /// <summary>
    /// A server response for all languages.
    /// </summary>
    internal class Languages : ITVDBResponse
    {
        [JsonProperty("data")]
        public Language[] Data {get;set;}

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