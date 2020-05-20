using BankAccount.Api.AppServices.Interfaces;
using BankAccount.Api.Contracts.V1;
using BankAccount.Api.Contracts.V1.Requests;
using BankAccount.Api.Contracts.V1.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankAccount.Api.Controllers.V1
{
    public class AccountsController : ControllerBase
    {
        private readonly IAccountManager _accountManager;

        public AccountsController(IAccountManager accountManager)
        {
            _accountManager = accountManager ?? throw new ArgumentNullException(nameof(accountManager));
        }

        [HttpGet(ApiRoutes.Accounts.GetAll)]
        [ProducesResponseType(typeof(IEnumerable<AccountModel>), 200)]
        public async Task<IActionResult> Get()
        {
            var accounts = await _accountManager.GetAll();
            return new JsonResult(accounts);
        }

        [HttpGet(ApiRoutes.Accounts.Get)]
        [ProducesResponseType(typeof(AccountModel), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(int id)
        {
            var account = await _accountManager.GetById(id);
            if(account != null)
            {
                return new JsonResult(account);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost(ApiRoutes.Accounts.Create)]
        [ProducesResponseType(typeof(AccountModel), 201)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> Post([FromBody] AccountSaveModel model)
        {
            var account = await _accountManager.CreateAccount(model);
            return new JsonResult(account);
        }

        [HttpPut(ApiRoutes.Accounts.Debit)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> Debit([FromBody] AccountDebitModel model)
        {
            await _accountManager.DebitAccount(model);
            return Ok();
        }

        [HttpPut(ApiRoutes.Accounts.Withdraw)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> Withdraw([FromBody] AccountWithdrawModel model)
        {
            await _accountManager.WithdrawAccount(model);
            return Ok();
        }

        [HttpPut(ApiRoutes.Accounts.Transfer)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> Transfer([FromBody] AccountTransferMoneyModel model)
        {
            await _accountManager.TransferMoney(model);
            return Ok();
        }

        [HttpDelete(ApiRoutes.Accounts.Delete)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> Delete(int id)
        {
            await _accountManager.DeleteAccount(id);
            return Ok();
        }
    }
}
