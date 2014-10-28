using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GalaxyDecorMVC.Models;
using GalaxyDecorMVC.Mapper;
using GalaxyDecor.BusinessLibrary.BusinessRules;
using GalaxyDecor.BusinessLibrary.BusinessObjects;

namespace GalaxyDecorMVC.Controllers
{
    public class ItemsController : Controller
    {
        public ActionResult Index()
        {
            Collection<Items> itemsList = ItemsBR.GetAllItems();

            return this.View(itemsList);
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            Collection<Categories> allCategories = ItemsBR.GetAllCategories();
            ViewBag.categoriesGroup = allCategories.ToList();

            Items objItem = new Items();
            objItem.CalculatePVPoints = true;

            return View(objItem);
        }

        [HttpPost]
        public ActionResult Create(Items createItem)
        {
            ItemsBR.CreateItem(createItem);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string ItemID)
        {
            Items item = new Items();

            if (!string.IsNullOrEmpty(ItemID))
            {
                item = ItemsBR.GetSelectedItem(Convert.ToInt32(ItemID));
                
                Collection<Categories> allCategories = ItemsBR.GetAllCategories();
                ViewBag.categoriesGroup = allCategories.ToList();
            }

            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(Items updateItem)
        {
            ItemsBR.UpdateItem(updateItem);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int itemID)
        {
            ItemsBR.DeleteItem(itemID);

            return RedirectToAction("Index");
        }

        public IEnumerable<Items> GetItems(string query = "")
        {
            IEnumerable<Items> itemsList = ItemsBR.GetAllItems();

            return String.IsNullOrEmpty(query) ? itemsList : itemsList.Where(q => q.ItemName.Contains(query)).ToList();
        }
    }
}
