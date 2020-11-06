using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestBeTech.Models;

namespace TestBeTech.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepository categoryRepository;
        public CategoryController(ICategoryRepository cr)
        {
            categoryRepository = cr;
        }
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(ViewCategory viewCategory)
        {
            if (viewCategory.Name != null)
            {
                categoryRepository.AddCategory(new Category { Name = viewCategory.Name });
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult EditCategory()
        {
            IEnumerable<Category> categories = categoryRepository.Categories.ToList();
            List<ViewCategory> viewCategories = new List<ViewCategory>();
            if (categories != null)
            {
                foreach (Category c in categories)
                {
                    viewCategories.Add(new ViewCategory { Id = c.Id, Name = c.Name });
                }
            }
            return View(new ViewChoiceCategory { categories = viewCategories });
        }
        [HttpPost]
        public IActionResult EditCategory(ViewChoiceCategory info)
        {
            Category category = categoryRepository.Categories.Where(p => p.Id == info.SelectedCategory).FirstOrDefault();
            if (info.NewName != null&&category!=null)
            {
                category.Name = info.NewName;
                categoryRepository.EditCategory(category);
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult DeleteCategory()
        {
            IEnumerable<Category> categories = categoryRepository.Categories.ToList();
            List<ViewCategory> viewCategories = new List<ViewCategory>();
            if (categories != null)
            {
                foreach (Category c in categories)
                {
                    viewCategories.Add(new ViewCategory { Id = c.Id, Name = c.Name });
                }
            }
            return View(new ViewChoiceCategory { categories = viewCategories });
        }
        [HttpPost]
        public IActionResult DeleteCategory(ViewChoiceCategory info)
        {
            Category category = categoryRepository.Categories.Where(p => p.Id == info.SelectedCategory).FirstOrDefault();
            if (category != null)
            {
                categoryRepository.DeleteCategory(category);
            }
            return RedirectToAction("Index", "Home");
        }
        public ViewResult ShowCategory()
        {
            IEnumerable<Category> categories = categoryRepository.Categories.ToList();
            List<ViewCategory> viewCategories = new List<ViewCategory>();
            if (categories != null)
            {
                foreach (Category c in categories)
                {
                    viewCategories.Add(new ViewCategory { Id = c.Id, Name = c.Name });
                }
            }
            return View(viewCategories);
        }
    }
}
