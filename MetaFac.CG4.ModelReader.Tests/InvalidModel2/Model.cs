using FluentModels;
using System;

namespace MetaFac.CG4.ModelReader.Tests.InvalidModel2
{
    [Entity(1)]
    public class InvalidEntity2
    {
        [Member(1)] public Type? MyType { get; }
    }
}
