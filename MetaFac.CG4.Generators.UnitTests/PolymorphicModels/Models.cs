using MetaFac.CG4.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaFac.CG4.Generators.UnitTests.PolymorphicModels
{
    [Entity(1)]
    public interface IValueNode
    {
        [Member(1)] public long Id { get; set; }
        [Member(2)] public string? Name { get; set; }
    }

    [Entity(2)]
    public interface IInt32Node : IValueNode
    {
        [Member(1)] public int IntValue { get; set; }
    }

    [Entity(3)]
    public interface IStringNode : IValueNode
    {
        [Member(1)] public string? StrValue { get; set; }
    }

    [Entity(4)]
    public interface IBooleanNode : IValueNode
    {
        [Member(1)] public bool BoolValue { get; set; }
    }

    [Entity(10)]
    public interface ITree
    {
        [Member(1)] public ITree? Left { get; set; }
        [Member(2)] public ITree? Right { get; set; }
        [Member(3)] public IValueNode? Value { get; set; }
    }
}
