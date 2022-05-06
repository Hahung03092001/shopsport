namespace web_baiTapLon.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dtChiTietHDB")]
    public partial class dtChiTietHDB
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(25)]
        public string MaHDB { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaSP { get; set; }

        public int? SLBan { get; set; }

        [Column(TypeName = "money")]
        public decimal? ThanhTien { get; set; }

        [StringLength(100)]
        public string KhuyenMai { get; set; }

        public virtual dtHoaDonBan dtHoaDonBan { get; set; }

        public virtual dtSanPham dtSanPham { get; set; }
    }
}
