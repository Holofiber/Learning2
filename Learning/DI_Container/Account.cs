using System.Diagnostics;

namespace DI_Container
{
    public class Account
    {
        private readonly ILogger logger;
        private InternalAccountChecker internalAccountChecker;

        public Account(ILogger logger, InternalAccountChecker internalAccountChecker)
        {
            this.logger = logger;
            this.internalAccountChecker = internalAccountChecker;

            Debug.WriteLine($"{nameof(Account)} created");
        }
    }
}