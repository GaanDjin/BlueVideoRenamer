using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TheTVDB_API_v2;

namespace Blue_Video_Renamer
{
    public class VideoInformation
    {
        public static Dictionary<string, TheTVDB_API_v2.Series> lookedUpSeries = new Dictionary<string, TheTVDB_API_v2.Series>();

        public static TheTVDB_API_v2.TheTVDB ThetvDB { get; set; }
        
        internal static Episode[] MatchEpisode(string name, List<Episode> episodes, Series series, bool matchSeries)
        {
            
            if (episodes == null || episodes.Count == 0 || series == null)
                return null;
            if (name == null || name.Trim().Length == 0)
                return null;

            FileInfo file = new FileInfo(name);

            //string[] seriesName = series.SeriesName.Split(' ');

            foreach(Episode ep in episodes)
            {
                //Check file name for series, season, and episode. 
                //If series or season can't be found check parent dir for series name and season.
                
                int season = ep.AiredSeason;
                int epinum = ep.AiredEpisodeNumber;

                Regex reg = new Regex((matchSeries ? "(" + series.SeriesName.Replace(" ", ".?") + ")" : "" )+".*((S" + season.ToString("00") + "|" + season.ToString("00") + "|" + season + ")([^\\\\d]?" + epinum.ToString("00") + ")([^\\\\d]?" + (epinum+1).ToString("00") + "))\\D", RegexOptions.IgnoreCase);

                if (reg.IsMatch(name))
                {
                    foreach(Episode ep2 in episodes)
                    {
                        if (ep2.AiredSeason == ep.AiredSeason && ep2.AiredEpisodeNumber-1 == ep.AiredEpisodeNumber)
                        {
                            return new Episode[] { ep, ep2 };
                        }
                    }
                    return new Episode[] { ep };
                }

                reg = new Regex((matchSeries ? "(" + series.SeriesName.Replace(" ", ".?") + ")" : "") + ".*((S" + season.ToString("00") + "|" + season.ToString("00") + "|" + season + ")([^\\\\d]?" + epinum.ToString("00") + "))\\D", RegexOptions.IgnoreCase);

                if (reg.IsMatch(name))
                    return new Episode[] { ep };
            }

            return new Episode[] { };
        }
                     

