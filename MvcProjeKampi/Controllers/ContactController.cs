using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAcsessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Collections.Specialized.BitVector32;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        MessageManager _messageManager = new MessageManager(new EfMessageDal());
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator cv= new ContactValidator();

        // GET: Contact
        public ActionResult Index()
        {
            var contactvalues = cm.GetAll();
            return View(contactvalues);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactvalues=cm.GetById(id);
            return View(contactvalues);
        }
        public PartialViewResult MessageLeftMenu()
        {
            string userEmail = (string)Session["AdminUserName"];
            var contactList = cm.GetAll();
            ViewBag.contactCount = contactList.Count();
            var listResult = _messageManager.GetListSendInbox(userEmail);
            var sendList = listResult.FindAll(x => x.IsDraft == false);
            ViewBag.sendCount = sendList.Count();
            var listResult2 = _messageManager.GetListInbox(userEmail);
            ViewBag.inboxCount = listResult2.Count();
            var draftMail = _messageManager.GetListDraft(userEmail).Count();
            ViewBag.draftMail = draftMail; 
            return PartialView();
        }

    }
}