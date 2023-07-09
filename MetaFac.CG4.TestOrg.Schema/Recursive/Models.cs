using MetaFac.CG4.Attributes;

namespace MetaFac.CG4.TestOrg.Schema.Recursive
{
    [Entity(1)]
    public interface ITree
    {
        [Member(1)] public int Id { get; }
        [Member(2)] public ITree? A { get; }
        [Member(3)] public ITree? B { get; }
    }
}
