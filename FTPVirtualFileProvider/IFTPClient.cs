using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.FileProviders;

namespace FTPVirtualFileProvider
{
    public interface IFtpClient
    {
        public IDirectoryContents GetDirectoryContents(string dirPath);
        public IEnumerable<IFileInfo> GetFiles(string dirPath);
        public IFileInfo GetFile(string filePath);
        public Stream GetStream(IFileInfo fileInfo);
        public bool Exist(IFileInfo fileInfo);
    }
}
