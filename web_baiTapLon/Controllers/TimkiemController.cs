using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_baiTapLon.data;

namespace web_baiTapLon.Controllers
{
    public class TimkiemController : Controller
    {
        // GET: Timkiem
        public ActionResult Index()
        {
            return View();
        }
        dataproducts db = new dataproducts();
        [HttpPost]
        public ActionResult Ketquatimkiem(FormCollection f)
        {
            string searchkey = f["txtsearchkey"].ToString();
            ViewBag.keyword = searchkey;
            List<dtSanPham> lstKQ = db.dtSanPhams.Where(n => n.TenSP.Contains(searchkey)).ToList();
            
            if (lstKQ.Count == 0)
            {
                ViewBag.Thongbao = "Không có sản phẩm bạn đang tìm kiếm !";
                return View(db.dtSanPhams.OrderBy(n => n.TenSP));
            }
            ViewBag.Thongbao = "Đã tìm thấy " + lstKQ.Count + " sản phẩm ";
            return PartialView("show_timkiem",lstKQ.OrderBy(n => n.TenSP));
        }

        [HttpGet]
        public ActionResult Ketquatimkiem( string searchkey)
        {
            ViewBag.keyword = searchkey;
            List<dtSanPham> lstKQ = db.dtSanPhams.Where(n => n.TenSP.Contains(searchkey)).ToList();
            
            if (lstKQ.Count == 0)
            {
                ViewBag.Thongbao = "Không có sản phẩm bạn đang tìm kiếm !";
                return View(db.dtSanPhams.OrderBy(n => n.TenSP));
            }
            ViewBag.Thongbao = "Đã tìm thấy " + lstKQ.Count + " sản phẩm ";
            return View(lstKQ.OrderBy(n => n.TenSP));
        }
    }
}