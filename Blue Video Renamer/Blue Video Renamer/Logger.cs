using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue_Video_Renamer
{
    public class Logger
    {
        public static Logger instance;
        public static Logger Instance
        {
            get
            {
                if (instance == null)
                    instance = new Logger(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + Path.DirectorySeparatorChar + "FromThe.Blue" + Path.DirectorySeparatorChar + "Video Renamer" + Path.DirectorySeparatorChar + "Video File Renamer Log.txt");
                return instance;
            }
            set
            {
                instance = value;
            }
        }

        public List<string> Log;
        public string LogFile;

        public Logger(string logfile)
        {
            Log = new List<string>();
            LogFile = logfile;


            if (File.Exists(logfile)){
                FileInfo fi = new FileInfo(logfile);

                
                for (int i = 25; i > 1; i--)
                {
                    string oldFile = Path.GetFileNameWithoutExtension(fi.Name) + "(" + i.ToString("00") + ")" + fi.Extension;
                    string oldFileMove = Path.GetFileNameWithoutExtension(fi.Name) + "(" + (i-1).ToString("00") + ")" + fi.Extension;

                    if (File.Exists(fi.Directory.FullName + Path.DirectorySeparatorChar + oldFile))
                        File.Delete(fi.Directory.FullName + Path.DirectorySeparatorChar + oldFile);

                    if (File.Exists(fi.Directory.FullName + Path.DirectorySeparatorChar + oldFileMove))
                        File.Move(fi.Directory.FullName + Path.DirectorySeparatorChar + oldFileMove, fi.Directory.FullName + Path.DirectorySeparatorChar + oldFile);
                }

                File.Move(logfile, fi.Directory.FullName + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(fi.Name) + "(01)" + fi.Extension);
            }
        }

        public void WriteLog(string message)
        {
            message = DateTime.Now + "\t" + message;
            Log.Add(message);

            //Only keep 100 lines local. If you want to see more goto the damn file! >.<
            if (Log.Count > 100)
                Log.RemoveAt(0);

            FileInfo fi = new FileInfo(LogFile);

            if (!fi.Directory.Exists)
                Directory.CreateDirectory(fi.Directory.FullName);

            try
            {
            System.IO.File.AppendAllText(LogFile, "\n" + message);
            }
            catch (Exception e) {
                Log.Add("Failed to write last message to log!" + e.Message);
            }
        }
    }
}
