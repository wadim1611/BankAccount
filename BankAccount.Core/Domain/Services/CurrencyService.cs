using BankAccount.Core.Domain.Models;
using BankAccount.Core.Domain.Services.Interfaces;
using BankAccount.Core.Persistance.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankAccount.Core.Domain.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrenciesRepository _currenciesRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CurrencyService(ICurrenciesRepository currenciesRepository, IUnitOfWork unitOfWork)
        {
            _currenciesRepository = currenciesRepository ?? throw new ArgumentNullException(nameof(currenciesRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Currency> CreateAsync(Currency currency)
        {
            var createdCurrency =  await _currenciesRepository.CreateAsync(currency);
            await _unitOfWork.CompleteAsync();
            return createdCurrency;
        }

        public async Task DeleteAsync(int id)
        {
            var currency = await _currenciesRepository.GetByIdAsync(id);
            if (currency == null) throw new ArgumentNullException($"Currency with id: {id} not found");
            _currenciesRepository.Remove(currency);
        }

        public async Task<IEnumerable<Currency>> GetAllAsync()
        {
            return await _currenciesRepository.GetAll();
        }

        public async Task<Currency> GetByIdAsunc(int id)
        {
            return await _currenciesRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(int id, Currency currency)
        {
            var currencyToUpdate = await _currenciesRepository.GetByIdAsync(id);
            if (currencyToUpdate == null) throw new ArgumentNullException($"Currency with id: {id} not found");
            currency.Id = currencyToUpdate.Id;
            _currenciesRepository.Update(currency);
            await _unitOfWork.CompleteAsync();
        }
    }
}
