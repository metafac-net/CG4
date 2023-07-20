using System.Collections.Generic;
using System.Collections.Immutable;

namespace MetaFac.CG4.Generators
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
                }
            } while (result != lastResult);
            return result;
        }
    }
}