namespace NBT.Exceptions
{
    public sealed class NBTTokenInvalidCastException : NBTException
    {
        private NBTTokenInvalidCastException() { }
        public NBTTokenInvalidCastException(NBTTokenType type) : base($"Cannot cast NBT token to {type}.") { }
    }
}