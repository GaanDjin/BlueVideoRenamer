using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.IO;

namespace Blue_Video_Renamer
{
    public class Configuration
    {
        public static readonly List<string> RenameFormatValues = new List<string>(new string[] {
            "%1", "%series%",
         "%2", "%title%",
         "%3", "%season%",
         "%4", "%seriesyear%",
         "%5", "%genre%",
         "%6", "%episodenumber%",
         "%7", "%filename%",
         "%8", "%filenumber%",
         "%9", "%comment%",
         "%0", "%bitrate%",
         "%t", "%playtime%",
         "%res%", "%resolution%",
         "%directors%",
         "%writers%",
         "%overview%",
         "%absolutenumber%",
         "%status%" ,
         "%episodeAired%", 
         "%netowrk%",
         "%seriesoverview%",
         "%airsdayofweek%",
         "%airstime%",
         "%rating%"
        });

        public static string SavePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + Path.DirectorySeparatorChar + "FromThe.Blue" + Path.DirectorySeparatorChar + "Video Renamer" + Path.DirectorySeparatorChar + "Settings.json";

        private static Configuration instance;
        public static Configuration Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = Load(SavePath);
                    if (instance == null)
                        instance = new Configuration();
                }

                return instance;
            }
            set
            {
                instance = value;
            }
        }

        #region Public Properties

        /// <summary>
        /// An Array of RegEx patterns to check if a file is a valid video file. Generally this is just a RexEx matching file extensions.
        /// 
        /// WebM	.webm	Matroska	VP8, VP9	Vorbis, Opus	Royalty-free format created for HTML5 video.
        /// Matroska.mkv Matroska    Any Any
        /// Flash Video(FLV)   .flv FLV VP6, Sorenson Spark, Screen video, Screen video 2, H.264	MP3, ADPCM, Nellymoser, Speex, AAC Use of the H.264 and AAC compression formats in the FLV file format has some limitations and authors of Flash Player strongly encourage everyone to embrace the new standard F4V file format[2] de facto standard for web-based streaming video(over RTMP).
        /// F4V.flv MPEG-4 Part 12	H.264	MP3, AAC Replacement for FLV.
        /// Vob.vob VOB H.262/MPEG-2 Part 2 or MPEG-1 Part 2	PCM, DTS, MPEG-1, Audio Layer II(MP2), or Dolby Digital(AC-3) Files in VOB format have.vob filename extension and are typically stored in the VIDEO_TS folder at the root of a DVD.The VOB format is based on the MPEG program stream format.
        /// Ogg Video.ogv, .ogg Ogg Theora, Dirac Vorbis, FLAC
        /// Dirac	.drc? Dirac	?	
        /// GIF.gif N/A N/A none    Simple animation, inefficient compression, no sound, widely supported
        /// Video alternative to GIF	.gifv HTML    Any none    Not standardized, and not a real video file in the classical meaning since it merely references the real video file (e.g.a.webm file), which has to exist separately elsewhere.A.gifv "file" is simply a HTML webpage which includes a HTML5 video tag, where the video has no sound. As there were large communities online which create art using the medium of short soundless videos in GIF format, GIFV was created as a functionally similar replacement with vastly smaller filesizes than the inefficient GIF format.
        /// Multiple-image Network Graphics.mng N/A N/A none    Inefficient, not widely used.
        /// AVI.avi AVI any any Uses RIFF
        /// QuickTime File Format.mov, .qt QuickTime   Many[3] AAC, MP3, others[3]
        /// Windows Media Video.wmv ASF Windows Media Video, Windows Media Video Screen, Windows Media Video Image Windows Media Audio, Sipro ACELP.net
        /// Raw video format.yuv    Further documentation needed Doesn't apply	Doesn't apply   Supports all resolutions, sampling structures, and frame rates
        /// RealMedia (RM)  .rm RealMedia   RealVideo RealAudio   Made for RealPlayer
        /// RealMedia Variable Bitrate(RMVB)   .rmvb RealMedia Variable Bitrate  RealVideo RealAudio   Made for RealPlayer
        /// Advanced Systems Format(ASF)   .asf ASF any any
        /// AMV video format.amv Modified version of AVI[4] Variant of Motion JPEG Variant of IMA, ADPCM   Proprietary video file format produced for MP4 players and S1 MP3 players with video playback
        /// MPEG-4 Part 14 (MP4)	.mp4, .m4p(with DRM), .m4v MPEG-4 Part 12	H.264, MPEG-4 Part 2, MPEG-2, MPEG-1	Advanced Audio Coding, MP3, others
        /// MPEG-1	.mpg, .mp2, .mpeg, .mpe, .mpv MPEG-1 part 1	MPEG-1 part 2	MPEG-1 Audio Layer I, MPEG-1 Audio Layer I, MPEG-1 Audio Layer III(MP3)    Old, but very widely used due to installed base.
        /// MPEG-2 – Video.mpg, .mpeg, .m2v? H.262	AAC, MP3, MPEG-2 Part 3, others
        /// M4V – (file format for videos for iPods and PlayStation Portables developed by Apple)	.m4v MPEG-4 Part 12	H.264	AAC, Dolby Digital  Developed by Apple, used in iTunes.Very similar to MP4 format, but may optionally have DRM.
        /// SVI.svi?   ?   ? Samsung video format for portable players
        /// 3GPP	.3gp MPEG-4 Part 12	MPEG-4 Part 2, H.263, H.264	AMR-NB, AMR-WB, AMR-WB+, AAC-LC, HE-AAC v1 or Enhanced aacPlus(HE-AAC v2)  Common video format for cell phones
        /// 3GPP2	.3g2 MPEG-4 Part 12	MPEG-4 Part 2, H.263, H.264	AMR-NB, AMR-WB, AMR-WB+, AAC-LC, HE-AAC v1 or Enhanced aacPlus(HE-AAC v2), EVRC, SMV or VMR-WB Common video format for cell phones
        /// Material Exchange Format(MXF)  .mxf MXF ?   ?
        /// ROQ.roq    ?	?	?	used by Quake 3[5]
        /// Nullsoft Streaming Video (NSV)  .nsv NSV ?   ? For streaming video content over the Internet
        /// Flash Video(FLV)   .flv.f4v.f4p.f4a.f4b Audio, video, text, data    Adobe Flash Platform SWF, F4V, ISO base media file format Developed by the Adobe Flash Platform
        /// </summary>
        public static string[] VideoFileExtensions { get { return Instance.VideoExtensions; } set { Instance.VideoExtensions = value; } }

        /// <summary>
        /// A list of RegEx patterns for files that may be downloaded but unwanted.
        /// </summary>
        public static string[] UnwantedFiles { get { return Instance.Unwantedfiles; } set { Instance.Unwantedfiles = value; } }

        /// <summary>
        /// Identifies if while looking at a file change for a video in the folder files of this type should be deleted or not.
        /// </summary>
        public static bool DeleteUnwantedFiles { get { return Instance.Deleteunwantedfiles; } set { Instance.Deleteunwantedfiles = value; } }

        /// <summary>
        /// Identifies if while looking at a file change for a video in the folder files of this type should be deleted or not.
        /// </summary>
        public static bool DeleteDuplicates { get { return Instance.Deleteduplicates; } set { Instance.Deleteduplicates = value; } }

        /// <summary>
        /// Determins if an accompanying file (Like a translation file) should be renamed when a video file is renamed.
        /// Forinstance: When renaming "my.show.103.mkv" to "My Show S01E03.mkv" 
        /// if there is another file with the same name but different extension like "my.show.103.srt" it should also be renamed to "My Show S01E03.srt".
        /// </summary>
        public static bool RenameMatchingAccompanyingFiles { get { return Instance.Renamematchingaccompanyingfiles; } set { Instance.Renamematchingaccompanyingfiles = value; } }

        /// <summary>
        /// API Key to access The TV DB Api.
        /// </summary>
        public static string TheTVDBApiKey { get { return Instance.ApiKey; } set { Instance.ApiKey = value; } }

        /// <summary>
        /// The format to display dates that are used by episodes.
        /// </summary>
        public static string EpisodeDateFormat { get { return Instance.Episodedateformat; } set { Instance.Episodedateformat = value; } }

        /// <summary>
        /// The format to display dates that are used by searies. Ie. air date.
        /// </summary>
        public static string SeriesDateFormat { get { return Instance.Seriesdateformat; } set { Instance.Seriesdateformat = value; } }

        /// <summary>
        /// While renaming a file if the name contains an invalid character that the OS doesn't allow in its file system the invalid character will be replaced by this value.
        /// </summary>
        public static char InvalidCharReplacement { get { return Instance.Invalidcharreplacement; } set { Instance.Invalidcharreplacement = value; } }

        /// <summary>
        /// When renaming a file if there are files in a series that are missing this option tells the program to create an empty file of that 
        /// episodes name with the extention ".missing". Good for identifying missing episodes in explorer.
        /// </summary>
        public static bool MakeMissingPlaceholder { get { return Instance.Makemissingplaceholder; } set { Instance.Makemissingplaceholder = value; } }

        /// <summary>
        /// The last root path treeview was expended to. For remembering next time. 
        /// If the path is invalid it'll expand until it can't find the next node and gives up.
        /// </summary>
        public static string LastRootPath { get { return Instance.Lastrootpath; } set { Instance.Lastrootpath = value; } }

        /// <summary>
        /// The formats used as a template for renaming files. 
        /// 
        /// %1, %series% - The name of the series
        /// %2, %title% - The title of the episode
        /// %3, %season% - the season number (w/ leading zero)
        /// %4, %seriesyear% - the year the series was aired
        /// %5, %genre% - the genres this series belongs to. Comma seperated.
        /// %6, %episodenumber% - The number of the episode in the season
        /// %7, %filename% - The original name of the file
        /// %8, %filenumber% - the number of the file being processed.
        /// %9, %comment% - The comment. Not implemented
        /// %0, %bitrate% - Attempts to get the bitrate from the OS. If it fails it will be removed.
        /// %t, %playtime% - Attempts to get the The Duration of the video from the OS. If it fails it will be removed.
        /// &gt; 120 min then show "x hrs y min z sec"
        /// &lt;= 120 min then show "y min z sec"
        /// %res%, %resolution% - Attempts to get the The resolution of the video from the OS. If it fails it will be removed.
        /// %directors% - The episode directors, comma seperated
        /// %writers% - The episode writers, comma seperated
        /// %overview% - The episode summary / synopsis. (Warning this will probably cause the app to flip out due to windows max file length of 255 chars!)
        /// %absolutenumber% - The absolute number of this episode across all seasons.
        /// %status% - The status of the series. 
        /// %episodeAired% - The date the episode was first aired. 
        /// %netowrk% - The network the episode was first aired on.
        /// %seriesoverview% - The series summary / synopsis. (Warning this will probably cause the app to flip out due to windows max file length of 255 chars!)
        /// %airsdayofweek% - The days of the week episodes air on, comma seperated.
        /// %airstime% - the time of day the episodes starts, comma seperated
        /// %rating% - The TVDB rating for this episode.
        /// 
        /// Other characters will be treated at literal values. For instance:
        /// "%1 - S%3E%6 - %2" will result in an output file like this: "My TV Show - S01E02 - The Second episode"
        /// </summary>
        public static string[] RenameFormats { get { return Instance.Renameformats; } set { Instance.Renameformats = value; } }

        /// <summary>
        /// Any strings in the file that match ReplaceChars.Key will be replaced with it's corisponding Value before renaming.
        /// </summary>
        public static Dictionary<string, string> ReplaceChars { get { return Instance.Replacechars; } set { Instance.Replacechars = value; } }

        #endregion

        #region Instance Variables for Serialization.

        [JsonProperty("VideoFileExtensions")]
        public string[] VideoExtensions = new string[] {
            "\\.3g2$",
            "\\.3gp$",
            "\\.amv$",
            "\\.asf$",
            "\\.avi$",
            "\\.drc$",
            "\\.flv$",
            "\\.f4v$",
            "\\.f4p$",
            "\\.f4a$",
            "\\.f4b$",
            "\\.gif$",
            "\\.gifv$",
            "\\.m2v$",
            "\\.m4p$",
            "\\.m4v$",
            "\\.mkv$",
            "\\.mng$",
            "\\.mov$",
            "\\.mp4$",
            "\\.mp2$",
            "\\.mpe$",
            "\\.mpeg$",
            "\\.mpg$",
            "\\.mpv$",
            "\\.mxf$",
            "\\.nsv$",
            "\\.ogv$",
            "\\.ogg$",
            "\\.qt$",
            "\\.rm$",
            "\\.rmvb$",
            "\\.roq$",
            "\\.svi$",
            "\\.vob$",
            "\\.webm$",
            "\\.wmv$",
            "\\.yuv$",
        };

        [JsonProperty("UnwantedFiles")]
        public string[] Unwantedfiles = new string[] { "\\.nfo$", "\\.txt$", "sample\\.\\w{2,4}$" };

        [JsonProperty("DeleteUnwantedFiles")]
        public bool Deleteunwantedfiles = false;

        [JsonProperty("DeleteDuplicates")]
        public bool Deleteduplicates = false;

        [JsonProperty("RenameMatchingAccompanyingFiles")]
        public bool Renamematchingaccompanyingfiles = true;

        [JsonProperty("TheTVDBApiKey")]
        public string ApiKey { get; internal set; } = null;

        [JsonProperty("EpisodeDateFormat")]
        public string Episodedateformat { get; internal set; } = "yyyy-MM-dd";

        [JsonProperty("SeriesDateFormat")]
        public string Seriesdateformat { get; internal set; } = "yyyy";

        [JsonProperty("InvalidCharReplacement")]
        public char Invalidcharreplacement { get; internal set; } = '_';

        [JsonProperty("MakeMissingPlaceholder")]
        public bool Makemissingplaceholder { get; set; } = false;

        [JsonProperty("LastRootPath")]
        public string Lastrootpath { get; internal set; } = null;

        [JsonProperty("RenameFormats")]
        public string[] Renameformats = new string[] { "%1 - S%3E%6 - %2", "%1 - Season %3\\%1 - S%3E%6 - %2" };

        [JsonProperty("ReplaceChars")]
        public Dictionary<string, string> Replacechars = new Dictionary<string, string>();

        #endregion

        public Configuration()
        {

        }

        /// <summary>
        /// Loads a configuration from file. If the file doesn't exist null is returned.
        /// </summary>
        /// <param name="configfile">The config file, in JSON format, to load</param>
        /// <returns>null if the file doesn't exist otherwise a loaded configuration.</returns>
        public static Configuration Load(string configfile)
        {
            if (File.Exists(configfile))
            {
                string text = File.ReadAllText(configfile);
                return JsonConvert.DeserializeObject<Configuration>(text);
            }
            return null;
        }
        
        /// <summary>
        /// Returns true if the specified file matches a RegEx pattern in <see cref="VideoFileFormats"/>.
        /// If the filename is null or empty then returns false.
        /// If the <see cref="VideoFileFormats"/> array is empty this function will always return true.
        /// </summary>
        /// <param name="filename">The filename to check</param>
        /// <returns>True if the filname has a valid extension or if <see cref="VideoFileFormats"/> is empty; otherwise false.</returns>
        public static bool IsValidVideo(string filename)
        {
            return IsValidExt(filename, VideoFileExtensions);
        }

        /// <summary>
        /// Returns true if the specified file matches a RegEx pattern in <see cref="UnwantedFiles"/>.
        /// If the filename is null or empty then returns false.
        /// If <see cref="UnwantedFiles"/> is empty this function will return false. 
        /// </summary>
        /// <param name="filename">The filename to check</param>
        /// <returns>True if the filname has a valid extension; otherwise false.</returns>
        public static bool IsUnwantedExtension(string filename)
        {
            if (UnwantedFiles == null || UnwantedFiles.Length == 0)
                return false;
            return IsValidExt(filename, UnwantedFiles);
        }

        /// <summary>
        /// Returns true if the specified file matches with a RegEx found in list.
        /// If the filename is null or empty then returns false.
        /// If the list is empty this function will always return true.
        /// </summary>
        /// <param name="filename">The filename to check.</param>
        /// <param name="list">List of RegEx patterns to check. </param>
        /// <returns>True if the filname matches a pattern in the list or if list is empty; otherwise false.</returns>
        internal static bool IsValidExt(string filename, string[] list)
        {
            if (filename == null || filename.Trim().Length == 0)
                return false;

            if (list == null || list.Length == 0)
                return true;

            foreach (string ext in list)
            {
                Regex regex = new Regex(ext, RegexOptions.IgnoreCase);
                if (regex.IsMatch(filename))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Saves the configuration to <see cref="SavePath"/>.
        /// Saves in JSON format.
        /// </summary>
        public void Save()
        {
            Save(SavePath);
        }

        /// <summary>
        /// Saves this configuation to the file given. Overwrites the file if it already exists.
        /// Saves in JSON format.
        /// </summary>
        /// <param name="filename">The file to save the config to.</param>
        public void Save(string filename)
        {
            string text = JsonConvert.SerializeObject(this);

            FileInfo fi = new FileInfo(filename);

            if (!fi.Directory.Exists)
                Directory.CreateDirectory(fi.Directory.FullName);

            File.WriteAllText(filename, text);
        }
    }
}
