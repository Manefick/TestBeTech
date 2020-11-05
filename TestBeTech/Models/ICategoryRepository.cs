using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestBeTech.Models
{
    public interface ICategoryRepository
    {
        IQueryable<Category> Categories { get; }
        public void AddCategory(Category category) { }
        public void EditCategory(Category category) { }
        public void DeleteCategory(Category category) { }
    }
}
