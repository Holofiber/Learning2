using System;
using System.Threading;
using System.Threading.Tasks;

namespace TPL_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<string> task = Task.Run(() =>
            {
                Console.WriteLine(DateTime.Now.ToLongTimeString() + " Начинаем долгую задачу");
                Thread.Sleep(10000);
                Console.WriteLine(DateTime.Now.ToLongTimeString() + " Завершаем долгую задачу");
                return "Результат долгой задачи";
            });
            Console.WriteLine(DateTime.Now.ToLongTimeString() + " Делаем что-то до начала ожидания результата задачи");
            string result = task.Result;
            Console.WriteLine(DateTime.Now.ToLongTimeString() + " Полученный результат: " + result);
            Console.ReadLine();
        }
    }
}
