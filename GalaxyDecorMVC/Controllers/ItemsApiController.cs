using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GalaxyDecor.BusinessLibrary.BusinessObjects;
using GalaxyDecor.BusinessLibrary.BusinessRules;

namespace GalaxyDecorMVC.Controllers
{
    public class ItemsApiController : System.Web.Http.ApiController
    {
        //
        // GET: /ItemsApi/
        [HttpGet]
        public IEnumerable<Items> GetItems(string query = "")
        {
            IEnumerable<Items> itemsList = ItemsBR.GetAllItems();

            return String.IsNullOrEmpty(query) ? itemsList : itemsList.Where(q => q.ItemName.ToLower().Contains(query.ToLower())).ToList();
        }
    }
}
