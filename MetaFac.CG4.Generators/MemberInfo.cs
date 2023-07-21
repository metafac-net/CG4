using MetaFac.CG4.Models;
using System;

namespace MetaFac.CG4.Generators
{
    public class MemberInfo
    {
        private readonly EngineScope _engineScope;

        public FieldKind Kind { get; }

        private void Define(string name, string value)
        {
            _engineScope.SetToken(name, value);
        }

        private void DefineFieldName(string kind)
        {
            if (Kind.IsIndexType())
                Define($"Index{kind}FieldName", "T_FieldName_");
            else if (Kind.IsArrayType())
                Define($"Array{kind}FieldName", "T_FieldName_");
            else
                Define($"Unary{kind}FieldName", "T_FieldName_");
        }
        public MemberInfo(ModelMemberDef memberDef, EngineScope engineScope)
        {
            _engineScope = engineScope ?? throw new ArgumentNullException(nameof(engineScope));

            Kind = default;
            if (memberDef.IsModelType) Kind = Kind | FieldKind.IsModelType;
            if (memberDef.IndexType is not null) Kind = Kind | FieldKind.IsIndexType;
            if (memberDef.ArrayRank > 0) Kind = Kind | FieldKind.IsArrayType;
            if (memberDef.IsBufferType) Kind = Kind | FieldKind.IsBufferType;
            if (memberDef.IsStringType) Kind = Kind | FieldKind.IsStringType;
            if (memberDef.Nullable) Kind = Kind | FieldKind.IsNullable;
            if (Kind.IsModelType())
            {
                DefineFieldName("Model");
            }
            else if (Kind.IsBufferType())
            {
                DefineFieldName("Buffer");
            }
            else if (Kind.IsStringType())
            {
                DefineFieldName("String");
            }
            else
            {
                if (Kind.IsNullable())
                {
                    Define("ExternalMaybeType", "T_ExternalT_InnerType__");
                    Define("ConcreteMaybeType", "T_ConcreteT_InnerType__");
                    DefineFieldName("Maybe");
                }
                else
                {
                    Define("ExternalOtherType", "T_ExternalT_InnerType__");
                    Define("ConcreteOtherType", "T_ConcreteT_InnerType__");
                    DefineFieldName("Other");
                }
            }
        }
    }
}