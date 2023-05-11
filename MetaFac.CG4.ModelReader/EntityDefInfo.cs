using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MetaFac.CG4.ModelReader
{
    internal class EntityDefInfo
    {
        private readonly TypeInfo _typeInfo;
        public readonly string EntityName;
        private readonly Type? BaseType;
        public string? ParentName;
        public readonly int? Tag;

        public EntityDefInfo(TypeInfo typeInfo, int? tag)
        {
            if (!typeInfo.IsInterface) throw new ArgumentException("Must be an interface type", nameof(typeInfo));
            if (!typeInfo.Name.StartsWith("I")) throw new ArgumentException("Interface name must start with 'I'", nameof(typeInfo));
            _typeInfo = typeInfo ?? throw new ArgumentNullException(nameof(typeInfo));
            EntityName = _typeInfo.Name.Substring(1);
            BaseType = null;
            foreach (Type implementedInterface in typeInfo.ImplementedInterfaces)
            {
                if (BaseType is null)
                {
                    BaseType = implementedInterface;
                    ParentName= BaseType.Name.Substring(1);
                }
                else
                {
                    throw new ArgumentException("Cannot implement more than 1 interface", nameof(typeInfo));
                }
            }
            Tag = tag;
        }

        public bool IsAbstract => _typeInfo.IsAbstract;

        public object[] CustomAttributes => _typeInfo.GetCustomAttributes(false);

        public PropertyInfo[] RuntimeProperties
        {
            get
            {
                Type declaringType = _typeInfo.AsType();
                var result = _typeInfo.GetRuntimeProperties()
                    .Where(p => p.DeclaringType == declaringType)
                    .ToArray();
                return result;
}
        }
    }
}
