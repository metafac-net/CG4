using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace MetaFac.CG4.Generators
{
    public class TemplateScope
    {
        public static readonly TemplateScope Empty = new TemplateScope();

        public readonly ImmutableDictionary<string, string> Tokens;

        public TemplateScope(ImmutableDictionary<string, string> tokens)
        {
            Tokens = tokens ?? throw new System.ArgumentNullException(nameof(tokens));
        }

        public TemplateScope(IEnumerable<KeyValuePair<string, string>>? tokens = null)
        {
            Tokens = tokens?.ToImmutableDictionary() ?? ImmutableDictionary<string, string>.Empty;
        }

        public TemplateScope SetTokens(IEnumerable<KeyValuePair<string, string>> tokens)
        {
            var tokensToAdd = tokens ?? Enumerable.Empty<KeyValuePair<string, string>>();
            return new TemplateScope(Tokens.SetItems(tokensToAdd));
        }

        public TemplateScope SetToken(string name, string value)
        {
            return new TemplateScope(Tokens.SetItem(name, value));
        }

        public TemplateScope SetProxyTypeTokens(ProxyDef proxyDef)
        {
            KeyValuePair<string, string>[] tokens = new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>($"External{proxyDef.ProxyTypeName}", proxyDef.ExternalTypeName),
                new KeyValuePair<string, string>($"Concrete{proxyDef.ProxyTypeName}", proxyDef.ConcreteTypeName),
            };
            return new TemplateScope(Tokens.SetItems(tokens));
        }

    }
}