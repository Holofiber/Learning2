using System;
using System.Collections.Generic;
using System.Reflection;

namespace MyCoreLib.Tests
{
    public static class Utill
    {
        public static void PrettyPrint(object Data)
        {
            var type = Data.GetType();
            PropertyInfo[]? properties = type.GetProperties();

            Console.WriteLine("{0,-20} {1,5}\n", "Property Name", "Property Value");
            foreach (var property in properties)
            {
                if (property.CanWrite)
                {
                    Console.WriteLine("{0,-20} {1,5:N1}", property.Name, property.GetValue(Data));
                }
            }
        }



        public static void PrettyPrint<T>(this IEnumerable<T> Data)
        {
            var enumer = Data.GetEnumerator();
            enumer.MoveNext();
            var properties = enumer.Current.GetType().GetProperties();

            foreach (var item in properties)
            {
                Console.Write("{0,-20} ", item.Name);
            }            

            foreach (var item in Data)
            {
               var _properties = item.GetType().GetProperties();
                Console.WriteLine();
                foreach (var property in _properties)
                {
                    Console.Write("{0,-20}", property.GetValue(item));

                }
            }

           

        }
    }
}
