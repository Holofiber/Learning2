
//public class QueueProcessor
//{
//    public QueueProcessor(Queue theQueue)
//    {
//        this.theQueue = theQueue;
//        theThread = new Thread(new ThreadStart(this.ThreadFunc));
//    }

//    private Queue theQueue;
//    private Thread theThread;
//    private Thread thread;

//}

public class EntrPoint
{
    private static void ThreadFunc()
    {
        Console.WriteLine($"hello from thread {Thread.CurrentThread.GetHashCode()}");
    }

    

    static void Main(string[] args)
    {
        Thread thread = new Thread(new ThreadStart(EntrPoint.ThreadFunc));
        Console.WriteLine($"main thread {Thread.CurrentThread.ManagedThreadId}");

        Console.WriteLine("run new thread...");

        thread.Start();

        thread.Join();
        Console.WriteLine("thread finished");
    }
}