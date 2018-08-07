using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Anonymous_methods
{

    public static class MyExtensions
    {



        public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> enumerable, Predicate<T> filterFunc)
        {
            foreach (var item in enumerable)
            {
                if (filterFunc(item))
                {
                    yield return item;
                }
            }
        }

    }



    class Base
    {
        
    }

    class Derived : Base
    {
        
    }





    class Program
    {

        static void Main(string[] args)
        {
            Base b = new Base();
            Derived derived = new Derived();

            b = derived;




            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(100000);
            });







            Thread.Sleep(100);

            Action<string> handler = Handler1;
            handler("hello world!");

            handler = m => Console.WriteLine($"<<{m}>>");


            handler("hello world!");


            List<int> list = new List<int>() { 1, 2, 3, 4, 5 };


            Func<int, int, int> shos = Shos;

            int suma = list.Aggregate(shos);
            Console.WriteLine(suma);





            var ints = list.MyWhere(i => i > 3);


            foreach (int i in ints)
            {
                Console.WriteLine(i);
            }


            DownloadFile(null, 
                onSuccess: () => Console.WriteLine("success"), 
                onException: exception => Console.WriteLine(exception.ToString()));


            DownloadFile("asdasdsa",
                onSuccess: () => Console.WriteLine("success"),
                onException: exception => Console.WriteLine(exception.ToString()));



            Console.ReadLine();
        }



        public static void DownloadFile(string url, Action onSuccess, Action<Exception> onException)
        {
            try
            {

                if (url == null)
                {
                    throw new ArgumentNullException();
                }

                onSuccess();

            }
            catch (ApplicationException e)
            {
                onException(e);
            }
        }



        public static void SomeOperation()
        {

        }







        public static int Shos(int sum, int i)
        {
            return sum * i;
        }



        public static bool FilterInts(int i)
        {
            return i > 3;
        }



        private static void Handler1(string mes)
        {
            Console.WriteLine(mes);
        }
        private static void Handler2(string mes)
        {
            Console.WriteLine($"<<{mes}>>");
        }
    }
}
