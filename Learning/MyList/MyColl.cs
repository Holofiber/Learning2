﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace MyList
{
    public class MyColl<T> : IEnumerable<T>
    {
        public MyColl(T[] items)
        {
            this.items = items;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new NestedEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        class NestedEnumerator : IEnumerator<T>
        {
            public NestedEnumerator(MyColl<T> coll)
            {
                Monitor.Enter(coll.items.SyncRoot);
                this.index = -1;
                this.coll = coll;
            }

            public T Current
            {
                get { return current; }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public bool MoveNext()
            {
                if (++index >= coll.items.Length)
                {
                    return false;
                }
                else
                {
                    current = coll.items[index];
                    return true;
                }
            }

            public void Reset()
            {
                current = default(T);
                index = 0;
            }

            public void Dispose()
            {

                try
                {
                    current = default(T);
                    index = coll.items.Length;
                }
                finally
                {
                    Monitor.Exit(coll.items.SyncRoot);
                }

            }

            private MyColl<T> coll;
            private T current;
            private int index;
        }
        private T[] items;
    }
}
