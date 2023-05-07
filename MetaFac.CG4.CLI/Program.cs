using MetaFac.Platform;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Threading.Tasks;

namespace MetaFac.CG4.CLI
{
    static class Program
    {
        //private static ILogger ConfigureLogger()
        //{
        //    using ILoggerFactory loggerFactory =
        //                LoggerFactory.Create(builder =>
        //                    builder.AddSimpleConsole(options =>
        //                    {
        //                        options.IncludeScopes = false;
        //                        options.SingleLine = true;
        //                        options.TimestampFormat = "hh:mm:ss ";
        //                        options.ColorBehavior = LoggerColorBehavior.Enabled;
        //                    }));

        //    return loggerFactory.CreateLogger("MFCG4");
        //}

        public static async Task Main(string[] args)
        {
            //var logger = ConfigureLogger();
            var clock = new TimeOfDayClock();
            var commands = new Commands(clock);
            int result = await commands.Run(args);
            Environment.ExitCode = result;
        }
    }
}