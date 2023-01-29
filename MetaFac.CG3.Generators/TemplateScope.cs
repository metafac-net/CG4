using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace MetaCode.Generators
{
    public class TemplateScope
    {
        public static readonly TemplateScope Empty = new TemplateScope();

        public readonly ImmutableDictionary<string, string> Tokens;
        public readonly ImmutableDictionary<string, TemplateIterator> Iterators;

        public TemplateScope(ImmutableDictionary<string, string> tokens, ImmutableDictionary<string, TemplateIterator> iterators)
        {
            Tokens = tokens ?? throw new System.ArgumentNullException(nameof(tokens));
            Iterators = iterators ?? throw new System.ArgumentNullException(nameof(iterators));
        }

        public TemplateScope(IEnumerable<KeyValuePair<string, string>>? tokens = null, IEnumerable<KeyValuePair<string, TemplateIterator>>? iterators = null)
        {
            Iterators = iterators?.ToImmutableDictionary() ?? ImmutableDictionary<string, TemplateIterator>.Empty;
            Tokens = tokens?.ToImmutableDictionary() ?? ImmutableDictionary<string, string>.Empty;
        }

        public TemplateScope SetTokens(IEnumerable<KeyValuePair<string, string>> tokens)
        {
            var tokensToAdd = tokens ?? Enumerable.Empty<KeyValuePair<string, string>>();
            return new TemplateScope(Tokens.SetItems(tokensToAdd), Iterators);
        }

        public TemplateScope SetToken(string name, string value)
        {
            return new TemplateScope(Tokens.SetItem(name, value), Iterators);
        }

        public TemplateScope SetProxyTypeTokens(ProxyDef proxyDef)
        {
            KeyValuePair<string, string>[] tokens = new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>($"External{proxyDef.ProxyTypeName}", proxyDef.ExternalTypeName),
                new KeyValuePair<string, string>($"Concrete{proxyDef.ProxyTypeName}", proxyDef.ConcreteTypeName),
            };
            return new TemplateScope(Tokens.SetItems(tokens), Iterators);
        }

    }
}