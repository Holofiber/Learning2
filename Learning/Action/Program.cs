using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Action
{

    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        //20 properties
    }



    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6 };

            list.Where(i => i % 2 == 0)
                .ToList()
                .ForEach(Console.WriteLine);



            var persons = new List<Person>()
            {
                new Person(){ Name = "Jon", Surname = "Doe", Age = 20},
                new Person(){ Name = "Sara", Surname = "ASD", Age = 35},
                new Person(){ Name = "Vasia", Surname = "ZXC", Age = 46},
                new Person(){ Name = "David", Surname = "QWE", Age = 28},
            };


            var list1 = persons
                .Select(person => new { Name = person.Name, Age = person.Age })
                .Where(person => person.Age > 30);




            foreach (var item in list1)
            {
                Console.WriteLine($"{item.Name} {item.Age}");
            }


            Console.ReadLine();
        }

        private static void Action(int i)
        {
            Console.WriteLine(i);
        }
    }
}
