using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyDecor.BusinessLibrary.BusinessObjects
{
    public class Items
    {
        private int _ItemID;
        [Display(Name="ID")]
        public int ItemID
        {
            get { return _ItemID; }
            set { _ItemID = value; }
        }

        private int _categoryID;
        [Required]
        public int categoryID
        {
            get { return _categoryID; }
            set { _categoryID = value; }
        }

        private string _categoryName;
        public string CategoryName
        {
            get { return _categoryName; }
            set { _categoryName = value; }
        }
        
        private string _ItemName;
        [Display(Name = "Item Name")]
        [Required]
        public string ItemName
        {
            get { return _ItemName; }
            set { _ItemName = value; }
        }

        private double _Price;
        [Required]
        public double Price
        {
            get { return _Price; }
            set { _Price = value; }
        }

        private bool _CalculatePVPoints = true;
        [Display(Name = "Include in points?")]
        public bool CalculatePVPoints
        {
            get { return _CalculatePVPoints; }
            set { _CalculatePVPoints = value; }
        }

        public string ItemIDWithPrice { get; set; }
    }
}
