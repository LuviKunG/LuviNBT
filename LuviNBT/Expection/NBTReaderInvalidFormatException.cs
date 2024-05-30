namespace NBT.Exceptions
{
    public class NBTReaderInvalidFormatException : NBTException
    {
        private NBTReaderInvalidFormatException() { }
        public NBTReaderInvalidFormatException(Type readerType, char c) : base($"Cannot read the character \'{c}\' in reader of {nameof(readerType)}") { }
    }
}