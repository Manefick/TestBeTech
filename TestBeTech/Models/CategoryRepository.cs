using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestBeTech.Models
{
    public class CategoryRepository:ICategoryRepository
    {
        private ApplicationDbContext context;
        public CategoryRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Category> Categories => context.Categories;
        public void AddCategory(Category category)
        {
            if (category != null)
            {
                context.Categories.Add(category);
            }
            context.SaveChanges();
        }
        public void EditCategory(Category category)
        {
            if (category != null)
            {
                context.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void DeleteCategory(Category category)
        {
            if (category != null)
            {
                context.Remove(category);
                context.SaveChanges();
            }
        }
    }
}
