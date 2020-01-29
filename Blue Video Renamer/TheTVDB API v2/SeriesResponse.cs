using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTVDB_API_v2
{
    /// <summary>
    /// The server response for a series request. 
    /// Contains the JSON errors about the series but for now we're not going to pass this class to the client. 
    /// </summary>
    internal class SeriesResponse : ITVDBResponse
    {
        /// <summary>
        /// A series record.
        /// </summary>
        [JsonProperty("data")]
        public Series Series;

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
