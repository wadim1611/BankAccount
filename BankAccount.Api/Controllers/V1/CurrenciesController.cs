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
    public class CurrenciesController : ControllerBase
    {
        private readonly ICurrencyManager _currencyManager;

        public CurrenciesController(ICurrencyManager currencyManager)
        {
            _currencyManager = currencyManager ?? throw new ArgumentNullException(nameof(currencyManager)); 
        }

        [HttpGet(ApiRoutes.Currencies.GetAll)]
        [ProducesResponseType(typeof(IEnumerable<CurrencyModel>), 200)]
        public async Task<IActionResult> Get()
        {
            var currencies = await _currencyManager.GetAllAsync();
            return new JsonResult(currencies);
        }

        [HttpGet(ApiRoutes.Currencies.Get)]
        [ProducesResponseType(typeof(CurrencyModel), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(int id)
        {
            var currency = await _currencyManager.GetByIdAsync(id);
            if(currency != null)
            {
                return new JsonResult(currency);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost(ApiRoutes.Currencies.Create)]
        [ProducesResponseType(typeof(CurrencyModel), 201)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> Post([FromBody] CurrencySaveModel model)
        {
            var currency = await _currencyManager.CreateAsync(model);
            return new JsonResult(currency);
        }

        [HttpPut(ApiRoutes.Currencies.Update)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> Put(int id, [FromBody] CurrencySaveModel model)
        {
            await _currencyManager.UpdateAsync(id, model);
            return Ok();
        }

        [HttpDelete(ApiRoutes.Currencies.Delete)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task Delete(int id)
        {
            await _currencyManager.DeleteAsync(id);
        }
    }
}
