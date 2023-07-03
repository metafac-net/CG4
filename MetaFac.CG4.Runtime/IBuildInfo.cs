namespace MetaFac.CG4.Runtime
{
    public interface IBuildInfo
    {
        string AssemblyName { get; }
        string AssemblyConfiguration { get; }
        string AssemblyVersion { get; }
        string AssemblyFileVersion { get; }
        string AssemblyInformationalVersion { get; }
        string GitCommitId { get; }
        string GitCommitDate { get; }
    }
}
