namespace NBT
{
    /// <summary>
    /// The type of value in NBT.
    /// </summary>
    public enum NBTValueType
    {
        /// <summary>
        /// The type is unknow and invalid.
        /// </summary>
        Invalid,
        /// <summary>
        /// [number]b or [number]B
        /// </summary>
        Byte,
        /// <summary>
        /// true or false (case insensitive)
        /// </summary>
        Boolean,
        /// <summary>
        /// [number]s or [number]S
        /// </summary>
        Short,
        /// <summary>
        /// [number]
        /// </summary>
        Int,
        /// <summary>
        /// [number]l or [number]L
        /// </summary>
        Long,
        /// <summary>
        /// [number]f or [number]F with . as decimal separator
        /// </summary>
        Float,
        /// <summary>
        /// [number]d or [number]D with . as decimal separator
        /// </summary>
        Double,
        /// <summary>
        /// Nested in single quotes (') or double quotes (").
        /// </summary>
        String
    }
}