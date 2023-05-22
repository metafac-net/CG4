﻿using System;

namespace MetaFac.CG4.Attributes
{
    public enum BasicGeneratorId
    {
        None,
        Contracts,
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class CG4GenerateAttribute : Attribute
    {
        public BasicGeneratorId GeneratorId { get; }
        public string JsonMetadataFilename { get; }

        public CG4GenerateAttribute(BasicGeneratorId generatorId, string jsonMetadataFilename)
        {
            GeneratorId = generatorId;
            JsonMetadataFilename = jsonMetadataFilename;
        }
    }
}