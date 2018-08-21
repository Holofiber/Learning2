using System.Diagnostics;

namespace DI_Container
{
    public class MainBusinessLogic
    {
        private readonly ILogger logger;

        public MainBusinessLogic(ILogger logger)
        {
            this.logger = logger;

            Debug.WriteLine(nameof(MainBusinessLogic) + "created");
        }


        public void Start()
        {

        }
    }
}