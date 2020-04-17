using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace INDOPRIDE
{
    [DataContract]
    class ServerResponse
    {
        [DataMember]
        public File[] files { get; set; }
        [DataMember]
        public long total_bytes { get; set; }
        [DataMember]
        public int total_files { get; set; }
        [DataMember]
        public IgnoreObject ignore { get; set; }
        [DataMember]
        public string version { get; set; }

    }

    [DataContract]
    class File
    {
        [DataMember]
        public string filename { get; set; }
        [DataMember]
        public string md5 { get; set; }
        [DataMember]
        public long filesize { get; set; }

    }

    [DataContract]
    class IgnoreObject
    {
        [DataMember]
        public IgnoreFolderConfig[] folders { get; set; }
        [DataMember]
        public string[] files { get; set; }
    }

    [DataContract]
    class IgnoreFolderConfig
    {
        [DataMember]
        public string folder_path { get; set; }
        [DataMember]
        public bool all_subfolders { get; set; }
    }

}
