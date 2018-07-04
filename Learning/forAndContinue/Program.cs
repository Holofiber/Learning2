using System;

namespace forAndContinue
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            for (int i=0; i<10;i++)
            {
                Console.WriteLine("text "+i);
                if(i<9)
                {
                    continue;
                }
                Console.WriteLine(i);
            }
            Console.WriteLine("some...");
        }
    }
}
