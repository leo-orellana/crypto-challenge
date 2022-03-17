using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace backend.Models
{
    public class CryptoCurrency
    {
        [JsonPropertyName("status")]
        public Status Status { get; set; }
        [JsonPropertyName("data")]
        public Dictionary<string, Data> Data { get; set; }
    }

    public class Status
    {
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }
        [JsonPropertyName("error_code")]
        public int ErrorCode { get; set; }
        [JsonPropertyName("error_message")]
        public string ErrorMessage { get; set; }
        [JsonPropertyName("elapsed")]
        public int Elapsed { get; set; }
        [JsonPropertyName("credit_count")]
        public int CreditCount { get; set; }
        [JsonPropertyName("notice")]
        public string Notice { get; set; }
    }

    public class Data
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
        [JsonPropertyName("slug")]
        public string Slug { get; set; }
        [JsonPropertyName("quote")]
        public Dictionary<string, QuoteData> Quote { get; set; }
    }

    public class QuoteData
    {
        [JsonPropertyName("price")]
        public float Price { get; set; }
        [JsonPropertyName("last_updated")]
        public DateTime LastUpdated { get; set; }
    }

}
