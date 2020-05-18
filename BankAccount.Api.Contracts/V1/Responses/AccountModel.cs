using System;

namespace BankAccount.Api.Contracts.V1.Responses
{
    public class AccountModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OpenedDate { get; set; }
        public int CurrencyCode { get; set; }
        public decimal Balance { get; set; }
    }
}
