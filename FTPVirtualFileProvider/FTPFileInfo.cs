using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.FileProviders;

namespace FTPVirtualFileProvider
{
    public class FTPFileInfo : IFileInfo
    {
        private readonly IFtpClient _ftpClient;

        public FTPFileInfo(IFtpClient ftpClient)
        {
            _ftpClient = ftpClient;
        }
        public Stream CreateReadStream()
        {
            if (!Exists)
            {
                throw new FileNotFoundException();
            }
            return _ftpClient.GetStream(this);
        }

        public bool Exists => PhysicalPath != null && _ftpClient.Exist(this);
        public long Length { get; init; }
        public string? PhysicalPath { get; init; }
        public string Name { get; init; }
        public DateTimeOffset LastModified { get; init; }
        public bool IsDirectory { get; init; }
    }
}
