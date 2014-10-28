using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxyDecor.BusinessLibrary.Data;

namespace GalaxyDecor.BusinessLibrary.BusinessRules
{
    public static class BillsBR
    {
        public static int CreateBill(BusinessObjects.BillingInformation objBill)
        {
            int billNo = 0;
            
            if (objBill != null)
            {
                billNo = BillingData.CreateBill(objBill);
            }

            return billNo;
        }

        public static void AddTransactions(int BillNo, List<BusinessObjects.BillTransactions> list)
        {
            if (BillNo != 0)
            {
                var filteredTransactions = list.Where(o => o.ItemName != null && o.ItemName != string.Empty).ToList();

                BillingData.AddTransactions(BillNo, filteredTransactions);
            }
        }
    }
}
