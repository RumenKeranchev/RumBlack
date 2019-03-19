using Microsoft.AspNetCore.Hosting;
using RB.WebApp.Areas.Identity;

[assembly: HostingStartup(typeof(IdentityHostingStartup))]
namespace RB.WebApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}