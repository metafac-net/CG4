﻿
using MetaFac.CG4.Schemas;

namespace MetaFac.CG4.TestOrg.Schema.Personel
{
    public enum GenderEnum
    {
        Undefined,
        Male,
        Female,
    }

    [Entity(1)]
    public class Person
    {
        [Member(1)] string? FamilyName { get; }
        [Member(2)] string? FirstName { get; }
        [Member(3, ModelState.Hidden)] string? OtherNames { get; }
        [Member(4)] GenderEnum Gender { get; }
        [Member(5)] System.DayOfWeek DayOfBirth { get; }
    }
}
