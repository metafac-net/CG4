using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace MetaCode.Generators
{
    public class TemplateIterator
    {
        public readonly string Name;
        public readonly ImmutableList<TemplateScope> Iterations;

        public TemplateIterator(string name, IEnumerable<TemplateScope> iterations)
        {
            Name = name;
            Iterations = ImmutableList<TemplateScope>.Empty.AddRange(iterations ?? Enumerable.Empty<TemplateScope>());
        }
    }
}
