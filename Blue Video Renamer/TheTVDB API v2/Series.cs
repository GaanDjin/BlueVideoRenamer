using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTVDB_API_v2
{
    /// <summary>
    /// Contains information about a series.
    /// </summary>
    public class Series
    {
        [JsonProperty("added")]
        internal string DateAdded { get; set; }
        [JsonProperty("airsTime")]
        internal string airsTime { get; set; }
        [JsonProperty("firstAired")]
        internal string firstAired { get; set; }


        public DateTime Added {
            get {
                if (DateAdded == null || DateAdded.Length == 0) return DateTime.MinValue;
                DateTime result = DateTime.MinValue;
                DateTime.TryParse(DateAdded, out result);
                return result;
            }
        }

        [JsonProperty("airsDayOfWeek")]
        public string AirsDayOfWeek { get; set; }
        public DateTime AirsTime
        {
            get
            {
                if (airsTime == null || airsTime.Length == 0) return DateTime.MinValue;
                DateTime result = DateTime.MinValue;
                DateTime.TryParse(airsTime, out result);
                return result;
            }
        }
        [JsonProperty("aliases")]
        public string[] Aliases { get; set; }
        [JsonProperty("banner")]
        public string Banner { get; set; }
        public DateTime FirstAired
        {
            get
            {
                if (firstAired == null || firstAired.Length == 0) return DateTime.MinValue;
                DateTime result = DateTime.MinValue;
                DateTime.TryParse(firstAired, out result);
                return result;
            }
        }
        [JsonProperty("genre")]
        public string[] Genre { get; set; }
        [JsonProperty("id")]
        public int? Id { get; set; }
        [JsonProperty("imdbId")]
        public string ImdbId { get; set; }
        [JsonProperty("lastUpdated")]
        public long? LastUpdated { get; set; }
        [JsonProperty("network")]
        public string Network { get; set; }
        [JsonProperty("networkId")]
        public string NetworkId { get; set; }
        [JsonProperty("overview")]
        public string Overview { get; set; }
        [JsonProperty("rating")]
        public string Rating { get; set; }
        [JsonProperty("runtime")]
        public string Runtime { get; set; }
        [JsonProperty("seriesId")]
        public string SeriesId { get; set; }
        [JsonProperty("seriesName")]
        public string SeriesName { get; set; }
        [JsonProperty("siteRating")]
        public float? SiteRating { get; set; }
        [JsonProperty("siteRatingCount")]
        public int? SiteRatingCount { get; set; }
        [JsonProperty("slug")]
        public string Slug { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("zap2itId")]
        public string Zap2itId { get; set; }

    }
}