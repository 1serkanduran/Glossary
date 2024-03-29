﻿using BusinessLayer.Concrete;
using DataAcsessLayer.Concrete;
using DataAcsessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        Context c = new Context();
        // GET: WriterPanelContent
        public ActionResult MyContent(string p)
        { 
            p = (string)Session["WriterMail"];
            var writeridinfo=c.Writers.Where(x=>x.WriterMail == p).Select(y=>y.WriterID).FirstOrDefault();
            //ViewBag.d = p;
            var contentvalues = cm.GetListByWriter(writeridinfo);
            return View(contentvalues);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d=id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content p)
        {
            p.ContentDate=DateTime.Parse(DateTime.Now.ToShortDateString());
            string mail= (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail ==mail).Select(y => y.WriterID).FirstOrDefault();
            p.WriterID = writeridinfo;
            p.ContentStatus = true;
            cm.ContentAddBL(p);
            return RedirectToAction("MyContent");
        }

    }
}