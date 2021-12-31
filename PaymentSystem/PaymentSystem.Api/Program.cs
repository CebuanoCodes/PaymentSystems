using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using PaymentSystem.Api;

namespace PaymentSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateWebHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseDefaultServiceProvider(options =>
            options.ValidateScopes = false);
                });
    }
}
