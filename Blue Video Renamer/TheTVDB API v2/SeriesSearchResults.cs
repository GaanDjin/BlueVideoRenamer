using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTVDB_API_v2
{
    /// <summary>
    /// The server response for a search for a series.
    /// </summary>
    internal class SeriesSearchResults : ITVDBResponse
    {
        [JsonProperty("Error")]
        public string Error { get; set; }

        [JsonProperty("data")]
        public SeriesSearchResult[] Results { get; set; }

        public override string ToString()
        {
            JsonSerializerSettings jsonsettings = new JsonSerializerSettings();
            jsonsettings.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.SerializeObject(this, jsonsettings);
        }
    }
}
