using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using web_baiTapLon.data;

namespace web_baiTapLon.Controllers
{
    public class aboutController : Controller
    {
        // GET: about
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult loadnhanvien()
        {
            dataproducts db = new dataproducts();
            List<dtNhanVien> listnhanvien = db.dtNhanViens.ToList();
            return PartialView("nhanvien", listnhanvien);
        }
        public ActionResult themnhanvien()
        {


            return View();
        }
        [HttpPost]
        public ActionResult themnhanvien(dtNhanVien nhanvien)
        {
            dataproducts db = new dataproducts();
            db.dtNhanViens.Add(nhanvien);
            db.SaveChanges();
            return Redirect("Index");
        }
        [HttpGet]
        public ActionResult Suanhanvien(string MaNV)
        {
            dataproducts db = new dataproducts();
            if (MaNV == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dtNhanVien nhanvien = db.dtNhanViens.Find(MaNV);
            if (nhanvien == null)
            {
                return HttpNotFound();
            }

            //ViewBag.MaLoai = new SelectList(db.dtLoais, "MaLoai", "TenLoai");

            return View(nhanvien);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaSanPham(dtNhanVien nhanvien)
        {
            dataproducts db = new dataproducts();
            if (ModelState.IsValid)
            {
                db.Entry(nhanvien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Xoanhanvien(String MaNV)
        {
            dataproducts db = new dataproducts();
            dtNhanVien nhanvien = db.dtNhanViens.Single(h => h.MaNV == MaNV);
            if (nhanvien == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(nhanvien);
        }

        [HttpPost, ActionName("Xoanhanvien")]
        public ActionResult XacNhanXoa(String MaNV)
        {
            dataproducts db = new dataproducts();
            dtNhanVien nhanvien = db.dtNhanViens.Single(n => n.MaNV == MaNV);
            if (nhanvien == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            db.dtNhanViens.Remove(nhanvien);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult viewupnhanvien()
        {
            return View();
        }
        public ActionResult laynhanvien()
        {
            dataproducts db = new dataproducts();
            List<dtNhanVien> listnhanvien = db.dtNhanViens.ToList();
            return PartialView("Viewupnv", listnhanvien);
        }
    }
}