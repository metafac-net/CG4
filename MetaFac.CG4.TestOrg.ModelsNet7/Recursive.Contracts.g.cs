#region Notices
// <auto-generated>
// Warning: This file was automatically generated. Changes to this file may
// cause incorrect behavior and will be lost when this file is regenerated.
// </auto-generated>
// <information>
// This file was generated using MetaFac.CG4 tools and user supplied metadata.
// Generator: Contracts.2.6
// Metadata : MetaFac.CG4.TestOrg.Schema(.Recursive)
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

namespace MetaFac.CG4.TestOrg.ModelsNet7.Recursive.Contracts
{
    public partial interface ITree : IEntityBase
    {
        Int32 Id { get; }
        ITree? A { get; }
        ITree? B { get; }
    }
}
