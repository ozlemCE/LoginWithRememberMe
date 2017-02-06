using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginWithRememberMe.Models;
using LoginWithRememberMe.Repository;
using LoginWithRememberMe.ViewModels;

namespace LoginWithRememberMe.Controllers
{
    public class AccountController : Controller
    {
       

        public ActionResult Index()
        {
            Account acc = checkCookie();
            if (acc == null)
                return View();
            else
            {
                AccountModel accModel = new AccountModel();
                if (accModel.login(acc.Username, acc.Password))
                {
                    Session["Username"] = acc.Username;
                    return View("Welcome");

                }
                else
                {
                    ViewBag.Error = "Geçersiz giriş.";
                    return View();
                }

            }
        }

        [HttpPost]
        public ActionResult Login(AccountViewModel avm)
        {
            AccountModel accModel = new AccountModel();
            if (accModel.login(avm.account.Username, avm.account.Password))
            {
                Session["Username"] = avm.account.Username;
                if (avm.remember)
                {
                    HttpCookie ckKullaniciAdi = new HttpCookie("Username");
                    ckKullaniciAdi.Expires = DateTime.Now.AddSeconds(3600);
                    ckKullaniciAdi.Value = avm.account.Username;
                    Response.Cookies.Add(ckKullaniciAdi);

                    HttpCookie ckSifre = new HttpCookie("Password");
                    ckSifre.Expires = DateTime.Now.AddSeconds(3600);
                    ckSifre.Value = avm.account.Password;
                    Response.Cookies.Add(ckSifre);

                }
                return View("Welcome");
            }
            else
            {
                ViewBag.Error = "Geçersiz giriş.";
                return View("Index");
            }
        }

        public ActionResult Logout()
        {
            //oturumu kaldır
            Session.Remove("username");
            // cookie yi kaldır
            if (Response.Cookies["username"] != null)
            {
                HttpCookie ckKullaniciAdi = new HttpCookie("username");
                ckKullaniciAdi.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(ckKullaniciAdi);
            }
            if (Response.Cookies["password"] != null)
            {
                HttpCookie ckSifre = new HttpCookie("password");
                ckSifre.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(ckSifre);
            }
            return View("Index");
        }


    



        public Account checkCookie()
        {
            Account sKullanici = null;
            string username = string.Empty, password = string.Empty;
            if (Request.Cookies["Username"] != null)
                username = Request.Cookies["Username"].Value;
            if (Request.Cookies["Password"] != null)
                password = Request.Cookies["Password"].Value;
            if (!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(password))
                sKullanici = new Account { Username = username, Password = password };
            return sKullanici;
        } 


    }
}
