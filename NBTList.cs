using System.Collections;

namespace NBT
{
    public sealed class NBTList : IEnumerable, IEnumerable<NBTToken>
    {
        private readonly List<NBTToken> list;

        public NBTList()
        {
            list = new();
        }

        public NBTToken this[int index]
        {
            get => list[index];
            set => list[index] = value;
        }

        public int Count => list.Count;

        public void Add(NBTToken token)
        {
            list.Add(token);
        }

        public void AddRange(IEnumerable<NBTToken> tokens)
        {
            list.AddRange(tokens);
        }

        public void Insert(int index, NBTToken token)
        {
            list.Insert(index, token);
        }

        public void InsertRange(int index, IEnumerable<NBTToken> tokens)
        {
            list.InsertRange(index, tokens);
        }

        public void Remove(NBTToken token)
        {
            list.Remove(token);
        }

        public void RemoveRange(int index, int count)
        {
            list.RemoveRange(index, count);
        }

        public void RemoveAt(int index)
        {
            list.RemoveAt(index);
        }

        public bool Contains(NBTToken token)
        {
            return list.Contains(token);
        }

        public int IndexOf(NBTToken token)
        {
            return list.IndexOf(token);
        }

        public void Clear()
        {
            list.Clear();
        }

        public IEnumerator GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator<NBTToken> IEnumerable<NBTToken>.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", list)}]";
        }
    }
}