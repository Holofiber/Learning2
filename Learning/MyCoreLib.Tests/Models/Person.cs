using System;

namespace MyCoreLib.Tests
{
    public class Person : IEquatable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(int age, string name)
        {
            Age = age;
            Name = name;
        }

        public static bool operator == (Person p1, Person p2)
        {           

            return p1.Equals (p2);
        }
        public static bool operator != (Person p1, Person p2)
        {
            return !p1.Equals (p2);
        }

        public override string ToString()
        {
            return $"{Name} {Age}";
        }

        public bool Equals(Person? other)
        {
            if (ReferenceEquals(other, null))
                return false;
            if(ReferenceEquals(this, other))
                return true;

            return other.Name == this.Name && other.Age == this.Age;          
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(obj, null))
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return Equals((Person)obj);
        }

        public override int GetHashCode()
        {
            // return HashCode.Combine(Name, Age);
            return 0;
        }


    }    
}