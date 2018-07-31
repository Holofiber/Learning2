namespace BinaryTree
{
    public class Node
    {
        public int NodeNumber;
        public Node BackReference;
        public Node LeftReference;
        public Node RightReference;

        public override string ToString()
        {
            return NodeNumber.ToString();
        }
    }
}