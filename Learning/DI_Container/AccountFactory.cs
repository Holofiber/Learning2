namespace DI_Container
{
    public class AccountFactory
    {
        private readonly ILogger logger;
        private readonly IValidator validator;

        public AccountFactory()
        {
            this.logger = logger;
            this.validator = validator;
        }


        public Account Create()
        {
            return new Account(logger, validator);
        }
    }
}