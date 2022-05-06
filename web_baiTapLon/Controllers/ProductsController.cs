using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_baiTapLon.data;

namespace web_baiTapLon.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult spbanchay()
        {
            dataproducts db = new dataproducts();
            var a = from b in db.dtChiTietHDBs
                    join ab in db.dtSanPhams on b.MaSP equals ab.MaSP
                    group b by b.MaSP into gr
                    orderby db.dtChiTietHDBs.Sum(s => s.SLBan) descending
                    select gr.Take(3);
            


            return PartialView("productHome", a);
        }


    }
}