using System.Collections.Generic;
using System.Dynamic;

namespace DI_Container
{
    public class AccountManager
    {
        private readonly ILogger logger;
        private readonly AccountFactory accountFactory;
        List<Account> accounts = new List<Account>();

        public AccountManager(ILogger logger, AccountFactory accountFactory)
        {
            this.logger = logger;
            this.accountFactory = accountFactory;


            for (int i = 0; i < 3; i++)
            {
                accounts.Add(accountFactory.Create());
            }
        }


        public void Start()
        {

        }
    }
}