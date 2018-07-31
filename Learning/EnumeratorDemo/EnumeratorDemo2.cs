using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumeratorDemo
{
    public class EnumeratorDemo2
    {
        public static void Run()
        {
            //var it1 = MagicNumbers();
            //var it2 = MagicNumbers();
            var it1 = new MagicEnum();
            var it2 = new MagicEnum();


            it1.MoveNext();

            it2.MoveNext();
            it2.MoveNext();


            Console.WriteLine(it1.Current);
            Console.WriteLine(it2.Current);
        }






        public static IEnumerator<int> MagicNumbers()
        {
            yield return 7;
            yield return 42;
            yield return 666;
        }


        public class MagicEnum : IEnumerator<int>
        {
            private int state = -1;
            

            public void Dispose()
            {
                
            }

            public bool MoveNext()
            {

                switch (state)
                {
                    case -1:
                        state = 1;
                        Current = 7;
                        return true;
                        break;
                    case 1:
                        state = 2;
                        Current = 42;
                        return true;
                        break;
                    case 2:
                        state = 3;
                        Current = 666;
                        return true;
                        break;
                    case 3:
                        state = 4;
                        return false;
                        break;
                }

                return false;


            }

            public void Reset()
            {
            }

            public int Current { get; private set; }

            object IEnumerator.Current => Current;
        }

    }






}
