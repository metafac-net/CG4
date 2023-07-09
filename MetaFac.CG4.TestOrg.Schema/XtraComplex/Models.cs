using MetaFac.CG4.Attributes;

namespace MetaFac.CG4.TestOrg.Schema.XtraComplex
{
    [Entity(1)]
    public interface ITree
    {
        [Member(1)] INode Value { get; }
        [Member(2)] ITree? A { get; }
        [Member(3)] ITree? B { get; }
    }

    [Entity(2)]
    public interface INode
    {
    }

    [Entity(3)]
    public interface IStrNode : INode
    {
        [Member(1)] string StrVal { get; }
    }

    [Entity(4)]
    public interface INumNode : INode
    {
    }

    [Entity(5)]
    public interface ILongNode : INumNode
    {
        [Member(1)] long LongVal { get; }
    }

    [Entity(6)]
    public interface IByteNode : INumNode
    {
        [Member(1)] byte ByteVal { get; }
    }
}
