using AutoMapper;
using BankAccount.Api.AppServices.Interfaces;
using BankAccount.Api.Contracts.V1.Requests;
using BankAccount.Api.Contracts.V1.Responses;
using BankAccount.Core.Domain.Models;
using BankAccount.Core.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankAccount.Api.AppServices
{
    public class CurrencyManager : ICurrencyManager
    {
        private readonly ICurrencyService _currenciesService;
        private readonly IMapper _mapper;

        public CurrencyManager(ICurrencyService currenciesService, IMapper mapper)
        {
            _currenciesService = currenciesService ?? throw new ArgumentNullException(nameof(currenciesService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CurrencyModel> CreateAsync(CurrencySaveModel model)
        {
            var currency = _mapper.Map<Currency>(model);
            var createdCurrency = await _currenciesService.CreateAsync(currency);
            return _mapper.Map<CurrencyModel>(createdCurrency);
        }

        public async Task DeleteAsync(int userId)
        {
            await _currenciesService.DeleteAsync(userId);
        }

        public async Task<IEnumerable<CurrencyModel>> GetAllAsync()
        {
            var currencies = await _currenciesService.GetAllAsync();
            return _mapper.Map<IEnumerable<CurrencyModel>>(currencies);
        }

        public async Task<CurrencyModel> GetByIdAsync(int id)
        {
            var currency = await _currenciesService.GetByIdAsunc(id);
            return _mapper.Map<CurrencyModel>(currency);
        }

        public async Task UpdateAsync(int id, CurrencySaveModel model)
        {
            var currency = _mapper.Map<Currency>(model);
            await _currenciesService.UpdateAsync(id, currency);
        }
    }
}
