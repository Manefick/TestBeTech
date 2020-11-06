using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestBeTech.Models;

namespace TestBeTech.Controllers
{
    public class HomeController : Controller
    {
        private ICurrencyRepository currencyRepository;
        public HomeController(ICurrencyRepository currency)
        {
            currencyRepository = currency;
        }
        public IActionResult Index()
        {
            Currency currency = currencyRepository.Currencies.FirstOrDefault();
            return View(currency);
        }
    }
}
