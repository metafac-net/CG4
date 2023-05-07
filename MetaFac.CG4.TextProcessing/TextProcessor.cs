using System;
using System.Collections.Generic;
using System.Text;

namespace MetaFac.CG4.TextProcessing
{

    public class TextProcessor
    {
        private const string PrefixCsharpComment = "//";
        private const string PrefixMetaCode = ">>";
        private const string EmitCodePrefix = "Emit(\"";
        private const string EmitCodeSuffix = "\");";
        private const string DirectiveTemplateBegin = "template_begin";
        private const string DirectiveTemplateEnd = "template_end";
        private const string DirectiveGeneratorHeader = "generator_header";
        private const string DirectiveGeneratorBody = "generator_body";
        private const string DirectiveGeneratorFooter = "generator_footer";
        private const string DirectiveGeneratorEnd = "generator_end";

        private static (string indent, string remainder) StripLeadingWhitespace(string input)
        {
            StringBuilder indent = new StringBuilder();
            for (int pos = 0; pos < input.Length; pos++)
            {
                char ch = input[pos];
                if (char.IsWhiteSpace(ch))
                {
                    // nothing
                    indent.Append(ch);
                }
                else
                {
                    return (indent.ToString(), input.Substring(pos));
                }
            }
            return (input, "");
        }

        private enum TextState
        {
            Init,
            Header,
            Body,
            Footer,
            End,
        }

        private static string? GetMetaCodeDirective(string comment)
        {
            if (string.IsNullOrWhiteSpace(comment)) return null;
            int firstBar = comment.IndexOf('|');
            int lastBar = comment.LastIndexOf('|');
            if (firstBar >= 0 && lastBar >= 0 && lastBar > firstBar)
            {
                string[] parts = comment.Substring(firstBar + 1, lastBar - firstBar - 1).Trim().Split(':');
                if (parts[0].Equals("metacode", StringComparison.OrdinalIgnoreCase))
                {
                    string? directive = parts.Length >= 2 ? parts[1].Trim().ToLower() : null;
                    switch (directive)
                    {
                        case DirectiveTemplateBegin: return DirectiveTemplateBegin;
                        case DirectiveTemplateEnd: return DirectiveTemplateEnd;
                        case DirectiveGeneratorHeader: return DirectiveGeneratorHeader;
                        case DirectiveGeneratorBody: return DirectiveGeneratorBody;
                        case DirectiveGeneratorFooter: return DirectiveGeneratorFooter;
                        case DirectiveGeneratorEnd: return DirectiveGeneratorEnd;
                    }
                }
            }
            return null;
        }

        private static string FormatDirective(string directive)
        {
            return $"|metacode:{directive}|";
        }

        private static string[] generator_header = new string[]
        {
            "using System;",
            "using System.Linq;",
            "using MetaFac.CG4.Generators;",
            "namespace T_GeneratorNamespace_",
            "{",
            "    public partial class Generator : GeneratorBase",
            "    {",
            "        public Generator() : base(\"T_GeneratorShortName_\") { }",
            "        protected override void OnGenerate(TemplateScope outerScope)",
            "        {",
        };

        private static string[] generator_footer = new string[]
        {
            "        }",
            "    }",
            "}",
        };

