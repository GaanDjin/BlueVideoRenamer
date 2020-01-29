using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace TheTVDB_API_v2
{
    /// <summary>
    /// Contains information about a particular episode.
    /// Note: As Director is depreciated it is omitted from this class (in favor of Directors).
    /// </summary>
    public class Episode : ITVDBResponse
    {
    //    [JsonConstructor]
    //    public Episode()
    //    {
    //        AbsoluteNumber = -1;
    //        AiredEpisodeNumber = -1;
    //        AiredSeason = -1;
    //        AirsAfterSeason = -1;
    //        AirsBeforeEpisode = -1;
    //        AirsBeforeSeason = -1;
    //        Directors = new string[0];
    //    DvdChapter = -1;
    //    DvdDiscid  = null;
    //    DvdEpisodeNumber = -1;
    //    DvdSeason  = -1;
    //    EpisodeName = "";
    //    ThumbUrl = null;
    //        FirstAired = null;
    //    GuestStars  = new string[0];
    //    Id = -1;
    //        ImdbId = null;
    //        LastUpdated = -1;
    //        LastUpdatedBy = -1;
    //        Overview = null;
    //        ProductionCode = null;
    //        SeriesId = null;
    //        ShowUrl = null;
    //        SiteRating = 0;
    //        SiteRatingCount = 0;
    //        ThumbAdded = DateTime.MinValue;
    //        ThumbAuthor = -1;
    //        ThumbHeight = -1;
    //        ThumbWidth = -1;
    //        Writers = new string[0];
    //        Error = null;
    //}

        [JsonProperty("absoluteNumber")]
        [DefaultValue(0)]
        public int? AbsoluteNumber { get; set; }

        [JsonProperty("airedEpisodeNumber")]
        [DefaultValue(0)]
        public int AiredEpisodeNumber { get; set; }

        [JsonProperty("airedSeason")]
        [DefaultValue(0)]
        public int AiredSeason { get; set; }

        [JsonProperty("airsAfterSeason")]
        [DefaultValue(0)]
        public int? AirsAfterSeason { get; set; }

        [JsonProperty("airsBeforeEpisode")]
        [DefaultValue(0)]
        public int? AirsBeforeEpisode { get; set; }

        [JsonProperty("airsBeforeSeason")]
        [DefaultValue(0)]
        public int? AirsBeforeSeason { get; set; }

        //[JsonProperty("director")]
        //public string director { get; set; }

        [JsonProperty("directors")]
        public string[] Directors { get; set; }

        [JsonProperty("dvdChapter", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(0f)]
        public float? DvdChapter { get; set; } = 0;

        [JsonProperty("dvdDiscid")]
        public string DvdDiscid { get; set; }

        [JsonProperty("dvdEpisodeNumber")]
        [DefaultValue(0f)]
        public float? DvdEpisodeNumber { get; set; }

        [JsonProperty("dvdSeason")]
        [DefaultValue(0)]
        public int? DvdSeason { get; set; }

        [JsonProperty("episodeName")]
        public string EpisodeName { get; set; }

        [JsonProperty("filename")]
        public string ThumbUrl { get; set; }

        [JsonProperty("firstAired")]
        internal string firstAired;

        public DateTime FirstAired
        {
            get
            {
                if (firstAired == null || firstAired.Length == 0) return DateTime.MinValue;
                return DateTime.Parse(firstAired);
            }
        }

        [JsonProperty("guestStars")]
        public string[] GuestStars { get; set; }

        [JsonProperty("id")]
        [DefaultValue(0)]
        public int Id { get; set; }

        [JsonProperty("imdbId")]
        public string ImdbId { get; set; }

        [JsonProperty("lastUpdated")]
        [DefaultValue(0)]
        public long? LastUpdated { get; set; }

        [JsonProperty("lastUpdatedBy")]
        [DefaultValue(0)]
        public int? LastUpdatedBy { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("productionCode")]
        public string ProductionCode { get; set; }

        [JsonProperty("seriesId")]
        public string SeriesId { get; set; }

        [JsonProperty("showUrl")]
        public string ShowUrl { get; set; }

        [JsonProperty("siteRating")]
        [DefaultValue(0)]
        public float? SiteRating { get; set; }

        [JsonProperty("siteRatingCount")]
        [DefaultValue(0)]
        public int? SiteRatingCount { get; set; }

        [JsonProperty("thumbAdded")]
        internal string thumbAdded;

        public DateTime ThumbAdded
        {
            get
            {
                if (thumbAdded == null || thumbAdded.Length == 0) return DateTime.MinValue;
                return DateTime.Parse(thumbAdded);
            }
        }


        [JsonProperty("thumbAuthor")]
        [DefaultValue(0)]
        public int? ThumbAuthor { get; set; }

        [JsonProperty("thumbHeight")]
        [DefaultValue(0)]
        public int? ThumbHeight { get; set; }

        [JsonProperty("thumbWidth")]
        [DefaultValue(0)]
        public int? ThumbWidth { get; set; }

        [JsonProperty("writers")]
        public string[] Writers { get; set; }

        [JsonProperty("Error")]
        public string Error{ get;  set;}

        public override string ToString()
        {
            JsonSerializerSettings jsonsettings = new JsonSerializerSettings();
            jsonsettings.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.SerializeObject(this, jsonsettings);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType() != typeof(Episode))
                return false;

            Episode that = (Episode)obj;

            return Id == that.Id && AiredEpisodeNumber == that.AiredEpisodeNumber && AiredSeason == that.AiredSeason;
        }
    }
}