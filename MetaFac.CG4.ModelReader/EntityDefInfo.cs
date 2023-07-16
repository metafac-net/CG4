using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MetaFac.CG4.ModelReader
{
    internal static class TypeHelpers
    {
    }
    internal class EntityDefInfo
    {
        private readonly TypeInfo _typeInfo;
        public readonly string EntityName;
        // private readonly Type? BaseTypeqqq;
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
            if (_typeInfo.BaseType is not null && _typeInfo.BaseType != typeof(object))
                ParentName = _typeInfo.BaseType.Name;
            else
                ParentName = null;
            //var uniqueInterfaces = GetUniqueInterfaces(typeInfo.ImplementedInterfaces);
            //foreach (Type implementedInterface in uniqueInterfaces)
            //{
            //    if (BaseType is null)
            //    {
            //        BaseType = implementedInterface;
            //        ParentName = BaseType.Name;
            //    }
            //    else
            //    {
            //        throw new ArgumentException("Cannot implement more than 1 interface", nameof(typeInfo));
            //    }
            //}
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