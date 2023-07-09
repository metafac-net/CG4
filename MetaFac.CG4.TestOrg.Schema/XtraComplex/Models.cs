using MetaFac.CG4.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaFac.CG4.TestOrg.Schema.XtraComplex
{
    [Entity(1)]
    public interface ITree
    {
        [Member(1)] public INode Value { get; }
        [Member(2)] public ITree? A { get; }
        [Member(3)] public ITree? B { get; }
    }

    [Entity(2)]
    public interface INode
    {
    }

    [Entity(3)]
    public interface IStrNode : INode
    {
        [Member(1)] public string StrVal { get; }
    }

    [Entity(4)]
    public interface INumNode : INode
    {
        [Member(1)] public long NumVal { get; }
    }
}
