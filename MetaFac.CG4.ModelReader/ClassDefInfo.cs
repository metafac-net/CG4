using System;
using System.Collections.Generic;

namespace MetaFac.CG4.ModelReader
{
    internal class ClassDefInfo
    {
        public readonly Type ClassType;
        public readonly int? ClassTag;
        //public readonly Dictionary<string, string> ClassTokens;

        public ClassDefInfo(Type classType, int? classTag)
        {
            ClassType = classType ?? throw new ArgumentNullException(nameof(classType));
            ClassTag = classTag;
            //ClassTokens = classTokens ?? new Dictionary<string, string>();
        }
    }
}
