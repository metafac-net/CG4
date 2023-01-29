using System.Collections.Generic;
using System.Collections.Immutable;

namespace MetaFac.CG3.TextProcessing
{
    public class TokenReplacer
    {
        private readonly string _prefix;
        private readonly string _suffix;
        private readonly ImmutableDictionary<string, string> _tokens;

        public TokenReplacer(string prefix, string suffix, IEnumerable<KeyValuePair<string, string>> tokens)
        {
            _prefix = prefix;
            _suffix = suffix;
            _tokens = tokens?.ToImmutableDictionary() ?? ImmutableDictionary<string, string>.Empty;
        }

        public string ReplaceTokens(string input)
        {
            // todo this is a brute force method
            string result = input;
            string lastResult;
            do
            {
                lastResult = result;
                foreach (var item in _tokens)
                {
                    string token = _prefix + item.Key + _suffix;
                    string before = result;
                    result = result.Replace(token, item.Value);
                    string after = result;
                    if (after != before)
                    {
                        after = before;
                    }
                }
            } while (result != lastResult);
            return result;
        }
    }
}