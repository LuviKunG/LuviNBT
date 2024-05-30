using System.Collections;
using System.Text;

namespace NBT
{
    public sealed class NBTCompound : IEnumerable, IEnumerable<KeyValuePair<string, NBTToken>>, IReadOnlyDictionary<string, NBTToken>
    {
        private readonly Dictionary<string, NBTToken> dictionary;

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
            dictionary.Add(key, value);
        }

        public void Add(string key, NBTValue value)
        {
            dictionary.Add(key, value);
        }

        public bool TryAdd(string key, NBTToken value)
        {
            return dictionary.TryAdd(key, value);
        }

        public bool TryAdd(string key, NBTValue value)
        {
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