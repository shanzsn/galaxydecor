using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GalaxyDecor.BusinessLibrary.BusinessObjects;
using GalaxyDecor.BusinessLibrary.BusinessRules;

namespace GalaxyDecorMVC.Controllers
{
    public class MembersController : Controller
    {
        public ActionResult Index()
        {
            Collection<MembersInformation> membersList = MembersBR.GetAllMembers();

            return this.View(membersList);
        }

        public ActionResult Details(int memberID)
        {
            MembersInformation memberdetail = MembersBR.GetSelectedMember(memberID);

            return this.View(memberdetail);
        }

        [HttpGet]
        public JsonResult SponsorDetails(int memberID)
        {
            MembersInformation memberdetail = MembersBR.GetSelectedMember(memberID);

            return this.Json(memberdetail, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Collection<MembersInformation> membersList = MembersBR.GetAllPossibleSponsors(0);
            ViewBag.membersGroup = membersList.ToList();

            return View();
        }

        [HttpPost]
        public ActionResult Create(MembersInformation createItem)
        {
            MembersBR.CreateMember(createItem);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string memberID)
        {
            MembersInformation item = new MembersInformation();

            if (!string.IsNullOrEmpty(memberID))
            {
                item = MembersBR.GetSelectedMember(Convert.ToInt32(memberID));
            }

            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(MembersInformation updateItem)
        {
            MembersBR.UpdateMember(updateItem);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int memberID)
        {
            MembersBR.DeleteMember(memberID);

            return RedirectToAction("Index");
        }
    }
}
