using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyDecor.BusinessLibrary.BusinessObjects
{
    public class BillTransactions
    {
        private int _TID;

        public int TID
        {
            get { return _TID; }
            set { _TID = value; }
        }

        private bool _IsPurchase;

        public bool IsPurchase
        {
            get { return _IsPurchase; }
            set { _IsPurchase = value; }
        }

        private int _ItemID;

        public int ItemID
        {
            get { return _ItemID; }
            set { _ItemID = value; }
        }

        private string _ItemName;

        public string ItemName
        {
            get { return _ItemName; }
            set { _ItemName = value; }
        }

        private double _Price;

        public double Price
        {
            get { return _Price; }
            set { _Price = value; }
        }

        private int _Quantity;

        public int Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }

        private bool _IncludeInPV;

        public bool IncludeInPV
        {
            get { return _IncludeInPV; }
            set { _IncludeInPV = value; }
        }
    }
}
