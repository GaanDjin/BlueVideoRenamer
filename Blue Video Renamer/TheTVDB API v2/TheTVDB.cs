using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TheTVDB_API_v2
{
    /// <summary>
    /// Primary class that handles all API calls to The TV DB. 
    /// Based on v2 of the api: https://api.thetvdb.com/swagger
    /// </summary>
    public class TheTVDB
    {
        /// <summary>
        /// The default location for images stored on the server.
        /// As of 2020-01-29
        /// </summary>
        public const string DefaultImageBaseURL = "https://artworks.thetvdb.com";

        /// <summary>
        /// The default location for api on the server.
        /// As of 2020-01-29
        /// </summary>
        public const string DefaultAPIBaseURL = "https://api.thetvdb.com/";

        private static string baseurl = DefaultAPIBaseURL;
        private static string imagebaseurl = DefaultImageBaseURL;

        /// <summary>
        /// Returns the base url for this API. 
        /// When setting if the value does not start with http:// or https:// then https:// will be prepended.
        /// When setting a trailing / will be added if the value being set doesn't have one.
        /// If the value being set is null or contains only spaces then the APIBaseURL will be set to <see cref="TheTVDB.DefaultAPIBaseURL"/>.
        /// </summary>
        public static string APIBaseURL
        {
            get
            {
                return baseurl;
            }
            set
            {
                if (value == null || value.Trim().Length == 0)
                    baseurl = DefaultAPIBaseURL;
                baseurl = value;
                if (!baseurl.EndsWith("/"))
                    baseurl += "/";

                if (!baseurl.StartsWith("https://") || !baseurl.StartsWith("http://"))
                    baseurl = "https://" + baseurl;
            }
        }


        /// <summary>
        /// Returns the base url for the banners.
        /// When setting if the value does not start with http:// or https:// then https:// will be prepended.
        /// When setting a trailing / will be added if the value being set doesn't have one.
        /// If the value being set is null or contains only spaces then the APIBaseURL will be set to <see cref="TheTVDB.DefaultImageBaseURL"/>.
        /// </summary>
        public static string ImageBaseURL
        {
            get
            {
                return imagebaseurl;
            }
            set
            {
                if (value == null || value.Trim().Length == 0)
                    imagebaseurl = DefaultAPIBaseURL;
                imagebaseurl = value;
                if (!imagebaseurl.EndsWith("/"))
                    imagebaseurl += "/";

                if (!imagebaseurl.StartsWith("https://") || !imagebaseurl.StartsWith("http://"))
                    imagebaseurl = "https://" + imagebaseurl;
            }
        }

        //Thought about this but shouldn't keep in memory right!?
        //private Authentication Credentials;

        /// <summary>
        /// The Token used in all calls to the API.
        /// Any call made within an hour of the expiry time will trigger a renewal call.
        /// </summary>
        public string Token { get; private set; } = null;

        /// <summary>
        /// The time when the Token expires. 
        /// Any call made within an hour of the expiry time will trigger a renewal call.
        /// </summary>
        public DateTime TokenExpiresOn { get; private set; } = DateTime.MinValue;

        /// <summary>
        /// If a call fails this will contain the last error message.
        /// </summary>
        public string LastError { get; private set; }

        /// <summary>
        /// The language <see cref="Language.Abbreviation"/> to request data. 
        /// By default this is empty and the API will return english. 
        /// </summary>
        public string AcceptLanguage { get; set; } = null;

        /// <summary>
        /// The original JSON response of the last call made to the api.
        /// </summary>
        public string LastResponseRaw { get; private set; }

        /// <summary>
        /// Something about specifiying that null values shouls be ignored when making requests.
        /// </summary>
        JsonSerializerSettings jsonsettings;

        /// <summary>
        /// Instaniates a new instance of the API. 
        /// Don't forget to call <see cref="AuthenticateAsync(string, string, string)"/> before making calls!
        /// </summary>
        public TheTVDB()
        {
            jsonsettings = new JsonSerializerSettings();
            jsonsettings.NullValueHandling = NullValueHandling.Ignore;
            jsonsettings.MissingMemberHandling = MissingMemberHandling.Ignore;
            jsonsettings.DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate;
            //jsonsettings.DateParseHandling = DateParseHandling.
        }

        internal enum Requestmethods
        {
            get,
            post
        }

        /// <summary>
        /// Checks to see if there's a Token and that its not expired. If its close to expiring (within one hour) then renew it
        /// </summary>
        /// <returns>True if the token appears to be OK; otherwise false.</returns>
        private async Task<bool> CheckTokenAsync()
        {
            if (Token == null)
            {
                LastError = "No Token. Not authenticated Yet!";
                return false;
            }

            if (DateTime.Now > TokenExpiresOn)
            {
                LastError = "Token Has Expired! Please Renew Token.";
                return false;
            }

            if (DateTime.Now.AddHours(1) > TokenExpiresOn)
            {
                //Less than an hour before token expires. Try to renew.
                bool result = await RefreshTokenAsync();

                return result;
            }

            return true;
        }

        /// <summary>
        /// Makes the actual request to the api based on the full path and, optionally, a request object for the api body.
        /// </summary>
        /// <typeparam name="T">The type of object that the response will be converted to.</typeparam>
        /// <param name="path">The full url including the query string to call</param>
        /// <param name="request">Optional: The Request body that will be converted to JSON.</param>
        /// <param name="reqmethod">The request method. POST for authentication seems to be the only case.</param>
        /// <returns>The deserialized object sent by the server.</returns>
        private async Task<T> MakeRequestAsync<T>(string path, ITVDBRequest request, Requestmethods reqmethod = Requestmethods.get) where T : ITVDBResponse
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(baseurl + path);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Accept = "application/json";

            if (AcceptLanguage != null && AcceptLanguage.Trim().Length > 0)
            {
                httpWebRequest.Headers[HttpRequestHeader.AcceptLanguage] = AcceptLanguage;
            }

            if (Token != null && DateTime.Now < TokenExpiresOn)
            {
                httpWebRequest.Headers[HttpRequestHeader.Authorization] = "Bearer " + Token;
                //httpWebRequest.Credentials = //Authorization: Bearer 
            }

            switch (reqmethod)
            {
                default:
                case Requestmethods.get:
                    httpWebRequest.Method = "GET";
                    break;
                case Requestmethods.post:
                    httpWebRequest.Method = "POST";
                    break;
            }


            if (request != null)
            {
                using (var streamWriter = new StreamWriter(await httpWebRequest.GetRequestStreamAsync()))
                {
                    string json = JsonConvert.SerializeObject(request, jsonsettings);

                    streamWriter.Write(json);
                    //streamWriter.Flush();
                    //streamWriter.Close();
                }
            }
            else
            {
                //httpWebRequest.
                //using (var streamWriter = new StreamWriter(await httpWebRequest.GetRequestStreamAsync())) { }
            }

            T result;
            HttpWebResponse httpResponse;
            try
            {
                httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
            }
            catch (WebException we)
            {
                //result = default(T);
                httpResponse = (HttpWebResponse)we.Response;
                //LastError = we.Message;
                //return default(T);
            }

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                string jsonresult = streamReader.ReadToEnd();

                LastResponseRaw = jsonresult;

                if (jsonresult == null || jsonresult.Trim().Length == 0)
                {
                    LastError = "Response Received but no data from server!";
                    return default(T);
                }

                result = JsonConvert.DeserializeObject<T>(jsonresult);

            }

            if (result.Error != null)
                LastError = result.Error;
            return result;




        }

        /// <summary>
        /// Authenticates the credentials given from the website and stores a Token to use in future calls if the call succeeded.
        /// </summary>
        /// <param name="apiKey">The API Key from the website</param>
        /// <param name="username">Optional: The username. If this is specified then the userkey is required as well. Only needed for User lookups.</param>
        /// <param name="userkey">Optional: The user key or passphrase. If this is specified then the username is required as well. Only needed for User lookups.</param>
        /// <returns>True if the api was able to authenticate and has received a token; otherwise false.</returns>
        public async Task<bool> AuthenticateAsync(string apiKey, string username = null, string userkey = null)
        {
            Token = null;
            TokenExpiresOn = DateTime.MinValue;

            Authentication auth = new Authentication(apiKey, username, userkey);

            TokenResponse result = await MakeRequestAsync<TokenResponse>("login", auth, Requestmethods.post);

            if (result.Error != null || result.Token == null)
            {
                LastError = result.Error;
                return false;
            }

            Token = result.Token;
            TokenExpiresOn = DateTime.Now.AddHours(24);

            return true;
        }

        /// <summary>
        /// Attempts to renew the Authentication token for another 24 hours.
        /// If the renewal fails then the session is invalidated and the program will need to call <see cref="AuthenticateAsync(string, string, string)"/> again.
        /// </summary>
        /// <returns>True if successful otherwise false.</returns>
        public async Task<bool> RefreshTokenAsync()
        {
            TokenResponse result = await MakeRequestAsync<TokenResponse>("refresh_token", null, Requestmethods.get);

            if (result.Error != null || Token == null)
            {
                return false;
            }

            Token = result.Token;
            TokenExpiresOn = DateTime.Now.AddHours(24);

            return true;
        }

        /// <summary>
        /// Searches for TV series based on the name, IMDB Id, or zap2itId. If there is more than one match all matches are returned. 
        /// </summary>
        /// <param name="name">The full or partial name of the series.</param>
        /// <param name="imdbId">Optional: The IMDB ID of the series</param>
        /// <param name="zap2itId">Optional: The Zap2itId of the series.</param>
        /// <returns>An array of series summaries found that mach the search terms.</returns>
        public async Task<SeriesSearchResult[]> SearchSeries(string name, string imdbId = null, string zap2itId = null)
        {
            LastError = "";
            if (!await CheckTokenAsync())
            {
                return null;
            }

            SeriesSearchRequest request = new SeriesSearchRequest(name, imdbId, zap2itId);

            SeriesSearchResults result = await MakeRequestAsync<SeriesSearchResults>("search/series" + request.ToQueryString(), null, Requestmethods.get);

            if (result.Error != null)
            {
                if (result.Error.Equals("Resource not found", StringComparison.CurrentCultureIgnoreCase))
                    return new SeriesSearchResult[0];

                LastError = result.Error;
                return null;
            }

            for (int i = 0; i < result.Results.Length; i++)
            {
                if (result.Results[i].Banner != null)
                    result.Results[i].Banner = ImageBaseURL + result.Results[i].Banner;
                //else
                //    result.Results[i].Banner = "https://www.thetvdb.com/images/missing/movie.jpg";
            }
            return result.Results;
        }

        /// <summary>
        /// Returns the search params that can be used when looking up Series.
        /// *** THIS DOESN"T WORK *** 
        /// It's in the API spec but calls will fail with not authorized. 
        /// </summary>
        /// <returns>A list of keys that can be used when searching for a series</returns>
        public async Task<string[]> SearchSeriesParams()
        {
            LastError = "";
            if (!await CheckTokenAsync())
            {
                return null;
            }

            SearchParamsResults result = await MakeRequestAsync<SearchParamsResults>("/search/series/params", null, Requestmethods.get);

            if (result.Error != null)
            {
                if (result.Error.Equals("Resource not found", StringComparison.CurrentCultureIgnoreCase))
                    return new string[0];

                LastError = result.Error;
                return null;
            }

            return result.Results;
        }

        /// <summary>
        /// Gets the series information based on a search result from <see cref="SearchSeries(string, string, string)"/> 
        /// </summary>
        /// <param name="series">The series summary to look up</param>
        /// <returns>The series details.</returns>
        public async Task<Series> GetSeries(SeriesSearchResult series)
        {
            if (series == null)
            {
                LastError = "null SeriesSearchResult passed to GetSeries!";
                return null;
            }

            if (series.Id <= 0)
            {
                LastError = "Invalid SeriesSearchResult passed to GetSeries!";
                return null;
            }

            return await GetSeries(series.Id.Value);
        }

        /// <summary>
        /// Gets the series information based on a seriesID.
        /// </summary>
        /// <param name="seriesID">The Id of the series to look up.</param>
        /// <returns>The series details.</returns>
        public async Task<Series> GetSeries(int seriesID)
        {
            LastError = "";
            if (!await CheckTokenAsync())
            {
                return null;
            }

            SeriesResponse result = await MakeRequestAsync<SeriesResponse>("series/" + seriesID, null, Requestmethods.get);

            if (result.Error != null)
            {
                if (result.Error.Equals("Resource not found", StringComparison.CurrentCultureIgnoreCase))
                    return null;

                LastError = result.Error;
                return null;
            }

            return result.Series;
        }

        /// <summary>
        /// Gets the actors in a series based on a search result from <see cref="SearchSeries(string, string, string)"/>
        /// </summary>
        /// <param name="series">The series summary to look up</param>
        /// <returns>A list of Actors played in the series and their roles.</returns>
        public async Task<Actor[]> GetActors(SeriesSearchResult series)
        {
            if (series == null)
            {
                LastError = "null SeriesSearchResult passed to GetActors!";
                return null;
            }

            if (series.Id <= 0)
            {
                LastError = "Invalid SeriesSearchResult passed to GetActors!";
                return null;
            }

            return await GetActors(series.Id.Value);
        }

        /// <summary>
        /// Gets the actors information for a series
        /// </summary>
        /// <param name="series">The series to look up.</param>
        /// <returns>A list of Actors played in the series and their roles.</returns>
        public async Task<Actor[]> GetActors(Series series)
        {
            if (series == null)
            {
                LastError = "null Series passed to GetActors!";
                return null;
            }

            if (series.Id <= 0)
            {
                LastError = "Invalid Series passed to GetActors!";
                return null;
            }

            return await GetActors(series.Id.Value);
        }

        /// <summary>
        /// Gets the actors information based on a seriesID.
        /// </summary>
        /// <param name="seriesID">The Id of the series to look up.</param>
        /// <returns>A list of Actors played in the series and their roles.</returns>
        public async Task<Actor[]> GetActors(int seriesID)
        {
            LastError = "";
            if (!await CheckTokenAsync())
            {
                return null;
            }

            ActorsResponse result = await MakeRequestAsync<ActorsResponse>("series/" + seriesID + "/actors", null, Requestmethods.get);

            if (result.Error != null)
            {
                if (result.Error.Equals("Resource not found", StringComparison.CurrentCultureIgnoreCase))
                    return null;

                LastError = result.Error;
                return null;
            }

            for (int i = 0; i < result.Actors.Length; i++)
                result.Actors[i].ImageUrl = ImageBaseURL + result.Actors[i].ImageUrl;

            return result.Actors;
        }

        /// <summary>
        /// Gets the episodes for a series. This is paged by 100 results a page.
        /// </summary>
        /// <param name="series">The series to look up</param>
        /// <param name="page">The paged results for the episodes</param>
        /// <returns>The list of episodes and page data.</returns>
        public async Task<EpisodesResponse> GetEpisodes(SeriesSearchResult series, int page = 1)
        {
            if (series == null)
            {
                LastError = "null SeriesSearchResult passed to GetEpisodes!";
                return null;
            }

            if (series.Id <= 0)
            {
                LastError = "Invalid SeriesSearchResult passed to GetEpisodes!";
                return null;
            }

            return await GetEpisodes(series.Id.Value, page);
        }

        /// <summary>
        /// Gets the episodes for a series. This is paged by 100 results a page.
        /// </summary>
        /// <param name="series">The series to look up</param>
        /// <param name="page">The paged results for the episodes</param>
        /// <returns>The list of episodes and page data.</returns>
        public async Task<EpisodesResponse> GetEpisodes(Series series, int page = 1)
        {
            if (series == null)
            {
                LastError = "null Series passed to GetEpisodes!";
                return null;
            }

            if (series.Id <= 0)
            {
                LastError = "Invalid Series passed to GetEpisodes!";
                return null;
            }

            return await GetEpisodes(series.Id.Value, page);
        }

        /// <summary>
        /// Gets the episodes for a series. This is paged by 100 results a page.
        /// </summary>
        /// <param name="seriesID">The series to look up</param>
        /// <param name="page">The paged results for the episodes</param>
        /// <returns>The list of episodes and page data.</returns>
        public async Task<EpisodesResponse> GetEpisodes(int seriesID, int page = 1)
        {
            LastError = "";
            if (!await CheckTokenAsync())
            {
                return null;
            }

            string pagequery = "";

            if (page > 0)
                pagequery = "?page=" + page;

            EpisodesResponse result = await MakeRequestAsync<EpisodesResponse>("series/" + seriesID + "/episodes" + pagequery, null, Requestmethods.get);

            if (result.Error != null)
            {
                if (result.Error.Equals("Resource not found", StringComparison.CurrentCultureIgnoreCase))
                {
                    result = new EpisodesResponse();
                    result.Episodes = new Episode[0];
                    result.Errors = null;
                    result.PageInfo = null;
                    return result;
                }
                LastError = result.Error;
                return null;
            }

            for (int i = 0; i < result.Episodes.Length; i++)
                result.Episodes[i].ThumbUrl = ImageBaseURL + result.Episodes[i].ThumbUrl;

            return result;
        }

        /// <summary>
        /// Gets all episodes for a given series. 
        /// Handles the paged calls and returns all of them.
        /// </summary>
        /// <param name="series">The series to look up</param>
        /// <returns>A list of all episodes for the given series.</returns>
        public async Task<Episode[]> GetAllEpisodes(SeriesSearchResult series)
        {
            if (series == null)
            {
                LastError = "null SeriesSearchResult passed to GetAllEpisodes!";
                return null;
            }

            if (series.Id <= 0)
            {
                LastError = "Invalid SeriesSearchResult passed to GetAllEpisodes!";
                return null;
            }

            return await GetAllEpisodes(series.Id.Value);
        }

        /// <summary>
        /// Gets all episodes for a given series. 
        /// Handles the paged calls and returns all of them.
        /// </summary>
        /// <param name="series">The series to look up</param>
        /// <returns>A list of all episodes for the given series.</returns>
        public async Task<Episode[]> GetAllEpisodes(Series series)
        {
            if (series == null)
            {
                LastError = "null Series passed to GetAllEpisodes!";
                return null;
            }

            if (series.Id <= 0)
            {
                LastError = "Invalid Series passed to GetAllEpisodes!";
                return null;
            }

            return await GetAllEpisodes(series.Id.Value);
        }

        /// <summary>
        /// Gets all episodes for a given series. 
        /// Handles the paged calls and returns all of them.
        /// </summary>
        /// <param name="series">The series to look up</param>
        /// <returns>A list of all episodes for the given series.</returns>
        public async Task<Episode[]> GetAllEpisodes(int seriesID)
        {
            EpisodesResponse response = await GetEpisodes(seriesID);

            if (response == null)
                return null;

            if (response.PageInfo == null)
                return response.Episodes;

            if (response.PageInfo.First == response.PageInfo.Last)
                return response.Episodes;

            List<Episode> episodes = new List<Episode>(response.Episodes);

            int page = response.PageInfo.First.Value;
            int lastPage = response.PageInfo.Last.Value;
            while (page <= lastPage)
            {
                response = Task.Run(async () => { return await GetEpisodes(seriesID, page++); }).Result;
                //var task = GetEpisodes(seriesID, page++);
                //task.Wait();
                //response = task.Result;

                if (response.Episodes != null && response.Episodes.Length > 0)
                {
                    
                    episodes.AddRange(response.Episodes);
                }
            }
            //foreach (Episode ep in response.Episodes)
            //{
            //    if (!episodes.Contains(ep))
            //        episodes.Add(ep);
            //}
            //episodes;
            return episodes.Distinct().ToArray();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="seriesID">The default series ID is Gravity Falls. This parameter doesn't seem to matter.</param>
        /// <returns></returns>
        public async Task<string[]> GetEpisodeSearchParameters(int seriesID = 259972)
        {
            LastError = "";
            if (!await CheckTokenAsync())
            {
                return null;
            }

            SearchParamsResults result = await MakeRequestAsync<SearchParamsResults>("series/" + seriesID + "/episodes/query/params", null, Requestmethods.get);

            if (result.Error != null)
            {
                if (result.Error.Equals("Resource not found", StringComparison.CurrentCultureIgnoreCase))
                {
                    return null;
                }
                LastError = result.Error;
                return null;
            }

            return result.Results;
        }

        /// <summary>
        /// Searches the list of episodes in a series by the given search parameters. This is paged by 100 results a page.
        /// </summary>
        /// <param name="series">The series to lookup</param>
        /// <param name="searchparams">The parameters of </param>
        /// <param name="page">The page of search results</param>
        /// <returns>The list of episodes and page data.</returns>
        public async Task<EpisodesResponse> QueryEpisodes(SeriesSearchResult series, int page = 1, Dictionary<string, string> searchparams = null)
        {
            if (series == null)
            {
                LastError = "null SeriesSearchResult passed to QueryEpisodes!";
                return null;
            }

            if (series.Id <= 0)
            {
                LastError = "Invalid SeriesSearchResult passed to QueryEpisodes!";
                return null;
            }

            return await QueryEpisodes(series.Id.Value, page, searchparams);
        }

        /// <summary>
        /// Searches the list of episodes in a series by the given search parameters. This is paged by 100 results a page.
        /// </summary>
        /// <param name="series">The series to lookup</param>
        /// <param name="searchparams">The parameters of </param>
        /// <param name="page">The page of search results</param>
        /// <returns>The list of episodes and page data.</returns>
        public async Task<EpisodesResponse> QueryEpisodes(Series series, int page = 1, Dictionary<string, string> searchparams = null)
        {
            if (series == null)
            {
                LastError = "null Series passed to QueryEpisodes!";
                return null;
            }

            if (series.Id <= 0)
            {
                LastError = "Invalid Series passed to QueryEpisodes!";
                return null;
            }

            return await QueryEpisodes(series.Id.Value, page, searchparams);
        }

        /// <summary>
        /// Searches the list of episodes in a series by the given search parameters. This is paged by 100 results a page.
        /// </summary>
        /// <param name="series">The series to lookup</param>
        /// <param name="searchparams">The parameters of </param>
        /// <param name="page">The page of search results</param>
        /// <returns>The list of episodes and page data.</returns>
        public async Task<EpisodesResponse> QueryEpisodes(int seriesID, int page = 1, Dictionary<string, string> searchparams = null)
        {
            LastError = "";
            if (!await CheckTokenAsync())
            {
                return null;
            }

            if (searchparams == null || searchparams.Count == 0)
            {
                LastError = "search params cannot be empty when searching for episodes!";
                return null;
            }

            EpisodesResponse result = await MakeRequestAsync<EpisodesResponse>("series/" + seriesID + "/episodes/query" + BuildQueryString(searchparams), null, Requestmethods.get);

            if (result.Error != null)
            {
                if (result.Error.Equals("Resource not found", StringComparison.CurrentCultureIgnoreCase))
                {
                    result = new EpisodesResponse();
                    result.Episodes = new Episode[0];
                    result.Errors = null;
                    result.PageInfo = null;
                    return result;
                }
                LastError = result.Error;
                return null;
            }

            for (int i = 0; i < result.Episodes.Length; i++)
                result.Episodes[i].ThumbUrl = ImageBaseURL + result.Episodes[i].ThumbUrl;

            return result;
        }

        /// <summary>
        /// Gets all episodes for a given series that match the given search parameters
        /// </summary>
        /// <param name="series">The series to look up</param>
        /// <param name="searchparams">The search parameters organized by search key and value</param>
        /// <returns>A list of all episodes for the given series.</returns>
        public async Task<Episode[]> QueryEpisodes(SeriesSearchResult series, Dictionary<string, string> searchparams = null)
        {
            if (series == null)
            {
                LastError = "null SeriesSearchResult passed to QueryEpisodes!";
                return null;
            }

            if (series.Id <= 0)
            {
                LastError = "Invalid SeriesSearchResult passed to QueryEpisodes!";
                return null;
            }

            return await QueryEpisodes(series.Id.Value, searchparams);
        }

        /// <summary>
        /// Gets all episodes for a given series that match the given search parameters
        /// </summary>
        /// <param name="series">The series to look up</param>
        /// <param name="searchparams">The search parameters organized by search key and value</param>
        /// <returns>A list of all episodes for the given series.</returns>
        public async Task<Episode[]> QueryEpisodes(Series series, Dictionary<string, string> searchparams = null)
        {
            if (series == null)
            {
                LastError = "null Series passed to QueryEpisodes!";
                return null;
            }

            if (series.Id <= 0)
            {
                LastError = "Invalid Series passed to QueryEpisodes!";
                return null;
            }

            return await QueryEpisodes(series.Id.Value, searchparams);
        }

        /// <summary>
        /// Gets all episodes for a given series. 
        /// Handles the paged calls and returns all of them.
        /// </summary>
        /// <param name="series">The series to look up</param>
        /// <returns>A list of all episodes for the given series.</returns>
        public async Task<Episode[]> QueryEpisodes(int seriesID, Dictionary<string, string> searchparams = null)
        {
            EpisodesResponse response = await QueryEpisodes(seriesID, 1, searchparams);

            if (response == null)
                return null;

            if (response.PageInfo == null)
                return response.Episodes;

            if (response.PageInfo.First == response.PageInfo.Last)
                return response.Episodes;

            List<Episode> episodes = new List<Episode>(response.Episodes);

            while (response.PageInfo.Next > 0)
            {
                response = await QueryEpisodes(seriesID, response.PageInfo.Next.Value, searchparams);

                if (response.Episodes != null && response.Episodes.Length > 0)
                    episodes.AddRange(response.Episodes);
            }

            return episodes.ToArray();
        }

        /// <summary>
        /// Takes in a dictionary of keys and values and outputs a url safe query string.
        /// Alywas starts with a ? if there are values in parameters.
        /// if parameters is empty then an empty string will be returned.
        /// eg. 
        /// If the parameters contains Kay: "cat" Value: "big caracal" and Key: "colour" Value: "red" then the output will be "?cat=big%20caracal&colour=red"
        /// </summary>
        /// <param name="parameters">The key value pairs to convert into a query string</param>
        /// <returns>The query string.</returns>
        private string BuildQueryString(Dictionary<string, string> parameters)
        {
            if (parameters == null || parameters.Count == 0)
            {
                return "";
            }

            bool first = true;
            string toreturn = "";
            foreach (KeyValuePair<string, string> kvp in parameters)
            {
                if (!first)
                {
                    toreturn += "&" + Uri.EscapeUriString(kvp.Key) + "=" + Uri.EscapeUriString(kvp.Value);
                }
            }

            return "?" + toreturn;
        }


        /// <summary>
        /// Gets a summary about the seasons and total episodes in the requested series.
        /// </summary>
        /// <param name="seriesID">The series to lookup</param>
        /// <returns>An object containing the series episodes summary.</returns>
        public async Task<SeriesEpisodesSummary> QueryEpisodesSummary(SeriesSearchResult series)
        {
            if (series == null)
            {
                LastError = "null SeriesSearchResult passed to v!";
                return null;
            }

            if (series.Id <= 0)
            {
                LastError = "Invalid SeriesSearchResult passed to QueryEpisodesSummary!";
                return null;
            }

            return await QueryEpisodesSummary(series.Id.Value);
        }

        /// <summary>
        /// Gets a summary about the seasons and total episodes in the requested series.
        /// </summary>
        /// <param name="seriesID">The series to lookup</param>
        /// <returns>An object containing the series episodes summary.</returns>
        public async Task<SeriesEpisodesSummary> QueryEpisodesSummary(Series series)
        {
            if (series == null)
            {
                LastError = "null Series passed to QueryEpisodesSummary!";
                return null;
            }

            if (series.Id <= 0)
            {
                LastError = "Invalid Series passed to QueryEpisodesSummary!";
                return null;
            }

            return await QueryEpisodesSummary(series.Id.Value);
        }

        /// <summary>
        /// Gets a summary about the seasons and total episodes in the requested series.
        /// </summary>
        /// <param name="seriesID">The ID of the series to lookup</param>
        /// <returns>An object containing the series episodes summary.</returns>
        public async Task<SeriesEpisodesSummary> QueryEpisodesSummary(int seriesID)
        {
            LastError = "";
            if (!await CheckTokenAsync())
            {
                return null;
            }

            SeriesEpisodesSummary result = await MakeRequestAsync<SeriesEpisodesSummary>("series/" + seriesID + "/episodes/summary", null, Requestmethods.get);

            if (result.Error != null)
            {
                if (result.Error.Equals("Resource not found", StringComparison.CurrentCultureIgnoreCase))
                {
                    result = new SeriesEpisodesSummary();
                    return result;
                }
                LastError = result.Error;
                return null;
            }
            
            return result;
        }

        /// <summary>
        /// Returns a summary of the images for a particular series
        /// </summary>
        /// <param name="series">The series to lookup</param>
        /// <returns>The summary information of the images the server has on this series.</returns>
        public async Task<SeriesImagesCount> ImageSummary(SeriesSearchResult series)
        {
            if (series == null)
            {
                LastError = "null SeriesSearchResult passed to ImageSummary!";
                return null;
            }

            if (series.Id <= 0)
            {
                LastError = "Invalid SeriesSearchResult passed to ImageSummary!";
                return null;
            }

            return await ImageSummary(series.Id.Value);
        }

        /// <summary>
        /// Returns a summary of the images for a particular series
        /// </summary>
        /// <param name="series">The series to lookup</param>
        /// <returns>The summary information of the images the server has on this series.</returns>
        public async Task<SeriesImagesCount> ImageSummary(Series series)
        {
            if (series == null)
            {
                LastError = "null Series passed to ImageSummary!";
                return null;
            }

            if (series.Id <= 0)
            {
                LastError = "Invalid Series passed to ImageSummary!";
                return null;
            }

            return await ImageSummary(series.Id.Value);
        }

        /// <summary>
        /// Returns a summary of the images for a particular series
        /// </summary>
        /// <param name="seriesID">The ID of the series to lookup</param>
        /// <returns>The summary information of the images the server has on this series.</returns>
        public async Task<SeriesImagesCount> ImageSummary(int seriesID)
        {
            LastError = "";
            if (!await CheckTokenAsync())
            {
                return null;
            }

            SeriesImagesCounts result = await MakeRequestAsync<SeriesImagesCounts>("series/" + seriesID + "/images", null, Requestmethods.get);

            if (result.Error != null)
            {
                if (result.Error.Equals("Resource not found", StringComparison.CurrentCultureIgnoreCase))
                {
                    return new SeriesImagesCount();
                }
                LastError = result.Error;
                return null;
            }

            return result.Count;
        }

        /// <summary>
        /// Gets an array of image data (including a link and size) for the selected series based on the specified search parameters (<see cref="QueryImageParams(Series)"/>).
        /// </summary>
        /// <param name="series">The series to lookup</param>
        /// <param name="searchparams">The parameters by Key and Value to query.</param>
        /// <returns>An Array of image query results. Empty if there were no results. Null if there was an error.</returns>
        public async Task<SeriesImageQueryResult[]> QueryImages(SeriesSearchResult series, Dictionary<string, string> searchparams = null)
        {
            if (series == null)
            {
                LastError = "null SeriesSearchResult passed to QueryImages!";
                return null;
            }

            if (series.Id <= 0)
            {
                LastError = "Invalid SeriesSearchResult passed to QueryImages!";
                return null;
            }

            return await QueryImages(series.Id.Value, searchparams);
        }

        /// <summary>
        /// Gets an array of image data (including a link and size) for the selected series based on the specified search parameters (<see cref="QueryImageParams(Series)"/>).
        /// </summary>
        /// <param name="series">The series to lookup</param>
        /// <param name="searchparams">The parameters by Key and Value to query.</param>
        /// <returns>An Array of image query results. Empty if there were no results. Null if there was an error.</returns>
        public async Task<SeriesImageQueryResult[]> QueryImages(Series series, Dictionary<string, string> searchparams = null)
        {
            if (series == null)
            {
                LastError = "null Series passed to QueryImages!";
                return null;
            }

            if (series.Id <= 0)
            {
                LastError = "Invalid Series passed to QueryImages!";
                return null;
            }

            return await QueryImages(series.Id.Value, searchparams);
        }

        /// <summary>
        /// Gets an array of image data (including a link and size) for the selected series based on the specified search parameters (<see cref="QueryImageParams(Series)"/>).
        /// </summary>
        /// <param name="seriesID">The ID of the series to lookup</param>
        /// <param name="searchparams">The parameters by Key and Value to query.</param>
        /// <returns>An Array of image query results. Empty if there were no results. Null if there was an error.</returns>
        public async Task<SeriesImageQueryResult[]> QueryImages(int seriesID, Dictionary<string, string> searchparams = null)
        {
            LastError = "";
            if (!await CheckTokenAsync())
            {
                return null;
            }

            SeriesImageQueryResults result = await MakeRequestAsync<SeriesImageQueryResults>("series/" + seriesID + "/images/query" + BuildQueryString(searchparams), null, Requestmethods.get);

            if (result.Error != null)
            {
                if (result.Error.Equals("Resource not found", StringComparison.CurrentCultureIgnoreCase))
                {
                    return new SeriesImageQueryResult[0];
                }
                LastError = result.Error;
                return null;
            }

            for (int i = 0; i < result.Data.Length; i++)
            {
                if (result.Data[i].FileName != null)
                        result.Data[i].FileName = ImageBaseURL + result.Data[i].FileName;
                if (result.Data[i].Thumbnail != null)
                    result.Data[i].Thumbnail = ImageBaseURL + result.Data[i].Thumbnail;
            }
            return result.Data;
        }

        /// <summary>
        /// Gets an array of value keys that can be used in <see cref="QueryImages(Series, Dictionary{string, string})"/>.
        /// </summary>
        /// <param name="series">The series to lookup</param>
        /// <returns>An array of keys to use for searching images in a series</returns>
        public async Task<SeriesImagesQueryParam[]> QueryImageParams(SeriesSearchResult series)
        {
            if (series == null)
            {
                LastError = "null SeriesSearchResult passed to QueryImageParams!";
                return null;
            }

            if (series.Id <= 0)
            {
                LastError = "Invalid SeriesSearchResult passed to QueryImageParams!";
                return null;
            }

            return await QueryImageParams(series.Id.Value);
        }

        /// <summary>
        /// Gets an array of value keys that can be used in <see cref="QueryImages(Series, Dictionary{string, string})"/>.
        /// </summary>
        /// <param name="series">The series to lookup</param>
        /// <returns>An array of keys to use for searching images in a series</returns>
        public async Task<SeriesImagesQueryParam[]> QueryImageParams(Series series)
        {
            if (series == null)
            {
                LastError = "null Series passed to QueryImageParams!";
                return null;
            }

            if (series.Id <= 0)
            {
                LastError = "Invalid Series passed to QueryImageParams!";
                return null;
            }

            return await QueryImageParams(series.Id.Value);
        }

        /// <summary>
        /// Gets an array of value keys that can be used in <see cref="QueryImages(Series, Dictionary{string, string})"/>.
        /// </summary>
        /// <param name="seriesID">The ID of the series to lookup</param>
        /// <returns>An array of keys to use for searching images in a series</returns>
        public async Task<SeriesImagesQueryParam[]> QueryImageParams(int seriesID)
        {
            LastError = "";
            if (!await CheckTokenAsync())
            {
                return null;
            }

            SeriesImagesQueryParams result = await MakeRequestAsync<SeriesImagesQueryParams>("series/" + seriesID + "/images/query/params", null, Requestmethods.get);

            if (result.Error != null)
            {
                if (result.Error.Equals("Resource not found", StringComparison.CurrentCultureIgnoreCase))
                {
                    return new SeriesImagesQueryParam[0];
                }
                LastError = result.Error;
                return null;
            }

            return result.Parameters;
        }

        /// <summary>
        /// Gets information about a particular language, given the language ID.
        /// </summary>
        /// <param name="id">ID of the language</param>
        /// <returns> Information about a particular language, given the language ID.</returns>
        public async Task<Language> GetLanguage(int id)
        {
            LastError = "";
            if (!await CheckTokenAsync())
            {
                return null;
            }

            Languages result = await MakeRequestAsync<Languages>("languages/" + id, null, Requestmethods.get);

            if (result.Error != null || result.Data == null || result.Data.Length == 0)
            {
                if (result.Error.Equals("Resource not found", StringComparison.CurrentCultureIgnoreCase))
                {
                    return new Language();
                }
                LastError = result.Error;
                return null;
            }

            return result.Data[0];
        }

        /// <summary>
        /// Gets all available languages. These language abbreviations can be used in the Accept-Language header for routes that return translation records.
        /// </summary>
        /// <returns></returns>
        public async Task<Language[]> GetLanguages()
        {
            LastError = "";
            if (!await CheckTokenAsync())
            {
                return null;
            }

            Languages result = await MakeRequestAsync<Languages>("languages", null, Requestmethods.get);

            if (result.Error != null)
            {
                if (result.Error.Equals("Resource not found", StringComparison.CurrentCultureIgnoreCase))
                {
                    return new Language[0];
                }
                LastError = result.Error;
                return null;
            }

            return result.Data;
        }
    }

}
