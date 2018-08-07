using System;
using System.Collections;
using System.Collections.Generic;

namespace MyListDemo
{
    public class MyList<T> : IList<T>
    {
        public Node<T> head;
        public Node<T> tail;
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

        public IEnumerable<T> GetEnumeratorReverse()
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
            if (head == null)
            {
                return false;
            }
            var tempNode = head;

            while (true)
            {

                if (item.Equals(tempNode.Item))
                {
                    return true;
                }


                if (tempNode.NextNode == null)
                {
                    return false;
                    break;
                }
                tempNode = tempNode.NextNode;


            }
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var tempNode = head;

            for (int j = 0; j < arrayIndex; j++)
            {
                if (tempNode != null)
                {
                    array[j] = tempNode.Item;
                    tempNode = tempNode.NextNode;
                }
                else
                {
                    break;
                }
            }

        }

        public bool Remove(T item)
        {
            if (head == null)
            {
                return false;
            }
            var tempNode = head;

            while (true)
            {

                if (item.Equals(tempNode.Item))
                {
                    tempNode.PrevNode.NextNode = tempNode.NextNode;
                    tempNode.NextNode.PrevNode = tempNode.PrevNode;
                    count--;
                    head = tempNode;

                    return true;

                }



                if (tempNode.NextNode == null)
                {
                    return false;
                    break;
                }
                tempNode = tempNode.NextNode;


            }
        }

        public int Count
        {
            get => Count = count;
            private set { }
        }

        public bool IsReadOnly { get; }

        public int IndexOf(T item)
        {
            if (head == null)
            {
                return -1;
            }

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
            get => this._getElementAt(index);
            set => this._setElementAt(index, value);
        }

        private void _setElementAt(int index, T value)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException("List is empty.");

            if (index == 0)
            {
                head.Item = value;
            }
            else if (index == (Count - 1))
            {
                tail.Item = value;
            }
            else
            {
                Node<T> currentNode = null;


                if (index > (Count / 2))
                {
                    currentNode = this.tail;
                    for (int i = (Count - 1); i > index; --i)
                    {
                        currentNode = currentNode.PrevNode;
                    }
                }
                else
                {
                    currentNode = this.head;
                    for (int i = 0; i < index; ++i)
                    {
                        currentNode = currentNode.NextNode;
                    }
                }

                currentNode.Item = value;
            }
        }

        private T _getElementAt(int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException("List is empty.");

            if (index == 0)
            {
                return head.Item;
            }

            if (index == (Count - 1))
            {
                return tail.Item;
            }

            Node<T> currentNode = null;


            if (index > (Count / 2))
            {
                currentNode = this.tail;
                for (int i = (Count - 1); i > index; --i)
                {
                    currentNode = currentNode.PrevNode;
                }
            }
            else
            {
                currentNode = this.head;
                for (int i = 0; i < index; ++i)
                {
                    currentNode = currentNode.NextNode;
                }
            }

            return currentNode.Item;
        }
    }
}

