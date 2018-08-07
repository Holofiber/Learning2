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
            ICollection<int> tree = new Tree<int>();

            var enumur = tree.GetEnumerator();

            var moveNextResult = enumur.MoveNext();

            moveNextResult.Should().BeFalse();
        }

        [TestMethod]
        public void Tree_With_Only_Root_Test()
        {
            ICollection<int> tree = new Tree<int>();


            tree.Add(10);

            var enumerator = tree.GetEnumerator();

            enumerator.MoveNext().Should().BeTrue();

            enumerator.Current.Should().Be(10);

            enumerator.MoveNext().Should().BeFalse();

        }

        [TestMethod]
        public void Add_Value_Check_Sorting_Test()
        {
            ICollection<int> tree = new Tree<int>();

            tree.Add(20);
            tree.Add(10);
            tree.Add(30);
            tree.Add(5);
            tree.Add(15);
            tree.Add(25);
            tree.Add(35);



            var enumerator = tree.GetEnumerator();

            enumerator.MoveNext().Should().BeTrue();
            enumerator.Current.Should().Be(5);

            enumerator.MoveNext().Should().BeTrue();
            enumerator.Current.Should().Be(10);

            enumerator.MoveNext().Should().BeTrue();
            enumerator.Current.Should().Be(15);

            enumerator.MoveNext().Should().BeTrue();
            enumerator.Current.Should().Be(20);

            enumerator.MoveNext().Should().BeTrue();
            enumerator.Current.Should().Be(25);

            enumerator.MoveNext().Should().BeTrue();
            enumerator.Current.Should().Be(30);

            enumerator.MoveNext().Should().BeTrue();
            enumerator.Current.Should().Be(35);

            enumerator.MoveNext().Should().BeFalse();
        }


        [TestMethod]
        public void Sorting_Tree_Test()
        {
            ICollection<int> tree = new Tree<int>() { 20, 30, 35, 25, 10, 5, 15 };

            List<int> list = new List<int>() { 20, 30, 35, 25, 10, 5, 15 };
            list.Sort();

            List<int> sortFromTree = new List<int>();

            foreach (var i in tree)
            {
                sortFromTree.Add(i);
            }

            for (int i = 0; i < list.Count; i++)
            {
                sortFromTree[i].Should().Be(list[i]);
            }
        }

        [TestMethod]
        public void Tree_Count_Test()
        {
            ICollection<int> tree = new Tree<int>() { 20, 30, 35, 25, 10, 5, 15 };

            tree.Count.Should().Be(7);

        }

    }
}
