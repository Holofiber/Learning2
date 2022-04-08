namespace LeatCodeTasks
{
    public class LC1117Building_H2O
    {
        public LC1117Building_H2O(int count)
        {
            GenerateTask(count);
        }

        private void GenerateTask(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Thread t = new Thread(Hidro);
                t.Start();
            }

            for (int i = 0; i < count/2; i++)
            {
                Thread t = new Thread(Oxy);
                t.Start();
            }
        }

        private static Semaphore H = new Semaphore(2, 2);
        private static Semaphore O = new Semaphore(0, 2);

        object syncLock = new object();

        public void Hidro()
        {
            H.WaitOne();

            Console.WriteLine($"Hidro");

            O.Release();
        }


        public void Oxy()
        {
            lock (syncLock)
            {
                O.WaitOne();
                O.WaitOne();
                Console.WriteLine($"Oxy ");

                H.Release(2);
            }
        }

    }
}
