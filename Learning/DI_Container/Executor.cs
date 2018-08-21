﻿namespace DI_Container
{
    public class Executor
    {
        private AccountManager accountManager;
        private ILogger logger;


        public Executor(ILogger logger, AccountManager accountManager)
        {
            this.logger = logger;
            this.accountManager = accountManager;
        }

        public void Start()
        {

        }
    }
}