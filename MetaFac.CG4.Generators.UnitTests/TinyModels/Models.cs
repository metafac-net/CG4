using MetaFac.CG4.Attributes;

namespace MetaFac.CG4.Generators.UnitTests.TinyModels
{
    [Entity(1)]
    public interface IBase
    {
        [Member(1)] int Id { get; }
    }
    [Entity(2)]
    public interface IDerived
    {
        [Member(1)] string Name { get; }
        [Member(2, ModelState.Reserved)] int ReservedField { get; }
    }
}
