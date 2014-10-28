using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxyDecor.BusinessLibrary.BusinessObjects;
using GalaxyDecor.BusinessLibrary.Data;

namespace GalaxyDecor.BusinessLibrary.BusinessRules
{
    public static class ItemsBR
    {
        #region Categories
        public static Collection<Categories> GetAllCategories()
        {
            return ItemsData.GetAllCategories();
        }

        public static Categories GetSelectedCategory(int CategoryID)
        {
            return ItemsData.GetSelectedCategory(CategoryID);
        }

        public static int CreateCategory(Categories category)
        {
            return ItemsData.CreateCategory(category);
        }

        public static int UpdateCategory(Categories category)
        {
            return ItemsData.UpdateCategory(category);
        }

        public static int DeleteCategory(int categoryID)
        {
            return ItemsData.DeleteCategory(categoryID);
        }
        #endregion

        #region Items
        public static Collection<Items> GetAllItems()
        {
            return ItemsData.GetAllItems();
        }

        public static Items GetSelectedItem(int ItemID)
        {
            return ItemsData.GetSelectedItem(ItemID);
        }

        public static void CreateItem(Items item)
        {
            ItemsData.CreateItem(item);
        }

        public static void UpdateItem(Items item)
        {
            ItemsData.UpdateItem(item);
        }

        public static int DeleteItem(int ItemID)
        {
            return ItemsData.DeleteItem(ItemID);
        }
        #endregion
    }
}
