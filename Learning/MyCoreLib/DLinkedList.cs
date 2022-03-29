using System.Collections;

namespace MyCoreLib
{
    public class DLinkedList<T> : IList<T>, ICollection<T>, IEnumerable<T>
    {
        public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsReadOnly => throw new NotImplementedException();

        private Node<T> Head { get; set; }
        private Node<T> Tail { get; set; }

        public int Count { get; private set; }

        public DLinkedList()
        {
            Count = 0;
        }

        public DLinkedList(IEnumerable<T> collection) : this()
        {
            foreach (var item in collection)
            {
                this.AddLast(item);
            }
        }

        public void AddLast(T item)
        {
            var temp = new Node<T>(item);

            if (Count == 0)
            {
                Head = temp;

                Tail = temp;

                Count++;
            }
            else
            {
                Tail.Next = temp;
                temp.Prev = Tail;
                Tail = temp;

                Count++;
            }

        }

        public void AddFirst(T item)
        {
            var temp = new Node<T>(item);

            if (Count == 0)
            {
                Head = temp;

                Tail = temp;

                Count++;
            }
            else
            {
                Head.Prev = temp;
                temp.Next = Head;
                Head = temp;

                Count++;
            }
        }

        public void Add(T item)
        {
            AddLast(item);
        }

        public void Clear()
        {
            Count = 0;
            Head = null;
            Tail = null;
        }

        public bool Contains(T item)
        {
            foreach (var val in this)
            {
                if (val.Equals(item))
                    return true;
            }

            return false;
        }

        public void CopyTo(T[] array)
        {
            CopyTo(array, 0);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var current = Head;

            for (int i = arrayIndex; i < array.Length; i++)
            {
                if (current == null)
                    break;

                array[i] = current.Value;

                current = current.Next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;

            while (current != null)
            {
                yield return current.Value;

                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<T> Reverse()
        {
            var current = Tail;

            while (current != null)
            {
                yield return current.Value;

                current = current.Prev;
            }
        }

        private IEnumerator<Node<T>> GetNodeEnumerator()
        {
            var current = Head;

            while (current != null)
            {
                yield return current;

                current = current.Next;
            }
        }

        public int IndexOf(T item)
        {
            var current = Head;
            int count = 0;            

            while(current != null)
            {
                if (current.Value.Equals(item))
                    break;
                    
                current = current.Next;
                count++;
            }

            if (count == Count)
            {
                return -1;
            }

            return count;
        }

        public void Insert(int index, T item)
        {
            var current = Head;
            var temp = new Node<T>(item);

            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            var prev = current.Prev;

            if (prev!=null)            
            prev.Next = temp;
            temp.Prev = prev;

            current.Prev = temp;
            temp.Next = current;
        }

        public bool Remove(T item)
        {
            var node = GetNodeEnumerator();

            while (node.MoveNext())
            {
                if (node.Current.Value.Equals(item))
                {
                    if (node.Current == Head && node.Current == Tail)
                    {
                        Head = null;
                        Tail = null;                        
                    }

                    if (node.Current.Prev != null)
                    {
                        if (node.Current.Next == null)
                        {
                            node.Current.Prev.Next = null;
                            Tail = node.Current.Prev;
                        }
                        else
                        {
                            node.Current.Prev.Next = node.Current.Next;
                        }
                    }

                    if (node.Current.Next != null)
                    {

                        if (node.Current.Prev == null)
                        {
                            node.Current.Next.Prev = null;
                            Head = node.Current.Next;
                        }
                        else
                        {
                            node.Current.Next.Prev = node.Current.Prev;
                        }
                    }

                    Count--;

                    return true;
                }
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            var current = Head;            

            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            current.Prev.Next = current.Next;
            current.Next.Prev = current.Prev;
            Count--;
        }

        private class Node<T>
        {
            private T item;

            public Node(T item)
            {
                this.item = item;
            }

            public Node<T> Prev { get; set; }

            public Node<T> Next { get; set; }

            public T Value { get => item; private set => value = item; }
        }
    }
}
