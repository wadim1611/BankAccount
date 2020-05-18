using BankAccount.Core.Domain.Models;
using System;
using System.Threading.Tasks;

namespace BankAccount.Core.Domain.Services.Interfaces
{
    public interface IExchangeRateService
    {
        Task<ExchangeRatePair> GetAsync(string currCodeFrom, string currCodeTo);

        Task<ExchangeRatePair> GetAsync(string currCodeFrom, string currCodeTo, DateTime dateTime);
    }
}
