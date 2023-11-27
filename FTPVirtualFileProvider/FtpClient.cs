using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentFTP;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;

namespace FTPVirtualFileProvider
{
    public class FtpClient : IFtpClient
    {
        private readonly FluentFTP.FtpClient _ftpClient;
        public FtpClient(FtpConfig ftpConfig)
        {
            _ftpClient = new FluentFTP.FtpClient(ftpConfig.Host,ftpConfig.UserName,ftpConfig.Password,ftpConfig.Port);
            _ftpClient.AutoConnect();

        }
        public IDirectoryContents GetDirectoryContents(string dirPath)
        {
            //var fileItem = _ftpClient.GetObjectInfo(string.IsNullOrEmpty(dirPath) ? "/" : dirPath);
            return new FTPDirectoryContents(dirPath, this);
        }

        public IEnumerable<IFileInfo> GetFiles(string dirPath)
        {
            var fileItems = _ftpClient.GetListing(dirPath);
            var list = fileItems.Select(ToFileInfo);
            return list;
        }

        public IFileInfo GetFile(string filePath)
        {
            var fileItem = _ftpClient.GetObjectInfo(filePath);
            return ToFileInfo(fileItem);
        }

        public Stream GetStream(IFileInfo fileInfo)
        {
            return _ftpClient.OpenRead(fileInfo.PhysicalPath);
        }

        public bool Exist(IFileInfo fileInfo)
        {
            return fileInfo.IsDirectory
                ? _ftpClient.DirectoryExists(fileInfo.PhysicalPath)
                : _ftpClient.FileExists(fileInfo.PhysicalPath);
        }

        private FTPFileInfo ToFileInfo(FtpListItem item)
        {
            return new FTPFileInfo(this)
            {
                PhysicalPath = item.FullName,
                Name = Path.GetFileName(item.FullName),
                IsDirectory = item.Type == FtpObjectType.Directory,
                LastModified = item.Modified,
                Length = item.Size
            };
        }

    }
}
