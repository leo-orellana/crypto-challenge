using backend.Interfaces;
using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace backend
{
    public class CoinMarketService : ICoinMarketService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CoinMarketService(IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory;
        }

        public async Task<CryptoCurrency> GetQuotes()
        {
            HttpClient client = _httpClientFactory.CreateClient("CoinMarketHttpClient");
            string path = $"quotes/latest?symbol=btc,eth,bnb,usdt,ada";

            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return System.Text.Json.JsonSerializer.Deserialize<CryptoCurrency>(responseBody);
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
        }

        public async Task<CryptoCurrency> GetExchange(string Currency, string CurrencyToExchange)
        {
            HttpClient client = _httpClientFactory.CreateClient("CoinMarketHttpClient");
            string path = $"quotes/latest?symbol={Currency}&convert=";

            HttpResponseMessage response = await client.GetAsync(path + CurrencyToExchange);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return System.Text.Json.JsonSerializer.Deserialize<CryptoCurrency>(responseBody);
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
        }
    }
}
