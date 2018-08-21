using System.Diagnostics;

namespace DI_Container
{
    public class Account
    {
        private InternalAccountChecker internalAccountChecker;

        public Account( InternalAccountChecker internalAccountChecker)
        {
            this.internalAccountChecker = internalAccountChecker;

            Debug.WriteLine($"{nameof(Account)} created");
        }
    }
}