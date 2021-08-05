using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Core;
using TransformSsbBlobToSQL.Data;
namespace TransformSsbBlobToSQL
{
    public class Program
    {
        public static void Main(string[] args)
        {
        #if DEBUG
            Debugger.Launch();
#endif
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Warning()
                .WriteTo.Console()
                .CreateLogger();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            
            return new HostBuilder()
                .ConfigureAppConfiguration(config =>
                {
                    config.AddCommandLine(args);
                })
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureServices(s =>
                {
                    s.AddSingleton<ILogger>(Log.Logger);
                    s.AddDbContext<SsbContext>(options =>
                    {
                        options.UseSqlite("FileName=sqlitedb");
                    });
                });
        }
    }
}