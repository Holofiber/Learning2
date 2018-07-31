using System;
using System.Collections.Generic;
using BinaryTree;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryTreeTest
{
    [TestClass]
    public class MyEnumeratorTest
    {
        [TestMethod]
        public void EmpptyTree_Test()
        {
            Tree tree = new Tree();

            var enumur = tree.GetEnumerator();

            var moveNextResult = enumur.MoveNext();

            moveNextResult.Should().BeFalse();
        }

        [TestMethod]
        public void Tree_With_Only_Root_Test()
        {
            Tree tree = new Tree();

            tree.Add(10);

            var enumerator = tree.GetEnumerator();

            enumerator.MoveNext().Should().BeTrue();

            enumerator.Current.Should().Be(10);

            enumerator.MoveNext().Should().BeFalse();
            
        }

       /* [TestMethod]
        public void Tree_With_Left_Node_Test()
        {
            Tree tree = new Tree();

            tree.Add(10);
            tree.Add(7);

            var enumerator = tree.GetEnumerator();

            enumerator.MoveNext();

            enumerator.Current.Should().Be(7);
        }*/
    }
}
