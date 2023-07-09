using System;
using System.Threading.Tasks;

namespace MetaFac.CG4.CLI
{
    static class Program
    {
        public static async Task Main(string[] args)
        {
            var commands = new Commands();
            int result = await commands.Run(args);
            Environment.ExitCode = result;
        }
    }
}