namespace NBT
{
    using Exceptions;

    public sealed class NBTToken
    {
        public readonly NBTTokenType type;
        private readonly object? reference;

        public NBTToken(NBTValue value)
        {
            type = NBTTokenType.Value;
            reference = value;
        }

        public NBTToken(NBTCompound compound)
        {
            type = NBTTokenType.Compound;
            reference = compound;
        }

        public NBTToken(NBTList list)
        {
            type = NBTTokenType.List;
            reference = list;
        }

        public object GetToken()
        {
            return reference switch
            {
                NBTValue value => value,
                NBTCompound compound => compound,
                NBTList list => list,
                _ => throw new NBTTokenInvalidCastException(type),
            };
        }

        public static explicit operator NBTValue(NBTToken token)
        {
            return (NBTValue)token.GetToken();
        }

        public static explicit operator NBTCompound(NBTToken token)
        {
            return (NBTCompound)token.GetToken();
        }

        public static explicit operator NBTList(NBTToken token)
        {
            return (NBTList)token.GetToken();
        }

        public static implicit operator NBTToken(NBTValue value)
        {
            return new(value);
        }

        public static implicit operator NBTToken(NBTCompound compound)
        {
            return new(compound);
        }

        public static implicit operator NBTToken(NBTList list)
        {
            return new(list);
        }

        public override string ToString()
        {
            return GetToken().ToString()!;
        }
    }
}