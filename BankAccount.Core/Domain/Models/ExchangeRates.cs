using System;
using System.Collections.Generic;

namespace BankAccount.Core.Domain.Models
{
    public class ExchangeRates
    {
        public DateTime Date { get; set; }

        public string Base { get; set; }

        public Dictionary<string, decimal> Rates { get; set; }
    }
}
