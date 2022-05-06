using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_baiTapLon.data;
using web_baiTapLon.Models;

namespace web_baiTapLon.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoadProductsCart(String CatId, String count, String index)
        {
            dataproducts db = new dataproducts();
            //dtSanPham sp = (dtSanPham)db.dtSanPhams.Where(h => h.MaSP == CatId);
            List<dtSanPham> listsp = db.dtSanPhams.Where(h => h.MaSP == CatId).ToList();
            List<CartModel> listCart = new List<CartModel>();
            if (listsp.Count > 0)
            {
                CartModel c = new CartModel(product: listsp[0], count: count, index: index);
                listCart.Add(c);
            }

            return PartialView("listProduct", listCart);
        }
        public ActionResult layhdb()
        {
            dataproducts db = new dataproducts();
            List<dtChiTietHDB> listhd = db.dtChiTietHDBs.ToList();
            return PartialView("Viewhd", listhd);
        }
        public ActionResult qlyhd()
        {
            return View();
        }
    }
}