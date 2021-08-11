using BusinessLayer.Abstract;
using BusinessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace McvProjeKampi.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        IAuthService authService = new AuthManager(new AdminManager(new EfAdminDal()));
        // GET: Register
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginDto loginDto)
        {
            authService.Register(loginDto.AdminUserName, loginDto.AdminPassword);
            return RedirectToAction("Index", "Gallery");
        }
    }
 }
