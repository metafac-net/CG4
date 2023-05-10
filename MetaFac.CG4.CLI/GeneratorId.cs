﻿namespace MetaFac.CG4.CLI
{
    public enum GeneratorId
    {
        /// <summary>
        /// Common contracts for all polymorphic generated code.
        /// </summary>
        Contracts,

        /// <summary>
        /// C# freezable model classes.
        /// </summary>
        ClassesV2,

        /// <summary>
        /// C# immutable records (requires C# V8.0+).
        /// </summary>
        RecordsV2,

        /// <summary>
        /// C# immutable DTO classes for MessagePack.
        /// </summary>
        MessagePack,

    }
}