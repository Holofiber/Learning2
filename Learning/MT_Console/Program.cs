using System.Drawing;
using Console = Colorful.Console;

namespace MT_Console
{
    public class Program
    {
        public static void ThreadFunc()
        {
            System.Console.WriteLine($"hello from thread{Thread.CurrentThread.GetHashCode()}");
        }

        static void Main(string[] args)
        {
            //Thread newThread = new Thread(new ThreadStart(Program.ThreadFunc));
            //System.Console.WriteLine($"main thread {Thread.CurrentThread.ManagedThreadId}");

            //System.Console.WriteLine("Run new thread");

            //newThread.Start();

            //newThread.Join();
            //System.Console.WriteLine("end new thread");

            //var tread1 = new Thread(PrintMessage);
            //var tread2 = new Thread(PrintMessage2);

            var thread3 = new Thread(Method3);
            var thread1 = new Thread(Method1);
            var thread2 = new Thread(Method2);

            thread3.Start();
            //  Thread.Sleep(100);
            thread2.Start();
            // Thread.Sleep(100);
            thread1.Start();


            thread1.Join();
            thread2.Join();
            thread3.Join();

            System.Console.WriteLine(num);



            //tread1.Start((Color.Green, 10));

            //Thread.Sleep(2000);

            //tread2.Start((Color.Red, 5));

            while (true)
            {
                Thread.Sleep(1000);
            }
        }

        static object syncLock = new object();

        static ManualResetEvent manualResetEvent = new ManualResetEvent(true);

        //static ManualResetEvent mre1 = new ManualResetEvent(true);
        static ManualResetEvent mre2 = new ManualResetEvent(false);
        static ManualResetEvent mre3 = new ManualResetEvent(false);

        public static void PrintMessage(object param)
        {
            (Color color, int count) = ((Color, int))param;

            for (int i = 0; i < count; i++)
            {
                manualResetEvent.WaitOne();
                Thread.Sleep(1000);
                lock (syncLock)
                {
                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} ran in Print message", color);
                }
            }
        }

        public static void PrintMessage2(object param)
        {
            (Color color, int count) = ((Color, int))param;
            manualResetEvent.Reset();
            for (int i = 0; i < count; i++)
            {
                Thread.Sleep(1000);
                lock (syncLock)
                {
                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} ran in Print message", color);
                }
            }
            manualResetEvent.Set();
        }

        public static int num = 0;

        public static void Method1()
        {
            for (int i = 0; i < 1_000_000; i++)
            {
                Interlocked.Increment(ref num);

            }
        }

        public static void Method2()
        {
            for (int i = 0; i < 1_000_000; i++)
            {
                
            }
        }

        public static void Method3()
        {
            for (int i = 0; i < 1_000_000; i++)
            {
                Interlocked.Increment(ref num);
            }
        }
    }
}