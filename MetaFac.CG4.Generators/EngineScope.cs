using System.Collections.Generic;
using System.Collections.Immutable;

namespace MetaFac.CG4.Generators
{

    public class EngineScope
    {
        public static readonly EngineScope Default = new EngineScope();


        public bool Ignored { get; }
        public TemplateScope Scope { get; private set; }

        public void SetTokens(IEnumerable<KeyValuePair<string, string>> tokens)
        {
            Scope = Scope.SetTokens(tokens);
        }

        public void SetToken(string name, string value)
        {
            Scope = Scope.SetToken(name, value);
        }

        public EngineScope(TemplateScope? scope = null, bool ignored = false)
        {
            Ignored = ignored;
            Scope = scope ?? TemplateScope.Empty;
        }

        public string? ReplaceTokens(string input)
        {
            if (input is null) return null;
            if (Ignored) return input;
            TokenReplacer _replacer = new TokenReplacer("T_", "_", Scope.Tokens);
            string? output = _replacer.ReplaceTokens(input);
            return output;
        }
    }
}