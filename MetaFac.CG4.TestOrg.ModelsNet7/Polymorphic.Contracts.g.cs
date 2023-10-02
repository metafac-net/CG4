#region Notices
// <auto-generated>
// Warning: This file was automatically generated. Changes to this file may
// cause incorrect behavior and will be lost when this file is regenerated.
// </auto-generated>
// <information>
// This file was generated using MetaFac.CG4 tools and user supplied metadata.
// Generator: Contracts.2.2
// Metadata : MetaFac.CG4.TestOrg.Schema(.Polymorphic)
// </information>
#endregion
#nullable enable
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS8019 // Unnecessary using directive
using MetaFac.CG4.Runtime;
using MetaFac.Memory;
using MetaFac.Mutability;
using System;
using System.Collections.Generic;

namespace MetaFac.CG4.TestOrg.ModelsNet7.Polymorphic.Contracts
{
    public enum CustomEnum
    {
        Value0 = 0,
        Value1 = 1,
    }
    public partial interface IValueNode : IEntityBase
    {
        Int64 Id { get; }
        String? Name { get; }
    }
    public partial interface INumericNode : IValueNode
    {
    }
    public partial interface IStringNode : IValueNode
    {
        String? StrValue { get; }
    }
    public partial interface IBooleanNode : IValueNode
    {
        Boolean BoolValue { get; }
    }
    public partial interface ICustomNode : IValueNode
    {
        CustomEnum CustomValue { get; }
    }
    public partial interface IInt32Node : INumericNode
    {
        Int32 IntValue { get; }
    }
    public partial interface IInt64Node : INumericNode
    {
        Int64 LongValue { get; }
    }
}
