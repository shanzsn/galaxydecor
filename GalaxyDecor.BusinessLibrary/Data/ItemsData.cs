using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using GalaxyDecor.BusinessLibrary.BusinessObjects;
using GalaxyDecor.BusinessLibrary.BusinessRules;
using System.Collections.ObjectModel;

namespace GalaxyDecor.BusinessLibrary.Data
{
    internal class ItemsData
    {
        #region Categories
        public static int CreateCategory(Categories category)
        {
            int categoryID = 0;

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.Create(DataSettings.ConnectionString);
            DbCommand command = db.GetStoredProcCommand("CategoryAdd");

            if (category.CategoryName != null)
            {
                db.AddInParameter(command, "CategoryName", DbType.String, category.CategoryName);
            }

            db.AddOutParameter(command, "CategoryID", DbType.Int32, 0);
            
            // Code to execute goes here.
            db.ExecuteNonQuery(command);            

            categoryID = (int)db.GetParameterValue(command, "CategoryID");

            command = null;
            db = null;

            return categoryID;
        }

        public static int UpdateCategory(Categories category)
        {
            if (category != null)
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.Create(DataSettings.ConnectionString);
                DbCommand command = db.GetStoredProcCommand("UpdateCategory");

                db.AddInParameter(command, "CategoryID", DbType.Int32, category.CategoryID);
                db.AddInParameter(command, "CategoryName", DbType.String, category.CategoryName);
                
                // Code to execute goes here.
                db.ExecuteNonQuery(command);
                                
                command = null;
                db = null;    
            }

            return -1;
        }

        public static int DeleteCategory(int categoryID)
        {
            if (categoryID != 0)
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.Create(DataSettings.ConnectionString);
                DbCommand command = db.GetStoredProcCommand("DeleteCategory");

                db.AddInParameter(command, "CategoryID", DbType.Int32, categoryID);
                
                // Code to execute goes here.
                db.ExecuteNonQuery(command);

                command = null;
                db = null;
            }

