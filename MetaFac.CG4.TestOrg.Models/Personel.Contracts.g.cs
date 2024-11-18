#region Notices
// <auto-generated>
// Warning: This file was automatically generated. Changes to this file may
// cause incorrect behavior and will be lost when this file is regenerated.
// </auto-generated>
// <information>
// This file was generated using MetaFac.CG4 tools and user supplied metadata.
// Generator: Contracts.2.10
// Metadata : MetaFac.CG4.TestOrg.Schema(.Personel)
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

namespace MetaFac.CG4.TestOrg.Models.Personel.Contracts
{
    public enum GenderEnum
    {
        Undefined = 0,
        Male = 1,
        Female = 2,
    }
    public partial interface IPerson : IEntityBase
    {
        String? FamilyName { get; }
        String? FirstName { get; }
        GenderEnum Gender { get; }
        System.DayOfWeek DayOfBirth { get; }
    }
}