        public static IEnumerable<string?> ConvertTemplateToGenerator(
            IEnumerable<string> sourceLines,
            string generatorNamespace,
            string generatorShortname,
            IEncryptedTextCache etc)
        {
            TextState state = default;
            int lineNumber = 0;
            foreach (string input in sourceLines)
            {
                lineNumber++;
                (string outerIndent, string sourceCode) = StripLeadingWhitespace(input);
                switch (state)
                {
                    case TextState.Init:
                        // scan for TemplateBegin directive
                        if (sourceCode.StartsWith(PrefixCsharpComment))
                        {
                            string comment = sourceCode.Substring(PrefixCsharpComment.Length);
                            var directive = GetMetaCodeDirective(comment);
                            if (directive is null)
                            {
                                yield return input;
                            }
                            else if (directive == DirectiveTemplateBegin)
                            {
                                yield return $"{outerIndent}{PrefixCsharpComment} {FormatDirective(DirectiveGeneratorHeader)}";
                                var outerTokens = new Dictionary<string, string>()
                                {
                                    ["GeneratorNamespace"] = generatorNamespace,
                                    ["GeneratorShortName"] = generatorShortname
                                };
                                var replacer = new TokenReplacer("T_", "_", outerTokens);
                                // end of generator header
                                foreach (var line in generator_header)
                                {
                                    string? actualOutput = replacer.ReplaceTokens(line);
                                    yield return actualOutput;
                                }
                                // end of generator header
                                yield return $"{outerIndent}{PrefixCsharpComment} {FormatDirective(DirectiveGeneratorBody)}";
                                state = TextState.Body;
                            }
                            else
                            {
                                throw new ArgumentOutOfRangeException(nameof(directive), directive, null);
                            }
                        }
                        else
                        {
                            // not started - just emit
                            yield return input;
                        }
                        break;
                    case TextState.Header:
                        break;
                    case TextState.Body:
                        if (sourceCode.StartsWith(PrefixCsharpComment))
                        {
                            // comment found
                            string comment = sourceCode.Substring(PrefixCsharpComment.Length);
                            var directive = GetMetaCodeDirective(comment);
                            if (directive == DirectiveTemplateEnd)
                            {
                                yield return $"{outerIndent}{PrefixCsharpComment} {FormatDirective(DirectiveGeneratorFooter)}";
                                foreach (var line in generator_footer)
                                {
                                    yield return line;
                                }
                                yield return $"{outerIndent}{PrefixCsharpComment} {FormatDirective(DirectiveGeneratorEnd)}";
                                state = TextState.Footer;
                            }
                            else
                            {
                                (string innerIndent, string candidate) = StripLeadingWhitespace(comment);
                                if (candidate.StartsWith(PrefixMetaCode))
                                {
                                    // metacode found - emit
                                    string metacode = candidate.Substring(PrefixMetaCode.Length);
                                    yield return $"{outerIndent}{innerIndent}{metacode}";
                                }
                                else
                                {
                                    // not metacode - just emit the input unchanged
                                    string encodedSource = EncodeSource(etc, outerIndent, sourceCode);
                                    yield return $"{EmitCodePrefix}{encodedSource}{EmitCodeSuffix}";
                                }
                            }
                        }
                        else
                        {
                            // not comment - emit code
                            string encodedSource = EncodeSource(etc, outerIndent, sourceCode);
                            yield return $"{EmitCodePrefix}{encodedSource}{EmitCodeSuffix}";
                        }
                        break;
                    case TextState.Footer:
                    case TextState.End:
                        // ended - just emit
                        yield return input;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(state), state, null);
                }
            }
            if (state == TextState.Body)
            {
                yield return $"{PrefixCsharpComment} {FormatDirective(DirectiveGeneratorFooter)}";
                foreach (var line in generator_footer)
                {
                    yield return line;
                }
                yield return $"{PrefixCsharpComment} {FormatDirective(DirectiveGeneratorEnd)}";
                state = TextState.Footer;
            }

        }

        public static IEnumerable<string?> EmitEncryptedText(
            IEncryptedTextCache etc,
            string generatorNamespace,
            string generatorShortname)
        {
            string[] file_header = new string[]
            {
                "using System.Collections.Generic;",
                "namespace T_GeneratorNamespace_",
                "{",
                "    public partial class Generator",
                "    {",
                "        protected override string OnGetEncryptionKeyId() => \"T_GeneratorKeyId_\";",
                "        protected override IEnumerable<(string,string)> OnGetEncryptedText()",
                "        {",
            };
            string[] file_footer = new string[]
            {
                "        }",
                "    }",
                "}"
            };
            var outerTokens = new Dictionary<string, string>()
            {
                ["GeneratorNamespace"] = generatorNamespace,
                ["GeneratorShortName"] = generatorShortname,
                ["GeneratorKeyId"] = etc.KeyId.ToString("N"),
            };
            var replacer = new TokenReplacer("T_", "_", outerTokens);
            foreach (string line in file_header)
            {
                yield return replacer.ReplaceTokens(line);
            }
            foreach (var kvp in etc.Cache)
            {
                string line = $"            yield return (\"{kvp.Key.ToString("N")}\", \"{Convert.ToBase64String(kvp.Value.AsSpan().ToArray())}\");";
                yield return line;
            }
            foreach (string line in file_footer)
            {
                yield return line;
            }
        }

        private static string EncodeSource(IEncryptedTextCache etc, string outerIndent, string sourceCode)
        {
            string encodedSource;
            if (etc.IsNonEncrypting)
            {
                encodedSource = $"{outerIndent}{Escaped(sourceCode)}";
            }
            else
            {
                string clearText = $"{outerIndent}{sourceCode}";
                Guid hash = etc.AddText(clearText);
                encodedSource = hash.ToString("N");
            }

            return encodedSource;
        }
        private static string? Escaped(string input)
        {
            if (input is null) return null;
            // escape double quotes
            StringBuilder result = new StringBuilder();
            foreach (char ch in input)
            {
                if (ch == '"') // || ch == '\\')
                    result.Append('\\');
                result.Append(ch);
            }
            return result.ToString();
        }

