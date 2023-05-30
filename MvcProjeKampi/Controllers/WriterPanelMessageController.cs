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
            var drafList = listResult.FindAll(x => x.IsDraft == true);
            ViewBag.draftCount = drafList.Count();
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
        public ActionResult NewMessage(Message message, string button)
        {
            string userEmail = (string)Session["WriterMail"];
            ValidationResult results = messageValidator.Validate(message);
            if (button == "draft")
            {

                results = messageValidator.Validate(message);
                if (results.IsValid)
                {
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    message.SenderMail = userEmail;
                    message.IsDraft = true;
                    mm.MessageAddBL(message);
                    return RedirectToAction("Draft");
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
                results = messageValidator.Validate(message);
                if (results.IsValid)
                {
                    message.MessageDate = DateTime.Now;
                    message.SenderMail = userEmail;
                    message.IsDraft = false;
                    mm.MessageAddBL(message);
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
            string userEmail = (string)Session["WriterMail"];
            var sendList = mm.GetListSendInbox(userEmail);
            var draftList = sendList.FindAll(x => x.IsDraft == true);
            return View(draftList);
        }

        public ActionResult GetDraftMessageDetails(int id)
        {
            var Values = mm.GetByID(id);
            return View(Values);
        }
    }
}