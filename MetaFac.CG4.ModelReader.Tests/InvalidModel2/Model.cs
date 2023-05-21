using MetaFac.CG4.Attributes;
using System;

namespace MetaFac.CG4.ModelReader.Tests.InvalidModel2
{
    [Entity(1)]
    public interface IInvalidEntity2
    {
        [Member(1)] public Version MyVersion { get; }
    }
}
