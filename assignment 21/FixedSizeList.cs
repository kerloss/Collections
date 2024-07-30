using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_21
{
    internal class FixedSizeList<T>
    {
        private T[] Items;
        private int Capacity;
        private int Count;

        public FixedSizeList(int _capacity)
        {
            Items = new T[Capacity];
            Capacity = _capacity;
            Count = 0;
        }

        public void Add(T item)
        {
            if (Count >= Capacity)
            {
                throw new InvalidOperationException("Cannot add more elements. The list is already full.");
            }

            Items[Count] = item;
            Count++;
        }

        public T Get(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Invalid index. Index is out of range.");
            }

            return Items[index];
        }
    }
}
