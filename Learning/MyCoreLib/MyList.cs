namespace MyCoreLib
{
    public class MyList<T> where T : IComparable<T>
    {
        T[] arr = new T[10];

        public int Count { get; private set; }

        public MyList()
        {
            Count = 0;
        }

        public void Add(T i)
        {
            arr[Count] = i;
            Count++;
        }

        public void Remove()
        {

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
    }
}
