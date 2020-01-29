using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheTVDB_API_v2
{
    /// <summary>
    /// Contains an API Key and optional user login used to authenticate against the api.
    /// </summary>
    public class Authentication : ITVDBRequest
    {
        [JsonIgnore]
        private string apikey;

        [JsonIgnore]
        private string userkey;

        [JsonIgnore]
        private string username;

        /// <summary>
        /// Optional: The API Key issued by TheTVDB
        /// https://www.thetvdb.com/member/api
        /// </summary>
        [JsonProperty("apikey")]
        public string ApiKey
        {
            get
            {
                return apikey;
            }
            set
            {
                if (value == null || value.Trim().Length == 0)
                {
                    apikey = null;
                    return;
                }
                apikey = value.Trim();
            }
        }

        /// <summary>
        /// Optional: The User Key issued by TheTVDB
        /// https://www.thetvdb.com/member/api
        /// </summary>
        [JsonProperty("userkey")]
        public string UserKey
        {
            get
            {
                return userkey;
            }
            set
            {
                if (value == null || value.Trim().Length == 0)
                {
                    userkey = null;
                    return;
                }
                userkey = value.Trim();
            }
        }

        /// <summary>
        /// Optional: The User Name issued by TheTVDB
        /// https://www.thetvdb.com/member/api
        /// </summary>
        [JsonProperty("username")]
        public string UserName
        {
            get
            {
                return username;
            }
            set
            {
                if (value == null || value.Trim().Length == 0)
                {
                    username = null;
                    return;
                }
                username = value.Trim();
            }
        }

        public Authentication() { }

        public Authentication(string api_key, string user_name = null, string user_key = null)
        {
            ApiKey = api_key;
            UserName = user_name;
            UserKey = user_key;
        }

        public override string ToString()
        {
            JsonSerializerSettings jsonsettings = new JsonSerializerSettings();
            jsonsettings.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.SerializeObject(this, jsonsettings);
        }
    }
}
