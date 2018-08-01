using System;
using System.Collections;
using System.Collections.Generic;

namespace MyListDemo
{
    public class MyList<T> : ICollection<T>, IList<T>
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
                tail.NextNode = node;


                node.PrevNode = tail;

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

                yield return currentNode.Item;

                currentNode = currentNode.NextNode;
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

                yield return currentNode.Item;

                currentNode = currentNode.PrevNode;
            }

        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }



        public void Clear()
        {
            head = null;
            count = 0;
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
            private set { }
        }

        public bool IsReadOnly { get; }

        public int IndexOf(T item)
        {
            var tempNode = head;
            int i = 0;
            while (true)
            {
                if (item.Equals(tempNode.Item))
                {
                    return i;
                }
                else
                {
                    i++;
                    if (tempNode.NextNode == null)
                    {
                        return -1;
                        break;
                    }
                    tempNode = tempNode.NextNode;
                }

            }
        }

        public void Insert(int index, T item)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new System.NotImplementedException();
        }

        public T this[int index]
        {
            get => default(T); set => new System.NotImplementedException();
        }
    }
}

