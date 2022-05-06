using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web_baiTapLon.data;

namespace web_baiTapLon.Models
{
    public class CartModel
    {

        public dtSanPham product { get; set; }
        public String count { get; set; }
        public float money { get; set; }
        public String index { get; set; }

        public CartModel() { }
        public CartModel(dtSanPham product, String count, String index)
        {
            this.product = product;
            this.count = count;
            this.index = index;
            this.money = (float)(this.product.DonGiaBan * int.Parse(this.count));
        }
    }
}