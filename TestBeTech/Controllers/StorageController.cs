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
        public StorageController(IStoregeRepository sr)
        {
            storegeRepository = sr;
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

    }
}
