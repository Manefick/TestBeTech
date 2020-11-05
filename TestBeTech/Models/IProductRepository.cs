using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestBeTech.Models
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
        public Product AddProduct(Product product);
        public void EditProduct(Product product) { }
        public void DeleteProduct(Product product) { }
    }
}
