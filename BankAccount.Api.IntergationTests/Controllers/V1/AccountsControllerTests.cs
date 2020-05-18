using BankAccount.Api.Contracts.V1;
using BankAccount.Api.Contracts.V1.Requests;
using BankAccount.Api.Contracts.V1.Responses;
using FluentAssertions;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace BankAccount.Api.IntergationTests.Controllers.V1
{
    public class AccountsControllerTests : IntegrationTest
    {
        [Fact]
        public async Task GetAll_WithoutAnyAccounts_ReturnsEmptyResponse()
        {
            // Arrange

            // Act
            var response = await TestClient.GetAsync(ApiRoutes.Accounts.GetAll);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            (await response.Content.ReadAsAsync<List<AccountModel>>()).Should().BeEmpty();
        }

        [Fact]
        public async Task Get_ReturnsAccounts_WhenAccountExistsInTheDatabase()
        {
            // Arrange
            var createdAccount = await CreatePostAsync(new AccountSaveModel 
            {
                UserId = 0, 
                CurrencyId = 0 
            });

            // Act
            var response = await TestClient.GetAsync(ApiRoutes.Accounts.Get.Replace("{id}", createdAccount.Id.ToString()));

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var returnedPost = await response.Content.ReadAsAsync<AccountModel>();
            returnedPost.Id.Should().Be(createdAccount.Id);
            returnedPost.CurrencyCode.Should().Be(createdAccount.CurrencyCode);
        }

        protected async Task<AccountModel> CreatePostAsync(AccountSaveModel request)
        {
            var response = await TestClient.PostAsJsonAsync(ApiRoutes.Accounts.Create, request);
            return await response.Content.ReadAsAsync<AccountModel>();
        }
    }
}
