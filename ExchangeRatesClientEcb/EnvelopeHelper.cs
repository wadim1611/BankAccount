using BankAccount.Core.Domain.Models;
using ExchangeRatesClientEcb.ServiceResponseClasses;
using System.Linq;

namespace ExchangeRatesClientEcb
{
    public static class EnvelopeHelper
    {
        public static ExchangeRates GetExchangeRates(this Envelope envelope, string baseCurrency)
        {
            var date = envelope.Cube.Cube1.time;
            var envelopeRates = envelope.Cube.Cube1.Cube;

            ExchangeRates exchangeRates = new ExchangeRates()
            {
                Base = baseCurrency,
                Date = date,
                Rates = envelopeRates.ToDictionary(r => r.currency.ToUpper(), r => r.rate)
            };

            return exchangeRates;
        }
    }
}
