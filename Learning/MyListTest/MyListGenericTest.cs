using System;
using System.Text;
using System.Collections.Generic;
using FluentAssertions;
using FluentAssertions.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyList;
using MyDListDemo;

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
            DList<string> list = new DList<string>();

            list.Add("A");

            list.head.Item.Should().Be("A");
            list.head.NextNode.Should().BeNull();
            list.head.PrevNode.Should().BeNull();
        }

        [TestMethod]
        public void String_Type_Test2()
        {
            DList<string> list = new DList<string>();


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
        public void Person_Type_Test2()
        {
            DateTime dateTime = 8.August(2018);

            Person Sem = new Person("Sem", 76, "Male");
            var Tom = new Person("Tom", 17, "Male");
            var Kat = new Person("Kat", 45, "Female");
            var Ann = new Person("Ann", 5, "Female");


            DList<Person> list = new DList<Person>() { Sem, Tom, Kat, Ann };

            list.head.Item.Should().Be(Sem);
            list.head.NextNode.Item.Should().Be(Tom).And.NotBe(Kat);
            list.head.NextNode.NextNode.Item.Should().Be(Kat);
            list.head.NextNode.NextNode.NextNode.Item.Should().Be(Ann);

            list.head.NextNode.PrevNode.Item.Should().Be(Sem);
            list.head.NextNode.NextNode.PrevNode.Item.Should().Be(Tom);
            list.head.NextNode.NextNode.NextNode.PrevNode.Item.Should().Be(Kat);

            list.head.Item.Age.Should().Be(76);
            list.head.Item.Name.Should().Be("Sem");
            list.head.Item.Sex.Should().Be("Male");

        }

        [TestMethod]
        public void Float_Type_Test()
        {
            DList<float> list = new DList<float>();

            list.Add(0.000000000000000000000000000000000000000000001f);
            // 45 ззнаків після коми, не точно показує

            list.head.Item.Should().Be(0.000000000000000000000000000000000000000000002f);
            list.head.NextNode.Should().BeNull();
            list.head.PrevNode.Should().BeNull();
        }

        [TestMethod]
        public void Float_Type_Test2()
        {
            DList<float> list = new DList<float>();


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
            DList<double> list = new DList<double>();

            list.Add(0.0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001);
            //100500 over знаків і тест фейлить, якщо змінити останній знак

            list.head.Item.Should().Be(0.0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001);
            list.head.NextNode.Should().BeNull();
            list.head.PrevNode.Should().BeNull();
        }

        [TestMethod]
        public void Count_Test()
        {
            DList<string> list = new DList<string>();


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
            DList<string> list = new DList<string>();


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
            DList<string> list = new DList<string>();


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
            DList<string> list = new DList<string>();


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
            DList<string> list = new DList<string>() { "a", "b", "c", "d" };

            list.Should().HaveCount(4);
            list.Remove("b").Should().BeTrue();
            list.Count.Should().Be(3);
            list.head.NextNode.Item.Should().Be("c");
            list.head.NextNode.PrevNode.Item.Should().Be("a");



        }

        [TestMethod]
        public void Empty_List_Test()
        {
            DList<string> list = new DList<string>();

            list.IndexOf("q").Should().Be(-1);
            list.Contains("a").Should().BeFalse();
            list.Remove("qq").Should().BeFalse();

        }
    }
}
