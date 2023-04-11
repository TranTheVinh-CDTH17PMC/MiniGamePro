using MiniGame.Interface;
using MiniGame.Repository;
using MiniGame.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace MiniGame.Controllers
{
    [Authorize]
    public class QuestionPackController : Controller
    {
        private readonly IGoiCauHoi GCH;
        private readonly INguoiDung ND;
        private readonly ICauHoi CH;
        static Regex ConvertToUnsign_rg = null;
        public QuestionPackController()
        {
            GCH = new GoiCauHoiRepository();
            ND = new NguoiDungRepository();
            CH = new CauHoiRepository();
        }
        public QuestionPackController(IGoiCauHoi _GCH, INguoiDung _ND, ICauHoi _CH)
        {
            ND = _ND;
            GCH = _GCH;
            CH = _CH;
        }    
        // GET: GoiCauHoi
        public ActionResult Index()
        {
            int id = ND.GetIDByName(User.Identity.Name);
            IEnumerable<GoiCauHoiViewModel> model = GCH.SelectAll().Select(
                item => new GoiCauHoiViewModel
                {
                    Id = item.Id,
                    Tengoi = item.Tengoi,
                    IdTengoi = item.IdTengoi,
                    IdNguoidung = item.IdNguoidung,
                    Trangthai = item.Trangthai
                }).Where(x=>x.Trangthai==true && x.IdNguoidung == id);
            return View(model);
        }

        // GET: GoiCauHoi/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GoiCauHoi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GoiCauHoi/Create
        [HttpPost]
        public ActionResult Create(string Name)
        {
            try
            {
                int count = GCH.SelectAll().Count();
                string idtengoi = count.ToString() + "2023";
                var model = new GoiCauHoi();
                model.IdNguoidung = 1;
                model.IdTengoi = ChuyenThanhKhongDau(idtengoi);
                model.Tengoi = Name;
                model.Trangthai = true;
                GCH.Insert(model);
                GCH.Save();
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GoiCauHoi/Edit/5
        public ActionResult Edit()
        {
            return View();
        }

        // POST: GoiCauHoi/Edit/5
        [HttpPost]
        public ActionResult Edit(int Id, string Name)
        {
            try
            {
                var model = GCH.SelectById(Id);
                model.Tengoi = Name;
                GCH.Update(model);
                GCH.Save();
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GoiCauHoi/Delete/5
        // POST: GoiCauHoi/Delete/5
        [HttpPost]
        public ActionResult Delete(int Idelete)
        {
            try
            {
                var model = GCH.SelectById(Idelete);
                model.Trangthai = false;
                GCH.Update(model);
                GCH.Save();
                var ch = CH.SelectAll().Where(x => x.Id_Goicauhoi == Idelete);
                foreach(var item in ch)
                {
                    var temp = CH.SelectById(item.Id);
                    temp.Trangthai = false;
                    CH.Update(temp);
                    CH.Save();
                }    
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public static string ChuyenThanhKhongDau(string s)
        {
            if (string.IsNullOrEmpty(s) == true)
                return "";

            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D').Replace(" ", "").ToLower();
        }
    }
}
