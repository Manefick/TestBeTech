using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestBeTech.Models;

namespace TestBeTech.Controllers
{
    public class StorageController : Controller
    {
        private IStoregeRepository storegeRepository;
        private ICurrencyRepository currencyRepository;
        private IProductRepository productRepository;
        public StorageController(IStoregeRepository sr, IProductRepository product, ICurrencyRepository currency)
        {
            storegeRepository = sr;
            currencyRepository = currency;
            productRepository = product;
        }
        public IActionResult AddStorage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddStorage(ViewStorage info)
        {
            if (info != null)
            {
                storegeRepository.AddStorage(new Storage
                {
                    Name = info.Name,
                    Address = info.Address
                });

            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult EditStorage()
        {
            IEnumerable<Storage> storages = storegeRepository.Storages.ToList();
            IEnumerable<Currency> currencies = currencyRepository.Currencies.ToList();
            List<ViewCurrency> viewCurrencies = currencies.Select(x => new ViewCurrency
            {
                Id = x.Id,
                Name = x.Name,
                ShortName = x.ShortName,
                ExchangeRate = x.ExchangeRate,
                UpdateDate = x.UpdateDate
            }).ToList();
            List<ViewStorage> viewStorages = new List<ViewStorage>();
            if (storages != null)
            {
                foreach (Storage c in storages)
                {
                    viewStorages.Add(new ViewStorage { Id = c.Id, Name = c.Name, Address = c.Address });
                }
            }
            return View(new ViewChoiceStorage { storages = viewStorages, CurrencyList=viewCurrencies });
        }
        [HttpPost]
        public IActionResult EditStorage(ViewChoiceStorage info)
        {
            Storage storage = storegeRepository.Storages.Where(p => p.Id == info.SelectedStorage).FirstOrDefault();
            if (info.NewName != null && storage != null)
            {
                storage.Name = info.NewName;
                storegeRepository.EditStorage(storage);
            }
            if (info.NewAdress != null && storage != null)
            {
                storage.Address = info.NewAdress;
                storegeRepository.EditStorage(storage);
            }

            return RedirectToAction("Index", "Home");
        }
        public IActionResult DeleteStorage()
        {
            IEnumerable<Storage> storages = storegeRepository.Storages.ToList();
            List<ViewStorage> viewStorages = new List<ViewStorage>();
            if (storages != null)
            {
                foreach (Storage c in storages)
                {
                    viewStorages.Add(new ViewStorage { Id = c.Id, Name = c.Name, Address = c.Address });
                }
            }
            return View(new ViewChoiceStorage { storages = viewStorages });
        }
        [HttpPost]
        public IActionResult DeleteStorage(ViewChoiceStorage info)
        {
            Storage storage = storegeRepository.Storages.Where(p => p.Id == info.SelectedStorage).FirstOrDefault();
            if (storage != null)
            {
                storegeRepository.DeleteStorage(storage);
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult DisplayStorage()
        {
            IEnumerable<Storage> storages = storegeRepository.Storages.ToList();
            List<ViewStorage> viewStorages = new List<ViewStorage>();
            if (storages != null)
            {
                foreach (Storage c in storages)
                {
                    viewStorages.Add(new ViewStorage { Id = c.Id, Name = c.Name, Address = c.Address });
                }
            }
            return View(new ViewChoiceStorage { storages = viewStorages });
        }
        [HttpPost]
        public IActionResult DisplayStorage(ViewChoiceStorage info)
        {
            var x = storegeRepository.StorageWithProd(info.SelectedStorage);
            List<Product> prod = x.ProductStorages.Select(x => x.Product).ToList();
            List<ViewProduct> viewProducts = prod.Select(x => new ViewProduct
            {
                Name = x.Name,
                Id = x.Id,
                Barcode = x.Barcode,
                BasicCurrPrice = x.BasicCurrPrice,
                Count = x.Count,
                Price = x.Price,
                CategoryName = x.Category.Name,
                CurrencyName = x.Currency.ShortName
            }).ToList();
            return View("Display", viewProducts);
        }
        [HttpPost]
        public IActionResult SumProduct(ViewChoiceStorage info)
        {
            var prod = storegeRepository.StorageWithProd(info.SelectedStorage);
            List<Product> products = prod.ProductStorages.Select(x => x.Product).ToList();
            double SumBasicCurren = products.Sum(p => p.BasicCurrPrice * p.Count);
            double SumPriceProd = SumBasicCurren / currencyRepository.Currencies.FirstOrDefault(p => p.Id == info.SelectedCurrency)
                .ExchangeRate;
            return View(new ViewSumPrice { Curr = currencyRepository.Currencies.
                FirstOrDefault(p=>p.Id == info.SelectedCurrency).ShortName, StorName = storegeRepository.Storages
                .FirstOrDefault(p=>p.Id==info.SelectedStorage).Name, Sum = SumPriceProd});
        }

    }
}
