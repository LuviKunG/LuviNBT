using System.Runtime.Serialization;

namespace NBT.Exceptions
{
    public class NBTException : Exception
    {
        public NBTException() { }
        public NBTException(string? message) : base(message) { }
        public NBTException(string? message, Exception? innerException) : base(message, innerException) { }
        protected NBTException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    public class NBTReaderInvalidFormatException : NBTException
    {
        private NBTReaderInvalidFormatException() { }
        public NBTReaderInvalidFormatException(Type readerType, char c) : base($"Cannot read the character \'{c}\' in reader of {nameof(readerType)}") { }
    }
}