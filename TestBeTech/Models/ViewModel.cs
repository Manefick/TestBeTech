using System;
using System.Collections.Generic;
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
    }
    public class ViewProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double BasicCurrPrice { get; set; }
        public double Price { get; set; }
        public int Barcode { get; set; }
        public int Count { get; set; }
        public int SelectedCategory { get; set; }
        public int SelectedCurrency { get; set; }
        public int SelectedStorage{ get; set; }
        public IEnumerable<ViewCategory> categories { get; set; }
        public IEnumerable<ViewStorage> storages { get; set; }
        public IEnumerable<ViewCurrency> currencies  { get; set; }
    }
}
