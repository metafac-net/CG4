using System;

namespace MetaFac.CG4.Runtime.JsonSystemText
{
    public struct VersionValue
    {
        public int Major { get; set; }
        public int Minor { get; set; }
        public int Build { get; set; }
        public int Revision { get; set; }
        public VersionValue() { }
        public VersionValue(int major, int minor, int build, int revision)
        {
            Major = major;
            Minor = minor;
            Build = build;
            Revision = revision;
        }
        public override int GetHashCode() => HashCode.Combine(Major, Minor, Build, Revision);
        public override bool Equals(object? obj) => obj is VersionValue other && Equals(other);
        public bool Equals(VersionValue other) =>
            other.Major == Major
            && other.Minor == Minor
            && other.Build == Build
            && other.Revision == Revision;
        public static bool operator ==(VersionValue left, VersionValue right) => left.Equals(right);
        public static bool operator !=(VersionValue left, VersionValue right) => !left.Equals(right);

        public static implicit operator VersionValue?(Version? input)
            => input is null
                ? null
                : new VersionValue(input.Major, input.Minor, input.Build, input.Revision);

        private static Version CreateVersion(int major, int minor, int build, int revision)
        {
            if (revision >= 0) return new Version(major, minor, build, revision);
            if (build >= 0) return new Version(major, minor, build);
            return new Version(major, minor);
        }

        public static implicit operator Version?(VersionValue? input)
            => input is null
                ? null
                : CreateVersion(input.Value.Major, input.Value.Minor, input.Value.Build, input.Value.Revision);
    }

}