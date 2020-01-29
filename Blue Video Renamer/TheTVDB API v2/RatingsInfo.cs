using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTVDB_API_v2
{
    /// <summary>
    /// The ratings for a fiven record
    /// </summary>
    public class RatingsInfo
    {
        /// <summary>
        /// Average rating for the given record.
        /// </summary>
        [JsonProperty("average")]
        public float? Average { get; set; }
        /// <summary>
        /// Number of ratings for the given record.
        /// </summary>
        [JsonProperty("count")]
        public int? Count { get; set; }

        public override string ToString()
        {
            JsonSerializerSettings jsonsettings = new JsonSerializerSettings();
            jsonsettings.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.SerializeObject(this, jsonsettings);
        }
    }

}
