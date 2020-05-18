using BankAccount.Core.Domain.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace BankAccount.Core.Domain.Services.Interfaces
{
    public interface IExchangeRateClient
    {
        Task<ExchangeRates> GetAsync();
    }
}
