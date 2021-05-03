using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(SicWEB.Areas.Identity.IdentityHostingStartup))]
namespace SicWEB.Areas.Identity
{
  public class IdentityHostingStartup : IHostingStartup
  {
    public void Configure(IWebHostBuilder builder)
    {
      builder.ConfigureServices((context, services) =>
      {
      });
    }
  }
}