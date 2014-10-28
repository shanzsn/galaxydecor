using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GalaxyDecor.BusinessLibrary.BusinessObjects;
using GalaxyDecor.BusinessLibrary.BusinessRules;
using GalaxyDecorMVC.Models;

namespace GalaxyDecorMVC.Controllers
{
    public class BillTransactionsController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Details(int billid)
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult Create(int mID = 0)
        {
            var model = new BillingModels();

            model.BillNo = -1;
            model.BillIssueDate = DateTime.Now.Date;

            if (mID == 0)
            {
                model.prpMembersInformation.MembershipNo = -1;
            }
            else
            {
                model.prpMembersInformation = MembersBR.GetSelectedMember(mID);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(BillingModels createBill)
        {
            if (createBill != null)
            {
                BillingInformation biObject = new BillingInformation();

                biObject.BillIssueDate = createBill.BillIssueDate;
                biObject.prpMembersInformation = createBill.prpMembersInformation;
                biObject.YearMonth = createBill.BillIssueDate.ToString("yyyymm");
                
                foreach (BillTransactions item in createBill.transactions) 
                {
                    if (!string.IsNullOrEmpty(item.ItemName))
                    {
                        biObject.Total += (item.Price * item.Quantity);
                    }
                }

                biObject.Total = createBill.transactions.Sum(o => o.Price * o.Quantity);

                int BillNo = BillsBR.CreateBill(biObject);
                BillsBR.AddTransactions(BillNo, createBill.transactions);
            }

            return RedirectToAction("Index");
        }
    }
}
