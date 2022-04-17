using System;
using System.Collections.Concurrent;
using System.Numerics;
using System.Threading.Tasks;

namespace SandBoxConsole
{
    public class Program
    {
        const int FactorialToCompute = 4000;

        static void Main(string[] args)
        {
            var numbers = new ConcurrentDictionary<BigInteger, BigInteger>(4, FactorialToCompute);

            //Func<BigInteger, BigInteger> factorial = null;
            //factorial = (n) => (n == 0) ? 1 : n * factorial(n - 1); 

            BigInteger factorial(BigInteger n)
            {
                return (n == 0) ? 1 : n * factorial(n - 1);
            }

            var po = new ParallelOptions();

            po.MaxDegreeOfParallelism = Environment.ProcessorCount;

            //set GC to server mode for better performens.
            Parallel.For(0, FactorialToCompute, po, (i) =>
            {
                numbers[i] = factorial(i);
            });

            Console.WriteLine("DONE");

            //for (ulong i = 0; i < FactorialToCompute; ++i)
            //{
            //    numbers[i] = factorial(i);
            //}

        }
    }
}
