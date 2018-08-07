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

        public int Count { get; }
        public bool IsReadOnly { get; }


        private void Add(T nodeValue, Node<T> node = null)
        {
            if (node == null)
            {
                if (RootNode == null)
                {
                    RootNode = new Node<T>();
                    RootNode.NodeNumber = nodeValue;
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

            nextNode.NodeNumber = nodeValue;
            nextNode.BackReference = node;

            if (node.NodeNumber.CompareTo(nodeValue) >= 1)
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


            return new MyEnumerator(RootNode);
        }


        /*public IEnumerator<T> GetMyEnumerator()
        {
            return new MyEnumerator(RootNode);
        }*/

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        class MyEnumerator : IEnumerator<T>
        {
            private Node<T> InitialNode;
            private Stack<(Node<T>, Side)> Nodes { get; set; } = new Stack<(Node<T>, Side)>();


            public MyEnumerator(Node<T> root)
            {
                InitialNode = root;
            }

            public void Dispose()
            {
            }


            private Node<T> CurrentNode;
            Side side = Side.None;

            public bool MoveNext()
            {
                if (side == Side.None)
                {
                    CurrentNode = InitialNode;
                }



                if (CurrentNode == null)
                {
                    return false;
                }

                // Current = CurrentNode.NodeNumber;

                while (CurrentNode != null)
                {


                    if (side == Side.None)
                    {
                        return MoveLeft();
                    }

                    if (side == Side.Right)
                    {
                        return MoveRight();
                    }

                    if (side == Side.Left)
                    {
                        return MoveLeft();
                    }


                    if (side == Side.Back)
                    {
                        CurrentNode = CurrentNode.BackReference;
                        Nodes.Push((CurrentNode, Side.Back));
                        Current = CurrentNode.NodeNumber;
                        side = Side.Right;
                        return true;
                    }




                }

                // (CurrentNode, side) = Nodes.Pop();

                return false;
            }

            private bool MoveLeft()
            {

                if (CurrentNode.LeftReference == null && CurrentNode.RightReference == null)
                {
                    return false;
                }
                while (CurrentNode.LeftReference != null)
                {
                    CurrentNode = CurrentNode.LeftReference;
                }

                side = Side.Back;
                Current = CurrentNode.NodeNumber;

                return true;
            }

            private bool MoveRight()
            {
                if (CurrentNode.RightReference != null)
                {
                    CurrentNode = CurrentNode.RightReference;
                    if (CurrentNode.LeftReference != null)
                    {
                        while (CurrentNode.LeftReference != null)
                        {
                            CurrentNode = CurrentNode.LeftReference;
                        }
                    }
                    else if (CurrentNode.RightReference != null)
                    {

                    }

                    Current = CurrentNode.NodeNumber;

                    return true;

                }
                //TODO  need change
                return true;
            }


            enum Side
            {
                None,
                Back,
                Left,
                Right
            }


            public void Reset()
            {
            }

            public T Current
            {
                get { return InitialNode.NodeNumber; }
                set => InitialNode.NodeNumber = value;
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }
        }
    }
}