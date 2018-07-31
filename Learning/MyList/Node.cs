using System;
using System.Collections.Generic;

namespace MyListDemo
{
    public class Node
    {
        public Node(int number)
        {
            Number = number;
        }

        public Node()
        {
            
        }

        public Node InitialItem;

        public Node FollowingItem;

        public Node(int number, Node initialItem)
        {
            Number = number;
            InitialItem = initialItem;
        }

        public int Number;

        public override string ToString()
        {
            return Number.ToString();
        }
    }


}