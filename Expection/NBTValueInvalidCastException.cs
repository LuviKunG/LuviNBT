namespace NBT.Exceptions
{
    public class NBTValueInvalidCastException : NBTException
    {
        private NBTValueInvalidCastException() { }
        public NBTValueInvalidCastException(NBTValueType type) : base($"Cannot cast NBT value to {type}.") { }
    }
}