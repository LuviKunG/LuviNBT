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
}