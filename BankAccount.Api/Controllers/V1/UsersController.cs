using BankAccount.Api.AppServices.Interfaces;
using BankAccount.Api.Contracts.V1;
using BankAccount.Api.Contracts.V1.Requests;
using BankAccount.Api.Contracts.V1.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BankAccount.Api.Controllers.V1
{
    public class UsersController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public UsersController(IUserManager userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        [HttpGet(ApiRoutes.Users.GetAll)]
        public async Task<IActionResult> Get()
        {
            var users = await _userManager.GetAllAsync();
            return new JsonResult(users);
        }

        [HttpGet(ApiRoutes.Users.Get)]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _userManager.GetByIdAsync(id);
            return new JsonResult(user);
        }

        [HttpPost(ApiRoutes.Users.Create)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> Post([FromBody] UserSaveModel model)
        {
            var user = await _userManager.CreateUserAsync(model);
            return new JsonResult(user);
        }

        [HttpPut(ApiRoutes.Users.Update)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> Put(int id, [FromBody] UserSaveModel model)
        {
            await _userManager.UpdateUserAsync(id, model);
            return Ok();
        }

        [HttpDelete(ApiRoutes.Users.Delete)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> Delete(int id)
        {
            await _userManager.DeleteUserAsync(id);
            return Ok();
        }
    }
}
