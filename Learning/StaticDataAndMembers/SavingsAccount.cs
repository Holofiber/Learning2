using System;

namespace StaticDataAndMembers
{
    public class SavingsAccount
    {
        public double CurrBalance;

        public static double CurrInterestRate;

        public SavingsAccount(double balance)
        {
            Console.WriteLine("In public ctor");
            CurrBalance = balance;
        }

        static SavingsAccount()
        {
            Console.WriteLine("In static ctor!");
            CurrInterestRate = 0.04;
        }

        public static void SetInterestRate(double newRate)
        {
            CurrInterestRate = newRate;
        }

        public static double GetInterestRate()
        {
            return CurrInterestRate;
        }
    }
}