using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using Console = Colorful.Console;

namespace SandBoxConsole
{
    public class Program
    {
        public delegate bool SomeDelegate();
        static void Main(string[] args)
        {
            Run();

            while (true)
            {
                var data = Console.ReadLine();

                if (data != null)
                {
                    queue.Enqueue(Convert.ToInt32(data));
                }

                Thread.Sleep(100);
            }
        }

        public static ConcurrentQueue<int> queue = GetQueue();

        public static async void Run()
        {
            Worker workerRed = new Worker(queue, 2000, Color.Red);
            Worker workerGreen = new Worker(queue, 1000, Color.Green);

            Task t1 = Task.Factory.StartNew(() => workerRed.Start());

            Task t2 = Task.Factory.StartNew(() => workerGreen.Start());

            Thread.SpinWait(100000000);
            workerGreen.Stop();
        }

        public static ConcurrentQueue<int> GetQueue()
        {
            ConcurrentQueue<int> queue = new ConcurrentQueue<int>();
            Random random = new Random(300);

            for (int i = 1; i <= 10; i++)
            {
                queue.Enqueue(i);
            }

            return queue;
        }
    }

    public class Worker
    {
        private readonly ConcurrentQueue<int> queue;
        private readonly int pending;
        private readonly Color color;
        private bool run = true;

        public Worker(ConcurrentQueue<int> queue, int pending, Color color)
        {
            this.queue = queue;
            this.pending = pending;
            this.color = color;
        }

        public void Start()
        {
            System.Console.WriteLine($"ID: {Thread.CurrentThread.ManagedThreadId}", Color.Yellow);

            while (run)
            {
                Thread.Sleep(pending);

                if (queue.TryDequeue(out int num))
                    Console.WriteLine($"{num * num}", color);
            }

            System.Console.WriteLine("end");
        }

        public void Stop()
        {
            run = false;
        }
    }
}
