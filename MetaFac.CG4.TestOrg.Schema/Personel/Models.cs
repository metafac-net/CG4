using MetaFac.CG4.Attributes;

namespace MetaFac.CG4.TestOrg.Schema.Personel
{
    [Entity(1)]
    public interface IPerson
    {
        [Member(1)]
        string FamilyName { get; }

        [Member(2)]
        string FirstName { get; }
    }
}
