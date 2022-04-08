using System;
using System.Threading;

namespace Mutex_Seaphore_Sample
{
    internal class Program
    {
        static Mutex mutex = new Mutex(false, "MutexName1");
        static Semaphore semaphore = new Semaphore(1, 1, "semi");
        SemaphoreSlim slim = new SemaphoreSlim(1);

        static void Main(string[] args)
        {
            semaphore.WaitOne(10000);
            //mutex.WaitOne(1000);

            while (!Console.KeyAvailable)
            {
                Thread.Sleep(100);

                Console.WriteLine("I'm working!");
            }

            Console.WriteLine("I'm free!");

            semaphore.Release();
            //mutex.ReleaseMutex();

            Console.ReadLine();
        }

        ~Program()
        {
           // mutex.Dispose();
            semaphore.Dispose();
        }
    }
}
