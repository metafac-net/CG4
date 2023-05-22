using MetaFac.CG4.Attributes;
namespace MetaFac.CG4.TestOrg.Models
{
    /// <summary>
    /// Generates all interfaces for our DTOs.
    /// 
    /// To create the models.json file, run this dotnet tool:
    /// 
    ///   mfcg4 a2j -am {assembly-path}.dll -an {assembly-namespace} -oj Models.json
    ///   
    /// To install the tool:
    /// 
    ///     dotnet tool install -g MetaFac.CG4.CLI
    ///     
    /// To update the tool:
    /// 
    ///     dotnet tool update -g MetaFac.CG4.CLI
    ///     
    /// </summary>
    [CG4Generate(BasicGeneratorId.Contracts, "Models.json")]
    internal static partial class InterfaceModels { }
}
