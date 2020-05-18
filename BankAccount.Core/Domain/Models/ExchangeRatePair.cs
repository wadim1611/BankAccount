using System;

namespace BankAccount.Core.Domain.Models
{
    public class ExchangeRatePair
    {
        public DateTime Date { get; set; }
        public string CodeFrom { get; set; }
        public string CodeTo { get; set; }
        public decimal Rate { get; set; }

        public ExchangeRatePair(string currCodeFrom, string currCodeTo)
        {
            CodeFrom = currCodeFrom;
            CodeTo = currCodeTo;
        }
    }
}
