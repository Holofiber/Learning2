class Program
{
    static  void Main(string[] args)
    {
        AsyncTest();

        while (true) { };
    }

    public static async void AsyncTest()
    {
        var t = new TestClass();

        Task<int> result = t.Foo();       
        
        t.Bar2();
        Console.WriteLine("await");
       int z = await result;
    }
}

public class TestClass
{

    public async Task<int> Foo()
    {
        Console.WriteLine("Start Foo");
        Console.WriteLine(DateTime.Now);
        //Task task = new Task(() => Bar());
        Task<int> p = Task.Factory.StartNew(Bar, TaskCreationOptions.LongRunning);
        

       //var task = await Task.Run(()=>Bar());
        //task.Start();       

        return await p;
    }

    public int Bar()
    {
        Console.WriteLine("Start bar");
        Console.WriteLine(DateTime.Now);

        SpinWait.SpinUntil(() => false, 5000);
        

        Console.WriteLine("End Bar");
        Console.WriteLine(DateTime.Now);
       // throw new Exception();
        int someResult = 0;

        return someResult;
    }

    public int Bar2()
    {
        Console.WriteLine("Start bar2");
        Console.WriteLine(DateTime.Now);

        SpinWait.SpinUntil(() => false, 9000);        

        Console.WriteLine("End Bar2");
        Console.WriteLine(DateTime.Now);

        int someResult = 0;

        return someResult;
    }


}