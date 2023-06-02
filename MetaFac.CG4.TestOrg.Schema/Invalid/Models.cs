using MetaFac.CG4.Attributes;

namespace MetaFac.CG4.TestOrg.Schema.Invalid
{
    [Entity(1)]
    public interface IBadPerson
    {
        [Member(1)]
        string FamilyName { get; }

        [Member(1)]
        string FirstName { get; }
    }
}
