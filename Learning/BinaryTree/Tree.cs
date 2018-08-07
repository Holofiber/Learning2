using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace BinaryTree
{
    public class Tree<T> : ICollection<T> where T : IComparable<T>
    {
        private Node<T> RootNode;

        public void Add(T item)
        {
            Add(item, RootNode);
            Count++;
        }

        public void Clear()
        {
            RootNode = null;
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public int Count { get; set; }

        public bool IsReadOnly { get; }


        private void Add(T nodeValue, Node<T> node = null)
        {
            if (node == null)
            {
                if (RootNode == null)
                {
                    RootNode = new Node<T>();
                    RootNode.Value = nodeValue;
                }
                else
                {
                    node = RootNode;
                    NodesReview(node, nodeValue);
                }
            }
            else
            {
                NodesReview(node, nodeValue);
            }
        }

        private void NodesReview(Node<T> node, T nodeValue)
        {
            Node<T> nextNode = new Node<T>();

            nextNode.Value = nodeValue;
            nextNode.BackReference = node;

            if (node.Value.CompareTo(nodeValue) >= 1)
            {
                if (node.LeftReference == null)
                {
                    node.LeftReference = nextNode;
                    nextNode.BackReference = node;
                }
                else
                {
                    Add(nodeValue, node.LeftReference);
                }
            }
            else
            {
                if (node.RightReference == null)
                {
                    node.RightReference = nextNode;
                    nextNode.BackReference = node;
                }
                else
                {
                    Add(nodeValue, node.RightReference);
                }
            }
        }


        public IEnumerator<T> GetEnumerator()
        {
            if (RootNode == null)
                yield break;

            foreach (var item in RootNode)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public class Node<T> : IEnumerable<T>
        {
            public T Value;
            public Node<T> BackReference;
            public Node<T> LeftReference;
            public Node<T> RightReference;
            public IEnumerator<T> GetEnumerator()
            {
                if (LeftReference != null)
                {
                    foreach (var item in LeftReference)
                    {
                        yield return item;
                    }
                }

                yield return Value;

                if (RightReference != null)
                {
                    foreach (var item in RightReference)
                    {
                        yield return item;
                    }
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

        }
    }
}