        internal static string GetEpisodeName(string name, Series series, Episode[] ep, string format, int filenum, char invalidCharReplacement = '_', string episodedateformat = "YYYY-MM-DD", string seriesdateformat = "YYYY")
        {
            if (format == null || format.Trim().Length == 0 || series == null || ep == null || ep.Length == 0)
                return name;

            if (name == null)
                name = "";

            format = format.Replace('/', Path.DirectorySeparatorChar);
            format = format.Replace('\\', Path.DirectorySeparatorChar);

            char[] invalidFileChars = Path.GetInvalidFileNameChars();

            if (invalidCharReplacement == '\0' || invalidFileChars.Contains(invalidCharReplacement))
                invalidCharReplacement = '_';

            if (episodedateformat == null || episodedateformat.Trim().Length == 0)
                episodedateformat = "YYYY-MM-DD";
            if (seriesdateformat == null || seriesdateformat.Trim().Length == 0)
                seriesdateformat = "YYYY";

           
            string newName = format;

            string epName = ep[0].EpisodeName == null ? "" : ep[0].EpisodeName.Replace('/', invalidCharReplacement).Replace('\\', invalidCharReplacement);
            string airedseason = ep[0].AiredSeason.ToString("##00");
            string airedEpisode = ep[0].AiredEpisodeNumber.ToString("##00");
            string directors = FromArray(ep[0].Directors).Replace('/', invalidCharReplacement).Replace('\\', invalidCharReplacement);
            string writers = FromArray(ep[0].Writers).Replace('/', invalidCharReplacement).Replace('\\', invalidCharReplacement);
            string overview = ep[0].Overview == null ? "" : ep[0].Overview.Replace('/', invalidCharReplacement).Replace('\\', invalidCharReplacement);
            string absnumber = "";
            if(ep[0].AbsoluteNumber.HasValue)
                absnumber = ep[0].AbsoluteNumber.Value.ToString("##00");
            string firstAired = ep[0].FirstAired.ToString(episodedateformat).Replace(':', '-');

            if (ep.Length > 1)
            {
                for (int i = 1; i < ep.Length; i++)
                {
                    epName += ep[i].EpisodeName == null ? "" : " & " + ep[i].EpisodeName.Replace('/', invalidCharReplacement).Replace('\\', invalidCharReplacement);
                    if(ep[0].AiredSeason != ep[i].AiredSeason)
                        airedseason += "-" + ep[i].AiredSeason.ToString("##00"); //Assume same season?
                    airedEpisode += "-" + ep[i].AiredEpisodeNumber.ToString("##00");
                    directors += FromArray(ep[i].Directors).Replace('/', invalidCharReplacement).Replace('\\', invalidCharReplacement);
                    writers += FromArray(ep[i].Writers).Replace('/', invalidCharReplacement).Replace('\\', invalidCharReplacement);
                    overview += ep[i].Overview == null ? "" : ep[i].Overview.Replace('/', invalidCharReplacement).Replace('\\', invalidCharReplacement);
                    if (ep[0].AbsoluteNumber.HasValue)
                        absnumber += ep[i].AbsoluteNumber.Value.ToString("##00");
                    firstAired += ep[i].FirstAired.ToString(episodedateformat).Replace(':', '-');
                }
            }

            newName = newName.Replace("%1", series.SeriesName == null ? "" : series.SeriesName.Replace('/', invalidCharReplacement).Replace('\\', invalidCharReplacement)); //Series Name
            newName = newName.Replace("%series%", series.SeriesName == null ? "" : series.SeriesName.Replace('/', invalidCharReplacement).Replace('\\', invalidCharReplacement)); //Series Name
            newName = newName.Replace("%2", epName); //episodeName
            newName = newName.Replace("%title%", epName); //episodeName
            newName = newName.Replace("%3", airedseason); //airedSeason
            newName = newName.Replace("%season%", airedseason); //airedSeason
            newName = newName.Replace("%4", series.FirstAired.ToString(seriesdateformat).Replace(':', '-')); //Series firstAired
            newName = newName.Replace("%seriesyear%", series.FirstAired.ToString(seriesdateformat).Replace(':', '-')); //Series firstAired
            newName = newName.Replace("%5", FromArray(series.Genre).Replace('/', invalidCharReplacement).Replace('\\', invalidCharReplacement)); //Genre
            newName = newName.Replace("%genre%", FromArray(series.Genre).Replace('/', invalidCharReplacement).Replace('\\', invalidCharReplacement)); //Genre
            newName = newName.Replace("%6", airedEpisode); //airedEpisodeNumber
            newName = newName.Replace("%episodenumber%", airedEpisode); //airedEpisodeNumber
            newName = newName.Replace("%7", name); //File name
            newName = newName.Replace("%filename%", name); //File name
            newName = newName.Replace("%8", filenum.ToString("##00")); //File number
            newName = newName.Replace("%filenumber%", filenum.ToString("##00")); //File number
            newName = newName.Replace("%9", ""); //Comment
            newName = newName.Replace("%comment%", ""); //Comment

            if (newName.Contains("%0") || newName.Contains("%bitrate%") || newName.Contains("%t") || newName.Contains("%playtime%") || newName.Contains("%res%") || newName.Contains("%resolution%"))
            {
                Dictionary<string, List<string>> details = ShellUtilities.GetFileDetails(name);
                if (details.ContainsKey("Bit rate"))
                {
                    newName = newName.Replace("%0", details["Bit rate"][0]); //Bitrate
                    newName = newName.Replace("%bitrate%", details["Bit rate"][0]); //Bitrate
                }
                else
                {
                    newName = newName.Replace("%0", ""); //Bitrate
                    newName = newName.Replace("%bitrate%", ""); //Bitrate
                }

                if (details.ContainsKey("Length"))
                {
                    TimeSpan tslen;
                    if (TimeSpan.TryParse(details["Length"][0], out tslen))
                    {
                        string length = "";

                        if (tslen.TotalMinutes > 120)
                        {
                            length = tslen.Hours + "hrs " + tslen.Minutes + "min " + tslen.Seconds;
                        }
                        else
                            length = tslen.TotalMinutes + "min " + tslen.Seconds;

                        newName = newName.Replace("%t", length); //Play time
                        newName = newName.Replace("%playtime%", length); //Play time
                    }
                    else
                    {
                        newName = newName.Replace("%t", "");
                        newName = newName.Replace("%playtime", "");
                    }
                }
                else
                {
                    newName = newName.Replace("%t", "");
                    newName = newName.Replace("%playtime", "");
                }
                
                if (details.ContainsKey("Dimensions"))
                {
                    newName = newName.Replace("%res%", details["Dimensions"][0]);
                    newName = newName.Replace("%resolution%", details["Dimensions"][0]);
                }
                else
                {
                    newName = newName.Replace("%res%", "");
                    newName = newName.Replace("%resolution%", "");
                }
            }

            newName = newName.Replace("%directors%", directors);//directors
            newName = newName.Replace("%writers%", writers); //writers
            newName = newName.Replace("%overview%", overview); //overview
            newName = newName.Replace("%absolutenumber%", absnumber); //absoluteNumber
            newName = newName.Replace("%status%", series.Status); //status
            newName = newName.Replace("%episodeAired%", firstAired); //Episode firstAired
            newName = newName.Replace("%netowrk%", series.Network.Replace('/', invalidCharReplacement).Replace('\\', invalidCharReplacement)); //network
            newName = newName.Replace("%seriesoverview%", series.Overview.Replace('/', invalidCharReplacement).Replace('\\', invalidCharReplacement)); //Series overview
            newName = newName.Replace("%airsdayofweek%", series.AirsDayOfWeek.Replace('/', invalidCharReplacement).Replace('\\', invalidCharReplacement));  //airsDayOfWeek
            newName = newName.Replace("%airstime%", series.AirsTime.ToString("t").Replace(':', '-')); //airsTime
            if (series.Rating != null)
                newName = newName.Replace("%rating%", series.Rating.Replace('/', invalidCharReplacement).Replace('\\', invalidCharReplacement)); //rating
            else
                newName = newName.Replace("%rating%", "no rating");

            foreach (KeyValuePair<string, string> replace in Configuration.ReplaceChars)
            {
                newName = newName.Replace(replace.Key, replace.Value); //rating
            }

            
            foreach(char c in invalidFileChars)
            {
                if (c == '\\')
                    continue;
                newName = newName.Replace(c, invalidCharReplacement);
            }

            if (name != null && name.Trim().Length > 0)
            {
                System.IO.FileInfo file = new System.IO.FileInfo(name);
                newName += file.Extension;
            }
            return newName;
        }

        //internal static string GetEpisodeName(string name, Series series, Episode[] ep, string text, int filenum, object invalidCharreplacement, string episodeDateFormat, object seriesDateFormat, bool is2part)
        //{
        //    throw new NotImplementedException();
        //}

        //internal static string GetEpisodeName(string name, Series series, Episode[] ep, string text, int filenum, object invalidCharreplacement, object episodeDateFormat, object seriesDateFormat, bool is2part)
        //{
        //    throw new NotImplementedException();
        //}

        public static string FromArray(string[] arr)
        {
            string ret = "";

            if (arr == null || arr.Length == 0)
                return ret;

            foreach(string s in arr)
            {
                ret += s + ",";
            }

            ret = ret.Substring(0, ret.Length - 1);

            return ret;
        }
    }
}
