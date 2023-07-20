using MetaFac.CG4.Attributes;

namespace MetaFac.CG4.Generators.UnitTests.PolymorphicModels
{
    public enum CustomEnum
    {
        Value0,
        Value1,
    }

    [Entity(1)]
    public class ValueNode
    {
        [Member(1)] public long Id { get; set; }
        [Member(2)] public string? Name { get; set; }
    }

    [Entity(2)]
    public class NumericNode : ValueNode
    {
    }

    [Entity(3)]
    public class StringNode : ValueNode
    {
        [Member(1)] public string? StrValue { get; set; }
    }

    [Entity(4)]
    public class BooleanNode : ValueNode
    {
        [Member(1)] public bool BoolValue { get; set; }
    }

    [Entity(5)]
    public class CustomNode : ValueNode
    {
        [Member(1)] public CustomEnum CustomValue { get; set; }
    }

    [Entity(6)]
    public class Int32Node : NumericNode
    {
        [Member(1)] public int IntValue { get; set; }
    }

    [Entity(7)]
    public class Int64Node : NumericNode
    {
        [Member(1)] public long LongValue { get; set; }
    }

    [Entity(10)]
    public class Tree
    {
        [Member(1)] public Tree? Left { get; set; }
        [Member(2)] public Tree? Right { get; set; }
        [Member(3)] public ValueNode? Value { get; set; }
    }
}
