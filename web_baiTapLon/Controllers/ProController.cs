using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using web_baiTapLon.data;

namespace web_baiTapLon.Controllers
{
    public class ProController : Controller
    {
        // GET: Pro
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult loadsp()
        {
           
            dataproducts db = new dataproducts();           
            List<dtSanPham> listsp = db.dtSanPhams.ToList();
            return PartialView("Products", listsp);
        }
        public ActionResult loaisp()
        {
            dataproducts db = new dataproducts();
            List<dtLoai> listloai = db.dtLoais.ToList();
            return PartialView("listloai", listloai);
        }
        public ActionResult laysp(String MaSP)
        {
            dataproducts db = new dataproducts();
            List<dtSanPham> listsp = db.dtSanPhams.ToList();
            return PartialView("Viewup", listsp);
        }
        public ActionResult LoadProducts(String CatId)
        {
            dataproducts db = new dataproducts();
            List<dtSanPham> list = db.dtSanPhams.Where(h => h.MaLoai == CatId).ToList();
            return PartialView("Products", list);

        }
        public ActionResult Themsp()
        {
            dataproducts db = new dataproducts();
            ViewBag.MaLoai = new SelectList(db.dtLoais, "MaLoai", "TenLoai");
            return View();
        }
        [HttpPost]
        public ActionResult Themsp(dtSanPham sanpham)
        {
            dataproducts db = new dataproducts();
            db.dtSanPhams.Add(sanpham);
            db.SaveChanges();
            return Redirect("Index");
        }
        [HttpGet]
        public ActionResult SuaSanPham(string MaSP)
        {
            dataproducts db = new dataproducts();
            if (MaSP == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dtSanPham sanpham = db.dtSanPhams.Find(MaSP);
            if (sanpham == null)
            {
                return HttpNotFound();
            }

            ViewBag.MaLoai = new SelectList(db.dtLoais, "MaLoai", "TenLoai");

            return View(sanpham);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaSanPham( dtSanPham sanpham)
        {
            dataproducts db = new dataproducts();
            if (ModelState.IsValid)
            {
                db.Entry(sanpham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult XoaSanPham(String MaSP)
        {
            dataproducts db = new dataproducts();
            dtSanPham sanpham = db.dtSanPhams.Single(h => h.MaSP == MaSP);
            if (sanpham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sanpham);
        }

        [HttpPost, ActionName("XoaSanPham")]
        public ActionResult XacNhanXoa(string MaSP)
        {
            dataproducts db = new dataproducts();
            dtSanPham sanpham = db.dtSanPhams.Single(n => n.MaSP == MaSP);
            if (sanpham == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            db.dtSanPhams.Remove(sanpham);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult viewupdatesp()
        {
            return View();
        }
        public ActionResult SelectedProduct()
        {
            return View();
        }

        public ActionResult LoadProductsItem(String CatId)
        {
            dataproducts db = new dataproducts();
            List<dtSanPham> list = db.dtSanPhams.Where(h => h.MaSP == CatId).ToList();
            return PartialView("itemProduct", list);
        }
    }
}