using System.Diagnostics;

namespace DI_Container
{
    public class InternalAccountChecker
    {
        private readonly ILogger logger;
        private IValidator validator;


        public InternalAccountChecker(ILogger logger, IValidator validator)
        {
            this.logger = logger;
            this.validator = validator;

            Debug.WriteLine($"{nameof(InternalAccountChecker)} created");
        }
    }
}