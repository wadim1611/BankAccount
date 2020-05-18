using BankAccount.Core.Domain.Models;
using BankAccount.Core.Domain.Services.Interfaces;
using ExchangeRatesClientEcb.ServiceResponseClasses;
using Polly;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExchangeRatesClientEcb
{
    public class ExchangeRateClientEcb : IExchangeRateClient
    {
        private const string _ecbBaseCurrency = "EUR";
        private const string _ecbExchangeRateUrl = @"https://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml";

        private readonly HttpClient _httpClient;

        public ExchangeRateClientEcb(HttpClient httpClient) 
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<ExchangeRates> GetAsync()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, _ecbExchangeRateUrl);
            HttpResponseMessage response = await Execute(_httpClient, request);

            if (response.IsSuccessStatusCode)
            {
                var envelope = await ReadEcbDataAsync(response);
                return envelope.GetExchangeRates(_ecbBaseCurrency);
            }
            else
            {
                var msg = $"Exchane rate response failed. Code: {response.StatusCode}. Phrase: {response.ReasonPhrase}";
                throw new Exception(msg);
            }
        }

        private async Task<HttpResponseMessage> Execute(HttpClient client, HttpRequestMessage request)
        {
            CancellationToken cancellationToken = CancellationToken.None;
            var policy = Policy
                .Handle<HttpRequestException>()
                .WaitAndRetryAsync(new[] {
                TimeSpan.FromSeconds(1),
                TimeSpan.FromSeconds(2),
                TimeSpan.FromSeconds(4)
                });
            var response = await policy.ExecuteAsync(ct => client.SendAsync(request, ct), cancellationToken);

            return response;
        }

        private async Task<Envelope> ReadEcbDataAsync(HttpResponseMessage response)
        {
            try 
            {
                var stream = await response.Content.ReadAsStreamAsync();
                XmlSerializer serializer = new XmlSerializer(typeof(Envelope));
                Envelope envelope = (Envelope)serializer.Deserialize(stream);
                return envelope;
            }
            catch (Exception ex) 
            {
                throw new Exception("Unable to parse ECB response", ex);
            }
        }
    }
}
