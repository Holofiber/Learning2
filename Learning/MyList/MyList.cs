using System.Collections;
using System.Collections.Generic;

namespace MyListDemo
{
    public class MyList<T> : ICollection<T>
    {
        public Node<T> head;
        private Node<T> tail;
        private int count;
        private T[] items;

        public MyList()
        {
            
        }

        public void Add(T value)
        {
            Node<T> node = new Node<T>(value);

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
            count++;
        }

        public MyList(T[] items)
        {
            this.items = items;
        }
         IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = head;

            while (true)
            {
                if (currentNode == null)
                {
                    yield break;
                }

                yield return currentNode.Number;

                currentNode = currentNode.FollowingItem;
            }

        }

        public IEnumerator<T> GetEnumeratorReverse()
        {
            var currentNode = tail;

            while (true)
            {
                if (currentNode == null)
                {
                    yield break;
                }

                yield return currentNode.Number;

                currentNode = currentNode.InitialItem;
            }

        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        

        public void Clear()
        {
            
        }

        public bool Contains(T item)
        {
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            
        }

        public bool Remove(T item)
        {
            return false;
        }

        public int Count
        {
            get => Count = count;
            private set {}
        }

        public bool IsReadOnly { get; }
    }
}

