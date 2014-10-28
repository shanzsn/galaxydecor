using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GalaxyDecor.BusinessLibrary.BusinessObjects;
using GalaxyDecor.BusinessLibrary.BusinessRules;

namespace GalaxyDecorMVC.Mapper
{
    public static class Mapper
    {
        public static void GetAllListItem()
        {

        }

        internal static Models.ItemsViewModel MapItems(GalaxyDecor.BusinessLibrary.BusinessObjects.Items item)
        {
            Models.ItemsViewModel ivm = new Models.ItemsViewModel();

            ivm.CalculatePVPoints = item.CalculatePVPoints;
            ivm.categoryID = item.categoryID;
            ivm.ItemID = item.ItemID;
            ivm.ItemName = item.ItemName;
            ivm.Price = item.Price;

            return ivm;
        }

        //private static IList<System.Web.Mvc.SelectListItem> GetCategories(int CategoryID)
        //{
        //    Collection<Categories> allCategories = ItemsBR.GetAllCategories();

        //    List<SelectListItem> CategoriesList = null;


        //}
    }
}