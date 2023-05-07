//------------------------------------------------------------------------------
//   Warning: This code was automatically generated.
//   Changes to this file may cause incorrect behavior
//   and will be lost when this file is regenerated.
//------------------------------------------------------------------------------
//
// |metacode:version=0.1|
// |metacode:generator_header|
using System;
using System.Linq;
using MetaFac.CG3.Generators;
namespace MetaFac.CG3.Generator.ProtobufNet3
{
    public partial class Generator : GeneratorBase
    {
        public Generator() : base("MetaFac.CG3.ProtobufNet3") { }
        protected override void OnGenerate(TemplateScope outerScope)
        {
// |metacode:generator_body|
Define("BooleanFieldType","Boolean");
Define("SByteFieldType","SByte");
Define("ByteFieldType","Byte");
Define("Int16FieldType","Int16");
Define("UInt16FieldType","UInt16");
Define("CharFieldType","Char");
Define("Int32FieldType","Int32");
Define("UInt32FieldType","UInt32");
Define("SingleFieldType","Single");
Define("Int64FieldType","Int64");
Define("UInt64FieldType","UInt64");
Define("DoubleFieldType","Double");
Define("DateTimeFieldType","DateTime");
Define("TimeSpanFieldType","TimeSpan");
Define("DateTimeZoneFieldType","DateTimeOffset");
Define("DecimalFieldType","Decimal");
Define("GuidFieldType","Guid");
Define("StringFieldType","String");
Define("BinaryFieldType","byte[]");
Define("ConcreteBoolean","T_BooleanFieldType_");
Define("ConcreteSByte","T_SByteFieldType_");
Define("ConcreteByte","T_ByteFieldType_");
Define("ConcreteInt16","T_Int16FieldType_");
Define("ConcreteUInt16","T_UInt16FieldType_");
Define("ConcreteChar","T_CharFieldType_");
Define("ConcreteInt32","T_Int32FieldType_");
Define("ConcreteUInt32","T_UInt32FieldType_");
Define("ConcreteSingle","T_SingleFieldType_");
Define("ConcreteInt64","T_Int64FieldType_");
Define("ConcreteUInt64","T_UInt64FieldType_");
Define("ConcreteDouble","T_DoubleFieldType_");
Define("ConcreteDateTime","T_DateTimeFieldType_");
Define("ConcreteTimeSpan","T_TimeSpanFieldType_");
Define("ConcreteDateTimeOffset","T_DateTimeZoneFieldType_");
Define("ConcreteDecimal","T_DecimalFieldType_");
Define("ConcreteGuid","T_GuidFieldType_");
Define("ConcreteString","T_StringFieldType_");
Define("ConcreteBinaryFieldType","T_BinaryFieldType_");
Define("ExternalBoolean","T_BooleanFieldType_");
Define("ExternalSByte","T_SByteFieldType_");
Define("ExternalByte","T_ByteFieldType_");
Define("ExternalInt16","T_Int16FieldType_");
Define("ExternalUInt16","T_UInt16FieldType_");
Define("ExternalChar","T_CharFieldType_");
Define("ExternalInt32","T_Int32FieldType_");
Define("ExternalUInt32","T_UInt32FieldType_");
Define("ExternalSingle","T_SingleFieldType_");
Define("ExternalInt64","T_Int64FieldType_");
Define("ExternalUInt64","T_UInt64FieldType_");
Define("ExternalDouble","T_DoubleFieldType_");
Define("ExternalDateTime","T_DateTimeFieldType_");
Define("ExternalTimeSpan","T_TimeSpanFieldType_");
Define("ExternalDateTimeOffset","T_DateTimeZoneFieldType_");
Define("ExternalDecimal","T_DecimalFieldType_");
Define("ExternalGuid","T_GuidFieldType_");
Define("ExternalString","T_StringFieldType_");
Define("ExternalBinaryFieldType","T_BinaryFieldType_");
Define("BinaryFieldType","byte[]");
Define("ConcreteDateTime","DateTimeData");
Define("ExternalDateTime","DateTime");
Define("ConcreteDateTimeOffset","DateTimeOffsetData");
Define("ExternalDateTimeOffset","DateTimeOffset");
Define("BaseClassName","object");
Emit("// <auto-generated />");
Emit("#region Auto-generated");
Emit("//--------------------------------------------------------------------------------");
Emit("// Warning: This file was automatically generated. Changes to this file may");
Emit("// cause incorrect behavior and will be lost when this file is regenerated.");
Emit("//");
Emit("// This file was generated using MetaFac.CG3 tools and user supplied metadata.");
Emit("//");
Emit("// To download and install the tool, the .NET CLI command is:");
Emit("// dotnet tool install --global MetaFac.CG3.CLI");
Emit("//");
Emit("// For more information about using this tool, the help command is:");
Emit("// mfcg3 g2c --help");
Emit("//--------------------------------------------------------------------------------");
Emit("#endregion");
Emit("#nullable enable");
Emit("using MetaFac.Memory;");
Emit("using MetaFac.CG3.Runtime;");
Emit("using MetaFac.CG3.Runtime.ProtobufNet3;");
Emit("using ProtoBuf;");
Emit("using System;");
Emit("using System.Collections.Generic;");
Emit("using System.Linq;");
Emit("using System.Runtime.CompilerServices;");
Emit("using T_Namespace_.Interfaces;");
Emit("");
Emit("namespace T_Namespace_.ProtobufNet3");
Emit("{");
    using (Ignored()) {
Emit("    using T_ConcreteOtherType_ = System.Int64;");
Emit("    using T_ExternalOtherType_ = System.Int64;");
Emit("    using T_IndexType_ = System.String;");
    }
Emit("");
    using (Ignored()) {
Emit("    [ProtoContract, CompatibilityLevel(CompatibilityLevel.Level300)]");
Emit("    public class T_ModelType_ : IT_ModelType_, IEquatable<T_ModelType_>");
Emit("    {");
Emit("        public static T_ModelType_? CreateFrom(IT_ModelType_? source)");
Emit("        {");
Emit("            if (source is null) return null;");
Emit("            return new T_ModelType_(source);");
Emit("        }");
Emit("");
Emit("        [ProtoMember(1)]");
Emit("        public int TestData { get; set; }");
Emit("");
Emit("        public T_ModelType_() { }");
Emit("        public T_ModelType_(IT_ModelType_? source)");
Emit("        {");
Emit("            if (source is null) throw new ArgumentNullException(nameof(source));");
Emit("            TestData = source.TestData;");
Emit("        }");
Emit("        public bool Equals(T_ModelType_? other)");
Emit("        {");
Emit("            if (ReferenceEquals(other, this)) return true;");
Emit("            if (other is null) return false;");
Emit("            return other.TestData == TestData;");
Emit("        }");
Emit("");
Emit("        public override bool Equals(object? obj)");
Emit("        {");
Emit("            return (obj is T_ModelType_ other) && Equals(other);");
Emit("        }");
Emit("");
Emit("        public override int GetHashCode()");
Emit("        {");
Emit("            return TestData.GetHashCode();");
Emit("        }");
Emit("    }");
Emit("");
Emit("    internal static class ConversionHelpers");
Emit("    {");
Emit("        public static T_ExternalOtherType_ ToExternal(this T_ConcreteOtherType_ value) => value;");
Emit("        public static T_ExternalOtherType_? ToExternal(this T_ConcreteOtherType_? value, int notUsed) => value;");
Emit("        public static T_ConcreteOtherType_ ToInternal(this T_ExternalOtherType_ value) => value;");
Emit("        public static T_ConcreteOtherType_? ToInternal(this T_ExternalOtherType_? value) => value;");
Emit("    }");
    }
Emit("");
    foreach (var cs in outerScope.Iterators["Classes"].Iterations) {
    using (NewScope(cs)) {
Emit("    [ProtoContract, CompatibilityLevel(CompatibilityLevel.Level300)]");
Emit("    //todo when we support polymorphism");
Emit("    //    foreach AllDerivedClasses");
Emit("    //    [ProtoInclude(1000 + ClassTags.T_ClassName_, typeof(T_ClassName_))]");
Emit("    //    endfor");
Emit("    public sealed partial class T_ClassName_ : IT_ClassName_, IEquatable<T_ClassName_>");
Emit("    {");
Emit("        [MethodImpl(MethodImplOptions.AggressiveInlining)]");
Emit("        public static T_ClassName_? CreateFrom(IT_ClassName_? source)");
Emit("        {");
Emit("            if (source is null) return null;");
Emit("            return new T_ClassName_(source);");
Emit("        }");
Emit("");
        using (Ignored()) {
Emit("        private const int T_ClassTag_ = 9000;");
Emit("        private const int T_FieldTag_ = 100;");
Emit("        private const DataFormat T_ProtobufDataFormat_ = DataFormat.Default;");
        }
Emit("        private const int ClassTag = T_ClassTag_;");
Emit("");
        foreach (var fs in cs.Iterators["Fields"].Iterations) {
          using (NewScope(fs)) {
            var fieldInfo = new FieldInfo(fs, _engine.Current);
            Define("ProtobufDataFormat", fieldInfo.IsSignedType? "DataFormat.ZigZag" : "DataFormat.Default");
Emit("        [ProtoMember(T_FieldTag_, DataFormat = T_ProtobufDataFormat_)]");
        using (Ignored()) {
Emit("        public int IgnoreThisField { get; set; }");
        }
        switch (fieldInfo.Kind)
        {
            case FieldKind.UnaryModel:
        using (Ignored()) {
Emit("        [ProtoMember(T_FieldTag_ + 1)]");
        }
Emit("        public T_ModelType_? T_UnaryModelFieldName_ { get; set; }");
            break; case FieldKind.ArrayModel:
        using (Ignored()) {
Emit("        [ProtoMember(T_FieldTag_ + 2)]");
        }
Emit("        public T_ModelType_?[]? T_ArrayModelFieldName_ { get; set; }");
            break; case FieldKind.IndexModel:
        using (Ignored()) {
Emit("        [ProtoMember(T_FieldTag_ + 3)]");
        }
Emit("        public Dictionary<T_IndexType_, T_ModelType_?>? T_IndexModelFieldName_ { get; set; }");
            break; case FieldKind.UnaryMaybe:
        using (Ignored()) {
Emit("        [ProtoMember(T_FieldTag_ + 4)]");
        }
Emit("        public T_ConcreteOtherType_? T_UnaryMaybeFieldName_ { get; set; }");
            break; case FieldKind.ArrayMaybe:
        using (Ignored()) {
Emit("        [ProtoMember(T_FieldTag_ + 5)]");
        }
Emit("        public T_ConcreteOtherType_?[]? T_ArrayMaybeFieldName_ { get; set; }");
            break; case FieldKind.IndexMaybe:
        using (Ignored()) {
Emit("        [ProtoMember(T_FieldTag_ + 6)]");
        }
Emit("        public Dictionary<T_IndexType_, T_ConcreteOtherType_?>? T_IndexMaybeFieldName_ { get; set; }");
            break; case FieldKind.UnaryOther:
        using (Ignored()) {
Emit("        [ProtoMember(T_FieldTag_ + 7)]");
        }
Emit("        public T_ConcreteOtherType_ T_UnaryOtherFieldName_ { get; set; }");
            break; case FieldKind.ArrayOther:
        using (Ignored()) {
Emit("        [ProtoMember(T_FieldTag_ + 8)]");
        }
Emit("        public T_ConcreteOtherType_[]? T_ArrayOtherFieldName_ { get; set; }");
            break; case FieldKind.IndexOther:
        using (Ignored()) {
Emit("        [ProtoMember(T_FieldTag_ + 9)]");
        }
Emit("        public Dictionary<T_IndexType_, T_ConcreteOtherType_>? T_IndexOtherFieldName_ { get; set; }");
            break; case FieldKind.UnaryBuffer:
        using (Ignored()) {
Emit("        [ProtoMember(T_FieldTag_ + 10)]");
        }
Emit("        public byte[]? T_UnaryBufferFieldName_ { get; set; }");
            break; case FieldKind.ArrayBuffer:
        using (Ignored()) {
Emit("        [ProtoMember(T_FieldTag_ + 11)]");
        }
Emit("        public byte[]?[]? T_ArrayBufferFieldName_ { get; set; }");
            break; case FieldKind.IndexBuffer:
        using (Ignored()) {
Emit("        [ProtoMember(T_FieldTag_ + 12)]");
        }
Emit("        public Dictionary<T_IndexType_, byte[]?>? T_IndexBufferFieldName_ { get; set; }");
            break; case FieldKind.UnaryString:
        using (Ignored()) {
Emit("        [ProtoMember(T_FieldTag_ + 13)]");
        }
Emit("        public String? T_UnaryStringFieldName_ { get; set; }");
            break; case FieldKind.ArrayString:
        using (Ignored()) {
Emit("        [ProtoMember(T_FieldTag_ + 14)]");
        }
Emit("        public String?[]? T_ArrayStringFieldName_ { get; set; }");
            break; case FieldKind.IndexString:
        using (Ignored()) {
Emit("        [ProtoMember(T_FieldTag_ + 15)]");
        }
Emit("        public Dictionary<T_IndexType_, String?>? T_IndexStringFieldName_ { get; set; }");
            break; default:
                throw new ArgumentOutOfRangeException("fieldInfo.Kind", fieldInfo.Kind, $"ordinal={(int)fieldInfo.Kind}");
        }
        }}
Emit("");
        foreach (var fs in cs.Iterators["Fields"].Iterations) {
          using (NewScope(fs)) {
            var fieldInfo = new FieldInfo(fs, _engine.Current);
        switch (fieldInfo.Kind)
        {
            case FieldKind.UnaryModel:
Emit("        IT_ModelType_? IT_ClassName_.T_UnaryModelFieldName_ => T_UnaryModelFieldName_;");
            break; case FieldKind.ArrayModel:
Emit("        IEnumerable<IT_ModelType_?>? IT_ClassName_.T_ArrayModelFieldName_ => T_ArrayModelFieldName_;");
            break; case FieldKind.IndexModel:
Emit("        IEnumerable<KeyValuePair<T_IndexType_, IT_ModelType_?>>? IT_ClassName_.T_IndexModelFieldName_ => T_IndexModelFieldName_");
Emit("            ?.Select(kvp => new KeyValuePair<T_IndexType_, IT_ModelType_?>(kvp.Key, kvp.Value));");
            break; case FieldKind.UnaryMaybe:
Emit("        T_ExternalOtherType_? IT_ClassName_.T_UnaryMaybeFieldName_ => T_UnaryMaybeFieldName_.ToExternal();");
            break; case FieldKind.ArrayMaybe:
Emit("        IEnumerable<T_ExternalOtherType_?>? IT_ClassName_.T_ArrayMaybeFieldName_ => T_ArrayMaybeFieldName_");
Emit("            ?.Select(x => x.ToExternal());");
            break; case FieldKind.IndexMaybe:
Emit("        IEnumerable<KeyValuePair<T_IndexType_, T_ExternalOtherType_?>>? IT_ClassName_.T_IndexMaybeFieldName_ => T_IndexMaybeFieldName_");
Emit("            ?.Select(kvp => new KeyValuePair<T_IndexType_, T_ExternalOtherType_?>(kvp.Key, kvp.Value.ToExternal()));");
            break; case FieldKind.UnaryOther:
Emit("        T_ExternalOtherType_ IT_ClassName_.T_UnaryOtherFieldName_ => T_UnaryOtherFieldName_.ToExternal();");
            break; case FieldKind.ArrayOther:
Emit("        IEnumerable<T_ExternalOtherType_>? IT_ClassName_.T_ArrayOtherFieldName_ => T_ArrayOtherFieldName_");
Emit("            ?.Select(x => x.ToExternal());");
            break; case FieldKind.IndexOther:
Emit("        IEnumerable<KeyValuePair<T_IndexType_, T_ExternalOtherType_>>? IT_ClassName_.T_IndexOtherFieldName_ => T_IndexOtherFieldName_");
Emit("            ?.Select(kvp => new KeyValuePair<T_IndexType_, T_ExternalOtherType_>(kvp.Key, kvp.Value.ToExternal()));");
            break; case FieldKind.UnaryBuffer:
Emit("        Octets? IT_ClassName_.T_UnaryBufferFieldName_ => T_UnaryBufferFieldName_ is null? null: Octets.UnsafeWrap(T_UnaryBufferFieldName_);");
            break; case FieldKind.ArrayBuffer:
Emit("        IEnumerable<Octets?>? IT_ClassName_.T_ArrayBufferFieldName_ => T_ArrayBufferFieldName_?.Select(b => b is null ? null : Octets.UnsafeWrap(b));");
            break; case FieldKind.IndexBuffer:
Emit("        IEnumerable<KeyValuePair<T_IndexType_, Octets?>>? IT_ClassName_.T_IndexBufferFieldName_ => T_IndexBufferFieldName_");
Emit("            ?.Select(kvp => new KeyValuePair<T_IndexType_, Octets?>(kvp.Key, kvp.Value is null ? null : Octets.UnsafeWrap(kvp.Value)));");
            break; case FieldKind.UnaryString:
Emit("        String? IT_ClassName_.T_UnaryStringFieldName_ => T_UnaryStringFieldName_;");
            break; case FieldKind.ArrayString:
Emit("        IEnumerable<String?>? IT_ClassName_.T_ArrayStringFieldName_ => T_ArrayStringFieldName_;");
            break; case FieldKind.IndexString:
Emit("        IEnumerable<KeyValuePair<T_IndexType_, String?>>? IT_ClassName_.T_IndexStringFieldName_ => T_IndexStringFieldName_");
Emit("            ?.Select(kvp => new KeyValuePair<T_IndexType_, String?>(kvp.Key, kvp.Value));");
            break; default: break;
        }
        }}
Emit("");
Emit("        [MethodImpl(MethodImplOptions.AggressiveInlining)]");
Emit("        public T_ClassName_()");
Emit("        {");
Emit("        }");
Emit("");
Emit("        [MethodImpl(MethodImplOptions.AggressiveInlining)]");
Emit("        public T_ClassName_(IT_ClassName_ source)");
Emit("        {");
Emit("            if (source is null) throw new ArgumentNullException(nameof(source));");
            foreach (var fs in cs.Iterators["Fields"].Iterations) {
              using (NewScope(fs)) {
                var fieldInfo = new FieldInfo(fs, _engine.Current);
            switch (fieldInfo.Kind)
            {
                case FieldKind.UnaryModel:
Emit("            T_UnaryModelFieldName_ = T_ModelType_.CreateFrom(source.T_UnaryModelFieldName_);");
                break; case FieldKind.ArrayModel:
Emit("            T_ArrayModelFieldName_ = source.T_ArrayModelFieldName_?.Select(x => T_ModelType_.CreateFrom(x)).ToArray();");
                break; case FieldKind.IndexModel:
Emit("            T_IndexModelFieldName_ = source.T_IndexModelFieldName_?.ToDictionary(kvp => kvp.Key, kvp => T_ModelType_.CreateFrom(kvp.Value));");
                break; case FieldKind.UnaryMaybe:
Emit("            T_UnaryMaybeFieldName_ = source.T_UnaryMaybeFieldName_.ToInternal();");
                break; case FieldKind.ArrayMaybe:
Emit("            T_ArrayMaybeFieldName_ = source.T_ArrayMaybeFieldName_?.Select(x => x.ToInternal()).ToArray();");
                break; case FieldKind.IndexMaybe:
Emit("            T_IndexMaybeFieldName_ = source.T_IndexMaybeFieldName_?.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.ToInternal());");
                break; case FieldKind.UnaryOther:
Emit("            T_UnaryOtherFieldName_ = source.T_UnaryOtherFieldName_.ToInternal();");
                break; case FieldKind.ArrayOther:
Emit("            T_ArrayOtherFieldName_ = source.T_ArrayOtherFieldName_?.Select(x => x.ToInternal()).ToArray();");
                break; case FieldKind.IndexOther:
Emit("            T_IndexOtherFieldName_ = source.T_IndexOtherFieldName_?.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.ToInternal());");
                break; case FieldKind.UnaryBuffer:
Emit("            T_UnaryBufferFieldName_ = source.T_UnaryBufferFieldName_?.Memory.ToArray();");
                break; case FieldKind.ArrayBuffer:
Emit("            T_ArrayBufferFieldName_ = source.T_ArrayBufferFieldName_?.Select(b => b?.Memory.ToArray()).ToArray();");
                break; case FieldKind.IndexBuffer:
Emit("            T_IndexBufferFieldName_ = source.T_IndexBufferFieldName_?.ToDictionary(kvp => kvp.Key, kvp => kvp.Value?.Memory.ToArray());");
                break; case FieldKind.UnaryString:
Emit("            T_UnaryStringFieldName_ = source.T_UnaryStringFieldName_;");
                break; case FieldKind.ArrayString:
Emit("            T_ArrayStringFieldName_ = source.T_ArrayStringFieldName_?.ToArray();");
                break; case FieldKind.IndexString:
Emit("            T_IndexStringFieldName_ = source.T_IndexStringFieldName_?.ToDictionary(kvp => kvp.Key, kvp => (String?)kvp.Value);");
                break; default: break;
            }
            }}
Emit("        }");
Emit("");
Emit("        [MethodImpl(MethodImplOptions.AggressiveInlining)]");
Emit("        public bool Equals(T_ClassName_? other)");
Emit("        {");
Emit("            if (other is null) return false;");
Emit("            if (ReferenceEquals(other, this)) return true;");
            foreach (var fs in cs.Iterators["Fields"].Iterations) {
              using (NewScope(fs)) {
                var fieldInfo = new FieldInfo(fs, _engine.Current);
            switch (fieldInfo.Kind)
            {
                case FieldKind.UnaryModel:
Emit("            if (!T_UnaryModelFieldName_.ValueEquals(other.T_UnaryModelFieldName_)) return false;");
                break; case FieldKind.ArrayModel:
Emit("            if (!T_ArrayModelFieldName_.ArrayEquals(other.T_ArrayModelFieldName_)) return false;");
                break; case FieldKind.IndexModel:
Emit("            if (!T_IndexModelFieldName_.IndexEquals(other.T_IndexModelFieldName_)) return false;");
                break; case FieldKind.UnaryMaybe:
Emit("            if (!T_UnaryMaybeFieldName_.ValueEquals(other.T_UnaryMaybeFieldName_)) return false;");
                break; case FieldKind.ArrayMaybe:
Emit("            if (!T_ArrayMaybeFieldName_.ArrayEquals(other.T_ArrayMaybeFieldName_)) return false;");
                break; case FieldKind.IndexMaybe:
Emit("            if (!T_IndexMaybeFieldName_.IndexEquals(other.T_IndexMaybeFieldName_)) return false;");
                break; case FieldKind.UnaryOther:
Emit("            if (!T_UnaryOtherFieldName_.ValueEquals(other.T_UnaryOtherFieldName_)) return false;");
                break; case FieldKind.ArrayOther:
Emit("            if (!T_ArrayOtherFieldName_.ArrayEquals(other.T_ArrayOtherFieldName_)) return false;");
                break; case FieldKind.IndexOther:
Emit("            if (!T_IndexOtherFieldName_.IndexEquals(other.T_IndexOtherFieldName_)) return false;");
                break; case FieldKind.UnaryBuffer:
Emit("            if (!T_UnaryBufferFieldName_.ValueEquals(other.T_UnaryBufferFieldName_)) return false;");
                break; case FieldKind.ArrayBuffer:
Emit("            if (!T_ArrayBufferFieldName_.ArrayEquals(other.T_ArrayBufferFieldName_)) return false;");
                break; case FieldKind.IndexBuffer:
Emit("            if (!T_IndexBufferFieldName_.IndexEquals(other.T_IndexBufferFieldName_)) return false;");
                break; case FieldKind.UnaryString:
Emit("            if (!T_UnaryStringFieldName_.ValueEquals(other.T_UnaryStringFieldName_)) return false;");
                break; case FieldKind.ArrayString:
Emit("            if (!T_ArrayStringFieldName_.ArrayEquals(other.T_ArrayStringFieldName_)) return false;");
                break; case FieldKind.IndexString:
Emit("            if (!T_IndexStringFieldName_.IndexEquals(other.T_IndexStringFieldName_)) return false;");
                break; default: break;
            }
            }}
Emit("            return true;");
Emit("        }");
Emit("");
Emit("        [MethodImpl(MethodImplOptions.AggressiveInlining)]");
Emit("        public static bool operator ==(T_ClassName_ left, T_ClassName_ right)");
Emit("        {");
Emit("            if (left is null) return (right is null);");
Emit("            return left.Equals(right);");
Emit("        }");
Emit("");
Emit("        [MethodImpl(MethodImplOptions.AggressiveInlining)]");
Emit("        public static bool operator !=(T_ClassName_ left, T_ClassName_ right)");
Emit("        {");
Emit("            if (left is null) return !(right is null);");
Emit("            return !left.Equals(right);");
Emit("        }");
Emit("");
Emit("        [MethodImpl(MethodImplOptions.AggressiveInlining)]");
Emit("        public override bool Equals(object? obj)");
Emit("        {");
Emit("            return obj is T_ClassName_ other && Equals(other);");
Emit("        }");
Emit("");
Emit("        public override int GetHashCode()");
Emit("        {");
Emit("            int hash = 0;");
Emit("            unchecked");
Emit("            {");
                foreach (var fs in cs.Iterators["Fields"].Iterations) {
                  using (NewScope(fs)) {
                    var fieldInfo = new FieldInfo(fs, _engine.Current);
                switch (fieldInfo.Kind)
                {
                    case FieldKind.UnaryModel:
Emit("                hash = (hash * 397) ^ T_UnaryModelFieldName_.CalcHashUnary();");
                    break; case FieldKind.ArrayModel:
Emit("                hash = (hash * 397) ^ T_ArrayModelFieldName_.CalcHashArray();");
                    break; case FieldKind.IndexModel:
Emit("                hash = (hash * 397) ^ T_IndexModelFieldName_.CalcHashIndex();");
                    break; case FieldKind.UnaryMaybe:
Emit("                hash = (hash * 397) ^ T_UnaryMaybeFieldName_.CalcHashUnary();");
                    break; case FieldKind.ArrayMaybe:
Emit("                hash = (hash * 397) ^ T_ArrayMaybeFieldName_.CalcHashArray();");
                    break; case FieldKind.IndexMaybe:
Emit("                hash = (hash * 397) ^ T_IndexMaybeFieldName_.CalcHashIndex();");
                    break; case FieldKind.UnaryOther:
Emit("                hash = (hash * 397) ^ T_UnaryOtherFieldName_.CalcHashUnary();");
                    break; case FieldKind.ArrayOther:
Emit("                hash = (hash * 397) ^ T_ArrayOtherFieldName_.CalcHashArray();");
                    break; case FieldKind.IndexOther:
Emit("                hash = (hash * 397) ^ T_IndexOtherFieldName_.CalcHashIndex();");
                    break; case FieldKind.UnaryBuffer:
Emit("                hash = (hash * 397) ^ T_UnaryBufferFieldName_.CalcHashUnary();");
                    break; case FieldKind.ArrayBuffer:
Emit("                hash = (hash * 397) ^ T_ArrayBufferFieldName_.CalcHashArray();");
                    break; case FieldKind.IndexBuffer:
Emit("                hash = (hash * 397) ^ T_IndexBufferFieldName_.CalcHashIndex();");
                    break; case FieldKind.UnaryString:
Emit("                hash = (hash * 397) ^ T_UnaryStringFieldName_.CalcHashUnary();");
                    break; case FieldKind.ArrayString:
Emit("                hash = (hash * 397) ^ T_ArrayStringFieldName_.CalcHashArray();");
                    break; case FieldKind.IndexString:
Emit("                hash = (hash * 397) ^ T_IndexStringFieldName_.CalcHashIndex();");
                    break; default: break;
                }
                }}
Emit("            }");
Emit("            return hash;");
Emit("        }");
Emit("");
Emit("    }");
Emit("");
    }}
Emit("");
Emit("}");
// |metacode:generator_footer|
        }
    }
}
// |metacode:generator_end|
