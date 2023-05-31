using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAcsessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm=new MessageManager(new EfMessageDal());
        ContactManager cm = new ContactManager(new EfContactDal());
        MessageValidator messageValidator= new MessageValidator();
        // GET: WritePanelMessage
        public ActionResult Inbox()
        {
            string userEmail = (string)Session["WriterMail"];
            var messageList = mm.GetListInbox(userEmail);
            return View(messageList);
        }
        public ActionResult SendBox()
        {
            string userEmail = (string)Session["WriterMail"];
            var result = mm.GetListSendInbox(userEmail);
            return View(result);
        }
        public PartialViewResult ContactSideBarPartial()
        {
            string userEmail = (string)Session["WriterMail"];
            var contactList = cm.GetAll();
            ViewBag.contactCount = contactList.Count();
            var listResult = mm.GetListSendInbox(userEmail);
            var sendList = listResult.FindAll(x => x.IsDraft == false);
            ViewBag.sendCount = sendList.Count();
            var listResult2 = mm.GetListInbox(userEmail);
            ViewBag.inboxCount = listResult2.Count();
            var draftMail = mm.GetListDraft(userEmail).Count();
            ViewBag.draftMail = draftMail;
            return PartialView();
        }
        public ActionResult GetInBoxMessageDetails(int id)
        {
            var result = mm.GetByID(id);
            return View(result);
        }
        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var result = mm.GetByID(id);
            return View(result);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message p, string button)
        {
            string userEmail = (string)Session["WriterMail"];
            ValidationResult results = messageValidator.Validate(p);
            if (button == "draft")
            {
                if (results.IsValid)
                {
                    p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    p.SenderMail = userEmail;
                    p.IsDraft = true;
                    mm.MessageAddBL(p);
                    return RedirectToAction("Draft"); ;
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            else if (button == "save")
            {
                results = messageValidator.Validate(p);
                if (results.IsValid)
                {
                    p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    p.SenderMail = userEmail;
                    //p.IsDraft = false;
                    mm.MessageAddBL(p);
                    return RedirectToAction("SendBox");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            return View();
        }
        public ActionResult Draft()
        {
            string userMail = (string)Session["WriterMail"];
            var result = mm.IsDraft(userMail);
            return View(result);
        }

        public ActionResult GetDraftMessageDetails(int id)
        {
            var Values = mm.GetByID(id);
            return View(Values);
        }
    }
}