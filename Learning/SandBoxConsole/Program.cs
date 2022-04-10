using System;
using System.Threading;
using System.Collections;

namespace SandBoxConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            Queue queue1 = new Queue();
            SetQueue(queue1, 100, "queue1");

            Queue queue2 = new Queue();
            SetQueue(queue2, 100, "queue2");

            QueeueProcessor proc1 = new QueeueProcessor(queue1);
            proc1.BeginProcessData();

            QueeueProcessor proc2 = new QueeueProcessor(queue2);
            proc2.BeginProcessData();

            Thread.SpinWait(2000000);

            proc1.EndProcessData();
            proc2.EndProcessData();

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }

        private static void SetQueue(Queue queue, int count, string Qname)
        {
            
            for (int i = 0; i < count; i++)
            {
                queue.Enqueue($"{Qname} {i}");
            }
        }
    }

    

    public class QueeueProcessor
    {
        private readonly Queue theQueue;
        private Thread theThread;
        public Thread TheThread { get { return theThread; } }

        public QueeueProcessor(Queue theQueue)
        {
            this.theQueue = theQueue;
            theThread = new Thread(new ThreadStart(this.ThreadFunc));
        }

        public void BeginProcessData()
        {
            theThread.Start();
        }

        public void EndProcessData()
        {
            theThread.Join();
        }

        private void ThreadFunc()
        {
            foreach (var item in theQueue)
            {
                Console.WriteLine(item);
            }
            
        }
    }

}
