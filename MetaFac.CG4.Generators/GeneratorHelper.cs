using MetaFac.CG4.Attributes;
using MetaFac.CG4.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MetaFac.CG4.Generators
{
    public static class GeneratorHelper
    {
        public static GeneratorId GetGeneratorId(string generatorId)
        {
            if (generatorId is null) throw new ArgumentNullException(nameof(generatorId));
            string prefix = $"{nameof(GeneratorId)}.";
            if (generatorId.StartsWith(prefix))
            {
                string suffix = generatorId.Substring(prefix.Length);
                if (Enum.TryParse<GeneratorId>(suffix, out var parsedGeneratorId))
                {
                    return parsedGeneratorId;
                }
            }
            throw new ArgumentOutOfRangeException(nameof(generatorId), generatorId, null);
        }

        public static GeneratorBase CreateBasicGenerator(GeneratorId generatorId)
        {
            switch (generatorId)
            {
                case GeneratorId.Contracts:
                    return new MetaFac.CG4.Generator.Contracts.Generator();
                case GeneratorId.MessagePack:
                    return new MetaFac.CG4.Generator.MessagePack.Generator();
                case GeneratorId.ClassesV2:
                    return new MetaFac.CG4.Generator.ClassesV2.Generator();
                case GeneratorId.RecordsV2:
                    return new MetaFac.CG4.Generator.RecordsV2.Generator();
                default:
                    throw new ArgumentOutOfRangeException(nameof(generatorId), generatorId, null);
            }
        }

        public static GeneratorBase GetGeneratorByName(string name, GeneratorBase[] generators)
        {
            if (generators is null || generators.Length == 0)
                throw new ArgumentException($"No generators specified.", nameof(generators));
            var candidates = generators.Where(g => g.GetType().Name.Contains(name)).ToArray();
            if (candidates.Length == 0)
                throw new ArgumentException($"Name does not match any of the generators", nameof(name));
            if (candidates.Length > 1)
                throw new ArgumentException($"Name matches multiple generators", nameof(name));
            GeneratorBase generator = candidates[0];
            return generator;
        }

        private static void WriteLines(IEnumerable<string> content, string filename)
        {
            using var sw = new StreamWriter(filename);
            foreach (var line in content)
            {
                sw.WriteLine(line);
            }
        }

    }
}