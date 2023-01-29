namespace MetaCode.Generators.Tests
{
    // todo move to TS3 repo
    //public class ProxyTypeTests
    //{
    //    [Fact]
    //    public void Interface_Generation()
    //    {
    //        var fields = new List<ModelFieldDef>() {
    //            new ModelFieldDef("Field01", 01, "Quantity", false, false, 0),
    //            new ModelFieldDef("Field02", 02, "Quantity", true, false, 0),
    //            new ModelFieldDef("Field03", 03, "Quantity", false, true, 1),
    //            new ModelFieldDef("Field04", 04, "Quantity", true, true, 1),
    //        };
    //        var class1 = new ModelClassDef("Class1", 1, false, null, fields);
    //        var model1 = new ModelDefinition("Model1", 1, new ModelClassDef[] { class1 });
    //        var metadata = new ModelContainer(model1, new Dictionary<string, string>()
    //        {
    //            ["Token1"] = "Value1",
    //            ["Token2"] = null
    //        });
    //        TemplateScope outerScope = metadata.GetScopeFromMetadata()
    //            .SetToken("Namespace", "MyNamespace")
    //            .SetToken("ExternalQuantity", "LabApps.Units.Quantity")
    //            .SetToken("ConcreteQuantity", "LabApps.Units.Quantity")
    //            ;
    //        var generator = new MetaCode.TS3.Generator.Interfaces.Generator();
    //        string[] actualOutput = generator.Generate(outerScope).ToArray();
    //        string[] expectedOutput = new string[] {
    //            "#if NET5_0",
    //            "#nullable enable",
    //            "#endif",
    //            "",
    //            "using System;",
    //            "using System.Collections.Generic;",
    //            "using MetaFac.Memory;",
    //            "",
    //            "namespace MyNamespace.Interfaces",
    //            "{",
    //            "",
    //            "    public partial interface IClass1",
    //            "    {",
    //            "        LabApps.Units.Quantity Field01 { get; }",
    //            "        LabApps.Units.Quantity? Field02 { get; }",
    //            "#if NET5_0",
    //            "        IEnumerable<LabApps.Units.Quantity>? Field03 { get; }",
    //            "#else",
    //            "        IEnumerable<LabApps.Units.Quantity> Field03 { get; }",
    //            "#endif",
    //            "#if NET5_0",
    //            "        IEnumerable<LabApps.Units.Quantity?>? Field04 { get; }",
    //            "#else",
    //            "        IEnumerable<LabApps.Units.Quantity?> Field04 { get; }",
    //            "#endif",
    //            "    }",
    //            "}"
    //        };
    //        for (int i = 0; i < actualOutput.Length && i < expectedOutput.Length; i++)
    //        {
    //            actualOutput[i].Should().Be(expectedOutput[i], $"line[{i}]");
    //        }
    //        actualOutput.Length.Should().Be(expectedOutput.Length);
    //    }
    //    [Fact]
    //    public void MsgPack_Generation()
    //    {
    //        var fields = new List<ModelFieldDef>() {
    //            new ModelFieldDef("Field01", 01, "Quantity", false, false, 0),
    //            new ModelFieldDef("Field02", 02, "Quantity", true, false, 0),
    //            new ModelFieldDef("Field03", 03, "Quantity", false, true, 1),
    //            new ModelFieldDef("Field04", 04, "Quantity", true, true, 1),
    //        };
    //        var class1 = new ModelClassDef("Class1", 1, false, null, fields);
    //        var model1 = new ModelDefinition("Model1", 1, new ModelClassDef[] { class1 });
    //        var metadata = new ModelContainer(model1, new Dictionary<string, string>()
    //        {
    //            ["Token1"] = "Value1",
    //            ["Token2"] = null
    //        });
    //        TemplateScope outerScope = metadata.GetScopeFromMetadata()
    //            .SetToken("Namespace", "MyNamespace")
    //            .SetToken("ExternalQuantity", "LabApps.Units.Quantity")
    //            .SetToken("ConcreteQuantity", "QuantityValue")
    //            ;
    //        var generator = new MetaCode.TS3.Generator.MsgPack.Generator();
    //        string[] actualOutput = generator.Generate(outerScope).ToArray();
    //        string[] expectedOutput = new string[] {
    //            "#if NET5_0",
    //            "#nullable enable",
    //            "#endif",
    //            "",
    //            "using System;",
    //            "using System.Collections.Generic;",
    //            "using System.Linq;",
    //            "using System.Runtime.CompilerServices;",
    //            "using LabApps.Types.Equality;",
    //            "using MetaFac.Memory;",
    //            "using MessagePack;",
    //            "using MetaCode.Runtime;",
    //            "using MetaCode.Runtime.MsgPack;",
    //            "",
    //            "using MyNamespace.Interfaces;",
    //            "",
    //            "namespace MyNamespace.MsgPack",
    //            "{",
    //            "",
    //            "",
    //            "    [MessagePackObject]",
    //            "    public sealed partial class Class1 : IClass1, IEquatable<Class1>",
    //            "    {",
    //            "        [MethodImpl(MethodImplOptions.AggressiveInlining)]",
    //            "#if NET5_0",
    //            "        public static Class1? CreateFrom(IClass1? source)",
    //            "#else",
    //            "        public static Class1 CreateFrom(IClass1 source)",
    //            "#endif",
    //            "        {",
    //            "            if (source is null) return null;",
    //            "            return new Class1(source);",
    //            "        }",
    //            "",
    //            "        private const int ClassTag = 1;",
    //            "",
    //            "        [Key(1)]",
    //            "        public QuantityValue Field01 { get; set; }",
    //            "        [Key(2)]",
    //            "        public QuantityValue? Field02 { get; set; }",
    //            "        [Key(3)]",
    //            "#if NET5_0",
    //            "        public QuantityValue[]? Field03 { get; set; }",
    //            "#else",
    //            "        public QuantityValue[] Field03 { get; set; }",
    //            "#endif",
    //            "        [Key(4)]",
    //            "#if NET5_0",
    //            "        public QuantityValue?[]? Field04 { get; set; }",
    //            "#else",
    //            "        public QuantityValue?[] Field04 { get; set; }",
    //            "#endif",
    //            "",
    //            "        LabApps.Units.Quantity IClass1.Field01 => Field01.ToExternal();",
    //            "        LabApps.Units.Quantity? IClass1.Field02 => Field02.ToExternal();",
    //            "#if NET5_0",
    //            "        IEnumerable<LabApps.Units.Quantity>? IClass1.Field03 => Field03",
    //            "            ?.Select(x => x.ToExternal());",
    //            "#else",
    //            "        IEnumerable<LabApps.Units.Quantity> IClass1.Field03 => Field03",
    //            "            ?.Select(x => x.ToExternal());",
    //            "#endif",
    //            "#if NET5_0",
    //            "        IEnumerable<LabApps.Units.Quantity?>? IClass1.Field04 => Field04",
    //            "            ?.Select(x => x.ToExternal());",
    //            "#else",
    //            "        IEnumerable<LabApps.Units.Quantity?> IClass1.Field04 => Field04",
    //            "            ?.Select(x => x.ToExternal());",
    //            "#endif",
    //            "",
    //            //"        [MethodImpl(MethodImplOptions.AggressiveInlining)]",
    //            //"    }",
    //            //"}"
    //        };
    //        for (int i = 0; i < actualOutput.Length && i < expectedOutput.Length; i++)
    //        {
    //            actualOutput[i].Should().Be(expectedOutput[i], $"line[{i}]");
    //        }
    //        //actualOutput.Length.Should().Be(expectedOutput.Length);
    //    }
    //}
}