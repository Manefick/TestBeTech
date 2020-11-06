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
                foreach (Category c in categories)
                {
                    viewCategories.Add(new ViewCategory { Id = c.Id, Name = c.Name });
                }
            }
            if (currencies != null)
            {
                foreach (Currency c in currencies)
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
                foreach (Storage s in storages)
                {
                    viewStorages.Add(new ViewStorage { Id = s.Id, Name = s.Name, Address = s.Address });
                }
            }
            return View(new ViewProduct { categories = viewCategories, currencies = viewCurrencies, storages = viewStorages });
        }
        [HttpPost]
        public IActionResult AddProduct(ViewProduct info)
        {
            if (info != null)
            {
                Storage storage = storegeRepository.Storages.Where(p => p.Id == info.SelectedStorage).FirstOrDefault();
                Currency currency = currencyRepository.Currencies.Where(p => p.Id == info.SelectedCurrency).FirstOrDefault();
                Random rnd = new Random();
                Product prod = productRepository.AddProduct(new Product
                {
                    Name = info.Name,
                    Price = info.Price,
                    CategoryId = info.SelectedCategory,
                    Count = info.Count,
                    CurrencyId = info.SelectedCurrency,
                    BasicCurrPrice = info.Price * currency.ExchangeRate,
                    Barcode = rnd.Next(10000000, 99999999),
                    ProductStorages = new List<ProductStorage> { new ProductStorage { StorageId = storage.Id } }
                });


            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult EditProduct()
        {
            List<Product> products = productRepository.Products.ToList();
            List<ViewProduct> viewProducts = products.Select(x => new ViewProduct
            {
                Id = x.Id,
                Barcode = x.Barcode,
                BasicCurrPrice = x.BasicCurrPrice,
                Count = x.Count,
                Name = x.Name,
                Price = x.Price
            }).ToList();
            List < Storage > storages = storegeRepository.Storages.ToList();
            List<ViewStorage> viewStorages = storages.Select(x => new ViewStorage
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address
            }).ToList();
            List<Currency> currencies = currencyRepository.Currencies.ToList();
            List<ViewCurrency> viewCurrencies = currencies.Select(x => new ViewCurrency
            {
                Id = x.Id,
                Name = x.Name,
                ExchangeRate = x.ExchangeRate,
                ShortName = x.ShortName,
                UpdateDate = x.UpdateDate
            }).ToList();
            List<Category> categories = categoryRepository.Categories.ToList();
            List<ViewCategory> viewCategories = categories.Select(x => new ViewCategory
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return View(new ViewChoiseProduct
            {
                categories = viewCategories,
                products = viewProducts,
                currencies = viewCurrencies,
                storages = viewStorages
            });

        }
        [HttpPost]
        public IActionResult EditProduct(ViewChoiseProduct info)
        {
            Storage storage = storegeRepository.Storages.Where(p => p.Id == info.SelectedStorage).FirstOrDefault();
            Product product = productRepository.Products.FirstOrDefault(p => p.Id == info.SelectedProduct);
            Currency currency = currencyRepository.Currencies.FirstOrDefault(p => p.Id == info.SelectedCurrency);
            Category category = categoryRepository.Categories.FirstOrDefault(p => p.Id == info.SelectedCategory);
            if (info.NewName != null)
            { product.Name = info.NewName; }
            if (info.NewPrice != 0)
            { product.Price = info.NewPrice; }
            product.Count = info.NewCount;
            product.CategoryId = category.Id;
            product.CurrencyId = currency.Id;
            product.ProductStorages = new List<ProductStorage> { new ProductStorage { StorageId = storage.Id } };
            productRepository.EditProduct(product);
            return RedirectToAction("Index", "Home");
        }
    }
}
