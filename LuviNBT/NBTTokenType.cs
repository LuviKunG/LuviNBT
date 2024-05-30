namespace NBT
{
    /// <summary>
    /// The type of token in NBT.
    /// </summary>
    public enum NBTTokenType
    {
        /// <summary>
        /// Value type.
        /// </summary>
        Value,
        /// <summary>
        /// Nested in square brackets [] and separated by commas.
        /// </summary>
        List,
        /// <summary>
        /// Nested in curly brackets {} and separated by commas.
        /// Has a key-value pair structure.
        /// </summary>
        Compound
    }
}