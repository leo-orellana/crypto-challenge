using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Interfaces
{
    public interface ICoinMarketService
    {
        Task<CryptoCurrency> GetQuotes();
        Task<CryptoCurrency> GetExchange(string Currency, string CurrencyToExchange);
    }

}
