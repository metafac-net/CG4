using System.Text;

namespace MetaFac.CG3.ModelReader
{
    public class TagName
    {
        public readonly string Name;
        public readonly int? Tag;
        public readonly string? InnerType;

        public TagName(int? tag, string name, string? innerType = null)
        {
            Tag = tag;
            Name = name;
            InnerType = innerType;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append($"{Name}");
            if (Tag.HasValue) result.Append($"({Tag.Value})");
            return result.ToString();
        }
    }
}
