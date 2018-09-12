using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticDataAndMembers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****  Fun  with  Static  Data  *****\n");

            SavingsAccount sl = new SavingsAccount(50);
            Console.WriteLine("Interest  Rate  is:  {0}", SavingsAccount.GetInterestRate());
            SavingsAccount.SetInterestRate(0.9);
            Console.WriteLine("Interest  Rate  is:  {0}", SavingsAccount.GetInterestRate());

            SavingsAccount s2 = new SavingsAccount(100);

            //  Вывести  текущую  процентную  ставку.

            Console.WriteLine("Interest  Rate  is:  {0}", SavingsAccount.GetInterestRate());

            //  Создать  новый  объект;  это  не  'сбросит1  процентную  ставку.

            SavingsAccount s3 =
                new SavingsAccount(10000.75);

            Console.WriteLine("InterestRate  is:  {0}", SavingsAccount.GetInterestRate());

            Console.ReadLine();
        }
    }
}