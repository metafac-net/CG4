using System.IO;
using System.Text;

namespace MetaFac.CG4.ModelReader.Tests
{
    public static class JsonReformatterOld
    {
        /// <summary>
        /// Shrinks JSON text slightly by:
        /// 1. Lonely "{" chars are moved to the end of the previous line;
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Reformat(string input)
        {
            // todo convert this to spans
            StringBuilder output = new StringBuilder();
            using var reader = new StringReader(input);
            string? lastLine = null;
            string? thisLine;
            while ((thisLine = reader.ReadLine()) is not null)
            {
                if (lastLine is null)
                {
                    lastLine = thisLine;
                }
                else if (thisLine.Trim() == "{")
                {
                    // lonely "{" found
                    lastLine += " {";
                }
                else
                {
                    output.AppendLine(lastLine);
                    lastLine = thisLine;
                }
            }
            if (lastLine is not null)
            {
                output.AppendLine(lastLine);
            }
            return output.ToString();
        }
    }
}
