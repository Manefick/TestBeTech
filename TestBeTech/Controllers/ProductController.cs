using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestBeTech.Models;

namespace TestBeTech.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository productRepository;
        private ICurrencyRepository currencyRepository;
        private IStoregeRepository storegeRepository;
        private ICategoryRepository categoryRepository;
        public ProductController(ICategoryRepository category, ICurrencyRepository currency, 
            IProductRepository product, IStoregeRepository storege)
        {
            productRepository = product;
            currencyRepository = currency;
            storegeRepository = storege;
            categoryRepository = category;
        }
        public IActionResult AddProduct()
        {
            IEnumerable<Category> categories = categoryRepository.Categories.ToList();
            IEnumerable<Currency> currencies = currencyRepository.Currencies.ToList();
            IEnumerable<Storage> storages = storegeRepository.Storages.ToList();
            List<ViewCategory> viewCategories = new List<ViewCategory>();
            List<ViewCurrency> viewCurrencies = new List<ViewCurrency>();
            List<ViewStorage> viewStorages = new List<ViewStorage>();
            if (categories != null)
            {
                foreach(Category c in categories)
                {
                    viewCategories.Add(new ViewCategory { Id = c.Id, Name = c.Name });
                }
            }
            if (currencies != null)
            {
                foreach(Currency c in currencies)
                {
                    viewCurrencies.Add(new ViewCurrency
                    {
                        Id = c.Id,
                        Name = c.Name,
                        ShortName = c.ShortName,
                        ExchangeRate = c.ExchangeRate,
                        UpdateDate = c.UpdateDate
                    });
                }
            }
            if (storages != null)
            {
                foreach(Storage s in storages)
                {
                    viewStorages.Add(new ViewStorage { Id = s.Id, Name = s.Name, Address = s.Address });
                }
            }
            return View(new ViewProduct { categories = viewCategories, currencies=viewCurrencies, storages = viewStorages});
        }
        [HttpPost]
        public IActionResult AddProduct(ViewProduct info)
        {
            if (info != null)
            {
                Storage storage = storegeRepository.Storages.Where(p => p.Id == info.SelectedStorage).FirstOrDefault();
                Currency currency = currencyRepository.Currencies.Where(p => p.Id == info.SelectedCurrency).FirstOrDefault();
                Product prod = productRepository.AddProduct(new Product
                {
                    Name = info.Name,
                    Price = info.Price,
                    CategoryId = info.SelectedCategory,
                    Count = info.Count,
                    CurrencyId = info.SelectedCurrency,
                    BasicCurrPrice = info.Price * currency.ExchangeRate,
                    ProductStorages = new List<ProductStorage> { new ProductStorage {Storage = storage } }//??
                });

            }
            return RedirectToAction("Index", "Home");
        }
    }
}
