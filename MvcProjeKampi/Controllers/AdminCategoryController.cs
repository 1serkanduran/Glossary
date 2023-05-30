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
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        // GET: AdminCategory
        [Authorize(Roles="B")]
        public ActionResult Index()
        {
            var categoryvalues = cm.GetList();
            return View(categoryvalues);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            CategoryValidatior categoryvalidator= new CategoryValidatior();
            ValidationResult result=categoryvalidator.Validate(p);
            if (result.IsValid)
            {
                cm.CategoryAddBL(p);
                return RedirectToAction("Index");
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
        public ActionResult DeleteCategory(int id)
        {
            var category=cm.GetByID(id);
            cm.CategoryDeleteBL(category);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryvalue=cm.GetByID(id);
            return View(categoryvalue);
        }
        [HttpPost]
        public ActionResult EditCategory(Category p)
        {
            cm.CategoryUpdateBL(p);
            return RedirectToAction("Index");
        }

    }
}