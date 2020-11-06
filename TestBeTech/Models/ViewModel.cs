using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestBeTech.Models
{
    public class ViewCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class ViewChoiceCategory
    {
        public IEnumerable<ViewCategory> categories { get; set; }
        public string NewName { get; set; }
        public int SelectedCategory { get; set; }
    }
    public class ViewCurrency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public double ExchangeRate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
    public class ViewStorage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
    public class ViewChoiceStorage
    {
        public IEnumerable<ViewStorage> storages { get; set; }
        public int SelectedStorage { get; set; }
        public string NewName { get; set; }
        public string NewAdress { get; set; }
        public List<Product> ProductsList { get; set; }
        public int SelectedCurrency { get; set; }
        public List<ViewCurrency> CurrencyList { get; set; }

    }
    public class ViewProduct
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public double BasicCurrPrice { get; set; }
        public double Price { get; set; }
        public int Barcode { get; set; }
        public int Count { get; set; }
        public string CategoryName { get; set; }
        public string CurrencyName { get; set; }
        public int SelectedCategory { get; set; }
        public int SelectedCurrency { get; set; }
        public int SelectedStorage{ get; set; }
        public IEnumerable<ViewCategory> categories { get; set; }
        public IEnumerable<ViewStorage> storages { get; set; }
        public IEnumerable<ViewCurrency> currencies  { get; set; }
    }
    public class ViewChoiseProduct
    {
        public string NewName { get; set; }
        public double NewPrice { get; set; }
        public int NewCount { get; set; }
        public int SelectedProduct { get; set; }
        public int SelectedCategory { get; set; }
        public int SelectedCurrency { get; set; }
        public int SelectedStorage { get; set; }
        public IEnumerable<ViewCategory> categories { get; set; }
        public IEnumerable<ViewStorage> storages { get; set; }
        public IEnumerable<ViewCurrency> currencies { get; set; }
        public IEnumerable<ViewProduct> products { get; set; }
    }
    public class ViewSumPrice
    {
        public Double Sum { get; set; }
        public string Curr { get; set; }
        public string StorName { get; set; }
    }
}
