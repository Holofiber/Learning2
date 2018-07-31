using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTree
{
    public class Tree : IEnumerable<int>
    {
        private Node RootNode;

        public void Clear()
        {
            RootNode = null;
        }

       

        public void Add(int number, Node node = null)
        {
            if (node == null)
            {
                if (RootNode == null)
                {
                    RootNode = new Node();
                    RootNode.NodeNumber = number;
                }
                else
                {
                    node = RootNode;
                    NodesReview(node, number);
                }
            }
            else
            {
                NodesReview(node, number);
            }
        }

        private void NodesReview(Node node, int number)
        {
            Node nextNode = new Node();

            nextNode.NodeNumber = number;
            nextNode.BackReference = node;

            if (node.NodeNumber > number)
            {
                if (node.LeftReference == null)
                {
                    node.LeftReference = nextNode;
                }
                else
                {
                    Add(number, node.LeftReference);
                }
            }
            else
            {
                if (node.RightReference == null)
                {
                    node.RightReference = nextNode;
                }
                else
                {
                    Add(number, node.RightReference);
                }
            }
        }


        public IEnumerator<int> GetEnumerator()
        {


            throw new NotImplementedException();
        }





        public IEnumerator<int> GetMyEnumerator()
        {
            return new MyEnumerator(RootNode);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        class MyEnumerator : IEnumerator<int>
        {
            private Node InitialNode;
            private Stack<(Node, Side)> Nodes { get; set; } = new Stack<(Node, Side)>();


            public MyEnumerator(Node root)
            {
                InitialNode = root;
            }

            public void Dispose()
            {
            }


            private Node CurrentNode;
            Side side = Side.None;

            public bool MoveNext()
            {
                CurrentNode = InitialNode;


                if (CurrentNode == null)
                {
                    return false;
                }


                while (CurrentNode != null)
                {
                    if (side == Side.None)
                    {
                        Nodes.Push((CurrentNode, Side.Left));
                        CurrentNode = CurrentNode.LeftReference;
                        side = Side.None;
                        continue;
                    }

                    if (side == Side.Left)
                    {
                        Nodes.Push((CurrentNode, Side.Right));
                        CurrentNode = CurrentNode.RightReference;
                    }
                }

                (CurrentNode, side) = Nodes.Pop();

                Current = CurrentNode.NodeNumber;

                return true;


                //if left side !=null move to left
                // if left side == null move to root
                // if right side != null move to right
                // else end

                Current = CurrentNode.NodeNumber;


                return true;
            }


            enum Side
            {
                None,
                Left,
                Right
            }


            public void Reset()
            {
            }

            public int Current { get; private set; }

            object IEnumerator.Current
            {
                get { return Current; }
            }
        }
    }
}