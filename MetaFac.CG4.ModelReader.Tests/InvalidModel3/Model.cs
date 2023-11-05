using MetaFac.CG4.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaFac.CG4.ModelReader.Tests.InvalidModel3
{
    [Entity(1)]
    public abstract class BaseEntity
    {
        [Member(1)] public int BaseField1 { get; }
    }

    [Entity(2)]
    public class InvalidEntity3 : BaseEntity
    {
        [Member(1)] public string? MyField1 { get; }
    }
}