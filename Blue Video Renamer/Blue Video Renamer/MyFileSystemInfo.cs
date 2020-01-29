using System;
using System.Collections;
using System.IO;
using System.Linq;

namespace Blue_Video_Renamer
{
    /// <summary>
    /// https://github.com/tschuler/StatureTool/blob/master/ObjectListViewFull-2.9.1/ObjectListViewDemo/Demo/Models/MyFileSystemInfo.cs
    /// 
    /// Standard .NET FileSystemInfos are always not equal to each other.
    /// When we try to refresh a directory, our controls can't match up new
    /// files with existing files. They are also sealed so we can't just subclass them.
    /// This class is a wrapper around a FileSystemInfo that simply provides
    /// equality.
    /// </summary>
    public class MyFileSystemInfo : IEquatable<MyFileSystemInfo>
    {
        public const FileAttributes allAttributes = FileAttributes.Archive | FileAttributes.Compressed | FileAttributes.Device |
            FileAttributes.Directory | FileAttributes.Encrypted | FileAttributes.Hidden | FileAttributes.IntegrityStream |
            FileAttributes.Normal | FileAttributes.NoScrubData | FileAttributes.NotContentIndexed | FileAttributes.Offline | 
            FileAttributes.ReadOnly | FileAttributes.ReparsePoint | FileAttributes.SparseFile | FileAttributes.System | 
            FileAttributes.Temporary;


        public MyFileSystemInfo(FileSystemInfo fileSystemInfo)
        {
            if (fileSystemInfo == null) throw new ArgumentNullException("fileSystemInfo");
            this.info = fileSystemInfo;
        }

        public bool IsDirectory { get { return this.AsDirectory != null; } }

        public DirectoryInfo AsDirectory { get { return this.info as DirectoryInfo; } }
        public FileInfo AsFile { get { return this.info as FileInfo; } }

        public FileSystemInfo Info
        {
            get { return this.info; }
        }
        private readonly FileSystemInfo info;

        public string Name
        {
            get { return this.info.Name; }
        }

        public string Extension
        {
            get { return this.info.Extension; }
        }

        public DateTime CreationTime
        {
            get { return this.info.CreationTime; }
        }

        public DateTime LastWriteTime
        {
            get { return this.info.LastWriteTime; }
        }

        public string FullName
        {
            get { return this.info.FullName; }
        }

        public FileAttributes Attributes
        {
            get { return this.info.Attributes; }
        }

        public long Length
        {
            get { return this.AsFile.Length; }
        }

        public IEnumerable GetFileSystemInfos(FileAttributes attributes = allAttributes)
        {
            ArrayList children = new ArrayList();
            if (this.IsDirectory)
            {
                try { 
                IEnumerable files = this.AsDirectory.GetFileSystemInfos().OrderBy(f => f.FullName);
                foreach (FileSystemInfo x in files)
                {
                    if ((x.Attributes & attributes) != 0)
                        children.Add(new MyFileSystemInfo(x));
                }
                } catch (Exception) {
                    
                }
            }
            return children;
        }

        // Two file system objects are equal if they point to the same file system path

        public bool Equals(MyFileSystemInfo other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.info.FullName, this.info.FullName);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(MyFileSystemInfo)) return false;
            return Equals((MyFileSystemInfo)obj);
        }
        public override int GetHashCode()
        {
            return (this.info != null ? this.info.FullName.GetHashCode() : 0);
        }
        public static bool operator ==(MyFileSystemInfo left, MyFileSystemInfo right)
        {
            return Equals(left, right);
        }
        public static bool operator !=(MyFileSystemInfo left, MyFileSystemInfo right)
        {
            return !Equals(left, right);
        }
    }

}
