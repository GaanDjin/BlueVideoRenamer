using Newtonsoft.Json;
using System;

namespace TheTVDB_API_v2
{
    /// <summary>
    /// Contains information about a paged search result.
    /// </summary>
    public class PaginationInfo : ITVDBResponse
    {
        public string Error
        {
            get; set;
        }

        /// <summary>
        /// The first page in the search results. (Usually 1)
        /// </summary>
        [JsonProperty("first")]
        public int? First { get; set; }
        
        /// <summary>
        /// The last page in the search results. 
        /// </summary>
        [JsonProperty("last")]
        public int? Last { get; set; }

        /// <summary>
        /// The next page in search results.
        /// </summary>
        [JsonProperty("next")]
        public int? Next { get; set; }

        /// <summary>
        /// The last page in the search results.
        /// </summary>
        [JsonProperty("previous")]
        public int? Previous { get; set; }

        public override string ToString()
        {
            JsonSerializerSettings jsonsettings = new JsonSerializerSettings();
            jsonsettings.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.SerializeObject(this, jsonsettings);
        }
    }
}