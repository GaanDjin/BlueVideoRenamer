using Newtonsoft.Json;
using System;
namespace TheTVDB_API_v2
{
    /// <summary>
    /// Contains summary information about the image counts for a series.
    /// </summary>
    public class SeriesImagesCount : ITVDBResponse
    {
        /// <summary>
        /// The number of fanart pictures in the series
        /// </summary>
        [JsonProperty("fanart")]
        public int? Fanart { get; set; }

        /// <summary>
        /// The number of poster images in the series
        /// </summary>
        [JsonProperty("poster")]
        public int? Poster { get; set; }

        /// <summary>
        /// The number of seasons in the series.
        /// </summary>
        [JsonProperty("season")]
        public int? Season { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("seasonwide")]
        public int? SeasonWide { get; set; }

        /// <summary>
        /// The Id of the series. 
        /// </summary>
        [JsonProperty("series")]
        public int? Series { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("Error")]
        public string Error { get; set; }
    }

    /// <summary>
    /// The series image count response from the server. 
    /// </summary>
    internal class SeriesImagesCounts : ITVDBResponse
    {
        [JsonProperty("data")]
        public SeriesImagesCount Count;

        [JsonProperty("Error")]
        public string Error { get; set; }

    }
}