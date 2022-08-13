using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryConsoleApp.Models
{
    public class Recipient
    {
        public string MemberNo { get; set; }
        public Data Data { get; set; }
    }

    public class Data
    {
        public string ShortName { get; set; }
        public string StoredProc { get; set; }
        public string FileName { get; set; }
        public string Deliminator { get; set; }
        public int EmailFile { get; set; }
        public string EmailAddress { get; set; }
        public int FTPFile { get; set; }
        public Ftpinfo FTPInfo { get; set; }
        public int FileDrop { get; set; }
        public string FileDropLocation { get; set; }
        public string FileOrder { get; set; }
        public Unit[] Units { get; set; }
    }

    public class Ftpinfo
    {
        public string FTPName { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }

    public class Unit
    {
        public string UnitName { get; set; }
        public string[] Details { get; set; }
    }
}
