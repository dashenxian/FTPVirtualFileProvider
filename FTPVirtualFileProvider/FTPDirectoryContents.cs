using System;
using System.Collections;
using Microsoft.Extensions.FileProviders;

namespace FTPVirtualFileProvider
{
    public class FTPDirectoryContents : IDirectoryContents
    {
        private readonly string _directory;
        private readonly IFtpClient _ftpClient;
        public FTPDirectoryContents(string directory, IFtpClient ftpClient)
        {
            _directory = directory;
            _ftpClient = ftpClient;
        }
        public IEnumerator<IFileInfo> GetEnumerator()
        {
            return _ftpClient.GetFiles(_directory).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Exists =>_ftpClient.Exist(_ftpClient.GetFile(_directory));
    }
}
