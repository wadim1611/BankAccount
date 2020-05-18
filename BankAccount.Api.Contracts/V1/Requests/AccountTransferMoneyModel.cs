namespace BankAccount.Api.Contracts.V1.Requests
{
    public class AccountTransferMoneyModel
    {
        public int AccountIdFrom { get; set; }
        public int AccountIdTo { get; set; }
        public decimal Amount { get; set; }
    }
}