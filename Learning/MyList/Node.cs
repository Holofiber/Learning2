using System;
using System.Collections.Generic;

namespace MyListDemo
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

        public Node<T> InitialItem;

        public Node<T> FollowingItem;



        public Node(T item, Node<T> initialItem)
        {
            Item = item;
            InitialItem = initialItem;
        }

        public T Item;

        public override string ToString()
        {
            return Item.ToString();
        }
    }


}