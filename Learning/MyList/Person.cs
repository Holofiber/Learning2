using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList
{
    public class Person
    {
        public readonly string Name;
        public readonly int Age;
        public readonly string Sex;

        public Person(string name, int age, string sex)
        {
            Name = name;
            Age = age;
            Sex = sex;
        }

        public void Some()
        {
            Person ivan = new Person("Ivan", 22, "M");
            Person tom = new Person("Tom", 14, "M");

            ivan.PersonIsMajority();
            tom.PersonIsMajority();
        }

    }

    public static class PersonExtension
    {
        public static bool PersonIsMajority(this Person person)
        {
            if (person.Age >= 21)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }


}
