namespace MetaFac.CG3.CLI
{
    public enum GeneratorId
    {
        /// <summary>
        /// Common interfaces for all simple (non-polymorphic) generated code.
        /// </summary>
        Interfaces,
        Freezables,
        Immutables,
        JsonPoco,
        ProtobufNet3,
        Records,

        /// <summary>
        /// Common interfaces for all polymorphic generated code.
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