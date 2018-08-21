namespace DI_Container
{
    internal class OrderValidator
    {
        private readonly ILogger logger;
        private IValidator validator;


        public OrderValidator(ILogger logger, IValidator validator)
        {
            this.logger = logger;
            this.validator = validator;
        }
    }
}