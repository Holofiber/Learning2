using System;
using System.Threading.Tasks;

namespace TPL_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Task task = new Task(() => Console.WriteLine("Hello Task!"));
            task.Start();


            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
