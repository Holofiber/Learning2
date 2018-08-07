using System;
using System.Collections.Generic;

namespace MyDListDemo
{
    public class Node<T>
    {
        public Node(T item)
        {
            Item = item;
        }

        public Node()
        {

        }

        public Node<T> PrevNode;

        public Node<T> NextNode;



        public Node(T item, Node<T> prevNode)
        {
            Item = item;
            PrevNode = prevNode;
        }

        public T Item;

        public override string ToString()
        {
            return Item.ToString();
        }
    }


}