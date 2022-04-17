using System;
using System.Threading;

namespace SandBoxConsole
{
    public class Program
    {
        static private readonly object theLock = new Object();
        static private int numberThreads = 0;
        static private Random rnd = new Random();

        private static void RndThreadFunc()
        {
            Monitor.Enter(theLock);
            try
            {
                ++numberThreads;
            }
            finally
            {
                Monitor.Exit(theLock);
            }

            int time = rnd.Next(1000, 12000);
            Thread.Sleep(time);

            Monitor.Enter(theLock);
            try
            {
                --numberThreads;
            }
            finally { Monitor.Exit(theLock); }
        }

        private static void RptThreadFunc()
        {
            while (true)
            {
                int threadCount = 0;
                Monitor.Enter(theLock);

                try
                {
                    threadCount = numberThreads;
                }
                finally
                {
                    Monitor.Exit(theLock);
                }
                Console.WriteLine($"{threadCount} active treads");

                Thread.Sleep(1000);
            }
        }

        static void Main(string[] args)
        {
            Thread reporter = new Thread(new ThreadStart(RptThreadFunc));

            reporter.IsBackground = true;
            reporter.Start();

            Thread[] rndthread = new Thread[50];
            for (uint i =0; i < 50; ++i)
            {
                rndthread[i] = new Thread(new ThreadStart(RndThreadFunc));
                rndthread[i].Start();
            }

        }

    }
}
