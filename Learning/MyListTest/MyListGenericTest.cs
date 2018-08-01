using System;
using System.Text;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyListDemo;

namespace MyListTest
{
    [TestClass]
    public class MyListGenericTest
    {


        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void String_Type_Test()
        {
            MyList<string> list = new MyList<string>();

            list.Add("A");

            list.head.Item.Should().Be("A");
            list.head.FollowingItem.Should().BeNull();
            list.head.InitialItem.Should().BeNull();
        }

        [TestMethod]
        public void String_Type_Test2()
        {
            MyList<string> list = new MyList<string>();


            list.Add("A");
            list.Add("B");
            list.Add("C");
            list.Add("W");
            list.Add("Z");


            list.head.Item.Should().Be("A");
            list.head.FollowingItem.Item.Should().Be("B");
            list.head.FollowingItem.FollowingItem.Item.Should().Be("C");
            list.head.FollowingItem.FollowingItem.FollowingItem.Item.Should().Be("W");
            list.head.FollowingItem.FollowingItem.FollowingItem.FollowingItem.Item.Should().Be("Z");

            list.head.FollowingItem.InitialItem.Item.Should().Be("A");
            list.head.FollowingItem.FollowingItem.InitialItem.Item.Should().Be("B");
            list.head.FollowingItem.FollowingItem.FollowingItem.InitialItem.Item.Should().Be("C");
            list.head.FollowingItem.FollowingItem.FollowingItem.FollowingItem.InitialItem.Item.Should().Be("W");
        }

        [TestMethod]
        public void Float_Type_Test()
        {
            MyList<float> list = new MyList<float>();

            list.Add(0.000000000000000000000000000000000000000000001f);
            // 45 ззнаків після коми, не точно показує

            list.head.Item.Should().Be(0.000000000000000000000000000000000000000000002f);
            list.head.FollowingItem.Should().BeNull();
            list.head.InitialItem.Should().BeNull();
        }

        [TestMethod]
        public void Float_Type_Test2()
        {
            MyList<float> list = new MyList<float>();


            list.Add(0.0000000001f);
            list.Add(0.0000000002f);
            list.Add(0.0000000003f);
            list.Add(0.0000000004f);
            list.Add(0.0000000005f);


            list.head.Item.Should().Be(0.0000000001f);
            list.head.FollowingItem.Item.Should().Be(0.0000000002f);
            list.head.FollowingItem.FollowingItem.Item.Should().Be(0.0000000003f);
            list.head.FollowingItem.FollowingItem.FollowingItem.Item.Should().Be(0.0000000004f);
            list.head.FollowingItem.FollowingItem.FollowingItem.FollowingItem.Item.Should().Be(0.0000000005f);

            list.head.FollowingItem.InitialItem.Item.Should().Be(0.0000000001f);
            list.head.FollowingItem.FollowingItem.InitialItem.Item.Should().Be(0.0000000002f);
            list.head.FollowingItem.FollowingItem.FollowingItem.InitialItem.Item.Should().Be(0.0000000003f);
            list.head.FollowingItem.FollowingItem.FollowingItem.FollowingItem.InitialItem.Item.Should().Be(0.0000000004f);
        }

        [TestMethod]
        public void Double_Type_Test()
        {
            MyList<double> list = new MyList<double>();

            list.Add(0.0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001);
            //100500 over знаків і тест фейлить, якщо змінити останній знак

            list.head.Item.Should().Be(0.0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001);
            list.head.FollowingItem.Should().BeNull();
            list.head.InitialItem.Should().BeNull();
        }
    }
}
