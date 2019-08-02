using System;
using System.Linq;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Selstam.VoC.Commands;
using Selstam.VoC.Services.VoC.Interfaces;
using Selstam.VoC.Services.VoCApiClient;

namespace Selstam.VoC
{
    using Selstam.VoC.Services.VoC;

    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();

            ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();

            var app = new CommandLineApplication<VolvoOnCallService>
            {
                UsePagerForHelpText = false,
                FullName = "voc"
            };

            app.Conventions
                .UseDefaultConventions()
                .UseConstructorInjection(serviceProvider);

            app.OnValidationError(r =>
            {
                app.ShowHelp(usePager: false);
            });

            app.Execute(args);
#if DEBUG
            Console.ReadLine();
#endif
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IVoCApiClientService, VoCApiClientService>();
            services.AddTransient<IVoCService, VoCService>();

            services.AddLogging(c => c.AddConsole(options => options.IncludeScopes = true ))
                    .Configure<LoggerFilterOptions>(o => o.MinLevel = LogLevel.Debug);
        }
    }
}
