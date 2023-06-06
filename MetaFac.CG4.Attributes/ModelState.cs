using System;

namespace MetaFac.CG4.Attributes
{
    [Flags]
    public enum ModelState
    {
        Active = 0,
        IsRedacted = 0x01,
        IsInactive = 0x02,

        /// <summary>
        /// Reserved for future use. Is not emitted during generation. This is useful for pre-allocating tags.
        /// </summary>
        Reserved = IsRedacted,

        /// <summary>
        /// Deprecated. Will be deleted in the future. Emitted during generation.
        /// </summary>
        Deprecated = IsInactive,

        /// <summary>
        /// Deleted. Is not emitted during generation
        /// </summary>
        Deleted = IsRedacted | IsInactive,
    }
}
