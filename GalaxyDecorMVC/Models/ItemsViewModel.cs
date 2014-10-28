using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GalaxyDecor.BusinessLibrary.BusinessObjects;

namespace GalaxyDecorMVC.Models
{
    public class ItemsViewModel : Items
    {
        public IList<SelectListItem> AllCategories { get; set; }
    }
}