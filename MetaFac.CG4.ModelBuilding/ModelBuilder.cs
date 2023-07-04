using MetaFac.CG4.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MetaFac.CG4.ModelBuilding
{
    public static class ModelBuilder
    {
        public static IModelContainerBuilder Create() => new ModelContainerBuilder();
    }
}