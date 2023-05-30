using BusinessLayer.Concrete;
using DataAcsessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AboutController : Controller
    {
        AboutManager abm=new AboutManager(new EfAboutDal());
        // GET: About
        public ActionResult Index()
        {
            var aboutvalues = abm.GetList();
            return View(aboutvalues);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            abm.AboutAddBL(p);
            return RedirectToAction("Index");
        }
        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
        public ActionResult AboutDelete(int id)
        {
            var result = abm.GetById(id);
            if (result.AboutStatus==true)
            {
                result.AboutStatus=false;
            }
            else
            {
                result.AboutStatus= true;
            }
            abm.AboutDeleteBL(result);
            return RedirectToAction("Index");
        }
    }
}