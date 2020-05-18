using System.Net.Http;
using Xunit;

namespace ExchangeRatesClientEcb.Tests
{
    public class ExchangeRateClientTests
    {
        [Fact]
        public async void ExchangeRateClient_GetExchangeRate_Success()
        {
            // arrange
            var client = new HttpClient();
            ExchangeRateClientEcb exchangeRateClient = new ExchangeRateClientEcb(client);

            // act
            var actual = await exchangeRateClient.GetAsync();

            // assert
            var exception = await Record.ExceptionAsync(() => exchangeRateClient.GetAsync());
            Assert.Null(exception);
        }
    }
}
