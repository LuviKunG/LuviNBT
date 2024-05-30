using System.Text;

namespace NBT.Parser
{
    using NBT.Exceptions;

    public static class NBTParser
    {
        public static NBTToken Parse(string str)
        {
            throw new NotImplementedException("Not finish yet...");
        }

        public static string Parse(NBTToken token)
        {
            return token.type switch
            {
                NBTTokenType.Value => ToStringValue((NBTValue)token),
                NBTTokenType.Compound => ToStringCompound((NBTCompound)token),
                NBTTokenType.List => ToStringList((NBTList)token),
                _ => throw new NBTTokenInvalidCastException(token.type),
            };
        }

        private static string ToStringValue(NBTValue value)
        {
            return value.type switch
            {
                NBTValueType.Byte => $"{(byte)value}b",
                NBTValueType.Boolean => $"{(bool)value}",
                NBTValueType.Short => $"{(short)value}s",
                NBTValueType.Int => $"{(int)value}",
                NBTValueType.Long => $"{(long)value}l",
                NBTValueType.Float => $"{(float)value}f",
                NBTValueType.Double => $"{(double)value}d",
                NBTValueType.String => $"\"{(string)value}\"",
                _ => throw new NBTValueInvalidCastException(value.type),
            };
        }

        private static string ToStringCompound(NBTCompound compound)
        {
            if (compound.Count > 0)
            {
                StringBuilder builder = new("{");
                foreach (KeyValuePair<string, NBTToken> pair in compound)
                {
                    builder.Append(pair.Key);
                    builder.Append(':');
                    builder.Append(Parse(pair.Value));
                    builder.Append(',');
                }
                builder[^1] = '}';
                return builder.ToString();
            }
            else
            {
                return "{}";
            }
        }

        private static string ToStringList(NBTList list)
        {
            if (list.Count > 0)
            {
                StringBuilder builder = new("[");
                foreach (NBTToken token in list)
                {
                    builder.Append(Parse(token));
                    builder.Append(',');
                }
                builder[^1] = ']';
                return builder.ToString();
            }
            else
            {

                return "[]";
            }
        }
    }
}