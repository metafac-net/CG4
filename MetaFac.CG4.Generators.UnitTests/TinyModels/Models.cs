using MetaFac.CG4.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
