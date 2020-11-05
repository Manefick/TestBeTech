using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestBeTech.Models
{
    public class CurrencyJsonModel
    {
        [JsonProperty("r030")]
        public int Code { get; set; }
        [JsonProperty("cc")]
        public string ShortName { get; set; }
        [JsonProperty("rate")]
        public double ExchangeRate { get; set; }
        [JsonProperty("exchangedate")]
        public DateTime UpdateDate { get; set; }
    }
}
