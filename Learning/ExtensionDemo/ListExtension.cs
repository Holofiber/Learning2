using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtensionDemo
{
    public static class ListExtension
    {
        public static List<int> PositiveNumbers(this List<int> list)
        {
            var result = new List<int>();

            return list.Where(i => i > 0).ToList();
        }



        public static List<double> PositiveNumbers(this List<double> list, List<double> list1)
        {

            list.AddRange(list1.Where(i => i > 0));
            return list;
        }

        public static IEnumerable<T> From<T>(this IEnumerable<T> enumerable, Func<T> function)
        {

            yield return function();

        }

        public static IList<T> ReverseAll<T>(this IList<T> enumerable)
        {
            if (enumerable == null)
            {
                throw new ArgumentNullException(nameof(enumerable));
            }

            var result = new List<T>();
            int lenght = enumerable.Count() - 1;
            for (int i = 0; i <= lenght; i++)
            {
                result.Add(enumerable[lenght - i]);
            }

            return result;
        }

        public static IList<T> Shuffle<T>(this IList<T> list)
        {
            Random rng = new Random();

            var result = list.ToList();
            int count = result.Count;
            while (count > 1)
            {
                count--;
                int k = rng.Next(count + 1);
                T value = result[k];
                result[k] = result[count];
                result[count] = value;
            }

            return result;
        }

        public static void Print<T>(this IList<T> list)
        {
            foreach (T i in list)
            {
                Console.WriteLine();
                Console.Write($"{i} ");
                Console.WriteLine();
            }
        }
    }
}