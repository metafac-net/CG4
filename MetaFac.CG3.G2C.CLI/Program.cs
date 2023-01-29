using MetaFac.Platform;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Threading.Tasks;
using MetaFac.CG3.Generators;

namespace MetaCode.TS3.CLI
{
    public static class Program
    {
        public static async Task Main(string[] args)
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

            ILogger logger = loggerFactory.CreateLogger("MCTS3");
            ITimeOfDayClock clock = new TimeOfDayClock();

            var commands = new Commands(logger, clock);

            int result = await commands.Run(args);

            Environment.ExitCode = result;
        }

        private static ProxyDef ParseProxyDef(string value)
        {
            string[] kvp = value.Split('=');
            if (kvp.Length != 2) throw new ArgumentException("incorrect format for proxy definition", value);
            string proxyTypeName = kvp[0].Trim();
            if (string.IsNullOrEmpty(proxyTypeName)) throw new ArgumentException("incorrect format for proxy definition", value);
            string[] vp = kvp[1].Split(',');
            if (vp.Length < 1 || vp.Length > 2) throw new ArgumentException("incorrect format for proxy definition", value);
            string externalTypeName = vp[0].Trim();
            if (string.IsNullOrEmpty(externalTypeName)) throw new ArgumentException("incorrect format for proxy definition", value);
            string concreteTypeName = externalTypeName;
            if (vp.Length > 1)
                concreteTypeName = vp[1].Trim();
            if (string.IsNullOrEmpty(concreteTypeName)) throw new ArgumentException("incorrect format for proxy definition", value);
            var proxyDef = new ProxyDef(proxyTypeName, externalTypeName, concreteTypeName);
            return proxyDef;
        }
    }
}