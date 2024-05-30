using System.Text;

namespace NBT
{
    using Exceptions;

    public sealed class NBTValue
    {
        private static readonly Encoding Encoding;

        static NBTValue()
        {
#if NBT_ENCODING_UTF8
            Encoding = Encoding.UTF8;
#elif NBT_ENCODING_ASCII
            Encoding = Encoding.ASCII;
#else
            Encoding = Encoding.Default;
#endif
        }

        public readonly NBTValueType type;
        private readonly byte[]? bytes;

        #region Constructors

        /// <summary>
        /// Private constructor to declare the type of the value.
        /// </summary>
        /// <param name="type"></param>
        private NBTValue(NBTValueType type)
        {
            this.type = type;
        }

        /// <summary>
        /// Constructor for a byte value.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public NBTValue(byte value) : this(NBTValueType.Byte)
        {
            bytes = new byte[] { value };
        }

        /// <summary>
        /// Constructor for a boolean value.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public NBTValue(bool value) : this(NBTValueType.Boolean)
        {
            bytes = new byte[] { (byte)(value ? 0b_1 : 0b_0) };
        }

        /// <summary>
        /// Constructor for a short value.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public NBTValue(short value) : this(NBTValueType.Short)
        {
            bytes = BitConverter.GetBytes(value);
        }

        /// <summary>
        /// Constructor for an int value.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public NBTValue(int value) : this(NBTValueType.Int)
        {
            bytes = BitConverter.GetBytes(value);
        }

        /// <summary>
        /// Constructor for a long value.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public NBTValue(long value) : this(NBTValueType.Long)
        {
            bytes = BitConverter.GetBytes(value);
        }

        /// <summary>
        /// Constructor for a float value.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public NBTValue(float value) : this(NBTValueType.Float)
        {
            bytes = BitConverter.GetBytes(value);
        }

        /// <summary>
        /// Constructor for a double value.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public NBTValue(double value) : this(NBTValueType.Double)
        {
            bytes = BitConverter.GetBytes(value);
        }

        /// <summary>
        /// Constructor for a string value.
        /// </summary>
        /// <param name="value"></param>
        public NBTValue(string value) : this(NBTValueType.String)
        {
            bytes = Encoding.GetBytes(value);
        }

        #endregion

        public object GetValue()
        {
            return type switch
            {
                NBTValueType.Byte => (byte)this,
                NBTValueType.Boolean => (bool)this,
                NBTValueType.Short => (short)this,
                NBTValueType.Int => (int)this,
                NBTValueType.Long => (long)this,
                NBTValueType.Float => (float)this,
                NBTValueType.Double => (double)this,
                NBTValueType.String => (string)this,
                _ => throw new NBTValueInvalidCastException(type),
            };
        }

        #region Explicit Operators

        public static explicit operator byte(NBTValue token)
        {
            if (token.type != NBTValueType.Byte)
            {
                throw new NBTValueInvalidCastException(NBTValueType.Byte);
            }
            return token.bytes![0];
        }

        public static explicit operator bool(NBTValue token)
        {
            if (token.type != NBTValueType.Boolean)
            {
                throw new NBTValueInvalidCastException(NBTValueType.Boolean);
            }
            return token.bytes![0] != 0b_0;
        }

        public static explicit operator short(NBTValue token)
        {
            if (token.type != NBTValueType.Short)
            {
                throw new NBTValueInvalidCastException(NBTValueType.Short);
            }
            short value;
            try
            {
                value = BitConverter.ToInt16(token.bytes!, 0);
            }
            catch
            {
                throw new NBTValueInvalidCastException(NBTValueType.Short);
            }
            return value;
        }

        public static explicit operator int(NBTValue token)
        {
            if (token.type != NBTValueType.Int)
            {
                throw new NBTValueInvalidCastException(NBTValueType.Int);
            }
            int value;
            try
            {
                value = BitConverter.ToInt32(token.bytes!, 0);
            }
            catch
            {
                throw new NBTValueInvalidCastException(NBTValueType.Int);
            }
            return value;
        }

        public static explicit operator long(NBTValue token)
        {
            if (token.type != NBTValueType.Long)
            {
                throw new NBTValueInvalidCastException(NBTValueType.Long);
            }
            long value;
            try
            {
                value = BitConverter.ToInt64(token.bytes!, 0);
            }
            catch
            {
                throw new NBTValueInvalidCastException(NBTValueType.Long);
            }
            return value;
        }

        public static explicit operator float(NBTValue token)
        {
            if (token.type != NBTValueType.Float)
            {
                throw new NBTValueInvalidCastException(NBTValueType.Float);
            }
            float value;
            try
            {
                value = BitConverter.ToSingle(token.bytes!, 0);
            }
            catch
            {
                throw new NBTValueInvalidCastException(NBTValueType.Float);
            }
            return value;
        }

        public static explicit operator double(NBTValue token)
        {
            if (token.type != NBTValueType.Double)
            {
                throw new NBTValueInvalidCastException(NBTValueType.Double);
            }
            double value;
            try
            {
                value = BitConverter.ToDouble(token.bytes!, 0);
            }
            catch
            {
                throw new NBTValueInvalidCastException(NBTValueType.Double);
            }
            return value;
        }

        public static explicit operator string(NBTValue token)
        {
            if (token.type != NBTValueType.String)
            {
                throw new NBTValueInvalidCastException(NBTValueType.String);
            }
            string value;
            try
            {
                value = Encoding.GetString(token.bytes!);
            }
            catch
            {
                throw new NBTValueInvalidCastException(NBTValueType.String);
            }
            return value;
        }

        #endregion

        #region Implicit Operators

        public static implicit operator NBTValue(byte value)
        {
            return new NBTValue(value);
        }

        public static implicit operator NBTValue(bool value)
        {
            return new NBTValue(value);
        }

        public static implicit operator NBTValue(short value)
        {
            return new NBTValue(value);
        }

        public static implicit operator NBTValue(int value)
        {
            return new NBTValue(value);
        }

        public static implicit operator NBTValue(long value)
        {
            return new NBTValue(value);
        }

        public static implicit operator NBTValue(float value)
        {
            return new NBTValue(value);
        }

        public static implicit operator NBTValue(double value)
        {
            return new NBTValue(value);
        }

        public static implicit operator NBTValue(string value)
        {
            return new NBTValue(value);
        }

        #endregion

        public override string ToString()
        {
            if (type == NBTValueType.String)
            {
                return $"\"{GetValue()}\"";
            }
            return GetValue().ToString()!;
        }
    }
}