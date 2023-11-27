using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;

namespace FTPVirtualFileProvider
{
    public class FTPFileProvider : IFileProvider
    {
        private readonly IFtpClient _ftpClient;

        public FTPFileProvider(IFtpClient ftpClient)
        {
            _ftpClient = ftpClient;
        }
        public IFileInfo GetFileInfo(string subpath)
        {
            return _ftpClient.GetFile(subpath);
        }

        public IDirectoryContents GetDirectoryContents(string subpath)
        {
            return _ftpClient.GetDirectoryContents(subpath);
        }

        public IChangeToken Watch(string filter)
        {
            return NullChangeToken.Singleton;
        }
    }
}
