using BankAccount.Core.Domain.Models;
using BankAccount.Core.Domain.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BankAccount.Core.Domain.Services
{
    public class ExchangeRateService : IExchangeRateService
    {
        private readonly IExchangeRateClient _exchangeRateClient;
        //private readonly IHttpClientFactory _clientFactory;
        private readonly IMemoryCache _cache;

        public ExchangeRateService(IExchangeRateClient exchangeRateClient, IMemoryCache memoryCache) //, IHttpClientFactory clientFactory
        {
            _exchangeRateClient = exchangeRateClient ?? throw new ArgumentNullException(nameof(exchangeRateClient));
            _cache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
            //_clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
        }

        public async Task<ExchangeRatePair> GetAsync(string currCodeFrom, string currCodeTo)
        {
            return await GetAsync(currCodeFrom, currCodeTo, DateTime.UtcNow.Date);
        }

        public async Task<ExchangeRatePair> GetAsync(string currCodeFrom, string currCodeTo, DateTime date)
        {
            var yestorday = DateTime.UtcNow.AddDays(-1).Date;
            if (date >= yestorday)
            {
                string exchangeRateKey = $"CurrencyExchangeRateFor_{date.Date}";
                ExchangeRates rates = await GetExchangeRates(exchangeRateKey);
                var exchangePair = GetExchangePair(rates, currCodeFrom, currCodeTo);
                return exchangePair;
            }
            else
            {
                // TODO: keep exchange rate history
            }

            throw new ArgumentOutOfRangeException($"Can not find exchange rate for a pair {currCodeFrom} - {currCodeTo} on {date}");
        }

        private async Task<ExchangeRates> GetExchangeRates(string exchangeRateKey)
        {
            ExchangeRates ratesEntry;
            if (!_cache.TryGetValue(exchangeRateKey, out ratesEntry))
            {
                Semaphore semaphore = new Semaphore(0, 1);
                try
                {
                    semaphore.WaitOne();
                    if (!_cache.TryGetValue(exchangeRateKey, out ratesEntry))
                    {
                        //var client = _clientFactory.CreateClient();
                        ratesEntry = await _exchangeRateClient.GetAsync();
                        // TODO: save rates to history
                        int seconsTillTomorrow = GetSecondsTillTomorrow();
                        var cacheEntryOptions = new MemoryCacheEntryOptions()
                            .SetAbsoluteExpiration(TimeSpan.FromSeconds(seconsTillTomorrow));

                        _cache.Set(exchangeRateKey, ratesEntry, cacheEntryOptions);
                    }
                }
                finally
                {
                    semaphore.Release();
                }
            }

            return ratesEntry;
        }

        private ExchangeRatePair GetExchangePair(ExchangeRates rates, string CurrCodeFrom, string CurrCodeTo)
        {
            if (rates.Base == CurrCodeFrom)
            {
                if (rates.Rates.ContainsKey(CurrCodeTo))
                {
                    var exchangeRatePair = new ExchangeRatePair(CurrCodeFrom, CurrCodeTo);
                    exchangeRatePair.Rate = rates.Rates[CurrCodeTo];
                    exchangeRatePair.Date = rates.Date;
                    return exchangeRatePair;
                }
            }
            else
            {
                if (rates.Rates.ContainsKey(CurrCodeFrom) && rates.Rates.ContainsKey(CurrCodeTo))
                {
                    var exchangeRatePair = new ExchangeRatePair(CurrCodeFrom, CurrCodeTo);
                    exchangeRatePair.Rate = rates.Rates[CurrCodeFrom] / rates.Rates[CurrCodeTo];
                    exchangeRatePair.Date = rates.Date;
                    return exchangeRatePair;
                }
            }

            return null;
        }

        private static int GetSecondsTillTomorrow()
        {
            DateTime now = DateTime.UtcNow;
            DateTime tomorrow = now.AddDays(1).Date;
            int seconsTillTomorrow = (int)(tomorrow - now).TotalSeconds;
            return seconsTillTomorrow;
        } 
    }
}
