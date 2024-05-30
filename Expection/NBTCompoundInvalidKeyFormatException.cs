namespace NBT.Exceptions
{
    public sealed class NBTCompoundInvalidKeyFormatException : NBTException
    {
        private NBTCompoundInvalidKeyFormatException() { }
        public NBTCompoundInvalidKeyFormatException(string? key) : base(key is null ? $"Key is null." : $"Key is invalid format. The value is \'{key}\'") { }
    }
}