using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


            int t = a(s, z);

            int e = s.WordCount(z);
            Console.WriteLine(t);
        }


    }

    public static class StringExtension
    {
        public static int WordCount(this string str, char c)
        {
            int counter = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c)
                    counter++;
            }
            return counter;
        }
    }
}
