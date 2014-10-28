using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GalaxyDecor.BusinessLibrary.BusinessObjects;

namespace GalaxyDecorMVC.Models
{
    public class BillingModels : BillingInformation
    {
        public BillingModels()
        {
            transactions = new List<BillTransactions>();
        }

        public List<BillTransactions> transactions { get; set; }
    }
}