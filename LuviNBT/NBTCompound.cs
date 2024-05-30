using NBT.Exceptions;
using System.Collections;
using System.Text;

namespace NBT
{
    public sealed class NBTCompound : IEnumerable, IEnumerable<KeyValuePair<string, NBTToken>>, IReadOnlyDictionary<string, NBTToken>
    {
        private readonly Dictionary<string, NBTToken> dictionary;

        /// <summary>
        /// Check if the string key is valid.
        /// </summary>
        /// <remarks>
        /// The key must be between 1 and 32 characters long, and must not contain any whitespace characters or special characters except for the following: '_', '+', '-', '.'.
        /// </remarks>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsStringKeyValid(string key)
        {
            if (key.Length == 0 || key.Length > 32)
                return false;
            foreach (char c in key)
            {
                if (char.IsWhiteSpace(c))
                    return false;
                if (!(char.IsLetterOrDigit(c) || c == '_' || c == '+' || c == '-' || c == '.'))
                    return false;
            }
            return true;
        }

        public NBTCompound()
        {
            dictionary = new();
        }

        public NBTToken this[string key]
        {
            get => dictionary[key];
            set => dictionary[key] = value;
        }

        public int Count => dictionary.Count;

        public IEnumerable<string> Keys => ((IReadOnlyDictionary<string, NBTToken>)dictionary).Keys;

        public IEnumerable<NBTToken> Values => ((IReadOnlyDictionary<string, NBTToken>)dictionary).Values;

        public void Add(string key, NBTToken value)
        {
            if (!IsStringKeyValid(key))
                throw new NBTCompoundInvalidKeyFormatException(key);
            dictionary.Add(key, value);
        }

        public void Add(string key, NBTValue value)
        {
            if (!IsStringKeyValid(key))
                throw new NBTCompoundInvalidKeyFormatException(key);
            dictionary.Add(key, value);
        }

        public bool TryAdd(string key, NBTToken value)
        {
            if (!IsStringKeyValid(key))
                throw new NBTCompoundInvalidKeyFormatException(key);
            return dictionary.TryAdd(key, value);
        }

        public bool TryAdd(string key, NBTValue value)
        {
            if (!IsStringKeyValid(key))
                throw new NBTCompoundInvalidKeyFormatException(key);
            return dictionary.TryAdd(key, value);
        }

        public bool TryGetValue(string key, out NBTToken value)
        {
            return dictionary.TryGetValue(key, out value!);
        }

        public void Remove(string key)
        {
            dictionary.Remove(key);
        }

        public bool ContainsKey(string key)
        {
            return dictionary.ContainsKey(key);
        }

        public void Clear()
        {
            dictionary.Clear();
        }

        public IEnumerator GetEnumerator()
        {
            return dictionary.GetEnumerator();
        }

        IEnumerator<KeyValuePair<string, NBTToken>> IEnumerable<KeyValuePair<string, NBTToken>>.GetEnumerator()
        {
            return dictionary.GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder builder = new();
            builder.Append('{');
            foreach (KeyValuePair<string, NBTToken> member in dictionary)
            {
                builder.Append(member.Key);
                builder.Append(": ");
                builder.Append(member.Value);
                builder.Append(", ");
            }
            if (builder.Length > 1)
                builder.Length -= 2;
            builder.Append('}');
            return builder.ToString();
        }
    }
}