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
        private const int CodeEur = 978;

        private ICurrencyRepository currencyRepository;
        private IProductRepository productRepository;
        public CurrencyController(ICurrencyRepository currency, IProductRepository product)
        {
            currencyRepository = currency;
            productRepository = product;
        }

        static readonly HttpClient httpClient = new HttpClient();
        public async Task<IActionResult> UpdateCurrency()
        {
            HttpResponseMessage responseByte = await httpClient.GetAsync("https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json");
            string response = await responseByte.Content.ReadAsStringAsync();
            List<CurrencyJsonModel> currencyJsonModels = JsonConvert.DeserializeObject<List<CurrencyJsonModel>>(response);
            Currency currencyUsd = currencyRepository.Currencies.FirstOrDefault(p => p.ShortName == "USD");
            Currency currencyEur = currencyRepository.Currencies.FirstOrDefault(p => p.ShortName == "EUR");
            Currency currencyUah = currencyRepository.Currencies.FirstOrDefault(p => p.ShortName == "UAH");
            foreach(var x in currencyJsonModels)
            {
                if(x.Code==CodeUsd)
                {
                    currencyUah.ExchangeRate = 1 / x.ExchangeRate;
                    currencyUah.UpdateDate = x.UpdateDate;
                    currencyRepository.EditCurrency(currencyUah);
                    currencyUsd.UpdateDate = x.UpdateDate;
                    currencyRepository.EditCurrency(currencyUsd);
                }
                if (x.Code == CodeEur)
                {
                    currencyEur.ExchangeRate =  currencyUah.ExchangeRate* x.ExchangeRate;
                    currencyEur.UpdateDate = x.UpdateDate;
                    currencyRepository.EditCurrency(currencyEur);
                }
            }
            foreach(Product product in productRepository.Products.ToList())
            {
                product.BasicCurrPrice = product.Price * 
                    currencyRepository.Currencies.FirstOrDefault(p=>p.Id ==product.CurrencyId).ExchangeRate;
                productRepository.EditProduct(product);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
