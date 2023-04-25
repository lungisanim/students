using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace University
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

    public static class EntityFrameworkConfigExtensions
    {
        public static IHostBuilder UseEntityFrameworkConfig(this IHostBuilder hostBuilder)
        {
            return hostBuilder.ConfigureServices((context, services) =>
            {
                var connectionString = context.Configuration.GetConnectionString("UniversityConnection");
                services.AddDbContext<StudentContext>(options =>
                    options.UseSqlServer(connectionString));
            });
        }
    }
}