            return -1;
        }

        public static Collection<Categories> GetAllCategories()
        {
            Collection<Categories> categories = new Collection<Categories>();
            Categories category = null;

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.Create(DataSettings.ConnectionString);
            DbCommand command = db.GetStoredProcCommand("CategoryGetAllCategory");
            
            DataSet dataSet = null;
            
            // Code to execute goes here.
            dataSet = db.ExecuteDataSet(command);
            
            foreach (DataRow rw in dataSet.Tables[0].Rows)
            {
                category = new Categories();
                category.CategoryID= Convert.ToInt32(rw["CategoryID"]);
                category.CategoryName = rw.IsNull("CategoryName") ? string.Empty : Convert.ToString(rw["CategoryName"]);
                category.DateModified = rw.IsNull("DateModified") ? DateTime.Now : Convert.ToDateTime(rw["DateModified"]);

                categories.Add(category);
            }

            return categories;
        }

        internal static Categories GetSelectedCategory(int CategoryID)
        {
            Categories category = null;

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.Create(DataSettings.ConnectionString);
            DbCommand command = db.GetStoredProcCommand("GetSelectedCategory");
            
            db.AddInParameter(command, "CategoryID", DbType.Int32, CategoryID);
            
            DataSet dataSet = null;

            // Code to execute goes here.
            dataSet = db.ExecuteDataSet(command);

            foreach (DataRow rw in dataSet.Tables[0].Rows)
            {
                category = new Categories();
                category.CategoryID = Convert.ToInt32(rw["CategoryID"]);
                category.CategoryName = rw.IsNull("CategoryName") ? string.Empty : Convert.ToString(rw["CategoryName"]);
            }

            return category;
        }
        #endregion

        #region Items
        public static Collection<Items> GetAllItems()
        {
            Collection<Items> Items = new Collection<Items>();
            Items item = null;
            Categories category = null;

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.Create(DataSettings.ConnectionString);
            DbCommand command = db.GetStoredProcCommand("ItemsGetAllItems");

            DataSet dataSet = null;

            // Code to execute goes here.
            dataSet = db.ExecuteDataSet(command);

            foreach (DataRow rw in dataSet.Tables[0].Rows)
            {
                item = new Items();
                category = new Categories();

                item.ItemID = Convert.ToInt32(rw["ItemID"]);
                item.ItemName = rw.IsNull("ItemName") ? string.Empty : Convert.ToString(rw["ItemName"]);
                item.Price = rw.IsNull("Price") ? 0 : Convert.ToDouble(rw["Price"]);
                item.CalculatePVPoints = rw.IsNull("CalculatePVPoints") ? false : Convert.ToBoolean(rw["CalculatePVPoints"]);
                item.categoryID = Convert.ToInt32(rw["CategoryID"]);
                item.CategoryName = rw.IsNull("CategoryName") ? string.Empty : Convert.ToString(rw["CategoryName"]);
                item.ItemIDWithPrice = item.ItemID + "|" + item.Price;
                
                Items.Add(item);
            }

            return Items;
        }

        internal static Items GetSelectedItem(int ItemID)
        {
            Items item = null;
            Categories category = null;

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.Create(DataSettings.ConnectionString);
            DbCommand command = db.GetStoredProcCommand("GetSelectedItem");

            db.AddInParameter(command, "ItemID", DbType.Int32, ItemID);

            DataSet dataSet = null;

            // Code to execute goes here.
            dataSet = db.ExecuteDataSet(command);

            foreach (DataRow rw in dataSet.Tables[0].Rows)
            {
                item = new Items();
                category = new Categories();

                item.ItemID = Convert.ToInt32(rw["ItemID"]);
                item.ItemName = rw.IsNull("ItemName") ? string.Empty : Convert.ToString(rw["ItemName"]);
                item.Price = rw.IsNull("Price") ? 0 : Convert.ToDouble(rw["Price"]);
                item.CalculatePVPoints = rw.IsNull("CalculatePVPoints") ? false : Convert.ToBoolean(rw["CalculatePVPoints"]);
                item.categoryID = Convert.ToInt32(rw["CategoryID"]);
            }

            return item;
        }

        public static int CreateItem(Items item)
        {
            int itemID = 0;

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.Create(DataSettings.ConnectionString);
            DbCommand command = db.GetStoredProcCommand("ItemsAdd");

            db.AddInParameter(command, "ItemName", DbType.String, item.ItemName);
            db.AddInParameter(command, "CategoryID", DbType.Int32, item.categoryID);
            db.AddInParameter(command, "Price", DbType.Int32, item.Price);
            db.AddInParameter(command, "CalculatePVPoints", DbType.Boolean, item.CalculatePVPoints);

            db.AddOutParameter(command, "ItemID", DbType.Int32, 0);

            // Code to execute goes here.
            db.ExecuteNonQuery(command);

            itemID = (int)db.GetParameterValue(command, "ItemID");

            command = null;
            db = null;

            return itemID;
        }

        public static int UpdateItem(Items item)
        {
            if (item != null)
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.Create(DataSettings.ConnectionString);
                DbCommand command = db.GetStoredProcCommand("ItemsUpdate");

                db.AddInParameter(command, "ItemID", DbType.Int32, item.ItemID);
                db.AddInParameter(command, "ItemName", DbType.String, item.ItemName);
                db.AddInParameter(command, "CategoryID", DbType.Int32, item.categoryID);
                db.AddInParameter(command, "Price", DbType.Int32, item.Price);
                db.AddInParameter(command, "CalculatePVPoints", DbType.Boolean, item.CalculatePVPoints);
                
                // Code to execute goes here.
                db.ExecuteNonQuery(command);

                command = null;
                db = null;
            }

            return -1;
        }

        public static int DeleteItem(int ItemID)
        {
            if (ItemID != 0)
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.Create(DataSettings.ConnectionString);
                DbCommand command = db.GetStoredProcCommand("ItemsDelete");

                db.AddInParameter(command, "ItemID", DbType.Int32, ItemID);

                // Code to execute goes here.
                db.ExecuteNonQuery(command);

                command = null;
                db = null;
            }

            return -1;
        }
        #endregion
    }
}
