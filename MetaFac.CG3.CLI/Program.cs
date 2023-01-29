using MetaFac.CG3.Generators;
using MetaFac.CG3.ModelReader;
using MetaFac.CG3.TextProcessing;
using MetaFac.Platform;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using MiniCLI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MetaFac.CG3.CLI
{
    static class Program
    {
        private static ILogger ConfigureLogger()
        {
            using ILoggerFactory loggerFactory =
                        LoggerFactory.Create(builder =>
                            builder.AddSimpleConsole(options =>
                            {
                                options.IncludeScopes = false;
                                options.SingleLine = true;
                                options.TimestampFormat = "hh:mm:ss ";
                                options.ColorBehavior = LoggerColorBehavior.Enabled;
                            }));

            return loggerFactory.CreateLogger("MFCG3");
        }

        public static async Task Main(string[] args)
        {
            var logger = ConfigureLogger();
            var clock = new TimeOfDayClock();
            var commands = new Commands(logger, clock);
            int result = await commands.Run(args);
            Environment.ExitCode = result;
        }
    }
}