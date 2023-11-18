using FluentModels;

namespace MetaFac.CG4.Generators.UnitTests.TinyModels
{
    [Entity(1)]
    public class Base
    {
        [Member(1)] int Id { get; }
    }
    [Entity(2)]
    public class Derived
    {
        [Member(1)] string? Name { get; }
        [Member(2, ModelState.Hidden)] int ReservedField { get; }
        [Member(3)] long? Number { get; }
    }
}
