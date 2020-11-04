using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TestBeTech.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double BasicCurrPrice { get; set; }
        public double Price { get; set; }
        public int Barcode { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public ICollection<ProductStorage> ProductStorages { get; set; }
       
    }
    public class ProductStorage
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int StorageId { get; set; }
        public Storage Storage { get; set; }
    }
}
