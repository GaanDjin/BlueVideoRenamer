using Newtonsoft.Json;
using System;

namespace TheTVDB_API_v2
{
    /// <summary>
    /// Contains information about an Actor on a specified series.
    /// </summary>
    public class Actor
    {
        [JsonProperty("id")]
        public int? Id;

        [JsonProperty("image")]
        public string ImageUrl;

        [JsonProperty("imageAdded")]
        public string imageAdded;
        public DateTime ImageAdded
        {
            get
            {
                if (imageAdded == null || imageAdded.Length == 0) return DateTime.MinValue;
                return DateTime.Parse(imageAdded);
            }
        }

        [JsonProperty("imageAuthor")]
        public int? imageAuthor;

        [JsonProperty("lastUpdated")]
        public long? lastUpdated;

        [JsonProperty("name")]
        public string name;

        [JsonProperty("role")]
        public string role;

        [JsonProperty("seriesId")]
        public int? seriesId;

        [JsonProperty("sortOrder")]
        public int? sortOrder;

        /// <summary>
        /// Returns a JSON serialized string representing this object.
        /// Null values are ignored (left out)
        /// </summary>
        /// <returns>Returns a JSON serialized string representing this object.</returns>
        public override string ToString()
        {
            JsonSerializerSettings jsonsettings = new JsonSerializerSettings();
            jsonsettings.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.SerializeObject(this, jsonsettings);
        }
    }
}