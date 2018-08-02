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
            list.head.NextNode.Should().BeNull();
            list.head.PrevNode.Should().BeNull();
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
            list.head.NextNode.Item.Should().Be("B");
            list.head.NextNode.NextNode.Item.Should().Be("C");
            list.head.NextNode.NextNode.NextNode.Item.Should().Be("W");
            list.head.NextNode.NextNode.NextNode.NextNode.Item.Should().Be("Z");

            list.head.NextNode.PrevNode.Item.Should().Be("A");
            list.head.NextNode.NextNode.PrevNode.Item.Should().Be("B");
            list.head.NextNode.NextNode.NextNode.PrevNode.Item.Should().Be("C");
            list.head.NextNode.NextNode.NextNode.NextNode.PrevNode.Item.Should().Be("W");
        }

        [TestMethod]
        public void Float_Type_Test()
        {
            MyList<float> list = new MyList<float>();

            list.Add(0.000000000000000000000000000000000000000000001f);
            // 45 ззнаків після коми, не точно показує

            list.head.Item.Should().Be(0.000000000000000000000000000000000000000000002f);
            list.head.NextNode.Should().BeNull();
            list.head.PrevNode.Should().BeNull();
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
            list.head.NextNode.Item.Should().Be(0.0000000002f);
            list.head.NextNode.NextNode.Item.Should().Be(0.0000000003f);
            list.head.NextNode.NextNode.NextNode.Item.Should().Be(0.0000000004f);
            list.head.NextNode.NextNode.NextNode.NextNode.Item.Should().Be(0.0000000005f);

            list.head.NextNode.PrevNode.Item.Should().Be(0.0000000001f);
            list.head.NextNode.NextNode.PrevNode.Item.Should().Be(0.0000000002f);
            list.head.NextNode.NextNode.NextNode.PrevNode.Item.Should().Be(0.0000000003f);
            list.head.NextNode.NextNode.NextNode.NextNode.PrevNode.Item.Should().Be(0.0000000004f);
        }

        [TestMethod]
        public void Double_Type_Test()
        {
            MyList<double> list = new MyList<double>();

            list.Add(0.0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001);
            //100500 over знаків і тест фейлить, якщо змінити останній знак

            list.head.Item.Should().Be(0.0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001);
            list.head.NextNode.Should().BeNull();
            list.head.PrevNode.Should().BeNull();
        }

        [TestMethod]
        public void Count_Test()
        {
            MyList<string> list = new MyList<string>();


            list.Add("1");
            list.Add("2");
            list.Add("3");
            list.Add("4");
            list.Add("5");

            list.Count.Should().Be(5);

            int z = 0;

            for (int i = 1; i <= list.Count; i++)
            {
                z = i;
            }

            z.Should().Be(5);
        }

        [TestMethod]
        public void Clear_Test()
        {
            MyList<string> list = new MyList<string>();


            list.Add("A");
            list.Add("B");
            list.Add("C");
            list.Add("W");
            list.Add("Z");

            list.Count.Should().Be(5);


            list.head.Item.Should().Be("A");
            list.head.NextNode.Item.Should().Be("B");
            list.head.NextNode.NextNode.Item.Should().Be("C");
            list.head.NextNode.NextNode.NextNode.Item.Should().Be("W");
            list.head.NextNode.NextNode.NextNode.NextNode.Item.Should().Be("Z");

            list.Clear();

            list.head.Should().BeNull();
            list.Count.Should().Be(0);
        }

        [TestMethod]
        public void Contains_Test()
        {
            MyList<string> list = new MyList<string>();


            list.Add("A");
            list.Add("B");
            list.Add("C");
            list.Add("W");
            list.Add("Z");

            list.Contains("A").Should().BeTrue();
            list.Contains("a").Should().BeFalse();
            list.Contains("R").Should().BeFalse();
            list.Contains("W").Should().BeTrue();
        }

        [TestMethod]
        public void IndexOf_Test()
        {
            MyList<string> list = new MyList<string>();


            list.Add("A");
            list.Add("B");
            list.Add("C");
            list.Add("W");
            list.Add("Z");

            list.IndexOf("A").Should().Be(0);
            list.IndexOf("B").Should().Be(1);
            list.IndexOf("C").Should().Be(2);
            list.IndexOf("W").Should().Be(3);
            list.IndexOf("Z").Should().Be(4);
            list.IndexOf("F").Should().Be(-1);
            list.IndexOf("F").Should().BeNegative();
        }

        [TestMethod]
        public void Remove_Test()
        {
            MyList<string> list = new MyList<string>() { "a", "b", "c", "d" };

            list.Should().HaveCount(4);
            list.Remove("b").Should().BeTrue();
            list.Count.Should().Be(3);
            list.head.NextNode.Item.Should().Be("c");
            list.head.NextNode.PrevNode.Item.Should().Be("a");



        }

        [TestMethod]
        public void Empty_List_Test()
        {
            MyList<string> list = new MyList<string>();

            list.IndexOf("q").Should().Be(-1);
            list.Contains("a").Should().BeFalse();
            list.Remove("qq").Should().BeFalse();

        }
    }
}
