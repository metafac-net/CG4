using MetaFac.CG3.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaFac.CG3.Generators.UnitTests.PolymorphicModels
{
    [Entity(1)]
    public abstract class ValueNode
    {
        [Member(1)] public long Id { get; set; }
        [Member(2)] public string? Name { get; set; }
    }

    [Entity(2)]
    public sealed class Int32Node : ValueNode
    {
        [Member(1)] public int IntValue { get; set; }
    }

    [Entity(3)]
    public sealed class StringNode : ValueNode
    {
        [Member(1)] public string? StrValue { get; set; }
    }

    [Entity(4)]
    public sealed class BooleanNode : ValueNode
    {
        [Member(1)] public bool BoolValue { get; set; }
    }

    [Entity(10)]
    public sealed class Tree
    {
        [Member(1)] public Tree? Left { get; set; }
        [Member(2)] public Tree? Right { get; set; }
        [Member(3)] public ValueNode? Value { get; set; }
    }
}
