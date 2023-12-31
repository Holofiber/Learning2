﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDListDemo;

namespace MyListTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DList<int> list = new DList<int>();

            list.Add(10);

            list.head.Item.Should().Be(10);
            list.head.NextNode.Should().BeNull();
            list.head.PrevNode.Should().BeNull();
        }

        [TestMethod]
        public void TestMethod2()
        {
            DList<int> list = new DList<int>();

            list.Add(10);
            list.Add(11);

            list.head.Item.Should().Be(10);
            list.head.NextNode.Item.Should().Be(11);
            list.head.NextNode.PrevNode.Should().Be(list.head);
        }

        [TestMethod]
        public void TestMethod3()
        {
            DList<int> list = new DList<int>();


            list.Add(10);
            list.Add(11);
            list.Add(12);
            list.Add(13);
            list.Add(14);


            list.head.Item.Should().Be(10);
            list.head.NextNode.Item.Should().Be(11);
            list.head.NextNode.NextNode.Item.Should().Be(12);
            list.head.NextNode.NextNode.NextNode.Item.Should().Be(13);
            list.head.NextNode.NextNode.NextNode.NextNode.Item.Should().Be(14);

            list.head.NextNode.PrevNode.Item.Should().Be(10);
            list.head.NextNode.NextNode.PrevNode.Item.Should().Be(11);
            list.head.NextNode.NextNode.NextNode.PrevNode.Item.Should().Be(12);
            list.head.NextNode.NextNode.NextNode.NextNode.PrevNode.Item.Should().Be(13);
        }
    }
}
