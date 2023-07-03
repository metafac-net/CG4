namespace MetaFac.CG4.Runtime
{
    public class BuildInfo : IBuildInfo
    {
        private static readonly BuildInfo _instance = new BuildInfo();
        public static IBuildInfo Instance => _instance;

        string IBuildInfo.AssemblyName => ThisAssembly.AssemblyName;
        string IBuildInfo.AssemblyConfiguration => ThisAssembly.AssemblyConfiguration;
        string IBuildInfo.AssemblyVersion => ThisAssembly.AssemblyVersion;
        string IBuildInfo.AssemblyFileVersion => ThisAssembly.AssemblyFileVersion;
        string IBuildInfo.AssemblyInformationalVersion => ThisAssembly.AssemblyInformationalVersion;
        string IBuildInfo.GitCommitId => ThisAssembly.GitCommitId;

        private readonly string _gitCommitDate = ThisAssembly.GitCommitDate.ToString("O");
        string IBuildInfo.GitCommitDate => _gitCommitDate;
    }
}