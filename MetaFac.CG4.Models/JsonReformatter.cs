using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;

namespace MetaFac.CG4.Models
{
    public readonly struct JsonReformatterOptions
    {
        public readonly bool IsAssigned = false;
        public readonly char? IndentChar = null;
        public readonly int? IndentSize = null;
        public readonly bool? UseUnixEOL = null;

        public static JsonReformatterOptions Default = new JsonReformatterOptions();

        private JsonReformatterOptions(int? indentSize, char? indentChar, bool? useUnixEOL)
        {
            IsAssigned = true;
            IndentSize = indentSize;
            IndentChar = indentChar;
            UseUnixEOL = useUnixEOL;
        }
        public JsonReformatterOptions WithIndentSize(int? indentSize = null)
        {
            if (indentSize is not null && (indentSize < 0 || indentSize > 8))
                throw new ArgumentOutOfRangeException(nameof(indentSize), indentSize, null);
            return new JsonReformatterOptions(indentSize, IndentChar, UseUnixEOL);
        }
        public JsonReformatterOptions WithIndentChar(char? indentChar = null)
        {
            if (indentChar is not null && indentChar != ' ' && IndentChar != '\t')
                throw new ArgumentOutOfRangeException(nameof(indentChar), indentChar, null);
            return new JsonReformatterOptions(IndentSize, indentChar, UseUnixEOL);
        }
        public JsonReformatterOptions WithEOL(bool? useUnixEOL)
        {
            return new JsonReformatterOptions(IndentSize, IndentChar, useUnixEOL);
        }
    }

    public static class JsonReformatter
    {
        private enum ParseState
        {
            InPrefix,
            InContent,
            SeenEOL,
        }
        private static void DequeueAll(Queue<char> queue, StringBuilder output)
        {
            while (queue.Count > 0)
            {
                char ch = queue.Dequeue();
                output.Append(ch);
            }
        }
        private static void EmitPrefixChars(JsonReformatterOptions options, Queue<char> prefixChars, StringBuilder output)
        {
            // todo need structure depth to do this properly
            DequeueAll(prefixChars, output);
        }
        private static void EmitEOLChars(JsonReformatterOptions options, Queue<char> eolChars, StringBuilder output)
        {
            if (options.UseUnixEOL is null)
            {
                DequeueAll(eolChars, output);
            }
            else
            {
                eolChars.Clear();
                if (!(bool)options.UseUnixEOL)
                {
                    output.Append('\r');
                }
                output.Append('\n');
            }
        }

        public static string ReformatJson(this string input, JsonReformatterOptions options = default)
        {
            var output = new StringBuilder();
            var prefixChars = new Queue<char>();
            var eolChars = new Queue<char>();
            ParseState state = ParseState.InPrefix;
            foreach (char ch in input)
            {
                switch (state)
                {
                    case ParseState.InPrefix:
                        switch (ch)
                        {
                            case ' ':
                            case '\t':
                                prefixChars.Enqueue(ch);
                                break;
                            // old
                            case '\r':
                            case '\n':
                                EmitPrefixChars(options, prefixChars, output);
                                eolChars.Enqueue(ch);
                                state = ParseState.SeenEOL;
                                break;
                            default:
                                EmitPrefixChars(options, prefixChars, output);
                                output.Append(ch);
                                state = ParseState.InContent;
                                break;
                        }
                        break;
                    case ParseState.InContent:
                        switch (ch)
                        {
                            case '\r':
                            case '\n':
                                eolChars.Enqueue(ch);
                                state = ParseState.SeenEOL;
                                break;
                            default:
                                output.Append(ch);
                                break;
                        }
                        break;
                    case ParseState.SeenEOL:
                        switch (ch)
                        {
                            case '\r':
                            case '\n':
                                eolChars.Enqueue(ch);
                                break;
                            default:
                                EmitEOLChars(options, eolChars, output);
                                output.Append(ch);
                                state = ParseState.InPrefix;
                                break;
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(state), state, null);
                }
            }
            return output.ToString();
        }
    }
}
