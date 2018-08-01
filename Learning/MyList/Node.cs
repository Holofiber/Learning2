using System;
using System.Collections.Generic;

namespace MyListDemo
{
    public class Node<T>
    {
        public Node(T number)
        {
            Number = number;
        }

        public Node()
        {

        }

        public Node<T> InitialItem;

        public Node<T> FollowingItem;

        public Node(T number, Node<T> initialItem)
        {
            Number = number;
            InitialItem = initialItem;
        }

        public T Number;

        public override string ToString()
        {
            return Number.ToString();
        }
    }


}