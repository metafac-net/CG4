using MetaFac.CG4.Attributes;

namespace MetaFac.CG4.TestOrg.Schema.XtraComplex
{
    [Entity(1)]
    public class Tree
    {
        [Member(1)] Node? Value { get; }
        [Member(2)] Tree? A { get; }
        [Member(3)] Tree? B { get; }
    }

    [Entity(2)]
    public class Node
    {
    }

    [Entity(3)]
    public class StrNode : Node
    {
        [Member(1)] string? StrVal { get; }
    }

    [Entity(4)]
    public class NumNode : Node
    {
    }

    [Entity(5)]
    public class LongNode : NumNode
    {
        [Member(1)] long LongVal { get; }
    }

    [Entity(6)]
    public class ByteNode : NumNode
    {
        [Member(1)] byte ByteVal { get; }
    }
}
