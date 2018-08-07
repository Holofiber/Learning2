using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class Program
    {
        static void Main(string[] args)
        {

            Tree<int> tree = new Tree<int> { 15, 10, 5, 30, 8 , 20, 25,35};

            Tree<string> s = new Tree<string> { "15", "10", "5", "20", "8" };



            Tree<Person> personsTree = new Tree<Person>()
            {
                new Person("Tom", 34),
                new Person("Jimi" , 54),
                new Person("Kat", 23)

            };

            foreach (int i in tree)
            {
                Console.WriteLine(tree);
            }


            foreach (var person in personsTree)
            {
                Console.WriteLine(person);
            }

        }
    }

    public class Person : IComparable<Person>, IComparable
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;

        }
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} {Age}";
        }

        public int CompareTo(Person other)
        {
            if (ReferenceEquals(this, other))
            {
                return 0;
            }

            if (ReferenceEquals(null, other))
            {
                return 1;
            }

            return Age.CompareTo(other.Age);
        }

        public int CompareTo(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return 1;
            }

            if (ReferenceEquals(this, obj))
            {
                return 0;
            }

            if (!(obj is Person))
            {
                throw new ArgumentException($"Object must be of type {nameof(Person)}");
            }

            return CompareTo((Person)obj);
        }

        public static bool operator <(Person left, Person right)
        {
            return Comparer<Person>.Default.Compare(left, right) < 0;
        }

        public static bool operator >(Person left, Person right)
        {
            return Comparer<Person>.Default.Compare(left, right) > 0;
        }

        public static bool operator <=(Person left, Person right)
        {
            return Comparer<Person>.Default.Compare(left, right) <= 0;
        }

        public static bool operator >=(Person left, Person right)
        {
            return Comparer<Person>.Default.Compare(left, right) >= 0;
        }
    }
}
