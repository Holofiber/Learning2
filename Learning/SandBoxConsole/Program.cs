using System;
using System.Threading;

namespace SandBoxConsole
{
    public class Program
    {
        static private readonly object theLock = new Object();
        static private int numberThreads = 0;
        static private Random rnd = new Random();
        static private int counter = 0;

        private static void ThreadFunc1()
        {
            lock (theLock)
            {
                for (int i = 0; i < 50; i++)
                {
                    Monitor.Wait(theLock, Timeout.Infinite);
                    Console.WriteLine($"{++counter} from thread {Thread.CurrentThread.ManagedThreadId}");
                    Monitor.Pulse(theLock);
                }
            }
        }

        private static void ThreadFunc2()
        {
            lock (theLock)
            {
                for (int i = 0; i < 50; i++)
                {
                    Monitor.Pulse(theLock);
                    Monitor.Wait(theLock, Timeout.Infinite);
                    Console.WriteLine($"{++counter} from thread {Thread.CurrentThread.ManagedThreadId}");
                }
            }
        }

        private static void ThreadFunc3()
        {
            lock (theLock)
            {
                for (int i = 0; i < 50; i++)
                {
                    Monitor.Pulse(theLock);
                    Monitor.Wait(theLock, Timeout.Infinite);
                    Console.WriteLine($"{++counter} from thread {Thread.CurrentThread.ManagedThreadId}");
                }
            }
        }

        static void Main(string[] args)
        {
            Thread thread1 = new Thread(new ThreadStart(ThreadFunc1));
            Thread thread2 = new Thread(new ThreadStart(ThreadFunc2));
            Thread thread3 = new Thread(new ThreadStart(ThreadFunc3));

            thread1.Start();
            thread2.Start();
            thread3.Start();
        }

    }
}
