using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumeratorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            EnumeratorDemo2.Run();
            return;

            var array = new MyArray() { 1, 2, 3, 4, };

            var iterator1 = array.GetEnumerator();
            var iterator2 = array.GetEnumerator();
            var iterator3 = array.GetEnumerator();


            //Console.WriteLine($"it1: {iterator1.Current}");//

            iterator2.MoveNext();
            Console.WriteLine($"it2: {iterator2.Current}");//0

            iterator3.MoveNext();
            iterator3.MoveNext();
            Console.WriteLine($"it3: {iterator3.Current}");//1

            foreach (int i in array)
            {
                Console.WriteLine(i);
            }




            var iterator4 = array.GetEnumerator();
            try
            {
                while (iterator4.MoveNext())
                {
                    var i = iterator4.Current;
                    Console.WriteLine(i);
                    throw new Exception("asdasd");
                }
            }
            finally
            {
                iterator4.Dispose();
            }



            iterator1.Dispose();
            iterator2.Dispose();
            iterator3.Dispose();

        }
    }

    public class MyArray : IEnumerable<int>
    {
        List<int> myIntArray = new List<int>();

        public void Add(int i)
        {
            myIntArray.Add(i);
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new MyArrayEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class MyArrayEnumerator : IEnumerator<int>
        {
            private readonly MyArray myArray;

            public MyArrayEnumerator(MyArray myArray)
            {
                this.myArray = myArray;

            }

            public void Dispose()
            {

            }

            private int index = -1;

            public bool MoveNext()
            {
                if (index + 1 < myArray.myIntArray.Count)
                {
                    index++;

                    return true;
                }

                return false;

            }

            public void Reset()
            {

            }

            public int Current
            {
                get { return myArray.myIntArray[index]; }
            }

            object IEnumerator.Current => Current;
        }


    }
}
