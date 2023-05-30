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
    public class AuthorizationController : Controller
    {
        AdminManager am=new AdminManager(new EfAdminDal());
        // GET: Authorization
        public ActionResult Index()
        {
            var adminvalues = am.GetList();
            return View(adminvalues);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            am.AdminAddBL(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            var adminvalue = am.GetByID(id);
            return View(adminvalue);
        }
        [HttpPost]
        public ActionResult EditAdmin(Admin p)
        {
            am.AdminUpdateBL(p);
            return RedirectToAction("Index");
        }
        public ActionResult AdminDelete(int id)
        {
            var result = am.GetByID(id);
            if (result.AdminStatus == true)
            {
                result.AdminStatus = false;
            }
            else
            {
                result.AdminStatus = true;
            }
            am.AdminDeleteBL(result);
            return RedirectToAction("Index");
        }
    }
}