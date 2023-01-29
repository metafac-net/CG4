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

namespace MetaCode.TS3.Generator.Freezables
{
    public partial class Generator : GeneratorBase
    {
        public Generator() : base("MetaCode.TS3.Freezables") { }
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
Define("BinaryFieldType","Octets");
Define("BaseClassName","FreezableBase");
Emit("#region Auto-generated");
Emit("//");
Emit("// Warning: This code was automatically generated. Changes to this file may");
Emit("// cause incorrect behavior and will be lost when this file is regenerated.");
Emit("//");
Emit("// This file was generated by the MetaFac.CG3.CLI tool (or mfcg3)");
Emit("// using a MetaFac generator and modified according to supplied model(s).");
Emit("//");
Emit("// Generator: T_GeneratorId_ T_GeneratorVersion_");
Emit("// Metadata : T_MetadataSource_ T_MetadataVersion_");
Emit("//");
Emit("// For more information about using this tool, the help command is:");
Emit("// mcts3 g2c --help");
Emit("//");
Emit("// To download and install the tool, the .NET CLI command is:");
Emit("// dotnet tool install --global MetaFac.CG3.CLI");
Emit("//");
Emit("//--------------------------------------------------------------------------------");
Emit("#endregion");
Emit("#nullable enable");
Emit("using MetaFac.Collections.Freezables;");
Emit("using MetaFac.Mutability;");
Emit("using MetaFac.Memory;");
Emit("using MetaFac.CG3.Runtime;");
Emit("using System;");
Emit("using System.Collections.Generic;");
Emit("using System.Linq;");
Emit("using System.Runtime.CompilerServices;");
Emit("using T_Namespace_.Interfaces;");
Emit("");
Emit("namespace T_Namespace_.Freezables");
Emit("{");
    using (Ignored()) {
Emit("    using T_ExternalOtherType_ = System.Int64;");
Emit("    using T_IndexType_ = System.String;");
    }
Emit("");
    using (Ignored()) {
Emit("    public class T_ModelType_ : FreezableBase, IT_ModelType_, IEquatable<T_ModelType_>");
Emit("    {");
Emit("        public static T_ModelType_? CreateFrom(IT_ModelType_? source)");
Emit("        {");
Emit("            if (source is null) return null;");
Emit("            if (source is T_ModelType_ concrete && concrete.IsFrozen()) return concrete;");
Emit("            return new T_ModelType_(source);");
Emit("        }");
Emit("");
Emit("        public int TestData { get; }");
Emit("");
Emit("        public T_ModelType_() { }");
Emit("        public T_ModelType_(int testData)");
Emit("        {");
Emit("            TestData = testData;");
Emit("        }");
Emit("        public T_ModelType_(IT_ModelType_ source)");
Emit("        {");
Emit("            if (source is null) throw new ArgumentNullException(nameof(source));");
Emit("            TestData = source.TestData;");
Emit("        }");
Emit("");
Emit("        public bool Equals(T_ModelType_? other)");
Emit("        {");
Emit("            if (other is null) return false;");
Emit("            if (ReferenceEquals(other, this)) return true;");
Emit("            if (this.TestData != other.TestData) return false;");
Emit("            return base.Equals(other);");
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
    }
Emit("");
    foreach (var cs in outerScope.Iterators["Classes"].Iterations) {
    using (NewScope(cs)) {
Emit("    public sealed partial class T_ClassName_ : FreezableBase, IT_ClassName_, ICopyFrom<T_ClassName_>, IEquatable<T_ClassName_>");
Emit("    {");
Emit("        [MethodImpl(MethodImplOptions.NoInlining)]");
Emit("        private static void ThrowIsReadonly(string verb, [CallerMemberName] string? method = null)");
Emit("        {");
Emit("            throw new InvalidOperationException($\"Cannot {verb} '{method}' when read-only\");");
Emit("        }");
Emit("");
Emit("        [MethodImpl(MethodImplOptions.AggressiveInlining)]");
Emit("        public static T_ClassName_? CreateFrom(IT_ClassName_? source)");
Emit("        {");
Emit("            if (source is null) return null;");
Emit("            if (source is T_ClassName_ thisClass && thisClass.IsFrozen()) return thisClass;");
Emit("            return new T_ClassName_(source);");
Emit("        }");
Emit("");
Emit("        private static T_ClassName_ CreateEmpty()");
Emit("        {");
Emit("            var result = new T_ClassName_();");
Emit("            result.Freeze();");
Emit("            return result;");
Emit("        }");
Emit("#pragma warning disable 109");
Emit("        public new static readonly T_ClassName_ Empty = CreateEmpty();");
Emit("#pragma warning restore 109");
Emit("");
        using (Ignored()) {
Emit("        private const int T_ClassTag_ = 99;");
        }
Emit("        private const int ClassTag = T_ClassTag_;");
Emit("");
Emit("        [MethodImpl(MethodImplOptions.AggressiveInlining)]");
Emit("        private ref T CheckNotFrozen<T>(ref T value)");
Emit("        {");
Emit("            if (IsFrozen()) ThrowIsReadonly(\"set\");");
Emit("            return ref value;");
Emit("        }");
Emit("");
        foreach (var fs in cs.Iterators["Fields"].Iterations) {
          using (NewScope(fs)) {
            var fieldInfo = new FieldInfo(fs, _engine.Current);
        switch (fieldInfo.Kind)
        {
            case FieldKind.UnaryModel:
Emit("        private T_ModelType_? field_T_UnaryModelFieldName_;");
Emit("        public T_ModelType_? T_UnaryModelFieldName_");
Emit("        {");
Emit("            get => field_T_UnaryModelFieldName_;");
Emit("            set => field_T_UnaryModelFieldName_ = CheckNotFrozen(ref value);");
Emit("        }");
            break; case FieldKind.ArrayModel:
Emit("        private FreezableArray<T_ModelType_?>? field_T_ArrayModelFieldName_;");
Emit("        public FreezableArray<T_ModelType_?>? T_ArrayModelFieldName_");
Emit("        {");
Emit("            get => field_T_ArrayModelFieldName_;");
Emit("            set => field_T_ArrayModelFieldName_ = CheckNotFrozen(ref value);");
Emit("        }");
            break; case FieldKind.IndexModel:
Emit("        private FreezableHashedDictionary<T_IndexType_, T_ModelType_?>? field_T_IndexModelFieldName_;");
Emit("        public FreezableHashedDictionary<T_IndexType_, T_ModelType_?>? T_IndexModelFieldName_");
Emit("        {");
Emit("            get => field_T_IndexModelFieldName_;");
Emit("            set => field_T_IndexModelFieldName_ = CheckNotFrozen(ref value);");
Emit("        }");
            break; case FieldKind.UnaryMaybe:
Emit("        private T_ExternalOtherType_? field_T_UnaryMaybeFieldName_;");
Emit("        public T_ExternalOtherType_? T_UnaryMaybeFieldName_");
Emit("        {");
Emit("            get => field_T_UnaryMaybeFieldName_;");
Emit("            set => field_T_UnaryMaybeFieldName_ = CheckNotFrozen(ref value);");
Emit("        }");
            break; case FieldKind.ArrayMaybe:
Emit("        private FreezableArray<T_ExternalOtherType_?>? field_T_ArrayMaybeFieldName_;");
Emit("        public FreezableArray<T_ExternalOtherType_?>? T_ArrayMaybeFieldName_");
Emit("        {");
Emit("            get => field_T_ArrayMaybeFieldName_;");
Emit("            set => field_T_ArrayMaybeFieldName_ = CheckNotFrozen(ref value);");
Emit("        }");
            break; case FieldKind.IndexMaybe:
Emit("        private FreezableHashedDictionary<T_IndexType_, T_ExternalOtherType_?>? field_T_IndexMaybeFieldName_;");
Emit("        public FreezableHashedDictionary<T_IndexType_, T_ExternalOtherType_?>? T_IndexMaybeFieldName_");
Emit("        {");
Emit("            get => field_T_IndexMaybeFieldName_;");
Emit("            set => field_T_IndexMaybeFieldName_ = CheckNotFrozen(ref value);");
Emit("        }");
            break; case FieldKind.UnaryOther:
Emit("        private T_ExternalOtherType_ field_T_UnaryOtherFieldName_;");
Emit("        public T_ExternalOtherType_ T_UnaryOtherFieldName_");
Emit("        {");
Emit("            get => field_T_UnaryOtherFieldName_;");
Emit("            set => field_T_UnaryOtherFieldName_ = CheckNotFrozen(ref value);");
Emit("        }");
            break; case FieldKind.ArrayOther:
Emit("        private FreezableArray<T_ExternalOtherType_>? field_T_ArrayOtherFieldName_;");
Emit("        public FreezableArray<T_ExternalOtherType_>? T_ArrayOtherFieldName_");
Emit("        {");
Emit("            get => field_T_ArrayOtherFieldName_;");
Emit("            set => field_T_ArrayOtherFieldName_ = CheckNotFrozen(ref value);");
Emit("        }");
            break; case FieldKind.IndexOther:
Emit("        private FreezableHashedDictionary<T_IndexType_, T_ExternalOtherType_>? field_T_IndexOtherFieldName_;");
Emit("        public FreezableHashedDictionary<T_IndexType_, T_ExternalOtherType_>? T_IndexOtherFieldName_");
Emit("        {");
Emit("            get => field_T_IndexOtherFieldName_;");
Emit("            set => field_T_IndexOtherFieldName_ = CheckNotFrozen(ref value);");
Emit("        }");
            break; case FieldKind.UnaryBuffer:
Emit("        private Octets? field_T_UnaryBufferFieldName_;");
Emit("        public Octets? T_UnaryBufferFieldName_");
Emit("        {");
Emit("            get => field_T_UnaryBufferFieldName_;");
Emit("            set => field_T_UnaryBufferFieldName_ = CheckNotFrozen(ref value);");
Emit("        }");
            break; case FieldKind.ArrayBuffer:
Emit("        private FreezableArray<Octets?>? field_T_ArrayBufferFieldName_;");
Emit("        public FreezableArray<Octets?>? T_ArrayBufferFieldName_");
Emit("        {");
Emit("            get => field_T_ArrayBufferFieldName_;");
Emit("            set => field_T_ArrayBufferFieldName_ = CheckNotFrozen(ref value);");
Emit("        }");
            break; case FieldKind.IndexBuffer:
Emit("        private FreezableHashedDictionary<T_IndexType_, Octets?>? field_T_IndexBufferFieldName_;");
Emit("        public FreezableHashedDictionary<T_IndexType_, Octets?>? T_IndexBufferFieldName_");
Emit("        {");
Emit("            get => field_T_IndexBufferFieldName_;");
Emit("            set => field_T_IndexBufferFieldName_ = CheckNotFrozen(ref value);");
Emit("        }");
            break; case FieldKind.UnaryString:
Emit("        private String? field_T_UnaryStringFieldName_;");
Emit("        public String? T_UnaryStringFieldName_");
Emit("        {");
Emit("            get => field_T_UnaryStringFieldName_;");
Emit("            set => field_T_UnaryStringFieldName_ = CheckNotFrozen(ref value);");
Emit("        }");
            break; case FieldKind.ArrayString:
Emit("        private FreezableArray<String?>? field_T_ArrayStringFieldName_;");
Emit("        public FreezableArray<String?>? T_ArrayStringFieldName_");
Emit("        {");
Emit("            get => field_T_ArrayStringFieldName_;");
Emit("            set => field_T_ArrayStringFieldName_ = CheckNotFrozen(ref value);");
Emit("        }");
            break; case FieldKind.IndexString:
Emit("        private FreezableHashedDictionary<T_IndexType_, String?>? field_T_IndexStringFieldName_;");
Emit("        public FreezableHashedDictionary<T_IndexType_, String?>? T_IndexStringFieldName_");
Emit("        {");
Emit("            get => field_T_IndexStringFieldName_;");
Emit("            set => field_T_IndexStringFieldName_ = CheckNotFrozen(ref value);");
Emit("        }");
            break; default: break;
        }
        }}
Emit("");
Emit("");
        foreach (var fs in cs.Iterators["Fields"].Iterations) {
          using (NewScope(fs)) {
            var fieldInfo = new FieldInfo(fs, _engine.Current);
        switch (fieldInfo.Kind)
        {
            case FieldKind.UnaryModel:
Emit("        IT_ModelType_? IT_ClassName_.T_UnaryModelFieldName_ => field_T_UnaryModelFieldName_;");
            break; case FieldKind.ArrayModel:
Emit("        IEnumerable<IT_ModelType_?>? IT_ClassName_.T_ArrayModelFieldName_ => field_T_ArrayModelFieldName_;");
            break; case FieldKind.IndexModel:
Emit("        IEnumerable<KeyValuePair<T_IndexType_, IT_ModelType_?>>? IT_ClassName_.T_IndexModelFieldName_ => field_T_IndexModelFieldName_?");
Emit("            .Select(kvp => new KeyValuePair<T_IndexType_, IT_ModelType_?>(kvp.Key, kvp.Value));");
            break; case FieldKind.UnaryMaybe:
Emit("        T_ExternalOtherType_? IT_ClassName_.T_UnaryMaybeFieldName_ => field_T_UnaryMaybeFieldName_;");
            break; case FieldKind.ArrayMaybe:
Emit("        IEnumerable<T_ExternalOtherType_?>? IT_ClassName_.T_ArrayMaybeFieldName_ => field_T_ArrayMaybeFieldName_;");
            break; case FieldKind.IndexMaybe:
Emit("        IEnumerable<KeyValuePair<T_IndexType_, T_ExternalOtherType_?>>? IT_ClassName_.T_IndexMaybeFieldName_ => field_T_IndexMaybeFieldName_;");
            break; case FieldKind.UnaryOther:
Emit("        T_ExternalOtherType_ IT_ClassName_.T_UnaryOtherFieldName_ => field_T_UnaryOtherFieldName_;");
            break; case FieldKind.ArrayOther:
Emit("        IEnumerable<T_ExternalOtherType_>? IT_ClassName_.T_ArrayOtherFieldName_ => field_T_ArrayOtherFieldName_;");
            break; case FieldKind.IndexOther:
Emit("        IEnumerable<KeyValuePair<T_IndexType_, T_ExternalOtherType_>>? IT_ClassName_.T_IndexOtherFieldName_ => field_T_IndexOtherFieldName_;");
            break; case FieldKind.UnaryBuffer:
Emit("        Octets? IT_ClassName_.T_UnaryBufferFieldName_ => field_T_UnaryBufferFieldName_;");
            break; case FieldKind.ArrayBuffer:
Emit("        IEnumerable<Octets?>? IT_ClassName_.T_ArrayBufferFieldName_ => field_T_ArrayBufferFieldName_;");
            break; case FieldKind.IndexBuffer:
Emit("        IEnumerable<KeyValuePair<T_IndexType_, Octets?>>? IT_ClassName_.T_IndexBufferFieldName_ => field_T_IndexBufferFieldName_;");
            break; case FieldKind.UnaryString:
Emit("        String? IT_ClassName_.T_UnaryStringFieldName_ => field_T_UnaryStringFieldName_;");
            break; case FieldKind.ArrayString:
Emit("        IEnumerable<String?>? IT_ClassName_.T_ArrayStringFieldName_ => field_T_ArrayStringFieldName_;");
            break; case FieldKind.IndexString:
Emit("        IEnumerable<KeyValuePair<T_IndexType_, String?>>? IT_ClassName_.T_IndexStringFieldName_ => field_T_IndexStringFieldName_;");
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
Emit("        public T_ClassName_(T_ClassName_ source) : base(source)");
Emit("        {");
Emit("            if (source is null) throw new ArgumentNullException(nameof(source));");
Emit("");
            foreach (var fs in cs.Iterators["Fields"].Iterations) {
              using (NewScope(fs)) {
                var fieldInfo = new FieldInfo(fs, _engine.Current);
            switch (fieldInfo.Kind)
            {
                case FieldKind.UnaryModel:
Emit("            field_T_UnaryModelFieldName_ = source.field_T_UnaryModelFieldName_;");
                break; case FieldKind.ArrayModel:
Emit("            field_T_ArrayModelFieldName_ = source.field_T_ArrayModelFieldName_;");
                break; case FieldKind.IndexModel:
Emit("            field_T_IndexModelFieldName_ = source.field_T_IndexModelFieldName_;");
                break; case FieldKind.UnaryMaybe:
Emit("            field_T_UnaryMaybeFieldName_ = source.field_T_UnaryMaybeFieldName_;");
                break; case FieldKind.ArrayMaybe:
Emit("            field_T_ArrayMaybeFieldName_ = source.field_T_ArrayMaybeFieldName_;");
                break; case FieldKind.IndexMaybe:
Emit("            field_T_IndexMaybeFieldName_ = source.field_T_IndexMaybeFieldName_;");
                break; case FieldKind.UnaryOther:
Emit("            field_T_UnaryOtherFieldName_ = source.field_T_UnaryOtherFieldName_;");
                break; case FieldKind.ArrayOther:
Emit("            field_T_ArrayOtherFieldName_ = source.field_T_ArrayOtherFieldName_;");
                break; case FieldKind.IndexOther:
Emit("            field_T_IndexOtherFieldName_ = source.field_T_IndexOtherFieldName_;");
                break; case FieldKind.UnaryBuffer:
Emit("            field_T_UnaryBufferFieldName_ = source.field_T_UnaryBufferFieldName_;");
                break; case FieldKind.ArrayBuffer:
Emit("            field_T_ArrayBufferFieldName_ = source.field_T_ArrayBufferFieldName_;");
                break; case FieldKind.IndexBuffer:
Emit("            field_T_IndexBufferFieldName_ = source.field_T_IndexBufferFieldName_;");
                break; case FieldKind.UnaryString:
Emit("            field_T_UnaryStringFieldName_ = source.field_T_UnaryStringFieldName_;");
                break; case FieldKind.ArrayString:
Emit("            field_T_ArrayStringFieldName_ = source.field_T_ArrayStringFieldName_;");
                break; case FieldKind.IndexString:
Emit("            field_T_IndexStringFieldName_ = source.field_T_IndexStringFieldName_;");
                break; default: break;
            }
            }}
Emit("        }");
Emit("");
Emit("        [MethodImpl(MethodImplOptions.AggressiveInlining)]");
Emit("        public T_ClassName_(IT_ClassName_ source)");
Emit("        {");
Emit("            if (source is null) throw new ArgumentNullException(nameof(source));");
Emit("");
            foreach (var fs in cs.Iterators["Fields"].Iterations) {
              using (NewScope(fs)) {
                var fieldInfo = new FieldInfo(fs, _engine.Current);
            switch (fieldInfo.Kind)
            {
                case FieldKind.UnaryModel:
Emit("            field_T_UnaryModelFieldName_ = T_ModelType_.CreateFrom(source.T_UnaryModelFieldName_);");
                break; case FieldKind.ArrayModel:
Emit("            field_T_ArrayModelFieldName_ = FreezableArray<T_ModelType_?>.CreateFrom(source.T_ArrayModelFieldName_?.Select(x => T_ModelType_.CreateFrom(x)));");
                break; case FieldKind.IndexModel:
Emit("            field_T_IndexModelFieldName_ = FreezableHashedDictionary<T_IndexType_, T_ModelType_?>.CreateFrom(");
Emit("                source.T_IndexModelFieldName_?.Select(x => new KeyValuePair<T_IndexType_, T_ModelType_?>(x.Key, T_ModelType_.CreateFrom(x.Value))));");
                break; case FieldKind.UnaryMaybe:
Emit("            field_T_UnaryMaybeFieldName_ = source.T_UnaryMaybeFieldName_;");
                break; case FieldKind.ArrayMaybe:
Emit("            field_T_ArrayMaybeFieldName_ = FreezableArray<T_ExternalOtherType_?>.CreateFrom(source.T_ArrayMaybeFieldName_);");
                break; case FieldKind.IndexMaybe:
Emit("            field_T_IndexMaybeFieldName_ = FreezableHashedDictionary<T_IndexType_, T_ExternalOtherType_?>.CreateFrom(source.T_IndexMaybeFieldName_);");
                break; case FieldKind.UnaryOther:
Emit("            field_T_UnaryOtherFieldName_ = source.T_UnaryOtherFieldName_;");
                break; case FieldKind.ArrayOther:
Emit("            field_T_ArrayOtherFieldName_ = FreezableArray<T_ExternalOtherType_>.CreateFrom(source.T_ArrayOtherFieldName_);");
                break; case FieldKind.IndexOther:
Emit("            field_T_IndexOtherFieldName_ = FreezableHashedDictionary<T_IndexType_, T_ExternalOtherType_>.CreateFrom(source.T_IndexOtherFieldName_);");
                break; case FieldKind.UnaryBuffer:
Emit("            field_T_UnaryBufferFieldName_ = source.T_UnaryBufferFieldName_;");
                break; case FieldKind.ArrayBuffer:
Emit("            field_T_ArrayBufferFieldName_ = FreezableArray<Octets?>.CreateFrom(source.T_ArrayBufferFieldName_);");
                break; case FieldKind.IndexBuffer:
Emit("            field_T_IndexBufferFieldName_ = FreezableHashedDictionary<T_IndexType_, Octets?>.CreateFrom(source.T_IndexBufferFieldName_);");
                break; case FieldKind.UnaryString:
Emit("            field_T_UnaryStringFieldName_ = source.T_UnaryStringFieldName_;");
                break; case FieldKind.ArrayString:
Emit("            field_T_ArrayStringFieldName_ = FreezableArray<String?>.CreateFrom(source.T_ArrayStringFieldName_);");
                break; case FieldKind.IndexString:
Emit("            field_T_IndexStringFieldName_ = FreezableHashedDictionary<T_IndexType_, String?>.CreateFrom(source.T_IndexStringFieldName_);");
                break; default: break;
            }
            }}
Emit("        }");
Emit("");
Emit("        [MethodImpl(MethodImplOptions.AggressiveInlining)]");
Emit("        public void CopyFrom(T_ClassName_? source)");
Emit("        {");
Emit("            if (IsFrozen()) ThrowIsReadonly(\"call\");");
Emit("            if (source is null) return;");
Emit("            base.CopyFrom(source);");
Emit("");
            foreach (var fs in cs.Iterators["Fields"].Iterations) {
              using (NewScope(fs)) {
                var fieldInfo = new FieldInfo(fs, _engine.Current);
            switch (fieldInfo.Kind)
            {
                case FieldKind.UnaryModel:
Emit("            field_T_UnaryModelFieldName_ = source.field_T_UnaryModelFieldName_;");
                break; case FieldKind.ArrayModel:
Emit("            field_T_ArrayModelFieldName_ = source.field_T_ArrayModelFieldName_;");
                break; case FieldKind.IndexModel:
Emit("            field_T_IndexModelFieldName_ = source.field_T_IndexModelFieldName_;");
                break; case FieldKind.UnaryMaybe:
Emit("            field_T_UnaryMaybeFieldName_ = source.field_T_UnaryMaybeFieldName_;");
                break; case FieldKind.ArrayMaybe:
Emit("            field_T_ArrayMaybeFieldName_ = source.field_T_ArrayMaybeFieldName_;");
                break; case FieldKind.IndexMaybe:
Emit("            field_T_IndexMaybeFieldName_ = source.field_T_IndexMaybeFieldName_;");
                break; case FieldKind.UnaryOther:
Emit("            field_T_UnaryOtherFieldName_ = source.field_T_UnaryOtherFieldName_;");
                break; case FieldKind.ArrayOther:
Emit("            field_T_ArrayOtherFieldName_ = source.field_T_ArrayOtherFieldName_;");
                break; case FieldKind.IndexOther:
Emit("            field_T_IndexOtherFieldName_ = source.field_T_IndexOtherFieldName_;");
                break; case FieldKind.UnaryBuffer:
Emit("            field_T_UnaryBufferFieldName_ = source.field_T_UnaryBufferFieldName_;");
                break; case FieldKind.ArrayBuffer:
Emit("            field_T_ArrayBufferFieldName_ = source.field_T_ArrayBufferFieldName_;");
                break; case FieldKind.IndexBuffer:
Emit("            field_T_IndexBufferFieldName_ = source.field_T_IndexBufferFieldName_;");
                break; case FieldKind.UnaryString:
Emit("            field_T_UnaryStringFieldName_ = source.field_T_UnaryStringFieldName_;");
                break; case FieldKind.ArrayString:
Emit("            field_T_ArrayStringFieldName_ = source.field_T_ArrayStringFieldName_;");
                break; case FieldKind.IndexString:
Emit("            field_T_IndexStringFieldName_ = source.field_T_IndexStringFieldName_;");
                break; default: break;
            }
            }}
Emit("        }");
Emit("");
Emit("        protected override void OnFreeze()");
Emit("        {");
            foreach (var fs in cs.Iterators["Fields"].Iterations) {
              using (NewScope(fs)) {
                var fieldInfo = new FieldInfo(fs, _engine.Current);
            switch (fieldInfo.Kind)
            {
                case FieldKind.UnaryModel:
Emit("            field_T_UnaryModelFieldName_?.Freeze();");
                break; case FieldKind.ArrayModel:
Emit("            field_T_ArrayModelFieldName_?.Freeze();");
                break; case FieldKind.IndexModel:
Emit("            field_T_IndexModelFieldName_?.Freeze();");
                break; case FieldKind.UnaryMaybe:
                break; case FieldKind.ArrayMaybe:
Emit("            field_T_ArrayMaybeFieldName_?.Freeze();");
                break; case FieldKind.IndexMaybe:
Emit("            field_T_IndexMaybeFieldName_?.Freeze();");
                break; case FieldKind.UnaryOther:
                break; case FieldKind.ArrayOther:
Emit("            field_T_ArrayOtherFieldName_?.Freeze();");
                break; case FieldKind.IndexOther:
Emit("            field_T_IndexOtherFieldName_?.Freeze();");
                break; case FieldKind.UnaryBuffer:
                break; case FieldKind.ArrayBuffer:
Emit("            field_T_ArrayBufferFieldName_?.Freeze();");
                break; case FieldKind.IndexBuffer:
Emit("            field_T_IndexBufferFieldName_?.Freeze();");
                break; case FieldKind.UnaryString:
                break; case FieldKind.ArrayString:
Emit("            field_T_ArrayStringFieldName_?.Freeze();");
                break; case FieldKind.IndexString:
Emit("            field_T_IndexStringFieldName_?.Freeze();");
                break; default: break;
            }
            }}
Emit("            base.OnFreeze();");
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
Emit("            if (!field_T_UnaryModelFieldName_.ValueEquals(other.field_T_UnaryModelFieldName_)) return false;");
                break; case FieldKind.ArrayModel:
Emit("            if (!field_T_ArrayModelFieldName_.ArrayEquals(other.field_T_ArrayModelFieldName_)) return false;");
                break; case FieldKind.IndexModel:
Emit("            if (!field_T_IndexModelFieldName_.IndexEquals(other.field_T_IndexModelFieldName_)) return false;");
                break; case FieldKind.UnaryMaybe:
Emit("            if (!field_T_UnaryMaybeFieldName_.ValueEquals(other.field_T_UnaryMaybeFieldName_)) return false;");
                break; case FieldKind.ArrayMaybe:
Emit("            if (!field_T_ArrayMaybeFieldName_.ArrayEquals(other.field_T_ArrayMaybeFieldName_)) return false;");
                break; case FieldKind.IndexMaybe:
Emit("            if (!field_T_IndexMaybeFieldName_.IndexEquals(other.field_T_IndexMaybeFieldName_)) return false;");
                break; case FieldKind.UnaryOther:
Emit("            if (!field_T_UnaryOtherFieldName_.ValueEquals(other.field_T_UnaryOtherFieldName_)) return false;");
                break; case FieldKind.ArrayOther:
Emit("            if (!field_T_ArrayOtherFieldName_.ArrayEquals(other.field_T_ArrayOtherFieldName_)) return false;");
                break; case FieldKind.IndexOther:
Emit("            if (!field_T_IndexOtherFieldName_.IndexEquals(other.field_T_IndexOtherFieldName_)) return false;");
                break; case FieldKind.UnaryBuffer:
Emit("            if (!field_T_UnaryBufferFieldName_.ValueEquals(other.field_T_UnaryBufferFieldName_)) return false;");
                break; case FieldKind.ArrayBuffer:
Emit("            if (!field_T_ArrayBufferFieldName_.ArrayEquals(other.field_T_ArrayBufferFieldName_)) return false;");
                break; case FieldKind.IndexBuffer:
Emit("            if (!field_T_IndexBufferFieldName_.IndexEquals(other.field_T_IndexBufferFieldName_)) return false;");
                break; case FieldKind.UnaryString:
Emit("            if (!field_T_UnaryStringFieldName_.ValueEquals(other.field_T_UnaryStringFieldName_)) return false;");
                break; case FieldKind.ArrayString:
Emit("            if (!field_T_ArrayStringFieldName_.ArrayEquals(other.field_T_ArrayStringFieldName_)) return false;");
                break; case FieldKind.IndexString:
Emit("            if (!field_T_IndexStringFieldName_.IndexEquals(other.field_T_IndexStringFieldName_)) return false;");
                break; default: break;
            }
            }}
Emit("            return base.Equals(other);");
Emit("        }");
Emit("");
Emit("        [MethodImpl(MethodImplOptions.AggressiveInlining)]");
Emit("        public static bool operator ==(T_ClassName_ left, T_ClassName_ right)");
Emit("        {");
Emit("            if (ReferenceEquals(left, right)) return true;");
Emit("            if (left is null) return false;");
Emit("            if (right is null) return false;");
Emit("            return left.Equals(right);");
Emit("        }");
Emit("");
Emit("        [MethodImpl(MethodImplOptions.AggressiveInlining)]");
Emit("        public static bool operator !=(T_ClassName_ left, T_ClassName_ right)");
Emit("        {");
Emit("            if (ReferenceEquals(left, right)) return false;");
Emit("            if (left is null) return true;");
Emit("            if (right is null) return true;");
Emit("            return !(left.Equals(right));");
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
Emit("            int hash = base.GetHashCode();");
Emit("            unchecked");
Emit("            {");
                foreach (var fs in cs.Iterators["Fields"].Iterations) {
                  using (NewScope(fs)) {
                    var fieldInfo = new FieldInfo(fs, _engine.Current);
                switch (fieldInfo.Kind)
                {
                    case FieldKind.UnaryModel:
Emit("                hash = (hash * 397) ^ (field_T_UnaryModelFieldName_.CalcHashUnary());");
                    break; case FieldKind.ArrayModel:
Emit("                hash = (hash * 397) ^ (field_T_ArrayModelFieldName_.CalcHashArray());");
                    break; case FieldKind.IndexModel:
Emit("                hash = (hash * 397) ^ (field_T_IndexModelFieldName_.CalcHashIndex());");
                    break; case FieldKind.UnaryMaybe:
Emit("                hash = (hash * 397) ^ (field_T_UnaryMaybeFieldName_.CalcHashUnary());");
                    break; case FieldKind.ArrayMaybe:
Emit("                hash = (hash * 397) ^ (field_T_ArrayMaybeFieldName_.CalcHashArray());");
                    break; case FieldKind.IndexMaybe:
Emit("                hash = (hash * 397) ^ (field_T_IndexMaybeFieldName_.CalcHashIndex());");
                    break; case FieldKind.UnaryOther:
Emit("                hash = (hash * 397) ^ (field_T_UnaryOtherFieldName_.CalcHashUnary());");
                    break; case FieldKind.ArrayOther:
Emit("                hash = (hash * 397) ^ (field_T_ArrayOtherFieldName_.CalcHashArray());");
                    break; case FieldKind.IndexOther:
Emit("                hash = (hash * 397) ^ (field_T_IndexOtherFieldName_.CalcHashIndex());");
                    break; case FieldKind.UnaryBuffer:
Emit("                hash = (hash * 397) ^ (field_T_UnaryBufferFieldName_.CalcHashUnary());");
                    break; case FieldKind.ArrayBuffer:
Emit("                hash = (hash * 397) ^ (field_T_ArrayBufferFieldName_.CalcHashArray());");
                    break; case FieldKind.IndexBuffer:
Emit("                hash = (hash * 397) ^ (field_T_IndexBufferFieldName_.CalcHashIndex());");
                    break; case FieldKind.UnaryString:
Emit("                hash = (hash * 397) ^ (field_T_UnaryStringFieldName_.CalcHashUnary());");
                    break; case FieldKind.ArrayString:
Emit("                hash = (hash * 397) ^ (field_T_ArrayStringFieldName_.CalcHashArray());");
                    break; case FieldKind.IndexString:
Emit("                hash = (hash * 397) ^ (field_T_IndexStringFieldName_.CalcHashIndex());");
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
