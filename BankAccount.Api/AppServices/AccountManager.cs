using AutoMapper;
using BankAccount.Api.AppServices.Interfaces;
using BankAccount.Api.Contracts.V1.Requests;
using BankAccount.Api.Contracts.V1.Responses;
using BankAccount.Core.Domain.Commands;
using BankAccount.Core.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankAccount.Api.AppServices
{
    public class AccountManager : IAccountManager
    {
        private readonly IExchangeRateService _exchangeRateService;
        private readonly ICurrencyService _currencyService;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountManager(IAccountService accountService, IMapper mapper, IExchangeRateService exchangeRateService, ICurrencyService currencyService)
        {
            _exchangeRateService = exchangeRateService ?? throw new ArgumentNullException(nameof(exchangeRateService));
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
            _currencyService = currencyService ?? throw new ArgumentNullException(nameof(currencyService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<AccountModel>> GetAll()
        {
            var accounts = await _accountService.GetAllAsync();
            return _mapper.Map<IEnumerable<AccountModel>>(accounts);
        }

        public async Task<AccountModel> GetById(int id)
        {
            var account = await _accountService.GetByIdAsunc(id);
            return _mapper.Map<AccountModel>(account);
        }

        public async Task DeleteAccount(int id)
        {
            await _accountService.DeleteAsync(id);
        }

        public async Task<AccountModel> CreateAccount(AccountSaveModel model)
        {
            var createdAccount = await _accountService.CreateAccountAsync(model.UserId, model.CurrencyId);
            return _mapper.Map<AccountModel>(createdAccount);
        }

        public async Task DebitAccount(AccountDebitModel model)
        {
            var command = new BankAccountCommand(_accountService, model.AccountId, BankAccountCommand.Action.Deposit, model.Amount);
            await _accountService.ExecuteAsync(command);
        }

        public async Task TransferMoney(AccountTransferMoneyModel model)
        {
            var accountFrom =  await _accountService.GetByIdAsunc(model.AccountIdFrom);
            var accountTo = await _accountService.GetByIdAsunc(model.AccountIdTo);
            decimal exchangeRate = 1;
            if (accountFrom.CurrencyId != accountTo.CurrencyId) // need exchange
            {
                var currencyFrom = await _currencyService.GetByIdAsunc(accountFrom.CurrencyId);
                var currencyTo = await _currencyService.GetByIdAsunc(accountTo.CurrencyId);
                var exchangeRatePair = await _exchangeRateService.GetAsync(currencyFrom.Code, currencyTo.Code);
                exchangeRate = exchangeRatePair.Rate;
            }
           
            var command = new MoneyTransferCommand(_accountService, model.AccountIdFrom, model.AccountIdTo, model.Amount, exchangeRate);
            await _accountService.ExecuteAsync(command);
        }

        public async Task WithdrawAccount(AccountWithdrawModel model)
        {
            var command = new BankAccountCommand(_accountService, model.AccountId, BankAccountCommand.Action.Withdraw, model.Amount);
            await _accountService.ExecuteAsync(command);
        }
    }
}
