using MiniGame.Interface;
using MiniGame.Repository;
using MiniGame.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniGame.Controllers
{
    public class GameController : Controller
    {
        private readonly ICauHoi CH;
        private readonly IGoiCauHoi GCH;
        private readonly IXepHang XH;
        public GameController()
        {
            CH = new CauHoiRepository();
            GCH = new GoiCauHoiRepository();
            XH = new XepHangRepository();
        }
        public GameController(ICauHoi _CH, IGoiCauHoi _GCH, IXepHang _XH)
        {
            CH = _CH;
            GCH = _GCH;
            XH = _XH;
        }
        // GET: Game
        public ActionResult Play(string id)
        {
            var model = CH.SelectAll().Where(x => x.Id_Tengoi == id.ToString()).ToArray();
            ViewBag.count = model.Count();
            ViewBag.Id = id;
            ViewBag.IdGoi = id;
            return View();
        }
        public ActionResult Rank(string id)
        {
            IEnumerable<XepHangViewModel> model = XH.SelectAll().Select(
                item => new XepHangViewModel
                {
                    Id = item.Id,
                    TenNguoiDung = item.TenNguoiDung,
                    IdGoiCauHoi = item.IdGoiCauHoi,
                    IdNguoiDung = item.IdNguoiDung,
                    Diem = item.Diem,
                    Trangthai = item.Trangthai
                }).Where(x => x.IdGoiCauHoi == id).OrderByDescending(x=>x.Diem).Take(5);
            return View(model);
        }
        public ActionResult CreateRank(string IdGoiCauHoi, int IdNguoiDung, string Diem)
        {
            var xh = new XepHang();
            xh.IdGoiCauHoi = IdGoiCauHoi;
            xh.IdNguoiDung = IdNguoiDung;
            if(User.Identity.IsAuthenticated)
            {
                xh.TenNguoiDung = User.Identity.Name;
            }    
            else
            {
                xh.TenNguoiDung = "Player";
            }    
            xh.Diem = Diem;
            xh.Trangthai = true;
            XH.Insert(xh);
            XH.Save();
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetQuestion(string id, int numeber)
        {
            var model = CH.SelectAll().Where(x => x.Id_Tengoi == id).ToArray();
            var cauhoi = new CauHoiViewModel();
            for (int i = 0; i < model.Count(); i++)
            {
                if (i == numeber)
                {
                    cauhoi.Id = model[i].Id;
                    cauhoi.Mota = model[i].Mota;
                    cauhoi.CauA = model[i].CauA;
                    cauhoi.CauB = model[i].CauB;
                    cauhoi.CauC = model[i].CauC;
                    cauhoi.CauD = model[i].CauD;
                    cauhoi.DAn = model[i].DAn;
                    cauhoi.Hinhmota = model[i].Hinhmota;
                }
            }
            return Json(cauhoi, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CountQues(string id)
        {
            int i = 0;
            i = GCH.SelectAll().Where(x=>x.IdTengoi==id && x.Trangthai == true).Count();
            return Json(i, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CheckQues(int id,string iddapan)
        {
            var check = new DapAnViewModel();
            var dapan = CH.SelectById(id);
            if(dapan.DAn == iddapan)
            {
                check.Dapan = true;
            }
            else
            {
                check.Dapan = false;
            }    
            check.Dapandung = dapan.DAn;
            return Json(check, JsonRequestBehavior.AllowGet);
        }
        // GET: Game/Details/5
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Game/Create
        public ActionResult Start()
        {
            return View();
        }
        // GET: Game/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Game/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Game/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Game/Delete/5
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
