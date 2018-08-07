using System;
using System.Collections.Generic;
using MyList;

namespace MyDListDemo
{
    public class Run
    {
        DList<double> list = new DList<double>();

        public void AddToList()
        {
            DList<int> lis = new DList<int>() { 1, 2, 3, 4, 5 };

            foreach (int li in lis)
            {
                Console.WriteLine(li);
            }
            Console.WriteLine(@"\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/");
            foreach (int li in lis.GetEnumeratorReverse())
            {
                Console.WriteLine(li);
            }

            list.Add(10.3);
            list.Add(11.54);
            list.Add(12);
            list.Add(13.1);
            list.Add(13.5);

            Console.WriteLine(@"\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/");
            foreach (double node in list)
            {
                Console.WriteLine(node);
            }

            DList<Person> personsList = new DList<Person>()
            {
                new Person("1. Tom", 34, "M"),
                new Person("2. Meri", 30, "W"),
                new Person("3. Ali", 21, " ")
            };
            Console.WriteLine(@"\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/");
            foreach (var person in personsList)
            {
                Console.WriteLine($"{person.Name} {person.Age}");
            }

            Console.WriteLine(@"\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/");

            foreach (var person in personsList.GetEnumeratorReverse())
            {
                Console.WriteLine($"{person.Name} {person.Age}");
            }

        }
    }


}