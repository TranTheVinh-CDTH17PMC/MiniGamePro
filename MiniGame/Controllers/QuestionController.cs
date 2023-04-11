using MiniGame.Interface;
using MiniGame.Repository;
using MiniGame.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniGame.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        private readonly IGoiCauHoi GCH;
        private readonly INguoiDung ND;
        private readonly ICauHoi CH;
        public QuestionController()
        {
            GCH = new GoiCauHoiRepository();
            ND = new NguoiDungRepository();
            CH = new CauHoiRepository();
        }
        public QuestionController(IGoiCauHoi _GCH, INguoiDung _ND, ICauHoi _CH)
        {
            ND = _ND;
            GCH = _GCH;
            CH = _CH;
        }
        // GET: CauHoi
        [HttpGet]
        public ActionResult Index()
        {
            int id = ND.GetIDByName(User.Identity.Name);
            var gch = GCH.SelectAll().Where(x => x.IdNguoidung == id);
            IEnumerable<CauHoiViewModel> model = CH.SelectAll().Select(
                item => new CauHoiViewModel
                {
                    Id = item.Id,
                    CauA = item.CauA,
                    CauB = item.CauB,
                    CauC = item.CauC,
                    CauD = item.CauD,
                    DAn = item.DAn,
                    Mota = item.Mota,
                    Hinhmota = item.Hinhmota,
                    IdNguoidung = item.IdNguoidung,
                    Id_Goicauhoi = item.Id_Goicauhoi,
                    Trangthai = item.Trangthai
                }).Where(x => x.Trangthai == true &&  x.IdNguoidung == id);
            return View(model);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            IEnumerable<CauHoiViewModel> model = CH.SelectAll().Select(
                item => new CauHoiViewModel
                {
                    Id = item.Id,
                    CauA = item.CauA,
                    CauB = item.CauB,
                    CauC = item.CauC,
                    CauD = item.CauD,
                    DAn = item.DAn,
                    Mota = item.Mota,
                    Hinhmota = item.Hinhmota,
                    Id_Goicauhoi = item.Id_Goicauhoi,
                    Trangthai = item.Trangthai
                }).Where(x => x.Id_Goicauhoi == id);
            return View(model);
        }
        // GET: CauHoi/Create
        public ActionResult Create()
        {
            int id = ND.GetIDByName(User.Identity.Name);
            ViewBag.listgch = GCH.SelectAll().Where(x => x.Trangthai == true && x.IdNguoidung == id);
            return View();
        }

        // POST: CauHoi/Create
        [HttpPost]
        public ActionResult Create(CauHoiViewModel model, HttpPostedFileBase File)
        {
            int id = ND.GetIDByName(User.Identity.Name);
            try
            {
                
                var path = "";
                if (File != null)
                {
                    if (File.ContentLength > 0)
                    {
                        if (Path.GetExtension(File.FileName).ToLower() == ".jpg"
                            || Path.GetExtension(File.FileName).ToLower() == ".png"
                            || Path.GetExtension(File.FileName).ToLower() == ".gif"
                            || Path.GetExtension(File.FileName).ToLower() == ".jpeg")
                        {

                            string name = DateTime.Now.ToString() + "_" + File.FileName;
                            name = name.Replace(" ", "");
                            name = name.Replace("/", "");
                            name = name.Replace(":", "");
                            path = Path.Combine(Server.MapPath("~/Content/ImgCauHoi/"), name);
                            model.Hinhmota = name;
                            File.SaveAs(path);
                        }
                    }
                    var gch = GCH.SelectById(model.Id_Goicauhoi);
                    var ch = new Cauhoi();
                    ch.Mota = model.Mota;
                    ch.CauA = model.CauA;
                    ch.CauB = model.CauB;
                    ch.CauC = model.CauC;
                    ch.CauD = model.CauD;
                    ch.DAn = model.DAn;
                    ch.IdNguoidung = id;
                    ch.Hinhmota = model.Hinhmota;
                    ch.Id_Goicauhoi = model.Id_Goicauhoi;
                    ch.Id_Tengoi = gch.IdTengoi;
                    ch.Trangthai = true;
                    CH.Insert(ch);
                    CH.Save();
                }
                // TODO: Add insert logic here
                ViewBag.listgch = GCH.SelectAll().Where(x => x.Trangthai == true && x.IdNguoidung == id);
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.listgch = GCH.SelectAll().Where(x => x.Trangthai == true && x.IdNguoidung == id);
                return View();
            }
        }

        // GET: CauHoi/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.listgch = GCH.SelectAll().Where(x => x.Trangthai == true);
            var ch = CH.SelectById(id);
            var model = new CauHoiViewModel();
            model.Mota = ch.Mota;
            model.CauA = ch.CauA;
            model.CauB = ch.CauB;
            model.CauC = ch.CauC;
            model.CauD = ch.CauD;
            model.DAn = ch.DAn;
            model.Hinhmota = ch.Hinhmota;
            model.Id_Goicauhoi = ch.Id_Goicauhoi;
            return View(model);
        }

        // POST: CauHoi/Edit/5
        [HttpPost]
        public ActionResult Edit(CauHoiViewModel model, HttpPostedFileBase File)
        {
            try
            {
                var path = "";
                var ch = CH.SelectById(model.Id);
                if (File != null)
                {
                    if (File.ContentLength > 0)
                    {
                        if (Path.GetExtension(File.FileName).ToLower() == ".jpg"
                            || Path.GetExtension(File.FileName).ToLower() == ".png"
                            || Path.GetExtension(File.FileName).ToLower() == ".gif"
                            || Path.GetExtension(File.FileName).ToLower() == ".jpeg")
                        {

                            string name = DateTime.Now.ToString() + "_" + File.FileName;
                            name = name.Replace(" ", "");
                            name = name.Replace("/", "");
                            name = name.Replace(":", "");
                            path = Path.Combine(Server.MapPath("~/Content/ImgCauHoi/"), name);
                            model.Hinhmota = name;
                            File.SaveAs(path);
                        }
                    }  
                }
                else
                {
                    model.Hinhmota = ch.Hinhmota;
                }
                ch.Mota = model.Mota;
                ch.CauA = model.CauA;
                ch.CauB = model.CauB;
                ch.CauC = model.CauC;
                ch.CauD = model.CauD;
                ch.DAn = model.DAn;
                ch.Hinhmota = model.Hinhmota;
                ch.Id_Goicauhoi = model.Id_Goicauhoi;
                CH.Update(ch);
                CH.Save();
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(int IdDelete)
        {
            try
            {
                var model = CH.SelectById(IdDelete);
                model.Trangthai = false;
                CH.Update(model);
                CH.Save();
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
