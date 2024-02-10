using FluentModels;

namespace MetaFac.CG4.ModelReader.Tests.InvalidModel1
{
    [Entity(1)]
    public class InvalidEntity1
    {
        [Member(1)] public bool[,]? Grid { get; }
    }
}