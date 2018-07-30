using System;
using System.Collections.Generic;
using System.Text;
using Employee;

namespace Employee
{
    public class EntryPoint
    {
        static void Main()
        {
           // Example1.Run();
            
            Person person = new Person(10, "Sem");
            person.OnAgeChanged+= Subscriber2;
            person.OnAgeChanged+= Subscriber1;
            person.OnAgeChanged+= Subscriber1;
            person.Age = 15;

            person.OnAgeChanged -= Subscriber1;
            
            Console.WriteLine();
            person.Age = 19;
        }

        private static void Subscriber1(object sender, int i)
        {
            
            Console.WriteLine("Subscriber1 say - Age was cahnged! \n age: "+i);
        }

        private static void Subscriber2(object sender, int i)
        {
            Console.WriteLine("Subscriber2 say - Age was cahnged! \n age: "+i);
        }
    }
}
