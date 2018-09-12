using System;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[4];
            try
            {
                //  a[5] = 4; // тут возникнет исключение, так как у нас в массиве только 4 элемента
                Met1();
                Console.WriteLine("Ending block try");
            }
            catch (MyDomainException e)
            {
                Console.WriteLine("It's OK! continue");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Console.WriteLine("block finally main");
            }




            Console.ReadLine();
        }

        public static void Met1()
        {
            try
            {
                Met2();
            }

            catch (Exception e)
            {

                var ex = new MyDomainException(1, "more details", e);
                throw ex;
            }
            finally
            {
                Console.WriteLine("block finally M1");
            }
        }

        public static void Met2()
        {
            throw new Exception("met2 excep");
        }

    }
}
