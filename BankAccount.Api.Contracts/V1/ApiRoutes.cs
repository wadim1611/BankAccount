namespace BankAccount.Api.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;

        public static class Users
        {
            public const string Get = Base + "/users/{id}";

            public const string GetAll = Base + "/users";

            public const string Create = Base + "/users";

            public const string Update = Base + "/users/{id}";

            public const string Delete = Base + "/users/{id}";
        }

        public static class Accounts
        {
            public const string Get = Base + "/accounts/{id}";

            public const string GetAll = Base + "/accounts";

            public const string Create = Base + "/accounts";

            public const string Debit = Base + "/accounts/debit";

            public const string Withdraw = Base + "/accounts/withdraw";

            public const string Transfer = Base + "/accounts/transfer";

            public const string Delete = Base + "/accounts/{id}";
        }

        public static class Currencies
        {
            public const string Get = Base + "/currencies/{id}";

            public const string GetAll = Base + "/currencies";

            public const string Create = Base + "/currencies";

            public const string Update = Base + "/currencies/{id}";

            public const string Delete = Base + "/currencies/{id}";
        }
    }
}
