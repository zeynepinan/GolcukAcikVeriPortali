

using acikveriportal.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace acikveriportal.Controllers
{
    public class UsersController : Controller
    {
        db_AcikVeriPortalEntities01 db = new db_AcikVeriPortalEntities01();
        // GET: Users
        [HttpGet]
        public ActionResult Kayit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kayit(Users user)
        {
            user.OlusturulmaTarihi = DateTime.Now;
            db.Users.Add(user);
            db.SaveChanges();
            ViewBag.Message = "Kayıt Başarı ile Gerçekleştirilmiştir.";
            return RedirectToAction("Login", "Users");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Users k)
        {
            var kullanici = db.Users.FirstOrDefault(x => x.EPosta == k.EPosta && x.Sifre == k.Sifre);
            if (kullanici != null)
            {
                FormsAuthentication.SetAuthCookie(k.EPosta, false);
                return RedirectToAction("dashboard", "Users");
            }
           
            
            ViewBag.ErrorMessage = "Kullanıcı adı veya şifre yanlış"; 
           return View();

        }

        public ActionResult Logout() {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult dashboard()
        {
            return View();
        }

    }
}