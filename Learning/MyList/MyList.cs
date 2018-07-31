using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyListDemo
{
    public class MyList : IEnumerable<int>
    {
        public Node head;
        private Node tail;
        private int Count;

        public MyList()
        {

        }

        public void Add(int value)
        {
            Node node = new Node(value);

            if (head == null)
            {

                head = node;
            }
            else
            {
                tail.FollowingItem = node;

                node.InitialItem = tail;

            }

            tail = node;
            Count++;
        }


        public IEnumerator<int> GetEnumerator()
        {

            return new CustomIterator(this);
        }

        public IEnumerator<int> GetEnumeratorSecond()
        {

            return new CustomIterator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public class CustomIterator : IEnumerator<int>, IEnumerator, IDisposable
        {
            internal CustomIterator(MyList container)
            {
                this.container = container;
                currentNode = null;

            }

            public void Reset()
            {

            }

            object IEnumerator.Current => Current;


            public int Current
            {
                get
                {
                    if (currentNode == null)
                    {
                        throw new InvalidOperationException();
                    }
                    return currentNode.Number;
                }

            }



            public bool MoveNext()
            {
                if (currentNode == null)
                {
                    currentNode = container.head;
                }
                if (currentNode.FollowingItem != null)
                {
                    currentNode = currentNode.FollowingItem;
                    return true;
                }
                return false;
            }


            private Node currentNode;
            private MyList container;

            public void Dispose()
            {

            }
        }

    }
}

