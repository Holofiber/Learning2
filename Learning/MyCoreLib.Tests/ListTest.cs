using NUnit.Framework;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System;

namespace MyCoreLib.Tests
{
    public class ListTest
    {


        [Test]
        public void Test1()
        {

            var list = new List<int>() { 1, 2, 3, 4, 5};
            list.Add(1);
            var linkedList = new LinkedList<int>();
            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);
            linkedList.AddLast(4);
            linkedList.AddLast(5);

            list.Should().BeEquivalentTo(linkedList);            

        }

        [Test]
        public void Test2()
        {

            var list = new List<string>() { "a", "b" };
            var linkedList = new LinkedList<string>();
            linkedList.AddLast("a");
            linkedList.AddLast("b");            

            list.Should().BeEquivalentTo(linkedList);

        }

        [Test]
        public void Test3()
        {

            var list = new List<Person>() { new Person(12, "Oleg"), new Person (54, "Olga"), new Person (21, "Alex") };
            var linkedList = new LinkedList<Person>();
            linkedList.AddLast(new Person(12, "Oleg"));
            linkedList.AddLast(new Person(54, "Olga"));
            linkedList.AddLast(new Person(21, "Alex"));

            foreach (var pair in list.Zip(linkedList))
            {
                pair.First.Should().Be(pair.Second);
            }

        }

        [Test]
        public void Test4()
        {

            var list = new List<Person>() { new Person(12, "Oleg"), new Person(54, "Olga"), new Person(21, "Alex") };
            
            list.Sort((x, y) =>
            {
                if (x.Name == null && y.Name == null) return 0;
                else if (x.Name == null) return -1;
                else if (y.Name == null) return 1;
                else return x.Name.CompareTo(y.Name);
            });

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            
            list.Should().BeInAscendingOrder(x=>x.Name);

        }

        [Test]
        public void Test5()
        {
            var myList = new MyList<int>() ;
            myList.Add(1);
            myList.Add(7);
            myList.Add(21);
            myList.Add(4);
            myList.Add(0);
            myList.Add(7);
            myList.Add(11);

            myList.Count.Should().Be(7);
            myList.Print();

            myList.BubbleSort();
            myList.Print();

            myList.BubbleSortDesc();
            myList.Print();

        }

        [Test]
        public void Test6()
        {
            var myList = new MyList<double>();
            myList.Add(1.435);
            myList.Add(7.5678);
            myList.Add(21.235);
            myList.Add(4.435345654675467);
            myList.Add(0.00000000001);
            myList.Add(7);
            myList.Add(11.546546);

            myList.Count.Should().Be(7);
            myList.Print();

            myList.BubbleSort();
            myList.Print();

            myList.BubbleSortDesc();
            myList.Print();

        }

        class Person
        {            
            public string Name { get; set; }
            public int Age { get; set; }

            public Person(int age, string name)
            {
                Age = age;
                Name = name;
            }

            public override string ToString()
            {
                return $"{Name} {Age}";
            }

        }
    }
}