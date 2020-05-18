namespace BankAccount.Api.Contracts.V1.Requests
{
    public class AccountDebitModel
    {
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
    }
}
