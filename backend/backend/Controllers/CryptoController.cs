using backend.Interfaces;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CryptoController : ControllerBase
    {
        private readonly ILogger<CryptoController> _logger;
        private readonly ICoinMarketService _coinMarketService;

        public CryptoController(ILogger<CryptoController> logger, ICoinMarketService coinMarketService)
        {
            _logger = logger;
            _coinMarketService = coinMarketService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CryptoResponse>>> GetAsync()
        {
            try
            {
                List<CryptoResponse> cr = new List<CryptoResponse>();

                CryptoCurrency currency = await this._coinMarketService.GetQuotes();

                foreach (var item in currency.Data.Values.ToList())
                {
                    cr.Add(new CryptoResponse
                    {
                        Name = item.Name,
                        Price = item.Quote.Values.ToList()[0].Price,
                        LastUpdated = item.Quote.Values.ToList()[0].LastUpdated
                    });
                }

                return cr;
            }
            catch (HttpRequestException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<ExchangeResponse>>> PostAsync(ExchangeParams Params)
        {
            try
            {
                List<ExchangeResponse> er = new List<ExchangeResponse>();

                foreach (var currency in Params.CurrenciesToExchange)
                {

                    CryptoCurrency crypto = await _coinMarketService.GetExchange(Params.Currency, currency);

                    foreach (var item in crypto.Data.Values.ToList())
                    {
                        er.Add(new ExchangeResponse
                        {
                            Name = item.Quote.Keys.ToList()[0],
                            Price = item.Quote.Values.ToList()[0].Price * Params.Amount
                        });
                    }
                }
                return er;
            }
            catch (HttpRequestException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
