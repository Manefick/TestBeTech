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
    }
}
