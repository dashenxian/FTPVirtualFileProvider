using FTPVirtualFileProvider;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace FTPVirtualFileProviderTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var services = new ServiceCollection()
                .AddScoped<IFileProvider, FTPFileProvider>()
                .AddScoped<IFtpClient, FtpClient>()
                ;

            var serviceProvider = services.BuildServiceProvider();
            var ftpFileProvider = serviceProvider.GetService<IFileProvider>();

            var directory = ftpFileProvider.GetDirectoryContents("/");

        }
    }
}