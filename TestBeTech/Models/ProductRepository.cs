using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestBeTech.Models
{
    public class ProductRepository: IProductRepository
    {
        private ApplicationDbContext context;
        public ProductRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Product> Products => context.Products;
        public Product AddProduct(Product product)
        {
            if (product != null)
            {
                context.Products.Add(product);
            }
            context.SaveChanges();
            return product;
        }
        public void EditProduct(Product product)
        {
            if (product != null)
            {
                context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void DeleteProduct(Product product)
        {
            if (product != null)
            {
                context.Remove(product);
                context.SaveChanges();
            }
        }
    }
}
