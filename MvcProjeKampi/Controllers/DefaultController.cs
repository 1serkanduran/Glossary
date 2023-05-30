using BusinessLayer.Concrete;
using DataAcsessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContentManager cm = new ContentManager(new EfContentDal());
        // GET: Default
        public ActionResult Headings()
        {
            var headinglist=hm.GetList();
            return View(headinglist);
        }
        public PartialViewResult Index(int id=0)
        {
            var contentlist = cm.GetListByID(id);
            return PartialView(contentlist);
        }
    }
}