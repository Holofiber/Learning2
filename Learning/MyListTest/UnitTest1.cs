using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyListDemo;

namespace MyListTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            MyList<int> list = new MyList<int>();

            list.Add(10);

            list.head.Item.Should().Be(10);
            list.head.FollowingItem.Should().BeNull();
            list.head.InitialItem.Should().BeNull();
        }

        [TestMethod]
        public void TestMethod2()
        {
            MyList<int> list = new MyList<int>();

            list.Add(10);
            list.Add(11);

            list.head.Item.Should().Be(10);
            list.head.FollowingItem.Item.Should().Be(11);
            list.head.FollowingItem.InitialItem.Should().Be(list.head);
        }

        [TestMethod]
        public void TestMethod3()
        {
            MyList<int> list = new MyList<int>();


            list.Add(10);
            list.Add(11);
            list.Add(12);
            list.Add(13);
            list.Add(14);


            list.head.Item.Should().Be(10);
            list.head.FollowingItem.Item.Should().Be(11);
            list.head.FollowingItem.FollowingItem.Item.Should().Be(12);
            list.head.FollowingItem.FollowingItem.FollowingItem.Item.Should().Be(13);
            list.head.FollowingItem.FollowingItem.FollowingItem.FollowingItem.Item.Should().Be(14);

            list.head.FollowingItem.InitialItem.Item.Should().Be(10);
            list.head.FollowingItem.FollowingItem.InitialItem.Item.Should().Be(11);
            list.head.FollowingItem.FollowingItem.FollowingItem.InitialItem.Item.Should().Be(12);
            list.head.FollowingItem.FollowingItem.FollowingItem.FollowingItem.InitialItem.Item.Should().Be(13);
        }
    }
}
