using System;

namespace MetaFac.CG4.SrcGenAttributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CG4GenerateAttribute : Attribute
    {
        public CG4GeneratorId GeneratorId { get; }
        public string JsonMetadataFilename { get; }

        public CG4GenerateAttribute(CG4GeneratorId generatorId, string jsonMetadataFilename)
        {
            GeneratorId = generatorId;
            JsonMetadataFilename = jsonMetadataFilename;
        }
    }
}
