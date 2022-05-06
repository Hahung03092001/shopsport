using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_baiTapLon.data;

namespace web_baiTapLon.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult wellcom()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(dtUser objUser)
        {
            dataproducts db = new dataproducts();
            if (ModelState.IsValid)
            {
                var obj = db.dtUsers.Where(x => x.Email.Equals(objUser.Email) &&
                x.Password.Equals(objUser.Password)).FirstOrDefault();
                if (obj != null)
                {
                    
                    Session["TenNguoiDung"] = obj.Email.ToString();
                    return RedirectToAction("wellcom","Login");
                }
            }
            return View(objUser);
        }
    }
   
}