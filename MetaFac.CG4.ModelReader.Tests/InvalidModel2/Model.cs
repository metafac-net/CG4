using MetaFac.CG4.Schemas;
using System;

namespace MetaFac.CG4.ModelReader.Tests.InvalidModel2
{
    [Entity(1)]
    public interface IInvalidEntity2
    {
        [Member(1)] public Version MyVersion { get; }
    }
}
