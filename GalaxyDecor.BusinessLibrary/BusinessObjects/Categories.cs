using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GalaxyDecor.BusinessLibrary.BusinessObjects
{
    public class Categories
    {
        private int _CateogryID;

        public int CategoryID
        {
            get { return _CateogryID; }
            set { _CateogryID = value; }
        }

        private string _CategoryName;
        
        [Required]
        [Display(Name = "Category")]
        public string CategoryName
        {
            get { return _CategoryName; }
            set { _CategoryName = value; }
        }

        private DateTime _DateModified;

        [Display(Name = "Changed On")]
        public DateTime DateModified
        {
            get { return _DateModified; }
            set { _DateModified = value; }
        }
    }
}
