using System.Collections;

namespace MyCoreLib
{
    public class MyList<T> : IList<T>,ICollection<T>, IEnumerable<T> where T : IComparable<T>
    {
        T[] arr = new T[8];

        public int Count { get; private set; }

        public bool IsReadOnly => throw new NotImplementedException();

        public int ArrayLenght => arr.Length;

        public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public MyList()
        {
            Count = 0;
        }

        public MyList(IEnumerable<T> collection) : this()
        {
            var inputCount = collection.Count();

            if (arr.Length<inputCount)
            arr = new T[inputCount];

            Array.Copy(collection.ToArray(), arr, inputCount);
            Count = inputCount;
        }

        public void Add(T i)
        {
            int lenght = arr.Length;

            if (lenght <= Count)
            {
                T[] tempArr = new T[lenght * 2];
                Array.Copy(arr, tempArr, lenght);

                arr = tempArr;
            }

            arr[Count] = i;
            Count++;
        }

        public void Remove(T i)
        {
            int index = Array.IndexOf(arr, i);

            Array.Copy(arr, index+1, arr, index, Count - index);
            
            Count--;
        }

        public void Print()
        {
            Console.WriteLine();
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        public void BubbleSort()
        {
            BubbleSort((x, y) => x.CompareTo(y) > 0);
        }

        public void BubbleSortDesc()
        {
            BubbleSort((x, y) => x.CompareTo(y) < 0);
        }

        private void BubbleSort(Func<T, T, bool> comparer)
        {
            int i, j;
            for (i = 0; i < Count - 1; i++)
                for (j = 0; j < Count - i - 1; j++)
                    if (comparer(arr[j], arr[j + 1]))
                    {
                        T temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
        }

        private void IncreaseArray()
        {
            Array.Resize(ref arr, arr.Length * 2);             
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(arr, item);
        }

        public void Insert(int index, T item)
        {
            if (arr.Length == Count)
                IncreaseArray();

            Array.Copy(arr, index, arr, index + 1, Count - index);
            arr[index] = item;
            Count++;
        }

        public void RemoveAt(int index)
        {
            Array.Copy(arr, index + 1, arr, index, Count - index);

            Count--;
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        bool ICollection<T>.Remove(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
