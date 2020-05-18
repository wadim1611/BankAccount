using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount.Api.Contracts.V1.Requests
{
    public class AccountSaveModel
    {
        public int UserId { get; set; }
        public int CurrencyId { get; set; }
    }
}
