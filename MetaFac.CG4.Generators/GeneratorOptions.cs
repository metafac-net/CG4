﻿using System;

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
}