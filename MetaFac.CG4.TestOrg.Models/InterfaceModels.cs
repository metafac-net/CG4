using MetaFac.CG4.SrcGenAttributes;

namespace MetaFac.CG4.TestOrg.Models
{
    /// <summary>
    /// Generates all interfaces for our DTOs.
    /// </summary>
    [CG4Generate(CG4GeneratorId.Contracts, "Models.json")]
    internal static partial class InterfaceModels { }

    /// <summary>
    /// Generates all MessagePack DTOs.
    /// </summary>
    [CG4Generate(CG4GeneratorId.MessagePack, "Models.json")]
    internal static partial class MessagePackModels { }
}
