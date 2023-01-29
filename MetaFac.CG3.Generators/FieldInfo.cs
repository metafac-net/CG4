using System;

namespace MetaFac.CG3.Generators
{
    public class FieldInfo
    {
        private readonly EngineScope _engineScope;

        public FieldKind Kind { get; }

        private readonly bool _isSignedType;
        public bool IsSignedType => _isSignedType;
        private readonly bool _isUnsignedType;
        public bool IsUnsignedType => _isUnsignedType;

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
        public FieldInfo(TemplateScope fieldScope, EngineScope engineScope)
        {
            _engineScope = engineScope ?? throw new ArgumentNullException(nameof(engineScope));

            _isSignedType = fieldScope.Tokens.TryGetValue("SignedType", out var _);
            _isUnsignedType = fieldScope.Tokens.TryGetValue("UnsignedType", out var _);

            Kind = default;
            if (fieldScope.Tokens.TryGetValue("ModelType", out var _)) Kind = Kind | FieldKind.IsModelType;
            if (fieldScope.Tokens.TryGetValue("IndexType", out var _)) Kind = Kind | FieldKind.IsIndexType;
            if (fieldScope.Tokens.TryGetValue("ArrayRank", out var _)) Kind = Kind | FieldKind.IsArrayType;
            if (fieldScope.Tokens.TryGetValue("BufferType", out var _)) Kind = Kind | FieldKind.IsBufferType;
            if (fieldScope.Tokens.TryGetValue("StringType", out var _)) Kind = Kind | FieldKind.IsStringType;
            if (fieldScope.Tokens.TryGetValue("Nullable", out var _)) Kind = Kind | FieldKind.IsNullable;
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
                Define("ExternalOtherType", "T_ExternalT_InnerType__");
                Define("ConcreteOtherType", "T_ConcreteT_InnerType__");
                if (Kind.IsNullable())
                {
                    DefineFieldName("Maybe");
                }
                else
                {
                    DefineFieldName("Other");
                }
            }
        }

    }
}