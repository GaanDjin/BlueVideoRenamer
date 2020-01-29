using Newtonsoft.Json;
using System;

namespace TheTVDB_API_v2
{
    /// <summary>
    /// Contains a sumary about the number of seasons and total episode count for the series.
    /// </summary>
    public class SeriesEpisodesSummary : ITVDBResponse
    {
        /// <summary>
        /// Number of all aired episodes for this series
        /// </summary>
        [JsonProperty("airedEpisodes")]
        public int? airedEpisodes;

        [JsonProperty("airedSeasons")]
        public int[] airedSeasons;

        /// <summary>
        /// Number of all dvd episodes for this series
        /// </summary>
        [JsonProperty("dvdEpisodes")]
        public int? dvdEpisodes;

        [JsonProperty("dvdSeasons")]
        public int[] dvdSeasons;

        [JsonProperty("Error")]
        public string Error{get;set;}

        public override string ToString()
        {
            JsonSerializerSettings jsonsettings = new JsonSerializerSettings();
            jsonsettings.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.SerializeObject(this, jsonsettings);
        }
    }
}