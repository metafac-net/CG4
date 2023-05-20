using MetaFac.CG4.Schemas;

namespace MetaFac.CG4.ModelReader.Tests.InvalidModel1
{
    [Entity(1)]
    public interface IInvalidEntity1
    {
        [Member(1)] public bool[,] Grid { get; }
    }
}