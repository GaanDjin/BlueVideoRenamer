using Newtonsoft.Json;
using System;

namespace TheTVDB_API_v2
{
    /// <summary>
    /// Contains information about a list of episodes along with episode errors (like missing translation if requested in another language)
    /// Also contains information about a pagignated result. Generally if show has more than 100 episodes it will be split into multipule "pages"
    /// </summary>
    public class EpisodesResponse : ITVDBResponse
    {
        [JsonProperty("data")]
        public Episode[] Episodes { get; set; }
        [JsonProperty("errors")]
        public JSONErrors Errors { get; set; }
        [JsonProperty("links")]
        public PaginationInfo PageInfo { get; set; }

        [JsonProperty("Error")]
        public string Error{get; set; }
        
        public override string ToString()
        {
            JsonSerializerSettings jsonsettings = new JsonSerializerSettings();
            jsonsettings.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.SerializeObject(this, jsonsettings);
        }
    }
}