using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTVDB_API_v2
{
    /// <summary>
    /// The server response to an Authentication request. 
    /// Contains a Token to be used for all subsequent requests or an error if authentication failed.
    /// </summary>
    internal class TokenResponse : ITVDBResponse
    {
        [JsonProperty("Error")]
        public string Error { get; set; }
        [JsonProperty("token")]
        public string Token;

        public override string ToString()
        {
            JsonSerializerSettings jsonsettings = new JsonSerializerSettings();
            jsonsettings.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.SerializeObject(this, jsonsettings);
        }
    }
}
