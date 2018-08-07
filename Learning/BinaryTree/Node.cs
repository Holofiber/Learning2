using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTree
{
    public class Node<T> where T : IComparable<T>
    {
        public T NodeNumber;
        public Node<T> BackReference;
        public Node<T> LeftReference;
        public Node<T> RightReference;
       
       
    }

   
    
}