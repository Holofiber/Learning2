namespace DI_Container
{
    public class Account
    {
        private readonly ILogger logger;
        private OrderValidator orderValidator;

        public Account(ILogger logger, IValidator validator)
        {
            this.logger = logger;
            orderValidator = new OrderValidator(logger, validator);
        }
    }
}