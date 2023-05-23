using MetaFac.CG4.Attributes;
namespace MetaFac.CG4.TestOrg.Models
{
    /// <summary>
    /// Generates all interfaces for our DTOs.
    /// </summary>
    [CG4Generate(BasicGeneratorId.Contracts, "Models.json")]
    internal static partial class InterfaceModels { }

    /// <summary>
    /// Generates all MessagePack DTOs.
    /// </summary>
    [CG4Generate(BasicGeneratorId.MessagePack, "Models.json")]
    internal static partial class MessagePackModels { }
}
