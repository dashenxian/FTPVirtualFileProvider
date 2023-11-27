using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPVirtualFileProvider
{
    public class FtpConfig
    {
        public FtpType FtpType { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public enum FtpType
    {
        Ftp,
        Sftp,
    }
}
