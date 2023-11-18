using FluentModels;

namespace MetaFac.CG4.TestOrg.Schema.Invalid
{
    [Entity(1)]
    public class BadPerson
    {
        [Member(1)]
        string? FamilyName { get; }

        [Member(1)]
        string? FirstName { get; }
    }
}
