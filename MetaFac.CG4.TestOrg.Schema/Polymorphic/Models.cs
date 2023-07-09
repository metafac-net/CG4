using MetaFac.CG4.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaFac.CG4.TestOrg.Schema.Polymorphic
{
    public enum CustomEnum
    {
        Value0,
        Value1,
    }

    [Entity(1)]
    public interface IValueNode
    {
        [Member(1)] public long Id { get; set; }
        [Member(2)] public string? Name { get; set; }
    }

    [Entity(2)]
    public interface INumericNode : IValueNode
    {
    }

    [Entity(3)]
    public interface IStringNode : IValueNode
    {
        [Member(3)] public string? StrValue { get; set; }
    }

    [Entity(4)]
    public interface IBooleanNode : IValueNode
    {
        [Member(3)] public bool BoolValue { get; set; }
    }

    [Entity(5)]
    public interface ICustomNode : IValueNode
    {
        [Member(3)] public CustomEnum CustomValue { get; set; }
    }

    [Entity(6)]
    public interface IInt32Node : INumericNode
    {
        [Member(3)] public int IntValue { get; set; }
    }

    [Entity(7)]
    public interface IInt64Node : INumericNode
    {
        [Member(3)] public long LongValue { get; set; }
    }
}
