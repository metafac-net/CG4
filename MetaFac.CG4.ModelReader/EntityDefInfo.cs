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
        public readonly bool IsAbstract;
        public string? ParentName;
        public readonly int? Tag;

        private static Type[] GetUniqueInterfaces(IEnumerable<Type> candidates)
        {
            List<Type> results = new List<Type>();
            foreach (var candidate in candidates)
            {
                // if any interface so far examined implements this then discard this
                if (results.Any(t => t.GetTypeInfo().ImplementedInterfaces.Contains(candidate)))
                    continue;

                Type[] implementedInterfaces = candidate.GetTypeInfo().ImplementedInterfaces.ToArray();
                int count = 0;
                int index = -1;
                for (int r = 0; r < results.Count; r++)
                {
                    var result = results[r];
                    if (implementedInterfaces.Contains(result))
                    {
                        index = r;
                        count++;
                    }
                }

                if (count > 1) throw new ArgumentException("Cannot implement more than 1 interface");

                else if (count == 1)
                {
                    // replace
                    results[index] = candidate;
                }
                else
                {
                    // otherwise add it
                    results.Add(candidate);
                }
            }
            return results.ToArray();
        }

        public EntityDefInfo(TypeInfo typeInfo, int? tag)
        {
            if (!typeInfo.IsClass) throw new ArgumentException("Must be an class type", nameof(typeInfo));
            _typeInfo = typeInfo ?? throw new ArgumentNullException(nameof(typeInfo));
            EntityName = _typeInfo.Name;
            IsAbstract = _typeInfo.IsAbstract;
            ParentName = _typeInfo.BaseType is not null && _typeInfo.BaseType != typeof(object)
                ? _typeInfo.BaseType.Name
                : null;
            Tag = tag;
        }

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