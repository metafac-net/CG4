using System;

namespace MetaCode.TextProcessing.Tests
{
    public readonly struct TextSpan
    {
        public readonly string Source;
        public readonly int Offset;
        public readonly int Length;

        public TextSpan(string source, int offset, int length) : this()
        {
            Source = source ?? throw new ArgumentNullException(nameof(source));
            if (offset < 0) throw new ArgumentOutOfRangeException(nameof(offset), offset, null);
            if (offset + length > source.Length) throw new ArgumentOutOfRangeException(nameof(length), length, null);
            Offset = offset;
            Length = length;
        }

        public char this[int index]
        {
            get
            {
                return Source[Offset + index];
            }
        }

        public override string ToString()
        {
            return Source.Substring(Offset, Length);
        }

    }
}