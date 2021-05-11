using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace McvProjeKampi.Controllers
{
    public class IstatistikController : Controller
    {
        Context c = new Context();
        // GET: Istatistik
        public ActionResult Index()
        {
            //Toplam kategori sayısı
            var ex1 = c.Categories.Count();
            ViewBag.CategoryCount = ex1;
            //Başlık tablosunda "yazılım" kategorisine ait başlık sayısı
            var ex2 = c.Headings.Count(x => x.HeadingName == "Yazılım");
            ViewBag.Heading = ex2;
            //Yazar adında 'a' harfi geçen yazar sayısı
            var ex3 = c.Writers.Count(x => x.WriterName.Contains("a"));
            ViewBag.Writer = ex3;
            //En fazla başlığa sahip kategori adı
            var ex4 = c.Headings.Max(x => x.Category.CategoryName);
            ViewBag.HeadingCategory = ex4;
            //Kategori tablosunda durumu true olan kategoriler ile false olan kategoriler arasındaki sayısal fark
            var ex5 = c.Categories.Count(x => x.CategoryStatus == true) - c.Categories.Count(x => x.CategoryStatus == false);
            ViewBag.Minus = ex5;

            return View();
        }
    }
}