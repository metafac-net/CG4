#region Notices
// <auto-generated>
// Warning: This file was automatically generated. Changes to this file may
// cause incorrect behavior and will be lost when this file is regenerated.
// </auto-generated>
// <information>
// This file was generated using MetaFac.CG4 tools and user supplied metadata.
// Generator: Contracts.2.8
// Metadata : MetaFac.CG4.TestOrg.Schema(.XtraComplex)
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
using System.Numerics;

namespace MetaFac.CG4.TestOrg.Models.XtraComplex.Contracts
{
    public partial interface ITree : IEntityBase
    {
        INode? Value { get; }
        ITree? A { get; }
        ITree? B { get; }
    }
    public partial interface INode : IEntityBase
    {
    }
    public partial interface IStrNode : INode
    {
        String? StrVal { get; }
    }
    public partial interface INumNode : INode
    {
    }
    public partial interface ILongNode : INumNode
    {
        Int64 LongVal { get; }
    }
    public partial interface IDaynNode : INumNode
    {
        System.DayOfWeek DaynVal { get; }
    }
}
