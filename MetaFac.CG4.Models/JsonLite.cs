using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MetaFac.CG4.Models
{
    public enum JsonTokenKind
    {
        StartArray,
        EndArray,
        StartObject,
        EndObject,
        Colon,
        Comma,
        String,
        Number,
        True,
        False,
        Null
    }

    public readonly struct JsonToken
    {
        public static readonly JsonToken StartArray = new JsonToken(JsonTokenKind.StartArray);
        public static readonly JsonToken EndArray = new JsonToken(JsonTokenKind.EndArray);
        public static readonly JsonToken StartObject = new JsonToken(JsonTokenKind.StartObject);
        public static readonly JsonToken EndObject = new JsonToken(JsonTokenKind.EndObject);
        public static readonly JsonToken Colon = new JsonToken(JsonTokenKind.Colon);
        public static readonly JsonToken Comma = new JsonToken(JsonTokenKind.Comma);
        public static readonly JsonToken True = new JsonToken(JsonTokenKind.True);
        public static readonly JsonToken False = new JsonToken(JsonTokenKind.False);
        public static readonly JsonToken Null = new JsonToken(JsonTokenKind.Null);

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="kind">The token kind.</param>
        JsonToken(JsonTokenKind kind)
        {
            Text = string.Empty;
            Kind = kind;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="kind">The token kind.</param>
        /// <param name="text">The token text.</param>
        public JsonToken(JsonTokenKind kind, string text)
        {
            Text = text;
            Kind = kind;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="kind">The token kind.</param>
        /// <param name="ch">The character to create the token from.</param>
        public JsonToken(JsonTokenKind kind, char ch) : this()
        {
            Text = new string(ch, 1);
            Kind = kind;
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="other">Another object to compare to. </param>
        /// <returns>true if <paramref name="other"/> and this instance are the same type and represent the same value; otherwise, false. </returns>
        public bool Equals(JsonToken other)
        {
            return other.Kind == Kind && other.Text.Equals(Text);
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">Another object to compare to. </param>
        /// <returns>true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false. </returns>
        public override bool Equals(object? obj)
        {
            return obj is JsonToken other && Equals(other);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Kind, Text);
        }

        /// <summary>
        /// Returns a value indicating the equality of the two objects.
        /// </summary>
        /// <param name="left">The left hand side of the comparisson.</param>
        /// <param name="right">The right hand side of the comparisson.</param>
        /// <returns>true if the left and right side are equal, false if not.</returns>
        public static bool operator ==(JsonToken left, JsonToken right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Returns a value indicating the inequality of the two objects.
        /// </summary>
        /// <param name="left">The left hand side of the comparisson.</param>
        /// <param name="right">The right hand side of the comparisson.</param>
        /// <returns>false if the left and right side are equal, true if not.</returns>
        public static bool operator !=(JsonToken left, JsonToken right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Returns the string representation of the token.
        /// </summary>
        /// <returns>The string representation of the token.</returns>
        public override string ToString()
        {
            if (Kind == JsonTokenKind.String)
                return Text;
            else if (Kind == JsonTokenKind.Number)
                return Text;
            else return $"[{Kind}]";
        }

        /// <summary>
        /// Gets the token text.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Gets the token kind.
        /// </summary>
        public JsonTokenKind Kind { get; }
    }

    public readonly struct TextSpan : IEquatable<TextSpan>
    {
        public readonly string Source;
        public readonly int Offset;
        public readonly int Length;

        public TextSpan()
        {
            Source = string.Empty;
            Offset = 0;
            Length = 0;
        }

        public TextSpan(char ch)
        {
            Source = new string(ch, 1);
            Offset = 0;
            Length = 1;
        }

        public TextSpan(string source, int offset, int length)
        {
            if (offset < 0 || offset > source.Length) throw new ArgumentOutOfRangeException(nameof(offset), offset, null);
            if (length < 0 || length > (source.Length - offset)) throw new ArgumentOutOfRangeException(nameof(length), length, null);
            Source = source;
            Offset = offset;
            Length = length;
        }

        public ReadOnlyMemory<char> Memory => Source.AsMemory(Offset, Length);

        public bool Equals(TextSpan that) => that.Length != Length ? false : that.Memory.Span.SequenceEqual(Memory.Span);

        public override string ToString() => Source.Substring(Offset, Length);
    }

    public static class JsonLexer
    {
        private static int HexCharToInt(char ch)
        {
            if (ch <= 57 && ch >= 48)
            {
                return ch - 48;
            }

            if (ch <= 70 && ch >= 65)
            {
                return ch - 55;
            }

            if (ch <= 102 && ch >= 97)
            {
                return ch - 87;
            }

            throw new InvalidDataException($"Invalid hex character '{ch}'.");
        }

        private static int UnicodeToInt(ReadOnlySpan<char> unicode)
        {
            return
                HexCharToInt(unicode[0]) << 12 |
                HexCharToInt(unicode[1]) << 8 |
                HexCharToInt(unicode[2]) << 4 |
                HexCharToInt(unicode[3]);
        }
        private static int MatchString(ReadOnlyMemory<char> input, string match)
        {
            ReadOnlySpan<char> inputSpan = input.Span;
            ReadOnlySpan<char> matchSpan = match.AsSpan();
            int pos = 0;
            while (pos < matchSpan.Length)
            {
                char matchCh = matchSpan[pos];
                char inputCh = inputSpan[pos];
                if (inputCh != matchCh)
                    throw new InvalidDataException($"Expected character '{matchCh}', but found character '{inputCh}'.");
                pos++;
            }
            return pos;
        }

        private static int ParseNumber(ReadOnlyMemory<char> input, out string output)
        {
            ReadOnlySpan<char> inputSpan = input.Span;

            var text = new StringBuilder();

            int consumed = 0;
            bool seenFirst = false;
            bool seenDecimal = false;
            bool seenExponent = false;
            while (consumed < inputSpan.Length)
            {
                char ch = inputSpan[consumed];
                switch (ch)
                {
                    case '-':
                    case '+':
                        if (seenFirst) throw new InvalidDataException($"Invalid character '{ch}'.");
                        consumed += 1;
                        seenFirst = true;
                        text.Append(ch);
                        break;

                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        consumed += 1;
                        seenFirst = true;
                        text.Append(ch);
                        break;

                    case 'e':
                    case 'E':
                        if (seenExponent) throw new InvalidDataException($"Invalid character '{ch}'.");
                        consumed += 1;
                        seenExponent = true;
                        seenFirst = false;
                        seenDecimal = true;
                        text.Append(ch);
                        break;

                    case '.':
                        if (seenDecimal) throw new InvalidDataException($"Invalid character '{ch}'.");
                        consumed += 1;
                        seenDecimal = true;
                        text.Append(ch);
                        break;

                    default:
                        // terminated
                        output = text.ToString();
                        return consumed;
                }
            }

            output = text.ToString();
            return consumed;
        }

        private static int ParseString(ReadOnlyMemory<char> input, out string output)
        {
            ReadOnlySpan<char> inputSpan = input.Span;

            var text = new StringBuilder();

            int consumed = 0;

            char ch = inputSpan[consumed];
            if (ch != '"') throw new InvalidDataException($"Invalid character '{ch}'.");
            consumed += 1;
            text.Append('"');

            while (consumed < inputSpan.Length)
            {
                ch = inputSpan[consumed];
                switch (ch)
                {
                    case '\\':
                        consumed += 1;
                        ch = inputSpan[consumed];
                        switch (ch)
                        {
                            case '"':
                                consumed += 1;
                                text.Append('"');
                                break;

                            case '\\':
                                consumed += 1;
                                text.Append('\\');
                                break;

                            case '/':
                                consumed += 1;
                                text.Append('/');
                                break;

                            case 'b':
                                consumed += 1;
                                text.Append('\b');
                                break;

                            case 'f':
                                consumed += 1;
                                text.Append('\f');
                                break;

                            case 'n':
                                consumed += 1;
                                text.Append('\n');
                                break;

                            case 'r':
                                consumed += 1;
                                text.Append('\r');
                                break;

                            case 't':
                                consumed += 1;
                                text.Append('\t');
                                break;

                            case 'u':
                                consumed += 1;
                                Span<char> unicode = stackalloc char[4];
                                for (var i = 0; i < 4; i++)
                                {
                                    ch = inputSpan[consumed];
                                    consumed += 1;

                                    unicode[i] = ch;
                                }
                                text.Append((char)UnicodeToInt(unicode));
                                break;

                            default:
                                throw new InvalidDataException($"Invalid escape character '{ch}'.");
                        }
                        break;

                    case '"':
                        consumed += 1;
                        text.Append('"');
                        output = text.ToString();
                        return consumed;

                    default:
                        consumed += 1;
                        text.Append(ch);
                        break;
                }
            }

            throw new InvalidDataException("String not terminated.");
        }

        public static IEnumerable<JsonToken> GetTokens(ReadOnlyMemory<char> input)
        {
            int pos = 0;
            while (pos < input.Length)
            {
                char ch = input.Span[pos];
                switch (ch)
                {
                    case '{':
                        pos += 1;
                        yield return JsonToken.StartObject;
                        break;
                    case '}':
                        pos += 1;
                        yield return JsonToken.EndObject;
                        break;
                    case '[':
                        pos += 1;
                        yield return JsonToken.StartArray;
                        break;
                    case ']':
                        pos += 1;
                        yield return JsonToken.EndArray;
                        break;
                    case ':':
                        pos += 1;
                        yield return JsonToken.Colon;
                        break;
                    case ',':
                        pos += 1;
                        yield return JsonToken.Comma;
                        break;
                    case 'f':
                        pos += MatchString(input.Slice(pos), "false");
                        yield return JsonToken.False;
                        break;
                    case 't':
                        pos += MatchString(input.Slice(pos), "true");
                        yield return JsonToken.True;
                        break;
                    case 'n':
                        pos += MatchString(input.Slice(pos), "null");
                        yield return JsonToken.Null;
                        break;
                    case '"':
                        pos += ParseString(input.Slice(pos), out var strValue);
                        yield return new JsonToken(JsonTokenKind.String, strValue);
                        break;
                    case '-':
                    case '+':
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        pos += ParseNumber(input.Slice(pos), out var numValue);
                        yield return new JsonToken(JsonTokenKind.Number, numValue);
                        break;
                    default:
                        if (!Char.IsWhiteSpace(ch))
                            throw new InvalidDataException($"Invalid character '{ch}'.");
                        pos += 1;
                        break;
                }
            }
        }
    }
}
