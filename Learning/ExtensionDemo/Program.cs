using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ExtensionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "wwwqqqrrr";
            char z = 'w';

            Func<string, char, int> a = (str, c) =>
            {
                int counter = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == c)
                        counter++;
                }
                return counter;
            };
            List<int> list1 = new List<int>() { 1, -5, 3, 6, -1, -51, -8, 9, 0 };
            List<string> stringList = new List<string>() { "asd", "gfg", "as" };
            List<double> doublesList = new List<double>() { 1.3, 1.6, 7.2 };

            List<int> positiveNumbers = new List<int>();
            List<int> shuffle = new List<int>();
            List<int> reverse = new List<int>();

            positiveNumbers = list1.PositiveNumbers().ToList();

            Print(positiveNumbers);
            shuffle = positiveNumbers.Shuffle().ToList();
            Print(shuffle);
            Print(positiveNumbers);
            reverse = shuffle.ReverseAll().ToList();

            Console.WriteLine("______________________________");
            Print(list1);
            Print(positiveNumbers);
            Print(shuffle);
            Print(reverse);



            int t = a(s, z);

            int e = s.WordCount(z);
            Console.WriteLine(t);
        }

        public static void Print(List<int> list)
        {
            Console.WriteLine();
            foreach (int i in list)
            {

                Console.Write($"{i} ");

            }
            Console.WriteLine();
        }

    }
}
