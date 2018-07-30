using System;
using BinaryTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryTreeTest
{
    [TestClass]
    public class UnitTest1
    {
        Tree tree = new Tree();
        Node node = new Node();

        [TestMethod]
        public void AddTest()
        {
            tree.Add(10);

            Assert.AreEqual(tree.RootNode.NodeNumber, 10);
        }

        [TestMethod]
        public void AddNumber_To_Left_Tree_Test()
        {
            node.NodeNumber = 15;
            tree.RootNode = node;

            tree.Add(7);

            Assert.AreEqual(tree.RootNode.LeftReference.NodeNumber, 7);
        }

        [TestMethod]
        public void Add_2_Numbers_To_Left_Tree_Test()
        {
            node.NodeNumber = 15;
            tree.RootNode = node;

            tree.Add(7);
            tree.Add(5);
            tree.Add(4);

            Assert.AreEqual(tree.RootNode.LeftReference.LeftReference.NodeNumber, 5);
        }

        [TestMethod]
        public void Add_Number_To_Right_Tree_Test()
        {
            node.NodeNumber = 15;
            tree.RootNode = node;

            tree.Add(20);


            Assert.AreEqual(tree.RootNode.RightReference.NodeNumber, 20);
        }

        [TestMethod]
        public void Add_2_Numbers_To_Right_Tree_Test()
        {
            node.NodeNumber = 15;
            tree.RootNode = node;

            tree.Add(20);
            tree.Add(18);

            Assert.AreEqual(tree.RootNode.RightReference.LeftReference.NodeNumber, 18);
        }

        [TestMethod]
        public void Clean_Test()
        {
            tree.Add(20);
            tree.Add(14);
            tree.Add(34);

            tree.Clear();

            Assert.IsNull(tree.RootNode);
        }
    }
}
