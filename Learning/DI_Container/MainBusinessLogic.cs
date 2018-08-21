namespace DI_Container
{
    public class MainBusinessLogic
    {
        private readonly ILogger logger;

        public MainBusinessLogic(ILogger logger)
        {
            this.logger = logger;
        }


        public void Start()
        {

        }
    }
}