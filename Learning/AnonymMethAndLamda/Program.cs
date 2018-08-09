using System;

namespace AnonymMethAndLamda
{
    class Program
    {

        static void Main(string[] args)
        {
            int Sum(int i, int i1) => i1 + i;

            Console.WriteLine(Sum(10, 20));
            Console.WriteLine(Sum(40, 20));
            Console.WriteLine();

            Func<int, int> retFunc = Factorial;
            int n1 = GetInt(6, retFunc);
            Console.WriteLine(n1);

            int n2 = GetInt(6, x => x * x);
            Console.WriteLine(n2);


            Action<int, int> op;

            op = Add;
            Operation(10, 6, op);

            op = Substract;
            Operation(10, 6, op);

            Predicate<int> isPositive = i => i > 0;

            Console.WriteLine();
            Console.WriteLine(isPositive(2));
            Console.WriteLine(isPositive(-1));


        }

        static void Operation(int x1, int x2, Action<int, int> op)
        {
            if (x1 > x2)
                op(x1, x2);
        }

        static void Add(int x1, int x2)
        {
            Console.WriteLine("Sum: " + (x1 + x2));
        }

        static void Substract(int x1, int x2)
        {
            Console.WriteLine("Sub: " + (x1 - x2));
        }

        static int GetInt(int x1, Func<int, int> retF)
        {
            int result = 0;
            if (x1 > 0)
                result = retF(x1);
            return result;
        }
        static int Factorial(int x)
        {
            int result = 1;
            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            return result;
        }
    }


}
