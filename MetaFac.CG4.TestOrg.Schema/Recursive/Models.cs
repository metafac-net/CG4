
using MetaFac.CG4.Schemas;

namespace MetaFac.CG4.TestOrg.Schema.Recursive
{
    [Entity(1)]
    public class Tree
    {
        [Member(1)] public int Id { get; }
        [Member(2)] public Tree? A { get; }
        [Member(3)] public Tree? B { get; }
    }
}
