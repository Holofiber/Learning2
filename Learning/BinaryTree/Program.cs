using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class Program
    {
        static void Main(string[] args)
        {

            Tree tree = new Tree();
            tree.Add(15);
            tree.Add(10);
            tree.Add(5);
            tree.Add(20);
            tree.Add(8);

        }
    }



    public class Node
    {
        public int NodeNumber;
        public Node BackReference;
        public Node LeftReference;
        public Node RightReference;
    }

    public class Nodes
    {
        public Node Node;
        public Nodes(Node node)
        {
            Node = node;
        }

        public Node GetNode()
        {
            return Node;

        }
    }

    public class Tree
    {
        private Node RootNode;

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
    }




}
