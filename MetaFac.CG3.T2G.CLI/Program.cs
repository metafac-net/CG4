using MetaFac.CG3.TextProcessing;
using MetaFac.Platform;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using MiniCLI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MetaFac.CG3.CLI
{
    static class Program
    {
        private static IEnumerable<string> ReadLines(string filename)
        {
            using var sr = new StreamReader(filename);
            string? line;
            while ((line = sr.ReadLine()) != null)
            {
                yield return line;
            }
        }

        private static void WriteLinesToFile(IEnumerable<string?>? content, string filename)
        {
            if (content is null) return;
            using var sw = new StreamWriter(filename);
            foreach (var line in content)
            {
                sw.WriteLine(line);
            }
        }

        private static async ValueTask<int> ConvertTemplateToGenerator(
            string templateFilename,
            string generatorFilename,
            string generatorNamespace,
            string generatorShortname)
        {
            if (logger is null) throw new ArgumentNullException(nameof(logger));

            // get relative paths
            string currentPath = Directory.GetCurrentDirectory();
            string templateRelPath = Path.GetRelativePath(currentPath, templateFilename);
            string generatorRelPath = Path.GetRelativePath(currentPath, generatorFilename);

            logger.LogInformation("  Current path: {value}", currentPath);
            logger.LogInformation(" Template file: {value}", templateRelPath);
            logger.LogInformation("Generator file: {value}", generatorRelPath);

            var sourceLines = ReadLines(templateRelPath);
            var outputLines = TextProcessor.ConvertTemplateToGenerator(
                sourceLines, generatorNamespace, generatorShortname, new NotEncryptedTextCache());
            WriteLinesToFile(outputLines, generatorRelPath);
            await Task.Delay(0);
            return 0;
        }

        private static readonly ILogger logger = ConfigureLogger();
        private static readonly ITimeOfDayClock clock = new TimeOfDayClock();

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

            return loggerFactory.CreateLogger("MetaCode");
        }

        public static void Main(string[] args)
        {

            var cmd = new Cmd<string, string, string, string, int>(
                "MetaCode", "Converts a template to a code generator",
                new Arg<string>("tf", "template", "The template file to process", s => s),
                new Arg<string>("gf", "output", "The name of the generated file", s => s),
                new Arg<string>("gn", "namespace", "The namespace for the generated code", s => s),
                new Arg<string>("gs", "shortname", "The short name (or id) of the generator", s => s),
                //new Arg<string>("ef", "encrypt", "Encrypt the template source code to this file", s => s, ""),
                //new Arg<string>("xp", "secrets-path","The location where the secrets are stored", s => s, "."),
                //new Arg<string>("s", "server", "The address (URL) of the metacode server", s => s, Constants.ServerUrl.MetaCodeWebApiV1),
                //new Arg<string>("t", "token", "The MetaCode administrator token for the account", s => s, ""),
                ConvertTemplateToGenerator);

            int result = cmd.Run(args).ConfigureAwait(false).GetAwaiter().GetResult();

            Environment.ExitCode = result;

        }
    }
}