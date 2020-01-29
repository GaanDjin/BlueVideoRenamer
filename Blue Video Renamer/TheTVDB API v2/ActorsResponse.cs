using Newtonsoft.Json;

namespace TheTVDB_API_v2
{
    /// <summary>
    /// Contains an Actor or an error that may have occured. 
    /// </summary>
    internal class ActorsResponse : ITVDBResponse
    {
        [JsonProperty("data")]
        public Actor[] Actors;
        
        /// <summary>
        /// Informative error messages (optional)
        /// </summary>
        [JsonProperty("errors")]
        public JSONErrors Errors;

        public string Error { get; set; }
        
        public override string ToString()
        {
            JsonSerializerSettings jsonsettings = new JsonSerializerSettings();
            jsonsettings.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.SerializeObject(this, jsonsettings);
        }
    }
}