using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTVDB_API_v2
{
    /// <summary>
    /// A search result for a series. Contains partial summary information of the series. 
    /// </summary>
    public class SeriesSearchResult : ITVDBResponse
    {
        [JsonProperty("Error")]
        public string Error
        {
            get;
            set;
        }

        [JsonProperty("aliases")]
        public string[] Aliases { get; set; }
        [JsonProperty("banner")]
        public string Banner { get; set; }
        [JsonProperty("firstAired")]
        public string FirstAired { get; set; }
        [JsonProperty("id")]
        public int? Id { get; set; }
        [JsonProperty("network")]
        public string Network { get; set; }
        [JsonProperty("overview")]
        public string Overview { get; set; }
        [JsonProperty("seriesName")]
        public string SeriesName { get; set; }
        [JsonProperty("slug")]
        public string Slug { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }

        public override string ToString()
        {
            JsonSerializerSettings jsonsettings = new JsonSerializerSettings();
            jsonsettings.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.SerializeObject(this, jsonsettings);
        }
    }
}
