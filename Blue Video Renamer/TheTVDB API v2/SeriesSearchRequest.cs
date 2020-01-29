using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTVDB_API_v2
{
    /// <summary>
    /// Search request information about a series.
    /// </summary>
    public class SeriesSearchRequest : ITVDBRequest
    {
        /// <summary>
        /// The name (full or partial) of the series to find.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("imdbId")]
        public string ImdbId { get; set; }

        [JsonProperty("zap2itId")]
        public string Zap2ItId { get; set; }

        //[JsonProperty("Accept-Language")]
        //public string AcceptLanguage { get; set; }

        public SeriesSearchRequest(string name = null, string imdbId = null, string zap2itId = null)
        {
            Name = name;
            ImdbId = imdbId;
            Zap2ItId = zap2itId;
            //AcceptLanguage = language;
        }

        public override string ToString()
        {
            JsonSerializerSettings jsonsettings = new JsonSerializerSettings();
            jsonsettings.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.SerializeObject(this, jsonsettings);
        }

        /// <summary>
        /// Returns a valid query string starting with a ? for this object.
        /// </summary>
        /// <returns></returns>
        public string ToQueryString()
        {
            string quey = "";
            string qn = null, qi = null, qz = null;

            if (Name != null && Name.Trim().Length > 0)
                qn = "name=" + Uri.EscapeUriString(Name);
            if (ImdbId != null && ImdbId.Trim().Length > 0)
                qi = "imdbId=" + Uri.EscapeUriString(ImdbId);
            if (Zap2ItId != null && Zap2ItId.Trim().Length > 0)
                qz = "zap2itId=" + Uri.EscapeUriString(Zap2ItId);

            if (qn != null)
            {
                quey = qn;
            }
            if (qi != null)
            {
                if (quey.Length > 0)
                    quey += "&";
                quey += qi;
            }
            if (qz != null)
            {
                if (quey.Length > 0)
                    quey += "&";
                quey += qz;

            }
            if (quey.Length > 0)
                quey = "?" + quey;

            return quey;
        }

    }
}