        private static string Unescaped(string input)
        {
            //if (input is null) return null;
            // un-escape double quotes
            return input.Replace("\\\"", "\"");
        }

        public static IEnumerable<string> ConvertGeneratorToTemplate(IEnumerable<string> sourceLines, IEncryptedTextCache? etc)
        {
            TextState state = default;
            int lineNumber = 0;
            foreach (string input in sourceLines)
            {
                lineNumber++;
                (string outerIndent, string sourceCode) = StripLeadingWhitespace(input);
                switch (state)
                {
                    case TextState.Init:
                        // scan for GeneratorHeader directive
                        if (sourceCode.StartsWith(PrefixCsharpComment))
                        {
                            string comment = sourceCode.Substring(PrefixCsharpComment.Length);
                            var directive = GetMetaCodeDirective(comment);
                            if (directive is null)
                            {
                                yield return input;
                            }
                            else if (directive == DirectiveGeneratorHeader)
                            {
                                state = TextState.Header;
                            }
                            else
                            {
                                throw new ArgumentOutOfRangeException(nameof(directive), directive, null);
                            }
                        }
                        else
                        {
                            // not started - just emit
                            yield return input;
                        }
                        break;
                    case TextState.Header:
                        // ignore lines until GeneratorBody directive
                        if (sourceCode.StartsWith(PrefixCsharpComment))
                        {
                            string comment = sourceCode.Substring(PrefixCsharpComment.Length);
                            var directive = GetMetaCodeDirective(comment);
                            if (directive is null)
                            {
                                // ignore
                            }
                            else if (directive == DirectiveGeneratorBody)
                            {
                                yield return $"{outerIndent}{PrefixCsharpComment} {FormatDirective(DirectiveTemplateBegin)}";
                                state = TextState.Body;
                            }
                            else
                            {
                                throw new ArgumentOutOfRangeException(nameof(directive), directive, null);
                            }
                        }
                        else
                        {
                            // ignore
                        }
                        break;
                    case TextState.Body:
                        if (sourceCode.StartsWith(PrefixCsharpComment))
                        {
                            string comment = sourceCode.Substring(PrefixCsharpComment.Length);
                            var directive = GetMetaCodeDirective(comment);
                            if (directive is null)
                            {
                                // comment found - emit unchanged
                                yield return input;
                            }
                            else if (directive == DirectiveGeneratorFooter)
                            {
                                state = TextState.Footer;
                            }
                            else
                            {
                                throw new ArgumentOutOfRangeException(nameof(directive), directive, null);
                            }
                        }
                        else
                        {
                            if (sourceCode.StartsWith(EmitCodePrefix) && sourceCode.EndsWith(EmitCodeSuffix))
                            {
                                string emitted = sourceCode
                                    .Substring(0, sourceCode.Length - EmitCodeSuffix.Length)
                                    .Substring(EmitCodePrefix.Length);
                                if (etc is null)
                                {
                                    yield return Unescaped(emitted);
                                }
                                else
                                {
                                    Guid hash = Guid.Parse(emitted);
                                    string decryptedSource = etc.GetText(hash);
                                    yield return decryptedSource;
                                }
                            }
                            else
                            {
                                // not emitted code - assume metacode
                                yield return $"{PrefixCsharpComment}{PrefixMetaCode}{outerIndent}{sourceCode}";
                            }
                        }
                        break;
                    case TextState.Footer:
                        // ignore lines until GeneratorEnd directive
                        if (sourceCode.StartsWith(PrefixCsharpComment))
                        {
                            string comment = sourceCode.Substring(PrefixCsharpComment.Length);
                            var directive = GetMetaCodeDirective(comment);
                            if (directive is null)
                            {
                                // ignore
                            }
                            else if (directive == DirectiveGeneratorEnd)
                            {
                                yield return $"{outerIndent}{PrefixCsharpComment} {FormatDirective(DirectiveTemplateEnd)}";
                                state = TextState.End;
                            }
                            else
                            {
                                throw new ArgumentOutOfRangeException(nameof(directive), directive, null);
                            }
                        }
                        else
                        {
                            // ignore
                        }
                        break;
                    case TextState.End:
                        // ended - just emit
                        yield return input;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(state), state, null);
                }
            }
        }
    }
}