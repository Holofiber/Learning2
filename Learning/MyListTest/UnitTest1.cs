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
            MyList list = new MyList();

            list.Add(10);

            list.head.Number.Should().Be(10);
            list.head.FollowingItem.Should().BeNull();
            list.head.InitialItem.Should().BeNull();
        }

        [TestMethod]
        public void TestMethod2()
        {
            MyList list = new MyList();

            list.Add(10);
            list.Add(11);

            list.head.Number.Should().Be(10);
            list.head.FollowingItem.Number.Should().Be(11);
            list.head.FollowingItem.InitialItem.Should().Be(list.head);
        }

        [TestMethod]
        public void TestMethod3()
        {
            MyList list = new MyList();


            list.Add(10);
            list.Add(11);
            list.Add(12);
            list.Add(13);
            list.Add(14);
            

            list.head.Number.Should().Be(10);
            list.head.FollowingItem.Number.Should().Be(11);
            list.head.FollowingItem.FollowingItem.Number.Should().Be(12);
            list.head.FollowingItem.FollowingItem.FollowingItem.Number.Should().Be(13);
            list.head.FollowingItem.FollowingItem.FollowingItem.FollowingItem.Number.Should().Be(14);

            list.head.FollowingItem.InitialItem.Number.Should().Be(10);
            list.head.FollowingItem.FollowingItem.InitialItem.Number.Should().Be(11);
            list.head.FollowingItem.FollowingItem.FollowingItem.InitialItem.Number.Should().Be(12);
            list.head.FollowingItem.FollowingItem.FollowingItem.FollowingItem.InitialItem.Number.Should().Be(13);
        }
    }
}
