using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace MetaFac.CG3.Generators
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
