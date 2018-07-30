using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Enumeraots
{
    public class MyColl<T> : IEnumerable<T>
    {
        public MyColl(T[] items)
        {
            this.items = items;
        }

        public IEnumerator<T> GetEnumerator(bool synchronized)
        {
            if (synchronized)
            {
                Monitor.Enter(items.SyncRoot);
            }

            try
            {
                int index = 0;
                while (true)
                {
                    if (index < items.Length)
                    {
                        yield return items[index++];
                    }
                    else
                    {
                        yield break;
                    }
                }
            }
            finally
            {
                if (synchronized)
                {
                    Monitor.Exit(items.SyncRoot);
                }
            }
        }
       

        private T[] items;
        public IEnumerator<T> GetEnumerator()
        {
            return GetEnumerator(false);
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}


