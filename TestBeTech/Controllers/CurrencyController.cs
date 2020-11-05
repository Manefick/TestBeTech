using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestBeTech.Models;

namespace TestBeTech.Controllers
{
    public class CurrencyController : Controller
    {
        private const int CodeUsd = 840;
        private ICurrencyRepository currencyRepository;
        public CurrencyController(ICurrencyRepository currency)
        {
            currencyRepository = currency;
        }

        static readonly HttpClient httpClient = new HttpClient();
        public async Task<IActionResult> UpdateCurrency()
        {
            HttpResponseMessage responseByte = await httpClient.GetAsync("https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json");
            string response = await responseByte.Content.ReadAsStringAsync();
            List<CurrencyJsonModel> currencyJsonModels = JsonConvert.DeserializeObject<List<CurrencyJsonModel>>(response);
            Currency currencyUsd = currencyRepository.Currencies.FirstOrDefault(p => p.ShortName == "USD");
            foreach(var x in currencyJsonModels)
            {
                if(x.Code==CodeUsd)
                {
                    currencyUsd.ExchangeRate = x.ExchangeRate;
                    currencyUsd.UpdateDate = x.UpdateDate;
                    currencyRepository.EditCurrency(currencyUsd);
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
