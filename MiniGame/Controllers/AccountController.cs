using MiniGame.Interface;
using MiniGame.Repository;
using MiniGame.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MiniGame.Controllers
{
    public class AccountController : Controller
    {
        private readonly INguoiDung ND;
        public AccountController()
        {
            ND = new NguoiDungRepository();
        }
        public AccountController(INguoiDung _ND)
        {
            ND = _ND;
        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        // GET: Account/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Account/Create
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Create
        [HttpPost]
        public ActionResult Login(NguoiDungViewModel model)
        {
            try
            {
                var _nd = ND.SelectAll().Where(x => x.Ten == model.Ten && x.Matkhau == model.Matkhau).Count();
                if(_nd == 1)
                {
                    FormsAuthentication.SetAuthCookie(model.Ten, false);
                    ViewBag.sai = false;
                    return RedirectToAction("Index","Game");
                }
            }
            catch
            {
                return View();
            }
            ViewBag.sai = true;
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(NguoiDungViewModel model)
        {
            try
            {
                var _nd = ND.SelectAll().Where(x => x.Ten == model.Ten).Count();
                if (_nd == 0)
                {
                    var nd = new NguoiDung();
                    nd.Ten = model.Ten;
                    nd.Matkhau = model.Matkhau;
                    nd.Trangthai = true;
                    ND.Insert(nd);
                    ND.Save();
                    ViewBag.sai = false;
                    return RedirectToAction("Index", "Game");
                }
            }
            catch
            {
                return View();
            }
            ViewBag.sai = true;
            return View();
        }

        // GET: Account/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Account/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
