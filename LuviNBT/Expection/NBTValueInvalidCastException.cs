namespace NBT.Exceptions
{
    public sealed class NBTValueInvalidCastException : NBTException
    {
        private NBTValueInvalidCastException() { }
        public NBTValueInvalidCastException(NBTValueType type) : base($"Cannot cast NBT value to {type}.") { }
    }
}