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
    public class MessageController : Controller
    {
        MessageManager cm = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidator = new MessageValidator();
        // GET: Message
        [Authorize]
        public ActionResult Inbox()
        {
            string userEmail = (string)Session["AdminUserName"];
            var result =cm.GetListInbox(userEmail);
            return View(result);
        }
        public ActionResult Sendbox()
        {
            string userEmail = (string)Session["AdminUserName"];
            var result =cm.GetListSendInbox(userEmail);
            return View(result);
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = cm.GetByID(id);
            return View(values);
        }
        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = cm.GetByID(id);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p, string button)
        {
            string userEmail = (string)Session["AdminUserName"];
            ValidationResult results = messagevalidator.Validate(p);
            if (button == "draft")
            {
                if (results.IsValid)
                {
                    p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    p.SenderMail = userEmail;
                    p.IsDraft = true;
                    cm.MessageAddBL(p);
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
            else if (button =="save")
            {
                results=messagevalidator.Validate(p);
                if (results.IsValid)
                {
                    p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    p.SenderMail = userEmail;
                    //p.IsDraft = false;
                    cm.MessageAddBL(p);
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
            string userMail = (string)Session["AdminUserName"];
            var result=cm.IsDraft(userMail);
            return View(result);
        }
        public ActionResult GetDraftMessageDetails(int id)
        {
            var Values = cm.GetByID(id);
            return View(Values);
        }


    }
}