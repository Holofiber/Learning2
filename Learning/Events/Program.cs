using System;
public delegate double ProcessResults(double x, double y);
public delegate double ProcessResults2(double x);
public class Processor
{
    public Processor (double factor)
    {
        this.factor = factor;

    }
    public double Compute (double x, double y)
    {
        double result = (x + y) * factor;
        Console.WriteLine("InstanceResult : {0}", result);
        return result;
    }

    public static double StaticCompute (double x, double y)
    {
        double result = (x + y) * 0.5;
        Console.WriteLine("StaticResult: {0}", result);
        return result;
    }

    public static double StaticCompute(double x)
    {
        double result = (x + x) * 0.5;
        Console.WriteLine("StaticResult: {0}", result);
        return result;
    }

    private double factor;
}

public class EntryPoint
{
    static void Main()
    {
        Processor proc1 = new Processor(0.75);
        Processor proc2 = new Processor(0.83);

        ProcessResults delegate1 = new ProcessResults(proc1.Compute);
        ProcessResults delegate2 = new ProcessResults(proc2.Compute);
        ProcessResults delegate3 =  Processor.StaticCompute;
        ProcessResults2 delegate4 = Processor.StaticCompute;
        ProcessResults[] delegates = new ProcessResults[]
        {
            proc1.Compute,
            proc2.Compute,
            Processor.StaticCompute
        };

        ProcessResults chained = delegates[0] +
                                delegates[1] +
                                delegates[2];

        Delegate[] chain = chained.GetInvocationList();
        double accumulator = 0;
        for (int i=0; i<chain.Length; ++i)
        {
            ProcessResults current = (ProcessResults)chain[i];
            accumulator += current(4, 5);
        }
       
        Console.WriteLine("Result : {0}", accumulator);
    }
}



