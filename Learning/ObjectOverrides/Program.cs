using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOverrides
{
    class A
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "asd";
            string s2 = "a" + "s" + "d";

            A a1 = new A();
            A a2 = new A();


            Console.WriteLine(s1.Equals(s2));
            Console.WriteLine(Object.ReferenceEquals(s1, s2));
            Console.WriteLine(Object.ReferenceEquals(a1, a2));


        }
    }
}
