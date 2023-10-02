using MetaFac.CG4.Attributes;
using System;

namespace MetaFac.CG4.Generators
{
    public sealed class GeneratorOptions
    {
        /// <summary>
        /// The users' copyright information to be included in the generated source files.
        /// </summary>
        public string? CopyrightInfo { get; set; }

        public GeneratorOptions() { }

        public GeneratorOptions(GeneratorOptions? source)
        {
            if (source is null) return;
            CopyrightInfo = source.CopyrightInfo;
        }
    }

    public static class GeneratorExtensions
    {
        public static GeneratorId ParseGeneratorId(this string generatorName)
        {
            string trimmedName = generatorName?.Trim() ?? throw new ArgumentNullException(nameof(generatorName));
            foreach (GeneratorId generatorId in Enum.GetValues(typeof(GeneratorId)))
            {
                if (string.Equals(generatorId.ToString(), trimmedName, StringComparison.OrdinalIgnoreCase))
                    return generatorId;
            }
            throw new ArgumentOutOfRangeException(nameof(generatorName), generatorName, null);
        }

        public static GeneratorBase GetGenerator(this GeneratorId generatorId)
        {
            GeneratorBase generator = generatorId switch
            {
                GeneratorId.Contracts => new MetaFac.CG4.Generator.Contracts.Generator(),
                GeneratorId.RecordsV2 => new MetaFac.CG4.Generator.RecordsV2.Generator(),
                GeneratorId.ClassesV2 => new MetaFac.CG4.Generator.ClassesV2.Generator(),
                GeneratorId.MessagePack => new MetaFac.CG4.Generator.MessagePack.Generator(),
                GeneratorId.JsonNewtonSoft => new MetaFac.CG4.Generator.JsonNewtonSoft.Generator(),
                GeneratorId.JsonSystemText => new MetaFac.CG4.Generator.JsonSystemText.Generator(),
                _ => throw new NotSupportedException($"GeneratorId: {generatorId}"),
            };
            return generator;
        }

    }
}