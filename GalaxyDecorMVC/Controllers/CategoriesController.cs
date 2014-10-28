using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GalaxyDecor.BusinessLibrary.BusinessRules;
using GalaxyDecor.BusinessLibrary.BusinessObjects;
using System.Collections.ObjectModel;
using GalaxyDecorMVC.Models;

namespace GalaxyDecorMVC.Controllers
{
    public class CategoriesController : Controller
    {
        public ActionResult Index()
        {
            Collection<Categories> categoriesList = ItemsBR.GetAllCategories();

            return this.View(categoriesList);
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Categories createCategory)
        {
            ItemsBR.CreateCategory(createCategory);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string CategoryID)
        {
            Categories category = new Categories();

            if (!string.IsNullOrEmpty(CategoryID))
            {
                category = ItemsBR.GetSelectedCategory(Convert.ToInt32(CategoryID));
            }

            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Categories updateCategory)
        {
            ItemsBR.UpdateCategory(updateCategory);

            return RedirectToAction("Index");
        }
        
        public ActionResult Delete(int categoryID)
        {
            ItemsBR.DeleteCategory(categoryID);

            return RedirectToAction("Index");
        }
    }
}
