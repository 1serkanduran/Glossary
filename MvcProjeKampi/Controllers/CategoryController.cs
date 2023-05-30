using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using DataAcsessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;

namespace MvcProjeKampi.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm=new CategoryManager(new EfCategoryDal());
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryList()
        {
            var categoryvalues = cm.GetList();
            return View(categoryvalues);
        }
        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryAdd(Category p)
        {
            CategoryValidatior categoryValidator=new CategoryValidatior();
            ValidationResult result=categoryValidator.Validate(p);
            if (result.IsValid)
            {
                cm.CategoryAddBL(p);
                return RedirectToAction("GetCategoryList");
            }
            else 
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                } 
            }
            return View();
        }
    }
}