using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxyDecor.BusinessLibrary.BusinessObjects;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace GalaxyDecor.BusinessLibrary.Data
{
    public static class BillingData
    {
        public static int CreateBill(BillingInformation bill)
        {
            int BillNo = 0;

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.Create(DataSettings.ConnectionString);
            DbCommand command = db.GetStoredProcCommand("BillAdd");

            db.AddInParameter(command, "MemberShipNo", DbType.Int32, bill.prpMembersInformation.MembershipNo);
            db.AddInParameter(command, "Total", DbType.Decimal, bill.Total);
            db.AddInParameter(command, "GrandTotal", DbType.Decimal, bill.Total);
            db.AddInParameter(command, "BillIssueDate", DbType.Date, bill.BillIssueDate);

            db.AddOutParameter(command, "BillID", DbType.Int32, 0);

            // Code to execute goes here.
            db.ExecuteNonQuery(command);

            BillNo = (int)db.GetParameterValue(command, "BillID");

            command = null;
            db = null;

            return BillNo;
        }

        internal static void AddTransactions(int BillNo, List<BillTransactions> filteredTransactions)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.Create(DataSettings.ConnectionString);
            DbCommand command = db.GetStoredProcCommand("TransactionsAdd");

            string XML = GenerateXML(BillNo,filteredTransactions);

            db.AddInParameter(command, "Transactions", DbType.Xml, XML);

            // Code to execute goes here.
            db.ExecuteNonQuery(command);

            command = null;
            db = null;
        }

        private static string GenerateXML(int billNo, List<BillTransactions> filteredTransactions)
        {
            string XML = string.Empty;
            string template = GetTemplate("AddBillTransaction");
            XML = "<Root>";
            foreach (BillTransactions bill in filteredTransactions)
            {
                string FillTemplate = string.Format(template,
                                                        billNo,
                                                        bill.ItemID,
                                                        bill.ItemName,
                                                        bill.Price,
                                                        bill.Quantity,
                                                        bill.IsPurchase,
                                                        bill.IncludeInPV);

                XML += FillTemplate;
            }
            XML += "</Root>";

            return XML;
        }

        private static string GetTemplate(string keyword)
        {
            string template = string.Empty;

            switch (keyword)
            {
                case "AddBillTransaction":
                    template = @"<Transactions BillNo='{0}' ItemID='{1}' ItemName='{2}' Price='{3}' Quantity='{4}' IsPurchase='{5}' IncludeInPV='{6}'></Transactions>";
                    break;
                case "":
                    break;
            }

            return template;
        }
    }
}
