using BankAccount.Api.AppServices.Interfaces;
using BankAccount.Api.Contracts.V1;
using BankAccount.Api.Contracts.V1.Requests;
using BankAccount.Api.Contracts.V1.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BankAccount.Api.Controllers.V1
{
    public class CurrenciesController : ControllerBase
    {
        private readonly ICurrencyManager _currencyManager;

        public CurrenciesController(ICurrencyManager currencyManager)
        {
            _currencyManager = currencyManager ?? throw new ArgumentNullException(nameof(currencyManager)); 
        }

        [HttpGet(ApiRoutes.Currencies.GetAll)]
        public async Task<IActionResult> Get()
        {
            var accounts = await _currencyManager.GetAllAsync();
            return new JsonResult(accounts);
        }

        [HttpGet(ApiRoutes.Currencies.Get)]
        public async Task<IActionResult> Get(int id)
        {
            var account = await _currencyManager.GetByIdAsync(id);
            return new JsonResult(account);
        }

        [HttpPost(ApiRoutes.Currencies.Create)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> Post([FromBody] CurrencySaveModel model)
        {
            var currency = await _currencyManager.CreateAsync(model);
            return new JsonResult(currency);
        }

        [HttpPut(ApiRoutes.Currencies.Update)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> Put(int id, [FromBody] CurrencySaveModel model)
        {
            await _currencyManager.UpdateAsync(id, model);
            return Ok();
        }

        [HttpDelete(ApiRoutes.Currencies.Delete)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task Delete(int id)
        {
            await _currencyManager.DeleteAsync(id);
        }
    }
}
